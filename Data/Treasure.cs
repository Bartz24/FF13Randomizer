using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FF13Data
{
    public enum TreasureArea
    {
        TheHangingEdge,
        ThePulseVestige,
        LakeBresha,
        TheVilePeaks,
        GapraWhitewood,
        SunlethWaterscape,
        Palumpolum,
        Nautilus,
        ThePalamecia,
        FifthArk,
        VallisMedia,
        TheArchylteSteppe,
        Mahhabara,
        SulyyaSprings,
        TaejinsTower,
        Oerba,
        YaschasMassif,
        TheFaultwarrens,
        Eden,
        OrphansCradle,
        Mission,
        UnknownOrUnused
    }

    public class Treasure : Identifier
    {
        public string Name { get; set; }
        public TreasureArea Area { get; set; }

        public Treasure(string name, string id, TreasureArea area)
        {
            this.Name = name;
            this.ID = id;
            this.Area = area;
            Treasures.treasures.Add(this);
        }
    }
}
