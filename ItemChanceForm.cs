using FF13Data;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FF13Randomizer
{
    public partial class ItemChanceForm : Form
    {
        List<Item> blacklistedWeapons = new List<Item>();
        public ItemChanceForm()
        {
            InitializeComponent();

            Items.items.ForEach(i => comboItem.Items.Add(i.Name));
            Items.items.ForEach(i =>
            {
                if (i.ID.StartsWith("wea_") && i.ID.EndsWith("_001"))
                    blacklistedWeapons.Add(i);
            });
        }

        private void button1_Click(object sender, EventArgs e)
        {
            dataGridView1.Rows.Clear();

            Item item = Items.items.Where(i => i.Name == comboItem.Text).First();
            int rankAdj = Flags.ItemFlags.Treasures.Range.Value;
            if(radioEnemy.Checked)
                rankAdj = Flags.ItemFlags.Drops.Range.Value;

            Dictionary<Item, Tuple<int, int, int>> table = new Dictionary<Item, Tuple<int, int, int>>();
            // Low, High, Count
            RandomNum.SetRand(new FF13Data.Random());
            int times = 10000;
            for (int i = 0; i < times; i++)
            {
                Tuple<Item, int> newItem = GetItem(item, rankAdj);
                if (newItem != null)
                {
                    if (!table.ContainsKey(newItem.Item1))
                    {
                        table.Add(newItem.Item1, new Tuple<int, int, int>(newItem.Item2, newItem.Item2, 1));
                    }
                    else
                    {
                        Tuple<int, int, int> tuple = table[newItem.Item1];
                        int low = Math.Min(tuple.Item1, newItem.Item2);
                        int high = Math.Max(tuple.Item2, newItem.Item2);
                        table[newItem.Item1] = new Tuple<int, int, int>(low, high, tuple.Item3 + 1);
                    }
                }
            }
            RandomNum.ClearRand();
            table.Keys.ToList().ForEach(i => {
                dataGridView1.Rows.Add(
                    i.Name,
                    table[i].Item1 < table[i].Item2 ? $"{table[i].Item1} - {table[i].Item2}" : table[i].Item2.ToString(),
                    table[i].Item3 / (float)times);
            });
        }

        private Tuple<Item, int> GetItem(Item item, int rankAdj)
        {
            int rank = TieredItems.manager.GetRank(item, radioEnemy.Checked ? 1 : (int)numericCount.Value);
            if (rank != -1)
            {
                if (rankAdj > 0)
                    rank = RandomNum.RandInt(Math.Max(0, rank - rankAdj), Math.Min(TieredItems.manager.GetHighBound(), rank + rankAdj));
                int oldRank = rank + 0;
                Tuple<Item, int> newItem;
                do
                {
                    newItem = TieredItems.manager.Get(rank, radioEnemy.Checked ? 1 : Int32.MaxValue, tiered => GetWeight(tiered, item));
                    rank--;
                } while ((newItem.Item1 == null || blacklistedWeapons.Contains(newItem.Item1)) && rank >= 0);
                if (newItem.Item1 == null)
                    return null;
                return newItem;
            }
            return null;
        }

        private int GetWeight(Tiered<Item> tiered, Item item)
        {
            if (radioTreasure.Checked)
                return RandoTreasure.GetTreasureWeight(tiered, false, false);
            else
                return RandoEnemies.GetDropWeight(tiered, (int)numericLevel.Value, SelectedType(), item.ID.StartsWith("it") && numericLevel.Value > 50);
        }

        private EnemyType SelectedType()
        {
            if (comboBox1.Text == "Boss")
                return EnemyType.Boss;
            if (comboBox1.Text == "Rare")
                return EnemyType.Rare;
            return EnemyType.Normal;
        }
    }
}
