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
    public partial class CrystariumPlando : UserControl
    {
        private bool loaded = false;
        public DataTable dataTable = new DataTable();
        public CrystariumPlando()
        {
            InitializeComponent();
            SetupCombobox();
            AddEntries();
        }

        private void SetupCombobox()
        {
            comboBox1.Items.AddRange(RandoCrystarium.CharNames.Select(s => char.ToUpper(s[0]) + s.Substring(1)).ToArray());
            comboBox2.Items.AddRange(Enum.GetNames(typeof(Role)).Skip(1).ToArray());
        }
        private void AddEntries()
        {
            dataTable.Columns.Add("id", typeof(string));
            dataTable.Columns.Add("name", typeof(string));
            dataTable.Columns.Add("role", typeof(string));
            dataTable.Columns.Add("Stage", typeof(int));
            dataTable.Columns.Add("Node", typeof(string));
            dataTable.Columns.Add("Original", typeof(string));
            dataTable.Columns.Add("New Type", typeof(string));
            dataTable.Columns.Add("New Ability", typeof(string));
            dataTable.Columns.Add("New Stat Amount", typeof(int));

            dataGridView1.AutoGenerateColumns = false;

            dataGridView1.Columns.Add(new DataGridViewTextBoxColumn());
            dataGridView1.Columns[0].HeaderText = "Stage";
            dataGridView1.Columns[0].DataPropertyName = "Stage";
            dataGridView1.Columns[0].ReadOnly = true;
            dataGridView1.Columns[0].SortMode = DataGridViewColumnSortMode.NotSortable;

            dataGridView1.Columns.Add(new DataGridViewTextBoxColumn());
            dataGridView1.Columns[1].HeaderText = "Node";
            dataGridView1.Columns[1].DataPropertyName = "Node";
            dataGridView1.Columns[1].ReadOnly = true;
            dataGridView1.Columns[1].SortMode = DataGridViewColumnSortMode.NotSortable;

            dataGridView1.Columns.Add(new DataGridViewTextBoxColumn());
            dataGridView1.Columns[2].HeaderText = "Original";
            dataGridView1.Columns[2].DataPropertyName = "Original";
            dataGridView1.Columns[2].ReadOnly = true;
            dataGridView1.Columns[2].SortMode = DataGridViewColumnSortMode.NotSortable;

            DataGridViewComboBoxColumn column2 = new DataGridViewComboBoxColumn();
            column2.Items.AddRange(new string[] { "???" }.Concat(Enum.GetNames(typeof(CrystariumType)).ToList().Replace(CrystariumType.ATBLevel.ToString(), "ATB Level").Replace(CrystariumType.RoleLevel.ToString(), "Role Level")).ToArray());
            column2.HeaderText = "New Type";
            column2.DisplayMember = "New Type";
            column2.ValueMember = "New Type";
            column2.DataPropertyName = "New Type";
            column2.SortMode = DataGridViewColumnSortMode.NotSortable;
            dataGridView1.Columns.Add(column2);

            DataGridViewComboBoxColumn column = new DataGridViewComboBoxColumn();
            column.Items.AddRange(new string[] { "???" }.Concat(Abilities.abilities.Select(a => a.Name).ToList()).ToArray());
            column.HeaderText = "New Ability";
            column.DisplayMember = "New Ability";
            column.ValueMember = "New Ability";
            column.DataPropertyName = "New Ability";
            column.SortMode = DataGridViewColumnSortMode.NotSortable;
            dataGridView1.Columns.Add(column);

            dataGridView1.Columns.Add(new DataGridViewTextBoxColumn());
            dataGridView1.Columns[5].HeaderText = "New Stat Amount";
            dataGridView1.Columns[5].DataPropertyName = "New Stat Amount";
            dataGridView1.Columns[5].SortMode = DataGridViewColumnSortMode.NotSortable;

            dataGridView1.DataSource = dataTable;
        }

        private void AddEntry(DataStoreIDCrystarium crystId, string charName, string role, string locationName)
        {
            dataTable.Rows.Add(crystId.ID, charName, role, crystId.Stage, locationName, "Unknown", "???", "???", 0);
        }

        public void ReloadData(FormMain main)
        {
            if (loaded)
                return;

            Dictionary<string, DataStoreWDB<DataStoreCrystarium, DataStoreIDCrystarium>> crystariums = new Dictionary<string, DataStoreWDB<DataStoreCrystarium, DataStoreIDCrystarium>>();
            Dictionary<string, Dictionary<DataStoreIDCrystarium, string>> displayNames = new Dictionary<string, Dictionary<DataStoreIDCrystarium, string>>();
            Dictionary<string, List<DataStoreIDCrystarium>> sorted = new Dictionary<string, List<DataStoreIDCrystarium>>();

            foreach (string name in RandoCrystarium.CharNames)
            {
                DataStoreWDB<DataStoreCrystarium, DataStoreIDCrystarium> cryst = new DataStoreWDB<DataStoreCrystarium, DataStoreIDCrystarium>();
                cryst.LoadData(File.ReadAllBytes($"{main.RandoPath}\\original\\db\\crystal\\crystal_{name}.wdb"));
                crystariums.Add(name, cryst);
                displayNames.Add(name, Crystarium.GetDisplayNames(cryst));

                List<DataStoreIDCrystarium> sortedList = cryst.IdList.Where(s => !s.ID.StartsWith("!")).ToList();
                sortedList.Sort((a, b) => a.CompareTo(b));
                sorted.Add(name, sortedList);
            }

            crystariums.Keys.ToList().ForEach(k => sorted[k].ForEach(s => AddEntry(s, k, crystariums[k][s.ID].Role.ToString(), displayNames[k][s])));
            foreach (DataRow row in dataTable.Rows)
            {
                DataStoreCrystarium cryst = crystariums[row.Field<string>(1)][row.Field<string>(0)];
                string name;
                if (cryst.Type == CrystariumType.Accessory)
                    name = "Accessory";
                else if (cryst.Type == CrystariumType.ATBLevel)
                    name = "ATB Level";
                else if (cryst.Type == CrystariumType.RoleLevel)
                    name = "Role Level";
                else if (cryst.Type == CrystariumType.Ability)
                {
                    Ability ability = Abilities.abilities.Find(a => a.GetIDs().Contains(cryst.AbilityName));
                    if (ability == null)
                        name = cryst.AbilityName;
                    else
                        name = ability.Name;
                }
                else
                {
                    name = $"{cryst.Type} +{cryst.Value}";
                }

                name += $" ({cryst.CPCost} CP)";

                row.SetField<string>(5, name);
            }

            loaded = true;
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (dataGridView1.DataSource != null && comboBox1.SelectedIndex > -1 && comboBox2.SelectedIndex > -1)
            {
                dataGridView1.Visible = true;
                CurrencyManager currencyManager1 = (CurrencyManager)dataGridView1.BindingContext[dataGridView1.DataSource];
                currencyManager1.SuspendBinding();
                string charName = RandoCrystarium.CharNames[comboBox1.SelectedIndex];
                string role = Enum.GetNames(typeof(Role))[comboBox2.SelectedIndex + 1];
                for (int row = 0; row < dataGridView1.Rows.Count; row++)
                {
                    dataGridView1.Rows[row].Visible = dataTable.Rows[row].Field<string>(1) == charName && dataTable.Rows[row].Field<string>(2) == role;
                }
                currencyManager1.ResumeBinding();
                dataGridView1.Refresh();                
            }
        }

        private void dataGridView1_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        {
            if (e.ColumnIndex == 5)
            {
                int i = -1;

                if (!int.TryParse(Convert.ToString(e.FormattedValue), out i) || i < 0 || i > 9999999)
                {
                    e.Cancel = true;
                    MessageBox.Show("Must enter a number from 0-9999999");
                }
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
