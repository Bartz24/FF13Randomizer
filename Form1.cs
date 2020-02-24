using FF13Data;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FF13Randomizer
{
    public partial class Form1 : Form
    {
        public static string version = "1.1.0";
        public string[] fileNamesModified = new string[]
        {
            "db/crystal/crystal_lightning.wdb",
            "db/crystal/crystal_snow.wdb",
            "db/crystal/crystal_fang.wdb",
            "db/crystal/crystal_hope.wdb",
            "db/crystal/crystal_vanille.wdb",
            "db/crystal/crystal_sazh.wdb",
            "db/resident/treasurebox.wdb",
            "db/resident/bt_chara_spec.wdb",
            "db/resident/bt_scene.wdb"
        };

        public Form1()
        {
            if (GetFF13Directory() == null)
                AutoSearchDir();

            if(GetFF13Directory()!=null)
            {
                Directory.CreateDirectory(randoPath+"\\FlagsSeeds");
                if (Directory.GetFiles(randoPath+"\\FlagsSeeds").Count() > 0)
                {
                    /*DirectoryInfo directory = new DirectoryInfo(randoPath+"\\FlagsSeeds");
                    FileInfo myFile = directory.GetFiles()
                  .OrderByDescending(f => f.LastWriteTime)
                  .First();
                    textBoxSeed.Text = UserFlagsSeed.Import(myFile.FullName, version);*/
                }

                foreach (string path in fileNamesModified)
                {
                    Directory.CreateDirectory(Path.GetDirectoryName(path.Replace("/", "\\")));
                }
            }

            new Flags();

            InitializeComponent();

            tabControl1.SelectedIndexChanged += TabControl1_TabIndexChanged;

            TableLayoutPanel tableLayout = new TableLayoutPanel();
            tableLayout.Dock = DockStyle.Fill;
            tableLayout.ColumnCount = 1;
            tableLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100));
            tableLayout.CellBorderStyle = TableLayoutPanelCellBorderStyle.Single;
            tableLayout.AutoScroll = true;
            tabPageFlags.Controls.Add(tableLayout);

            foreach (Flag flag in Flags.flags)
            {
                addFlagEvents(flag);
                flag.Dock = DockStyle.Fill;
                flag.FlagEnabled = true;

                flag.OnChangedEvent();
                flag.OnChanged += Flag_OnChanged;

                tableLayout.Controls.Add(flag);
            }

            SetRandomSeed();

            textBox2.Text = GetFF13Directory() == null ? "" : GetFF13Directory();

#if !DEBUG
            tabControl1.TabPages.Remove(tabPageDebug);
#endif
        }


        private void TabControl1_TabIndexChanged(object sender, EventArgs e)
        {
            flagInfo1.Flag = Flag.Empty;
            labelFlagsSelected.Text = "Flags Selected: " + Flags.flags.Sum(f => f.FlagEnabled ? 1 : 0);
            bool allow = GetFF13Directory() != null;
            buttonRandomize.Enabled = allow;
            buttonUninstall.Enabled = allow;
            buttonFullUninstall.Enabled = allow;
        }

        private void Flag_OnChanged(object sender, EventArgs e)
        {
            Control control = (Control)sender;
            while (!(control is Flag))
            {
                control = control.Parent;
            }
            if (flagInfo1.Flag == (Flag)control)
                flagInfo1.Update();
        }

        private void addFlagEvents(Control control)
        {
            control.MouseEnter += Flag_MouseEnter;
            control.MouseLeave += Flag_MouseLeave;
            foreach (Control cont in control.Controls)
            {
                addFlagEvents(cont);
            }
        }

        private void Flag_MouseLeave(object sender, EventArgs e)
        {
        }

        private void Flag_MouseEnter(object sender, EventArgs e)
        {
            Control control = (Control)sender;
            while (!(control is Flag))
            {
                control = control.Parent;
            }
            flagInfo1.Flag = (Flag)control;
        }

        private void tabControl1_DrawItem(object sender, DrawItemEventArgs e)
        {
            Graphics g = e.Graphics;
            Brush _textBrush;

            // Get the item from the collection.
            TabPage _tabPage = tabControl1.TabPages[e.Index];

            // Get the real bounds for the tab rectangle.
            Rectangle _tabBounds = tabControl1.GetTabRect(e.Index);

            if (e.State == DrawItemState.Selected)
            {

                // Draw a different background color, and don't paint a focus rectangle.
                _textBrush = new SolidBrush(e.ForeColor);
                g.FillRectangle(Brushes.Gray, e.Bounds);
            }
            else
            {
                _textBrush = new System.Drawing.SolidBrush(e.ForeColor);
                //g.FillRectangle(Brushes.LightGray, e.Bounds);
            }

            // Use our own font.
            Font _tabFont = e.Font;

            // Draw string. Center the text.
            StringFormat _stringFlags = new StringFormat();
            _stringFlags.Alignment = StringAlignment.Center;
            _stringFlags.LineAlignment = StringAlignment.Center;
            g.DrawString(_tabPage.Text, _tabFont, _textBrush, _tabBounds, new StringFormat(_stringFlags));
        }

        private string getCharID(string character)
        {
            if (character == "sazh")
                return "z";
            return character.Substring(0, 1);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            RandomizeCrystarium();
            MessageBox.Show("Done.");
        }

        private void RandomizeCrystarium()
        {
            string[] names = new string[] { "lightning", "fang", "snow", "sazh", "hope", "vanille" };

            Dictionary<string, CrystariumDatabase> crystariums = new Dictionary<string, CrystariumDatabase>();
            Dictionary<string, Role[]> primaryRoles = new Dictionary<string, Role[]>();
            primaryRoles.Add("lightning", new Role[] { Role.Commando, Role.Ravager, Role.Medic });
            primaryRoles.Add("fang", new Role[] { Role.Commando, Role.Sentinel, Role.Saboteur });
            primaryRoles.Add("snow", new Role[] { Role.Commando, Role.Ravager, Role.Sentinel });
            primaryRoles.Add("sazh", new Role[] { Role.Commando, Role.Ravager, Role.Synergist });
            primaryRoles.Add("hope", new Role[] { Role.Ravager, Role.Synergist, Role.Medic });
            primaryRoles.Add("vanille", new Role[] { Role.Ravager, Role.Saboteur, Role.Medic });

            foreach (string name in names)
            {
                crystariums.Add(name, new CrystariumDatabase($"{randoPath}\\original\\db\\crystal\\crystal_{name}.wdb"));
            }

            if (Flags.CrystariumFlags.RandStats.FlagEnabled)
            {
                Dictionary<int, Dictionary<CrystariumType, List<int>>> statAverages = new Dictionary<int, Dictionary<CrystariumType, List<int>>>();
                for (int stage = 1; stage <= 10; stage++)
                {
                    Dictionary<CrystariumType, List<int>> dict = new Dictionary<CrystariumType, List<int>>();
                    dict.Add(CrystariumType.HP, new List<int>());
                    dict.Add(CrystariumType.Strength, new List<int>());
                    dict.Add(CrystariumType.Magic, new List<int>());
                    statAverages.Add(stage, dict);
                }

                foreach (CrystariumDatabase crystarium in crystariums.Values)
                {
                    foreach (DataStoreCrystarium c in crystarium.Crystarium)
                    {
                        if (c.Type == CrystariumType.HP || c.Type == CrystariumType.Strength || c.Type == CrystariumType.Magic)
                        {
                            statAverages[c.Stage][c.Type].Add(c.Value);
                        }
                    }
                }

                statAverages.Values.ToList().ForEach(d => {
                    d.Keys.ToList().ForEach(k =>
                    {
                        int avg = (int)Math.Ceiling((double)d[k].Sum(v => v) / d[k].Count);
                        d[k].Clear();
                        d[k].Add(avg);
                    });
                    int avgStrMag = (d[CrystariumType.Strength][0] + d[CrystariumType.Magic][0]) / 2;
                    d[CrystariumType.Strength][0] = d[CrystariumType.Magic][0] = avgStrMag;
                });

                foreach (string name in names)
                {
                    CrystariumDatabase crystarium = crystariums[name];

                    Dictionary<int, Dictionary<Role, int>> nodeCounts = new Dictionary<int, Dictionary<Role, int>>();
                    for (int stage = 1; stage <= 10; stage++)
                    {
                        Dictionary<Role, int> stageDict = new Dictionary<Role, int>();
                        foreach (Role role in Enum.GetValues(typeof(Role)))
                        {
                            stageDict.Add(role, crystarium.Crystarium.Where(
                                c => c.Stage == stage && c.Role == role &&
                                (c.Type == CrystariumType.HP || c.Type == CrystariumType.Strength || c.Type == CrystariumType.Magic))
                                .Count());
                        }
                        nodeCounts.Add(stage, stageDict);
                    }

                    int hpMult = 1, strMult = 1, magMult = 1;
                    while (hpMult + strMult + magMult < 300)
                    {
                        int val = Math.Max((300 - hpMult - strMult - magMult) / 15, 1);
                        int select = RandomNum.randInt(0, 2);
                        if (select == 0)
                            hpMult += val;
                        else if (select == 1)
                            strMult += val;
                        else
                            magMult += val;
                    }

                    foreach (DataStoreCrystarium c in crystarium.Crystarium)
                    {
                        if (c.Type == CrystariumType.HP || c.Type == CrystariumType.Strength || c.Type == CrystariumType.Magic)
                        {
                            c.Type = RandomNum.SelectRandomWeighted(
                                new CrystariumType[] { CrystariumType.HP, CrystariumType.Strength, CrystariumType.Magic }.ToList(),
                                t => Math.Max(1, (int)Math.Pow(t == CrystariumType.HP ? hpMult : (t == CrystariumType.Strength ? strMult : magMult), 1 / 1.5d)));

                            int avgValue = statAverages[c.Stage][c.Type][0];
                            if (primaryRoles[name].Contains(c.Role))
                            {
                                avgValue = (int)Math.Ceiling(avgValue * (5 * Math.Exp(-0.5d * nodeCounts[c.Stage][c.Role]) + 1));
                            }
                            else
                                avgValue = (int)Math.Ceiling(avgValue / 1.8d);

                            if(name!="fang" && c.CPCost == 0)
                                avgValue = (int)Math.Floor(avgValue * 2.8d);


                            if (c.Type == CrystariumType.HP)
                                c.Value = (ushort)Math.Round(Math.Max(1, (float)avgValue * (float)hpMult / 100f));
                            if (c.Type == CrystariumType.Strength)
                                c.Value = (ushort)Math.Round(Math.Max(1, (float)avgValue * (float)strMult / 100f));
                            if (c.Type == CrystariumType.Magic)
                                c.Value = (ushort)Math.Round(Math.Max(1, (float)avgValue * (float)magMult / 100f));
                        }
                    }
                }
            }

            foreach (string name in names)
            {
                CrystariumDatabase crystarium = crystariums[name];

                if (Flags.CrystariumFlags.ShuffleATBAccessory.FlagEnabled)
                {
                    crystarium.Crystarium.ToList()
                                .Where(c => (c.Type == CrystariumType.Accessory || c.Type == CrystariumType.ATBLevel)
                                && c.CPCost > 0).ToList()
                                .Shuffle((a, b) => a.SwapStatsAbilities(b));
                }

                List<Ability> techniques = Abilities.abilities.Where(a => a.Role == Role.None).ToList();

                for (int r = 1; r <= 6; r++)
                {
                    Role role = (Role)r;

                    if (Flags.CrystariumFlags.NewAbilities.FlagEnabled)
                    {

                        List<int> abilityNodes = new List<int>();
                        for (int i = 0; i < crystarium.Crystarium.count; i++)
                        {
                            if (crystarium.Crystarium[i].Role == role && crystarium.Crystarium[i].Type == CrystariumType.Ability)
                                abilityNodes.Add(i);
                        }

                        abilityNodes.Shuffle();

                        List<Ability> starting = Abilities.abilities.Where(a => a.Role == role && a.Starting && a.HasCharacter(getCharID(name))).ToList();
                        List<Ability> rest = Abilities.abilities.Where(a => a.Role == role && !a.Starting && a.HasCharacter(getCharID(name))).ToList();

                        for (int i = abilityNodes.Count - 1; i >= 0; i--)
                        {
                            DataStoreCrystarium cryst = crystarium.Crystarium[abilityNodes[i]];
                            if (cryst.CPCost == 0)
                            {
                                int newI = RandomNum.randInt(0, starting.Count - 1);
                                DataStoreString dataStr = new DataStoreString() { Value = starting[newI].GetAbility(getCharID(name)) };
                                if (!crystarium.AbilityIDs.Contains(dataStr))
                                    crystarium.AbilityIDs.Add(dataStr, crystarium.AbilityIDs.GetTrueSize());
                                cryst.AbilityPointer = (uint)crystarium.AbilityIDs.IndexOf(dataStr);
                                starting.RemoveAt(newI);
                                abilityNodes.RemoveAt(i);
                                break;
                            }
                        }
                        rest.AddRange(starting);
                        for (int i = abilityNodes.Count - 1; i >= 0; i--)
                        {
                            DataStoreCrystarium cryst = crystarium.Crystarium[abilityNodes[i]];
                            if (rest.Count > 0)
                            {
                                int newI = RandomNum.randInt(0, rest.Count - 1);
                                DataStoreString dataStr = new DataStoreString() { Value = rest[newI].GetAbility(getCharID(name)) };
                                if (!crystarium.AbilityIDs.Contains(dataStr))
                                    crystarium.AbilityIDs.Add(dataStr, crystarium.AbilityIDs.GetTrueSize());
                                cryst.AbilityPointer = (uint)crystarium.AbilityIDs.IndexOf(dataStr);
                                rest.RemoveAt(newI);
                            }
                            else
                            {
                                int newI = RandomNum.randInt(0, techniques.Count - 1);
                                DataStoreString dataStr = new DataStoreString() { Value = techniques[newI].GetAbility(getCharID(name)) };
                                if (!crystarium.AbilityIDs.Contains(dataStr))
                                    crystarium.AbilityIDs.Add(dataStr, crystarium.AbilityIDs.GetTrueSize());
                                cryst.AbilityPointer = (uint)crystarium.AbilityIDs.IndexOf(dataStr);
                                techniques.RemoveAt(newI);
                            }
                        }
                    }

                    if (Flags.CrystariumFlags.ShuffleNonStat.FlagEnabled)
                    {
                        crystarium.Crystarium.ToList()
                                .Where(c => (c.Type == CrystariumType.Accessory
                                || c.Type == CrystariumType.Ability
                                || c.Type == CrystariumType.ATBLevel
                                || c.Type == CrystariumType.RoleLevel)
                                && c.Role == role && c.CPCost > 0 
                                && crystarium.Crystarium.ToList().Where(c2=>c2.Role==role && c2.Stage == 1 && c2.Type==CrystariumType.Ability && c2.CPCost > 0).Count() != 1).ToList()
                                .Shuffle((a, b) => a.SwapStatsAbilities(b));
                    }

                    if (Flags.CrystariumFlags.ShuffleStage.FlagEnabled)
                    {
                        for (int stage = 1; stage <= 10; stage++)
                        {
                            crystarium.Crystarium.ToList()
                                .Where(c => c.Stage == stage && c.Role == role && c.CPCost > 0).ToList()
                                .Shuffle((a, b) => a.SwapStatsAbilities(b));
                        }
                    }
                }                

                crystarium.Save($"db\\crystal\\crystal_{name}.wdb");

            }
        }

        private void runCommand(string command, bool showConsole = true)
        {
            ProcessStartInfo procStartInfo = new ProcessStartInfo("cmd", "/c " + command);

            //procStartInfo.RedirectStandardOutput = true;
            procStartInfo.UseShellExecute = false;
            procStartInfo.Verb = "runas";

            procStartInfo.CreateNoWindow = !showConsole;

#if DEBUG
            procStartInfo.CreateNoWindow = false;
#endif

            // wrap IDisposable into using (in order to release hProcess) 
            using (Process process = new Process())
            {
                process.OutputDataReceived += new DataReceivedEventHandler(MyProcOutputHandler);
                process.StartInfo = procStartInfo;
                process.Start();

                // Add this: wait until process does its work
                process.WaitForExit();                
            }
        }

        private static void MyProcOutputHandler(object sendingProcess,
                    DataReceivedEventArgs outLine)
        {
            // Collect the sort command output. 
            if (!String.IsNullOrEmpty(outLine.Data))
            {
                Console.WriteLine(outLine.Data);
            }
        }

        private void insertFiles(bool newFiles)
        {
            foreach (string path in fileNamesModified)
            {
                if (!newFiles)
                {
                    File.Copy(randoPath + "\\original\\" + path.Replace("/", "\\"), path.Replace("/", "\\"), true);
                }
                string filePath = path.Replace("/", "\\");
                string command = "ff13tool.exe -i " +
                    $"\"{GetFF13Directory() + "\\white_data\\sys\\filelistu.win32.bin"}\" " +
                    $"\"{GetFF13Directory() + "\\white_data\\sys\\white_imgu.win32.bin"}\" "+
                    $"\"{filePath}\"";
                runCommand(command, false);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            byte[] bytes = File.ReadAllBytes("old/treasurebox.wdb");
            uint gil = 1;
            for (int i = 0x477C; i < bytes.Length; i += 0xC)
            {
                bytes.SetSubArray(i, new byte[] { 0x00, 0x00, 0x08, 0xB0, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x08, 0xB0 });
                bytes.SetSubArray(i + 4, BitConverter.GetBytes(gil).ReverseArray());
                gil++;
            }
            File.WriteAllBytes("db/resident/treasurebox.wdb", bytes);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            RandomizeTreasures();
            MessageBox.Show("Done.");

        }

        List<string> shopsRemaining = new List<string>();
        List<Item> blacklistedWeapons = new List<Item>();

        private void RandomizeTreasures()
        {
            Items.items.ForEach(i=>{
                if (i.ID.StartsWith("wea_") && i.ID.EndsWith("_001"))
                    blacklistedWeapons.Add(i);
            });
            TreasureDatabase oldTreasures = new TreasureDatabase($"{randoPath}\\original\\db\\resident\\treasurebox.wdb");

            TreasureDatabase treasures = new TreasureDatabase($"{randoPath}\\original\\db\\resident\\treasurebox.wdb");
            if (Flags.ItemFlags.Treasures.FlagEnabled)
            {
                treasures.ItemIDs.Clear();

                List<Item> blacklisted = new List<Item>();

                treasures.Treasures.ToList().ForEach(t =>
                {
                    Item item = Items.items.Where(i => i.ID == oldTreasures.ItemIDs[(int)t.StartingPointer]?.Value).FirstOrDefault();
                    if (item != null)
                    {
                        int rank = TieredItems.manager.GetRank(item, (int)t.Count);
                        if (rank != -1)
                        {
                            Tuple<Item, int> newItem;
                            do
                            {
                                newItem = TieredItems.manager.Get(rank, tiered => GetTreasureWeight(tiered));
                                rank--;
                            } while (rank >= 0 && (newItem == null || blacklisted.Contains(newItem.Item1) || blacklistedWeapons.Contains(newItem.Item1)));
                            if (newItem.Item1.ID.StartsWith("wea_"))
                                blacklisted.Add(newItem.Item1);
                            DataStoreString dataStr = new DataStoreString() { Value = newItem.Item1.ID };
                            if (!treasures.ItemIDs.Contains(dataStr))
                                treasures.ItemIDs.Add(dataStr, treasures.ItemIDs.GetTrueSize());
                            t.StartingPointer = (uint)treasures.ItemIDs.IndexOf(dataStr);
                            if (t.StartingPointer == 0xFFFFFFFF)
                                treasures.ItemIDs.IndexOf(dataStr);
                            t.EndingPointer = (uint)(t.StartingPointer + dataStr.Value.Length);
                            t.Count = (uint)newItem.Item2;

                            if (t.StartingPointer > 0xAAAA || t.EndingPointer > 0xAAAA)
                                throw new Exception("Too large");

                            return;
                        }
                    }

                    DataStoreString str = oldTreasures.ItemIDs[(int)t.StartingPointer];
                    if (!treasures.ItemIDs.Contains(str))
                        treasures.ItemIDs.Add(str, treasures.ItemIDs.GetTrueSize());
                    t.StartingPointer = (uint)treasures.ItemIDs.IndexOf(str);
                    t.EndingPointer = (uint)(t.StartingPointer + str.Value.Length);

                    if (t.StartingPointer > 0xAAAA || t.EndingPointer > 0xAAAA)
                        throw new Exception("Too large");

                });
            }

            if (Flags.ItemFlags.Shops.FlagEnabled)
            {
                shopsRemaining.Clear();
                for (int i = 1; i <= 13; i++)
                {
                    if (i == 4)
                        continue;
                    shopsRemaining.Add("key_shop_" + i.ToString("00"));
                }
                shopsRemaining.Shuffle();
                treasures.ItemIDs.ToList().ForEach(str =>
                {
                    if (str.Value.StartsWith("key_shop_"))
                    {
                        str.Value = shopsRemaining[0];
                        shopsRemaining.RemoveAt(0);
                    }
                });
            }

            treasures.Save($"db\\resident\\treasurebox.wdb");
        }

        private int GetTreasureWeight(Tiered<Item> t)
        {            
            if (t.Items.Where(i => i.ID.StartsWith("material") || i.ID == "").Count() > 0)
                return Math.Max(1, t.Weight / 5);
            return (int)(t.Weight + 5 * Math.Exp(-0.05 * t.Weight));
        }

        private void button4_Click(object sender, EventArgs e)
        {
            byte[] bytes = File.ReadAllBytes("db/resident/treasurebox.wdb");
            bytes.SetSubArray(0x3DE6, Encoding.UTF8.GetBytes(textBox1.Text.Trim()));
            MessageBox.Show(Encoding.UTF8.GetString(bytes, 0x3DE6, 7));
            File.WriteAllBytes("db/resident/treasurebox.wdb", bytes);
            int val = Int32.Parse(textBox1.Text.Substring(5));
            val++;
            textBox1.Text = textBox1.Text.Substring(0, 5) + val.ToString("00");

        }

        private void button5_Click(object sender, EventArgs evt)
        {
            EnemyStatDatabase enemies = new EnemyStatDatabase($"{randoPath}\\original\\db\\resident\\bt_chara_spec.wdb");
            byte[] bytes = File.ReadAllBytes($"{randoPath}\\original\\db\\resident\\bt_chara_spec.wdb");
            List<string> lines = new List<string>();

            List<string[]> csv = File.ReadAllLines("test.csv").Select(s => s.Split(',')).ToList();
            List<Tuple<string, string, string>> csvVals = csv.Select(str => new Tuple<string, string, string>(str[0].Replace("\"",""), str[3].Replace("\"", ""), str[10].Replace("\"", ""))).ToList();


            for (int i = 0; i < enemies.Enemies.count; i++)
            {
                List<string> list = csvVals.Where(t => t.Item2 == enemies.Enemies[i].HP.ToString() && t.Item3 == enemies.Enemies[i].CP.ToString()).Select(t => t.Item1).ToList();

                byte[] idBytes = bytes.SubArray(i * 0x20 + 0x90, 0x10);
                string id = Encoding.UTF8.GetString(idBytes).Replace("\0", "");
                lines.Add($"\"{id}\",{(list.Count == 1 ? list[0] : list.Count.ToString())}," +
                    $"{enemies.Enemies[i].HP},{enemies.Enemies[i].CP}," +
                    $"{enemies.Enemies[i].Level}");

            }
            File.WriteAllText("foundNew.csv", String.Join(",\n", lines));

            MessageBox.Show("Done.");
        }

        private void RandomizeDrops()
        {
            byte[] scene = File.ReadAllBytes($"{ randoPath}\\original\\db\\resident\\bt_scene.wdb");
            EnemyStatDatabase enemies = new EnemyStatDatabase($"{randoPath}\\original\\db\\resident\\bt_chara_spec.wdb");

            if (Flags.ItemFlags.Drops.FlagEnabled)
            {
                enemies.Enemies.ToList().ForEach(e =>
                {
                    do
                    {
                        RandomizeDrop(enemies, e, true);
                        RandomizeDrop(enemies, e, false);
                    } while (e.CommonDropPointer == e.RareDropPointer && enemies.ItemIDs[(int)e.CommonDropPointer].Value != "");
                });
            }

            if (Flags.ItemFlags.Shops.FlagEnabled)
            {
                List<int> list = scene.IndexesOf(Encoding.UTF8.GetBytes("key_shop_"));

                List<string> shops = list.Select(i => Encoding.UTF8.GetString(scene.SubArray(i, 11))).ToList();
                for (int i = 0; i < shops.Count; i++)
                {
                    shops[i] = shopsRemaining[i];
                }

                for (int i = 0; i < list.Count; i++)
                {
                    scene.SetSubArray(list[i], Encoding.UTF8.GetBytes(shops[i]));
                }
            }

            enemies.Save($"db\\resident\\bt_chara_spec.wdb");
            File.WriteAllBytes($"db\\resident\\bt_scene.wdb", scene);
        }

        private void RandomizeDrop(EnemyStatDatabase enemies, DataStoreEnemy enemy, bool common)
        {
            Item item = null;
            if (enemies.ItemIDs[(int)(common ? enemy.CommonDropPointer : enemy.RareDropPointer)].Value != "")
                item = Items.items.Where(i => i.ID ==
                    enemies.ItemIDs[(int)(common ? enemy.CommonDropPointer : enemy.RareDropPointer)].Value).FirstOrDefault();
            if (item != null)
            {
                if (item.ID == "")
                    throw new Exception("LUL");
                int rank = TieredItems.manager.GetRank(item, 1);
                if (rank != -1)
                {
                    Tuple<Item, int> newItem;
                    do
                    {
                        newItem = TieredItems.manager.Get(rank, tiered => GetDropWeight(tiered,enemy));
                        rank--;
                    } while ((newItem == null || blacklistedWeapons.Contains(newItem.Item1)) && rank >= 0);
                    if (newItem.Item1 == null)
                        return;
                    DataStoreString dataStr = new DataStoreString() { Value = newItem.Item1.ID };
                    if (!enemies.ItemIDs.Contains(dataStr))
                        enemies.ItemIDs.Add(dataStr, enemies.ItemIDs.GetTrueSize());
                    if (common)
                        enemy.CommonDropPointer = (uint)enemies.ItemIDs.IndexOf(dataStr);
                    else
                        enemy.RareDropPointer = (uint)enemies.ItemIDs.IndexOf(dataStr);
                }
            }
        }

        private int GetDropWeight(Tiered<Item> t,DataStoreEnemy enemy)
        {
            if (t.Items.Where(i => i.ID == "").Count() > 0)
                return 0;
            if (enemy.Level >= 50)
            {
                if (t.Items.Where(i => i.ID.StartsWith("material")).Count() > 0)
                    return 0;
                if (t.Items.Where(i => i.ID.StartsWith("it")).Count() > 0)
                    return Math.Max(1, t.Weight / 4);
                return t.Weight * 2;
            }
            if (t.Items.Where(i => i.ID.StartsWith("material")).Count() > 0)
                return  (int)(t.Weight + 58 * Math.Exp(-0.005 * t.Weight));
            return  Math.Max(1, t.Weight / 4);
        }

        private static string FF13FilePath = null;

        private void button6_Click(object sender, EventArgs e)
        {
            AutoSearchDir();
        }

        private void AutoSearchDir()
        {
            object returnVal = Registry.GetValue("HKEY_CURRENT_USER\\Software\\Valve\\Steam", "SteamPath", "c:/program files (x86)/steam");
            returnVal = returnVal.ToString().Replace("/", "\\");

            if (GetFF13Path(returnVal.ToString()) == null)
            {
                string text = File.ReadAllText(returnVal.ToString() + "/steamapps/libraryfolders.vdf");
                Regex regex = new Regex("\"\\d+\"\\s+\"(.*)\"");
                foreach (Match match in regex.Matches(text))
                {
                    if (match.Success)
                    {
                        if (GetFF13Path(match.Groups[1].Value) != null)
                            break;
                    }
                }
            }
        }

        public static string GetFF13Directory()
        {
            string path = GetFF13Path()?.Replace("\\\\","\\");
            if (!String.IsNullOrEmpty(path) && path.EndsWith("\\FFXiiiSteam.dll"))
                return path.Substring(0, path.Length - "\\FFXiiiSteam.dll".Length);
            return null;
        }

        private static string GetFF13Path(string directoryCheck = null)
        {
            if (String.IsNullOrEmpty(FF13FilePath) || !File.Exists(FF13FilePath) || !FF13FilePath.EndsWith("FINAL FANTASY XIII\\FFXiiiSteam.dll"))
            {
                FF13FilePath = null;
                if (File.Exists("ff13path.txt"))
                {
                    FF13FilePath = File.ReadAllText("ff13path.txt").Replace("/", "\\");
                    FF13FilePath = (String.IsNullOrEmpty(FF13FilePath) || !FF13FilePath.EndsWith("FINAL FANTASY XIII\\FFXiiiSteam.dll") ? null : FF13FilePath);
                    if (File.Exists(FF13FilePath))
                        return FF13FilePath;
                }
                if (directoryCheck != null && Directory.Exists(directoryCheck))
                {
                    string[] paths = Directory.GetFiles(directoryCheck, "FFXiiiSteam.dll", SearchOption.AllDirectories);
                    paths.ToList().ForEach(p => 
                    {
                        if (p.Replace("/", "\\").EndsWith("FINAL FANTASY XIII\\FFXiiiSteam.dll"))
                            FF13FilePath = p.Replace("/", "\\");
                    });                    
                }
            }

            if (FF13FilePath != null)
                File.WriteAllText("ff13path.txt", FF13FilePath);
            else
                File.WriteAllText("ff13path.txt", "");
            return FF13FilePath;
        }

        private void button7_Click(object sender, EventArgs e)
        {
            SetRandomSeed();
        }

        private void SetRandomSeed()
        {
            string seed = DateTime.Now.ToString();
            textBoxSeed.Text = RandomNum.randSeed().ToString();
        }

        private int GetIntSeed(string seed)
        {
            try
            {
                return Int32.Parse(seed.Trim());
            }
            catch (Exception)
            {
                byte[] bytes = Encoding.UTF8.GetBytes(seed.Trim());
                return (int)bytes.Sum(b => (int)Math.Pow(b + bytes[b % bytes.Length], 2.4)) * (int)bytes.Length - (int)bytes.Length;
            }
        }

        private void button8_Click(object sender, EventArgs e)
        {
            DialogResult result;
            if (GetFF13Directory() == null)
            {
                result = MessageBox.Show("Select the FFXiiiSteam.dll file. " +
                    "This can be located in the steam directory, then FINAL FANTASY XIII folder. " +
                    "The randomizer should have automatically detected the folder. " +
                    "But it looks like you need to locate it yourself.", "Where to find it?", MessageBoxButtons.OKCancel);
            }
            else
            {
                result = MessageBox.Show("Select the FFXiiiSteam.dll file. " +
                    "This can be located in the steam directory, then FINAL FANTASY XIII folder. " +
                    "The randomizer should have automatically detected the folder. " +
                    "If the path is incorrect, you need to locate it yourself.", "Where to find it?", MessageBoxButtons.OKCancel);
            }

            if (result == DialogResult.OK)
            {
                string filePath = "";
                using (OpenFileDialog openFileDialog = new OpenFileDialog())
                {
                    openFileDialog.InitialDirectory = "c:\\";
                    openFileDialog.Filter = "FF13 Steam dll (FFXiiiSteam.dll)|FFXiiiSteam.dll";
                    openFileDialog.FilterIndex = 0;
                    openFileDialog.RestoreDirectory = true;

                    if (openFileDialog.ShowDialog() == DialogResult.OK)
                    {
                        //Get the path of specified file
                        filePath = openFileDialog.FileName;
                    }
                }
                if (filePath.EndsWith("FFXiiiSteam.dll"))
                {
                    File.WriteAllText("ff13path.txt", filePath);
                    
                    textBox2.Text = GetFF13Directory();
                }
            }
        }

        private void button9_Click(object sender, EventArgs e)
        {
            ExtractFiles();

            RandomNum.SetSeed(GetIntSeed(textBoxSeed.Text));

            MessageBox.Show("Randomizing...Please Wait. After pressing OK.");

            RandomizeCrystarium();
            RandomizeTreasures();
            RandomizeDrops();

            insertFiles(true);

            UserFlagsSeed.Export(randoPath + "\\FlagsSeeds", textBoxSeed.Text.Trim(), version);

            MessageBox.Show("Complete! Ready to play! Whenever you need to uninstall the rando, come back to this program and go to the Uninstall tab!");
        }

        private string randoPath
        {
            get => GetFF13Directory() + "\\FF13Randomizer";
        }

        private bool NeedsExtracting()
        {
            foreach (string path in fileNamesModified)
            {
                if (!File.Exists(randoPath + "\\original\\" + path))
                    return true;
            }
            return false;
        }

        private void ExtractFiles(bool force=false)
        {
            if (!force && !NeedsExtracting())
                return;
            MessageBox.Show("Extracting FF13 files!!!\nThis will take a while and should only be done the first time.\nIt'll take a while. Maybe a few minutes...");
            
            if (Directory.Exists(randoPath))
            {
                if (File.Exists(randoPath + "\\filelistu.win32.bin"))
                    FullUninstall();
                Directory.GetDirectories(randoPath).Where(d=>!d.EndsWith("FlagsSeeds")).ToList().ForEach(d => Directory.Delete(d, true));
            }
            Directory.CreateDirectory(randoPath);
            File.Copy(GetFF13Directory() + "\\white_data\\sys\\filelistu.win32.bin", randoPath + "\\filelistu.win32.bin",true);
            File.Copy(GetFF13Directory() + "\\white_data\\sys\\white_imgu.win32.bin", randoPath + "\\white_imgu.win32.bin",true);

            runCommand($"ff13tool.exe -x \"{randoPath + "\\filelistu.win32.bin"}\" \"{randoPath + "\\white_imgu.win32.bin"}\"");

            foreach (string path in fileNamesModified)
            {
                Directory.CreateDirectory(randoPath + "\\original\\" + Path.GetDirectoryName(path.Replace("/", "\\")));
                Directory.CreateDirectory(Path.GetDirectoryName(path.Replace("/", "\\")));
                File.Copy(randoPath + "\\white_imgu\\" + path.Replace("/", "\\"), randoPath + "\\original\\" + path.Replace("/", "\\"));
            }

            Directory.Delete(randoPath + "\\white_imgu", true);

            MessageBox.Show("Finished Extracting!");
        }

        private void button10_Click(object sender, EventArgs e)
        {
            if (!Directory.Exists(randoPath))
            {
                MessageBox.Show("Randomizer hasn't extracted the files...no reason to uninstall.");
                return;
            }
            MessageBox.Show("Begin Uninstalling...");
            insertFiles(false);
            MessageBox.Show("Finished Uninstalling!");

        }
        private void button11_Click(object sender, EventArgs e)
        {
            FullUninstall();
        }

        private void FullUninstall()
        {
            if (!Directory.Exists(randoPath))
            {
                MessageBox.Show("Randomizer hasn't extracted the files...no reason to uninstall.");
                return;
            }
            MessageBox.Show("Begin Uninstalling...");
            File.Copy(randoPath + "\\filelistu.win32.bin", GetFF13Directory() + "\\white_data\\sys\\filelistu.win32.bin", true);
            File.Copy(randoPath + "\\white_imgu.win32.bin", GetFF13Directory() + "\\white_data\\sys\\white_imgu.win32.bin", true);
            MessageBox.Show("Finished Uninstalling!");
        }

        private void button9_Click_1(object sender, EventArgs e)
        {
            FullUninstall();
            ExtractFiles(true);
        }

        private void button10_Click_1(object sender, EventArgs e)
        {
            string filePath = "";
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.InitialDirectory = randoPath+"\\FlagsSeeds";
                openFileDialog.Filter = "FF13 Flags Seed (*.ff13fs)|*.ff13fs";
                openFileDialog.FilterIndex = 0;
                openFileDialog.RestoreDirectory = true;

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    //Get the path of specified file
                    filePath = openFileDialog.FileName;
                }
            }
            if (filePath != "")
            {
                textBoxSeed.Text = UserFlagsSeed.Import(filePath, version);
            }
        }
    }
}
