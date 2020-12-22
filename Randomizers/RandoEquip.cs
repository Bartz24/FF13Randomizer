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
    public class RandoEquip : Randomizer
    {
        public DataStoreWDB<DataStoreEquip, DataStoreID> equip;

        public RandoEquip(FormMain formMain, RandomizerManager randomizers) : base(formMain, randomizers) { }

        public override string GetProgressMessage()
        {
            return "Randomizing Equipment...";
        }
        public override string GetID()
        {
            return "Equip";
        }

        public override void Load()
        {
            equip = new DataStoreWDB<DataStoreEquip, DataStoreID>();
            equip.LoadData(File.ReadAllBytes($"{main.RandoPath}\\original\\db\\resident\\item_weapon.wdb"));
        }
        public override void Randomize(BackgroundWorker backgroundWorker)
        {
        }

        public override void Save()
        {
            File.WriteAllBytes("db\\resident\\item_weapon.wdb", equip.Data);
        }
    }
}
