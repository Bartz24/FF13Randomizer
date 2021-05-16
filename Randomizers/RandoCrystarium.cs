using Bartz24.Docs;
using FF13Data;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FF13Randomizer
{
    public class RandoCrystarium : Randomizer
    {
        public static string[] CharNames = new string[] { "lightning", "fang", "snow", "sazh", "hope", "vanille" };

        public Dictionary<Role, StatValues> roleMults = new Dictionary<Role, StatValues>();
        public Dictionary<string, StatValues> charMults = new Dictionary<string, StatValues>();
        public Dictionary<string, DataStoreWDB<DataStoreCrystarium, DataStoreIDCrystarium>> crystariums = new Dictionary<string, DataStoreWDB<DataStoreCrystarium, DataStoreIDCrystarium>>();
        public Dictionary<string, Role[]> primaryRoles = new Dictionary<string, Role[]>();

        public RandoCrystarium(FormMain formMain, RandomizerManager randomizers) : base(formMain, randomizers) { }

        public override string GetProgressMessage()
        {
            return "Randomizing Crystarium...";
        }

        public override string GetID()
        {
            return "Crystarium";
        }

        public override void Load()
        {
            base.Load();

            primaryRoles.Add("lightning", new Role[] { Role.Commando, Role.Ravager, Role.Medic });
            primaryRoles.Add("fang", new Role[] { Role.Commando, Role.Sentinel, Role.Saboteur });
            primaryRoles.Add("snow", new Role[] { Role.Commando, Role.Ravager, Role.Sentinel });
            primaryRoles.Add("sazh", new Role[] { Role.Commando, Role.Ravager, Role.Synergist });
            primaryRoles.Add("hope", new Role[] { Role.Ravager, Role.Synergist, Role.Medic });
            primaryRoles.Add("vanille", new Role[] { Role.Ravager, Role.Saboteur, Role.Medic });

            foreach (string name in CharNames)
            {
                DataStoreWDB<DataStoreCrystarium, DataStoreIDCrystarium> cryst = new DataStoreWDB<DataStoreCrystarium, DataStoreIDCrystarium>();
                cryst.LoadData(File.ReadAllBytes($"{main.RandoPath}\\original\\db\\crystal\\crystal_{name}.wdb"));
                crystariums.Add(name, cryst);
            }
        }
        public override void Randomize(BackgroundWorker backgroundWorker)
        {

            Dictionary<int, Dictionary<CrystariumType, List<int>>> statAverages = new Dictionary<int, Dictionary<CrystariumType, List<int>>>();
            if (Flags.CrystariumFlags.RandStats)
                statAverages = GetStatAverages();

            Dictionary<string, Dictionary<Role, List<Ability>>> nodes = GetNodeAbilities();

            Dictionary<string, Dictionary<string, Tuple<CrystariumType, Ability, int>>> plando = CharNames.ToDictionary(c => c, c => new Dictionary<string, Tuple<CrystariumType, Ability, int>>());
            if (Flags.CrystariumFlags.ShuffleNodes)
            {
                plando = main.crystariumPlando1.GetNodes();
                PlaceNodes(plando, nodes);
            }
            backgroundWorker.ReportProgress(10);
            if (Flags.CrystariumFlags.RandStats)
                RandomizeStats(plando, statAverages);

            backgroundWorker.ReportProgress(20);

            backgroundWorker.ReportProgress(40);

            RandomizeAbilities(plando);

            foreach (string name in CharNames)
            {
                foreach (DataStoreIDCrystarium id in crystariums[name].IdList.Where(id => !id.ID.StartsWith("!")))
                {
                    DataStoreCrystarium c = crystariums[name][id.ID];
                    if (c.Type == CrystariumType.Unknown)
                        throw new Exception($"{name.Substring(0, 1).ToUpper() + name.Substring(1)} {c.Role} Stage {c.Stage} Node {Crystarium.GetDisplayNames(crystariums[name])[id]} is invalid.");
                }
            }
            backgroundWorker.ReportProgress(70);

            if (Flags.CrystariumFlags.RandCP)
                RandomizeCPCosts();

            if (Tweaks.Boosts.HalfSecondaryCPCost)
                ApplyHalfCPCosts();

            if (Tweaks.Boosts.ScaledCPCost)
                ApplyScaledCPCosts();

            if (Flags.CrystariumFlags.RandCP)
                ApplyPlandoCPCosts();

            backgroundWorker.ReportProgress(100);
        }

        public void ApplyPlandoCPCosts()
        {
            Dictionary<string, Dictionary<string, int>> plando = main.crystariumPlando1.GetCPCosts();

            foreach (string name in CharNames)
            {
                foreach (string id in plando[name].Keys)
                {
                    crystariums[name][id].CPCost = (uint)plando[name][id];
                }
            }
        }

        public void ApplyScaledCPCosts()
        {
            foreach (string name in CharNames)
            {
                foreach (DataStoreCrystarium c in crystariums[name].DataList)
                {
                    if (c.CPCost > 0)
                    {
                        int cpCost = (int)Math.Floor(c.CPCost * Math.Max(0.5, Math.Min(1, 1.08684 * Math.Exp(-0.08664 * c.Stage))));
                        c.CPCost = Math.Max(1, (uint)(Math.Round(cpCost / 5.0 / Math.Floor(Math.Log10(cpCost))) * 5 * Math.Floor(Math.Log10(cpCost))));
                    }
                }
            }
        }
        public void ApplyHalfCPCosts()
        {
            foreach (string name in CharNames)
            {
                foreach (DataStoreCrystarium c in crystariums[name].DataList)
                {
                    if (c.CPCost > 0 && !primaryRoles[name].Contains(c.Role))
                    {
                        c.CPCost = Math.Max(1, c.CPCost / 2);
                    }
                }
            }
        }

        public void RandomizeCPCosts()
        {
            Flags.CrystariumFlags.RandCP.SetRand();
            foreach (string name in CharNames)
            {
                foreach (Role role in Enum.GetValues(typeof(Role)))
                {
                    if (role == Role.None)
                        continue;
                    List<DataStoreIDCrystarium> roleCrysts = crystariums[name].IdList.Where(id => !id.ID.StartsWith("!") && crystariums[name][id.ID].CPCost > 0 && crystariums[name][id.ID].Role == role).ToList();
                    for (int stage = 1; stage <= 10; stage++)
                    {
                        List<DataStoreIDCrystarium> crysts = roleCrysts.Where(id => crystariums[name][id.ID].Stage == stage).ToList();
                        int[] weights = crysts.Select(id =>
                        {
                            DataStoreCrystarium c = crystariums[name][id.ID];
                            int val = 10000;
                            if (Flags.CrystariumFlags.RandCP.ExtraSelected && (c.Type == CrystariumType.Ability || c.Type == CrystariumType.Accessory || c.Type == CrystariumType.ATBLevel || c.Type == CrystariumType.RoleLevel))
                                val = (int)(val * 2);
                            if(id.SubNode > 0)
                                val = (int)(val * 1.5);
                            return val;
                        }).ToArray();

                        StatValuesWeighted cpCosts = new StatValuesWeighted(weights);
                        Tuple<int, int>[] bounds = Enumerable.Range(0, crysts.Count).Select(i => new Tuple<int, int>(1, Int32.MaxValue)).ToArray();
                        cpCosts.Randomize(bounds, crysts.Select(id =>  (long)crystariums[name][id.ID].CPCost).Sum());

                        for(int i = 0; i < crysts.Count; i++)
                        {
                            crystariums[name][crysts[i].ID].CPCost = (uint)cpCosts[i];
                        }
                    }
                }
            }
            RandomNum.ClearRand();
        }

        public Dictionary<string, Dictionary<Role, List<Ability>>> GetNodeAbilities()
        {
            Dictionary<string, Dictionary<Role, List<Ability>>> dict = new Dictionary<string, Dictionary<Role, List<Ability>>>();
            foreach (string name in CharNames)
            {
                Dictionary<Role, List<Ability>> abilities = new Dictionary<Role, List<Ability>>();
                foreach (Role role in Enum.GetValues(typeof(Role)))
                {
                    abilities.Add(role, crystariums[name].DataList.Where(c => c.Role == role && c.Type == CrystariumType.Ability && c.CPCost > 0 && (c.Stage > 1 || primaryRoles[name].Contains(c.Role))).Select(c => Abilities.GetAbility(name, c)).ToList());
                }
                dict.Add(name, abilities);
            }
            return dict;
        }

        public Dictionary<int, Dictionary<CrystariumType, List<int>>> GetStatAverages()
        {
            Dictionary<int, Dictionary<CrystariumType, List<int>>> statAverages = new Dictionary<int, Dictionary<CrystariumType, List<int>>>();
            Flags.CrystariumFlags.RandStats.SetRand();
            foreach (Role role in Enum.GetValues(typeof(Role)))
            {
                StatValues stats = new StatValues(3);
                int variance = Flags.CrystariumFlags.RandStats.Range.Value;
                stats.Randomize(variance);
                roleMults.Add(role, stats);
            }

            foreach (string name in CharNames)
            {
                StatValues stats = new StatValues(3);
                int variance = Flags.CrystariumFlags.RandStats.Range.Value;
                stats.Randomize(variance);
                charMults.Add(name, stats);
            }

            for (int stage = 1; stage <= 10; stage++)
            {
                Dictionary<CrystariumType, List<int>> dict = new Dictionary<CrystariumType, List<int>>();
                dict.Add(CrystariumType.HP, new List<int>());
                dict.Add(CrystariumType.Strength, new List<int>());
                dict.Add(CrystariumType.Magic, new List<int>());
                statAverages.Add(stage, dict);
            }

            foreach (string name in crystariums.Keys)
            {
                foreach (DataStoreCrystarium c in crystariums[name].DataList)
                {
                    if (c.Type == CrystariumType.HP || c.Type == CrystariumType.Strength || c.Type == CrystariumType.Magic)
                    {
                        statAverages[c.Stage][c.Type].Add(c.Value);
                    }
                }
            }

            if (Tweaks.Challenges.Stats1StageBehind)
            {
                for (int stage = 10; stage > 1; stage--)
                {
                    statAverages[stage] = statAverages[stage - 1];
                }
                Dictionary<CrystariumType, List<int>> dict = new Dictionary<CrystariumType, List<int>>();
                dict.Add(CrystariumType.HP, new List<int>());
                dict[CrystariumType.HP].Add(0);
                dict.Add(CrystariumType.Strength, new List<int>());
                dict[CrystariumType.HP].Add(0);
                dict.Add(CrystariumType.Magic, new List<int>());
                dict[CrystariumType.HP].Add(0);
                statAverages[1] = dict;
            }

            statAverages.Values.ForEach(d =>
            {
                d.Keys.ToList().ForEach(k =>
                {
                    int avg = (int)Math.Ceiling((double)d[k].Sum(v => v) / d[k].Count);
                    d[k].Clear();
                    d[k].Add(avg);
                });
                int avgStrMag = (d[CrystariumType.Strength][0] + d[CrystariumType.Magic][0]) / 2;
                d[CrystariumType.Strength][0] = d[CrystariumType.Magic][0] = (int)Math.Max(1, avgStrMag * 1.04 * 0.7);
                d[CrystariumType.HP][0] = (int)Math.Max(1, d[CrystariumType.HP][0] * 1.03 * 1.85);
            });
            RandomNum.ClearRand();
            return statAverages;
        }

        public void SetRemaining(List<DataStoreCrystarium> list)
        {
            foreach (string name in CharNames)
            {
                DataStoreWDB<DataStoreCrystarium, DataStoreIDCrystarium> crystarium = crystariums[name];
                foreach (DataStoreCrystarium c in list)
                {
                    if (!(c.Type == CrystariumType.HP || c.Type == CrystariumType.Strength || c.Type == CrystariumType.Magic))
                    {
                        int stage = c.Stage;
                        List<DataStoreCrystarium> others;
                        do
                        {
                            others = new CrystariumType[] { CrystariumType.HP, CrystariumType.Strength, CrystariumType.Magic }.SelectMany(t => crystarium.DataList.Where(o => o.Role == c.Role && o.Stage == stage && o.Type == t)).ToList();
                            stage--;
                        } while (others.Count == 0 && stage > 0);
                        if (others.Count > 0)
                        {
                            DataStoreCrystarium other = others[RandomNum.RandInt(0, others.Count - 1)];
                            c.Type = other.Type;
                            c.Value = other.Value;
                        }
                        else
                        {
                            c.Type = new CrystariumType[] { CrystariumType.HP, CrystariumType.Strength, CrystariumType.Magic }[RandomNum.RandInt(0, 2)];
                            c.Value = 1;
                        }
                    }
                }
            }
        }

        public void RandomizeStats(Dictionary<string, Dictionary<string, Tuple<CrystariumType, Ability, int>>> plando, Dictionary<int, Dictionary<CrystariumType, List<int>>> statAverages)
        {
            Flags.CrystariumFlags.RandStats.SetRand();
            foreach (string name in CharNames)
            {
                DataStoreWDB<DataStoreCrystarium, DataStoreIDCrystarium> crystarium = crystariums[name];

                Dictionary<int, Dictionary<Role, int>> nodeCounts = new Dictionary<int, Dictionary<Role, int>>();
                for (int stage = 1; stage <= 10; stage++)
                {
                    Dictionary<Role, int> stageDict = new Dictionary<Role, int>();
                    foreach (Role role in Enum.GetValues(typeof(Role)))
                    {
                        stageDict.Add(role, crystarium.DataList.Where(
                            c => c.Stage == stage && c.Role == role &&
                            (c.Type == CrystariumType.HP || c.Type == CrystariumType.Strength || c.Type == CrystariumType.Magic))
                            .Count());
                    }
                    nodeCounts.Add(stage, stageDict);
                }

                foreach (DataStoreCrystarium c in crystarium.DataList)
                {
                    if ((c.Type == CrystariumType.Unknown || c.Type == CrystariumType.HP || c.Type == CrystariumType.Strength || c.Type == CrystariumType.Magic) &&
                        !plando[name].Keys.Select(k => crystarium[k]).Contains(c))
                    {
                        c.Type = RandomNum.SelectRandomWeighted(
                            new CrystariumType[] { CrystariumType.HP, CrystariumType.Strength, CrystariumType.Magic }.ToList(),
                            t => Math.Max(1, (int)Math.Pow(
                                t == CrystariumType.HP ? (charMults[name][0] * roleMults[c.Role][0]) : (
                                t == CrystariumType.Strength ? (charMults[name][1] * roleMults[c.Role][1]) :
                                (charMults[name][2] * roleMults[c.Role][2])), 1 / 1.5d)));

                        if (Tweaks.Challenges.Stats1StageBehind && c.Stage == 1)
                        {
                            c.Value = 0;
                            continue;
                        }

                        int stage = c.Stage + (Tweaks.Challenges.Stats1StageBehind ? -1 : 0);
                        int avgValue = (int)Math.Ceiling(statAverages[c.Stage][c.Type][0] * Math.Pow(1.1, stage * 0.07 + 0.1 + (stage == 10 ? 1.8 : 0)));
                        if (stage == 10 && c.Type == CrystariumType.HP)
                            avgValue = (int)Math.Ceiling(avgValue * 1.8);
                        if (primaryRoles[name].Contains(c.Role))
                        {
                            //avgValue = (int)Math.Ceiling(avgValue * (5 * Math.Exp(-0.5d * nodeCounts[c.Stage][c.Role]) + 1));
                        }
                        else
                            avgValue = (int)Math.Ceiling(Math.Log(avgValue, 3) * Math.Pow(avgValue, 0.4));

                        if (name != "fang" && c.CPCost == 0)
                            avgValue = (int)Math.Floor(avgValue * 2.8d);
                        if (c.Type == CrystariumType.HP)
                            avgValue = (int)Math.Ceiling(avgValue * 0.9);


                        if (c.Type == CrystariumType.HP)
                            c.Value = (ushort)Math.Round(Math.Max(1,
                                (float)avgValue * (float)charMults[name][0] * (float)roleMults[c.Role][0] / 10000f));
                        if (c.Type == CrystariumType.Strength)
                            c.Value = (ushort)Math.Round(Math.Max(1,
                                (float)avgValue * (float)charMults[name][1] * (float)roleMults[c.Role][1] / 10000f));
                        if (c.Type == CrystariumType.Magic)
                            c.Value = (ushort)Math.Round(Math.Max(1,
                                (float)avgValue * (float)charMults[name][2] * (float)roleMults[c.Role][2] / 10000f));
                    }
                }

                foreach (Role role in Enum.GetValues(typeof(Role)))
                {
                    List<DataStoreCrystarium> list = crystarium.DataList.Where(
                    c => (c.Type == CrystariumType.HP ||
                c.Type == CrystariumType.Strength ||
                c.Type == CrystariumType.Magic) && c.Role == role && !plando[name].Keys.Select(k => crystarium[k]).Contains(c)).ToList();

                    for (int i = 0; i < list.Count() / 2; i++)
                    {
                        DataStoreCrystarium c = list[RandomNum.RandInt(0, list.Count - 1)];
                        int count = list.Where(c2 => c.Type == c2.Type).Count();
                        float mult = RandomNum.RandInt(100, 100 + (int)Math.Sqrt(Math.Max(0, (count - 1)) * 20)) / 100f;
                        list.ForEach(cr =>
                        {
                            if (c.Type == cr.Type && c.Stage == cr.Stage && cr.Value > 0)
                                cr.Value = (ushort)Math.Max(1, Math.Ceiling(cr == c ? (cr.Value * mult) : (cr.Value / Math.Pow(mult, 1 / 2.2f) - 1)));
                        });
                        if (c.Value > 0)
                            c.Value = (ushort)Math.Max(1, (int)c.Value);
                    }
                }
            }
            RandomNum.ClearRand();
        }

        public void PlaceNodes(Dictionary<string, Dictionary<string, Tuple<CrystariumType, Ability, int>>> plando, Dictionary<string, Dictionary<Role, List<Ability>>> nodes)
        {
            Flags.CrystariumFlags.ShuffleNodes.SetRand();

            foreach (string name in CharNames)
            {
                Dictionary<Role, int> origAbilityCounts = Enumerable.Range(1, 6).ToDictionary(i => (Role)i, i => nodes[name][(Role)i].Count);

                List<DataStoreCrystarium> unknowns = crystariums[name].DataList.Where(c => c.CPCost > 0 && (c.Stage > 1 || primaryRoles[name].Contains(c.Role))).ToList();

                foreach (string id in plando[name].Keys)
                {
                    DataStoreCrystarium cryst = crystariums[name][id];

                    if (plando[name][id].Item1 == CrystariumType.Ability)
                    {
                        cryst.Type = CrystariumType.Ability;
                        if (plando[name][id].Item2 != null)
                        {
                            cryst.AbilityName = plando[name][id].Item2.GetAbility(Abilities.GetCharID(name));
                            nodes.Values.ForEach(d => d.Values.ForEach(l => l.RemoveAll(a => a == plando[name][id].Item2)));
                        }
                        else
                            cryst.AbilityName = "";
                    }
                    else
                    {
                        cryst.Type = plando[name][id].Item1;
                        cryst.Value = (ushort)plando[name][id].Item3;
                    }
                    unknowns.Remove(cryst);
                }

                List<DataStoreCrystarium> possible;

                for (Role role = (Role)1; role <= (Role)6; role++)
                {
                    possible = crystariums[name].IdList.Where(
                        id => !id.ID.StartsWith("!") && !plando[name].Keys.Contains(id.ID)).Select(id => crystariums[name][id.ID]).Where(
                        c => c.Role == role &&
                        c.CPCost > 0 && (c.Stage > 1 || primaryRoles[name].Contains(role))
                        && unknowns.Contains(c)).ToList();

                    int abilityCount = crystariums[name].DataList.Where(c => c.Role == role && c.Type == CrystariumType.Ability && !unknowns.Contains(c) && c.CPCost > 0 && (c.Stage > 1 || primaryRoles[name].Contains(role))).Count();
                    for (int i = 0; i < origAbilityCounts[role] - abilityCount; i++)
                    {
                        int select = RandomNum.RandInt(0, possible.Count - 1);
                        possible[select].Type = CrystariumType.Ability;
                        possible[select].AbilityName = nodes[name][role][i].GetAbility(Abilities.GetCharID(name));
                        unknowns.Remove(possible[select]);
                        possible.RemoveAt(select);
                    }

                    int roleLevelCount = crystariums[name].DataList.Where(c => c.Role == role && c.Type == CrystariumType.RoleLevel && !unknowns.Contains(c)).Count();
                    for (int i = 0; i < 4 - roleLevelCount; i++)
                    {
                        int select = RandomNum.RandInt(0, possible.Count - 1);
                        possible[select].Type = CrystariumType.RoleLevel;
                        unknowns.Remove(possible[select]);
                        possible.RemoveAt(select);
                    }
                }

                possible = crystariums[name].IdList.Where(
                    id => !id.ID.StartsWith("!") && !plando[name].Keys.Contains(id.ID)).Select(id => crystariums[name][id.ID]).Where(
                    c => c.CPCost > 0 && (c.Stage > 1 || primaryRoles[name].Contains(c.Role)) && unknowns.Contains(c)).ToList();

                int atbLevelCount = crystariums[name].DataList.Where(c => c.Type == CrystariumType.ATBLevel && !unknowns.Contains(c)).Count();
                if (atbLevelCount == 0)
                {
                    int select = RandomNum.RandInt(0, possible.Count - 1);
                    possible[select].Type = CrystariumType.ATBLevel;
                    unknowns.Remove(possible[select]);
                    possible.RemoveAt(select);
                }

                int accessoryCount = crystariums[name].DataList.Where(c => c.Type == CrystariumType.Accessory && !unknowns.Contains(c)).Count();
                for (int i = 0; i < 3 - accessoryCount; i++)
                {
                    int select = RandomNum.RandInt(0, possible.Count - 1);
                    possible[select].Type = CrystariumType.Accessory;
                    unknowns.Remove(possible[select]);
                    possible.RemoveAt(select);
                }

                SetRemaining(unknowns);
            }

            foreach (string name in CharNames)
            {
                for (Role role = (Role)1; role <= (Role)6; role++)
                {
                    for (int stage = 1; stage <= 10; stage++)
                    {
                        List<DataStoreCrystarium> shuffle = crystariums[name].IdList.Where(
                            id => !id.ID.StartsWith("!") && !plando[name].Keys.Contains(id.ID)).Select(id => crystariums[name][id.ID]).Where(
                            c => c.Role == role &&
                            c.Stage == stage &&
                            c.CPCost > 0 && (c.Stage > 1 || primaryRoles[name].Contains(role))).ToList();
                        shuffle.Shuffle((a, b) => a.SwapStatsAbilities(b));
                    }
                }
            }

            RandomNum.ClearRand();
        }

        public void ShuffleTechniques(Dictionary<string, Dictionary<string, Tuple<CrystariumType, Ability, int>>> plando, string name, DataStoreWDB<DataStoreCrystarium, DataStoreIDCrystarium> crystarium)
        {
            if (Flags.CrystariumFlags.NewAbilities)
            {
                List<string> techniqueIDs = Abilities.abilities.Where(a => a.Role == Role.None).SelectMany(a => a.GetIDs()).ToList();

                Flags.CrystariumFlags.NewAbilities.SetRand();
                crystarium.DataList
                .Where(c => c.Type == CrystariumType.Ability
                && techniqueIDs.Contains(c.AbilityName)
                && (!Flags.CrystariumFlags.NewAbilities.ExtraSelected2 || (Flags.CrystariumFlags.NewAbilities.ExtraSelected2 && Abilities.GetAbility(name, c) != Abilities.Libra))
                && !plando[name].Keys.Select(k => crystarium[k]).Contains(c))
                .ToList().Shuffle((a, b) => a.SwapStatsAbilities(b));
                RandomNum.ClearRand();
            }
        }

        public void ShuffleAnyRole(Dictionary<string, Dictionary<string, Tuple<CrystariumType, Ability, int>>> plando, string name, DataStoreWDB<DataStoreCrystarium, DataStoreIDCrystarium> crystarium)
        {
            if (Flags.CrystariumFlags.NewAbilities && Flags.CrystariumFlags.NewAbilities.ExtraSelected)
            {
                Flags.CrystariumFlags.NewAbilities.SetRand();
                crystarium.DataList
                .Where(c => c.Type == CrystariumType.Ability
                && c.CPCost > 0 && (primaryRoles[name].Contains(c.Role) || c.Stage > 1)
                && !plando[name].Keys.Select(k => crystarium[k]).Contains(c))
                .ToList().Shuffle((a, b) => a.SwapStatsAbilities(b));
                RandomNum.ClearRand();
            }
        }

        public void RandomizeAbilities(Dictionary<string, Dictionary<string, Tuple<CrystariumType, Ability, int>>> plando)
        {
            foreach (string name in CharNames)
            {
                DataStoreWDB<DataStoreCrystarium, DataStoreIDCrystarium> crystarium = crystariums[name];

                ShuffleTechniques(plando, name, crystarium);

                List<Tiered<Ability>> added = new List<Tiered<Ability>>();
                List<Ability> obtained = new List<Ability>();

                Dictionary<Role, List<int>> startingNodes = new Dictionary<Role, List<int>>();
                for (int r = 1; r <= 6; r++)
                {
                    List<int> startingNodeList = new List<int>();
                    Role role = (Role)r;
                    if (Flags.CrystariumFlags.NewAbilities)
                    {
                        Flags.CrystariumFlags.NewAbilities.SetRand();
                        List<int> abilityNodes = new List<int>();
                        for (int i = 0; i < crystarium.DataList.Count; i++)
                        {
                            DataStoreCrystarium c = crystarium.DataList[i];
                            if (c.Role == role && c.Type == CrystariumType.Ability && (!plando[name].Keys.Select(k => crystarium[k]).Contains(c) || string.IsNullOrEmpty(c.AbilityName)))
                                abilityNodes.Add(i);
                        }
                        abilityNodes.Sort((a, b) => crystarium.DataList[a].Stage.CompareTo(crystarium.DataList[b].Stage));

                        List<Tiered<Ability>> starting = TieredAbilities.manager.list.Where(
                    t => t.Items.Where(a => a.Role == role && !a.Special && a.Starting && a.HasCharacter(Abilities.GetCharID(name))).Count() > 0 && !added.Contains(t)).ToList();

                        int maxStage = 1;
                        for (int i = 0; i < abilityNodes.Count; i++)
                        {
                            DataStoreCrystarium cryst = crystarium.DataList[abilityNodes[i]];
                            if (cryst.Stage < maxStage)
                                throw new Exception("Went down in stage!");
                            maxStage = cryst.Stage;
                            Ability orig = Abilities.GetAbility(name, cryst);

                            if (orig != null && orig.Special)
                                continue;

                            if (cryst.CPCost == 0 || (!primaryRoles[name].Contains(role) && cryst.Stage == 1))
                            {
                                int newI;
                                Ability ability;
                                do
                                {
                                    newI = RandomNum.RandInt(0, starting.Count - 1);
                                    ability = Flags.CrystariumFlags.NewAbilities.ExtraSelected ? TieredAbilities.GetNoDep(starting[newI]) : TieredAbilities.Get(starting[newI], obtained);
                                } while (ability == null);
                                cryst.AbilityName = ability.GetAbility(Abilities.GetCharID(name));
                                obtained.Add(ability);
                                added.Add(starting[newI]);
                                starting.RemoveAt(newI);
                                startingNodeList.Add(abilityNodes[i]);
                                abilityNodes.RemoveAt(i);
                                break;
                            }
                        }
                        maxStage = 1;
                        startingNodes.Add(role, startingNodeList);
                        RandomNum.ClearRand();
                    }
                }
                for (int r = 1; r <= 6; r++)
                {
                    Role role = (Role)r;
                    int maxStage = 1;
                    if (Flags.CrystariumFlags.NewAbilities)
                    {
                        Flags.CrystariumFlags.NewAbilities.SetRand();
                        List<int> abilityNodes = new List<int>();
                        for (int i = 0; i < crystarium.DataList.Count; i++)
                        {
                            DataStoreCrystarium c = crystarium.DataList[i];
                            if (c.Role == role && c.Type == CrystariumType.Ability && !startingNodes[role].Contains(i) && c.CPCost == 0 && (!plando[name].Keys.Select(k => crystarium[k]).Contains(c) || string.IsNullOrEmpty(c.AbilityName)))
                                abilityNodes.Add(i);
                        }
                        abilityNodes.Sort((a, b) => crystarium.DataList[a].Stage.CompareTo(crystarium.DataList[b].Stage));

                        List<Tiered<Ability>> rest = TieredAbilities.manager.list.Where(
                    t => t.Items.Where(a => a.Role == role && !a.Special && a.HasCharacter(Abilities.GetCharID(name))).Count() > 0 && !added.Contains(t)).ToList();
                        for (int i = 0; i < abilityNodes.Count; i++)
                        {
                            DataStoreCrystarium cryst = crystarium.DataList[abilityNodes[i]];
                            if (cryst.Stage < maxStage)
                                throw new Exception("Went down in stage!");
                            maxStage = cryst.Stage;

                            Ability orig = Abilities.GetAbility(name, cryst);

                            if (orig != null && orig.Special)
                                continue;

                            int newI;
                            Ability ability;
                            do
                            {
                                newI = RandomNum.RandInt(0, rest.Count - 1);
                                ability = Flags.CrystariumFlags.NewAbilities.ExtraSelected ? TieredAbilities.GetNoDep(rest[newI]) : TieredAbilities.Get(rest[newI], obtained);
                            } while (ability == null);
                            cryst.AbilityName = ability.GetAbility(Abilities.GetCharID(name));
                            obtained.Add(ability);
                            added.Add(rest[newI]);
                            rest.RemoveAt(newI);
                            startingNodes[role].Add(i);
                        }
                        RandomNum.ClearRand();
                    }
                }
                for (int r = 1; r <= 6; r++)
                {
                    Role role = (Role)r;
                    int maxStage = 1;
                    if (Flags.CrystariumFlags.NewAbilities.FlagEnabled)
                    {
                        Flags.CrystariumFlags.NewAbilities.SetRand();
                        List<int> abilityNodes = new List<int>();
                        for (int i = 0; i < crystarium.DataList.Count; i++)
                        {
                            DataStoreCrystarium c = crystarium.DataList[i];
                            if (c.Role == role && c.Type == CrystariumType.Ability && !startingNodes[role].Contains(i) && c.CPCost > 0 && (!plando[name].Keys.Select(k => crystarium[k]).Contains(c) || string.IsNullOrEmpty(c.AbilityName)))
                                abilityNodes.Add(i);
                        }
                        abilityNodes.Sort((a, b) => crystarium.DataList[a].Stage.CompareTo(crystarium.DataList[b].Stage));

                        List<Tiered<Ability>> rest = TieredAbilities.manager.list.Where(
                    t => t.Items.Where(a => (a.Role == role || Flags.CrystariumFlags.NewAbilities.ExtraSelected) && !a.Special && a.HasCharacter(Abilities.GetCharID(name))).Count() > 0 && !added.Contains(t)).ToList();
                        for (int i = 0; i < abilityNodes.Count; i++)
                        {
                            DataStoreCrystarium cryst = crystarium.DataList[abilityNodes[i]];
                            if (cryst.Stage < maxStage)
                                throw new Exception("Went down in stage!");
                            maxStage = cryst.Stage;

                            Ability orig = Abilities.GetAbility(name, cryst);

                            if (orig != null && orig.Special)
                                continue;

                            int newI;
                            Ability ability;
                            do
                            {
                                newI = RandomNum.RandInt(0, rest.Count - 1);
                                ability = Flags.CrystariumFlags.NewAbilities.ExtraSelected ? TieredAbilities.GetNoDep(rest[newI]) : TieredAbilities.Get(rest[newI], obtained);
                            } while (ability == null);
                            cryst.AbilityName = ability.GetAbility(Abilities.GetCharID(name));
                            obtained.Add(ability);
                            added.Add(rest[newI]);
                            rest.RemoveAt(newI);
                        }
                        RandomNum.ClearRand();
                    }
                }
                ShuffleAnyRole(plando, name, crystarium);
            }
        }

        public override void Save()
        {
            base.Save();

            foreach (string name in CharNames)
            {
                DataStoreWDB<DataStoreCrystarium, DataStoreIDCrystarium> crystarium = crystariums[name];

                File.WriteAllBytes($"db\\crystal\\crystal_{name}.wdb", crystarium.Data);
            }

            DocsJSONGenerator.CreateCrystariumDocs(crystariums, primaryRoles);
        }

        public override HTMLPage GetDocumentation()
        {
            HTMLPage page = new HTMLPage("Crystarium", "template/documentation.html");

            CharNames.ForEach(name =>
            {
                page.HTMLElements.Add(new Table(name[0].ToString().ToUpper() + name.Substring(1),
                    new string[] { "Stage", "Commando", "Ravager", "Sentinel", "Synergist", "Saboteur", "Medic"}.ToList(),
                    new int[] { 10, 15, 15, 15, 15, 15, 15 }.ToList(),
                    Enumerable.Range(1, 10).Select(stage => {
                        List<string> list = new List<string>();
                        list.Add(stage.ToString());
                        list.AddRange(new string[] { "", "", "", "", "", "" });
                        foreach (Role role in Enum.GetValues(typeof(Role)))
                        {
                            List<string> additions = new List<string>();
                            if (role == Role.None)
                                continue;
                            List<DataStoreCrystarium> roleCrysts = crystariums[name].IdList.Where(id => !id.ID.StartsWith("!") && crystariums[name][id.ID].Role == role && crystariums[name][id.ID].Stage == stage).Select(id => crystariums[name][id.ID]).ToList();
                            int hp = roleCrysts.Where(c => c.Type == CrystariumType.HP).Sum(c => c.Value);
                            int strength = roleCrysts.Where(c => c.Type == CrystariumType.Strength).Sum(c => c.Value);
                            int magic = roleCrysts.Where(c => c.Type == CrystariumType.Magic).Sum(c => c.Value);
                            int roleLevels = roleCrysts.Where(c => c.Type == CrystariumType.RoleLevel).Count();
                            int accessories = roleCrysts.Where(c => c.Type == CrystariumType.Accessory).Count();
                            int atbLevel = roleCrysts.Where(c => c.Type == CrystariumType.ATBLevel).Count();
                            List<string> abilities = roleCrysts.Where(c => c.Type == CrystariumType.Ability).Select(c => {
                                Ability ability = Abilities.abilities.Where(a => a.HasCharacter(Abilities.GetCharID(name)) && a.GetAbility(Abilities.GetCharID(name)) == c.AbilityName).FirstOrDefault();
                                return ability.Name;
                            }).ToList();
                            if (hp > 0)
                                additions.Add($"HP + {hp}");
                            if (strength > 0)
                                additions.Add($"Strength + {strength}");
                            if (magic > 0)
                                additions.Add($"Magic + {magic}");
                            if (roleLevels > 0)
                                additions.Add($"Role Level + {roleLevels}");
                            if (accessories > 0)
                                additions.Add($"Accessories + {accessories}");
                            if (atbLevel > 0)
                                additions.Add($"ATB Level");
                            additions.AddRange(abilities);
                            int roleCol = 0;
                            switch (role)
                            {
                                case Role.Commando:
                                    roleCol = 1;
                                    break;
                                case Role.Ravager:
                                    roleCol = 2;
                                    break;
                                case Role.Sentinel:
                                    roleCol = 3;
                                    break;
                                case Role.Synergist:
                                    roleCol = 4;
                                    break;
                                case Role.Medic:
                                    roleCol = 6;
                                    break;
                                case Role.Saboteur:
                                    roleCol = 5;
                                    break;
                            }
                            list[roleCol] = String.Join("<br>", additions);
                        }
                        return list;
                    })
                    .ToList(), false));
            });

            return page;
        }
    }
}
