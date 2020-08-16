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
using Utilities;

namespace FF13Randomizer
{
    public partial class FormMain : Form
    {
        public static string version = "1.7.0";
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
            "db/resident/bt_scene.wdb",
            "db/resident/charafamily.wdb",
            "db/resident/shop.wdb",
            "db/resident/bt_ability.wdb",
            "db/resident/item_weapon.wdb",
            "db/resident/item.wdb",
            #region Sound
            //"sound/pack/8000/usa/music_100rosh.win32.scd",
            //"sound/pack/8000/usa/music_101ldun_f.win32.scd", silent
            "sound/pack/8000/usa/music_102far3_b.win32.scd",
            //"sound/pack/8000/usa/music_105kibou.win32.scd",
            "sound/pack/8000/usa/music_105kyoufu.win32.scd",
            //"sound/pack/8000/usa/music_105saigo.win32.scd",
            //"sound/pack/8000/usa/music_105titarr.win32.scd",
            "sound/pack/8000/usa/music_106ofa2_b.win32.scd",
            "sound/pack/8000/usa/music_12snow_1.win32.scd",
            "sound/pack/8000/usa/music_13gekai_f.win32.scd",
            //"sound/pack/8000/usa/music_14fmv.win32.scd",
            "sound/pack/8000/usa/music_150sinpi.win32.scd",
            "sound/pack/8000/usa/music_151run.win32.scd",
            "sound/pack/8000/usa/music_152magni.win32.scd",
            //"sound/pack/8000/usa/music_153fuan.win32.scd",
            "sound/pack/8000/usa/music_154syuge2.win32.scd",
            "sound/pack/8000/usa/music_155far1or.win32.scd",
            "sound/pack/8000/usa/music_156far3or.win32.scd",
            "sound/pack/8000/usa/music_158opn1_i.win32.scd",
            "sound/pack/8000/usa/music_159opn_b.win32.scd",
            "sound/pack/8000/usa/music_160field.win32.scd",
            "sound/pack/8000/usa/music_161bo_fi.win32.scd",
            "sound/pack/8000/usa/music_162seifu.win32.scd",
            //"sound/pack/8000/usa/music_163gso.win32.scd",
            //"sound/pack/8000/usa/music_164fmv_2.win32.scd",
            //"sound/pack/8000/usa/music_165vin_ch.win32.scd",
            //"sound/pack/8000/usa/music_166vin_u2.win32.scd",
            "sound/pack/8000/usa/music_167choro.win32.scd",
            //"sound/pack/8000/usa/music_168faru_l.win32.scd",
            "sound/pack/8000/usa/music_16gfaru_b.win32.scd",
            //"sound/pack/8000/usa/music_17pls.win32.scd",
            //"sound/pack/8000/usa/music_18vin_uta.win32.scd",
            //"sound/pack/8000/usa/music_19hanabi.win32.scd",
            //"sound/pack/8000/usa/music_20eien.win32.scd",
            "sound/pack/8000/usa/music_21sn_sera.win32.scd",
            "sound/pack/8000/usa/music_26psicom.win32.scd",
            "sound/pack/8000/usa/music_27ansoku.win32.scd",
            "sound/pack/8000/usa/music_28shouk_b.win32.scd",
            "sound/pack/8000/usa/music_29kihei.win32.scd",
            //"sound/pack/8000/usa/music_30hot.win32.scd",
            //"sound/pack/8000/usa/music_31grv.win32.scd",
            "sound/pack/8000/usa/music_32vpek_f.win32.scd",
            "sound/pack/8000/usa/music_33light_1.win32.scd",
            "sound/pack/8000/usa/music_34comical.win32.scd",
            "sound/pack/8000/usa/music_36gapra_f.win32.scd",
            "sound/pack/8000/usa/music_39hope_1.win32.scd",
            "sound/pack/8000/usa/music_40monst_b.win32.scd",
            //"sound/pack/8000/usa/music_41sra.win32.scd",
            "sound/pack/8000/usa/music_42snls_f.win32.scd",
            "sound/pack/8000/usa/music_43sazh_1.win32.scd",
            "sound/pack/8000/usa/music_44sazh_2a.win32.scd",
            "sound/pack/8000/usa/music_44sazh_3b.win32.scd",
            "sound/pack/8000/usa/music_45kinpaku.win32.scd",
            "sound/pack/8000/usa/music_46vani_1.win32.scd",
            "sound/pack/8000/usa/music_47ppm.win32.scd",
            //"sound/pack/8000/usa/music_49farusi.win32.scd",
            //"sound/pack/8000/usa/music_50abs.win32.scd",
            "sound/pack/8000/usa/music_54snow_2.win32.scd",
            //"sound/pack/8000/usa/music_55hope_fu.win32.scd",
            "sound/pack/8000/usa/music_56fang.win32.scd",
            "sound/pack/8000/usa/music_57snow_3.win32.scd",
            "sound/pack/8000/usa/music_59hope_ie.win32.scd",
            //"sound/pack/8000/usa/music_61prd.win32.scd",
            "sound/pack/8000/usa/music_62nati_f.win32.scd",
            "sound/pack/8000/usa/music_64choco_c.win32.scd",
            //"sound/pack/8000/usa/music_65kanasii.win32.scd",
            //"sound/pack/8000/usa/music_67va_sazh.win32.scd",
            //"sound/pack/8000/usa/music_68tak.win32.scd",
            "sound/pack/8000/usa/music_6gameover.win32.scd",
            "sound/pack/8000/usa/music_70daisuri.win32.scd",
            //"sound/pack/8000/usa/music_71kanta_f.win32.scd",
            //"sound/pack/8000/usa/music_72waiban.win32.scd",
            "sound/pack/8000/usa/music_74faru1_b.win32.scd",
            //"sound/pack/8000/usa/music_76pro.win32.scd",
            //"sound/pack/8000/usa/music_77fark_f.win32.scd",
            //"sound/pack/8000/usa/music_78rainz_2.win32.scd",
            "sound/pack/8000/usa/music_81gto.win32.scd",
            //"sound/pack/8000/usa/music_83s_gp_f.win32.scd",
            "sound/pack/8000/usa/music_84daihe_f.win32.scd",
            //"sound/pack/8000/usa/music_85gp_b.win32.scd",
            "sound/pack/8000/usa/music_86choco_f.win32.scd",
            "sound/pack/8000/usa/music_89vani_2.win32.scd",
            //"sound/pack/8000/usa/music_90ligh_sn.win32.scd",
            "sound/pack/8000/usa/music_91teiji_f.win32.scd",
            "sound/pack/8000/usa/music_92saiha_f.win32.scd",
            //"sound/pack/8000/usa/music_93ragu_se.win32.scd",
            //"sound/pack/8000/usa/music_96grp.win32.scd",
            "sound/pack/8000/usa/music_97eden_pa.win32.scd",
            //"sound/pack/8000/usa/music_98hikari.win32.scd",
            "sound/pack/8000/usa/music_bat_short.win32.scd",
            "sound/pack/8000/usa/music_bossa.win32.scd",
            //"sound/pack/8000/usa/music_dark.win32.scd",
            //"sound/pack/8000/usa/music_fanfare.win32.scd",
            "sound/pack/8000/usa/music_handsnow.win32.scd",
            "sound/pack/8000/usa/music_handsnow2.win32.scd",
            "sound/pack/8000/usa/music_madfade.win32.scd",
            "sound/pack/8000/usa/music_result.win32.scd",
            //"sound/pack/8000/usa/music_snowfade.win32.scd",
            "sound/pack/8000/usa/music_theme_b.win32.scd",
            "sound/pack/8000/usa/music_title.win32.scd",
            "sound/pack/8000/usa/music_white_at.win32.scd",
            "sound/pack/8000/usa/music_white_e3.win32.scd"
#endregion
        };

        public FormMain()
        {
            if (!File.Exists("ff13tool.exe"))
            {
                MessageBox.Show("ff13tool is missing! Chances are it wasn't extracted correctly! Closing program...");
                this.Close();
            }


            if (GetFF13Directory() == null)
                AutoSearchDir();

            Directory.CreateDirectory("logs");

            if (GetFF13Directory()!=null)
            {
                Directory.CreateDirectory(RandoPath+"\\FlagsSeeds");
                if (Directory.GetFiles(RandoPath+"\\FlagsSeeds").Count() > 0)
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
            new Tweaks();

            InitializeComponent();

            tabControl1.SelectedIndexChanged += TabControl1_TabIndexChanged;

            addFlags(tabPageCrystarium, FlagType.Crystarium);
            addFlags(tabPageEnemies, FlagType.Enemies);
            addFlags(tabPageAbilities, FlagType.Abilities);
            addFlags(tabPageItems, FlagType.Items);
            addFlags(tabPageOther, FlagType.Other);
            addFlags(tabPageBoosts, FlagType.Boost);
            addFlags(tabPageChallenges, FlagType.Challenge);
            if (Directory.Exists(RandoPath))
            {
                addHistory();
            }

            defaultSettings();

            SetRandomSeed();

            textBox2.Text = GetFF13Directory() == null ? "" : GetFF13Directory();

            tabControl1.SelectedTab = tabPageBasics;

            labelVersion.Text = "Version: " + version;

#if !DEBUG
            tabControl1.TabPages.Remove(tabPageDebug);
#endif
        }

        private void addFlags(TabPage page, FlagType type)
        {
            TableLayoutPanel tableLayout = new TableLayoutPanel();
            tableLayout.Dock = DockStyle.Fill;
            tableLayout.ColumnCount = 1;
            tableLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100));
            tableLayout.CellBorderStyle = TableLayoutPanelCellBorderStyle.Single;
            tableLayout.AutoScroll = true; 
            page.Controls.Add(tableLayout);               
           

            foreach (Flag flag in Flags.flags)
            {
                addFlag(type, tableLayout, flag);
            }
            foreach (Flag flag in Tweaks.tweaks)
            {
                addFlag(type, tableLayout, flag);
            }
        }

        private void addFlag(FlagType type, TableLayoutPanel tableLayout, Flag flag)
        {
            if (flag.FlagType == type)
            {
                addFlagEvents(flag);
                flag.Dock = DockStyle.Fill;

                flag.OnChangedEvent();
                flag.OnChanged += Flag_OnChanged;

                tableLayout.Controls.Add(flag);
                tableLayout.RowStyles.Add(new RowStyle(SizeType.Absolute, flag.FlagHeight + 5));
            }
        }

        private void addHistory()
        {
            List<UserFlagsSeed> imported = UserFlagsSeed.Import(RandoPath);
            tabPageHistory.Controls.Clear();
            TableLayoutPanel tableLayout = new TableLayoutPanel();
            tableLayout.Dock = DockStyle.Fill;
            tableLayout.ColumnCount = 1;
            tableLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100));
            tableLayout.CellBorderStyle = TableLayoutPanelCellBorderStyle.Single;
            tableLayout.AutoScroll = true;
            tabPageHistory.Controls.Add(tableLayout);

            foreach (UserFlagsSeed usf in imported)
            {
                HistoryView view = new HistoryView(usf);
                view.Dock = DockStyle.Fill;
                view.OnSet += View_OnSet;
                tableLayout.Controls.Add(view);
            }
        }

        private void View_OnSet(object sender, EventArgs e)
        {
            HistoryView view = (HistoryView)sender;
            if (!String.IsNullOrEmpty(view.FlagString))
            {
                bool success = Flags.Import(view.FlagString, false);
                if (success)
                {
                    MessageBox.Show("Successfully imported flag string and seed!");
                }
                else
                {
                    MessageBox.Show("Failed to import flag string and seed! Resetting flags to default!");
                    defaultSettings();
                }
            }
            textBoxSeed.Text = view.Seed;
        }

        private void TabControl1_TabIndexChanged(object sender, EventArgs e)
        {
            labelFlagsSelected.Text = "Flags Selected: " + Flags.flags.Sum(f => f.FlagEnabled ? 1 : 0);
            bool allow = GetFF13Directory() != null;
            buttonRandomize.Enabled = allow;
            buttonFullUninstall.Enabled = allow;
        }

        private void Flag_OnChanged(object sender, EventArgs e)
        {
            Control control = (Control)sender;
            while (!(control is Flag))
            {
                control = control.Parent;
            }
            textCurrentFlags.Text = Flags.GetFlagString();
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

        private void button1_Click(object sender, EventArgs e)
        {
            //RandomizeCrystarium();
            MessageBox.Show("Done.");
        }

        

        private static BackgroundWorker commandWorker;
        private static int workerStart, workerMax,maxLines,curLines;

        private void runCommand(string command, bool showConsole = true, BackgroundWorker backgroundWorker=null,int cur=0, int max=0,int maxLine=0)
        {
            ProcessStartInfo procStartInfo = new ProcessStartInfo("cmd", "/c " + command);

            procStartInfo.RedirectStandardOutput = true;
            procStartInfo.UseShellExecute = false;
            procStartInfo.Verb = "runas";

            procStartInfo.CreateNoWindow = true;

            commandWorker = backgroundWorker;
            workerStart = cur;
            workerMax = max;
            curLines = 0;
            maxLines = maxLine;
            // wrap IDisposable into using (in order to release hProcess) 
            using (Process process = new Process())
            {                
                process.OutputDataReceived += new DataReceivedEventHandler(MyProcOutputHandler);
                process.StartInfo = procStartInfo;
                process.Start();

                process.BeginOutputReadLine();
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
                //Console.WriteLine(outLine.Data);
                curLines++;
                if (commandWorker != null)
                    commandWorker.ReportProgress(workerStart + (curLines * (workerMax - workerStart) / maxLines));
            }
        }

        private void insertFiles(BackgroundWorker backgroundWorker, bool newFiles)
        {
            foreach (string path in fileNamesModified)
            {
                if (!newFiles)
                {
                    File.Copy(RandoPath + "\\original\\" + path.Replace("/", "\\"), path.Replace("/", "\\"), true);
                }
                string filePath = path.Replace("/", "\\");
                if (!File.Exists(filePath))
                    continue;
                string command = "ff13tool.exe -i " +
                    $"\"{GetFF13Directory() + "\\white_data\\sys\\filelistu.win32.bin"}\" " +
                    $"\"{GetFF13Directory() + "\\white_data\\sys\\white_imgu.win32.bin"}\" "+
                    $"\"{filePath}\"";
                runCommand(command, false);
                backgroundWorker.ReportProgress(fileNamesModified.ToList().IndexOf(path) * 100 / fileNamesModified.Length);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //MessageBox.Show(TieredItems.manager.GetRank(Items.Trapezohedron).ToString());
            int rank = TieredItems.manager.GetRank(Items.TetradicCrown);
            Console.WriteLine("\n"+rank.ToString());
            int rankAdj = Flags.ItemFlags.Drops.Range.Value;
            if (rankAdj > 0)
                rank = RandomNum.RandInt(Math.Max(0, rank - rankAdj), Math.Min(TieredItems.manager.GetHighBound(), rank + rankAdj));            
            Console.WriteLine(rank.ToString());
            Tuple<Item, int> item;
            do
            {
                item = TieredItems.manager.Get(rank, 1,t=> 
                {

                    if (t.Items.Where(i => i.ID == "").Count() > 0)
                        return 0;
                    float mult = 1 + .01f * (float)Math.Pow(68 - 50, .8f);
                    if (t.Items.Where(i => i.ID.StartsWith("material_o")).Count() > 0)
                        return (int)(t.Weight * 3 * mult);
                    if (t.Items.Where(i => i.ID.StartsWith("material")).Count() > 0)
                        return 0;
                    if (t.Items.Where(i => i.ID.StartsWith("it")).Count() > 0)
                        return Math.Max(1, t.Weight / 4);
                    return (int)(t.Weight * 2 * mult);
                });
                rank--;
            } while (item.Item1 ==null);
            MessageBox.Show(item.Item1.Name + " x " + item.Item2);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            //RandomizeTreasures();
            MessageBox.Show("Done.");

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
            /*EnemyStatDatabase enemies = new EnemyStatDatabase($"{RandoPath}\\original\\db\\resident\\bt_chara_spec.wdb");
            byte[] bytes = File.ReadAllBytes($"{RandoPath}\\original\\db\\resident\\bt_chara_spec.wdb");
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
            */
        }

        private void ShuffleMusic(BackgroundWorker backgroundWorker)
        {
            /*List<string> musicList = fileNamesModified.Where(p => p.Contains("music_")).ToList();
            musicList.ForEach(p => File.Copy($"{randoPath}\\original\\{p}", p,true));            
            if (Flags.Other.Music.FlagEnabled)
            {
                int count = 0;
                musicList.Shuffle((p1, p2) =>
                {
                    count++;
                    if (p1 == p2)
                        return;
                    File.Move(p1, p1 + ".temp");
                    File.Move(p2, p1);
                    File.Move(p1 + ".temp", p2);
                    backgroundWorker.ReportProgress(count * 100 / musicList.Count);
                });
            }*/
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
                    FF13FilePath = (String.IsNullOrEmpty(FF13FilePath) || !File.Exists(FF13FilePath.Substring(0, FF13FilePath.LastIndexOf("\\")) + "\\white_data\\prog\\win\\bin\\ffxiiiimg.exe")) ? null : FF13FilePath;
                    if (File.Exists(FF13FilePath))
                        return FF13FilePath;
                }
                if (directoryCheck != null && Directory.Exists(directoryCheck))
                {
                    string[] paths = Directory.GetFiles(directoryCheck, "FFXiiiSteam.dll", SearchOption.AllDirectories);
                    paths.ToList().ForEach(p =>
                    {
                        p = p.Replace("/", "\\").Replace("\\\\", "\\");
                        string path = p.Substring(0, p.LastIndexOf("\\")) + "\\white_data\\prog\\win\\bin\\ffxiiiimg.exe";
                        if (File.Exists(path))
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
            textBoxSeed.Text = RandomNum.RandSeed().ToString();
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
                        filePath = openFileDialog.FileName.Replace("\\\\", "\\");
                    }
                }
                if (filePath.EndsWith("FFXiiiSteam.dll"))
                {
                    File.WriteAllText("ff13path.txt", filePath);
                    FF13FilePath = null;
                    textBox2.Text = GetFF13Directory();
                }
            }
        }

        private void button9_Click(object sender, EventArgs e)
        {

            new ProgressForm("Extracting files...", bw => ExtractFiles(bw)).ShowDialog();

            int seed = GetIntSeed(textBoxSeed.Text);
            foreach (Flag flag in Flags.flags)
            {
                flag.ResetRandom(seed);
            }

            foreach(string path in fileNamesModified)
            {
                if (File.Exists(path))
                    File.Delete(path);
            }

            RandomizerManager randomizers = new RandomizerManager();
            randomizers.Add(new RandoItems(this, randomizers));
            randomizers.Add(new RandoCrystarium(this, randomizers));
            randomizers.Add(new RandoTreasure(this, randomizers));
            randomizers.Add(new RandoShops(this, randomizers));
            randomizers.Add(new RandoEnemies(this, randomizers));
            randomizers.Add(new RandoAbilities(this, randomizers));
            randomizers.Add(new RandoEquip(this, randomizers));
            randomizers.Add(new RandoMusic(this, randomizers));
            randomizers.Add(new RandoRunSpeed(this, randomizers));

            new ProgressForm("Loading data...", bw => LoadRandos(randomizers, bw)).ShowDialog();

            foreach(Randomizer rando in randomizers)
            {
                new ProgressForm(rando.GetProgressMessage(), bw => rando.Randomize(bw)).ShowDialog();
            }

            new ProgressForm("Saving data...", bw => SaveRandos(randomizers, bw)).ShowDialog();


            new ProgressForm("Inserting files...", bw => insertFiles(bw, true)).ShowDialog();

            UserFlagsSeed.Export(RandoPath, textBoxSeed.Text.Trim(), version);
            addHistory();
            
            //UserFlagsSeed.Export("logs", textBoxSeed.Text.Trim(), version);

            MessageBox.Show("Complete! Ready to play! Whenever you need to uninstall the rando, come back to this program and go to the Uninstall tab!");
        }

        public void LoadRandos(List<Randomizer> randomizers, BackgroundWorker worker)
        {
            for(int i = 0; i < randomizers.Count; i++)
            {
                randomizers[i].Load();
                worker.ReportProgress((i + 1) * 100 / randomizers.Count);
            }
        }
        public void SaveRandos(List<Randomizer> randomizers, BackgroundWorker worker)
        {
            for (int i = 0; i < randomizers.Count; i++)
            {
                randomizers[i].Save();
                worker.ReportProgress((i + 1) * 100 / randomizers.Count);
            }
        }

        public string RandoPath
        {
            get => GetFF13Directory() + "\\FF13Randomizer";
        }

        private bool NeedsExtracting()
        {
            foreach (string path in fileNamesModified)
            {
                if (!File.Exists(RandoPath + "\\original\\" + path))
                    return true;
            }
            return false;
        }

        private void ExtractFiles(BackgroundWorker backgroundWorker, bool force=false)
        {
            if (File.Exists(RandoPath + "\\filelistu.win32.bin"))
                new ProgressForm("Fully reverting to vanilla files...", bw => FullUninstall(bw)).ShowDialog();

            if (!force && !NeedsExtracting())
                return;
            
            if (Directory.Exists(RandoPath))
            {
                Directory.GetDirectories(RandoPath).Where(d=>!d.EndsWith("FlagsSeeds")).ToList().ForEach(d => Directory.Delete(d, true));
            }
            backgroundWorker.ReportProgress(10);
            Directory.CreateDirectory(RandoPath);
            File.Copy(GetFF13Directory() + "\\white_data\\sys\\filelistu.win32.bin", RandoPath + "\\filelistu.win32.bin",true);
            backgroundWorker.ReportProgress(20);
            File.Copy(GetFF13Directory() + "\\white_data\\sys\\white_imgu.win32.bin", RandoPath + "\\white_imgu.win32.bin",true);
            backgroundWorker.ReportProgress(30);

            runCommand($"ff13tool.exe -x \"{RandoPath + "\\filelistu.win32.bin"}\" \"{RandoPath + "\\white_imgu.win32.bin"}\"", false, backgroundWorker, 30, 70, 14106);
            backgroundWorker.ReportProgress(70);

            foreach (string path in fileNamesModified)
            {
                Directory.CreateDirectory(RandoPath + "\\original\\" + Path.GetDirectoryName(path.Replace("/", "\\")));
                Directory.CreateDirectory(Path.GetDirectoryName(path.Replace("/", "\\")));
                File.Copy(RandoPath + "\\white_imgu\\" + path.Replace("/", "\\"), RandoPath + "\\original\\" + path.Replace("/", "\\"));
                
            }
            backgroundWorker.ReportProgress(85);

            Directory.Delete(RandoPath + "\\white_imgu", true);
        }

        private void button10_Click(object sender, EventArgs e)
        {
            if (!Directory.Exists(RandoPath))
            {
                MessageBox.Show("Randomizer hasn't extracted the files...no reason to uninstall.");
                return;
            }
            new ProgressForm("Reverting to vanilla files...", bw => insertFiles(bw, false)).ShowDialog();

        }
        private void button11_Click(object sender, EventArgs e)
        {
            new ProgressForm("Fully reverting to vanilla files...", bw => FullUninstall(bw)).ShowDialog();
        }

        private void defaultSettings()
        {
            presetDiversity_Click(null, null);
            presetPerseverance_Click(null, null);
            Tweaks.Challenges.BoostLevel.Range.Value = 10;
        }

        private void presetEvenedOdds_Click(object sender, EventArgs e)
        {
            Flags.CrystariumFlags.NewAbilities.FlagEnabled = true;
            Flags.CrystariumFlags.NewAbilities.ExtraSelected2 = true;
            Flags.CrystariumFlags.ShuffleNodes.FlagEnabled = true;
            Flags.CrystariumFlags.RandStats.FlagEnabled = true;
            Flags.CrystariumFlags.RandStats.Range.Value = 15;
            Flags.EnemyFlags.RandStats.FlagEnabled = true;
            Flags.EnemyFlags.RandStats.Range.Value = 10;
            Flags.ItemFlags.Treasures.FlagEnabled = true;
            Flags.ItemFlags.Treasures.Range.Value = 5;
            Flags.ItemFlags.Drops.FlagEnabled = true;
            Flags.ItemFlags.Drops.Range.Value = 5;
            Flags.ItemFlags.ShopLocations.FlagEnabled = true;
            Flags.Other.Music.FlagEnabled = true;

            Flags.CrystariumFlags.NewAbilities.ExtraSelected = false;
            Flags.EnemyFlags.Resistances.FlagEnabled = false;
            Flags.EnemyFlags.Debuffs.FlagEnabled = false;
            Flags.EnemyFlags.RandLevel.FlagEnabled = false;
            Flags.EnemyFlags.RandLevel.Range.Value = 0;
            Flags.AbilityFlags.ATBCost.FlagEnabled = false;
            Flags.AbilityFlags.ATBCost.Range.Value = 0;
            Flags.AbilityFlags.TPCost.FlagEnabled = false;
            Flags.AbilityFlags.TPCost.Range.Value = 0;
            Flags.ItemFlags.Shops.FlagEnabled = false;
            Flags.ItemFlags.Shops.ExtraSelected = false;
            Flags.ItemFlags.Shops.ExtraSelected2 = false;
            Flags.Other.RunSpeed.FlagEnabled = false;
            Flags.Other.RunSpeed.Range.Value = 0;

            if (sender != null)
                MessageBox.Show("Applied!");
        }

        private void presetDiversity_Click(object sender, EventArgs e)
        {
            Flags.CrystariumFlags.NewAbilities.FlagEnabled = true;
            Flags.CrystariumFlags.NewAbilities.ExtraSelected = true;
            Flags.CrystariumFlags.ShuffleNodes.FlagEnabled = true;
            Flags.CrystariumFlags.RandStats.FlagEnabled = true;
            Flags.CrystariumFlags.RandStats.Range.Value = 25;
            Flags.EnemyFlags.RandStats.FlagEnabled = true;
            Flags.EnemyFlags.RandStats.Range.Value = 25;
            Flags.EnemyFlags.RandLevel.FlagEnabled = true;
            Flags.EnemyFlags.RandLevel.Range.Value = 10;
            Flags.ItemFlags.Treasures.FlagEnabled = true;
            Flags.ItemFlags.Treasures.Range.Value = 20;
            Flags.ItemFlags.Drops.FlagEnabled = true;
            Flags.ItemFlags.Drops.Range.Value = 20;
            Flags.ItemFlags.ShopLocations.FlagEnabled = true;
            Flags.ItemFlags.Shops.FlagEnabled = true;
            Flags.ItemFlags.Shops.ExtraSelected = true;
            Flags.ItemFlags.Shops.ExtraSelected2 = true;
            Flags.Other.Music.FlagEnabled = true;
            Flags.Other.RunSpeed.FlagEnabled = true;
            Flags.Other.RunSpeed.Range.Value = 10;

            Flags.CrystariumFlags.NewAbilities.ExtraSelected2 = false;
            Flags.EnemyFlags.Resistances.FlagEnabled = false;
            Flags.EnemyFlags.Debuffs.FlagEnabled = false;
            Flags.AbilityFlags.ATBCost.FlagEnabled = false;
            Flags.AbilityFlags.ATBCost.Range.Value = 0;
            Flags.AbilityFlags.TPCost.FlagEnabled = false;
            Flags.AbilityFlags.TPCost.Range.Value = 0;

            if (sender != null)
                MessageBox.Show("Applied!");
        }

        private void presetDirtyFighting_Click(object sender, EventArgs e)
        {
            Flags.CrystariumFlags.NewAbilities.FlagEnabled = true;
            Flags.CrystariumFlags.NewAbilities.ExtraSelected = true;
            Flags.CrystariumFlags.ShuffleNodes.FlagEnabled = true;
            Flags.CrystariumFlags.RandStats.FlagEnabled = true;
            Flags.CrystariumFlags.RandStats.Range.Value = 50;
            Flags.EnemyFlags.Debuffs.FlagEnabled = true;
            Flags.EnemyFlags.RandStats.FlagEnabled = true;
            Flags.EnemyFlags.RandStats.Range.Value = 50;
            Flags.EnemyFlags.RandLevel.FlagEnabled = true;
            Flags.EnemyFlags.RandLevel.Range.Value = 35;
            Flags.AbilityFlags.ATBCost.FlagEnabled = true;
            Flags.AbilityFlags.ATBCost.Range.Value = 2;
            Flags.AbilityFlags.TPCost.FlagEnabled = true;
            Flags.AbilityFlags.TPCost.Range.Value = 2;
            Flags.ItemFlags.Treasures.FlagEnabled = true;
            Flags.ItemFlags.Treasures.Range.Value = 50;
            Flags.ItemFlags.Drops.FlagEnabled = true;
            Flags.ItemFlags.Drops.Range.Value = 50;
            Flags.ItemFlags.ShopLocations.FlagEnabled = true;
            Flags.ItemFlags.Shops.FlagEnabled = true;
            Flags.Other.Music.FlagEnabled = true;
            Flags.Other.RunSpeed.FlagEnabled = true;
            Flags.Other.RunSpeed.Range.Value = 25;

            Flags.CrystariumFlags.NewAbilities.ExtraSelected2 = false;
            Flags.EnemyFlags.Resistances.FlagEnabled = false;
            Flags.ItemFlags.Shops.ExtraSelected = false;
            Flags.ItemFlags.Shops.ExtraSelected2 = false;

            if (sender != null)
                MessageBox.Show("Applied!");
        }

        private void presetRuthless_Click(object sender, EventArgs e)
        {
            Flags.CrystariumFlags.NewAbilities.FlagEnabled = true;
            Flags.CrystariumFlags.NewAbilities.ExtraSelected = true;
            Flags.CrystariumFlags.ShuffleNodes.FlagEnabled = true;
            Flags.CrystariumFlags.RandStats.FlagEnabled = true;
            Flags.CrystariumFlags.RandStats.Range.Value = 100;
            Flags.EnemyFlags.Resistances.FlagEnabled = true;
            Flags.EnemyFlags.Debuffs.FlagEnabled = true;
            Flags.EnemyFlags.RandStats.FlagEnabled = true;
            Flags.EnemyFlags.RandStats.Range.Value = 100;
            Flags.EnemyFlags.RandLevel.FlagEnabled = true;
            Flags.EnemyFlags.RandLevel.Range.Value = 50;
            Flags.AbilityFlags.ATBCost.FlagEnabled = true;
            Flags.AbilityFlags.ATBCost.Range.Value = 5;
            Flags.AbilityFlags.TPCost.FlagEnabled = true;
            Flags.AbilityFlags.TPCost.Range.Value = 4;
            Flags.ItemFlags.Treasures.FlagEnabled = true;
            Flags.ItemFlags.Treasures.Range.Value = 100;
            Flags.ItemFlags.Drops.FlagEnabled = true;
            Flags.ItemFlags.Drops.Range.Value = 100;
            Flags.ItemFlags.ShopLocations.FlagEnabled = true;
            Flags.ItemFlags.Shops.FlagEnabled = true;
            Flags.Other.Music.FlagEnabled = true;
            Flags.Other.RunSpeed.FlagEnabled = true;
            Flags.Other.RunSpeed.Range.Value = 50;

            Flags.CrystariumFlags.NewAbilities.ExtraSelected2 = false;
            Flags.ItemFlags.Shops.ExtraSelected = false;
            Flags.ItemFlags.Shops.ExtraSelected2 = false;

            if (sender != null)
                MessageBox.Show("Applied!");
        }

        private void presetSalvation_Click(object sender, EventArgs e)
        {
            Tweaks.Boosts.HalfSecondaryCPCost.FlagEnabled = true;
            Tweaks.Boosts.ScaledCPCost.FlagEnabled = true;
            Tweaks.Boosts.RunSpeedMultiplier.FlagEnabled = true;
            Tweaks.Boosts.RunSpeedMultiplier.Range.Value = 25;

            Tweaks.Challenges.BoostLevel.FlagEnabled = false;
            Tweaks.Challenges.BoostLevel.Range.Value = 0;
            Tweaks.Challenges.Stats1StageBehind.FlagEnabled = false;
            Tweaks.Challenges.NoShops.FlagEnabled = false;

            if (sender != null)
                MessageBox.Show("Applied!");
        }

        private void presetPerseverance_Click(object sender, EventArgs e)
        {
            Tweaks.Boosts.HalfSecondaryCPCost.FlagEnabled = true;
            Tweaks.Boosts.ScaledCPCost.FlagEnabled = true;
            Tweaks.Challenges.BoostLevel.FlagEnabled = true;
            Tweaks.Challenges.BoostLevel.Range.Value = 10;
            Tweaks.Boosts.RunSpeedMultiplier.FlagEnabled = true;
            Tweaks.Boosts.RunSpeedMultiplier.Range.Value = 25;

            Tweaks.Challenges.Stats1StageBehind.FlagEnabled = false;
            Tweaks.Challenges.NoShops.FlagEnabled = false;

            if (sender != null)
                MessageBox.Show("Applied!");
        }

        private void presetBully_Click(object sender, EventArgs e)
        {
            Tweaks.Boosts.HalfSecondaryCPCost.FlagEnabled = true;
            Tweaks.Boosts.ScaledCPCost.FlagEnabled = true;
            Tweaks.Challenges.BoostLevel.FlagEnabled = true;
            Tweaks.Challenges.BoostLevel.Range.Value = 25;
            Tweaks.Boosts.RunSpeedMultiplier.FlagEnabled = true;
            Tweaks.Boosts.RunSpeedMultiplier.Range.Value = 25;

            Tweaks.Challenges.Stats1StageBehind.FlagEnabled = false;
            Tweaks.Challenges.NoShops.FlagEnabled = false;


            if (sender != null)
                MessageBox.Show("Applied!");
        }

        private void presetDevastation_Click(object sender, EventArgs e)
        {
            Tweaks.Challenges.BoostLevel.FlagEnabled = true;
            Tweaks.Challenges.BoostLevel.Range.Value = 40;
            Tweaks.Challenges.Stats1StageBehind.FlagEnabled = true;
            Tweaks.Challenges.NoShops.FlagEnabled = true;

            Tweaks.Boosts.HalfSecondaryCPCost.FlagEnabled = false;
            Tweaks.Boosts.ScaledCPCost.FlagEnabled = false;
            Tweaks.Boosts.RunSpeedMultiplier.FlagEnabled = false;
            Tweaks.Boosts.RunSpeedMultiplier.Range.Value = 0;


            if (sender != null)
                MessageBox.Show("Applied!");
        }

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button11_Click_1(object sender, EventArgs e)
        {
            new ItemChanceForm().ShowDialog();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button12_Click(object sender, EventArgs e)
        {
            string value = "";
            value = InputBox.ShowDialog("Input Flag String:", "Import");
            if (!String.IsNullOrEmpty(value))
            {
                bool success = Flags.Import(value, false);
                if (success)
                {
                    MessageBox.Show("Successfully imported flag string!");
                }
                else
                {
                    MessageBox.Show("Failed to import flag string!. Resetting flags to default!");
                    defaultSettings();
                }
            }
        }

        private void button13_Click(object sender, EventArgs e)
        {
            Clipboard.SetText(Flags.GetFlagString());
            MessageBox.Show("Copied flag string to clipboard!");
        }

        private void FullUninstall(BackgroundWorker backgroundWorker)
        {
            if (!Directory.Exists(RandoPath))
            {
                MessageBox.Show("Randomizer hasn't extracted the files...no reason to uninstall.");
                return;
            }
            File.Copy(RandoPath + "\\filelistu.win32.bin", GetFF13Directory() + "\\white_data\\sys\\filelistu.win32.bin", true);
            backgroundWorker.ReportProgress(50);
            File.Copy(RandoPath + "\\white_imgu.win32.bin", GetFF13Directory() + "\\white_data\\sys\\white_imgu.win32.bin", true);
            backgroundWorker.ReportProgress(100);
        }

        private void button9_Click_1(object sender, EventArgs e)
        {
            new ProgressForm("Fully reverting to vanilla files...", bw => FullUninstall(bw)).ShowDialog();
            new ProgressForm("Extracting files...", bw => ExtractFiles(bw,true)).ShowDialog();

            MessageBox.Show("Finished reextracting!");
        }

        private void button10_Click_1(object sender, EventArgs e)
        {
            string filePath = "";
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.InitialDirectory = RandoPath+"\\FlagsSeeds";
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
                //textBoxSeed.Text = UserFlagsSeed.Import(filePath, version);
            }
        }
    }
}
