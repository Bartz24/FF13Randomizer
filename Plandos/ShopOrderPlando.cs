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
    public partial class ShopOrderPlando : UserControl
    {
        public DataTable dataTable = new DataTable();
        public ShopOrderPlando()
        {
            InitializeComponent();
            AddEntries();
        }
        private void AddEntries()
        {
            dataTable.Columns.Add("id", typeof(string));
            dataTable.Columns.Add("Original Shop", typeof(string));
            dataTable.Columns.Add("New Shop", typeof(string));

            dataGridView1.AutoGenerateColumns = false;

            dataGridView1.Columns.Add(new DataGridViewTextBoxColumn());
            dataGridView1.Columns[0].HeaderText = "Original Shop";
            dataGridView1.Columns[0].DataPropertyName = "Original Shop";
            dataGridView1.Columns[0].ReadOnly = true;
            dataGridView1.Columns[0].SortMode = DataGridViewColumnSortMode.NotSortable;

            DataGridViewComboBoxColumn column = new DataGridViewComboBoxColumn();
            column.Items.AddRange(new string[] { "???" }.Concat(Items.items.Where(i=>i.ID.StartsWith("key_shop") && i != Items.UnicornMart).Select(i => i.Name).ToList()).ToArray());
            column.HeaderText = "New Shop";
            column.DisplayMember = "New Shop";
            column.ValueMember = "New Shop";
            column.DataPropertyName = "New Shop";
            column.SortMode = DataGridViewColumnSortMode.NotSortable;
            dataGridView1.Columns.Add(column);

            dataGridView1.DataSource = dataTable;
        }

        private void AddRowEntries()
        {
            for (int i = 1; i <= 13; i++)
            {
                string id = "key_shop_" + i.ToString("00");
                if (i == 4)
                    continue;
                dataTable.Rows.Add(id, Items.items.Find(item => item.ID == id).Name, "???");
            }
        }

        public void ReloadData(FormMain main)
        {
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.None;
            dataTable.Clear();

            AddRowEntries();
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        public Dictionary<Item, Item> GetShopReplacements()
        {
            Dictionary<Item, Item> dict = new Dictionary<Item, Item>();
            foreach (DataRow row in dataTable.Rows)
            {
                Item origShop = Items.items.Find(i => i.ID == row.Field<string>(0));
                Item newShop = Items.items.Find(i => i.Name == row.Field<string>(2) || i.ID == row.Field<string>(2));
                if (newShop != null)
                {
                    dict.Add(origShop, newShop);
                }
            }
            return dict;
        }

        private void dataGridView1_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        {
            FormMain.PlandoModified = true;
        }

        public class JSONPlandoShopOrder
        {
            public string ShopID { get; set; }
            public string NewShop { get; set; }
        }

        public List<JSONPlandoShopOrder> GetJSONPlando()
        {
            List<JSONPlandoShopOrder> list = new List<JSONPlandoShopOrder>();

            foreach (DataRow row in dataTable.Rows)
            {
                list.Add(new JSONPlandoShopOrder()
                {
                    ShopID = row.Field<string>(0),
                    NewShop = row.Field<string>(2)
                });
            }
            return list;
        }

        public void LoadJSONPlando(List<JSONPlandoShopOrder> list, string version)
        {
            list = MigrateJSON(list, version);
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.None;
            foreach (DataRow row in dataTable.Rows)
            {
                JSONPlandoShopOrder json = list.Find(j => j.ShopID == row.Field<string>(0));
                row.SetField<string>(2, json.NewShop);
            }
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        private List<JSONPlandoShopOrder> MigrateJSON(List<JSONPlandoShopOrder> list, string version)
        {
            if (version == FormMain.Version)
                return list;
            List<JSONPlandoShopOrder> migrated = new List<JSONPlandoShopOrder>(list);

            return migrated;
        }
    }
}
