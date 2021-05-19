using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using FF13Data;
using System.IO;
using System.Text.RegularExpressions;
using Bartz24.Data;

namespace FF13Randomizer
{
    public partial class ItemPlando : UserControl
    {
        public DataTable dataTable = new DataTable();
        public ItemPlando()
        {
            InitializeComponent();
            AddEntries();
        }
        private void AddEntries()
        {
            dataTable.Columns.Add("id", typeof(string));
            dataTable.Columns.Add("Name", typeof(string));
            dataTable.Columns.Add("Price", typeof(string));
            dataTable.Columns.Add("New Buy Price", typeof(int));
            dataTable.Columns.Add("New Sell Price", typeof(int));

            dataGridView1.AutoGenerateColumns = false;

            dataGridView1.Columns.Add(new DataGridViewTextBoxColumn());
            dataGridView1.Columns[0].HeaderText = "Name";
            dataGridView1.Columns[0].DataPropertyName = "Name";
            dataGridView1.Columns[0].ReadOnly = true;
            dataGridView1.Columns[0].SortMode = DataGridViewColumnSortMode.NotSortable;

            dataGridView1.Columns.Add(new DataGridViewTextBoxColumn());
            dataGridView1.Columns[1].HeaderText = "Price";
            dataGridView1.Columns[1].DataPropertyName = "Price";
            dataGridView1.Columns[1].ReadOnly = true;
            dataGridView1.Columns[1].SortMode = DataGridViewColumnSortMode.NotSortable;

            dataGridView1.Columns.Add(new DataGridViewTextBoxColumn());
            dataGridView1.Columns[2].HeaderText = "New Buy Price";
            dataGridView1.Columns[2].DataPropertyName = "New Buy Price";
            dataGridView1.Columns[2].SortMode = DataGridViewColumnSortMode.NotSortable;

            dataGridView1.Columns.Add(new DataGridViewTextBoxColumn());
            dataGridView1.Columns[3].HeaderText = "New Sell Price";
            dataGridView1.Columns[3].DataPropertyName = "New Sell Price";
            dataGridView1.Columns[3].SortMode = DataGridViewColumnSortMode.NotSortable;

            dataGridView1.DataSource = dataTable;
        }

        private void AddEntry(Item item)
        {
            dataTable.Rows.Add(item.ID, item.Name, "", -1, -1);
        }

        public void ReloadData(FormMain main)
        {
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.None;
            dataTable.Clear();

            DataStoreWDB<DataStoreItem, DataStoreID> items = new DataStoreWDB<DataStoreItem, DataStoreID>();
            items.LoadData(File.ReadAllBytes($"{main.RandoPath}\\original\\db\\resident\\item.wdb"));

            RandoItems.ApplyModifications(items);

            Items.items.Where(i => items.IdList.IndexOf(i.ID) != -1 && items[i].BuyPrice > 0 && items[i].SellPrice > 0).ForEach(i => AddEntry(i));

            foreach (DataRow row in dataTable.Rows)
            {
                Item item = Items.items.Find(i => i.ID == row.Field<string>(0));
                row.SetField<string>(2, $"{items[item].BuyPrice} ({items[item].SellPrice})");
            }

            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView1.Refresh();
        }

        private void dataGridView1_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        {
            if (e.ColumnIndex == 2 || e.ColumnIndex == 3)
            {
                int i = -1;

                if (!int.TryParse(Convert.ToString(e.FormattedValue), out i) || !(i == -1 || i >= 1 && i <= 999999999))
                {
                    e.Cancel = true;
                    MessageBox.Show("Must enter a number from 1-999999999 or -1");
                }
            }
            FormMain.PlandoModified = true;
        }

        public Dictionary<Item, int[]> GetItems()
        {
            Dictionary<Item, int[]> dict = new Dictionary<Item, int[]>();
            foreach (DataRow row in dataTable.Rows)
            {
                Item item = Items.items.Find(i => i.ID == row.Field<string>(0));
                int[] prices = new int[2];
                prices[0] = row.Field<int>(3);
                prices[1] = row.Field<int>(4);
                if (prices.Where(v => v != -1).Count() > 0)
                {
                    dict.Add(item, prices);
                }
            }
            return dict;
        }

        public Dictionary<Item, SynthesisGroup> GetSynthesisGroups()
        {
            Dictionary<Item, SynthesisGroup> dict = new Dictionary<Item, SynthesisGroup>();
            foreach (DataRow row in dataTable.Rows)
            {
                Item item = Items.items.Find(i => i.ID == row.Field<string>(0));
                string synthGroup = row.Field<string>(1);
                if (synthGroup != "???")
                {
                    dict.Add(item, Enum.GetValues(typeof(SynthesisGroup)).Cast<SynthesisGroup>().Where(s => s.SeparateWords() == synthGroup).First());
                }
            }
            return dict;
        }

        public class JSONPlandoItem
        {
            public string ID { get; set; }
            public int BuyPrice { get; set; }
            public int SellPrice { get; set; }
        }

        public List<JSONPlandoItem> GetJSONPlando()
        {
            List<JSONPlandoItem> list = new List<JSONPlandoItem>();

            foreach (DataRow row in dataTable.Rows)
            {
                list.Add(new JSONPlandoItem()
                {
                    ID = row.Field<string>(0),
                    BuyPrice = row.Field<int>(3),
                    SellPrice = row.Field<int>(4)
                });
            }
            
            return list;
        }

        public void LoadJSONPlando(List<JSONPlandoItem> list, string version)
        {
            
            list = MigrateJSON(list, version);
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.None;
            foreach (DataRow row in dataTable.Rows)
            {
                JSONPlandoItem json = list.Find(j => j.ID == row.Field<string>(0));
                row.SetField<int>(3, json.BuyPrice);
                row.SetField<int>(4, json.SellPrice);
            }
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        private List<JSONPlandoItem> MigrateJSON(List<JSONPlandoItem> list, string version)
        {
            if (version == FormMain.Version)
                return list;
            List<JSONPlandoItem> migrated = new List<JSONPlandoItem>(list);

            return migrated;
        }
    }
}
