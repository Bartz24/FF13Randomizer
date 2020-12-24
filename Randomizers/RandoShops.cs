using FF13Data;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FF13Randomizer
{
    public class RandoShops : Randomizer
    {
        DataStoreWDB<DataStoreShop, DataStoreID> shops;

        public RandoShops(FormMain formMain, RandomizerManager randomizers) : base(formMain, randomizers) { }

        public override string GetProgressMessage()
        {
            return "Randomizing Shops...";
        }
        public override string GetID()
        {
            return "Shops";
        }

        public override void Load()
        {
            shops = new DataStoreWDB<DataStoreShop, DataStoreID>();
            shops.LoadData(File.ReadAllBytes($"{main.RandoPath}\\original\\db\\resident\\shop.wdb"));
        }
        public override void Randomize(BackgroundWorker backgroundWorker)
        {
            RandomizeShops();
            NoShops();
        }

        private void NoShops()
        {
            if (Tweaks.Challenges.NoShops)
            {
                shops.DataList.ForEach(shop => {
                    Enumerable.Range(0, 32).ForEach(i => shop.SetItemID(i, ""));
                });
            }
        }

        private void RandomizeShops()
        {
            if (Flags.ItemFlags.Shops)
            {
                Flags.ItemFlags.Shops.SetRand();
                RandoEquip randoEquip = randomizers.Get<RandoEquip>("Equip");

                Dictionary<Shop, List<Item>> plando = main.shopPlando1.GetShops();

                List<Item> guaranteed = Items.items.Where(item => item.PreferredShop != null &&
                                                            randoEquip.equip.IdList.Where(id => id.ID == item.ID).Count() > 0 &&
                                                            randoEquip.equip.DataList.ToList().Where(e => e.UpgradeInto == item.ID).Count() == 0 &&
                                                            !plando.Values.SelectMany(l => l).Contains(item)).ToList();
                guaranteed.Add(Items.Potion);
                guaranteed.Add(Items.PhoenixDown);
                guaranteed.Add(Items.Millerite);
                guaranteed.Add(Items.Rhodochrosite);
                guaranteed.Add(Items.Cobaltite);
                guaranteed.Add(Items.Perovskite);
                guaranteed.Add(Items.Uraninite);
                guaranteed.Add(Items.MnarStone);
                guaranteed.Add(Items.Scarletite);
                guaranteed.Add(Items.Adamantite);
                guaranteed.Add(Items.DarkMatter);
                guaranteed.Add(Items.Trapezohedron);
                guaranteed.Shuffle();

                int initalGuaranteedCount = guaranteed.Count;
                int totalCount = Shops.shops.Sum(id => shops[$"{id.ID}{id.Tiers - 1}"].ItemCount);

                List<Item> shuffled = Items.items.Where(i => !guaranteed.Contains(i) && i.PreferredShop != null && !plando.Values.SelectMany(l => l).Contains(i)).ToList();
                shuffled.Shuffle();

                Shops.shops.ForEach(shopID =>
                {
                    int minSize = shops[$"{shopID.ID}{shopID.Tiers - 1}"].ItemCount;

                    List<Item> list = new List<Item>();

                    list.AddRange(plando[shopID]);

                    if (Flags.ItemFlags.Shops.ExtraSelected)
                    {
                        list.AddRange(guaranteed.Where(item => item.PreferredShop == shopID));
                        guaranteed.RemoveAll(item => item.PreferredShop == shopID);
                    }
                    else
                    {
                        int count = (int)Math.Ceiling((float)minSize / totalCount * initalGuaranteedCount);
                        for (int i = 0; i < count; i++)
                        {
                            if (guaranteed.Count == 0)
                                break;
                            list.Add(guaranteed[0]);
                            guaranteed.RemoveAt(0);
                        }
                    }

                    List<Item> possible = Flags.ItemFlags.Shops.ExtraSelected ? shuffled.Where(item => item.PreferredShop == shopID).ToList() : new List<Item>(shuffled);
                    int maxSize = RandomNum.RandInt(Math.Max(minSize, list.Count), Math.Min(list.Count + possible.Count, 32));

                    while (list.Count < maxSize && possible.Count > 0)
                    {
                        list.Add(possible[0]);
                        shuffled.Remove(possible[0]);
                        possible.RemoveAt(0);
                    }

                    RandoItems randoItems = randomizers.Get<RandoItems>("Items");

                    if (Flags.ItemFlags.Shops.ExtraSelected2)
                    {
                        list = list.OrderBy(item => randoItems.items[item].BuyPrice).ToList();

                        if (list.Count > 1)
                        {
                            for (int i = 0; i < Math.Max(2,list.Count / 3); i++)
                            {
                                int start = RandomNum.RandInt(0, list.Count - 2);
                                list.Swap(start, start + 1);
                            }
                        }

                        if (list.Contains(Items.Potion) && list.Count > 1 && list.IndexOf(Items.Potion) > 0)
                        {
                            list.Remove(Items.Potion);
                            list.Insert(0, Items.Potion);
                        }
                        if (list.Contains(Items.PhoenixDown) && list.Count > 1 && list.IndexOf(Items.PhoenixDown) > 1)
                        {
                            list.Remove(Items.PhoenixDown);
                            list.Insert(1, Items.PhoenixDown);
                        }
                    }

                    List<int> splits = new List<int>();
                    for (int i = 0; i < shopID.Tiers - 1; i++)
                    {
                        int num = -1;
                        do
                        {
                            num = RandomNum.RandInt(1, list.Count - 1);
                        } while (splits.Contains(num));
                        splits.Add(num);
                    }
                    splits.Add(list.Count);

                    splits = splits.OrderBy(v => v).ToList();

                    for (int i = 0; i < shopID.Tiers; i++)
                    {
                        List<Item> itemsAtTier = list.ToArray().SubArray(0, splits[i]).OrderBy(item => Items.items.IndexOf(item)).ToList();
                        for (int i2 = 0; i2 < 32; i2++)
                        {
                            shops[$"{shopID.ID}{i}"].SetItemID(i2, i2 < itemsAtTier.Count ? itemsAtTier[i2].ID : "");
                        }
                    }
                });

                RandomNum.ClearRand();
            }
        }

        public override void Save()
        {
            File.WriteAllBytes("db\\resident\\shop.wdb", shops.Data);
        }
    }
}
