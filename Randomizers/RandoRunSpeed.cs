using Bartz24.Data;
using Bartz24.Rando;
using FF13Data;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FF13Randomizer
{
    public class RandoRunSpeed : Randomizer
    {
        DataStoreWDB<DataStoreChara, DataStoreID> characters;
        FormMain main;

        public RandoRunSpeed(FormMain formMain, RandomizerManager randomizers) : base(randomizers) { main = formMain; }

        public override string GetProgressMessage()
        {
            return "Randomizing Run Speed...";
        }
        public override string GetID()
        {
            return "Run Speed";
        }

        public override void Load()
        {
            characters = new DataStoreWDB<DataStoreChara, DataStoreID>();
            characters.LoadData(File.ReadAllBytes($"{main.RandoPath}\\original\\db\\resident\\charafamily.wdb"));
        }
        public override void Randomize(BackgroundWorker backgroundWorker)
        {
            Dictionary<Character, int> plando = main.runSpeedPlando1.GetRunSpeeds();
            if (Flags.Other.RunSpeed)
            {
                Flags.Other.RunSpeed.SetRand();
                StatValues runSpeeds = new StatValues(6);

                Tuple<int, int>[] bounds = runSpeeds.GetVarianceBounds(Flags.Other.RunSpeed.Range.Value);
                for (int i = 0; i < 6; i++)
                {
                    if (plando.ContainsKey((Character)i))
                    {
                        bounds[i] = new Tuple<int, int>(plando[(Character)i] * 100 / 0x60, plando[(Character)i] * 100 / 0x60);
                        characters[GetID((Character)i)].RunSpeed = (byte)plando[(Character)i];
                    }
                }

                runSpeeds.Randomize(bounds, bounds.Where(b => b.Item1 != b.Item2).Count() * Flags.Other.RunSpeed.Range.Value);
                for(int i = 0; i < 6; i++)
                {
                    if (!plando.ContainsKey((Character)i))
                        characters[GetID((Character)i)].RunSpeed = (byte)Math.Round(0x60 * runSpeeds[i] / 100f);
                }
                RandomNum.ClearRand();
            }

            if (Tweaks.Boosts.RunSpeedMultiplier)
            {
                for (int i = 0; i < 6; i++)
                {
                    if (!Flags.Other.RunSpeed || !plando.ContainsKey((Character)i))
                        characters[GetID((Character)i)].RunSpeed = (byte)Math.Round(characters[GetID((Character)i)].RunSpeed * (100 + Tweaks.Boosts.RunSpeedMultiplier.Range.Value) / 100f);
                }
            }
        }

        public static string GetID(Character character)
        {
            switch (character)
            {
                case Character.Lightning:
                    return "fam_pc_light";
                case Character.Snow:
                    return "fam_pc_snow";
                case Character.Vanille:
                    return "fam_pc_vanira";
                case Character.Sazh:
                    return "fam_pc_sazz";
                case Character.Hope:
                    return "fam_pc_hope";
                case Character.Fang:
                    return "fam_pc_fang";
                default:
                    return "";
            }
        }

        public override void Save()
        {
            File.WriteAllBytes("db\\resident\\charafamily.wdb", characters.Data);
        }
    }
}
