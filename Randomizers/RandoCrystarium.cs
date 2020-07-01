using FF13Data;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FF13Randomizer
{
    public class RandoCrystarium : Randomizer
    {
        public string[] names = new string[] { "lightning", "fang", "snow", "sazh", "hope", "vanille" };
        public Dictionary<Role, StatValues> roleMults = new Dictionary<Role, StatValues>();
        public Dictionary<string, StatValues> charMults = new Dictionary<string, StatValues>();
        public Dictionary<string, CrystariumDatabase> crystariums = new Dictionary<string, CrystariumDatabase>();
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

            foreach (string name in names)
            {
                crystariums.Add(name, new CrystariumDatabase($"{main.RandoPath}\\original\\db\\crystal\\crystal_{name}.wdb"));
            }
        }
        public override void Randomize(BackgroundWorker backgroundWorker)
        {
            if (Flags.CrystariumFlags.RandStats.FlagEnabled)
                RandomizeStats();

            backgroundWorker.ReportProgress(10);

            if (Flags.CrystariumFlags.ScaledCPCost.FlagEnabled)
                ApplyScaledCPCosts();

            if (Flags.CrystariumFlags.HalfSecondaryCPCost.FlagEnabled)
                ApplyHalfCPCosts();

            backgroundWorker.ReportProgress(20);

            if (Flags.CrystariumFlags.ShuffleNodes.FlagEnabled)
                ShuffleNodes();

            backgroundWorker.ReportProgress(40);

            RandomizeAbilities();
            backgroundWorker.ReportProgress(100);
        }

        public void ApplyScaledCPCosts()
        {
            foreach (string name in names)
            {
                foreach (DataStoreCrystarium c in crystariums[name].Crystarium)
                {
                    int cpCost = (int)Math.Floor(c.CPCost * Math.Max(0.5, Math.Min(1, 1.08684 * Math.Exp(-0.08664 * c.Stage))));
                    c.CPCost = (uint)(Math.Round(cpCost / 5.0 / Math.Floor(Math.Log10(cpCost))) * 5 * Math.Floor(Math.Log10(cpCost)));
                }
            }
        }
        public void ApplyHalfCPCosts()
        {
            foreach (string name in names)
            {
                foreach (DataStoreCrystarium c in crystariums[name].Crystarium)
                {
                    if (!primaryRoles[name].Contains(c.Role))
                    {
                        c.CPCost /= 2;
                    }
                }
            }
        }
        public void RandomizeStats()
        {
            Dictionary<int, Dictionary<CrystariumType, List<int>>> statAverages = new Dictionary<int, Dictionary<CrystariumType, List<int>>>();
            Flags.CrystariumFlags.RandStats.SetRand();
            foreach (Role role in Enum.GetValues(typeof(Role)))
            {
                StatValues stats = new StatValues(3);
                int variance = ((FlagValue)Flags.CrystariumFlags.RandStats.FlagData).Range.Value;
                stats.Randomize(variance);
                roleMults.Add(role, stats);
            }

            foreach (string name in names)
            {
                StatValues stats = new StatValues(3);
                int variance = ((FlagValue)Flags.CrystariumFlags.RandStats.FlagData).Range.Value;
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
                foreach (DataStoreCrystarium c in crystariums[name].Crystarium)
                {
                    if (c.Type == CrystariumType.HP || c.Type == CrystariumType.Strength || c.Type == CrystariumType.Magic)
                    {
                        statAverages[c.Stage][c.Type].Add(c.Value);
                    }
                }
            }

            statAverages.Values.ToList().ForEach(d =>
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

            foreach (string name in names)
            {
                CrystariumDatabase crystarium = crystariums[name];

                Dictionary<int, Dictionary<Role, int>> nodeCounts = new Dictionary<int, Dictionary<Role, int>>();
                for (int stage = 1; stage <= 10; stage++)
                {
                    Dictionary<Role, int> stageDict = new Dictionary<Role, int>();
                    foreach (Role role in Enum.GetValues(typeof(Role)))
                    {
                        stageDict.Add(role, crystarium.Crystarium.Where(
                            c => c.Stage == stage && c.Role == role &&
                            (c.Type == CrystariumType.HP || c.Type == CrystariumType.Strength || c.Type == CrystariumType.Magic))
                            .Count());
                    }
                    nodeCounts.Add(stage, stageDict);
                }

                foreach (DataStoreCrystarium c in crystarium.Crystarium)
                {
                    if (c.Type == CrystariumType.HP || c.Type == CrystariumType.Strength || c.Type == CrystariumType.Magic)
                    {
                        c.Type = RandomNum.SelectRandomWeighted(
                            new CrystariumType[] { CrystariumType.HP, CrystariumType.Strength, CrystariumType.Magic }.ToList(),
                            t => Math.Max(1, (int)Math.Pow(
                                t == CrystariumType.HP ? (charMults[name][0] * roleMults[c.Role][0]) : (
                                t == CrystariumType.Strength ? (charMults[name][1] * roleMults[c.Role][1]) :
                                (charMults[name][2] * roleMults[c.Role][2])), 1 / 1.5d)));

                        int avgValue = (int)Math.Ceiling(statAverages[c.Stage][c.Type][0] * Math.Pow(1.1, c.Stage * 0.07 + 0.1 + (c.Stage == 10 ? 1.8 : 0)));
                        if (c.Stage == 10 && c.Type == CrystariumType.HP)
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
                    List<DataStoreCrystarium> list = crystarium.Crystarium.Where(
                    c => (c.Type == CrystariumType.HP ||
                c.Type == CrystariumType.Strength ||
                c.Type == CrystariumType.Magic) && c.Role == role).ToList();

                    for (int i = 0; i < list.Count() / 2; i++)
                    {
                        DataStoreCrystarium c = list[RandomNum.RandInt(0, list.Count - 1)];
                        int count = list.Where(c2 => c.Type == c2.Type).Count();
                        float mult = RandomNum.RandInt(100, 100 + (int)Math.Sqrt(Math.Max(0, (count - 1)) * 20)) / 100f;
                        list.ForEach(cr =>
                        {
                            if (c.Type == cr.Type && c.Stage == cr.Stage)
                                cr.Value = (ushort)Math.Max(1, Math.Ceiling(cr == c ? (cr.Value * mult) : (cr.Value / Math.Pow(mult, 1 / 2.2f) - 1)));
                        });
                        c.Value = (ushort)Math.Max(1, (int)c.Value);
                    }
                }
            }
            RandomNum.ClearRand();
        }

        public void ShuffleNodes()
        {
            Flags.CrystariumFlags.ShuffleNodes.SetRand();
            foreach (string name in names)
            {
                CrystariumDatabase crystarium = crystariums[name];

                for (int r = 1; r <= 6; r++)
                {
                    Role role = (Role)r;

                    crystarium.Crystarium.ToList()
                            .Where(c => c.Role == role
                            && c.CPCost > 0
                            && ((!primaryRoles[name].Contains(role) && c.Stage > 1) || primaryRoles[name].Contains(role))).ToList()
                            .Shuffle((a, b) => a.SwapStatsAbilities(b));
                }
            }
            RandomNum.ClearRand();
        }

        public void RandomizeAbilities()
        {
            foreach (string name in names)
            {
                CrystariumDatabase crystarium = crystariums[name];

                List<Tiered<Ability>> techniques = TieredAbilities.manager.list.Where(
                    t => t.Items.Where(a => a.Role == Role.None && (!Flags.CrystariumFlags.LibraStart.FlagEnabled || (Flags.CrystariumFlags.LibraStart.FlagEnabled && a != Abilities.Libra))).Count() > 0).ToList();

                List<Tiered<Ability>> added = new List<Tiered<Ability>>();
                List<Ability> obtained = new List<Ability>();

                Dictionary<Role, List<int>> startingNodes = new Dictionary<Role, List<int>>();
                for (int r = 1; r <= 6; r++)
                {
                    List<int> startingNodeList = new List<int>();
                    Role role = (Role)r;
                    if (Flags.CrystariumFlags.NewAbilities.FlagEnabled)
                    {
                        Flags.CrystariumFlags.NewAbilities.SetRand();
                        List<int> abilityNodes = new List<int>();
                        for (int i = 0; i < crystarium.Crystarium.count; i++)
                        {
                            if (crystarium.Crystarium[i].Role == role && crystarium.Crystarium[i].Type == CrystariumType.Ability)
                                abilityNodes.Add(i);
                        }
                        abilityNodes.Sort((a, b) => crystarium.Crystarium[a].Stage.CompareTo(crystarium.Crystarium[b].Stage));

                        List<Tiered<Ability>> starting = TieredAbilities.manager.list.Where(
                    t => t.Items.Where(a => a.Role == role && a.Starting && a.HasCharacter(getCharID(name))).Count() > 0 && !added.Contains(t)).ToList();

                        int maxStage = 1;
                        for (int i = 0; i < abilityNodes.Count; i++)
                        {
                            DataStoreCrystarium cryst = crystarium.Crystarium[abilityNodes[i]];
                            if (cryst.Stage < maxStage)
                                throw new Exception("Went down in stage!");
                            maxStage = cryst.Stage;

                            Ability orig = Abilities.abilities.Where(a => a.HasCharacter(getCharID(name)) && a.GetAbility(getCharID(name)) == crystarium.AbilityIDs[(int)cryst.AbilityPointer]?.Value).FirstOrDefault();

                            if (Flags.CrystariumFlags.LibraStart.FlagEnabled && orig == Abilities.Libra)
                                continue;

                            if (isTechnique(orig))
                            {
                                int newI;
                                Ability ability;
                                do
                                {
                                    newI = RandomNum.RandInt(0, techniques.Count - 1);
                                    ability = Flags.CrystariumFlags.AbilitiesAnyRole.FlagEnabled ? TieredAbilities.GetNoDep(techniques[newI]) : TieredAbilities.Get(techniques[newI], obtained);
                                } while (ability == null);
                                DataStoreString dataStr = new DataStoreString() { Value = ability.GetAbility(getCharID(name)) };
                                if (!crystarium.AbilityIDs.Contains(dataStr))
                                    crystarium.AbilityIDs.Add(dataStr, crystarium.AbilityIDs.GetTrueSize());
                                cryst.AbilityPointer = (uint)crystarium.AbilityIDs.IndexOf(dataStr);
                                obtained.Add(ability);
                                techniques.RemoveAt(newI);
                                startingNodeList.Add(abilityNodes[i]);
                                abilityNodes.RemoveAt(i);
                                i--;
                            }
                            else if (cryst.CPCost == 0 || (!primaryRoles[name].Contains(role) && cryst.Stage == 1))
                            {
                                int newI;
                                Ability ability;
                                do
                                {
                                    newI = RandomNum.RandInt(0, starting.Count - 1);
                                    ability = Flags.CrystariumFlags.AbilitiesAnyRole.FlagEnabled ? TieredAbilities.GetNoDep(starting[newI]) : TieredAbilities.Get(starting[newI], obtained);
                                } while (ability == null);
                                DataStoreString dataStr = new DataStoreString() { Value = ability.GetAbility(getCharID(name)) };
                                if (!crystarium.AbilityIDs.Contains(dataStr))
                                    crystarium.AbilityIDs.Add(dataStr, crystarium.AbilityIDs.GetTrueSize());
                                cryst.AbilityPointer = (uint)crystarium.AbilityIDs.IndexOf(dataStr);
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
                    if (Flags.CrystariumFlags.NewAbilities.FlagEnabled)
                    {
                        Flags.CrystariumFlags.NewAbilities.SetRand();
                        List<int> abilityNodes = new List<int>();
                        for (int i = 0; i < crystarium.Crystarium.count; i++)
                        {
                            if (crystarium.Crystarium[i].Role == role && crystarium.Crystarium[i].Type == CrystariumType.Ability && !startingNodes[role].Contains(i))
                                abilityNodes.Add(i);
                        }
                        abilityNodes.Sort((a, b) => crystarium.Crystarium[a].Stage.CompareTo(crystarium.Crystarium[b].Stage));

                        List<Tiered<Ability>> rest = TieredAbilities.manager.list.Where(
                    t => t.Items.Where(a => (a.Role == role || Flags.CrystariumFlags.AbilitiesAnyRole.FlagEnabled) && a.Role != Role.None && a.HasCharacter(getCharID(name))).Count() > 0 && !added.Contains(t)).ToList();
                        for (int i = 0; i < abilityNodes.Count; i++)
                        {
                            DataStoreCrystarium cryst = crystarium.Crystarium[abilityNodes[i]];
                            if (cryst.Stage < maxStage)
                                throw new Exception("Went down in stage!");
                            maxStage = cryst.Stage;

                            Ability orig = Abilities.abilities.Where(a => a.HasCharacter(getCharID(name)) && a.GetAbility(getCharID(name)) == crystarium.AbilityIDs[(int)cryst.AbilityPointer]?.Value).FirstOrDefault();

                            if (Flags.CrystariumFlags.LibraStart.FlagEnabled && orig == Abilities.Libra)
                                continue;

                            if (isTechnique(orig))
                            {
                                int newI;
                                Ability ability;
                                do
                                {
                                    newI = RandomNum.RandInt(0, techniques.Count - 1);
                                    ability = Flags.CrystariumFlags.AbilitiesAnyRole.FlagEnabled ? TieredAbilities.GetNoDep(techniques[newI]) : TieredAbilities.Get(techniques[newI], obtained);
                                } while (ability == null);
                                DataStoreString dataStr = new DataStoreString() { Value = ability.GetAbility(getCharID(name)) };
                                if (!crystarium.AbilityIDs.Contains(dataStr))
                                    crystarium.AbilityIDs.Add(dataStr, crystarium.AbilityIDs.GetTrueSize());
                                cryst.AbilityPointer = (uint)crystarium.AbilityIDs.IndexOf(dataStr);
                                obtained.Add(ability);
                                techniques.RemoveAt(newI);
                            }
                            else
                            {
                                int newI;
                                Ability ability;
                                do
                                {
                                    newI = RandomNum.RandInt(0, rest.Count - 1);
                                    ability = Flags.CrystariumFlags.AbilitiesAnyRole.FlagEnabled ? TieredAbilities.GetNoDep(rest[newI]) : TieredAbilities.Get(rest[newI], obtained);
                                } while (ability == null);
                                DataStoreString dataStr = new DataStoreString() { Value = ability.GetAbility(getCharID(name)) };
                                if (!crystarium.AbilityIDs.Contains(dataStr))
                                    crystarium.AbilityIDs.Add(dataStr, crystarium.AbilityIDs.GetTrueSize());
                                cryst.AbilityPointer = (uint)crystarium.AbilityIDs.IndexOf(dataStr);
                                obtained.Add(ability);
                                added.Add(rest[newI]);
                                rest.RemoveAt(newI);
                            }
                        }
                        RandomNum.ClearRand();
                    }
                }
            }
        }

        public override void Save()
        {
            base.Save();

            foreach (string name in names)
            {
                CrystariumDatabase crystarium = crystariums[name];

                crystarium.Save($"db\\crystal\\crystal_{name}.wdb");
            }

            DocsJSONGenerator.CreateCrystariumDocs(crystariums, primaryRoles);
        }

        public static bool isTechnique(Ability orig)
        {
            if (Flags.CrystariumFlags.LibraStart.FlagEnabled && orig == Abilities.Libra)
                return false;
            return orig == Abilities.Libra || orig == Abilities.Renew || orig == Abilities.Stopga || orig == Abilities.Quake || orig == Abilities.Dispelga;
        }

        private string getCharID(string character)
        {
            if (character == "sazh")
                return "z";
            return character.Substring(0, 1);
        }
    }
}
