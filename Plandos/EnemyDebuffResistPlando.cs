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
    public partial class EnemyDebuffResistPlando : UserControl
    {
        public DataTable dataTable = new DataTable();
        public EnemyDebuffResistPlando()
        {
            InitializeComponent();
            AddEntries();
        }
        private void AddEntries()
        {
            dataTable.Columns.Add("id", typeof(string));
            dataTable.Columns.Add("Name", typeof(string));

            ((Debuff[])Enum.GetValues(typeof(Debuff))).ForEach(e =>
            {
                dataTable.Columns.Add($"{e}", typeof(string));
                dataTable.Columns.Add($"New {e}", typeof(int));
            });

            dataGridView1.AutoGenerateColumns = false;

            dataGridView1.Columns.Add(new DataGridViewTextBoxColumn());
            dataGridView1.Columns[0].HeaderText = "Name";
            dataGridView1.Columns[0].DataPropertyName = "Name";
            dataGridView1.Columns[0].ReadOnly = true;
            dataGridView1.Columns[0].SortMode = DataGridViewColumnSortMode.NotSortable;

            ((Debuff[])Enum.GetValues(typeof(Debuff))).ForEach(e =>
            {
                dataGridView1.Columns.Add(new DataGridViewTextBoxColumn());
                dataGridView1.Columns[dataGridView1.Columns.Count - 1].HeaderText = $"{e}";
                dataGridView1.Columns[dataGridView1.Columns.Count - 1].DataPropertyName = $"{e}";
                dataGridView1.Columns[dataGridView1.Columns.Count - 1].ReadOnly = true;
                dataGridView1.Columns[dataGridView1.Columns.Count - 1].SortMode = DataGridViewColumnSortMode.NotSortable;

                dataGridView1.Columns.Add(new DataGridViewTextBoxColumn());
                dataGridView1.Columns[dataGridView1.Columns.Count - 1].HeaderText = $"New {e}";
                dataGridView1.Columns[dataGridView1.Columns.Count - 1].DataPropertyName = $"New {e}";
                dataGridView1.Columns[dataGridView1.Columns.Count - 1].SortMode = DataGridViewColumnSortMode.NotSortable;
            });

            dataGridView1.DataSource = dataTable;            

        }

        private void AddEntry(Enemy e)
        {
            dataTable.Rows.Add(e.ID, e.Name, "Unknown", -1, "Unknown", -1, "Unknown", -1, "Unknown", -1, "Unknown", -1, "Unknown", -1, "Unknown", -1, "Unknown", -1, "Unknown", -1, "Unknown", -1, "Unknown", -1);
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
                int i = 2;
                ((Debuff[])Enum.GetValues(typeof(Debuff))).ForEach(d => { row.SetField<string>(i, enemy[d].ToString()); i += 2; });
            }
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
        }

        private void dataGridView1_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        {
            if (e.ColumnIndex >= 2 && e.ColumnIndex % 2 == 0)
            {
                int i = -1;

                if (!int.TryParse(Convert.ToString(e.FormattedValue), out i) || !(i == -1 || i >= 0 && i <= 100))
                {
                    e.Cancel = true;
                    MessageBox.Show("Must enter a number from 0-100 or -1");
                }
            }
            FormMain.PlandoModified = true;
        }

        public Dictionary<Enemy, Dictionary<Debuff, int>> GetDebuffResists()
        {
            Dictionary<Enemy, Dictionary<Debuff, int>> dict = new Dictionary<Enemy, Dictionary<Debuff, int>>();
            foreach (DataRow row in dataTable.Rows)
            {
                Enemy enemy = Enemies.enemies.Find(e => e.ID == row.Field<string>(0));
                Dictionary<Debuff, int> vals = new Dictionary<Debuff, int>();
                for (int i = 0; i < 8; i++)
                {
                    int res = row.Field<int>(3 + 2 * i);
                    if (res > -1)
                        vals.Add((Debuff)i, res);
                }
                if (vals.Count > 0)
                {
                    dict.Add(enemy, vals);
                }
            }
            return dict;
        }

        public class JSONPlandoEnemyDebuffResists
        {
            public string ID { get; set; }
            public int Deprotect { get; set; }
            public int Deshell { get; set; }
            public int Poison { get; set; }
            public int Imperil { get; set; }
            public int Slow { get; set; }
            public int Fog { get; set; }
            public int Pain { get; set; }
            public int Curse { get; set; }
            public int Daze { get; set; }
            public int Death { get; set; }
            public int Dispel { get; set; }
        }

        public List<JSONPlandoEnemyDebuffResists> GetJSONPlando()
        {
            List<JSONPlandoEnemyDebuffResists> list = new List<JSONPlandoEnemyDebuffResists>();

            foreach (DataRow row in dataTable.Rows)
            {
                list.Add(new JSONPlandoEnemyDebuffResists()
                {
                    ID = row.Field<string>(0),
                    Deprotect = row.Field<int>(3 + 2 * (int)Debuff.Deprotect),
                    Deshell = row.Field<int>(3 + 2 * (int)Debuff.Deshell),
                    Poison = row.Field<int>(3 + 2 * (int)Debuff.Poison),
                    Imperil = row.Field<int>(3 + 2 * (int)Debuff.Imperil),
                    Slow = row.Field<int>(3 + 2 * (int)Debuff.Slow),
                    Fog = row.Field<int>(3 + 2 * (int)Debuff.Fog),
                    Pain = row.Field<int>(3 + 2 * (int)Debuff.Pain),
                    Curse = row.Field<int>(3 + 2 * (int)Debuff.Curse),
                    Daze = row.Field<int>(3 + 2 * (int)Debuff.Daze),
                    Death = row.Field<int>(3 + 2 * (int)Debuff.Death),
                    Dispel = row.Field<int>(3 + 2 * (int)Debuff.Dispel)
                });
            }
            return list;
        }

        public void LoadJSONPlando(List<JSONPlandoEnemyDebuffResists> list, string version)
        {
            list = MigrateJSON(list, version);
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.None;
            foreach (DataRow row in dataTable.Rows)
            {
                JSONPlandoEnemyDebuffResists json = list.Find(j => j.ID == row.Field<string>(0));
                row.SetField<int>(3 + 2 * (int)Debuff.Deprotect, json.Deprotect);
                row.SetField<int>(3 + 2 * (int)Debuff.Deshell, json.Deshell);
                row.SetField<int>(3 + 2 * (int)Debuff.Poison, json.Poison);
                row.SetField<int>(3 + 2 * (int)Debuff.Imperil, json.Imperil);
                row.SetField<int>(3 + 2 * (int)Debuff.Slow, json.Slow);
                row.SetField<int>(3 + 2 * (int)Debuff.Fog, json.Fog);
                row.SetField<int>(3 + 2 * (int)Debuff.Pain, json.Pain);
                row.SetField<int>(3 + 2 * (int)Debuff.Curse, json.Curse);
                row.SetField<int>(3 + 2 * (int)Debuff.Daze, json.Daze);
                row.SetField<int>(3 + 2 * (int)Debuff.Death, json.Death);
                row.SetField<int>(3 + 2 * (int)Debuff.Dispel, json.Dispel);
            }
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
        }

        private List<JSONPlandoEnemyDebuffResists> MigrateJSON(List<JSONPlandoEnemyDebuffResists> list, string version)
        {
            if (version == FormMain.Version)
                return list;
            List<JSONPlandoEnemyDebuffResists> migrated = new List<JSONPlandoEnemyDebuffResists>(list);

            return migrated;
        }
    }
}
