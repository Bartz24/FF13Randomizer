using Bartz24.Data;
using Bartz24.Docs;
using Bartz24.Rando;
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
    public class RandoEnemies : Randomizer
    {
        byte[] scene;
        DataStoreWDB<DataStoreEnemy, DataStoreID> enemies;
        byte[] bytes;

        FormMain main;
        public RandoEnemies(FormMain formMain, RandomizerManager randomizers) : base(randomizers) { main = formMain; }

        public override string GetProgressMessage()
        {
            return "Randomizing Enemies...";
        }
        public override string GetID()
        {
            return "Enemies";
        }

        public override void Load()
        {
            scene = File.ReadAllBytes($"{main.RandoPath}\\original\\db\\resident\\bt_scene.wdb");
            enemies = new DataStoreWDB<DataStoreEnemy, DataStoreID>();
            enemies.LoadData(File.ReadAllBytes($"{main.RandoPath}\\original\\db\\resident\\bt_chara_spec.wdb"));
            bytes = File.ReadAllBytes($"{main.RandoPath}\\original\\db\\resident\\bt_chara_spec.wdb");

            if (Enemies.enemies.Where(e => e.Parties.Length == 0 && e.ParentData == null || e.ParentData != null && e.ParentData.Parties.Length == 0).Count() > 0)
                throw new Exception("HELLO: " + string.Join(",", Enemies.enemies.Where(e => e.Parties.Length == 0 && e.ParentData == null || e.ParentData != null && e.ParentData.Parties.Length == 0).Select(e => e.Name).ToArray()));
        }
        public override void Randomize(BackgroundWorker backgroundWorker)
        {
            Dictionary<Enemy, int[]> plandoStats = main.enemyStatsPlando1.GetStats();
            Dictionary<Enemy, Tuple<Item, Item>> plandoDrops = main.enemyDropPlando1.GetDrops();
            Dictionary<Enemy, Dictionary<Element, ElementalRes>> plandoElementResists = main.enemyElementResistPlando1.GetElementResists();
            Dictionary<Enemy, Dictionary<Debuff, int>> plandoDebuffResists = main.enemyDebuffResistPlando1.GetDebuffResists();

            int completed = 0;
            List<DataStoreEnemy> enemyList = Enemies.enemies.Select(eID => enemies[eID.ID]).ToList();
            Enemies.enemies.ForEach(eID =>
            {
                DataStoreEnemy e = enemies[eID];
                byte[] idBytes = bytes.SubArray(completed * 0x20 + 0x90, 0x10);
                string id = Encoding.UTF8.GetString(idBytes).Replace("\0", "");

                double hpBase = 1.1;
                double strMagBase = 1.03;
                double cpBase = 1.3;

                if (Tweaks.Challenges.BoostLevel)
                {
                    int boost = Tweaks.Challenges.BoostLevel.Range.Value;
                    e.HP = (uint)Math.Max(10, e.HP * Math.Pow(hpBase, RandoExtensions.CubeRoot(boost)));
                    e.Strength = (ushort)Math.Max(1, e.Strength * Math.Pow(strMagBase, RandoExtensions.CubeRoot(boost)));
                    e.Magic = (ushort)Math.Max(1, e.Magic * Math.Pow(strMagBase, RandoExtensions.CubeRoot(boost)));
                }

                if (Flags.EnemyFlags.RandLevel)
                {
                    Flags.EnemyFlags.RandLevel.SetRand();
                    int variance = Flags.EnemyFlags.RandLevel.Range.Value;
                    bool lv0 = e.Level == 0;
                    int level = lv0 ? 10 : e.Level;
                    if (e.Level < 50)
                        e.Level = (byte)RandomNum.RandInt(Math.Max(1, e.Level - variance), Math.Min(49, e.Level + variance));
                    else if (e.Level > 50)
                        e.Level = (byte)RandomNum.RandInt(Math.Max(51, e.Level - variance), Math.Min(99, e.Level + variance));
                    if (plandoStats.ContainsKey(eID) && plandoStats[eID][0] > -1)
                        e.Level = (byte)plandoStats[eID][0];
                    if (plandoStats.ContainsKey(eID) && plandoStats[eID][6] > -1)
                        e.CP = (uint)plandoStats[eID][6];
                    int levelDiff = e.Level - level;

                    e.HP = (uint)Math.Max(10, e.HP * Math.Pow(hpBase, RandoExtensions.CubeRoot(levelDiff)));
                    e.Strength = (ushort)Math.Max(1, e.Strength * Math.Pow(strMagBase, RandoExtensions.CubeRoot(levelDiff)));
                    e.Magic = (ushort)Math.Max(1, e.Magic * Math.Pow(strMagBase, RandoExtensions.CubeRoot(levelDiff)));

                    if (e.CP > 0 && (!plandoStats.ContainsKey(eID) || plandoStats[eID][6] == -1))
                        e.CP = (uint)Math.Max(1, e.CP * Math.Pow(cpBase, RandoExtensions.CubeRoot(levelDiff)));
                    if (lv0 && (!plandoStats.ContainsKey(eID) || plandoStats[eID][0] == -1))
                        e.Level = 0;
                    RandomNum.ClearRand();
                }

                if (Flags.ItemFlags.Drops)
                {
                    if (eID.ParentData != null)
                    {
                        e.CommonDropID = enemies[eID.ParentData].CommonDropID;
                        e.RareDropID = enemies[eID.ParentData].RareDropID;
                    }
                    else
                    {
                        Flags.ItemFlags.Drops.SetRand();
                        do
                        {
                            RandomizeDrop(e, eID, true, plandoDrops);
                            RandomizeDrop(e, eID, false, plandoDrops);
                        } while (!AreDropsValid(e, eID, plandoDrops));
                        RandomNum.ClearRand();
                    }
                }

                int resistanceModifier = 100, debuffModifier = 100;
                if (Flags.EnemyFlags.RandStats)
                {
                    Flags.EnemyFlags.RandStats.SetRand();
                    StatValues stats = new StatValues(5 + (Flags.EnemyFlags.Resistances ? 1 : 0) + (Flags.EnemyFlags.Debuffs ? 1 : 0));
                    int variance = Flags.EnemyFlags.RandStats.Range.Value;

                    Tuple<int, int>[] bounds = stats.GetVarianceBounds(variance);
                    if (e.StaggerPoint == 1000)
                        bounds[4] = new Tuple<int, int>(1000, 1000);
                    if (plandoStats.ContainsKey(eID))
                    {
                        if (plandoStats[eID][1] > -1)
                            bounds[0] = new Tuple<int, int>((int)(plandoStats[eID][1] * 100 / Math.Max((int)e.HP, 1)), (int)(plandoStats[eID][1] * 100 / Math.Max((int)e.HP, 1)));
                        if (plandoStats[eID][2] > -1)
                            bounds[1] = new Tuple<int, int>((int)(plandoStats[eID][2] * 100 / Math.Max((int)e.Strength, 1)), (int)(plandoStats[eID][2] * 100 / Math.Max((int)e.Strength, 1)));
                        if (plandoStats[eID][3] > -1)
                            bounds[2] = new Tuple<int, int>((int)(plandoStats[eID][3] * 100 / Math.Max((int)e.Magic, 1)), (int)(plandoStats[eID][3] * 100 / Math.Max((int)e.Magic, 1)));
                        if (plandoStats[eID][4] > -1)
                            bounds[3] = new Tuple<int, int>((int)(plandoStats[eID][4] * 100 / Math.Max((int)e.ChainRes, 1)), (int)(plandoStats[eID][4] * 100 / Math.Max((int)e.ChainRes, 1)));
                        if (plandoStats[eID][5] > -1)
                            bounds[4] = new Tuple<int, int>((int)(plandoStats[eID][5] * 100 / Math.Max((int)e.StaggerPoint, 1)), (int)(plandoStats[eID][5] * 100 / Math.Max((int)e.StaggerPoint, 1)));
                    }

                    if(Flags.EnemyFlags.Resistances && plandoElementResists.ContainsKey(eID) && plandoElementResists[eID].Count == 8)
                    {
                        bounds[5] = new Tuple<int, int>(100, 100);
                    }

                    if (Flags.EnemyFlags.Debuffs && plandoDebuffResists.ContainsKey(eID) && plandoDebuffResists[eID].Count == 11)
                    {
                        bounds[5 + (Flags.EnemyFlags.Resistances ? 1 : 0)] = new Tuple<int, int>(100, 100);
                    }

                    stats.Randomize(bounds, bounds.Where(b => b.Item1 != b.Item2).Count() * variance);
                    e.HP = (uint)Math.Max(1, e.HP * stats[0] / 100f);
                    e.Strength = (ushort)Math.Max(1, e.Strength * stats[1] / 100f);
                    e.Magic = (ushort)Math.Max(1, e.Magic * stats[2] / 100f);
                    e.ChainRes = (uint)Math.Min(100, Math.Max(0, Math.Sqrt(Math.Pow(e.ChainRes + 1, 2f) * stats[3] / 100f) - 1));
                    if (bounds[4].Item1 == 1000)
                        e.StaggerPoint = 1000;
                    else
                        e.StaggerPoint = (ushort)Math.Min(999, Math.Max(101, (e.StaggerPoint - 100) * stats[4] / 100f + 100));
                    RandomNum.ClearRand();
                    if (Flags.EnemyFlags.Resistances)
                        resistanceModifier = stats[5];
                    if (Flags.EnemyFlags.Debuffs)
                        debuffModifier = stats[5 + (Flags.EnemyFlags.Resistances ? 1 : 0)];
                }

                if (plandoStats.ContainsKey(eID))
                {
                    if (Flags.EnemyFlags.RandStats || Flags.EnemyFlags.RandLevel)
                    {
                        if (plandoStats[eID][1] > -1)
                            e.HP = (uint)plandoStats[eID][1];
                        if (plandoStats[eID][2] > -1)
                            e.Strength = (ushort)plandoStats[eID][2];
                        if (plandoStats[eID][3] > -1)
                            e.Magic = (ushort)plandoStats[eID][3];
                    }
                    if (Flags.EnemyFlags.RandStats)
                    {
                        if (plandoStats[eID][4] > -1)
                            e.ChainRes = (uint)plandoStats[eID][4];
                        if (plandoStats[eID][5] > -1)
                            e.StaggerPoint = (ushort)plandoStats[eID][5];
                    }
                }

                if (Flags.EnemyFlags.Resistances)
                {
                    Flags.EnemyFlags.Resistances.SetRand();
                    RandomizeElements(e, eID, resistanceModifier, plandoElementResists);
                    RandomNum.ClearRand();
                }

                if (Flags.EnemyFlags.Debuffs)
                {
                    Flags.EnemyFlags.Debuffs.SetRand();
                    RandomizeDebuffs(e, eID, debuffModifier, plandoDebuffResists);
                    RandomNum.ClearRand();
                }

                completed++;
                backgroundWorker.ReportProgress(completed * 100 / enemies.DataList.Count);
            });


            if (Flags.ItemFlags.ShopLocations)
            {
                Flags.ItemFlags.ShopLocations.SetRand();
                List<int> list = scene.IndexesOf(Encoding.UTF8.GetBytes("key_shop_"));

                List<string> shops = list.Select(i => Encoding.UTF8.GetString(scene.SubArray(i, 11))).ToList();
                for (int i = 0; i < shops.Count; i++)
                {
                    shops[i] = randomizers.Get<RandoTreasure>("Treasures").ShopMappings[shops[i]];
                }

                for (int i = 0; i < list.Count; i++)
                {
                    scene.SetSubArray(list[i], Encoding.UTF8.GetBytes(shops[i]));
                }
                RandomNum.ClearRand();
            }
        }

        private bool AreDropsValid(DataStoreEnemy e, Enemy eID, Dictionary<Enemy, Tuple<Item, Item>> plandoDrops)
        {
            if (plandoDrops.ContainsKey(eID) && plandoDrops[eID].Item1 != null && plandoDrops[eID].Item1 != null)
            {
                return true;
            }
            return (e.CommonDropID != e.RareDropID) || (string.IsNullOrEmpty(e.CommonDropID) && string.IsNullOrEmpty(e.RareDropID));
        }

        public override HTMLPage GetDocumentation()
        {
            HTMLPage page = new HTMLPage("Enemies", "template/documentation.html");
            
            page.HTMLElements.Add(new Table("Enemies", 
                new string[] { "Name", "Level", "HP", "Strength", "Magic", "Chain Resistance", "Stagger Point", "Fire Resistance", "Ice Resistance", "Thunder Resistance", "Water Resistance", "Wind Resistance", "Earth Resistance", "Physical Resistance", "Magical Resistance", "CP", "Common Drop", "Rare Drop" }.ToList(), 
                new int[] { 12, 4,4,4,4,4,4,5,5,5,5,5,5,5,5,4,10,10 }.ToList(), 
                Enemies.enemies.OrderBy(e => e.Name).Select(e =>
            {
                Item common = Items.items.Find(i => i.ID == enemies[e].CommonDropID);
                Item rare = Items.items.Find(i => i.ID == enemies[e].RareDropID);
                return new string[] { e.Name, enemies[e].Level.ToString(), enemies[e].HP.ToString(), enemies[e].Strength.ToString(), enemies[e].Magic.ToString(), enemies[e].ChainRes.ToString(), enemies[e].StaggerPoint.ToString(), enemies[e].FireRes.ToString(), enemies[e].IceRes.ToString(), enemies[e].ThunderRes.ToString(), enemies[e].WaterRes.ToString(), enemies[e].WindRes.ToString(), enemies[e].EarthRes.ToString(), enemies[e].PhysicalRes.ToString(), enemies[e].MagicRes.ToString(), enemies[e].CP.ToString(), $"{(common == null ? enemies[e].CommonDropID : common == Items.Gil ? "-" : common.Name)}", $"{(rare == null ? enemies[e].RareDropID : rare == Items.Gil ? "-" : rare.Name)}" }.ToList();
            }).ToList()));
            
            return page;
        }

        public override void Save()
        {
            File.WriteAllBytes($"db\\resident\\bt_chara_spec.wdb", enemies.Data);
            File.WriteAllBytes($"db\\resident\\bt_scene.wdb", scene);

            int higherPhysRes = Enemies.enemies.Where(eID =>
            {
                DataStoreEnemy e = enemies[eID];
                return e.PhysicalRes > e.MagicRes;
            }).Count();
            int higherMagRes = Enemies.enemies.Where(eID =>
            {
                DataStoreEnemy e = enemies[eID];
                return e.PhysicalRes < e.MagicRes;
            }).Count();
        }

        private void RandomizeElements(DataStoreEnemy enemy, Enemy enemyID, int modifier, Dictionary<Enemy, Dictionary<Element, ElementalRes>> plandoElementResists)
        {
            RandoCrystarium crystarium = randomizers.Get<RandoCrystarium>("Crystarium");

            float leaderBias = 0.75f, aiBias = 0.90f;

            Dictionary<Element, ElementalRes[]> bounds = new Dictionary<Element, ElementalRes[]>();
            bounds.Add(Element.Fire, new ElementalRes[] { ElementalRes.Weakness, ElementalRes.Absorb });
            bounds.Add(Element.Ice, new ElementalRes[] { ElementalRes.Weakness, ElementalRes.Absorb });
            bounds.Add(Element.Thunder, new ElementalRes[] { ElementalRes.Weakness, ElementalRes.Absorb });
            bounds.Add(Element.Water, new ElementalRes[] { ElementalRes.Weakness, ElementalRes.Absorb });
            bounds.Add(Element.Wind, new ElementalRes[] { ElementalRes.Weakness, ElementalRes.Absorb });
            bounds.Add(Element.Earth, new ElementalRes[] { ElementalRes.Weakness, ElementalRes.Absorb });
            bounds.Add(Element.Physical, new ElementalRes[] { ElementalRes.Weakness, ElementalRes.Immune });
            bounds.Add(Element.Magical, new ElementalRes[] { ElementalRes.Weakness, ElementalRes.Immune });

            if(enemyID.ElementProperty == ElementProperty.Bomb)
            {
                ((Element[])Enum.GetValues(typeof(Element))).Where(e => enemy[e] == ElementalRes.Absorb).ForEach(e => bounds[e] = new ElementalRes[] { ElementalRes.Absorb, ElementalRes.Absorb });
            }

            if (plandoElementResists.ContainsKey(enemyID))
            {
                plandoElementResists[enemyID].ForEach(pair => bounds[pair.Key] = new ElementalRes[] { pair.Value, pair.Value });
            }

            bool isArmored = enemy.PhysicalRes >= ElementalRes.Resistant && enemy.MagicRes >= ElementalRes.Resistant;
            ElementalRes possibleMax = isArmored ? ElementalRes.Resistant : ElementalRes.Halved;

            List<Party> partiesUsed = enemyID.Parties.Select(p => GetParty(p)).ToList();
            if (enemyID.ParentData != null && enemyID.ParentData.Parties.Length > 0)
                partiesUsed.AddRange(enemyID.ParentData.Parties.Select(p => GetParty(p)).ToList());

            Dictionary<Element, int> typeWeights = Enumerable.Range((int)Element.Physical, 2).ToDictionary(i => (Element)i, i => 10000);
            Dictionary<Element, int> elementWeights = Enumerable.Range((int)Element.Fire, 6).ToDictionary(i => (Element)i, i => 10000);

            foreach (Party p in partiesUsed)
            {
                Dictionary<Member, List<Ability>> partyAbilities = new Dictionary<Member, List<Ability>>();
                for (int i = 0; i < p.Members.Length; i++)
                {
                    List<Ability> abilities = p.Members[i].GetAbilitiesAvailable(p.MaxStage, crystarium.crystariums[p.Members[i].Character.ToString().ToLower()], i == 0 || p.LeaderSwap, enemyID.ElementProperty == ElementProperty.Skytank).Where(a => a.Elements.Length > 0).SkipWhile(a => (enemyID.ElementProperty == ElementProperty.Bomb ? (a.Elements.Where(e => bounds[e][0] == ElementalRes.Absorb && bounds[e][1] == ElementalRes.Absorb).Count() > 0) : false)).ToList();
                    partyAbilities.Add(p.Members[i], abilities);
                }

                if (enemyID.ElementProperty == ElementProperty.Bomb && partyAbilities.Values.SelectMany(l=>l).Count() == 0)
                {
                    ((Element[])Enum.GetValues(typeof(Element))).Where(e => enemy[e] == ElementalRes.Absorb).ForEach(e => bounds[e] = new ElementalRes[] { ElementalRes.Halved, ElementalRes.Halved });
                }

                    List<Ability> physical, magic;
                physical = partyAbilities.Values.SelectMany(l => l).Where(a => a.Elements.Contains(Element.Physical)).ToList();
                magic = partyAbilities.Values.SelectMany(l => l).Where(a => a.Elements.Contains(Element.Magical)).ToList();

                if (physical.Count > 0 && magic.Count == 0 && bounds[Element.Physical][1] > possibleMax)
                    bounds[Element.Physical][1] = possibleMax;
                else if (physical.Count == 0 && magic.Count > 0 && bounds[Element.Magical][1] > possibleMax)
                    bounds[Element.Magical][1] = possibleMax;

                int randomRequiredVulnerable = RandomNum.RandInt(0, p.Members.Length);

                for (int i = 0; i < p.Members.Length; i++)
                {
                    if (partyAbilities[p.Members[i]].Count == 0)
                        continue;

                    float bias = (i == 0 ? leaderBias : aiBias) / (float)partiesUsed.Count;

                    Ability ability;
                    int elementCount = partyAbilities[p.Members[i]].SelectMany(a => GetElementsOnAbility(a, partyAbilities.Values.SelectMany(l => l).ToList())).Distinct().Count();

                    if (elementCount == 0)
                        ability = partyAbilities[p.Members[i]][RandomNum.RandInt(0, partyAbilities[p.Members[i]].Count - 1)];
                    else
                    {
                        List<Element> validElements;
                        do
                        {
                            ability = partyAbilities[p.Members[i]][RandomNum.RandInt(0, partyAbilities[p.Members[i]].Count - 1)];
                            validElements = GetElementsOnAbility(ability, partyAbilities.Values.SelectMany(l => l).ToList()).ToList();
                        } while (validElements.Count == 0);

                        elementWeights.Keys.Where(e => validElements.Contains(e)).ForEach(e =>
                        {
                            if (RandomNum.RandInt(0, 99) < 40)
                                elementWeights[e] = (int)(elementWeights[e] / bias);
                            else
                                elementWeights[e] = (int)(elementWeights[e] * bias);
                            if (i == randomRequiredVulnerable && bounds[e][1] > possibleMax)
                                bounds[e][1] = possibleMax;
                        });
                    }

                    typeWeights.Keys.Where(e => ability.Elements.Contains(e)).ForEach(e =>
                    {
                        float typeBias = bias * (e == Element.Physical ? 0.45f : 1);
                        if (RandomNum.RandInt(0, 99) < 40)
                            typeWeights[e] = (int)(typeWeights[e] / Math.Pow(typeBias, 0.1));
                        else
                            typeWeights[e] = (int)(typeWeights[e] * Math.Pow(typeBias, 0.1));
                        if (i == randomRequiredVulnerable && bounds[e][1] > possibleMax)
                            bounds[e][1] = possibleMax;
                    });
                }
            }

            if (plandoElementResists.ContainsKey(enemyID))
            {
                plandoElementResists[enemyID].ForEach(pair => bounds[pair.Key] = new ElementalRes[] { pair.Value, pair.Value });
            }

            StatValuesWeighted types = new StatValuesWeighted(typeWeights.Values.ToArray());
            StatValuesWeighted elements = new StatValuesWeighted(elementWeights.Values.ToArray());

            Tuple<int, int>[] typeBounds = typeWeights.Keys.Select(e => GetElemBounds(bounds[e])).ToArray();
            types.Randomize(typeBounds, (int)(types.GetTotalPoints(typeBounds) * modifier / 100f));

            Tuple<int, int>[] elementBounds = elementWeights.Keys.Select(e => GetElemBounds(bounds[e])).ToArray();
            elements.Randomize(elementBounds, (int)(elements.GetTotalPoints(elementBounds) * modifier / 100f));

            typeWeights.Keys.ToList().ForEach(e => enemy[e] = GetBoundRes(types[typeWeights.Keys.ToList().IndexOf(e)]));
            elementWeights.Keys.ToList().ForEach(e => enemy[e] = GetBoundRes(elements[elementWeights.Keys.ToList().IndexOf(e)]));
        }

        private void RandomizeDebuffs(DataStoreEnemy enemy, Enemy enemyID, int modifier, Dictionary<Enemy, Dictionary<Debuff, int>> plandoDebuffResists)
        {
            RandoCrystarium crystarium = randomizers.Get<RandoCrystarium>("Crystarium");

            float leaderBias = 0.75f, aiBias = 0.90f;

            Dictionary<Debuff, int[]> bounds = ((Debuff[])Enum.GetValues(typeof(Debuff))).ToDictionary(d => d, d => new int[] { 0, 100 });

            int immunities = (int)(((Debuff[])Enum.GetValues(typeof(Debuff))).Where(d => enemy[d] >= 100).Count() + Math.Sign(modifier - 100) * RandomNum.RandInt(0, (int)Math.Round(Math.Sqrt(1.2 * Math.Abs(modifier - 100)))));

            if (enemyID.Type == EnemyType.Eidolon)
            {
                bounds[Debuff.Poison] = new int[] { 100, 100 };
                immunities--;
            }

            if (plandoDebuffResists.ContainsKey(enemyID))
            {
                plandoDebuffResists[enemyID].ForEach(pair => { bounds[pair.Key] = new int[] { pair.Value, pair.Value }; if (pair.Value == 100) immunities--; });
            }

            immunities = Math.Max(0, Math.Min(11 - bounds.Values.Where(a => a[0] == 100 && a[1] == 100).Count(), immunities));

            for (int i = 0; i < immunities; i++)
            {
                Debuff d;
                do
                {
                    d = (Debuff)RandomNum.RandInt(0, 10);
                } while (bounds[d][0] == 100 && bounds[d][1] == 100);
                bounds[d] = new int[] { 100, 100 };
            }

            List<Party> partiesUsed = enemyID.Parties.Select(p => GetParty(p)).ToList();
            if (enemyID.ParentData != null && enemyID.ParentData.Parties.Length > 0)
                partiesUsed.AddRange(enemyID.ParentData.Parties);

            Dictionary<Debuff, int> weights = Enumerable.Range((int)Debuff.Deprotect, 11).ToDictionary(i => (Debuff)i, i => 10000);

            foreach (Party p in partiesUsed)
            {
                Dictionary<Member, List<Ability>> partyAbilities = new Dictionary<Member, List<Ability>>();
                for (int i = 0; i < p.Members.Length; i++)
                {
                    List<Ability> abilities = p.Members[i].GetAbilitiesAvailable(p.MaxStage, crystarium.crystariums[p.Members[i].Character.ToString().ToLower()], i == 0 || p.LeaderSwap, enemyID.ElementProperty == ElementProperty.Skytank).Where(a => a.Elements.Length > 0).ToList();
                    partyAbilities.Add(p.Members[i], abilities);
                }

                int randomRequiredVulnerable = RandomNum.RandInt(0, p.Members.Length);

                for (int i = 0; i < p.Members.Length; i++)
                {
                    float bias = (i == 0 ? leaderBias : aiBias) / (float)partiesUsed.Count;

                    Ability ability;
                    int debuffCount = partyAbilities[p.Members[i]].SelectMany(a => a.Debuffs).Distinct().Count();

                    if (debuffCount == 0)
                        ability = partyAbilities[p.Members[i]][RandomNum.RandInt(0, partyAbilities[p.Members[i]].Count - 1)];
                    else
                    {
                        List<Debuff> validDebuffs;
                        do
                        {
                            ability = partyAbilities[p.Members[i]][RandomNum.RandInt(0, partyAbilities[p.Members[i]].Count - 1)];
                            validDebuffs = ability.Debuffs.ToList();
                        } while (validDebuffs.Count == 0);

                        weights.Keys.Where(e => validDebuffs.Contains(e)).ForEach(e =>
                        {
                            if (RandomNum.RandInt(0, 99) < 40)
                                weights[e] = (int)(weights[e] / bias);
                            else
                                weights[e] = (int)(weights[e] * bias);
                            if (i == randomRequiredVulnerable && bounds[e][1] > 99)
                                bounds[e][1] = 99;
                        });
                    }
                }
            }

            if (enemyID.Type == EnemyType.Eidolon)
            {
                bounds[Debuff.Poison] = new int[] { 100, 100 };
            }

            if (plandoDebuffResists.ContainsKey(enemyID))
            {
                plandoDebuffResists[enemyID].ForEach(pair => bounds[pair.Key] = new int[] { pair.Value, pair.Value });
            }

            StatValuesWeighted debuffs = new StatValuesWeighted(weights.Values.ToArray());

            Tuple<int, int>[] debuffBounds = weights.Keys.Select(d => new Tuple<int, int>(bounds[d][0], bounds[d][1])).ToArray();
            debuffs.Randomize(debuffBounds, (int)(debuffs.GetTotalPoints(debuffBounds) * modifier / 100f));

            weights.Keys.ToList().ForEach(d => enemy[d] = (byte)Math.Min(100, debuffs[weights.Keys.ToList().IndexOf(d)]));
        }

        private Element[] GetElementsOnAbility(Ability a, List<Ability> all)
        {
            if (a.Elements.Contains(Element.Physical) || a.Elements.Contains(Element.Magical))
            {
                if (a.Elements.Length == 1)
                    return all.Where(aOther => !aOther.Elements.Contains(Element.Physical) && !aOther.Elements.Contains(Element.Magical)).SelectMany(aOther => aOther.Elements).ToArray();
                else
                    return a.Elements.Where(e => e != Element.Physical && e != Element.Magical).ToArray();
            }
            else
                return new Element[0];
        }

        private Party GetParty(Party party)
        {
            if (party.Members.Length <= 3)
                return party;
            Member[] random = new Member[3];
            for(int i = 0; i < 3; i++)
            {
                if(!party.LeaderSwap && i == 0)
                {
                    random[i] = party.Members[i];
                    continue;
                }
                    
                Member m;
                do
                {
                    m = party.Members[RandomNum.RandInt(0, party.Members.Length - 1)];
                } while (random.Contains(m));
                random[i] = m;
            }

            return new Party(party.MaxStage, party.LeaderSwap, random);
        }

        private ElementalRes GetBoundRes(int value)
        {
            for(ElementalRes res = ElementalRes.Weakness; res <= ElementalRes.Absorb; res++)
            {
                if (value >= GetBoundValue(res) && value <= GetBoundValue(res, true))
                    return res;
            }
            return ElementalRes.Normal;
        }

        private int GetBoundValue(ElementalRes res, bool nextHighest = false)
        {
            if (nextHighest)
            {
                return (res == ElementalRes.Absorb ? GetBoundValue(res) + 100 : GetBoundValue(res + 1)) - 1;
            }
            switch (res)
            {
                case ElementalRes.Weakness:
                    return 0;
                case ElementalRes.Normal:
                default:
                    return 200;
                case ElementalRes.Halved:
                    return 525;
                case ElementalRes.Resistant:
                    return 600;
                case ElementalRes.Immune:
                    return 650;
                case ElementalRes.Absorb:
                    return 700;
            }
        }

        private Tuple<int, int> GetElemBounds(ElementalRes[] bounds)
        {
            if(bounds[0] == bounds[1])
                return new Tuple<int, int>(GetBoundValue(bounds[0]), GetBoundValue(bounds[1]));
            return new Tuple<int, int>(GetBoundValue(bounds[0]), GetBoundValue(bounds[1], true));
        }

        private void RandomizeDrop(DataStoreEnemy enemy, Enemy enemyID, bool common, Dictionary<Enemy, Tuple<Item, Item>> plando)
        {
            int rankAdj = Flags.ItemFlags.Drops.Range.Value;
            Item item = null;
            if (!string.IsNullOrEmpty(common ? enemy.CommonDropID : enemy.RareDropID))
                item = Items.items.Where(i => i.ID ==
                   (common ? enemy.CommonDropID : enemy.RareDropID)).FirstOrDefault();
            if (item != null)
            {
                if (item.ID == "")
                    throw new Exception("LUL");
                int rank = TieredItems.manager.GetRank(item, 1);
                if (rank != -1)
                {
                    Tuple<Item, int> newItem;
                    if (plando.ContainsKey(enemyID) && (common ? plando[enemyID].Item1 : plando[enemyID].Item2) != null)
                    {
                        newItem = new Tuple<Item, int>(common ? plando[enemyID].Item1 : plando[enemyID].Item2, 1);
                    }
                    else
                    {
                        if (rankAdj > 0)
                            rank = RandomNum.RandInt(Math.Max(0, rank - rankAdj), Math.Min(TieredItems.manager.GetHighBound(), rank + rankAdj));
                        do
                        {
                            newItem = TieredItems.manager.Get(rank, 1, tiered => GetDropWeight(tiered, enemy.Level, enemyID.Type, item.ID.StartsWith("it") && enemy.Level > 50));
                            rank--;
                        } while ((newItem.Item1 == null || randomizers.Get<RandoTreasure>("Treasures").blacklistedWeapons.Contains(newItem.Item1)) && rank >= 0);
                    }
                    if (newItem.Item1 == null)
                        return;
                    if (newItem.Item1.ID.StartsWith("wea_"))
                        randomizers.Get<RandoTreasure>("Treasures").blacklistedWeapons.Add(newItem.Item1);
                    if (common)
                        enemy.CommonDropID = newItem.Item1.ID;
                    else
                        enemy.RareDropID = newItem.Item1.ID;
                }
            }
        }

        public static int GetDropWeight(Tiered<Item> t, int enemyLevel, EnemyType type, bool forceNormalDrop)
        {
            if (t.Items.Where(i => i.ID == "").Count() > 0)
                return 0;
            float mult;
            if (type == EnemyType.Boss && !forceNormalDrop)
            {
                mult = 1 + .01f * (float)Math.Pow(enemyLevel - 50, .8f);
                if (t.Items.Where(i => i.ID.StartsWith("material_o")).Count() > 0)
                    return (int)(t.Weight * 1.8 * mult);
                if (t.Items.Where(i => i.ID.StartsWith("material")).Count() > 0)
                    return 0;
                if (t.Items.Where(i => i.ID.StartsWith("it")).Count() > 0)
                    return Math.Max(1, t.Weight / 4);
                return (int)(t.Weight * 2 * mult);
            }
            else if (type == EnemyType.Rare)
            {
                mult = 1 + .01f * (float)Math.Pow(enemyLevel, .8f);
                if (t.Items.Where(i => i.ID.StartsWith("material_o")).Count() > 0)
                    return (int)(t.Weight * 4.5 * mult);
                if (t.Items.Where(i => i.ID.StartsWith("material")).Count() > 0)
                    return (int)Math.Max(1, t.Weight / 1.5);
                if (t.Items.Where(i => i.ID.StartsWith("wea_")).Count() > 0)
                    return 0;
                return (int)(t.Weight * mult);
            }
            else
            {
                mult = 1 + .01f * (float)Math.Pow(enemyLevel, .8f);
                if (t.Items.Where(i => i.ID.StartsWith("material_o")).Count() > 0)
                    return (int)(t.Weight);
                if (t.Items.Where(i => i.ID.StartsWith("material")).Count() > 0)
                    return (int)(t.Weight * 18.2f);
                if (t.Items.Where(i => i.ID.StartsWith("wea_")).Count() > 0)
                    return 0;
                if (t.Items.Contains(Items.Potion) || t.Items.Contains(Items.PhoenixDown) || t.Items.Contains(Items.Antidote) ||
                    t.Items.Contains(Items.HolyWater) || t.Items.Contains(Items.Painkiller) || t.Items.Contains(Items.FoulLiquid) ||
                    t.Items.Contains(Items.Wax) || t.Items.Contains(Items.Mallet))
                    return (int)(t.Weight * 4.2f);
                return (int)Math.Max(1, t.Weight / 22.5f * mult);
            }
        }
    }
}
