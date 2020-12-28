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
    public partial class EnemyElementResistPlando : UserControl
    {
        public DataTable dataTable = new DataTable();
        public EnemyElementResistPlando()
        {
            InitializeComponent();
            AddEntries();
        }
        private void AddEntries()
        {
            dataTable.Columns.Add("id", typeof(string));
            dataTable.Columns.Add("Name", typeof(string));

            ((Element[])Enum.GetValues(typeof(Element))).ForEach(e =>
            {
                dataTable.Columns.Add($"{e}", typeof(string));
                dataTable.Columns.Add($"New {e}", typeof(string));
            });

            dataGridView1.AutoGenerateColumns = false;

            dataGridView1.Columns.Add(new DataGridViewTextBoxColumn());
            dataGridView1.Columns[0].HeaderText = "Name";
            dataGridView1.Columns[0].DataPropertyName = "Name";
            dataGridView1.Columns[0].ReadOnly = true;
            dataGridView1.Columns[0].SortMode = DataGridViewColumnSortMode.NotSortable;

            ((Element[])Enum.GetValues(typeof(Element))).ForEach(e =>
            {
                dataGridView1.Columns.Add(new DataGridViewTextBoxColumn());
                dataGridView1.Columns[dataGridView1.Columns.Count-1].HeaderText = $"{e}";
                dataGridView1.Columns[dataGridView1.Columns.Count - 1].DataPropertyName = $"{e}";
                dataGridView1.Columns[dataGridView1.Columns.Count - 1].ReadOnly = true;
                dataGridView1.Columns[dataGridView1.Columns.Count - 1].SortMode = DataGridViewColumnSortMode.NotSortable;

                string[] items = new string[] { "???" }.Concat(Enum.GetNames(typeof(ElementalRes)).Where(res => (e == Element.Physical || e == Element.Magical ? (res != ElementalRes.Absorb.ToString()) : true)).ToArray());

                DataGridViewComboBoxColumn column = new DataGridViewComboBoxColumn();
                column.Items.AddRange(items);
                column.HeaderText = $"New {e}";
                column.DisplayMember = $"New {e}";
                column.ValueMember = $"New {e}";
                column.DataPropertyName = $"New {e}";
                column.SortMode = DataGridViewColumnSortMode.NotSortable;
                dataGridView1.Columns.Add(column);
            });

            dataGridView1.DataSource = dataTable;            

        }

        private void AddEntry(Enemy e)
        {
            dataTable.Rows.Add(e.ID, e.Name, "Unknown", "???", "Unknown", "???", "Unknown", "???", "Unknown", "???", "Unknown", "???", "Unknown", "???", "Unknown", "???", "Unknown", "???");
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
                ((Element[])Enum.GetValues(typeof(Element))).ForEach(e => { row.SetField<string>(i, enemy[e].ToString()); i += 2; });
            }
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
        }

        private void dataGridView1_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        {
            FormMain.PlandoModified = true;
        }

        public Dictionary<Enemy, Dictionary<Element, ElementalRes>> GetElementResists()
        {
            Dictionary<Enemy, Dictionary<Element, ElementalRes>> dict = new Dictionary<Enemy, Dictionary<Element, ElementalRes>>();
            foreach (DataRow row in dataTable.Rows)
            {
                Enemy enemy = Enemies.enemies.Find(e => e.ID == row.Field<string>(0));
                Dictionary<Element, ElementalRes> vals = new Dictionary<Element, ElementalRes>();
                for (int i = 0; i < 8; i++)
                {
                    string res = row.Field<string>(3 + 2 * i);
                    if (res != "???")
                        vals.Add((Element)i, Extensions.GetEnumValue<ElementalRes>(res));
                }
                if (vals.Count > 0)
                {
                    dict.Add(enemy, vals);
                }
            }
            return dict;
        }

        public class JSONPlandoEnemyElementResists
        {
            public string ID { get; set; }
            public string Fire { get; set; }
            public string Ice { get; set; }
            public string Thunder { get; set; }
            public string Water { get; set; }
            public string Wind { get; set; }
            public string Earth { get; set; }
            public string Physical { get; set; }
            public string Magical { get; set; }
        }

        public List<JSONPlandoEnemyElementResists> GetJSONPlando()
        {
            List<JSONPlandoEnemyElementResists> list = new List<JSONPlandoEnemyElementResists>();

            foreach (DataRow row in dataTable.Rows)
            {
                list.Add(new JSONPlandoEnemyElementResists()
                {
                    ID = row.Field<string>(0),
                    Fire = row.Field<string>(3 + 2 * (int)Element.Fire),
                    Ice = row.Field<string>(3 + 2 * (int)Element.Ice),
                    Thunder = row.Field<string>(3 + 2 * (int)Element.Thunder),
                    Water = row.Field<string>(3 + 2 * (int)Element.Water),
                    Wind = row.Field<string>(3 + 2 * (int)Element.Wind),
                    Earth = row.Field<string>(3 + 2 * (int)Element.Earth),
                    Physical = row.Field<string>(3 + 2 * (int)Element.Physical),
                    Magical = row.Field<string>(3 + 2 * (int)Element.Magical)
                });
            }
            return list;
        }

        public void LoadJSONPlando(List<JSONPlandoEnemyElementResists> list, string version)
        {
            list = MigrateJSON(list, version);
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.None;
            foreach (DataRow row in dataTable.Rows)
            {
                JSONPlandoEnemyElementResists json = list.Find(j => j.ID == row.Field<string>(0));
                row.SetField<string>(3 + 2 * (int)Element.Fire, json.Fire);
                row.SetField<string>(3 + 2 * (int)Element.Ice, json.Ice);
                row.SetField<string>(3 + 2 * (int)Element.Thunder, json.Thunder);
                row.SetField<string>(3 + 2 * (int)Element.Water, json.Water);
                row.SetField<string>(3 + 2 * (int)Element.Wind, json.Wind);
                row.SetField<string>(3 + 2 * (int)Element.Earth, json.Earth);
                row.SetField<string>(3 + 2 * (int)Element.Physical, json.Physical);
                row.SetField<string>(3 + 2 * (int)Element.Magical, json.Magical);
            }
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
        }

        private List<JSONPlandoEnemyElementResists> MigrateJSON(List<JSONPlandoEnemyElementResists> list, string version)
        {
            if (version == FormMain.Version)
                return list;
            List<JSONPlandoEnemyElementResists> migrated = new List<JSONPlandoEnemyElementResists>(list);

            return migrated;
        }
    }
}
