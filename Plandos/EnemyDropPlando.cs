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
    public partial class EnemyDropPlando : UserControl
    {
        public DataTable dataTable = new DataTable();
        public EnemyDropPlando()
        {
            InitializeComponent();
            AddEntries();
        }
        private void AddEntries()
        {
            dataTable.Columns.Add("id", typeof(string));
            dataTable.Columns.Add("Name", typeof(string));
            dataTable.Columns.Add("Original Common Item", typeof(string));
            dataTable.Columns.Add("New Common Item", typeof(string));
            dataTable.Columns.Add("Original Rare Item", typeof(string));
            dataTable.Columns.Add("New Rare Item", typeof(string));

            dataGridView1.AutoGenerateColumns = false;

            dataGridView1.Columns.Add(new DataGridViewTextBoxColumn());
            dataGridView1.Columns[0].HeaderText = "Name";
            dataGridView1.Columns[0].DataPropertyName = "Name";
            dataGridView1.Columns[0].ReadOnly = true;
            dataGridView1.Columns[0].SortMode = DataGridViewColumnSortMode.NotSortable;

            dataGridView1.Columns.Add(new DataGridViewTextBoxColumn());
            dataGridView1.Columns[1].HeaderText = "Original Common Item";
            dataGridView1.Columns[1].DataPropertyName = "Original Common Item";
            dataGridView1.Columns[1].ReadOnly = true;
            dataGridView1.Columns[1].SortMode = DataGridViewColumnSortMode.NotSortable;

            string[] items = new string[] { "???" }.Concat(Items.items.Select(i => i.Name).ToList().Replace(Items.Gil.Name, "None")).ToArray();

            DataGridViewComboBoxColumn column = new DataGridViewComboBoxColumn();
            column.Items.AddRange(items);
            column.HeaderText = "New Common Item";
            column.DisplayMember = "New Common Item";
            column.ValueMember = "New Common Item";
            column.DataPropertyName = "New Common Item";
            column.SortMode = DataGridViewColumnSortMode.NotSortable;
            dataGridView1.Columns.Add(column);

            dataGridView1.Columns.Add(new DataGridViewTextBoxColumn());
            dataGridView1.Columns[3].HeaderText = "Original Rare Item";
            dataGridView1.Columns[3].DataPropertyName = "Original Rare Item";
            dataGridView1.Columns[3].ReadOnly = true;
            dataGridView1.Columns[3].SortMode = DataGridViewColumnSortMode.NotSortable;

            DataGridViewComboBoxColumn column2 = new DataGridViewComboBoxColumn();
            column2.Items.AddRange(items);
            column2.HeaderText = "New Rare Item";
            column2.DisplayMember = "New Rare Item";
            column2.ValueMember = "New Rare Item";
            column2.DataPropertyName = "New Rare Item";
            column2.SortMode = DataGridViewColumnSortMode.NotSortable;
            dataGridView1.Columns.Add(column2);

            dataGridView1.DataSource = dataTable;
        }

        private void AddEntry(Enemy e)
        {
            dataTable.Rows.Add(e.ID, e.Name, "Unknown", "???", "Unknown", "???");
        }

        public void ReloadData(FormMain main)
        {
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.None;
            dataTable.Clear();

            foreach (Enemy e in Enemies.enemies.Where(e => e.ParentData == null).OrderBy(e => e.Name))
            {
                AddEntry(e);
            }

            DataStoreWDB<DataStoreEnemy, DataStoreID> enemies = new DataStoreWDB<DataStoreEnemy, DataStoreID>();

            enemies.LoadData(File.ReadAllBytes($"{main.RandoPath}\\original\\db\\resident\\bt_chara_spec.wdb"));

            foreach (DataRow row in dataTable.Rows)
            {
                Item common = Items.items.Find(i => i.ID == enemies[row.Field<string>(0)].CommonDropID);
                string name;
                if (common == null)
                    name = enemies[row.Field<string>(0)].CommonDropID;
                else if (common == Items.Gil)
                    name = "None";
                else
                    name = common.Name;
                row.SetField<string>(2, name);

                Item rare = Items.items.Find(i => i.ID == enemies[row.Field<string>(0)].RareDropID);
                if (rare == null)
                    name = enemies[row.Field<string>(0)].RareDropID;
                else if (rare == Items.Gil)
                    name = "None";
                else
                    name = rare.Name;
                row.SetField<string>(4, name);
            }
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        private void dataGridView1_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        {
            FormMain.PlandoModified = true;
        }

        public Dictionary<Enemy, Tuple<Item, Item>> GetDrops()
        {
            Dictionary<Enemy, Tuple<Item, Item>> dict = new Dictionary<Enemy, Tuple<Item, Item>>();
            foreach (DataRow row in dataTable.Rows)
            {
                Enemy enemy = Enemies.enemies.Find(e => e.ID == row.Field<string>(0));
                Item common = Items.items.Find(i => i.Name == row.Field<string>(3) || i.ID == row.Field<string>(3));
                if (row.Field<string>(3) == "None")
                    common = Items.Gil;
                Item rare = Items.items.Find(i => i.Name == row.Field<string>(5) || i.ID == row.Field<string>(5));
                if (row.Field<string>(5) == "None")
                    rare = Items.Gil;
                if (!(common == null && rare == null))
                {
                    dict.Add(enemy, new Tuple<Item, Item>(common, rare));
                }
            }
            return dict;
        }

        public class JSONPlandoEnemyDrops
        {
            public string ID { get; set; }
            public string Common { get; set; }
            public string Rare { get; set; }
        }

        public List<JSONPlandoEnemyDrops> GetJSONPlando()
        {
            List<JSONPlandoEnemyDrops> list = new List<JSONPlandoEnemyDrops>();

            foreach (DataRow row in dataTable.Rows)
            {
                list.Add(new JSONPlandoEnemyDrops()
                {
                    ID = row.Field<string>(0),
                    Common = row.Field<string>(3),
                    Rare = row.Field<string>(5)
                });
            }
            return list;
        }

        public void LoadJSONPlando(List<JSONPlandoEnemyDrops> list, string version)
        {
            list = MigrateJSON(list, version);
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.None;
            foreach (DataRow row in dataTable.Rows)
            {
                JSONPlandoEnemyDrops json = list.Find(j => j.ID == row.Field<string>(0));
                row.SetField<string>(3, json.Common);
                row.SetField<string>(5, json.Rare);
            }
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        private List<JSONPlandoEnemyDrops> MigrateJSON(List<JSONPlandoEnemyDrops> list, string version)
        {
            if (version == FormMain.Version)
                return list;
            List<JSONPlandoEnemyDrops> migrated = new List<JSONPlandoEnemyDrops>(list);

            return migrated;
        }
    }
}
