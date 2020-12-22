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

namespace FF13Randomizer
{
    public partial class ShopPlando : UserControl
    {
        private bool loaded = false;
        public DataTable dataTable = new DataTable();
        public ShopPlando()
        {
            InitializeComponent();
            SetupCombobox();
            AddEntries();
        }

        private void SetupCombobox()
        {
            comboBox1.Items.AddRange(Shops.shops.SelectMany(s => Enumerable.Range(0, s.Tiers).Select(i => s.Name + " " + ++i)).ToArray());
        }
        private void AddEntries()
        {
            dataTable.Columns.Add("id", typeof(string));
            dataTable.Columns.Add("index", typeof(int));
            dataTable.Columns.Add("Original Item", typeof(string));
            dataTable.Columns.Add("New Item", typeof(string));

            dataGridView1.AutoGenerateColumns = false;

            dataGridView1.Columns.Add(new DataGridViewTextBoxColumn());
            dataGridView1.Columns[0].HeaderText = "Original Item";
            dataGridView1.Columns[0].DataPropertyName = "Original Item";
            dataGridView1.Columns[0].ReadOnly = true;
            dataGridView1.Columns[0].SortMode = DataGridViewColumnSortMode.NotSortable;

            DataGridViewComboBoxColumn column = new DataGridViewComboBoxColumn();
            column.Items.AddRange(new string[] { "???" }.Concat(Items.items.Select(i => i.Name).ToList().Replace(Items.Gil.Name, "None")).ToArray());
            column.HeaderText = "New Item";
            column.DisplayMember = "New Item";
            column.ValueMember = "New Item";
            column.DataPropertyName = "New Item";
            column.SortMode = DataGridViewColumnSortMode.NotSortable;
            dataGridView1.Columns.Add(column);

            dataGridView1.DataSource = dataTable;
        }

        private void AddEntries(string shopID)
        {
            for (int i = 0; i < 32; i++)
            {
                dataTable.Rows.Add(shopID, i, "Unknown", "???");
            }
        }

        public void ReloadData(FormMain main)
        {
            if (loaded)
                return;

            DataStoreWDB<DataStoreShop, DataStoreID> shops = new DataStoreWDB<DataStoreShop, DataStoreID>();

            shops.LoadData(File.ReadAllBytes($"{main.RandoPath}\\original\\db\\resident\\shop.wdb"));

            shops.IdList.Where(s => !s.ID.StartsWith("!")).ToList().ForEach(s => AddEntries(s.ID));
            foreach (DataRow row in dataTable.Rows)
            {
                Item item = Items.items.Find(i => i.ID == shops[row.Field<string>(0)].GetItemID(row.Field<int>(1)));
                string name;
                if (item == null)
                    name = shops[row.Field<string>(0)].GetItemID(row.Field<int>(1));
                else if (item == Items.Gil)
                    name = "None";
                else
                    name = item.Name;
                row.SetField<string>(2, name);
            }

            loaded = true;
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (dataGridView1.DataSource != null && comboBox1.SelectedIndex > -1)
            {
                dataGridView1.Visible = true;
                CurrencyManager currencyManager1 = (CurrencyManager)dataGridView1.BindingContext[dataGridView1.DataSource];
                currencyManager1.SuspendBinding();
                string uiShopName = Shops.shops.SelectMany(s => Enumerable.Range(0, s.Tiers).Select(i => s.Name + " " + ++i)).ToArray()[comboBox1.SelectedIndex];
                string shopName = uiShopName.Substring(0, uiShopName.LastIndexOf(' '));
                string shopID = Shops.shops.Find(sh => sh.Name == shopName).ID;
                int tier = int.Parse(uiShopName.Substring(uiShopName.LastIndexOf(' ') + 1)) - 1;
                for (int row = 0; row < dataGridView1.Rows.Count; row++)
                {
                    dataGridView1.Rows[row].Visible = dataTable.Rows[row].Field<string>(0) == (shopID + tier);
                }
                currencyManager1.ResumeBinding();
                dataGridView1.Refresh();                
            }
        }

        public Dictionary<Treasure, Tuple<Item, int>> GetTreasures()
        {
            Dictionary<Treasure, Tuple<Item, int>> dict = new Dictionary<Treasure, Tuple<Item, int>>();
            foreach (DataRow row in dataTable.Rows)
            {
                Treasure first = Treasures.treasures.Find(t => t.ID == row.Field<string>(0));
                Item item = Items.items.Find(i => i.Name == row.Field<string>(3));
                int amount = row.Field<int>(4);
                if(first!=null && item!= null)
                {
                    dict.Add(first, new Tuple<Item, int>(item, amount));
                }
            }
            return dict;
        }
    }
}
