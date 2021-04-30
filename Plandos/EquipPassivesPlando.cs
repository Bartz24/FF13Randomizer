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
    public partial class EquipPassivesPlando : UserControl
    {
        public DataTable dataTable = new DataTable();
        public EquipPassivesPlando()
        {
            InitializeComponent();
            AddEntries();
        }
        private void AddEntries()
        {
            dataTable.Columns.Add("id", typeof(string));
            dataTable.Columns.Add("Name", typeof(string));
            dataTable.Columns.Add("Passive Type", typeof(string));
            dataTable.Columns.Add("New Passive Type", typeof(string));

            dataGridView1.AutoGenerateColumns = false;

            dataGridView1.Columns.Add(new DataGridViewTextBoxColumn());
            dataGridView1.Columns[0].HeaderText = "Name";
            dataGridView1.Columns[0].DataPropertyName = "Name";
            dataGridView1.Columns[0].ReadOnly = true;
            dataGridView1.Columns[0].SortMode = DataGridViewColumnSortMode.NotSortable;

            dataGridView1.Columns.Add(new DataGridViewTextBoxColumn());
            dataGridView1.Columns[1].HeaderText = "Passive Type";
            dataGridView1.Columns[1].DataPropertyName = "Passive Type";
            dataGridView1.Columns[1].ReadOnly = true;
            dataGridView1.Columns[1].SortMode = DataGridViewColumnSortMode.NotSortable;

            DataGridViewComboBoxColumn column = new DataGridViewComboBoxColumn();
            column.Items.AddRange(new string[] { "???" }.Concat(Passives.passives.Where(s => s.LockingLevel > LockingLevel.Fixed).Select(s => s.GetPassiveDirect(0, Int32.MaxValue).Name).ToArray()));
            column.HeaderText = "New Passive Type";
            column.DisplayMember = "New Passive Type";
            column.ValueMember = "New Passive Type";
            column.DataPropertyName = "New Passive Type";
            column.SortMode = DataGridViewColumnSortMode.NotSortable;
            dataGridView1.Columns.Add(column);

            dataGridView1.DataSource = dataTable;
        }

        private void AddEntry(Item item, string name)
        {
            dataTable.Rows.Add(item.ID, name, "", "???");
        }

        public void ReloadData(FormMain main)
        {
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.None;
            dataTable.Clear();

            DataStoreWDB<DataStoreEquip, DataStoreID> equips = new DataStoreWDB<DataStoreEquip, DataStoreID>();
            equips.LoadData(File.ReadAllBytes($"{main.RandoPath}\\original\\db\\resident\\item_weapon.wdb"));

            Items.items.Where(i => (i.ID.StartsWith("acc") || i.ID.StartsWith("wea")) && i.EquipPassive.Item1.LockingLevel > LockingLevel.Fixed && i.EquipPassive.Item2 == 0).ForEach(i =>
            {
                List<Item> upgrades = new List<Item>();
                for (Item i2 = i; ; i2 = Items.items.Find(i3 => i3.ID == equips[i2].UpgradeInto))
                {
                    upgrades.Add(i2);
                    if (equips[i2].UpgradeInto == "")
                        break;
                }
                List<string> names = Items.items.Where(i2 => i2.EquipPassive != null && i2.EquipPassive.Item1 == i.EquipPassive.Item1 && upgrades.Contains(i2)).OrderBy(i2 => i2.EquipPassive.Item2).Select(i2 => i2.Name).ToList();
                AddEntry(i, String.Join("/", names));
            });


            foreach (DataRow row in dataTable.Rows)
            {
                DataStoreEquip equip = equips[row.Field<string>(0)];
                Item item = Items.items.Find(i => i.ID == row.Field<string>(0));
                row.SetField<string>(2, String.Join("/", item.EquipPassive.Item1.GetPassives().Select(p => p.Name)));
            }

            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView1.Refresh();
        }

        private void dataGridView1_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        {
            FormMain.PlandoModified = true;
        }

        public Dictionary<Item, PassiveSet> GetPassives()
        {
            Dictionary<Item, PassiveSet> dict = new Dictionary<Item, PassiveSet>();
            foreach (DataRow row in dataTable.Rows)
            {
                Item item = Items.items.Find(i => i.ID == row.Field<string>(0));
                PassiveSet passive = Passives.passives.Where(s => s.GetPassives().Select(p => p.Name).Contains(row.Field<string>(3))).FirstOrDefault();
                if (passive != null)
                {
                    dict.Add(item, passive);
                }
            }
            return dict;
        }

        public class JSONPlandoEquipPassive
        {
            public string ID { get; set; }
            public string PassiveName { get; set; }
        }

        public List<JSONPlandoEquipPassive> GetJSONPlando()
        {
            List<JSONPlandoEquipPassive> list = new List<JSONPlandoEquipPassive>();

            foreach (DataRow row in dataTable.Rows)
            {
                list.Add(new JSONPlandoEquipPassive()
                {
                    ID = row.Field<string>(0),
                    PassiveName = row.Field<string>(3)
                });
            }
            
            return list;
        }

        public void LoadJSONPlando(List<JSONPlandoEquipPassive> list, string version)
        {
            
            list = MigrateJSON(list, version);
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.None;
            foreach (DataRow row in dataTable.Rows)
            {
                JSONPlandoEquipPassive json = list.Find(j => j.ID == row.Field<string>(0));
                row.SetField<string>(3, json.PassiveName);
            }
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        private List<JSONPlandoEquipPassive> MigrateJSON(List<JSONPlandoEquipPassive> list, string version)
        {
            if (version == FormMain.Version)
                return list;
            List<JSONPlandoEquipPassive> migrated = new List<JSONPlandoEquipPassive>(list);

            return migrated;
        }
    }
}
