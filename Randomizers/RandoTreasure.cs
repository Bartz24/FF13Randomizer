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
    public class RandoTreasure : Randomizer
    {
        public List<string> shopsRemaining = new List<string>();
        public List<Item> blacklistedWeapons = new List<Item>();

        public DataStoreWDB<DataStoreTreasure> oldTreasures;
        public DataStoreWDB<DataStoreTreasure> treasures;
        int[] ranks;

        public RandoTreasure(FormMain formMain, RandomizerManager randomizers) : base(formMain, randomizers) { }

        public override string GetProgressMessage()
        {
            return "Randomizing Treasures...";
        }
        public override string GetID()
        {
            return "Treasures";
        }

        public override void Load()
        {
            oldTreasures = new DataStoreWDB<DataStoreTreasure>();
            oldTreasures.LoadData(File.ReadAllBytes($"{main.RandoPath}\\original\\db\\resident\\treasurebox.wdb"));
            treasures = new DataStoreWDB<DataStoreTreasure>();
            treasures.LoadData(File.ReadAllBytes($"{main.RandoPath}\\original\\db\\resident\\treasurebox.wdb"));
            ranks = new int[treasures.DataList.Length];
        }
        public override void Randomize(BackgroundWorker backgroundWorker)
        {
            int rankAdj = Flags.ItemFlags.Drops.Range.Value;
            Items.items.ForEach(i =>
            {
                if (i.ID.StartsWith("wea_") && i.ID.EndsWith("_001"))
                    blacklistedWeapons.Add(i);
            });

            int completed = 0, index = -1;
            Flags.ItemFlags.Treasures.SetRand();
            treasures.IdList.Where(id=>!id.ID.StartsWith("!")).ToList().ForEach(tID =>
            {
                DataStoreTreasure t = treasures[tID.ID];
                index++;
                Item item = Items.items.Where(i => i.ID == t.ItemID).FirstOrDefault();
                int rank = -1;
                if (item != null)
                {
                    rank = TieredItems.manager.GetRank(item, (int)t.Count);
                    if (rank != -1 && Flags.ItemFlags.Treasures)
                    {
                        if (rankAdj > 0)
                            rank = RandomNum.RandInt(Math.Max(0, rank - rankAdj), Math.Min(TieredItems.manager.GetHighBound(), rank + rankAdj));
                        Tuple<Item, int> newItem;
                        rank++;
                        do
                        {
                            rank--;
                            newItem = TieredItems.manager.Get(rank, Int32.MaxValue, tiered => 
                                GetTreasureWeight(tiered, tID.ID.StartsWith("tre_ms"), 
                                    (tID.ID.StartsWith("tre_ms") && tID.ID.EndsWith("02")) || 
                                    (tID.ID.StartsWith("tre_vpek") && Int32.Parse(tID.ID.Substring(tID.ID.Length - 3)) >= 26)));
                        } while (rank >= 0 && (newItem.Item1 == null || blacklistedWeapons.Contains(newItem.Item1)));
                        if (newItem.Item1.ID.StartsWith("wea_"))
                            blacklistedWeapons.Add(newItem.Item1);
                        t.ItemID = newItem.Item1.ID;
                        t.Count = (uint)newItem.Item2;
                    }
                }

                ranks[index] = rank;

                completed++;

                backgroundWorker.ReportProgress(completed * 100 / treasures.DataList.Count);
            });
            RandomNum.ClearRand();

            if (Flags.ItemFlags.Shops)
            {
                Flags.ItemFlags.Shops.SetRand();
                shopsRemaining.Clear();
                for (int i = 1; i <= 13; i++)
                {
                    if (i == 4)
                        continue;
                    shopsRemaining.Add("key_shop_" + i.ToString("00"));
                }
                shopsRemaining.Shuffle();
                treasures.StringList.ToList().ForEach(str =>
                {
                    if (str.Value.StartsWith("key_shop_"))
                    {
                        str.Value = shopsRemaining[0];
                        shopsRemaining.RemoveAt(0);
                    }
                });
                RandomNum.ClearRand();
            }
        }

        public override void Save()
        {
            File.WriteAllBytes($"db\\resident\\treasurebox.wdb", treasures.Data);

            DocsJSONGenerator.CreateTreasureDocs(treasures, ranks);

        }

        public static int GetTreasureWeight(Tiered<Item> t, bool mission, bool missableOrRepeatable)
        {
            if (mission && t == TieredItems.Gil)
                return 0;
            if (missableOrRepeatable && t.Items.Where(i => i.ID.StartsWith("wea_")).Count() > 0)
                return 0;
            if (missableOrRepeatable && t.Items.Where(i => i.ID.StartsWith("material_o")).Count() > 0)
                return (int)Math.Max(1, t.Weight * 4);
            if (missableOrRepeatable && t.Items.Where(i => i.ID.StartsWith("material")).Count() > 0)
                return (int)Math.Max(1, t.Weight * 8);
            if (t.Items.Where(i => i.ID.StartsWith("it")).Count() > 0)
                return Math.Max(1, t.Weight * 4);
            if (t.Items.Where(i => i.ID.StartsWith("acc")).Count() > 0)
                return (int)Math.Max(1, t.Weight * 1.2);
            if (t.Items.Where(i => i.ID.StartsWith("material_o")).Count() > 0)
                return (int)Math.Max(1, t.Weight / 1.2);
            if (t.Items.Where(i => i.ID.StartsWith("material")).Count() > 0)
                return (int)Math.Max(1, t.Weight * 0.9);
            return (int)(t.Weight * 2);
        }
    }
}
