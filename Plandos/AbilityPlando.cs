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
    public partial class AbilityPlando : UserControl
    {
        public DataTable dataTable = new DataTable();
        public AbilityPlando()
        {
            InitializeComponent();
            AddEntries();
        }
        private void AddEntries()
        {
            dataTable.Columns.Add("Name", typeof(string));
            dataTable.Columns.Add("ATB/TP Cost", typeof(int));

            dataGridView1.AutoGenerateColumns = false;

            dataGridView1.Columns.Add(new DataGridViewTextBoxColumn());
            dataGridView1.Columns[0].HeaderText = "Name";
            dataGridView1.Columns[0].DataPropertyName = "Name";
            dataGridView1.Columns[0].ReadOnly = true;
            dataGridView1.Columns[0].SortMode = DataGridViewColumnSortMode.NotSortable;

            dataGridView1.Columns.Add(new DataGridViewTextBoxColumn());
            dataGridView1.Columns[1].HeaderText = "ATB/TP Cost (Full ATB = 6)";
            dataGridView1.Columns[1].DataPropertyName = "ATB/TP Cost";
            dataGridView1.Columns[1].SortMode = DataGridViewColumnSortMode.NotSortable;

            dataGridView1.DataSource = dataTable;
        }

        private void AddEntry(Ability ability)
        {
            dataTable.Rows.Add(ability.Name, -1);
        }

        public void ReloadData(FormMain main)
        {
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.None;
            dataTable.Clear();

            DataStoreWDB<DataStoreAbility, DataStoreID> abilities = new DataStoreWDB<DataStoreAbility, DataStoreID>();

            abilities.LoadData(File.ReadAllBytes($"{main.RandoPath}\\original\\db\\resident\\bt_ability.wdb"));

            Abilities.abilities.Where(aID => abilities.IdList.IndexOf(aID.GetIDs()[0]) > -1).ForEach(a => AddEntry(a));
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        private void dataGridView1_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        {
            if (e.ColumnIndex == 1)
            {
                int i = -1;

                if (!int.TryParse(Convert.ToString(e.FormattedValue), out i) || !(i == -1 || i >= 1 && i <= 6))
                {
                    e.Cancel = true;
                    MessageBox.Show("Must enter a number from 1-6 or -1");
                }
            }
            FormMain.PlandoModified = true;
        }

        public Dictionary<Ability, int> GetAbilities()
        {
            Dictionary<Ability, int> dict = new Dictionary<Ability, int>();
            foreach (DataRow row in dataTable.Rows)
            {
                Ability ability = Abilities.abilities.Find(a => a.Name == row.Field<string>(0));
                int cost = row.Field<int>(1);
                if(cost > 0)
                {
                    dict.Add(ability, cost);
                }
            }
            return dict;
        }

        public class JSONPlandoAbility
        {
            public string Name { get; set; }
            public int Cost { get; set; }
        }

        public List<JSONPlandoAbility> GetJSONPlando()
        {
            List<JSONPlandoAbility> list = new List<JSONPlandoAbility>();

            foreach (DataRow row in dataTable.Rows)
            {
                list.Add(new JSONPlandoAbility()
                {
                    Name = row.Field<string>(0),
                    Cost = row.Field<int>(1)
                });
            }
            return list;
        }

        public void LoadJSONPlando(List<JSONPlandoAbility> list, string version)
        {
            list = MigrateJSON(list, version);
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.None;
            foreach (DataRow row in dataTable.Rows)
            {
                JSONPlandoAbility json = list.Find(j => j.Name == row.Field<string>(0));
                row.SetField<int>(1, json.Cost);
            }
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        private List<JSONPlandoAbility> MigrateJSON(List<JSONPlandoAbility> list, string version)
        {
            if (version == FormMain.Version)
                return list;
            List<JSONPlandoAbility> migrated = new List<JSONPlandoAbility>(list);

            if(VersionOrder.Compare(version, "1.8.0.Pre-3") == -1)
            {
                migrated.Where(j => j.Cost == 0).ForEach(j => j.Cost = -1);
            }

            return migrated;
        }
    }
}
