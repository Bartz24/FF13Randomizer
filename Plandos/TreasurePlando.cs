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
    public partial class TreasurePlando : UserControl
    {
        public DataTable dataTable = new DataTable();
        public TreasurePlando()
        {
            InitializeComponent();
            SetupCombobox();
            AddEntries();
        }

        private void SetupCombobox()
        {
            comboBox1.Items.AddRange(Enum.GetValues(typeof(TreasureArea)).Cast<TreasureArea>().Select(v => v.SeparateWords()).ToArray());
        }
        private void AddEntries()
        {
            dataTable.Columns.Add("id", typeof(string));
            dataTable.Columns.Add("Treasure", typeof(string));
            dataTable.Columns.Add("Original Item", typeof(string));
            dataTable.Columns.Add("New Item", typeof(string));
            dataTable.Columns.Add("Amount", typeof(int));

            dataGridView1.AutoGenerateColumns = false;

            dataGridView1.Columns.Add(new DataGridViewTextBoxColumn());
            dataGridView1.Columns[0].HeaderText = "Treasure";
            dataGridView1.Columns[0].DataPropertyName = "Treasure";
            dataGridView1.Columns[0].ReadOnly = true;
            dataGridView1.Columns[0].SortMode = DataGridViewColumnSortMode.NotSortable;
            dataGridView1.Columns.Add(new DataGridViewTextBoxColumn());
            dataGridView1.Columns[1].HeaderText = "Original Item";
            dataGridView1.Columns[1].DataPropertyName = "Original Item";
            dataGridView1.Columns[1].ReadOnly = true;
            dataGridView1.Columns[1].SortMode = DataGridViewColumnSortMode.NotSortable;

            DataGridViewComboBoxColumn column = new DataGridViewComboBoxColumn();
            column.Items.AddRange(new string[] { "???" }.Concat(Items.items.Select(i => i.Name)).ToArray());
            column.HeaderText = "New Item";
            column.DisplayMember = "New Item";
            column.ValueMember = "New Item";
            column.DataPropertyName = "New Item";
            column.SortMode = DataGridViewColumnSortMode.NotSortable;
            dataGridView1.Columns.Add(column);

            dataGridView1.Columns.Add(new DataGridViewTextBoxColumn());
            dataGridView1.Columns[3].HeaderText = "Amount";
            dataGridView1.Columns[3].DataPropertyName = "Amount";
            dataGridView1.Columns[3].SortMode = DataGridViewColumnSortMode.NotSortable;

            dataGridView1.DataSource = dataTable;
        }

        private void AddEntry(string treasureID)
        {
            Treasure first = Treasures.treasures.Find(t => t.ID == treasureID);
            if(first!=null)
                dataTable.Rows.Add(treasureID, first.Name, "Unknown", "???", -1);
            else
                dataTable.Rows.Add(treasureID, treasureID, "Unknown", "???", -1);

        }

        public void ReloadData(FormMain main)
        {
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.None;
            dataTable.Clear();

            foreach (Treasure treasure in Treasures.treasures)
            {
                AddEntry(treasure.ID);
            }

            DataStoreWDB<DataStoreTreasure, DataStoreID> treasures = new DataStoreWDB<DataStoreTreasure, DataStoreID>();

            treasures.LoadData(File.ReadAllBytes($"{main.RandoPath}\\original\\db\\resident\\treasurebox.wdb"));

            treasures.IdList.Where(t => !t.ID.StartsWith("!") && Treasures.treasures.Where(tr=>tr.ID == t.ID).Count() == 0).ForEach(t => AddEntry(t.ID));
            foreach (DataRow row in dataTable.Rows)
            {
                Item item = Items.items.Find(i => i.ID == treasures[row.Field<string>(0)].ItemID);
                row.SetField<string>(2, $"{(item == null ? treasures[row.Field<string>(0)].ItemID : item.Name)} x {treasures[row.Field<string>(0)].Count}");
            }
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        private void dataGridView1_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        {
            if (e.ColumnIndex == 3)
            {
                int i = -1;

                if (!int.TryParse(Convert.ToString(e.FormattedValue), out i) || !(i == -1 || i >= 1 && i <= 9999999))
                {
                    e.Cancel = true;
                    MessageBox.Show("Must enter a number from 1-9999999 or -1");
                }
            }
            FormMain.PlandoModified = true;
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (dataGridView1.DataSource != null && comboBox1.SelectedIndex > -1)
            {
                dataGridView1.Visible = true;
                dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.None;
                CurrencyManager currencyManager1 = (CurrencyManager)BindingContext[dataGridView1.DataSource];
                currencyManager1.SuspendBinding();
                TreasureArea area = Enum.GetValues(typeof(TreasureArea)).Cast<TreasureArea>().ToArray()[comboBox1.SelectedIndex];
                for (int row = 0; row < dataGridView1.Rows.Count; row++)
                {
                    Treasure first = Treasures.treasures.Find(t => t.ID == dataTable.Rows[row].Field<string>(0));
                    dataGridView1.Rows[row].Visible = first == null && area == TreasureArea.UnknownOrUnused || first != null && first.Area == area;
                }
                currencyManager1.ResumeBinding();
                dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                dataGridView1.Refresh();
            }
        }

        public Dictionary<Treasure, Tuple<Item, int>> GetTreasures()
        {
            Dictionary<Treasure, Tuple<Item, int>> dict = new Dictionary<Treasure, Tuple<Item, int>>();
            foreach (DataRow row in dataTable.Rows)
            {
                Treasure first = Treasures.treasures.Find(t => t.ID == row.Field<string>(0));
                Item item = Items.items.Find(i => i.Name == row.Field<string>(3) || i.ID == row.Field<string>(3));
                int amount = row.Field<int>(4);
                if(first!=null && item!= null)
                {
                    dict.Add(first, new Tuple<Item, int>(item, amount));
                }
            }
            return dict;
        }

        public class JSONPlandoTreasure
        {
            public string ID { get; set; }
            public string Item { get; set; }
            public int Amount { get; set; }
        }

        public List<JSONPlandoTreasure> GetJSONPlando()
        {
            List<JSONPlandoTreasure> list = new List<JSONPlandoTreasure>();

            foreach (DataRow row in dataTable.Rows)
            {
                list.Add(new JSONPlandoTreasure()
                {
                    ID = row.Field<string>(0),
                    Item = row.Field<string>(3),
                    Amount = row.Field<int>(4)
                });
            }
            return list;
        }

        public void LoadJSONPlando(List<JSONPlandoTreasure> list, string version)
        {
            list = MigrateJSON(list, version);
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.None;
            foreach (DataRow row in dataTable.Rows)
            {
                JSONPlandoTreasure json = list.Find(j => j.ID == row.Field<string>(0));
                row.SetField<string>(3, json.Item);
                row.SetField<int>(4, json.Amount);
            }
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        private List<JSONPlandoTreasure> MigrateJSON(List<JSONPlandoTreasure> list, string version)
        {
            if (version == FormMain.Version)
                return list;
            List<JSONPlandoTreasure> migrated = new List<JSONPlandoTreasure>(list);

            if (VersionOrder.Compare(version, "1.8.0.Pre-3") == -1)
            {
                migrated.Where(j => j.Amount == 0).ForEach(j => j.Amount = -1);
            }

            return migrated;
        }
    }
}
