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
    public class RandoItems : Randomizer
    {
        public DataStoreWDB<DataStoreItem> items;

        public RandoItems(FormMain formMain, RandomizerManager randomizers) : base(formMain, randomizers) { }

        public override string GetProgressMessage()
        {
            return "Randomizing Items...";
        }
        public override string GetID()
        {
            return "Items";
        }

        public override void Load()
        {
            items = new DataStoreWDB<DataStoreItem>();
            items.LoadData(File.ReadAllBytes($"{main.RandoPath}\\original\\db\\resident\\item.wdb"));

            ApplyModifications();
        }

        private void ApplyModifications()
        {
            Dictionary<Item, uint> newBuyPrices = new Dictionary<Item, uint>();

            newBuyPrices.Add(Items.EmberRing, 4000);
            newBuyPrices.Add(Items.FrostRing, 4000);
            newBuyPrices.Add(Items.SparkRing, 4000);
            newBuyPrices.Add(Items.AquaRing, 4000);
            newBuyPrices.Add(Items.ZephyrRing, 4000);
            newBuyPrices.Add(Items.ClayRing, 4000);
            newBuyPrices.Add(Items.AuroraScarf, 9000);
            newBuyPrices.Add(Items.WarlocksGlove, 11000);
            newBuyPrices.Add(Items.TektiteBuckle, 11000);
            newBuyPrices.Add(Items.CeramicArmband, 11000);
            newBuyPrices.Add(Items.SafeguardSachet, 11000);
            newBuyPrices.Add(Items.DragonflyOrb, 11000);
            newBuyPrices.Add(Items.StarfallPendant, 11000);
            newBuyPrices.Add(Items.GemstoneNecklace, 11000);
            newBuyPrices.Add(Items.HexbaneTalisman, 11000);
            newBuyPrices.Add(Items.PainDeflector, 11000);
            newBuyPrices.Add(Items.EffulgentCape, 11000);
            newBuyPrices.Add(Items.MoonbowAnklet, 11000);
            newBuyPrices.Add(Items.SeraphsCrown, 11000);
            newBuyPrices.Add(Items.FlameshieldEarring, 11000);
            newBuyPrices.Add(Items.FrostshieldEarring, 11000);
            newBuyPrices.Add(Items.SparkshieldEarring, 11000);
            newBuyPrices.Add(Items.AquashieldEarring, 11000);
            newBuyPrices.Add(Items.BlazeRing, 15000);
            newBuyPrices.Add(Items.IcicleRing, 15000);
            newBuyPrices.Add(Items.FulmenRing, 15000);
            newBuyPrices.Add(Items.RiptideRing, 15000);
            newBuyPrices.Add(Items.GaleRing, 15000);
            newBuyPrices.Add(Items.StilstoneRing, 15000);
            newBuyPrices.Add(Items.ShieldTalisman, 17000);
            newBuyPrices.Add(Items.SoulfontTalisman, 17000);
            newBuyPrices.Add(Items.ShroudingTalisman, 17000);
            newBuyPrices.Add(Items.MoraleTalisman, 17000);
            newBuyPrices.Add(Items.BlessedTalisman, 17000);
            newBuyPrices.Add(Items.BattleTalisman, 17000);
            newBuyPrices.Add(Items.SprintShoes, 17000);
            newBuyPrices.Add(Items.SurvivalistCatalog, 26000);
            newBuyPrices.Add(Items.PowerGlove, 38000);
            newBuyPrices.Add(Items.WeirdingGlyph, 38000);
            newBuyPrices.Add(Items.SalamandrineRing, 40000);
            newBuyPrices.Add(Items.BorealRing, 40000);
            newBuyPrices.Add(Items.RaijinRing, 40000);
            newBuyPrices.Add(Items.NereidRing, 40000);
            newBuyPrices.Add(Items.SylphidRing, 40000);
            newBuyPrices.Add(Items.GaianRing, 40000);
            newBuyPrices.Add(Items.ChampionsBelt, 51000);
            newBuyPrices.Add(Items.MagussBracelet, 51000);
            newBuyPrices.Add(Items.FeralPride, 59000);
            newBuyPrices.Add(Items.TetradicCrown, 60000);
            newBuyPrices.Add(Items.Flamberge, 66000);
            newBuyPrices.Add(Items.Altairs, 66000);
            newBuyPrices.Add(Items.BrightwingStaff, 75000);
            newBuyPrices.Add(Items.HuntersRod, 82000);
            newBuyPrices.Add(Items.SurvivalistCatalog, 90000);
            newBuyPrices.Add(Items.Jatayu, 91000);
            newBuyPrices.Add(Items.OrochiRod, 98000);
            newBuyPrices.Add(Items.KaiserKnuckles, 113000);
            newBuyPrices.Add(Items.MagistralCrest, 113000);
            newBuyPrices.Add(Items.HuntersFriend, 120000);
            newBuyPrices.Add(Items.CanopusAMPs, 130000);
            newBuyPrices.Add(Items.Eagletalon, 140000);
            newBuyPrices.Add(Items.RazorCarbine, 150000);
            newBuyPrices.Add(Items.BattleStandard, 150000);
            newBuyPrices.Add(Items.Glaive, 150000);
            newBuyPrices.Add(Items.EnergySash, 180000);
            newBuyPrices.Add(Items.ChampionsBadge, 190000);
            newBuyPrices.Add(Items.Ethersol, 200000);
            newBuyPrices.Add(Items.TetradicTiara, 200000);
            newBuyPrices.Add(Items.Skycutter, 210000);
            newBuyPrices.Add(Items.Rhomphaia, 220000);
            newBuyPrices.Add(Items.Helterskelter, 230000);
            newBuyPrices.Add(Items.WarriorsEmblem, 230000);
            newBuyPrices.Add(Items.ErinyesCane, 230000);
            newBuyPrices.Add(Items.Gungnir, 280000);
            newBuyPrices.Add(Items.Ribbon, 310000);
            newBuyPrices.Add(Items.SiriusSidearms, 310000);
            newBuyPrices.Add(Items.Enkindler, 320000);
            newBuyPrices.Add(Items.CalamitySpear, 340000);
            newBuyPrices.Add(Items.Hresvelgr, 360000);
            newBuyPrices.Add(Items.Caladrius, 380000);
            newBuyPrices.Add(Items.PolarisSpecials, 400000);
            newBuyPrices.Add(Items.PhysiciansStaff, 420000);
            newBuyPrices.Add(Items.Peacemaker, 430000);
            newBuyPrices.Add(Items.Durandal, 430000);
            newBuyPrices.Add(Items.WingedSaint, 430000);
            newBuyPrices.Add(Items.MidnightSun, 450000);
            newBuyPrices.Add(Items.Tezcatlipoca, 450000);
            newBuyPrices.Add(Items.HyadesMagnums, 450000);
            newBuyPrices.Add(Items.FomalhautElites, 470000);
            newBuyPrices.Add(Items.GoddesssFavor, 480000);
            newBuyPrices.Add(Items.HereticsHalberd, 490000);
            newBuyPrices.Add(Items.Abraxas, 510000);
            newBuyPrices.Add(Items.SoulBlazer, 530000);
            newBuyPrices.Add(Items.GoldWatch, 540000);
            newBuyPrices.Add(Items.VenusGospel, 580000);
            newBuyPrices.Add(Items.UltimaWeapon, 600000);
            newBuyPrices.Add(Items.Urubutsin, 600000);
            newBuyPrices.Add(Items.BetelgeuseCustoms, 640000);
            newBuyPrices.Add(Items.BanescissorSpear, 660000);
            newBuyPrices.Add(Items.MalboroWand, 670000);
            newBuyPrices.Add(Items.Solaris, 700000);
            newBuyPrices.Add(Items.GrowthEgg, 1100000);
            newBuyPrices.Add(Items.SuperRibbon, 1200000);
            newBuyPrices.Add(Items.DoctorsCode, 1400000);
            newBuyPrices.Add(Items.Elixir, 2000000);
            newBuyPrices.Add(Items.OmegaWeapon6, 2200000);
            newBuyPrices.Add(Items.TotalEclipses5, 2200000);
            newBuyPrices.Add(Items.SaveTheQueen6, 2200000);
            newBuyPrices.Add(Items.Nue7, 2200000);
            newBuyPrices.Add(Items.KainsLance7, 2200000);
            newBuyPrices.Add(Items.TotalEclipses6, 2300000);
            newBuyPrices.Add(Items.SaveTheQueen1, 2300000);
            newBuyPrices.Add(Items.Nue4, 2300000);
            newBuyPrices.Add(Items.Nirvana8, 2300000);
            newBuyPrices.Add(Items.OmegaWeapon7, 2400000);
            newBuyPrices.Add(Items.TotalEclipses4, 2400000);
            newBuyPrices.Add(Items.SaveTheQueen7, 2400000);
            newBuyPrices.Add(Items.OmegaWeapon1, 2500000);
            newBuyPrices.Add(Items.TotalEclipses1, 2500000);
            newBuyPrices.Add(Items.Nue2, 2500000);
            newBuyPrices.Add(Items.TotalEclipses3, 2600000);
            newBuyPrices.Add(Items.SaveTheQueen4, 2600000);
            newBuyPrices.Add(Items.OmegaWeapon3, 2700000);
            newBuyPrices.Add(Items.GenjiGlove, 2800000);
            newBuyPrices.Add(Items.OmegaWeapon5, 3100000);
            newBuyPrices.Add(Items.Nirvana4, 3200000);
            newBuyPrices.Add(Items.Nirvana1, 3300000);
            newBuyPrices.Add(Items.Nue1, 3400000);
            newBuyPrices.Add(Items.TotalEclipses2, 3500000);
            newBuyPrices.Add(Items.SaveTheQueen3, 3500000);
            newBuyPrices.Add(Items.Nirvana5, 3500000);
            newBuyPrices.Add(Items.OmegaWeapon2, 3600000);
            newBuyPrices.Add(Items.KainsLance1, 3600000);
            newBuyPrices.Add(Items.KainsLance3, 3700000);
            newBuyPrices.Add(Items.OmegaWeapon4, 3900000);
            newBuyPrices.Add(Items.SaveTheQueen2, 3900000);
            newBuyPrices.Add(Items.Nue5, 3900000);
            newBuyPrices.Add(Items.TotalEclipses7, 4000000);
            newBuyPrices.Add(Items.SaveTheQueen5, 4100000);
            newBuyPrices.Add(Items.OmegaWeapon8, 4200000);
            newBuyPrices.Add(Items.Nue6, 4200000);
            newBuyPrices.Add(Items.TotalEclipses8, 4400000);
            newBuyPrices.Add(Items.Nue3, 4400000);
            newBuyPrices.Add(Items.SaveTheQueen8, 4500000);
            newBuyPrices.Add(Items.Nirvana3, 4900000);
            newBuyPrices.Add(Items.KainsLance8, 4900000);
            newBuyPrices.Add(Items.KainsLance6, 5000000);
            newBuyPrices.Add(Items.Nue8, 5100000);
            newBuyPrices.Add(Items.KainsLance2, 5100000);
            newBuyPrices.Add(Items.Nirvana2, 5200000);
            newBuyPrices.Add(Items.Nirvana6, 5200000);
            newBuyPrices.Add(Items.KainsLance4, 5400000);
            newBuyPrices.Add(Items.Nirvana7, 5600000);
            newBuyPrices.Add(Items.KainsLance5, 5600000);
            newBuyPrices.Add(Items.Godslayer, 16000000);
            newBuyPrices.Add(Items.DeathPenalties, 16000000);
            newBuyPrices.Add(Items.Omnipotence, 16000000);
            newBuyPrices.Add(Items.RisingSun, 16000000);
            newBuyPrices.Add(Items.FaerieTail, 16000000);
            newBuyPrices.Add(Items.Longinus, 16000000);

            foreach(Item item in newBuyPrices.Keys)
            {
                items[item].BuyPrice = newBuyPrices[item];
            }
        }

        public override void Randomize(BackgroundWorker backgroundWorker)
        {            
        }

        public override void Save()
        {
            File.WriteAllBytes("db\\resident\\item.wdb", items.Data);
        }
    }
}
