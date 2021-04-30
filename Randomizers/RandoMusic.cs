using FF13Data;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Bartz24.Docs;

namespace FF13Randomizer
{
    public class RandoMusic : Randomizer
    {
        List<string> soundFiles = new List<string>();
        List<string> newSoundFiles = new List<string>();
        Dictionary<string, string> names = new Dictionary<string, string>();
        public RandoMusic(FormMain formMain, RandomizerManager randomizers) : base(formMain, randomizers) { }

        public override string GetProgressMessage()
        {
            return "Randomizing Music...";
        }
        public override string GetID()
        {
            return "Music";
        }

        public override void Load()
        {
            soundFiles.AddRange(main.fileNamesModified.Where(n => n.Contains("music_"))); 
            //names.Add("sound/pack/8000/usa/music_100rosh.win32.scd", "Those For The Purge 1"); eh
            //names.Add("sound/pack/8000/usa/music_101ldun_f.win32.scd", "UNKNOWN"); silent
            names.Add("sound/pack/8000/usa/music_102far3_b.win32.scd", "Born Anew");
            //names.Add("sound/pack/8000/usa/music_105kibou.win32.scd", "Miracles"); does not loop
            names.Add("sound/pack/8000/usa/music_105kyoufu.win32.scd", "Sinful Hope");
            //names.Add("sound/pack/8000/usa/music_105saigo.win32.scd", "UNKNOWN"); does not loop
            //names.Add("sound/pack/8000/usa/music_105titarr.win32.scd", "Fabula Nova Crystallis"); does not loop
            names.Add("sound/pack/8000/usa/music_106ofa2_b.win32.scd", "Nascent Requiem"); 
            names.Add("sound/pack/8000/usa/music_12snow_1.win32.scd", "Snow's Theme");
            names.Add("sound/pack/8000/usa/music_13gekai_f.win32.scd", "The Vestige");
            //names.Add("sound/pack/8000/usa/music_14fmv.win32.scd", "UNKNOWN"); probably doesn't loop
            names.Add("sound/pack/8000/usa/music_150sinpi.win32.scd", "Mysteries Abound");
            names.Add("sound/pack/8000/usa/music_151run.win32.scd", "March of the Dreadnoughts");
            names.Add("sound/pack/8000/usa/music_152magni.win32.scd", "Terra Incognita");
            //names.Add("sound/pack/8000/usa/music_153fuan.win32.scd", "The Final Stage"); eh
            names.Add("sound/pack/8000/usa/music_154syuge2.win32.scd", "Fang's Theme 1");
            names.Add("sound/pack/8000/usa/music_155far1or.win32.scd", "Fighting Fate (No Lyrics)");
            names.Add("sound/pack/8000/usa/music_156far3or.win32.scd", "Born Anew (No Lyrics)");
            names.Add("sound/pack/8000/usa/music_158opn1_i.win32.scd", "Defiers of Fate 1");
            names.Add("sound/pack/8000/usa/music_159opn_b.win32.scd", "Defiers of Fate 2");
            names.Add("sound/pack/8000/usa/music_160field.win32.scd", "Sulyya Springs");
            names.Add("sound/pack/8000/usa/music_161bo_fi.win32.scd", "Will to Fight");
            names.Add("sound/pack/8000/usa/music_162seifu.win32.scd", "The Pulse L'Cie 1");
            //names.Add("sound/pack/8000/usa/music_163gso.win32.scd", "UNKNOWN"); does not loop
            //names.Add("sound/pack/8000/usa/music_164fmv_2.win32.scd", "UNKNOWN"); probably doesn't loop
            //names.Add("sound/pack/8000/usa/music_165vin_ch.win32.scd", "Ragnarok 1"); eh
            //names.Add("sound/pack/8000/usa/music_166vin_u2.win32.scd", "Ragnarok 2"); eh
            names.Add("sound/pack/8000/usa/music_167choro.win32.scd", "The Yaschas Massif");
            //names.Add("sound/pack/8000/usa/music_168faru_l.win32.scd", "Lost Hope 1"); eh
            names.Add("sound/pack/8000/usa/music_16gfaru_b.win32.scd", "Test of the L'Cie");
            //names.Add("sound/pack/8000/usa/music_17pls.win32.scd", "Those For the Purge 2"); eh
            //names.Add("sound/pack/8000/usa/music_18vin_uta.win32.scd", "Ragnarok 3"); eh
            //names.Add("sound/pack/8000/usa/music_19hanabi.win32.scd", "In the Sky That Night"); eh
            //names.Add("sound/pack/8000/usa/music_20eien.win32.scd", "Promised Eternity 1"); eh
            names.Add("sound/pack/8000/usa/music_21sn_sera.win32.scd", "Serah's Theme");
            names.Add("sound/pack/8000/usa/music_26psicom.win32.scd", "The Pulse L'Cie 2");
            names.Add("sound/pack/8000/usa/music_27ansoku.win32.scd", "The Pulse L'Cie 3");
            names.Add("sound/pack/8000/usa/music_28shouk_b.win32.scd", "Eidolons");
            names.Add("sound/pack/8000/usa/music_29kihei.win32.scd", "Cavalry Theme");
            //names.Add("sound/pack/8000/usa/music_30hot.win32.scd", "UNKNOWN"); does not loop
            //names.Add("sound/pack/8000/usa/music_31grv.win32.scd", "UNKNOWN"); does not loop
            names.Add("sound/pack/8000/usa/music_32vpek_f.win32.scd", "The Vile Peaks");
            names.Add("sound/pack/8000/usa/music_33light_1.win32.scd", "Lightning's Theme");
            names.Add("sound/pack/8000/usa/music_34comical.win32.scd", "Feast of Betrayal");
            names.Add("sound/pack/8000/usa/music_36gapra_f.win32.scd", "The Gapra Whitewood");
            names.Add("sound/pack/8000/usa/music_39hope_1.win32.scd", "Hope's Theme");
            names.Add("sound/pack/8000/usa/music_40monst_b.win32.scd", "Desperate Struggle");
            //names.Add("sound/pack/8000/usa/music_41sra.win32.scd", "Those For The Purge 4"); eh
            names.Add("sound/pack/8000/usa/music_42snls_f.win32.scd", "The Sunleth Waterscape");
            names.Add("sound/pack/8000/usa/music_43sazh_1.win32.scd", "Daddy's Got The Blues");
            names.Add("sound/pack/8000/usa/music_44sazh_2a.win32.scd", "Sazh's Theme");
            names.Add("sound/pack/8000/usa/music_44sazh_3b.win32.scd", "Can't Catch a Break");
            names.Add("sound/pack/8000/usa/music_45kinpaku.win32.scd", "Tension in the Air");
            names.Add("sound/pack/8000/usa/music_46vani_1.win32.scd", "Vanille's Theme");
            names.Add("sound/pack/8000/usa/music_47ppm.win32.scd", "PSICOM");
            //names.Add("sound/pack/8000/usa/music_49farusi.win32.scd", "Lost Hope 2"); eh
            //names.Add("sound/pack/8000/usa/music_50abs.win32.scd", "Lost Hope 3"); eh
            names.Add("sound/pack/8000/usa/music_54snow_2.win32.scd", "The Warpath Home");
            //names.Add("sound/pack/8000/usa/music_55hope_fu.win32.scd", "Face It Later"); eh
            names.Add("sound/pack/8000/usa/music_56fang.win32.scd", "The Pulse L'Cie 4");
            names.Add("sound/pack/8000/usa/music_57snow_3.win32.scd", "Atonement");
            names.Add("sound/pack/8000/usa/music_59hope_ie.win32.scd", "This Is Your Home");
            //names.Add("sound/pack/8000/usa/music_61prd.win32.scd", "Those For The Purge 5"); eh
            names.Add("sound/pack/8000/usa/music_62nati_f.win32.scd", "Nautilus");
            names.Add("sound/pack/8000/usa/music_64choco_c.win32.scd", "Chocobos of Cocoon");
            //names.Add("sound/pack/8000/usa/music_65kanasii.win32.scd", "Promised Eternity 2"); eh
            //names.Add("sound/pack/8000/usa/music_67va_sazh.win32.scd", "UNKNOWN"); does not loop
            //names.Add("sound/pack/8000/usa/music_68tak.win32.scd", "UNKNOWN"); eh
            names.Add("sound/pack/8000/usa/music_6gameover.win32.scd", "Game Over");
            names.Add("sound/pack/8000/usa/music_70daisuri.win32.scd", "Primarch Dysley");
            //names.Add("sound/pack/8000/usa/music_71kanta_f.win32.scd", "UNKNOWN"); eh
            //names.Add("sound/pack/8000/usa/music_72waiban.win32.scd", "UNKNOWN"); eh
            names.Add("sound/pack/8000/usa/music_74faru1_b.win32.scd", "Fighting Fate");
            //names.Add("sound/pack/8000/usa/music_76pro.win32.scd", "UNKNOWN"); eh
            //names.Add("sound/pack/8000/usa/music_77fark_f.win32.scd", "UNKNOWN"); eh
            //names.Add("sound/pack/8000/usa/music_78rainz_2.win32.scd", "UNKNOWN"); eh
            names.Add("sound/pack/8000/usa/music_81gto.win32.scd", "Fang's Theme 2");
            //names.Add("sound/pack/8000/usa/music_83s_gp_f.win32.scd", "UNKNOWN"); eh
            names.Add("sound/pack/8000/usa/music_84daihe_f.win32.scd", "The Archylte Steppe");
            //names.Add("sound/pack/8000/usa/music_85gp_b.win32.scd", "UNKNOWN");
            names.Add("sound/pack/8000/usa/music_86choco_f.win32.scd", "Chocobos of Pulse");
            names.Add("sound/pack/8000/usa/music_89vani_2.win32.scd", "Vanille's Theme 2");
            //names.Add("sound/pack/8000/usa/music_90ligh_sn.win32.scd", "UNKNOWN");
            names.Add("sound/pack/8000/usa/music_91teiji_f.win32.scd", "Taejin's Tower");
            names.Add("sound/pack/8000/usa/music_92saiha_f.win32.scd", "Dust to Dust");
            //names.Add("sound/pack/8000/usa/music_93ragu_se.win32.scd", "UNKNOWN");
            //names.Add("sound/pack/8000/usa/music_96grp.win32.scd", "UNKNOWN");
            names.Add("sound/pack/8000/usa/music_97eden_pa.win32.scd", "Eden Under Seige");
            //names.Add("sound/pack/8000/usa/music_98hikari.win32.scd", "UNKNOWN");
            names.Add("sound/pack/8000/usa/music_bat_short.win32.scd", "Blinded by Light 1");
            names.Add("sound/pack/8000/usa/music_bossa.win32.scd", "Saber's Edge");
            //names.Add("sound/pack/8000/usa/music_dark.win32.scd", "UNKNOWN");
            //names.Add("sound/pack/8000/usa/music_fanfare.win32.scd", "UNKNOWN");
            names.Add("sound/pack/8000/usa/music_handsnow.win32.scd", "The Warpath Home 2");
            names.Add("sound/pack/8000/usa/music_handsnow2.win32.scd", "The Warpath Home 3");
            names.Add("sound/pack/8000/usa/music_madfade.win32.scd", "The Hanging Edge");
            names.Add("sound/pack/8000/usa/music_result.win32.scd", "Battle Results");
            //names.Add("sound/pack/8000/usa/music_snowfade.win32.scd", "UNKNOWN");
            names.Add("sound/pack/8000/usa/music_theme_b.win32.scd", "A Brief Respite");
            names.Add("sound/pack/8000/usa/music_title.win32.scd", "The Promise");
            names.Add("sound/pack/8000/usa/music_white_at.win32.scd", "Lake Bresha");
            names.Add("sound/pack/8000/usa/music_white_e3.win32.scd", "Blinded by Light 2");
        }
        public override void Randomize(BackgroundWorker backgroundWorker)
        {
            if (Flags.Other.Music)
            {
                Flags.Other.Music.SetRand();
                newSoundFiles.AddRange(soundFiles);
                newSoundFiles.Shuffle();
                RandomNum.ClearRand();
            }
        }

        public override HTMLPage GetDocumentation()
        {
            HTMLPage page = new HTMLPage("Music", "template/documentation.html");
            page.HTMLElements.Add(new Table("Music", new string[] { "Original Track", "New Track" }.ToList(), new int[] { 50, 50 }.ToList(), Enumerable.Range(0, soundFiles.Count).Select(i => new string[] { names[soundFiles[i]], names[newSoundFiles[i]] }.ToList()).ToList())); ;
            return page;
        }

        public override void Save()
        {
            string log = "";
            for (int i = 0; i < Math.Min(soundFiles.Count, newSoundFiles.Count); i++)
            {
                File.Copy($"{main.RandoPath}\\original\\{soundFiles[i]}", newSoundFiles[i], true);
                log += (names[soundFiles[i]] == "UNKNOWN" ? soundFiles[i] : names[soundFiles[i]]) + " => " + (names[newSoundFiles[i]] == "UNKNOWN" ? newSoundFiles[i] : names[newSoundFiles[i]]) + "\n";
            }
            File.WriteAllText("logs/music.txt", log);
        }
    }
}
