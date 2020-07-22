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
        public ByteArray charaFamily;

        public RandoRunSpeed(FormMain formMain, RandomizerManager randomizers) : base(formMain, randomizers) { }

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
            charaFamily = new ByteArray(File.ReadAllBytes($"{main.RandoPath}\\original\\db\\resident\\charafamily.wdb"));
        }
        public override void Randomize(BackgroundWorker backgroundWorker)
        {
            if (Flags.Other.RunSpeed)
            {
                Flags.Other.RunSpeed.SetRand();
                StatValues runSpeeds = new StatValues(6);
                runSpeeds.Randomize(Flags.Other.RunSpeed.Range.Value);
                for(int i = 0; i < 6; i++)
                {
                    charaFamily.SetByte(0x9A34 + 0x17 + 0x58 * i, (byte)Math.Round(0x60 * runSpeeds[i] / 100f));
                }
                RandomNum.ClearRand();
            }
            if (Tweaks.Boosts.RunSpeedMultiplier)
            {
                for (int i = 0; i < 6; i++)
                {
                    charaFamily.SetByte(0x9A34 + 0x17 + 0x58 * i, (byte)Math.Round(charaFamily.ReadByte(0x9A34 + 0x17 + 0x58 * i) * (1 + Tweaks.Boosts.RunSpeedMultiplier.Range.Value) / 100f));
                }
            }
        }

        public override void Save()
        {
            File.WriteAllBytes("db\\resident\\charafamily.wdb", charaFamily.Data);
        }
    }
}
