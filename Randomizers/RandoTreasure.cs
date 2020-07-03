using FF13Data;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FF13Randomizer
{
    public class RandoTreasure : Randomizer
    {
        public List<string> shopsRemaining = new List<string>();
        public List<Item> blacklistedWeapons = new List<Item>();

        public TreasureDatabase oldTreasures;
        public TreasureDatabase treasures;
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
            oldTreasures = new TreasureDatabase($"{main.RandoPath}\\original\\db\\resident\\treasurebox.wdb");
            treasures = new TreasureDatabase($"{main.RandoPath}\\original\\db\\resident\\treasurebox.wdb");
            ranks = new int[treasures.Treasures.count];
        }
        public override void Randomize(BackgroundWorker backgroundWorker)
        {
            int rankAdj = ((FlagValue)Flags.ItemFlags.Drops.FlagData).Range.Value;
            Items.items.ForEach(i =>
            {
                if (i.ID.StartsWith("wea_") && i.ID.EndsWith("_001"))
                    blacklistedWeapons.Add(i);
            });

            int completed = 0, index = -1;
            Flags.ItemFlags.Treasures.SetRand();
            treasures.Treasures.ToList().ForEach(t =>
            {
                index++;
                Item item = Items.items.Where(i => i.ID == oldTreasures.ItemIDs[(int)t.StartingPointer]?.Value).FirstOrDefault();
                int rank = -1;
                if (item != null)
                {
                    rank = TieredItems.manager.GetRank(item, (int)t.Count);
                    if (rank != -1 && Flags.ItemFlags.Treasures.FlagEnabled)
                    {
                        if (rankAdj > 0)
                            rank = RandomNum.RandInt(Math.Max(0, rank - rankAdj), Math.Min(TieredItems.manager.GetHighBound(), rank + rankAdj));
                        Tuple<Item, int> newItem;
                        rank++;
                        do
                        {
                            rank--;
                            newItem = TieredItems.manager.Get(rank, Int32.MaxValue, tiered => GetTreasureWeight(tiered));
                        } while (rank >= 0 && (newItem.Item1 == null || blacklistedWeapons.Contains(newItem.Item1)));
                        if (newItem.Item1.ID.StartsWith("wea_"))
                            blacklistedWeapons.Add(newItem.Item1);
                        DataStoreString dataStr = new DataStoreString() { Value = newItem.Item1.ID };
                        if (!treasures.ItemIDs.Contains(dataStr))
                            treasures.ItemIDs.Add(dataStr, treasures.ItemIDs.GetTrueSize());
                        t.StartingPointer = (uint)treasures.ItemIDs.IndexOf(dataStr);
                        if (t.StartingPointer == 0xFFFFFFFF)
                            treasures.ItemIDs.IndexOf(dataStr);
                        t.EndingPointer = (uint)(t.StartingPointer + dataStr.Value.Length);
                        t.Count = (uint)newItem.Item2;

                        if (t.StartingPointer > 0xAAAA || t.EndingPointer > 0xAAAA)
                            throw new Exception("Too large");
                    }
                }

                ranks[index] = rank;

                completed++;

                backgroundWorker.ReportProgress(completed * 100 / treasures.Treasures.count);
            });
            RandomNum.ClearRand();

            if (Flags.ItemFlags.Shops.FlagEnabled)
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
                treasures.ItemIDs.ToList().ForEach(str =>
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

            treasures.Save($"db\\resident\\treasurebox.wdb");

            DocsJSONGenerator.CreateTreasureDocs(treasures, ranks);

        }

        public static int GetTreasureWeight(Tiered<Item> t)
        {
            if (t.Items.Where(i => i.ID.StartsWith("it")).Count() > 0)
                return Math.Max(1, t.Weight * 8);
            if (t.Items.Where(i => i.ID.StartsWith("acc")).Count() > 0)
                return (int)Math.Max(1, t.Weight * 1.2);
            if (t.Items.Where(i => i.ID.StartsWith("material_o")).Count() > 0)
                return Math.Max(1, t.Weight / 45);
            if (t.Items.Where(i => i.ID.StartsWith("material")).Count() > 0)
                return (int)Math.Max(1, t.Weight * 1.5);
            return (int)(t.Weight * 2);
        }
    }
}
