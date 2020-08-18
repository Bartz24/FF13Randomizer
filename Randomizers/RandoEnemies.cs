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
        Dictionary<byte, ElementalRes> physValues = new Dictionary<byte, ElementalRes>();
        byte[] scene;
        DataStoreWDB<DataStoreEnemy> enemies;
        byte[] bytes;

        public RandoEnemies(FormMain formMain, RandomizerManager randomizers) : base(formMain, randomizers) { }

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
            #region Set Physical Resistances
            physValues.Add(0x00, ElementalRes.Normal);
            physValues.Add(0x01, ElementalRes.Normal);
            physValues.Add(0x04, ElementalRes.Normal);
            physValues.Add(0x05, ElementalRes.Normal);
            physValues.Add(0x81, ElementalRes.Normal);

            physValues.Add(0x0D, ElementalRes.Halved);
            physValues.Add(0x10, ElementalRes.Halved);
            physValues.Add(0x11, ElementalRes.Halved);
            physValues.Add(0x14, ElementalRes.Halved);
            physValues.Add(0x15, ElementalRes.Halved);
            physValues.Add(0x91, ElementalRes.Halved);

            physValues.Add(0x18, ElementalRes.Resistant);
            physValues.Add(0x19, ElementalRes.Resistant);
            physValues.Add(0x1C, ElementalRes.Resistant);
            physValues.Add(0x1D, ElementalRes.Resistant);
            physValues.Add(0x98, ElementalRes.Resistant);

            physValues.Add(0x20, ElementalRes.Immune);
            physValues.Add(0x21, ElementalRes.Immune);
            physValues.Add(0x24, ElementalRes.Immune);
            physValues.Add(0x25, ElementalRes.Immune);
            #endregion
            scene = File.ReadAllBytes($"{main.RandoPath}\\original\\db\\resident\\bt_scene.wdb");
            enemies = new DataStoreWDB<DataStoreEnemy>();
            enemies.LoadData(File.ReadAllBytes($"{main.RandoPath}\\original\\db\\resident\\bt_chara_spec.wdb"));
            bytes = File.ReadAllBytes($"{main.RandoPath}\\original\\db\\resident\\bt_chara_spec.wdb");
        }
        public override void Randomize(BackgroundWorker backgroundWorker)
        {
            int completed = 0;
            bool noImmune = false; // ((FlagBool)Flags.EnemyFlags.Resistances.FlagData).Value;
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
                    e.HP = (uint)Math.Max(10, e.HP * Math.Pow(hpBase, Extensions.CubeRoot(boost)));
                    e.Strength = (ushort)Math.Max(1, e.Strength * Math.Pow(strMagBase, Extensions.CubeRoot(boost)));
                    e.Magic = (ushort)Math.Max(1, e.Magic * Math.Pow(strMagBase, Extensions.CubeRoot(boost)));
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
                    int levelDiff = e.Level - level;

                    e.HP = (uint)Math.Max(10, e.HP * Math.Pow(hpBase, Extensions.CubeRoot(levelDiff)));
                    e.Strength = (ushort)Math.Max(1, e.Strength * Math.Pow(strMagBase, Extensions.CubeRoot(levelDiff)));
                    e.Magic = (ushort)Math.Max(1, e.Magic * Math.Pow(strMagBase, Extensions.CubeRoot(levelDiff)));

                    if (e.CP > 0)
                        e.CP = (uint)Math.Max(1, e.CP * Math.Pow(cpBase, Extensions.CubeRoot(levelDiff)));
                    if (lv0)
                        e.Level = 0;
                    RandomNum.ClearRand();
                }

                if (Flags.ItemFlags.Drops)
                {
                    if (eID.ConnectedDrops != null)
                    {
                        e.CommonDropID = enemies[eID.ConnectedDrops].CommonDropID;
                        e.RareDropID = enemies[eID.ConnectedDrops].RareDropID;
                    }
                    else
                    {
                        Flags.ItemFlags.Drops.SetRand();
                        do
                        {
                            RandomizeDrop(enemies, e, eID, true);
                            RandomizeDrop(enemies, e, eID, false);
                        } while (e.CommonDropID == e.RareDropID && !string.IsNullOrEmpty(e.CommonDropID));
                        RandomNum.ClearRand();
                    }
                }

                DataStoreEnemy swap;
                if (Flags.EnemyFlags.Resistances)
                {
                    Flags.EnemyFlags.Resistances.SetRand();
                    do
                    {
                        swap = RandomNum.SelectRandomWeighted(enemyList, eS => eS == e ? 0 : 1);
                    } while (!(physValues[swap.PhysicalRes] >= ElementalRes.Resistant && swap.MagicRes >= ElementalRes.Resistant)
                    != !(physValues[e.PhysicalRes] >= ElementalRes.Resistant && e.MagicRes >= ElementalRes.Resistant));

                    ElementalRes o = e.ElemRes1;
                    e.ElemRes1 = swap.ElemRes1;
                    swap.ElemRes1 = o;

                    byte o2 = e.ElemRes2;
                    e.ElemRes2 = swap.ElemRes2;
                    swap.ElemRes2 = o2;

                    o2 = e.ElemRes3;
                    e.ElemRes3 = swap.ElemRes3;
                    swap.ElemRes3 = o2;

                    o2 = e.ElemRes4;
                    e.ElemRes4 = swap.ElemRes4;
                    swap.ElemRes4 = o2;
                    /*
                    o = e.PhysicalRes;
                    e.PhysicalRes = swap.PhysicalRes;
                    swap.PhysicalRes = o;
                    */
                    if (noImmune)
                    {
                        if (physValues[e.PhysicalRes] == ElementalRes.Immune)
                        {
                            e.PhysicalRes = physValues.Keys.Where(k => physValues[k] == ElementalRes.Halved).First();
                        }
                        if (e.MagicRes == ElementalRes.Immune)
                        {
                            e.MagicRes = ElementalRes.Halved;
                        }
                    }
                    RandomNum.ClearRand();
                }

                if (Flags.EnemyFlags.Debuffs)
                {
                    Flags.EnemyFlags.Debuffs.SetRand();
                    swap = RandomNum.SelectRandomWeighted(enemyList, eS => eS == e ? 0 : 1);

                    byte[] swapped = swap.DebuffRes;
                    byte[] enem = e.DebuffRes;


                    for (int i = 0; i < 16; i++)
                    {
                        byte o = enem[i];
                        enem[i] = swapped[i];
                        swapped[i] = o;
                    }

                    swap.DebuffRes = swapped;
                    e.DebuffRes = enem;
                    RandomNum.ClearRand();
                }

                if (Flags.EnemyFlags.RandStats)
                {
                    Flags.EnemyFlags.RandStats.SetRand();
                    StatValues stats = new StatValues(5);
                    int variance = Flags.EnemyFlags.RandStats.Range.Value;
                    stats.Randomize(variance);
                    e.HP = (uint)Math.Max(1, e.HP * stats[0] / 100f);
                    e.Strength = (ushort)Math.Max(1, e.Strength * stats[1] / 100f);
                    e.Magic = (ushort)Math.Max(1, e.Magic * stats[2] / 100f);
                    e.ChainRes = (uint)Math.Min(100, Math.Max(0, Math.Sqrt(Math.Pow(e.ChainRes + 1, 2f) * stats[3] / 100f) - 1));
                    e.StaggerPoint = (ushort)Math.Min(999, Math.Max(101, (e.StaggerPoint - 100) * stats[4] / 100f + 100));
                    RandomNum.ClearRand();
                }

                completed++;
                backgroundWorker.ReportProgress(completed * 100 / enemies.DataList.Count);
            });


            if (Flags.ItemFlags.Shops)
            {
                Flags.ItemFlags.Shops.SetRand();
                List<int> list = scene.IndexesOf(Encoding.UTF8.GetBytes("key_shop_"));

                List<string> shops = list.Select(i => Encoding.UTF8.GetString(scene.SubArray(i, 11))).ToList();
                for (int i = 0; i < shops.Count; i++)
                {
                    shops[i] = randomizers.Get<RandoTreasure>("Treasures").shopsRemaining[i];
                }

                for (int i = 0; i < list.Count; i++)
                {
                    scene.SetSubArray(list[i], Encoding.UTF8.GetBytes(shops[i]));
                }
                RandomNum.ClearRand();
            }
        }

        public override void Save()
        {
            File.WriteAllBytes($"db\\resident\\bt_chara_spec.wdb", enemies.Data);
            File.WriteAllBytes($"db\\resident\\bt_scene.wdb", scene);
        }

        private void RandomizeDrop(DataStoreWDB<DataStoreEnemy> enemies, DataStoreEnemy enemy, Enemy enemyID, bool common)
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
                    if (rankAdj > 0)
                        rank = RandomNum.RandInt(Math.Max(0, rank - rankAdj), Math.Min(TieredItems.manager.GetHighBound(), rank + rankAdj));
                    int oldRank = rank + 0;
                    Tuple<Item, int> newItem;
                    do
                    {
                        newItem = TieredItems.manager.Get(rank, 1, tiered => GetDropWeight(tiered, enemy.Level, enemyID.Type, item.ID.StartsWith("it") && enemy.Level > 50));
                        rank--;
                    } while ((newItem.Item1 == null || randomizers.Get<RandoTreasure>("Treasures").blacklistedWeapons.Contains(newItem.Item1)) && rank >= 0);
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
                    return (int)(t.Weight * 3.4f);
                return (int)Math.Max(1, t.Weight / 22.5f * mult);
            }
        }
    }
}
