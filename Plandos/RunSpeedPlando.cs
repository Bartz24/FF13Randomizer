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
    public partial class RunSpeedPlando : UserControl
    {
        public DataTable dataTable = new DataTable();
        public RunSpeedPlando()
        {
            InitializeComponent();
            AddEntries();
        }
        private void AddEntries()
        {
            dataTable.Columns.Add("Name", typeof(string));
            dataTable.Columns.Add("Run Speed", typeof(int));

            dataGridView1.AutoGenerateColumns = false;

            dataGridView1.Columns.Add(new DataGridViewTextBoxColumn());
            dataGridView1.Columns[0].HeaderText = "Name";
            dataGridView1.Columns[0].DataPropertyName = "Name";
            dataGridView1.Columns[0].ReadOnly = true;
            dataGridView1.Columns[0].SortMode = DataGridViewColumnSortMode.NotSortable;

            dataGridView1.Columns.Add(new DataGridViewTextBoxColumn());
            dataGridView1.Columns[1].HeaderText = "Run Speed";
            dataGridView1.Columns[1].DataPropertyName = "Run Speed";
            dataGridView1.Columns[1].SortMode = DataGridViewColumnSortMode.NotSortable;

            dataGridView1.DataSource = dataTable;
        }

        private void AddEntry(Character character, int runSpeed)
        {
            dataTable.Rows.Add($"{character} (Default: {runSpeed})", -1);
        }

        public void ReloadData(FormMain main)
        {
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.None;
            dataTable.Clear();

            DataStoreWDB<DataStoreChara, DataStoreID>  characters = new DataStoreWDB<DataStoreChara, DataStoreID>();
            characters.LoadData(File.ReadAllBytes($"{main.RandoPath}\\original\\db\\resident\\charafamily.wdb"));

            ((Character[])Enum.GetValues(typeof(Character))).ForEach(c => AddEntry(c, characters[RandoRunSpeed.GetID(c)].RunSpeed));
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        private void dataGridView1_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        {
            if (e.ColumnIndex == 1)
            {
                int i = -1;

                if (!int.TryParse(Convert.ToString(e.FormattedValue), out i) || !(i == -1 || i >= 1 && i <= 255))
                {
                    e.Cancel = true;
                    MessageBox.Show("Must enter a number from 1-255 or -1");
                }
            }
            FormMain.PlandoModified = true;
        }

        public Dictionary<Character, int> GetRunSpeeds()
        {
            Dictionary<Character, int> dict = new Dictionary<Character, int>();
            foreach (DataRow row in dataTable.Rows)
            {
                Character character = ((Character[])Enum.GetValues(typeof(Character)))[Enum.GetNames(typeof(Character)).ToList().FindIndex(n => row.Field<string>(0).StartsWith(n))];
                int speed = row.Field<int>(1);
                if(speed > 0)
                {
                    dict.Add(character, speed);
                }
            }
            return dict;
        }

        public class JSONPlandoRunSpeed
        {
            public string Name { get; set; }
            public int Speed { get; set; }
        }

        public List<JSONPlandoRunSpeed> GetJSONPlando()
        {
            List<JSONPlandoRunSpeed> list = new List<JSONPlandoRunSpeed>();

            foreach (DataRow row in dataTable.Rows)
            {
                list.Add(new JSONPlandoRunSpeed()
                {
                    Name = row.Field<string>(0),
                    Speed = row.Field<int>(1)
                });
            }
            return list;
        }

        public void LoadJSONPlando(List<JSONPlandoRunSpeed> list, string version)
        {
            list = MigrateJSON(list, version);
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.None;
            foreach (DataRow row in dataTable.Rows)
            {
                JSONPlandoRunSpeed json = list.Find(j => j.Name == row.Field<string>(0));
                row.SetField<int>(1, json.Speed);
            }
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        private List<JSONPlandoRunSpeed> MigrateJSON(List<JSONPlandoRunSpeed> list, string version)
        {
            if (version == FormMain.Version)
                return list;
            List<JSONPlandoRunSpeed> migrated = new List<JSONPlandoRunSpeed>(list);

            return migrated;
        }
    }
}
