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
    public partial class CrystariumPlando : UserControl
    {
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
            dataTable.Columns.Add("New CP Cost", typeof(int));

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
            column2.Items.AddRange(new string[] { "???" }.Concat(Enum.GetNames(typeof(CrystariumType)).SkipWhile(s => s == CrystariumType.Unknown.ToString()).ToList().Replace(CrystariumType.ATBLevel.ToString(), "ATB Level").Replace(CrystariumType.RoleLevel.ToString(), "Role Level")).ToArray());
            column2.HeaderText = "New Type";
            column2.DisplayMember = "New Type";
            column2.ValueMember = "New Type";
            column2.DataPropertyName = "New Type";
            column2.SortMode = DataGridViewColumnSortMode.NotSortable;
            dataGridView1.Columns.Add(column2);

            DataGridViewComboBoxColumn column = new DataGridViewComboBoxColumn();
            column.Items.AddRange(GetAbilityDropdownNames());
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

            dataGridView1.Columns.Add(new DataGridViewTextBoxColumn());
            dataGridView1.Columns[6].HeaderText = "New CP Cost";
            dataGridView1.Columns[6].DataPropertyName = "New CP Cost";
            dataGridView1.Columns[6].SortMode = DataGridViewColumnSortMode.NotSortable;

            dataGridView1.DataSource = dataTable;
        }

        private static string[] GetAbilityDropdownNames()
        {
            return new string[] { "???" }.Concat(Abilities.abilities.Select(a => a.Name + (a.GetCharacters() != "LSnVSzHF" ? $" ({a.GetCharacters()})" : "")).ToList()).ToArray();
        }

        private void AddEntry(DataStoreIDCrystarium crystId, string charName, string role, string locationName)
        {
            dataTable.Rows.Add(crystId.ID, charName, role, crystId.Stage, locationName, "Unknown", "???", "???", -1, -1);
        }

        public void ReloadData(FormMain main)
        {
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.None;
            dataTable.Clear();

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

            crystariums.Keys.ForEach(k => sorted[k].ForEach(s => AddEntry(s, k, crystariums[k][s.ID].Role.ToString(), displayNames[k][s])));
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
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (dataGridView1.DataSource != null && comboBox1.SelectedIndex > -1 && comboBox2.SelectedIndex > -1)
            {
                dataGridView1.Visible = true;
                dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.None;
                CurrencyManager currencyManager1 = (CurrencyManager)dataGridView1.BindingContext[dataGridView1.DataSource];
                currencyManager1.SuspendBinding();
                string charName = RandoCrystarium.CharNames[comboBox1.SelectedIndex];
                string role = Enum.GetNames(typeof(Role))[comboBox2.SelectedIndex + 1];
                for (int row = 0; row < dataGridView1.Rows.Count; row++)
                {
                    dataGridView1.Rows[row].Visible = dataTable.Rows[row].Field<string>(1) == charName && dataTable.Rows[row].Field<string>(2) == role;
                }
                currencyManager1.ResumeBinding();
                dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                dataGridView1.Refresh();
            }
        }

        private void dataGridView1_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        {
            if (e.ColumnIndex == 5)
            {
                int i = -1;

                if (!int.TryParse(Convert.ToString(e.FormattedValue), out i) || !(i == -1 || i >= 0 && i <= 999999))
                {
                    e.Cancel = true;
                    MessageBox.Show("Must enter a number from 0-999999 or -1");
                }
            }
            if (e.ColumnIndex == 6)
            {
                int i = -1;

                if (!int.TryParse(Convert.ToString(e.FormattedValue), out i) || !(i == -1 || i >= 0 && i <= 9999999))
                {
                    e.Cancel = true;
                    MessageBox.Show("Must enter a number from 0-9999999 or -1");
                }
            }
            FormMain.PlandoModified = true;
        }

        public Dictionary<string, Dictionary<string, Tuple<CrystariumType, Ability, int>>> GetNodes()
        {
            Dictionary<string, Dictionary<string, Tuple<CrystariumType, Ability, int>>> dict = new Dictionary<string, Dictionary<string, Tuple<CrystariumType, Ability, int>>>();
            RandoCrystarium.CharNames.ForEach(s => dict.Add(s, new Dictionary<string, Tuple<CrystariumType, Ability, int>>()));

            foreach (DataRow row in dataTable.Rows)
            {
                string nodeId = row.Field<string>(0);
                string name = row.Field<string>(1);
                CrystariumType type = row.Field<string>(6) == "???" ? CrystariumType.Unknown : ((CrystariumType[])Enum.GetValues(typeof(CrystariumType)))[Enum.GetNames(typeof(CrystariumType)).ToList().IndexOf(row.Field<string>(6).Replace(" ", ""))];
                Ability ability = Abilities.abilities.Find(a => a.Name == GetAbilityName(row.Field<string>(7)));
                int statAmount = row.Field<int>(8);
                if (!(type == CrystariumType.Unknown && ability == null))
                {
                    if (type == CrystariumType.Ability)
                    {
                        dict[name].Add(nodeId, new Tuple<CrystariumType, Ability, int>(type, ability, -1));
                    }
                    else if ((type == CrystariumType.HP || type == CrystariumType.Strength || type == CrystariumType.Magic) && statAmount > -1)
                    {
                        dict[name].Add(nodeId, new Tuple<CrystariumType, Ability, int>(type, null, statAmount));
                    }
                    else if (type == CrystariumType.Accessory || type == CrystariumType.ATBLevel || type == CrystariumType.RoleLevel)
                    {
                        dict[name].Add(nodeId, new Tuple<CrystariumType, Ability, int>(type, null, 0));
                    }
                    else if (ability != null)
                    {
                        dict[name].Add(nodeId, new Tuple<CrystariumType, Ability, int>(CrystariumType.Ability, ability, -1));
                    }
                }
            }
            return dict;
        }

        public Dictionary<string, Dictionary<string, int>> GetCPCosts()
        {
            Dictionary<string, Dictionary<string, int>> dict = new Dictionary<string, Dictionary<string, int>>();
            RandoCrystarium.CharNames.ForEach(s => dict.Add(s, new Dictionary<string, int>()));

            foreach (DataRow row in dataTable.Rows)
            {
                string nodeId = row.Field<string>(0);
                string name = row.Field<string>(1);
                int cpCost = row.Field<int>(9);
                if (cpCost > 0)
                {
                    dict[name].Add(nodeId, cpCost);
                }
            }
            return dict;
        }

        private string GetAbilityName(string name)
        {
            return name.Contains("(") ? name.Substring(0, name.IndexOf("(") - 1).Trim() : name;
        }

        public class JSONPlandoCrystarium
        {
            public string ID { get; set; }
            public string Type { get; set; }
            public string AbilityName { get; set; }
            public int Value { get; set; }
            public int CPCost { get; set; }
        }

        public List<JSONPlandoCrystarium> GetJSONPlando()
        {
            List<JSONPlandoCrystarium> list = new List<JSONPlandoCrystarium>();

            foreach (DataRow row in dataTable.Rows)
            {
                list.Add(new JSONPlandoCrystarium()
                {
                    ID = row.Field<string>(0),
                    Type = row.Field<string>(6),
                    AbilityName = row.Field<string>(7),
                    Value = row.Field<int>(8),
                    CPCost = row.Field<int>(9)
                });
            }
            return list;
        }

        public void LoadJSONPlando(List<JSONPlandoCrystarium> list, string version)
        {
            list = MigrateJSON(list, version);
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.None;
            foreach (DataRow row in dataTable.Rows)
            {
                JSONPlandoCrystarium json = list.Find(j => j.ID == row.Field<string>(0));
                row.SetField<string>(6, json.Type);

                row.SetField<string>(7, GetAbilityDropdownNames().Where(s => s == json.AbilityName || s.StartsWith(json.AbilityName)).FirstOrDefault());

                row.SetField<int>(8, json.Value);
                row.SetField<int>(9, json.CPCost);
            }
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        private List<JSONPlandoCrystarium> MigrateJSON(List<JSONPlandoCrystarium> list, string version)
        {
            if (version == FormMain.Version)
                return list;
            List<JSONPlandoCrystarium> migrated = new List<JSONPlandoCrystarium>(list);

            if (VersionOrder.Compare(version, "1.8.0.Pre-3") == -1)
            {
                migrated.Where(j => j.Value == 0).ForEach(j => j.Value = -1);
                migrated.ForEach(j => j.CPCost = -1);
            }

            return migrated;
        }
    }
}
