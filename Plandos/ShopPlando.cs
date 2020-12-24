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

            shops.IdList.Where(s => !s.ID.StartsWith("!")).ForEach(s => AddEntries(s.ID));
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

        public Dictionary<Shop, List<Item>> GetShops()
        {
            Dictionary<Shop, List<Item>> dict = new Dictionary<Shop, List<Item>>();
            Shops.shops.ForEach(s => dict.Add(s, new List<Item>()));
            foreach (DataRow row in dataTable.Rows)
            {
                Shop shop = Shops.shops.Find(s => s.GetAllIds().Contains(row.Field<string>(0)));
                Item item = Items.items.Find(i => i.Name == row.Field<string>(3) || i.ID == row.Field<string>(3));
                if (row.Field<string>(3) == "None")
                    item = Items.Gil;
                if (item != null)
                {
                    dict[shop].Add(item);
                }
            }
            return dict;
        }

        public class JSONPlandoShop
        {
            public string ShopID { get; set; }
            public int Index { get; set; }
            public string Item { get; set; }
        }

        public List<JSONPlandoShop> GetJSONPlando()
        {
            List<JSONPlandoShop> list = new List<JSONPlandoShop>();

            foreach (DataRow row in dataTable.Rows)
            {
                list.Add(new JSONPlandoShop()
                {
                    ShopID = row.Field<string>(0),
                    Index = row.Field<int>(1),
                    Item = row.Field<string>(3)
                });
            }
            return list;
        }

        public void LoadJSONPlando(List<JSONPlandoShop> list)
        {
            foreach (DataRow row in dataTable.Rows)
            {
                JSONPlandoShop json = list.Find(j => j.ShopID == row.Field<string>(0) && j.Index == row.Field<int>(1));
                row.SetField<string>(3, json.Item);
            }
        }

        private void dataGridView1_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        {
            FormMain.PlandoModified = true;
        }
    }
}
