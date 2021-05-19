using Bartz24.Data;
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
    public class RandoTreasure : Randomizer
    {
        public Dictionary<string, string> ShopMappings = new Dictionary<string, string>();
        public List<Item> blacklistedWeapons = new List<Item>();

        public DataStoreWDB<DataStoreTreasure, DataStoreID> oldTreasures;
        public DataStoreWDB<DataStoreTreasure, DataStoreID> treasures;
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
            oldTreasures = new DataStoreWDB<DataStoreTreasure, DataStoreID>();
            oldTreasures.LoadData(File.ReadAllBytes($"{main.RandoPath}\\original\\db\\resident\\treasurebox.wdb"));
            treasures = new DataStoreWDB<DataStoreTreasure, DataStoreID>();
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

            Dictionary<Treasure, Tuple<Item, int>> plando = main.treasurePlando1.GetTreasures();

            if (Flags.ItemFlags.Treasures)
            {
                plando.Values.ForEach(i =>
                {
                    if (i.Item1.ID.StartsWith("wea_") && i.Item1.ID.EndsWith("_001"))
                        blacklistedWeapons.Add(i.Item1);
                });
            }

            int completed = 0, index = -1;
            Flags.ItemFlags.Treasures.SetRand();
            treasures.IdList.Where(id=>!id.ID.StartsWith("!")).ForEach(tID =>
            {
                Treasure current = Treasures.treasures.Find(tr => tr.ID == tID.ID);
                DataStoreTreasure t = treasures[tID.ID];
                index++;
                Item item = Items.items.Where(i => i.ID == t.ItemID).FirstOrDefault();
                int rank = -1;
                if (item != null && Flags.ItemFlags.Treasures)
                {
                    if (current != null && plando.ContainsKey(current))
                    {
                        Item newItem = plando[current].Item1;
                        int amount = plando[current].Item2;
                        if (amount == -1)
                        {
                            Tiered<Item> tiered = TieredItems.manager.list.Find(tier => tier.Items.Contains(newItem));
                            amount = tiered.GetCount(RandomNum.RandInt(tiered.LowBound, tiered.HighBound), Int32.MaxValue);
                        }
                        t.ItemID = newItem.ID;
                        t.Count = (uint)amount;
                    }
                    else
                    {
                        rank = TieredItems.manager.GetRank(item, (int)t.Count);
                        if (rank != -1)
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
                }

                ranks[index] = rank;

                completed++;

                backgroundWorker.ReportProgress(completed * 100 / treasures.DataList.Count);
            });
            RandomNum.ClearRand();

            if (Flags.ItemFlags.ShopLocations)
            {
                ShopMappings.Clear();
                Dictionary<Item, Item> shops = main.shopOrderPlando1.GetShopReplacements();

                List<string> shopsRemaining = new List<string>();

                Flags.ItemFlags.ShopLocations.SetRand();
                for (int i = 1; i <= 13; i++)
                {
                    string id = "key_shop_" + i.ToString("00");
                    if (i == 4 || shops.Values.Where(item=>item.ID == id).Count() > 0)
                        continue;
                    shopsRemaining.Add(id);
                }
                shopsRemaining.Shuffle();

                ShopMappings.Add("key_shop_00", "key_shop_00");
                for (int i = 1; i <= 13; i++)
                {
                    string id = "key_shop_" + i.ToString("00");
                    if (i == 4)
                        continue;
                    if (shops.Keys.Where(item => item.ID == id).Count() > 0)
                        ShopMappings.Add(id, shops[shops.Keys.Where(item => item.ID == id).First()].ID);
                    else
                    {
                        ShopMappings.Add(id, shopsRemaining[0]);
                        shopsRemaining.RemoveAt(0);
                    }
                }

                treasures.DataList.ForEach(treasure =>
                {
                    if (treasure.ItemID.StartsWith("key_shop_"))
                    {
                        treasure.ItemID = ShopMappings[treasure.ItemID];
                    }
                });
                RandomNum.ClearRand();
            }
        }

        public override HTMLPage GetDocumentation()
        {
            HTMLPage page = new HTMLPage("Treasures", "template/documentation.html");

            foreach(TreasureArea area in Enum.GetValues(typeof(TreasureArea)))
            {
                if (Treasures.treasures.Where(t => t.Area == area).Count() > 0)
                {
                    page.HTMLElements.Add(new Table(area.SeparateWords(), new string[] { "Name", "Original Contents", "New Contents" }.ToList(), new int[] { 40, 30, 30 }.ToList(), Treasures.treasures.Where(t => t.Area == area).Select(t =>
                    {
                        Item oldItem = Items.items.Find(i => i.ID == oldTreasures[t].ItemID);
                        Item item = Items.items.Find(i => i.ID == treasures[t].ItemID);
                        return new string[] { t.Name, $"{(oldItem == null ? oldTreasures[t].ItemID : oldItem.Name)} x {oldTreasures[t].Count}", $"{(item == null ? treasures[t].ItemID : item.Name)} x {treasures[t].Count}" }.ToList();
                    }).ToList()));
                }

            }
            return page;
        }

        public override void Save()
        {
            File.WriteAllBytes($"db\\resident\\treasurebox.wdb", treasures.Data);
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
