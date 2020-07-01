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
        EnemyStatDatabase enemies;
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
            enemies = new EnemyStatDatabase($"{main.RandoPath}\\original\\db\\resident\\bt_chara_spec.wdb");
            bytes = File.ReadAllBytes($"{main.RandoPath}\\original\\db\\resident\\bt_chara_spec.wdb");
        }
        public override void Randomize(BackgroundWorker backgroundWorker)
        {
            int completed = 0;
            List<DataStoreEnemy> enemyList = enemies.Enemies.ToList();
            bool noImmune = false; // ((FlagBool)Flags.EnemyFlags.Resistances.FlagData).Value;
            enemyList.ForEach(e =>
            {
                byte[] idBytes = bytes.SubArray(completed * 0x20 + 0x90, 0x10);
                string id = Encoding.UTF8.GetString(idBytes).Replace("\0", "");

                if (Flags.EnemyFlags.BoostLevel.FlagEnabled)
                {
                    int boost = ((FlagValue)Flags.EnemyFlags.BoostLevel.FlagData).Range.Value;
                    bool lv0 = e.Level == 0;
                    byte level = (byte)(lv0 ? 10 : e.Level);
                    e.HP = (uint)Math.Max(1, e.HP * Math.Exp(Math.Pow(level + boost, 0.25) - Math.Pow(level, 0.25)));
                    e.Strength = (ushort)Math.Max(1, e.Strength * Math.Exp(Math.Pow(level + boost, 0.25) - Math.Pow(level, 0.25)));
                    e.Magic = (ushort)Math.Max(1, e.Magic * Math.Exp(Math.Pow(level + boost, 0.25) - Math.Pow(level, 0.25)));
                }

                if (Flags.EnemyFlags.RandLevel.FlagEnabled)
                {
                    Flags.EnemyFlags.RandLevel.SetRand();
                    int variance = ((FlagValue)Flags.EnemyFlags.RandLevel.FlagData).Range.Value;
                    int boost = Flags.EnemyFlags.BoostLevel.FlagEnabled ? ((FlagValue)Flags.EnemyFlags.BoostLevel.FlagData).Range.Value : 0;
                    bool lv0 = e.Level == 0;
                    byte level = (byte)(lv0 ? 10 : e.Level);
                    if (level < 50)
                        e.Level = (byte)RandomNum.RandInt(Math.Max(1, level - variance), Math.Min(49, level + variance));
                    else if (level > 50)
                        e.Level = (byte)RandomNum.RandInt(Math.Max(51, level - variance), Math.Min(99, level + variance));
                    e.HP = (uint)Math.Max(1, e.HP * Math.Exp(Math.Pow(e.Level + boost, 0.25) - Math.Pow(level + boost, 0.25)));
                    e.Strength = (ushort)Math.Max(1, e.Strength * Math.Exp(Math.Pow(e.Level + boost, 0.25) - Math.Pow(level + boost, 0.25)));
                    e.Magic = (ushort)Math.Max(1, e.Magic * Math.Exp(Math.Pow(e.Level + boost, 0.25) - Math.Pow(level + boost, 0.25)));
                    if (e.CP > 0)
                        e.CP = (uint)Math.Max(1, e.CP * Math.Exp(Math.Pow(e.Level, 0.4) - Math.Pow(level, 0.4)));
                    if (lv0)
                        e.Level = 0;
                    RandomNum.ClearRand();
                }

                if (Flags.ItemFlags.Drops.FlagEnabled)
                {
                    Flags.ItemFlags.Drops.SetRand();
                    do
                    {
                        RandomizeDrop(enemies, e, true);
                        RandomizeDrop(enemies, e, false);
                    } while (e.CommonDropPointer == e.RareDropPointer && enemies.ItemIDs[(int)e.CommonDropPointer].Value != "");
                    RandomNum.ClearRand();
                }

                DataStoreEnemy swap;
                if (Flags.EnemyFlags.Resistances.FlagEnabled)
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

                if (Flags.EnemyFlags.Debuffs.FlagEnabled)
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

                if (Flags.EnemyFlags.RandStats.FlagEnabled)
                {
                    Flags.EnemyFlags.RandStats.SetRand();
                    StatValues stats = new StatValues(5);
                    int variance = ((FlagValue)Flags.EnemyFlags.RandStats.FlagData).Range.Value;
                    stats.Randomize(variance);
                    e.HP = (uint)Math.Max(1, e.HP * stats[0] / 100f);
                    e.Strength = (ushort)Math.Max(1, e.Strength * stats[1] / 100f);
                    e.Magic = (ushort)Math.Max(1, e.Magic * stats[2] / 100f);
                    e.ChainRes = (uint)Math.Min(100, Math.Max(0, Math.Sqrt(Math.Pow(e.ChainRes + 1, 2f) * stats[3] / 100f) - 1));
                    e.StaggerPoint = (ushort)Math.Min(999, Math.Max(101, (e.StaggerPoint - 100) * stats[4] / 100f + 100));
                    RandomNum.ClearRand();
                }

                completed++;
                backgroundWorker.ReportProgress(completed * 100 / enemies.Enemies.count);
            });


            if (Flags.ItemFlags.Shops.FlagEnabled)
            {
                Flags.ItemFlags.Shops.SetRand();
                List<int> list = scene.IndexesOf(Encoding.UTF8.GetBytes("key_shop_"));

                List<string> shops = list.Select(i => Encoding.UTF8.GetString(scene.SubArray(i, 11))).ToList();
                for (int i = 0; i < shops.Count; i++)
                {
                    shops[i] = ((RandoTreasure)randomizers.Get("Treasures")).shopsRemaining[i];
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
            enemies.Save($"db\\resident\\bt_chara_spec.wdb");
            File.WriteAllBytes($"db\\resident\\bt_scene.wdb", scene);
        }

        private void RandomizeDrop(EnemyStatDatabase enemies, DataStoreEnemy enemy, bool common)
        {
            int rankAdj = ((FlagValue)Flags.ItemFlags.Drops.FlagData).Range.Value;
            Item item = null;
            if (enemies.ItemIDs[(int)(common ? enemy.CommonDropPointer : enemy.RareDropPointer)].Value != "")
                item = Items.items.Where(i => i.ID ==
                    enemies.ItemIDs[(int)(common ? enemy.CommonDropPointer : enemy.RareDropPointer)].Value).FirstOrDefault();
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
                        newItem = TieredItems.manager.Get(rank, 1, tiered => GetDropWeight(tiered, enemy.Level, item.ID.StartsWith("it") && enemy.Level > 50));
                        rank--;
                    } while ((newItem.Item1 == null || ((RandoTreasure)randomizers.Get("Treasures")).blacklistedWeapons.Contains(newItem.Item1)) && rank >= 0);
                    if (newItem.Item1 == null)
                        return;
                    if (newItem.Item1.ID.StartsWith("wea_"))
                        ((RandoTreasure)randomizers.Get("Treasures")).blacklistedWeapons.Add(newItem.Item1);
                    DataStoreString dataStr = new DataStoreString() { Value = newItem.Item1.ID };
                    if (!enemies.ItemIDs.Contains(dataStr))
                        enemies.ItemIDs.Add(dataStr, enemies.ItemIDs.GetTrueSize());
                    if (common)
                        enemy.CommonDropPointer = (uint)enemies.ItemIDs.IndexOf(dataStr);
                    else
                        enemy.RareDropPointer = (uint)enemies.ItemIDs.IndexOf(dataStr);
                }
            }
        }

        public static int GetDropWeight(Tiered<Item> t, int enemyLevel, bool forceNormalDrop)
        {
            if (t.Items.Where(i => i.ID == "").Count() > 0)
                return 0;
            float mult;
            if (enemyLevel > 50 && !forceNormalDrop)
            {
                mult = 1 + .01f * (float)Math.Pow(enemyLevel - 50, .8f);
                if (t.Items.Where(i => i.ID.StartsWith("material_o")).Count() > 0)
                    return (int)(t.Weight * 1.5 * mult);
                if (t.Items.Where(i => i.ID.StartsWith("material")).Count() > 0)
                    return 0;
                if (t.Items.Where(i => i.ID.StartsWith("it")).Count() > 0)
                    return Math.Max(1, t.Weight / 4);
                return (int)(t.Weight * 2 * mult);
            }
            mult = 1 + .01f * (float)Math.Pow(enemyLevel, .8f);
            if (t.Items.Where(i => i.ID.StartsWith("material_o")).Count() > 0)
                return (int)(t.Weight);
            if (t.Items.Where(i => i.ID.StartsWith("material")).Count() > 0)
                return (int)(t.Weight * 18.2f);
            if (t.Items.Where(i => i.ID.StartsWith("wea_")).Count() > 0)
                return 0;
            return (int)Math.Max(1, t.Weight / 22.5f * mult);
        }
    }
}
