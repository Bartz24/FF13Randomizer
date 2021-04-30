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
    public partial class EquipPlando : UserControl
    {
        public DataTable dataTable = new DataTable();
        public EquipPlando()
        {
            InitializeComponent();
            AddEntries();
        }
        private void AddEntries()
        {
            dataTable.Columns.Add("id", typeof(string));
            dataTable.Columns.Add("Name", typeof(string));
            dataTable.Columns.Add("Strength", typeof(string));
            dataTable.Columns.Add("New Strength Initial", typeof(int));
            dataTable.Columns.Add("New Strength Increase", typeof(int));
            dataTable.Columns.Add("Magic", typeof(string));
            dataTable.Columns.Add("New Magic Initial", typeof(int));
            dataTable.Columns.Add("New Magic Increase", typeof(int));
            dataTable.Columns.Add("Passive Type", typeof(string));
            dataTable.Columns.Add("New Passive Stat Initial", typeof(int));
            dataTable.Columns.Add("New Passive Stat Increase", typeof(int));
            dataTable.Columns.Add("Synthesis Group", typeof(string));
            dataTable.Columns.Add("New Synthesis Group", typeof(string));

            dataGridView1.AutoGenerateColumns = false;

            dataGridView1.Columns.Add(new DataGridViewTextBoxColumn());
            dataGridView1.Columns[0].HeaderText = "Name";
            dataGridView1.Columns[0].DataPropertyName = "Name";
            dataGridView1.Columns[0].ReadOnly = true;
            dataGridView1.Columns[0].SortMode = DataGridViewColumnSortMode.NotSortable;

            dataGridView1.Columns.Add(new DataGridViewTextBoxColumn());
            dataGridView1.Columns[1].HeaderText = "Strength";
            dataGridView1.Columns[1].DataPropertyName = "Strength";
            dataGridView1.Columns[1].ReadOnly = true;
            dataGridView1.Columns[1].SortMode = DataGridViewColumnSortMode.NotSortable;

            dataGridView1.Columns.Add(new DataGridViewTextBoxColumn());
            dataGridView1.Columns[2].HeaderText = "New Strength Initial";
            dataGridView1.Columns[2].DataPropertyName = "New Strength Initial";
            dataGridView1.Columns[2].SortMode = DataGridViewColumnSortMode.NotSortable;

            dataGridView1.Columns.Add(new DataGridViewTextBoxColumn());
            dataGridView1.Columns[3].HeaderText = "New Strength Increase";
            dataGridView1.Columns[3].DataPropertyName = "New Strength Increase";
            dataGridView1.Columns[3].SortMode = DataGridViewColumnSortMode.NotSortable;

            dataGridView1.Columns.Add(new DataGridViewTextBoxColumn());
            dataGridView1.Columns[4].HeaderText = "Magic";
            dataGridView1.Columns[4].DataPropertyName = "Magic";
            dataGridView1.Columns[4].ReadOnly = true;
            dataGridView1.Columns[4].SortMode = DataGridViewColumnSortMode.NotSortable;

            dataGridView1.Columns.Add(new DataGridViewTextBoxColumn());
            dataGridView1.Columns[5].HeaderText = "New Magic Initial";
            dataGridView1.Columns[5].DataPropertyName = "New Magic Initial";
            dataGridView1.Columns[5].SortMode = DataGridViewColumnSortMode.NotSortable;

            dataGridView1.Columns.Add(new DataGridViewTextBoxColumn());
            dataGridView1.Columns[6].HeaderText = "New Magic Increase";
            dataGridView1.Columns[6].DataPropertyName = "New Magic Increase";
            dataGridView1.Columns[6].SortMode = DataGridViewColumnSortMode.NotSortable;

            dataGridView1.Columns.Add(new DataGridViewTextBoxColumn());
            dataGridView1.Columns[7].HeaderText = "Passive Type";
            dataGridView1.Columns[7].DataPropertyName = "Passive Type";
            dataGridView1.Columns[7].ReadOnly = true;
            dataGridView1.Columns[7].SortMode = DataGridViewColumnSortMode.NotSortable;

            dataGridView1.Columns.Add(new DataGridViewTextBoxColumn());
            dataGridView1.Columns[8].HeaderText = "New Passive Stat Initial";
            dataGridView1.Columns[8].DataPropertyName = "New Passive Stat Initial";
            dataGridView1.Columns[8].SortMode = DataGridViewColumnSortMode.NotSortable;

            dataGridView1.Columns.Add(new DataGridViewTextBoxColumn());
            dataGridView1.Columns[9].HeaderText = "New Passive Stat Increase";
            dataGridView1.Columns[9].DataPropertyName = "New Passive Stat Increase";
            dataGridView1.Columns[9].SortMode = DataGridViewColumnSortMode.NotSortable;

            dataGridView1.Columns.Add(new DataGridViewTextBoxColumn());
            dataGridView1.Columns[10].HeaderText = "Synthesis Group";
            dataGridView1.Columns[10].DataPropertyName = "Synthesis Group";
            dataGridView1.Columns[10].ReadOnly = true;
            dataGridView1.Columns[10].SortMode = DataGridViewColumnSortMode.NotSortable;

            DataGridViewComboBoxColumn column = new DataGridViewComboBoxColumn();
            column.Items.AddRange(new string[] { "???" }.Concat(Enum.GetValues(typeof(SynthesisGroup)).Cast<SynthesisGroup>().Select(v => v.SeparateWords()).ToArray()));
            column.HeaderText = "New Synthesis Group";
            column.DisplayMember = "New Synthesis Group";
            column.ValueMember = "New Synthesis Group";
            column.DataPropertyName = "New Synthesis Group";
            column.SortMode = DataGridViewColumnSortMode.NotSortable;
            dataGridView1.Columns.Add(column);

            dataGridView1.DataSource = dataTable;
        }

        private void AddEntry(Item item)
        {
            dataTable.Rows.Add(item.ID, item.Name, "", -1, -1, "", -1, -1, "", -1, -1, "", "???");
        }

        public void ReloadData(FormMain main)
        {
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.None;
            dataTable.Clear();

            DataStoreWDB<DataStoreEquip, DataStoreID> equips = new DataStoreWDB<DataStoreEquip, DataStoreID>();
            equips.LoadData(File.ReadAllBytes($"{main.RandoPath}\\original\\db\\resident\\item_weapon.wdb"));

            DataStoreWDB<DataStoreItem, DataStoreID> items = new DataStoreWDB<DataStoreItem, DataStoreID>();
            items.LoadData(File.ReadAllBytes($"{main.RandoPath}\\original\\db\\resident\\item.wdb"));

            Items.items.Where(i => i.ID.StartsWith("acc") || i.ID.StartsWith("wea")).ForEach(i => AddEntry(i));


            foreach (DataRow row in dataTable.Rows)
            {
                DataStoreEquip equip = equips[row.Field<string>(0)];
                Item item = Items.items.Find(i => i.ID == row.Field<string>(0));
                row.SetField<string>(2, equip.StrengthInitial.ToString() + (equip.StrengthIncrease > 0 ? $" (+{equip.StrengthIncrease}/Lv)" : ""));
                row.SetField<string>(5, equip.MagicInitial.ToString() + (equip.MagicIncrease > 0 ? $" (+{equip.MagicIncrease}/Lv)" : ""));
                PassiveSet.Passive passive = item.EquipPassive.Item1.GetPassiveDirect(item.EquipPassive.Item2, Int32.MaxValue);
                string passiveName = passive.Name;
                if (passive.StatInitial == -1)
                {
                    passiveName = passiveName.Replace("X", equip.StatInitial.ToString());
                    if (equip.StatIncrease > 0)
                        passiveName += $" (+{equip.StatIncrease}/Lv)";
                }
                row.SetField<string>(8, passiveName);
                row.SetField<string>(11, ((SynthesisGroup)items[item].SynthesisGroup).SeparateWords());
            }

            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            dataGridView1.Refresh();
        }

        private void dataGridView1_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        {
            if (e.ColumnIndex == 2 || e.ColumnIndex == 3 || e.ColumnIndex == 5 || e.ColumnIndex == 6 || e.ColumnIndex == 8 || e.ColumnIndex == 9)
            {
                int i = -1;

                if (!int.TryParse(Convert.ToString(e.FormattedValue), out i) || !(i == -1 || i >= 0 && i <= 16000))
                {
                    e.Cancel = true;
                    MessageBox.Show("Must enter a number from 0-16000 or -1");
                }
            }
            FormMain.PlandoModified = true;
        }

        public Dictionary<Item, Tuple<int[], int[]>> GetEquipment()
        {
            Dictionary<Item, Tuple<int[], int[]>> dict = new Dictionary<Item, Tuple<int[], int[]>>();
            foreach (DataRow row in dataTable.Rows)
            {
                Item item = Items.items.Find(i => i.ID == row.Field<string>(0));
                int[] initials = new int[3];
                int[] increases = new int[3];
                initials[0] = row.Field<int>(3);
                increases[0] = row.Field<int>(4);
                initials[1] = row.Field<int>(6);
                increases[1] = row.Field<int>(7);
                initials[2] = row.Field<int>(9);
                increases[2] = row.Field<int>(10);
                if (initials.Where(v => v != -1).Count() > 0 || increases.Where(v => v != -1).Count() > 0)
                {
                    dict.Add(item, new Tuple<int[], int[]>(initials, increases));
                }
            }
            return dict;
        }

        public Dictionary<Item, SynthesisGroup> GetSynthesisGroups()
        {
            Dictionary<Item, SynthesisGroup> dict = new Dictionary<Item, SynthesisGroup>();
            foreach (DataRow row in dataTable.Rows)
            {
                Item item = Items.items.Find(i => i.ID == row.Field<string>(0));
                string synthGroup = row.Field<string>(1);
                if (synthGroup != "???")
                {
                    dict.Add(item, Enum.GetValues(typeof(SynthesisGroup)).Cast<SynthesisGroup>().Where(s => s.SeparateWords() == synthGroup).First());
                }
            }
            return dict;
        }

        public class JSONPlandoEquip
        {
            public string ID { get; set; }
            public int StrengthInitial { get; set; }
            public int StrengthIncrease { get; set; }
            public int MagicInitial { get; set; }
            public int MagicIncrease { get; set; }
            public int StatInitial { get; set; }
            public int StatIncrease { get; set; }
            public string SynthesisGroup { get; set; }
        }

        public List<JSONPlandoEquip> GetJSONPlando()
        {
            List<JSONPlandoEquip> list = new List<JSONPlandoEquip>();

            foreach (DataRow row in dataTable.Rows)
            {
                list.Add(new JSONPlandoEquip()
                {
                    ID = row.Field<string>(0),
                    StrengthInitial = row.Field<int>(3),
                    StrengthIncrease = row.Field<int>(4),
                    MagicInitial = row.Field<int>(6),
                    MagicIncrease = row.Field<int>(7),
                    StatInitial = row.Field<int>(9),
                    StatIncrease = row.Field<int>(10),
                    SynthesisGroup = row.Field<string>(12)
                });
            }
            
            return list;
        }

        public void LoadJSONPlando(List<JSONPlandoEquip> list, string version)
        {
            
            list = MigrateJSON(list, version);
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.None;
            foreach (DataRow row in dataTable.Rows)
            {
                JSONPlandoEquip json = list.Find(j => j.ID == row.Field<string>(0));
                row.SetField<int>(3, json.StrengthInitial);
                row.SetField<int>(4, json.StrengthIncrease);
                row.SetField<int>(6, json.MagicInitial);
                row.SetField<int>(7, json.MagicIncrease);
                row.SetField<int>(9, json.StatInitial);
                row.SetField<int>(10, json.StatIncrease);
                row.SetField<string>(12, json.SynthesisGroup);
            }
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
        }

        private List<JSONPlandoEquip> MigrateJSON(List<JSONPlandoEquip> list, string version)
        {
            if (version == FormMain.Version)
                return list;
            List<JSONPlandoEquip> migrated = new List<JSONPlandoEquip>(list);

            return migrated;
        }

        private void dataGridView1_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
        {

            Item item = Items.items.Find(i => i.ID == dataTable.Rows[e.RowIndex].Field<string>(0));
            if ((e.ColumnIndex == 2 || e.ColumnIndex == 3 || e.ColumnIndex == 5 || e.ColumnIndex == 6) && (item.ID.StartsWith("acc")))
            {
                e.Cancel = true;
            }
            if ((e.ColumnIndex == 8 || e.ColumnIndex == 9) && (item.EquipPassive == null || item.EquipPassive.Item1.GetPassiveDirect(item.EquipPassive.Item2, Int32.MaxValue).StatInitial != -1))
            {
                e.Cancel = true;
            }
        }
    }
}
