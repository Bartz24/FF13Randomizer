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
        public static string version = "1.4.4";
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
            #region Sound
            "sound/pack/8000/usa/music_100rosh.win32.scd",
            "sound/pack/8000/usa/music_101ldun_f.win32.scd",
            "sound/pack/8000/usa/music_102far3_b.win32.scd",
            "sound/pack/8000/usa/music_105kibou.win32.scd",
            "sound/pack/8000/usa/music_105kyoufu.win32.scd",
            "sound/pack/8000/usa/music_105saigo.win32.scd",
            "sound/pack/8000/usa/music_105titarr.win32.scd",
            "sound/pack/8000/usa/music_106ofa2_b.win32.scd",
            "sound/pack/8000/usa/music_12snow_1.win32.scd",
            "sound/pack/8000/usa/music_13gekai_f.win32.scd",
            "sound/pack/8000/usa/music_14fmv.win32.scd",
            "sound/pack/8000/usa/music_150sinpi.win32.scd",
            "sound/pack/8000/usa/music_151run.win32.scd",
            "sound/pack/8000/usa/music_152magni.win32.scd",
            "sound/pack/8000/usa/music_153fuan.win32.scd",
            "sound/pack/8000/usa/music_154syuge2.win32.scd",
            "sound/pack/8000/usa/music_155far1or.win32.scd",
            "sound/pack/8000/usa/music_156far3or.win32.scd",
            "sound/pack/8000/usa/music_158opn1_i.win32.scd",
            "sound/pack/8000/usa/music_159opn_b.win32.scd",
            "sound/pack/8000/usa/music_160field.win32.scd",
            "sound/pack/8000/usa/music_161bo_fi.win32.scd",
            "sound/pack/8000/usa/music_162seifu.win32.scd",
            "sound/pack/8000/usa/music_163gso.win32.scd",
            "sound/pack/8000/usa/music_164fmv_2.win32.scd",
            "sound/pack/8000/usa/music_165vin_ch.win32.scd",
            "sound/pack/8000/usa/music_166vin_u2.win32.scd",
            "sound/pack/8000/usa/music_167choro.win32.scd",
            "sound/pack/8000/usa/music_168faru_l.win32.scd",
            "sound/pack/8000/usa/music_16gfaru_b.win32.scd",
            "sound/pack/8000/usa/music_17pls.win32.scd",
            "sound/pack/8000/usa/music_18vin_uta.win32.scd",
            "sound/pack/8000/usa/music_19hanabi.win32.scd",
            "sound/pack/8000/usa/music_20eien.win32.scd",
            "sound/pack/8000/usa/music_21sn_sera.win32.scd",
            "sound/pack/8000/usa/music_26psicom.win32.scd",
            "sound/pack/8000/usa/music_27ansoku.win32.scd",
            "sound/pack/8000/usa/music_28shouk_b.win32.scd",
            "sound/pack/8000/usa/music_29kihei.win32.scd",
            "sound/pack/8000/usa/music_30hot.win32.scd",
            "sound/pack/8000/usa/music_31grv.win32.scd",
            "sound/pack/8000/usa/music_32vpek_f.win32.scd",
            "sound/pack/8000/usa/music_33light_1.win32.scd",
            "sound/pack/8000/usa/music_34comical.win32.scd",
            "sound/pack/8000/usa/music_36gapra_f.win32.scd",
            "sound/pack/8000/usa/music_39hope_1.win32.scd",
            "sound/pack/8000/usa/music_40monst_b.win32.scd",
            "sound/pack/8000/usa/music_41sra.win32.scd",
            "sound/pack/8000/usa/music_42snls_f.win32.scd",
            "sound/pack/8000/usa/music_43sazh_1.win32.scd",
            "sound/pack/8000/usa/music_44sazh_2a.win32.scd",
            "sound/pack/8000/usa/music_44sazh_3b.win32.scd",
            "sound/pack/8000/usa/music_45kinpaku.win32.scd",
            "sound/pack/8000/usa/music_46vani_1.win32.scd",
            "sound/pack/8000/usa/music_47ppm.win32.scd",
            "sound/pack/8000/usa/music_49farusi.win32.scd",
            "sound/pack/8000/usa/music_50abs.win32.scd",
            "sound/pack/8000/usa/music_54snow_2.win32.scd",
            "sound/pack/8000/usa/music_55hope_fu.win32.scd",
            "sound/pack/8000/usa/music_56fang.win32.scd",
            "sound/pack/8000/usa/music_57snow_3.win32.scd",
            "sound/pack/8000/usa/music_59hope_ie.win32.scd",
            "sound/pack/8000/usa/music_61prd.win32.scd",
            "sound/pack/8000/usa/music_62nati_f.win32.scd",
            "sound/pack/8000/usa/music_64choco_c.win32.scd",
            "sound/pack/8000/usa/music_65kanasii.win32.scd",
            "sound/pack/8000/usa/music_67va_sazh.win32.scd",
            "sound/pack/8000/usa/music_68tak.win32.scd",
            "sound/pack/8000/usa/music_6gameover.win32.scd",
            "sound/pack/8000/usa/music_70daisuri.win32.scd",
            "sound/pack/8000/usa/music_71kanta_f.win32.scd",
            "sound/pack/8000/usa/music_72waiban.win32.scd",
            "sound/pack/8000/usa/music_74faru1_b.win32.scd",
            "sound/pack/8000/usa/music_76pro.win32.scd",
            "sound/pack/8000/usa/music_77fark_f.win32.scd",
            "sound/pack/8000/usa/music_78rainz_2.win32.scd",
            "sound/pack/8000/usa/music_81gto.win32.scd",
            "sound/pack/8000/usa/music_83s_gp_f.win32.scd",
            "sound/pack/8000/usa/music_84daihe_f.win32.scd",
            "sound/pack/8000/usa/music_85gp_b.win32.scd",
            "sound/pack/8000/usa/music_86choco_f.win32.scd",
            "sound/pack/8000/usa/music_89vani_2.win32.scd",
            "sound/pack/8000/usa/music_90ligh_sn.win32.scd",
            "sound/pack/8000/usa/music_91teiji_f.win32.scd",
            "sound/pack/8000/usa/music_92saiha_f.win32.scd",
            "sound/pack/8000/usa/music_93ragu_se.win32.scd",
            "sound/pack/8000/usa/music_96grp.win32.scd",
            "sound/pack/8000/usa/music_97eden_pa.win32.scd",
            "sound/pack/8000/usa/music_98hikari.win32.scd",
            "sound/pack/8000/usa/music_bat_short.win32.scd",
            "sound/pack/8000/usa/music_bossa.win32.scd",
            "sound/pack/8000/usa/music_dark.win32.scd",
            "sound/pack/8000/usa/music_fanfare.win32.scd",
            "sound/pack/8000/usa/music_handsnow.win32.scd",
            "sound/pack/8000/usa/music_handsnow2.win32.scd",
            "sound/pack/8000/usa/music_madfade.win32.scd",
            "sound/pack/8000/usa/music_result.win32.scd",
            "sound/pack/8000/usa/music_snowfade.win32.scd",
            "sound/pack/8000/usa/music_theme_b.win32.scd",
            "sound/pack/8000/usa/music_title.win32.scd",
            "sound/pack/8000/usa/music_white_at.win32.scd",
            "sound/pack/8000/usa/music_white_e3.win32.scd"
#endregion
        };

        public Form1()
        {
            if (GetFF13Directory() == null)
                AutoSearchDir();

            Directory.CreateDirectory("logs");

            if (GetFF13Directory()!=null)
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

            addFlags(tabPageCrystarium, FlagType.Crystarium);
            addFlags(tabPageEnemies, FlagType.Enemies);
            addFlags(tabPageItems, FlagType.Items);

            presetEvenedOdds_Click(null, null);

            SetRandomSeed();

            textBox2.Text = GetFF13Directory() == null ? "" : GetFF13Directory();

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
                if (flag.FlagType == type)
                {
                    addFlagEvents(flag);
                    flag.Dock = DockStyle.Fill;

                    flag.OnChangedEvent();
                    flag.OnChanged += Flag_OnChanged;

                    tableLayout.Controls.Add(flag);
                }
            }
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
            //RandomizeCrystarium();
            MessageBox.Show("Done.");
        }

        private void RandomizeCrystarium(BackgroundWorker backgroundWorker)
        {
            string[] names = new string[] { "lightning", "fang", "snow", "sazh", "hope", "vanille" };

            Dictionary<Role, StatValues> roleMults = new Dictionary<Role, StatValues>();
            Dictionary<string, StatValues> charMults = new Dictionary<string, StatValues>();

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

            Dictionary<int, Dictionary<CrystariumType, List<int>>> statAverages = new Dictionary<int, Dictionary<CrystariumType, List<int>>>();
            if (Flags.CrystariumFlags.RandStats.FlagEnabled)
            {
                Flags.CrystariumFlags.RandStats.SetRand();
                foreach (Role role in Enum.GetValues(typeof(Role)))
                {
                    StatValues stats = new StatValues(3);
                    int variance = ((FlagValue)Flags.CrystariumFlags.RandStats.FlagData).Range.Value;
                    stats.Randomize(variance);
                    roleMults.Add(role, stats);
                }

                foreach (string name in names)
                {
                    StatValues stats = new StatValues(3);
                    int variance = ((FlagValue)Flags.CrystariumFlags.RandStats.FlagData).Range.Value;
                    stats.Randomize(variance);
                    charMults.Add(name, stats);
                }

                for (int stage = 1; stage <= 10; stage++)
                {
                    Dictionary<CrystariumType, List<int>> dict = new Dictionary<CrystariumType, List<int>>();
                    dict.Add(CrystariumType.HP, new List<int>());
                    dict.Add(CrystariumType.Strength, new List<int>());
                    dict.Add(CrystariumType.Magic, new List<int>());
                    statAverages.Add(stage, dict);
                }

                foreach (string name in crystariums.Keys)
                {
                    foreach (DataStoreCrystarium c in crystariums[name].Crystarium)
                    {
                        if (c.Type == CrystariumType.HP || c.Type == CrystariumType.Strength || c.Type == CrystariumType.Magic)
                        {
                            statAverages[c.Stage][c.Type].Add(c.Value);
                        }

                        if (Flags.CrystariumFlags.ScaledCPCost.FlagEnabled)
                        {
                            int cpCost = (int)Math.Floor(c.CPCost * Math.Max(0.5, Math.Min(1, 1.08684 * Math.Exp(-0.08664 * c.Stage))));
                            c.CPCost = (uint)(Math.Round(cpCost / 5.0 / Math.Floor(Math.Log10(cpCost))) * 5 * Math.Floor(Math.Log10(cpCost)));
                        }

                        if (Flags.CrystariumFlags.HalfSecondaryCPCost.FlagEnabled && !primaryRoles[name].Contains(c.Role))
                        {
                            c.CPCost /= 2;
                        }
                    }
                }

                statAverages.Values.ToList().ForEach(d =>
                {
                    d.Keys.ToList().ForEach(k =>
                    {
                        int avg = (int)Math.Ceiling((double)d[k].Sum(v => v) / d[k].Count);
                        d[k].Clear();
                        d[k].Add(avg);
                    });
                    int avgStrMag = (d[CrystariumType.Strength][0] + d[CrystariumType.Magic][0]) / 2;
                    d[CrystariumType.Strength][0] = d[CrystariumType.Magic][0] = (int)Math.Max(1, avgStrMag * 1.04);
                    d[CrystariumType.HP][0] = (int)Math.Max(1, d[CrystariumType.HP][0] * 1.03);
                });
                RandomNum.ClearRand();
            }



            foreach (string name in names)
            {
                CrystariumDatabase crystarium = crystariums[name];

                for (int r = 1; r <= 6; r++)
                {
                    Role role = (Role)r;

                    if (Flags.CrystariumFlags.ShuffleNodes.FlagEnabled)
                    {
                        Flags.CrystariumFlags.ShuffleNodes.SetRand();
                        crystarium.Crystarium.ToList()
                                .Where(c => c.Role == role
                                && c.CPCost > 0
                                && ((!primaryRoles[name].Contains(role) && c.Stage > 1) || primaryRoles[name].Contains(role))).ToList()
                                .Shuffle((a, b) => a.SwapStatsAbilities(b));
                        RandomNum.ClearRand();
                    }
                }

                if (Flags.CrystariumFlags.RandStats.FlagEnabled)
                {
                    Flags.CrystariumFlags.RandStats.SetRand();
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

                    foreach (DataStoreCrystarium c in crystarium.Crystarium)
                    {
                        if (c.Type == CrystariumType.HP || c.Type == CrystariumType.Strength || c.Type == CrystariumType.Magic)
                        {
                            c.Type = RandomNum.SelectRandomWeighted(
                                new CrystariumType[] { CrystariumType.HP, CrystariumType.Strength, CrystariumType.Magic }.ToList(),
                                t => Math.Max(1, (int)Math.Pow(
                                    t == CrystariumType.HP ? (charMults[name][0] * roleMults[c.Role][0]) : (
                                    t == CrystariumType.Strength ? (charMults[name][1] * roleMults[c.Role][1]) :
                                    (charMults[name][2] * roleMults[c.Role][2])), 1 / 1.5d)));

                            int avgValue = statAverages[c.Stage][c.Type][0];
                            if (primaryRoles[name].Contains(c.Role))
                            {
                                //avgValue = (int)Math.Ceiling(avgValue * (5 * Math.Exp(-0.5d * nodeCounts[c.Stage][c.Role]) + 1));
                            }
                            else
                                avgValue = (int)Math.Ceiling(avgValue / 1.8d);

                            if (name != "fang" && c.CPCost == 0)
                                avgValue = (int)Math.Floor(avgValue * 2.8d);


                            if (c.Type == CrystariumType.HP)
                                c.Value = (ushort)Math.Round(Math.Max(1,
                                    (float)avgValue * (float)charMults[name][0] * (float)roleMults[c.Role][0] / 10000f));
                            if (c.Type == CrystariumType.Strength)
                                c.Value = (ushort)Math.Round(Math.Max(1,
                                    (float)avgValue * (float)charMults[name][1] * (float)roleMults[c.Role][1] / 10000f));
                            if (c.Type == CrystariumType.Magic)
                                c.Value = (ushort)Math.Round(Math.Max(1,
                                    (float)avgValue * (float)charMults[name][2] * (float)roleMults[c.Role][2] / 10000f));
                        }
                    }

                    foreach (Role role in Enum.GetValues(typeof(Role)))
                    {
                        List<DataStoreCrystarium> list = crystarium.Crystarium.Where(
                        c => (c.Type == CrystariumType.HP ||
                    c.Type == CrystariumType.Strength ||
                    c.Type == CrystariumType.Magic) && c.Role == role).ToList();

                        for (int i = 0; i < list.Count() / 2; i++)
                        {
                            DataStoreCrystarium c = list[RandomNum.RandInt(0, list.Count - 1)];
                            int count = list.Where(c2 => c.Type == c2.Type).Count();
                            float mult = RandomNum.RandInt(100, 100 + (int)Math.Sqrt(Math.Max(0, (count - 1)) * 20)) / 100f;
                            list.ForEach(cr =>
                            {
                                if (c.Type == cr.Type && c.Stage == cr.Stage)
                                    cr.Value = (ushort)Math.Max(1, Math.Ceiling(cr == c ? (cr.Value * mult) : (cr.Value / Math.Pow(mult, 1 / 2.2f) - 1)));
                            });
                            c.Value = (ushort)Math.Max(1, (int)c.Value);
                        }
                    }
                    RandomNum.ClearRand();
                }

                backgroundWorker.ReportProgress(names.ToList().IndexOf(name) * (50 / 6));
            }


            foreach (string name in names)
            {
                CrystariumDatabase crystarium = crystariums[name];

                List<Tiered<Ability>> techniques = TieredAbilities.manager.list.Where(
                    t => t.Items.Where(a => a.Role == Role.None && (!Flags.CrystariumFlags.LibraStart.FlagEnabled || (Flags.CrystariumFlags.LibraStart.FlagEnabled && a != Abilities.Libra))).Count() > 0).ToList();

                List<Tiered<Ability>> added = new List<Tiered<Ability>>();
                List<Ability> obtained = new List<Ability>();

                Dictionary<Role, List<int>> startingNodes = new Dictionary<Role, List<int>>();
                for (int r = 1; r <= 6; r++)
                {
                    List<int> startingNodeList = new List<int>();
                    Role role = (Role)r;
                    if (Flags.CrystariumFlags.NewAbilities.FlagEnabled)
                    {
                        Flags.CrystariumFlags.NewAbilities.SetRand();
                        List<int> abilityNodes = new List<int>();
                        for (int i = 0; i < crystarium.Crystarium.count; i++)
                        {
                            if (crystarium.Crystarium[i].Role == role && crystarium.Crystarium[i].Type == CrystariumType.Ability)
                                abilityNodes.Add(i);
                        }
                        abilityNodes.Sort((a, b) => crystarium.Crystarium[a].Stage.CompareTo(crystarium.Crystarium[b].Stage));

                        List<Tiered<Ability>> starting = TieredAbilities.manager.list.Where(
                    t => t.Items.Where(a => a.Role == role && a.Starting && a.HasCharacter(getCharID(name))).Count() > 0 && !added.Contains(t)).ToList();

                        int maxStage = 1;
                        for (int i = 0; i < abilityNodes.Count; i++)
                        {
                            DataStoreCrystarium cryst = crystarium.Crystarium[abilityNodes[i]];
                            if (cryst.Stage < maxStage)
                                throw new Exception("Went down in stage!");
                            maxStage = cryst.Stage;

                            Ability orig = Abilities.abilities.Where(a => a.HasCharacter(getCharID(name)) && a.GetAbility(getCharID(name)) == crystarium.AbilityIDs[(int)cryst.AbilityPointer]?.Value).FirstOrDefault();

                            if (Flags.CrystariumFlags.LibraStart.FlagEnabled && orig == Abilities.Libra)
                                continue;

                            if (isTechnique(orig))
                            {
                                int newI;
                                Ability ability;
                                do
                                {
                                    newI = RandomNum.RandInt(0, techniques.Count - 1);
                                    ability = Flags.CrystariumFlags.AbilitiesAnyRole.FlagEnabled ? TieredAbilities.GetNoDep(techniques[newI]) : TieredAbilities.Get(techniques[newI], obtained);
                                } while (ability == null);
                                DataStoreString dataStr = new DataStoreString() { Value = ability.GetAbility(getCharID(name)) };
                                if (!crystarium.AbilityIDs.Contains(dataStr))
                                    crystarium.AbilityIDs.Add(dataStr, crystarium.AbilityIDs.GetTrueSize());
                                cryst.AbilityPointer = (uint)crystarium.AbilityIDs.IndexOf(dataStr);
                                obtained.Add(ability);
                                techniques.RemoveAt(newI);
                                startingNodeList.Add(abilityNodes[i]);
                                abilityNodes.RemoveAt(i);
                                i--;
                            }
                            else if (cryst.CPCost == 0 || (!primaryRoles[name].Contains(role) && cryst.Stage == 1))
                            {
                                int newI;
                                Ability ability;
                                do
                                {
                                    newI = RandomNum.RandInt(0, starting.Count - 1);
                                    ability = Flags.CrystariumFlags.AbilitiesAnyRole.FlagEnabled ? TieredAbilities.GetNoDep(starting[newI]) : TieredAbilities.Get(starting[newI], obtained);
                                } while (ability == null);
                                DataStoreString dataStr = new DataStoreString() { Value = ability.GetAbility(getCharID(name)) };
                                if (!crystarium.AbilityIDs.Contains(dataStr))
                                    crystarium.AbilityIDs.Add(dataStr, crystarium.AbilityIDs.GetTrueSize());
                                cryst.AbilityPointer = (uint)crystarium.AbilityIDs.IndexOf(dataStr);
                                obtained.Add(ability);
                                added.Add(starting[newI]);
                                starting.RemoveAt(newI);
                                startingNodeList.Add(abilityNodes[i]);
                                abilityNodes.RemoveAt(i);
                                break;
                            }
                        }
                        maxStage = 1;
                        startingNodes.Add(role, startingNodeList);
                        RandomNum.ClearRand();
                    }
                }
                for (int r = 1; r <= 6; r++)
                {
                    Role role = (Role)r;
                    int maxStage = 1;
                    if (Flags.CrystariumFlags.NewAbilities.FlagEnabled)
                    {
                        Flags.CrystariumFlags.NewAbilities.SetRand();
                        List<int> abilityNodes = new List<int>();
                        for (int i = 0; i < crystarium.Crystarium.count; i++)
                        {
                            if (crystarium.Crystarium[i].Role == role && crystarium.Crystarium[i].Type == CrystariumType.Ability && !startingNodes[role].Contains(i))
                                abilityNodes.Add(i);
                        }
                        abilityNodes.Sort((a, b) => crystarium.Crystarium[a].Stage.CompareTo(crystarium.Crystarium[b].Stage));

                        List<Tiered<Ability>> rest = TieredAbilities.manager.list.Where(
                    t => t.Items.Where(a => (a.Role == role || Flags.CrystariumFlags.AbilitiesAnyRole.FlagEnabled) && a.Role != Role.None && a.HasCharacter(getCharID(name))).Count() > 0 && !added.Contains(t)).ToList();
                        for (int i = 0; i < abilityNodes.Count; i++)
                        {
                            DataStoreCrystarium cryst = crystarium.Crystarium[abilityNodes[i]];
                            if (cryst.Stage < maxStage)
                                throw new Exception("Went down in stage!");
                            maxStage = cryst.Stage;

                            Ability orig = Abilities.abilities.Where(a => a.HasCharacter(getCharID(name)) && a.GetAbility(getCharID(name)) == crystarium.AbilityIDs[(int)cryst.AbilityPointer]?.Value).FirstOrDefault();

                            if (Flags.CrystariumFlags.LibraStart.FlagEnabled && orig == Abilities.Libra)
                                continue;

                            if (isTechnique(orig))
                            {
                                int newI;
                                Ability ability;
                                do
                                {
                                    newI = RandomNum.RandInt(0, techniques.Count - 1);
                                    ability = Flags.CrystariumFlags.AbilitiesAnyRole.FlagEnabled ? TieredAbilities.GetNoDep(techniques[newI]) : TieredAbilities.Get(techniques[newI], obtained);
                                } while (ability == null);
                                DataStoreString dataStr = new DataStoreString() { Value = ability.GetAbility(getCharID(name)) };
                                if (!crystarium.AbilityIDs.Contains(dataStr))
                                    crystarium.AbilityIDs.Add(dataStr, crystarium.AbilityIDs.GetTrueSize());
                                cryst.AbilityPointer = (uint)crystarium.AbilityIDs.IndexOf(dataStr);
                                obtained.Add(ability);
                                techniques.RemoveAt(newI);
                            }
                            else
                            {
                                int newI;
                                Ability ability;
                                do
                                {
                                    newI = RandomNum.RandInt(0, rest.Count - 1);
                                    ability = Flags.CrystariumFlags.AbilitiesAnyRole.FlagEnabled ? TieredAbilities.GetNoDep(rest[newI]) : TieredAbilities.Get(rest[newI], obtained);
                                } while (ability == null);
                                DataStoreString dataStr = new DataStoreString() { Value = ability.GetAbility(getCharID(name)) };
                                if (!crystarium.AbilityIDs.Contains(dataStr))
                                    crystarium.AbilityIDs.Add(dataStr, crystarium.AbilityIDs.GetTrueSize());
                                cryst.AbilityPointer = (uint)crystarium.AbilityIDs.IndexOf(dataStr);
                                obtained.Add(ability);
                                added.Add(rest[newI]);
                                rest.RemoveAt(newI);
                            }
                        }
                        RandomNum.ClearRand();
                    }
                }

                crystarium.Save($"db\\crystal\\crystal_{name}.wdb");

                backgroundWorker.ReportProgress(50 + names.ToList().IndexOf(name) * (50 / 6));

            }

            DocsJSONGenerator.CreateCrystariumDocs(crystariums, primaryRoles);
        }

        private static bool isTechnique(Ability orig)
        {
            if (Flags.CrystariumFlags.LibraStart.FlagEnabled && orig == Abilities.Libra)
                return false;
            return orig == Abilities.Libra || orig == Abilities.Renew || orig == Abilities.Stopga || orig == Abilities.Quake || orig == Abilities.Dispelga;
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
                if (path.Contains("music"))
                    continue;
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
                backgroundWorker.ReportProgress(fileNamesModified.ToList().IndexOf(path) * 100 / fileNamesModified.Length);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //MessageBox.Show(TieredItems.manager.GetRank(Items.Trapezohedron).ToString());
            int rank = TieredItems.manager.GetRank(Items.TetradicCrown);
            Console.WriteLine("\n"+rank.ToString());
            int rankAdj = ((FlagValue)Flags.ItemFlags.Drops.FlagData).Range.Value;
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

        List<string> shopsRemaining = new List<string>();
        List<Item> blacklistedWeapons = new List<Item>();

        private void RandomizeTreasures(BackgroundWorker backgroundWorker)
        {
            int rankAdj = ((FlagValue)Flags.ItemFlags.Drops.FlagData).Range.Value;
            Items.items.ForEach(i =>
            {
                if (i.ID.StartsWith("wea_") && i.ID.EndsWith("_001"))
                    blacklistedWeapons.Add(i);
            });
            TreasureDatabase oldTreasures = new TreasureDatabase($"{randoPath}\\original\\db\\resident\\treasurebox.wdb");

            TreasureDatabase treasures = new TreasureDatabase($"{randoPath}\\original\\db\\resident\\treasurebox.wdb");
            int[] ranks = new int[treasures.Treasures.count];

                int completed = 0, index = -1;
            Flags.ItemFlags.Treasures.SetRand();
            treasures.Treasures.ToList().ForEach(t =>
            {
                index++;
                Item item = Items.items.Where(i => i.ID == oldTreasures.ItemIDs[(int)t.StartingPointer]?.Value).FirstOrDefault();
                int rank = -1;
                if (item != null)
                {
                    rank = TieredItems.manager.GetRank(item, (int)t.Count);
                    if (rank != -1 && Flags.ItemFlags.Treasures.FlagEnabled)
                    {
                        if (rankAdj > 0)
                            rank = RandomNum.RandInt(Math.Max(0, rank - rankAdj), Math.Min(TieredItems.manager.GetHighBound(), rank + rankAdj));
                        Tuple<Item, int> newItem;
                        rank++;
                        do
                        {
                            rank--;
                            newItem = TieredItems.manager.Get(rank, Int32.MaxValue, tiered => GetTreasureWeight(tiered));
                        } while (rank >= 0 && (newItem.Item1 == null || blacklistedWeapons.Contains(newItem.Item1)));
                        if (newItem.Item1.ID.StartsWith("wea_"))
                            blacklistedWeapons.Add(newItem.Item1);
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
                    }
                }

                ranks[index] = rank;

                completed++;

                backgroundWorker.ReportProgress(completed * 100 / treasures.Treasures.count);
            });
            RandomNum.ClearRand();

            if (Flags.ItemFlags.Shops.FlagEnabled)
            {
                Flags.ItemFlags.Shops.SetRand();
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
                RandomNum.ClearRand();
            }

            treasures.Save($"db\\resident\\treasurebox.wdb");

            DocsJSONGenerator.CreateTreasureDocs(treasures, ranks);
        }

        public static int GetTreasureWeight(Tiered<Item> t)
        {
            if (t.Items.Where(i => i.ID.StartsWith("it")).Count() > 0)
                return Math.Max(1, t.Weight * 8);
            if (t.Items.Where(i => i.ID.StartsWith("acc")).Count() > 0)
                return (int)Math.Max(1, t.Weight * 1.2);
            if (t.Items.Where(i => i.ID.StartsWith("material_o")).Count() > 0)
                return Math.Max(1, t.Weight / 30);
            if (t.Items.Where(i => i.ID.StartsWith("material")).Count() > 0)
                return Math.Max(1, t.Weight * 4);
            return (int)(t.Weight * 2);
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

        private void RandomizeEnemies(BackgroundWorker backgroundWorker)
        {
            Dictionary<byte,ElementalRes> physValues = new Dictionary<byte, ElementalRes>();
            #region Set Physical Resistances
            physValues.Add(0x00, ElementalRes.Normal);
            physValues.Add(0x01, ElementalRes.Normal);
            physValues.Add(0x04, ElementalRes.Normal);
            physValues.Add(0x05, ElementalRes.Normal);
            physValues.Add(0x81, ElementalRes.Normal);

            physValues.Add(0x0D, ElementalRes.Halved);
            physValues.Add(0x10, ElementalRes.Halved);
            physValues.Add(0x11, ElementalRes.Halved);
            physValues.Add(0x14, ElementalRes.Halved);
            physValues.Add(0x15, ElementalRes.Halved);
            physValues.Add(0x91, ElementalRes.Halved);

            physValues.Add(0x18, ElementalRes.Resistant);
            physValues.Add(0x19, ElementalRes.Resistant);
            physValues.Add(0x1C, ElementalRes.Resistant);
            physValues.Add(0x1D, ElementalRes.Resistant);
            physValues.Add(0x98, ElementalRes.Resistant);

            physValues.Add(0x20, ElementalRes.Immune);
            physValues.Add(0x21, ElementalRes.Immune);
            physValues.Add(0x24, ElementalRes.Immune);
            physValues.Add(0x25, ElementalRes.Immune);
            #endregion


            byte[] scene = File.ReadAllBytes($"{ randoPath}\\original\\db\\resident\\bt_scene.wdb");
            EnemyStatDatabase enemies = new EnemyStatDatabase($"{randoPath}\\original\\db\\resident\\bt_chara_spec.wdb");
            byte[] bytes = File.ReadAllBytes($"{randoPath}\\original\\db\\resident\\bt_chara_spec.wdb");

            int completed = 0;
            List<DataStoreEnemy> enemyList = enemies.Enemies.ToList();
            bool noImmune = false; // ((FlagBool)Flags.EnemyFlags.Resistances.FlagData).Value;
            enemyList.ForEach(e =>
            {
                byte[] idBytes = bytes.SubArray(completed * 0x20 + 0x90, 0x10);
                string id = Encoding.UTF8.GetString(idBytes).Replace("\0", "");

                if (Flags.EnemyFlags.BoostLevel.FlagEnabled)
                {
                    int boost = ((FlagValue)Flags.EnemyFlags.BoostLevel.FlagData).Range.Value;
                    bool lv0 = e.Level == 0;
                    byte level = (byte)(lv0 ? 10 : e.Level);
                    e.HP = (uint)Math.Max(1, e.HP * Math.Exp(Math.Pow(level + boost, 0.25) - Math.Pow(level, 0.25)));
                    e.Strength = (ushort)Math.Max(1, e.Strength * Math.Exp(Math.Pow(level + boost, 0.25) - Math.Pow(level, 0.25)));
                    e.Magic = (ushort)Math.Max(1, e.Magic * Math.Exp(Math.Pow(level + boost, 0.25) - Math.Pow(level, 0.25)));
                }

                if (Flags.EnemyFlags.RandLevel.FlagEnabled)
                {
                    Flags.EnemyFlags.RandLevel.SetRand();
                    int variance = ((FlagValue)Flags.EnemyFlags.RandLevel.FlagData).Range.Value;
                    int boost = Flags.EnemyFlags.BoostLevel.FlagEnabled ? ((FlagValue)Flags.EnemyFlags.BoostLevel.FlagData).Range.Value : 0;
                    bool lv0 = e.Level == 0;
                    byte level = (byte)(lv0 ? 10 : e.Level);
                    if (level < 50)
                        e.Level = (byte)RandomNum.RandInt(Math.Max(1, level - variance), Math.Min(49, level + variance));
                    else if (level > 50)
                        e.Level = (byte)RandomNum.RandInt(Math.Max(51, level - variance), Math.Min(99, level + variance));
                    e.HP = (uint)Math.Max(1, e.HP * Math.Exp(Math.Pow(e.Level + boost, 0.25) - Math.Pow(level + boost, 0.25)));
                    e.Strength = (ushort)Math.Max(1, e.Strength * Math.Exp(Math.Pow(e.Level + boost, 0.25) - Math.Pow(level + boost, 0.25)));
                    e.Magic = (ushort)Math.Max(1, e.Magic * Math.Exp(Math.Pow(e.Level + boost, 0.25) - Math.Pow(level + boost, 0.25)));
                    if (e.CP > 0)
                        e.CP = (uint)Math.Max(1, e.CP * Math.Exp(Math.Pow(e.Level, 0.4) - Math.Pow(level, 0.4)));
                    if (lv0)
                        e.Level = 0;
                    RandomNum.ClearRand();
                }

                if (Flags.ItemFlags.Drops.FlagEnabled)
                {
                    Flags.ItemFlags.Drops.SetRand();
                    do
                    {
                        RandomizeDrop(enemies, e, true);
                        RandomizeDrop(enemies, e, false);
                    } while (e.CommonDropPointer == e.RareDropPointer && enemies.ItemIDs[(int)e.CommonDropPointer].Value != "");
                    RandomNum.ClearRand();
                }
                
                DataStoreEnemy swap;
                if (Flags.EnemyFlags.Resistances.FlagEnabled)
                {
                    Flags.EnemyFlags.Resistances.SetRand();
                    do
                    {
                        swap = RandomNum.SelectRandomWeighted(enemyList, eS => eS == e ? 0 : 1);
                    } while (!(physValues[swap.PhysicalRes] >= ElementalRes.Resistant && swap.MagicRes >= ElementalRes.Resistant)
                    != !(physValues[e.PhysicalRes] >= ElementalRes.Resistant && e.MagicRes >= ElementalRes.Resistant));

                    ElementalRes o = e.ElemRes1;
                    e.ElemRes1 = swap.ElemRes1;
                    swap.ElemRes1 = o;

                    byte o2 = e.ElemRes2;
                    e.ElemRes2 = swap.ElemRes2;
                    swap.ElemRes2 = o2;

                    o2 = e.ElemRes3;
                    e.ElemRes3 = swap.ElemRes3;
                    swap.ElemRes3 = o2;

                    o2 = e.ElemRes4;
                    e.ElemRes4 = swap.ElemRes4;
                    swap.ElemRes4 = o2;
                    /*
                    o = e.PhysicalRes;
                    e.PhysicalRes = swap.PhysicalRes;
                    swap.PhysicalRes = o;
                    */
                    if (noImmune)
                    {
                        if (physValues[e.PhysicalRes] == ElementalRes.Immune)
                        {
                            e.PhysicalRes = physValues.Keys.Where(k => physValues[k] == ElementalRes.Halved).First();
                        }
                        if (e.MagicRes == ElementalRes.Immune)
                        {
                            e.MagicRes = ElementalRes.Halved;
                        }
                    }
                    RandomNum.ClearRand();
                }

                if (Flags.EnemyFlags.Debuffs.FlagEnabled)
                {
                    Flags.EnemyFlags.Debuffs.SetRand();
                    swap = RandomNum.SelectRandomWeighted(enemyList, eS => eS == e ? 0 : 1);

                    byte[] swapped = swap.DebuffRes;
                    byte[] enem = e.DebuffRes;

                    
                    for (int i = 0; i < 16; i++)
                    {
                        byte o = enem[i];
                        enem[i] = swapped[i];
                        swapped[i] = o;
                    }

                    swap.DebuffRes = swapped;
                    e.DebuffRes = enem;
                    RandomNum.ClearRand();
                }

                if (Flags.EnemyFlags.RandStats.FlagEnabled)
                {
                    Flags.EnemyFlags.RandStats.SetRand();
                    StatValues stats = new StatValues(5);
                    int variance = ((FlagValue)Flags.EnemyFlags.RandStats.FlagData).Range.Value;
                    stats.Randomize(variance);
                    e.HP = (uint)Math.Max(1, e.HP * stats[0] / 100f);
                    e.Strength = (ushort)Math.Max(1, e.Strength * stats[1] / 100f);
                    e.Magic = (ushort)Math.Max(1, e.Magic * stats[2] / 100f);
                    e.ChainRes = (uint)Math.Min(100, Math.Max(0, Math.Sqrt(Math.Pow(e.ChainRes + 1, 2f) * stats[3] / 100f) - 1));
                    e.StaggerPoint = (ushort)Math.Min(999, Math.Max(101, (e.StaggerPoint -100) * stats[4] / 100f + 100));
                    RandomNum.ClearRand();
                }

                completed++;
                backgroundWorker.ReportProgress(completed * 100 / enemies.Enemies.count);
            });


            if (Flags.ItemFlags.Shops.FlagEnabled)
            {
                Flags.ItemFlags.Shops.SetRand();
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
                RandomNum.ClearRand();
            }

            enemies.Save($"db\\resident\\bt_chara_spec.wdb");
            File.WriteAllBytes($"db\\resident\\bt_scene.wdb", scene);
        }

        private void RandomizeDrop(EnemyStatDatabase enemies, DataStoreEnemy enemy, bool common)
        {
            int rankAdj = ((FlagValue)Flags.ItemFlags.Drops.FlagData).Range.Value;
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
                    if (rankAdj > 0)
                        rank = RandomNum.RandInt(Math.Max(0, rank - rankAdj), Math.Min(TieredItems.manager.GetHighBound(), rank + rankAdj));
                    int oldRank = rank + 0;
                    Tuple<Item, int> newItem;
                    do
                    {
                        newItem = TieredItems.manager.Get(rank, 1, tiered => GetDropWeight(tiered, enemy.Level, item.ID.StartsWith("it") && enemy.Level > 50));
                        rank--;
                    } while ((newItem.Item1 == null || blacklistedWeapons.Contains(newItem.Item1)) && rank >= 0);
                    if (newItem.Item1 == null)
                        return;
                    if (newItem.Item1.ID.StartsWith("wea_"))
                        blacklistedWeapons.Add(newItem.Item1);
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

        public static int GetDropWeight(Tiered<Item> t,int enemyLevel,bool forceNormalDrop)
        {
            if (t.Items.Where(i => i.ID == "").Count() > 0)
                return 0;
            float mult;
            if (enemyLevel > 50 && !forceNormalDrop)
            {
                mult = 1 + .01f * (float)Math.Pow(enemyLevel - 50, .8f);
                if (t.Items.Where(i => i.ID.StartsWith("material_o")).Count() > 0)
                    return (int)(t.Weight * 1.5 * mult);
                if (t.Items.Where(i => i.ID.StartsWith("material")).Count() > 0)
                    return 0;
                if (t.Items.Where(i => i.ID.StartsWith("it")).Count() > 0)
                    return Math.Max(1, t.Weight / 4);
                return (int)(t.Weight * 2 * mult);
            }
            mult = 1 + .01f * (float)Math.Pow(enemyLevel, .8f);
            if (t.Items.Where(i => i.ID.StartsWith("material_o")).Count() > 0)
                return (int)(t.Weight);
            if (t.Items.Where(i => i.ID.StartsWith("material")).Count() > 0)
                return  (int)(t.Weight * 18.2f);
            if (t.Items.Where(i => i.ID.StartsWith("wea_")).Count() > 0)
                return 0;
            return  (int)Math.Max(1, t.Weight / 22.5f * mult);
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

            new ProgressForm("Randomizing crystarium...", bw => RandomizeCrystarium(bw)).ShowDialog();
            new ProgressForm("Randomizing treasures...", bw => RandomizeTreasures(bw)).ShowDialog();
            new ProgressForm("Randomizing enemies... (Drops/Resistances/Stats)", bw => RandomizeEnemies(bw)).ShowDialog();
            new ProgressForm("Randomizing music...", bw => ShuffleMusic(bw)).ShowDialog();


            new ProgressForm("Inserting files...", bw => insertFiles(bw, true)).ShowDialog();

            UserFlagsSeed.Export(randoPath + "\\FlagsSeeds", textBoxSeed.Text.Trim(), version);
            UserFlagsSeed.Export("logs", textBoxSeed.Text.Trim(), version);

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

        private void ExtractFiles(BackgroundWorker backgroundWorker, bool force=false)
        {
            if (!force && !NeedsExtracting())
                return;
            
            if (Directory.Exists(randoPath))
            {
                if (File.Exists(randoPath + "\\filelistu.win32.bin"))
                    new ProgressForm("Fully reverting to vanilla files...", bw => FullUninstall(bw)).ShowDialog();
                Directory.GetDirectories(randoPath).Where(d=>!d.EndsWith("FlagsSeeds")).ToList().ForEach(d => Directory.Delete(d, true));
            }
            backgroundWorker.ReportProgress(10);
            Directory.CreateDirectory(randoPath);
            File.Copy(GetFF13Directory() + "\\white_data\\sys\\filelistu.win32.bin", randoPath + "\\filelistu.win32.bin",true);
            backgroundWorker.ReportProgress(20);
            File.Copy(GetFF13Directory() + "\\white_data\\sys\\white_imgu.win32.bin", randoPath + "\\white_imgu.win32.bin",true);
            backgroundWorker.ReportProgress(30);

            runCommand($"ff13tool.exe -x \"{randoPath + "\\filelistu.win32.bin"}\" \"{randoPath + "\\white_imgu.win32.bin"}\"", false, backgroundWorker, 30, 70, 14106);
            backgroundWorker.ReportProgress(70);

            foreach (string path in fileNamesModified)
            {
                Directory.CreateDirectory(randoPath + "\\original\\" + Path.GetDirectoryName(path.Replace("/", "\\")));
                Directory.CreateDirectory(Path.GetDirectoryName(path.Replace("/", "\\")));
                File.Copy(randoPath + "\\white_imgu\\" + path.Replace("/", "\\"), randoPath + "\\original\\" + path.Replace("/", "\\"));
                
            }
            backgroundWorker.ReportProgress(85);

            Directory.Delete(randoPath + "\\white_imgu", true);
        }

        private void button10_Click(object sender, EventArgs e)
        {
            if (!Directory.Exists(randoPath))
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

        private void presetEvenedOdds_Click(object sender, EventArgs e)
        {
            foreach (Flag flag in Flags.flags)
            {
                if (flag == Flags.EnemyFlags.Debuffs || 
                    flag == Flags.EnemyFlags.Resistances/* || 
                    flag == Flags.Other.Music*/ ||
                    flag == Flags.EnemyFlags.RandStats ||
                    flag == Flags.EnemyFlags.RandLevel)
                    flag.FlagEnabled = false;
                else if (flag == Flags.EnemyFlags.BoostLevel)
                {

                }
                else
                    flag.FlagEnabled = true;
            }
            ((FlagValue)Flags.ItemFlags.Drops.FlagData).Range.Value = 5;
            ((FlagValue)Flags.ItemFlags.Treasures.FlagData).Range.Value = 5;
            ((FlagValue)Flags.CrystariumFlags.RandStats.FlagData).Range.Value = 15;
            ((FlagValue)Flags.EnemyFlags.RandStats.FlagData).Range.Value = 0;
            ((FlagValue)Flags.EnemyFlags.RandLevel.FlagData).Range.Value = 0;
            //((FlagBool)Flags.EnemyFlags.Resistances.FlagData).Value = false;
            if (sender!=null)
            MessageBox.Show("Applied!");
        }

        private void presetDiversity_Click(object sender, EventArgs e)
        {
            foreach (Flag flag in Flags.flags)
            {
                if (flag == Flags.EnemyFlags.Debuffs || 
                    flag == Flags.EnemyFlags.Resistances || 
                    flag == Flags.CrystariumFlags.LibraStart/* || 
                    flag == Flags.Other.Music*/)
                    flag.FlagEnabled = false;
                else if (flag == Flags.EnemyFlags.BoostLevel)
                {

                }
                else
                    flag.FlagEnabled = true;
            }
            ((FlagValue)Flags.ItemFlags.Drops.FlagData).Range.Value = 20;
            ((FlagValue)Flags.ItemFlags.Treasures.FlagData).Range.Value = 20;
            ((FlagValue)Flags.CrystariumFlags.RandStats.FlagData).Range.Value = 25;
            ((FlagValue)Flags.EnemyFlags.RandStats.FlagData).Range.Value = 15;
            ((FlagValue)Flags.EnemyFlags.RandLevel.FlagData).Range.Value = 5;
            //((FlagBool)Flags.EnemyFlags.Resistances.FlagData).Value = false;

            MessageBox.Show("Applied!");
        }

        private void presetDirtyFighting_Click(object sender, EventArgs e)
        {
            foreach (Flag flag in Flags.flags)
            {
                if (flag == Flags.EnemyFlags.BoostLevel)
                {

                }
                else
                    flag.FlagEnabled = true;
            }
            ((FlagValue)Flags.ItemFlags.Drops.FlagData).Range.Value = 40;
            ((FlagValue)Flags.ItemFlags.Treasures.FlagData).Range.Value = 40;
            ((FlagValue)Flags.CrystariumFlags.RandStats.FlagData).Range.Value = 40;
            ((FlagValue)Flags.EnemyFlags.RandStats.FlagData).Range.Value = 50;
            ((FlagValue)Flags.EnemyFlags.RandLevel.FlagData).Range.Value = 20;
            //((FlagBool)Flags.EnemyFlags.Resistances.FlagData).Value = true;

            MessageBox.Show("Applied!");
        }

        private void presetBully_Click(object sender, EventArgs e)
        {
            foreach (Flag flag in Flags.flags)
            {
                if (flag == Flags.CrystariumFlags.LibraStart || 
                    flag == Flags.CrystariumFlags.ScaledCPCost || 
                    flag == Flags.CrystariumFlags.HalfSecondaryCPCost)
                    flag.FlagEnabled = false;
                else if (flag == Flags.EnemyFlags.BoostLevel)
                {

                }
                else
                    flag.FlagEnabled = true;
            }
            ((FlagValue)Flags.ItemFlags.Drops.FlagData).Range.Value = 50;
            ((FlagValue)Flags.ItemFlags.Treasures.FlagData).Range.Value = 50;
            ((FlagValue)Flags.CrystariumFlags.RandStats.FlagData).Range.Value = 80;
            ((FlagValue)Flags.EnemyFlags.RandStats.FlagData).Range.Value = 75;
            ((FlagValue)Flags.EnemyFlags.RandLevel.FlagData).Range.Value = 35;
            //((FlagBool)Flags.EnemyFlags.Resistances.FlagData).Value = true;

            MessageBox.Show("Applied!");
        }

        private void presetRuthless_Click(object sender, EventArgs e)
        {
            foreach (Flag flag in Flags.flags)
            {
                if (flag == Flags.CrystariumFlags.LibraStart || 
                    flag == Flags.CrystariumFlags.ScaledCPCost || 
                    flag == Flags.CrystariumFlags.HalfSecondaryCPCost)
                    flag.FlagEnabled = false;
                else if (flag == Flags.EnemyFlags.BoostLevel)
                {

                }
                else
                    flag.FlagEnabled = true;
            }
            ((FlagValue)Flags.ItemFlags.Drops.FlagData).Range.Value = 100;
            ((FlagValue)Flags.ItemFlags.Treasures.FlagData).Range.Value = 100;
            ((FlagValue)Flags.CrystariumFlags.RandStats.FlagData).Range.Value = 100;
            ((FlagValue)Flags.EnemyFlags.RandStats.FlagData).Range.Value = 100;
            ((FlagValue)Flags.EnemyFlags.RandLevel.FlagData).Range.Value = 50;
            //((FlagBool)Flags.EnemyFlags.Resistances.FlagData).Value = true;

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

        private void FullUninstall(BackgroundWorker backgroundWorker)
        {
            if (!Directory.Exists(randoPath))
            {
                MessageBox.Show("Randomizer hasn't extracted the files...no reason to uninstall.");
                return;
            }
            File.Copy(randoPath + "\\filelistu.win32.bin", GetFF13Directory() + "\\white_data\\sys\\filelistu.win32.bin", true);
            backgroundWorker.ReportProgress(50);
            File.Copy(randoPath + "\\white_imgu.win32.bin", GetFF13Directory() + "\\white_data\\sys\\white_imgu.win32.bin", true);
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
