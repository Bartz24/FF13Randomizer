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
    public partial class EnemyStatsPlando : UserControl
    {
        public DataTable dataTable = new DataTable();
        public EnemyStatsPlando()
        {
            InitializeComponent();
            AddEntries();
        }
        private void AddEntries()
        {
            dataTable.Columns.Add("id", typeof(string));
            dataTable.Columns.Add("Name", typeof(string));
            dataTable.Columns.Add("Level", typeof(string));
            dataTable.Columns.Add("New Level", typeof(int));
            dataTable.Columns.Add("HP", typeof(string));
            dataTable.Columns.Add("New HP", typeof(int));
            dataTable.Columns.Add("Strength", typeof(string));
            dataTable.Columns.Add("New Strength", typeof(int));
            dataTable.Columns.Add("Magic", typeof(string));
            dataTable.Columns.Add("New Magic", typeof(int));
            dataTable.Columns.Add("Chain Resistance", typeof(string));
            dataTable.Columns.Add("New Chain Resistance", typeof(int));
            dataTable.Columns.Add("Stagger Point", typeof(string));
            dataTable.Columns.Add("New Stagger Point", typeof(int));
            dataTable.Columns.Add("CP", typeof(string));
            dataTable.Columns.Add("New CP", typeof(int));

            dataGridView1.AutoGenerateColumns = false;

            dataGridView1.Columns.Add(new DataGridViewTextBoxColumn());
            dataGridView1.Columns[0].HeaderText = "Name";
            dataGridView1.Columns[0].DataPropertyName = "Name";
            dataGridView1.Columns[0].ReadOnly = true;
            dataGridView1.Columns[0].SortMode = DataGridViewColumnSortMode.NotSortable;

            dataGridView1.Columns.Add(new DataGridViewTextBoxColumn());
            dataGridView1.Columns[1].HeaderText = "Level";
            dataGridView1.Columns[1].DataPropertyName = "Level";
            dataGridView1.Columns[1].ReadOnly = true;
            dataGridView1.Columns[1].SortMode = DataGridViewColumnSortMode.NotSortable;

            dataGridView1.Columns.Add(new DataGridViewTextBoxColumn());
            dataGridView1.Columns[2].HeaderText = "New Level";
            dataGridView1.Columns[2].DataPropertyName = "New Level";
            dataGridView1.Columns[2].SortMode = DataGridViewColumnSortMode.NotSortable;

            dataGridView1.Columns.Add(new DataGridViewTextBoxColumn());
            dataGridView1.Columns[3].HeaderText = "HP";
            dataGridView1.Columns[3].DataPropertyName = "HP";
            dataGridView1.Columns[3].ReadOnly = true;
            dataGridView1.Columns[3].SortMode = DataGridViewColumnSortMode.NotSortable;

            dataGridView1.Columns.Add(new DataGridViewTextBoxColumn());
            dataGridView1.Columns[4].HeaderText = "New HP";
            dataGridView1.Columns[4].DataPropertyName = "New HP";
            dataGridView1.Columns[4].SortMode = DataGridViewColumnSortMode.NotSortable;

            dataGridView1.Columns.Add(new DataGridViewTextBoxColumn());
            dataGridView1.Columns[5].HeaderText = "Strength";
            dataGridView1.Columns[5].DataPropertyName = "Strength";
            dataGridView1.Columns[5].ReadOnly = true;
            dataGridView1.Columns[5].SortMode = DataGridViewColumnSortMode.NotSortable;

            dataGridView1.Columns.Add(new DataGridViewTextBoxColumn());
            dataGridView1.Columns[6].HeaderText = "New Strength";
            dataGridView1.Columns[6].DataPropertyName = "New Strength";
            dataGridView1.Columns[6].SortMode = DataGridViewColumnSortMode.NotSortable;

            dataGridView1.Columns.Add(new DataGridViewTextBoxColumn());
            dataGridView1.Columns[7].HeaderText = "Magic";
            dataGridView1.Columns[7].DataPropertyName = "Magic";
            dataGridView1.Columns[7].ReadOnly = true;
            dataGridView1.Columns[7].SortMode = DataGridViewColumnSortMode.NotSortable;

            dataGridView1.Columns.Add(new DataGridViewTextBoxColumn());
            dataGridView1.Columns[8].HeaderText = "New Magic";
            dataGridView1.Columns[8].DataPropertyName = "New Magic";
            dataGridView1.Columns[8].SortMode = DataGridViewColumnSortMode.NotSortable;

            dataGridView1.Columns.Add(new DataGridViewTextBoxColumn());
            dataGridView1.Columns[9].HeaderText = "Chain Resistance";
            dataGridView1.Columns[9].DataPropertyName = "Chain Resistance";
            dataGridView1.Columns[9].ReadOnly = true;
            dataGridView1.Columns[9].SortMode = DataGridViewColumnSortMode.NotSortable;

            dataGridView1.Columns.Add(new DataGridViewTextBoxColumn());
            dataGridView1.Columns[10].HeaderText = "New Chain Resistance";
            dataGridView1.Columns[10].DataPropertyName = "New Chain Resistance";
            dataGridView1.Columns[10].SortMode = DataGridViewColumnSortMode.NotSortable;

            dataGridView1.Columns.Add(new DataGridViewTextBoxColumn());
            dataGridView1.Columns[11].HeaderText = "Stagger Point";
            dataGridView1.Columns[11].DataPropertyName = "Stagger Point";
            dataGridView1.Columns[11].ReadOnly = true;
            dataGridView1.Columns[11].SortMode = DataGridViewColumnSortMode.NotSortable;

            dataGridView1.Columns.Add(new DataGridViewTextBoxColumn());
            dataGridView1.Columns[12].HeaderText = "New Stagger Point";
            dataGridView1.Columns[12].DataPropertyName = "New Stagger Point";
            dataGridView1.Columns[12].SortMode = DataGridViewColumnSortMode.NotSortable;

            dataGridView1.Columns.Add(new DataGridViewTextBoxColumn());
            dataGridView1.Columns[13].HeaderText = "CP";
            dataGridView1.Columns[13].DataPropertyName = "CP";
            dataGridView1.Columns[13].ReadOnly = true;
            dataGridView1.Columns[13].SortMode = DataGridViewColumnSortMode.NotSortable;

            dataGridView1.Columns.Add(new DataGridViewTextBoxColumn());
            dataGridView1.Columns[14].HeaderText = "New CP";
            dataGridView1.Columns[14].DataPropertyName = "New CP";
            dataGridView1.Columns[14].SortMode = DataGridViewColumnSortMode.NotSortable;

            dataGridView1.DataSource = dataTable;
        }

        private void AddEntry(Enemy e)
        {
            dataTable.Rows.Add(e.ID, e.Name, "Unknown", -1, "Unknown", -1, "Unknown", -1, "Unknown", -1, "Unknown", -1, "Unknown", -1, "Unknown", -1);
        }

        public void ReloadData(FormMain main)
        {
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.None;
            dataTable.Clear();

            foreach (Enemy e in Enemies.enemies.OrderBy(e => e.Name))
            {
                AddEntry(e);
            }

            DataStoreWDB<DataStoreEnemy, DataStoreID> enemies = new DataStoreWDB<DataStoreEnemy, DataStoreID>();

            enemies.LoadData(File.ReadAllBytes($"{main.RandoPath}\\original\\db\\resident\\bt_chara_spec.wdb"));

            foreach (DataRow row in dataTable.Rows)
            {
                DataStoreEnemy enemy = enemies[row.Field<string>(0)];
                row.SetField<string>(2, enemy.Level.ToString());
                row.SetField<string>(4, enemy.HP.ToString());
                row.SetField<string>(6, enemy.Strength.ToString());
                row.SetField<string>(8, enemy.Magic.ToString());
                row.SetField<string>(10, enemy.ChainRes.ToString());
                row.SetField<string>(12, enemy.StaggerPoint.ToString());
                row.SetField<string>(14, enemy.CP.ToString());
            }
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
        }

        private void dataGridView1_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        {
            if (e.ColumnIndex == 2)
            {
                int min, max;
                if (int.Parse(dataTable.Rows[e.RowIndex].Field<string>(2)) < 50)
                {
                    min = 1;
                    max = 49;
                }
                else
                {
                    min = 51;
                    max = 99;
                }

                int i = -1;
                if (!int.TryParse(Convert.ToString(e.FormattedValue), out i) || !(i == -1 || i >= min && i <= max))
                {
                    e.Cancel = true;
                    MessageBox.Show($"Must enter a number from {min}-{max} or -1");
                }
            }
            if (e.ColumnIndex == 4)
            {
                int i = -1;

                if (!int.TryParse(Convert.ToString(e.FormattedValue), out i) || !(i == -1 || i >= 1 && i <= 999999999))
                {
                    e.Cancel = true;
                    MessageBox.Show("Must enter a number from 1-999999999 or -1");
                }
            }
            if (e.ColumnIndex == 6 || e.ColumnIndex == 8)
            {
                int i = -1;

                if (!int.TryParse(Convert.ToString(e.FormattedValue), out i) || !(i == -1 || i >= 0 && i <= 65535))
                {
                    e.Cancel = true;
                    MessageBox.Show("Must enter a number from 0-65535 or -1");
                }
            }
            if (e.ColumnIndex == 10)
            {
                int i = -1;

                if (!int.TryParse(Convert.ToString(e.FormattedValue), out i) || !(i == -1 || i >= 0 && i <= 100))
                {
                    e.Cancel = true;
                    MessageBox.Show("Must enter a number from 0-100 or -1");
                }
            }
            if (e.ColumnIndex == 12)
            {
                int i = -1;

                if (!int.TryParse(Convert.ToString(e.FormattedValue), out i) || !(i == -1 || i >= 101 && i <= 1000))
                {
                    e.Cancel = true;
                    MessageBox.Show("Must enter a number from 101-1000 or -1");
                }
            }
            if (e.ColumnIndex == 14)
            {
                int i = -1;

                if (!int.TryParse(Convert.ToString(e.FormattedValue), out i) || !(i == -1 || i >= 0 && i <= 999999))
                {
                    e.Cancel = true;
                    MessageBox.Show("Must enter a number from 0-999999 or -1");
                }
            }
            FormMain.PlandoModified = true;
        }

        public Dictionary<Enemy, int[]> GetStats()
        {
            Dictionary<Enemy, int[]> dict = new Dictionary<Enemy, int[]>();
            foreach (DataRow row in dataTable.Rows)
            {
                Enemy enemy = Enemies.enemies.Find(e => e.ID == row.Field<string>(0));
                int[] vals = new int[7];
                for(int i = 0; i < 7; i++)
                {
                    vals[i] = row.Field<int>(3 + 2 * i);
                }
                if (vals.Where(v => v != -1).Count() > 0)
                {
                    dict.Add(enemy, vals);
                }
            }
            return dict;
        }

        public class JSONPlandoEnemyStats
        {
            public string ID { get; set; }
            public int Level { get; set; }
            public int HP { get; set; }
            public int Strength { get; set; }
            public int Magic { get; set; }
            public int ChainRes { get; set; }
            public int Stagger { get; set; }
            public int CP { get; set; }
        }

        public List<JSONPlandoEnemyStats> GetJSONPlando()
        {
            List<JSONPlandoEnemyStats> list = new List<JSONPlandoEnemyStats>();

            foreach (DataRow row in dataTable.Rows)
            {
                list.Add(new JSONPlandoEnemyStats()
                {
                    ID = row.Field<string>(0),
                    Level = row.Field<int>(3),
                    HP = row.Field<int>(5),
                    Strength = row.Field<int>(7),
                    Magic = row.Field<int>(9),
                    ChainRes = row.Field<int>(11),
                    Stagger = row.Field<int>(13),
                    CP = row.Field<int>(15)
                });
            }
            return list;
        }

        public void LoadJSONPlando(List<JSONPlandoEnemyStats> list, string version)
        {
            list = MigrateJSON(list, version);
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.None;
            foreach (DataRow row in dataTable.Rows)
            {
                JSONPlandoEnemyStats json = list.Find(j => j.ID == row.Field<string>(0));
                row.SetField<int>(3, json.Level);
                row.SetField<int>(5, json.HP);
                row.SetField<int>(7, json.Strength);
                row.SetField<int>(9, json.Magic);
                row.SetField<int>(11, json.ChainRes);
                row.SetField<int>(13, json.Stagger);
                row.SetField<int>(15, json.CP);
            }
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
        }

        private List<JSONPlandoEnemyStats> MigrateJSON(List<JSONPlandoEnemyStats> list, string version)
        {
            if (version == FormMain.Version)
                return list;
            List<JSONPlandoEnemyStats> migrated = new List<JSONPlandoEnemyStats>(list);

            return migrated;
        }
    }
}
