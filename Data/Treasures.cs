using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FF13Data
{
    public class Treasures
    {
        public static List<Treasure> treasures = new List<Treasure>();

        #region The Hanging Edge

        public static Treasure heAT13E = new Treasure("Aerorail Trussway 13-E", "tre_hang_001", TreasureArea.TheHangingEdge);
        public static Treasure heAT12E1 = new Treasure("Aerorail Trussway 12-E 1", "tre_hang_002", TreasureArea.TheHangingEdge);
        public static Treasure heAT12E2 = new Treasure("Aerorail Trussway 12-E 2", "tre_hang_003", TreasureArea.TheHangingEdge);
        public static Treasure heAT11E = new Treasure("Aerorail Trussway 11-E", "tre_hang_004", TreasureArea.TheHangingEdge);
        public static Treasure heAT5W = new Treasure("Aerorail Trussway 5-W", "tre_hang_005", TreasureArea.TheHangingEdge);
        public static Treasure heAT6W = new Treasure("Aerorail Trussway 6-W", "tre_hang_006", TreasureArea.TheHangingEdge);
        public static Treasure heAT3N1 = new Treasure("Aerorail Trussway 3-N 1", "tre_hang_007", TreasureArea.TheHangingEdge);
        public static Treasure heAT3N2 = new Treasure("Aerorail Trussway 3-N 2", "tre_hang_008", TreasureArea.TheHangingEdge);

        #endregion

        #region The Pulse Vestige

        public static Treasure pvS1 = new Treasure("Sacrarium 1", "tre_hgin_014", TreasureArea.ThePulseVestige);
        public static Treasure pvS2 = new Treasure("Sacrarium 2", "tre_hgin_001", TreasureArea.ThePulseVestige);
        public static Treasure pvS3 = new Treasure("Sacrarium 3", "tre_hgin_012", TreasureArea.ThePulseVestige);
        public static Treasure pvS4 = new Treasure("Sacrarium 4", "tre_hgin_002", TreasureArea.ThePulseVestige);
        public static Treasure pvHoS1 = new Treasure("House of Stairs 1", "tre_hgin_011", TreasureArea.ThePulseVestige);
        public static Treasure pvHoS2 = new Treasure("House of Stairs 2", "tre_hgin_005", TreasureArea.ThePulseVestige);
        public static Treasure pvA1 = new Treasure("Ambulatory 1", "tre_hgin_006", TreasureArea.ThePulseVestige);
        public static Treasure pvA2 = new Treasure("Ambulatory 2", "tre_hgin_003", TreasureArea.ThePulseVestige);
        public static Treasure pvA3 = new Treasure("Ambulatory 3", "tre_hgin_007", TreasureArea.ThePulseVestige);
        public static Treasure pvO = new Treasure("Oblatorium", "tre_hgin_008", TreasureArea.ThePulseVestige);
        public static Treasure pvAT = new Treasure("Anima's Throne", "tre_hgin_010", TreasureArea.ThePulseVestige);

        #endregion

        #region Lake Bresha

        public static Treasure lbTWS1 = new Treasure("The Waters Stilled 1", "tre_hgcr_001", TreasureArea.LakeBresha);
        public static Treasure lbTWS2 = new Treasure("The Waters Stilled 2", "tre_hgcr_002", TreasureArea.LakeBresha);
        public static Treasure lbTWS3 = new Treasure("The Waters Stilled 3", "tre_hgcr_004", TreasureArea.LakeBresha);
        public static Treasure lbATW1 = new Treasure("Amid Timebound Waves 1", "tre_hgcr_005", TreasureArea.LakeBresha);
        public static Treasure lbATW2 = new Treasure("Amid Timebound Waves 2", "tre_hgcr_006", TreasureArea.LakeBresha);
        public static Treasure lbATW3 = new Treasure("Amid Timebound Waves 3", "tre_hgcr_028", TreasureArea.LakeBresha);
        public static Treasure lbATW4 = new Treasure("Amid Timebound Waves 4", "tre_hgcr_007", TreasureArea.LakeBresha);
        public static Treasure lbATW5 = new Treasure("Amid Timebound Waves 5", "tre_hgcr_008", TreasureArea.LakeBresha);
        public static Treasure lbATW6 = new Treasure("Amid Timebound Waves 6", "tre_hgcr_009", TreasureArea.LakeBresha);
        public static Treasure lbEiC1 = new Treasure("Encased in Crystal 1", "tre_hgcr_010", TreasureArea.LakeBresha);
        public static Treasure lbEiC2 = new Treasure("Encased in Crystal 2", "tre_hgcr_012", TreasureArea.LakeBresha);
        public static Treasure lbEiC3 = new Treasure("Encased in Crystal 3", "tre_hgcr_011", TreasureArea.LakeBresha);
        public static Treasure lbEiC4 = new Treasure("Encased in Crystal 4", "tre_hgcr_014", TreasureArea.LakeBresha);
        public static Treasure lbEiC5 = new Treasure("Encased in Crystal 5", "tre_hgcr_013", TreasureArea.LakeBresha);
        public static Treasure lbEiC6 = new Treasure("Encased in Crystal 6", "tre_hgcr_015", TreasureArea.LakeBresha);
        public static Treasure lbEiC7 = new Treasure("Encased in Crystal 7", "tre_hgcr_016", TreasureArea.LakeBresha);
        public static Treasure lbTFF1 = new Treasure("The Frozen Falls 1", "tre_hgcr_017", TreasureArea.LakeBresha);
        public static Treasure lbTFF2 = new Treasure("The Frozen Falls 2", "tre_hgcr_030", TreasureArea.LakeBresha);
        public static Treasure lbTFF3 = new Treasure("The Frozen Falls 3", "tre_hgcr_029", TreasureArea.LakeBresha);
        public static Treasure lbTMM1 = new Treasure("The Mirrored Morass 1", "tre_hgcr_019", TreasureArea.LakeBresha);
        public static Treasure lbTMM2 = new Treasure("The Mirrored Morass 2", "tre_hgcr_018", TreasureArea.LakeBresha);
        public static Treasure lbGoA1 = new Treasure("Gates of Antiquity 1", "tre_hgcr_020", TreasureArea.LakeBresha);
        public static Treasure lbGoA2 = new Treasure("Gates of Antiquity 2", "tre_hgcr_021", TreasureArea.LakeBresha);
        public static Treasure lbFC1 = new Treasure("Forgotten Commons 1", "tre_hgcr_022", TreasureArea.LakeBresha);
        public static Treasure lbFC2 = new Treasure("Forgotten Commons 2", "tre_hgcr_023", TreasureArea.LakeBresha);
        public static Treasure lbACNL1 = new Treasure("A City No Longer 1", "tre_hgcr_024", TreasureArea.LakeBresha);
        public static Treasure lbACNL2 = new Treasure("A City No Longer 2", "tre_hgcr_003", TreasureArea.LakeBresha);
        public static Treasure lbACNL3 = new Treasure("A City No Longer 3", "tre_hgcr_025", TreasureArea.LakeBresha);
        public static Treasure lbEofP1 = new Treasure("Echoes of the Past 1", "tre_hgcr_027", TreasureArea.LakeBresha);
        public static Treasure lbEofP2 = new Treasure("Echoes of the Past 2", "tre_hgcr_026", TreasureArea.LakeBresha);

        #endregion

        #region Vile Peaks

        public static Treasure vpWaR = new Treasure("Wrack and Ruin", "tre_vpek_001", TreasureArea.TheVilePeaks);
        public static Treasure vpAMT1 = new Treasure("Another Man's Treasure 1", "tre_vpek_002", TreasureArea.TheVilePeaks);
        public static Treasure vpAMT2 = new Treasure("Another Man's Treasure 2", "tre_vpek_003", TreasureArea.TheVilePeaks);
        public static Treasure vpMN1 = new Treasure("Munitions Necropolis 1", "tre_vpek_005", TreasureArea.TheVilePeaks);
        public static Treasure vpMN2 = new Treasure("Munitions Necropolis 2", "tre_vpek_004", TreasureArea.TheVilePeaks);
        public static Treasure vpDD1 = new Treasure("Devastated Dreams 1", "tre_vpek_006", TreasureArea.TheVilePeaks);
        public static Treasure vpDD2 = new Treasure("Devastated Dreams 2", "tre_vpek_007", TreasureArea.TheVilePeaks);
        public static Treasure vpST1 = new Treasure("Scavenger's Trail 1", "tre_vpek_010", TreasureArea.TheVilePeaks);
        public static Treasure vpST2 = new Treasure("Scavenger's Trail 2", "tre_vpek_011", TreasureArea.TheVilePeaks);
        public static Treasure vpST3 = new Treasure("Scavenger's Trail 3", "tre_vpek_019", TreasureArea.TheVilePeaks);
        public static Treasure vpST4 = new Treasure("Scavenger's Trail 4", "tre_vpek_012", TreasureArea.TheVilePeaks);
        public static Treasure vpST5 = new Treasure("Scavenger's Trail 5", "tre_vpek_013", TreasureArea.TheVilePeaks);
        public static Treasure vpSTPulseGil1 = new Treasure("Scavenger's Trail Pulse 40+", "tre_vpek_031", TreasureArea.TheVilePeaks);
        public static Treasure vpSTPulseGil2 = new Treasure("Scavenger's Trail Pulse 25-39", "tre_vpek_030", TreasureArea.TheVilePeaks);
        public static Treasure vpSTPulseGil3 = new Treasure("Scavenger's Trail Pulse 0-24", "tre_vpek_029", TreasureArea.TheVilePeaks);
        public static Treasure vpSTPulseItem1 = new Treasure("Scavenger's Trail Pulse 35+", "tre_vpek_028", TreasureArea.TheVilePeaks);
        public static Treasure vpSTPulseItem2 = new Treasure("Scavenger's Trail Pulse 25-34", "tre_vpek_027", TreasureArea.TheVilePeaks);
        public static Treasure vpSTPulseItem3 = new Treasure("Scavenger's Trail Pulse 0-24", "tre_vpek_026", TreasureArea.TheVilePeaks);
        public static Treasure vpSP1 = new Treasure("Scrap Processing 1", "tre_vpek_020", TreasureArea.TheVilePeaks);
        public static Treasure vpSP2 = new Treasure("Scrap Processing 2", "tre_vpek_016", TreasureArea.TheVilePeaks);
        public static Treasure vpSP3 = new Treasure("Scrap Processing 3", "tre_vpek_009", TreasureArea.TheVilePeaks);
        public static Treasure vpSP4 = new Treasure("Scrap Processing 4", "tre_vpek_017", TreasureArea.TheVilePeaks);
        public static Treasure vpSP5 = new Treasure("Scrap Processing 5", "tre_vpek_021", TreasureArea.TheVilePeaks);
        public static Treasure vpSP6 = new Treasure("Scrap Processing 6", "tre_vpek_014", TreasureArea.TheVilePeaks);
        public static Treasure vpSP7 = new Treasure("Scrap Processing 7", "tre_vpek_015", TreasureArea.TheVilePeaks);
        public static Treasure vpSP8 = new Treasure("Scrap Processing 8", "tre_vpek_018", TreasureArea.TheVilePeaks);

        #endregion

        #region Gapra Whitewood

        public static Treasure gwCW = new Treasure("Canopy Wardwalks", "tre_gapr_001", TreasureArea.GapraWhitewood);
        public static Treasure gwRC = new Treasure("Research Corridor", "tre_gapr_002", TreasureArea.GapraWhitewood);
        public static Treasure gwBRSD = new Treasure("Bioweapon Research Site D", "tre_gapr_003", TreasureArea.GapraWhitewood);
        public static Treasure gwFTRS = new Treasure("Field Trial Range S", "tre_gapr_004", TreasureArea.GapraWhitewood);
        public static Treasure gwFTRN = new Treasure("Field Trial Range N", "tre_gapr_005", TreasureArea.GapraWhitewood);
        public static Treasure gwER1 = new Treasure("Environmental Regulation 1", "tre_gapr_006", TreasureArea.GapraWhitewood);
        public static Treasure gwER2 = new Treasure("Environmental Regulation 2", "tre_gapr_007", TreasureArea.GapraWhitewood);
        public static Treasure gwER3 = new Treasure("Environmental Regulation 3", "tre_gapr_008", TreasureArea.GapraWhitewood);
        public static Treasure gwBM = new Treasure("Bioweapons Maintenance", "tre_gapr_009", TreasureArea.GapraWhitewood);

        #endregion

        #region Sunleth Waterscape

        public static Treasure swTOG = new Treasure("The Old Growth", "tre_snls_001", TreasureArea.SunlethWaterscape);
        public static Treasure swST1 = new Treasure("Sun-dappled Trail 1", "tre_snls_002", TreasureArea.SunlethWaterscape);
        public static Treasure swST2 = new Treasure("Sun-dappled Trail 2", "tre_snls_003", TreasureArea.SunlethWaterscape);
        public static Treasure swST3 = new Treasure("Sun-dappled Trail 3", "tre_snls_004", TreasureArea.SunlethWaterscape);
        public static Treasure swASS1 = new Treasure("A Shimmering Sky 1", "tre_snls_005", TreasureArea.SunlethWaterscape);
        public static Treasure swASS2 = new Treasure("A Shimmering Sky 2", "tre_snls_007", TreasureArea.SunlethWaterscape);
        public static Treasure swASS3 = new Treasure("A Shimmering Sky 3", "tre_snls_006", TreasureArea.SunlethWaterscape);
        public static Treasure swRV1 = new Treasure("Rain-spotted Vale 1", "tre_snls_008", TreasureArea.SunlethWaterscape);
        public static Treasure swRV2 = new Treasure("Rain-spotted Vale 2", "tre_snls_009", TreasureArea.SunlethWaterscape);

        #endregion

        #region Palumpolum

        public static Treasure pTM1 = new Treasure("The Metrostile 1", "tre_pmpm_001", TreasureArea.Palumpolum);
        public static Treasure pTM2 = new Treasure("The Metrostile 2", "tre_pmpm_002", TreasureArea.Palumpolum);
        public static Treasure pTM3 = new Treasure("The Metrostile 3", "tre_pmpm_003", TreasureArea.Palumpolum);
        public static Treasure pNC1 = new Treasure("Nutriculture Complex 1", "tre_pmpm_005", TreasureArea.Palumpolum);
        public static Treasure pNC2 = new Treasure("Nutriculture Complex 2", "tre_pmpm_012", TreasureArea.Palumpolum);
        public static Treasure pNC3 = new Treasure("Nutriculture Complex 3", "tre_pmpm_023", TreasureArea.Palumpolum);
        public static Treasure pNC4 = new Treasure("Nutriculture Complex 4", "tre_pmpm_024", TreasureArea.Palumpolum);
        public static Treasure pNC5 = new Treasure("Nutriculture Complex 5", "tre_pmpm_004", TreasureArea.Palumpolum);
        public static Treasure pPT1 = new Treasure("Pedestrian Terraces 1", "tre_pmpm_006", TreasureArea.Palumpolum);
        public static Treasure pPT2 = new Treasure("Pedestrian Terraces 2", "tre_pmpm_008", TreasureArea.Palumpolum);
        public static Treasure pPT3 = new Treasure("Pedestrian Terraces 3", "tre_pmpm_013", TreasureArea.Palumpolum);
        public static Treasure pWP1 = new Treasure("Western Promenade 1", "tre_pmpm_010", TreasureArea.Palumpolum);
        public static Treasure pWP2 = new Treasure("Western Promenade 2", "tre_pmpm_026", TreasureArea.Palumpolum);
        public static Treasure pWP3 = new Treasure("Western Promenade 3", "tre_pmpm_019", TreasureArea.Palumpolum);
        public static Treasure pWP4 = new Treasure("Western Promenade 4", "tre_pmpm_020", TreasureArea.Palumpolum);
        public static Treasure pCA1 = new Treasure("Central Arcade 1", "tre_pmpm_014", TreasureArea.Palumpolum);
        public static Treasure pCA2 = new Treasure("Central Arcade 2", "tre_pmpm_025", TreasureArea.Palumpolum);
        public static Treasure pRT1 = new Treasure("Rivera Towers 1", "tre_pmpm_016", TreasureArea.Palumpolum);
        public static Treasure pRT2 = new Treasure("Rivera Towers 2", "tre_pmpm_017", TreasureArea.Palumpolum);
        public static Treasure pRT3 = new Treasure("Rivera Towers 3", "tre_pmpm_009", TreasureArea.Palumpolum);
        public static Treasure pRT4 = new Treasure("Rivera Towers 4", "tre_pmpm_011", TreasureArea.Palumpolum);
        public static Treasure pRT5 = new Treasure("Rivera Towers 5", "tre_pmpm_018", TreasureArea.Palumpolum);
        public static Treasure pFH1 = new Treasure("Felix Heights 1", "tre_pmpm_022", TreasureArea.Palumpolum);
        public static Treasure pFH2 = new Treasure("Felix Heights 2", "tre_pmpm_021", TreasureArea.Palumpolum);
        public static Treasure pTER1 = new Treasure("The Estheim Residence 1", "tre_pmpm_007", TreasureArea.Palumpolum);
        public static Treasure pTER2 = new Treasure("The Estheim Residence 2", "tre_pmpm_028", TreasureArea.Palumpolum);
        public static Treasure pTER3 = new Treasure("The Estheim Residence 3", "tre_pmpm_027", TreasureArea.Palumpolum);

        #endregion

        #region Nautilus

        public static Treasure nPS = new Treasure("Park Square", "tre_nati_005", TreasureArea.Nautilus);
        public static Treasure nCC = new Treasure("Chocobo Corral", "tre_nati_004", TreasureArea.Nautilus);
        public static Treasure nM = new Treasure("The Mall", "tre_nati_001", TreasureArea.Nautilus);
        public static Treasure nTCT1 = new Treasure("The Clock Tower 1", "tre_nati_002", TreasureArea.Nautilus);
        public static Treasure nTCT2 = new Treasure("The Clock Tower 2", "tre_nati_003", TreasureArea.Nautilus);

        #endregion

        #region The Palamecia

        public static Treasure tpSLD = new Treasure("Short-field Landing Deck", "tre_hiku_001", TreasureArea.ThePalamecia);
        public static Treasure tpEB1 = new Treasure("External Berths 1", "tre_hiku_002", TreasureArea.ThePalamecia);
        public static Treasure tpEB2 = new Treasure("External Berths 2", "tre_hiku_003", TreasureArea.ThePalamecia);
        public static Treasure tpEB3 = new Treasure("External Berths 3", "tre_hiku_004", TreasureArea.ThePalamecia);
        public static Treasure tpCC1 = new Treasure("Crew Corridors 1", "tre_hiku_005", TreasureArea.ThePalamecia);
        public static Treasure tpCC2 = new Treasure("Crew Corridors 2", "tre_hiku_006", TreasureArea.ThePalamecia);
        public static Treasure tpCC3 = new Treasure("Crew Corridors 3", "tre_hiku_007", TreasureArea.ThePalamecia);
        public static Treasure tpCA1 = new Treasure("Cargo Access 1", "tre_hiku_009", TreasureArea.ThePalamecia);
        public static Treasure tpCA2 = new Treasure("Cargo Access 2", "tre_hiku_008", TreasureArea.ThePalamecia);
        public static Treasure tpRS1 = new Treasure("Rotary Shaft 1", "tre_hiku_011", TreasureArea.ThePalamecia);
        public static Treasure tpRS2 = new Treasure("Rotary Shaft 2", "tre_hiku_013", TreasureArea.ThePalamecia);
        public static Treasure tpRS3 = new Treasure("Rotary Shaft 3", "tre_hiku_012", TreasureArea.ThePalamecia);
        public static Treasure tpRS4 = new Treasure("Rotary Shaft 4", "tre_hiku_010", TreasureArea.ThePalamecia);
        public static Treasure tpPEB1 = new Treasure("Primary Engine Bay 1", "tre_hiku_015", TreasureArea.ThePalamecia);
        public static Treasure tpPEB2 = new Treasure("Primary Engine Bay 2", "tre_hiku_014", TreasureArea.ThePalamecia);
        public static Treasure tpSWD1 = new Treasure("Starboard Weather Deck 1", "tre_hiku_016", TreasureArea.ThePalamecia);
        public static Treasure tpSWD2 = new Treasure("Starboard Weather Deck 2", "tre_hiku_017", TreasureArea.ThePalamecia);
        public static Treasure tpSWD3 = new Treasure("Starboard Weather Deck 3", "tre_hiku_018", TreasureArea.ThePalamecia);
        public static Treasure tpSWD4 = new Treasure("Starboard Weather Deck 4", "tre_hiku_019", TreasureArea.ThePalamecia);
        public static Treasure tpSWD5 = new Treasure("Starboard Weather Deck 5", "tre_hiku_020", TreasureArea.ThePalamecia);
        public static Treasure tpBA1 = new Treasure("Bridge Access 1", "tre_hiku_023", TreasureArea.ThePalamecia);
        public static Treasure tpBA2 = new Treasure("Bridge Access 2", "tre_hiku_022", TreasureArea.ThePalamecia);
        public static Treasure tpBA3 = new Treasure("Bridge Access 3", "tre_hiku_021", TreasureArea.ThePalamecia);
        public static Treasure tpBA4 = new Treasure("Bridge Access 4", "tre_hiku_024", TreasureArea.ThePalamecia);
        public static Treasure tpBA5 = new Treasure("Bridge Access 5", "tre_hiku_025", TreasureArea.ThePalamecia);
        public static Treasure tpBA6 = new Treasure("Bridge Access 6", "tre_hiku_027", TreasureArea.ThePalamecia);
        public static Treasure tpBA7 = new Treasure("Bridge Access 7", "tre_hiku_026", TreasureArea.ThePalamecia);
        public static Treasure tpBA8 = new Treasure("Bridge Access 8", "tre_hiku_028", TreasureArea.ThePalamecia);

        #endregion

        #region Fifth Ark

        public static Treasure faVH1 = new Treasure("Vestibular Hold 1", "tre_fark_001", TreasureArea.FifthArk);
        public static Treasure faVH2 = new Treasure("Vestibular Hold 2", "tre_fark_002", TreasureArea.FifthArk);
        public static Treasure faLT1 = new Treasure("Lower Traverse 1", "tre_fark_003", TreasureArea.FifthArk);
        public static Treasure faLT2 = new Treasure("Lower Traverse 2", "tre_fark_004", TreasureArea.FifthArk);
        public static Treasure faLT3 = new Treasure("Lower Traverse 3", "tre_fark_005", TreasureArea.FifthArk);
        public static Treasure faHC = new Treasure("High Conflux", "tre_fark_015", TreasureArea.FifthArk);
        public static Treasure faHi = new Treasure("Hibernatorium", "tre_fark_006", TreasureArea.FifthArk);
        public static Treasure faIC1 = new Treasure("Inner Circuit 1", "tre_fark_007", TreasureArea.FifthArk);
        public static Treasure faIC2 = new Treasure("Inner Circuit 2", "tre_fark_013", TreasureArea.FifthArk);
        public static Treasure faIC3 = new Treasure("Inner Circuit 3", "tre_fark_008", TreasureArea.FifthArk);
        public static Treasure faIC4 = new Treasure("Inner Circuit 4", "tre_fark_009", TreasureArea.FifthArk);
        public static Treasure faIC5 = new Treasure("Inner Circuit 5", "tre_fark_014", TreasureArea.FifthArk);
        public static Treasure faTS = new Treasure("The Synthrona", "tre_fark_010", TreasureArea.FifthArk);
        public static Treasure faHy = new Treasure("Hypogeum", "tre_fark_011", TreasureArea.FifthArk);
        public static Treasure faSC = new Treasure("Substratal Conflux", "tre_fark_012", TreasureArea.FifthArk);

        #endregion

        #region Vallis Media

        public static Treasure vmFoS = new Treasure("Fingers of Stone", "tre_gpcg_001", TreasureArea.VallisMedia);
        public static Treasure vmAT = new Treasure("Atzilut's Tears", "tre_gpcg_002", TreasureArea.VallisMedia);

        #endregion

        #region The Archylte Steppe

        public static Treasure asCE1 = new Treasure("Central Expanse 1", "tre_gpda_001", TreasureArea.TheArchylteSteppe);
        public static Treasure asCE2 = new Treasure("Central Expanse 2", "tre_gpda_005", TreasureArea.TheArchylteSteppe);
        public static Treasure asCE3 = new Treasure("Central Expanse 3", "tre_gpda_006", TreasureArea.TheArchylteSteppe);
        public static Treasure asCE4 = new Treasure("Central Expanse 4", "tre_gpda_003", TreasureArea.TheArchylteSteppe);
        public static Treasure asCE5 = new Treasure("Central Expanse 5", "tre_gpda_019", TreasureArea.TheArchylteSteppe);
        public static Treasure asCE6 = new Treasure("Central Expanse 6", "tre_gpda_004", TreasureArea.TheArchylteSteppe);
        public static Treasure asNH1 = new Treasure("Northern Highplain 1", "tre_gpda_023", TreasureArea.TheArchylteSteppe);
        public static Treasure asNH2 = new Treasure("Northern Highplain 2 (East Guarded?)", "tre_gpda_015", TreasureArea.TheArchylteSteppe);
        public static Treasure asNH3 = new Treasure("Northern Highplain 3 (West Guarded?)", "tre_gpda_020", TreasureArea.TheArchylteSteppe);
        public static Treasure asNH4 = new Treasure("Northern Highplain 4", "tre_gpda_014", TreasureArea.TheArchylteSteppe);
        public static Treasure asNH5 = new Treasure("Northern Highplain 5 (East Chocobo?)", "tre_gpda_029", TreasureArea.TheArchylteSteppe);
        public static Treasure asWB1 = new Treasure("Western Benchland 1", "tre_gpda_013", TreasureArea.TheArchylteSteppe);
        public static Treasure asWB2 = new Treasure("Western Benchland 2", "tre_gpda_002", TreasureArea.TheArchylteSteppe);
        public static Treasure asWB3 = new Treasure("Western Benchland 3", "tre_gpda_030", TreasureArea.TheArchylteSteppe);
        public static Treasure asWB4 = new Treasure("Western Benchland 4", "tre_gpda_012", TreasureArea.TheArchylteSteppe);
        public static Treasure asWB5 = new Treasure("Western Benchland 5", "tre_gpda_008", TreasureArea.TheArchylteSteppe);
        public static Treasure asWB6 = new Treasure("Western Benchland 6", "tre_gpda_009", TreasureArea.TheArchylteSteppe);
        public static Treasure asWB7 = new Treasure("Western Benchland 7", "tre_gpda_007", TreasureArea.TheArchylteSteppe);
        public static Treasure asTFoN1 = new Treasure("The Font of Namva 1", "tre_gpda_022", TreasureArea.TheArchylteSteppe);
        public static Treasure asTFoN2 = new Treasure("The Font of Namva 2", "tre_gpda_021", TreasureArea.TheArchylteSteppe);
        public static Treasure asET1 = new Treasure("Eastern Tors 1", "tre_gpda_016", TreasureArea.TheArchylteSteppe);
        public static Treasure asET2 = new Treasure("Eastern Tors 2", "tre_gpda_017", TreasureArea.TheArchylteSteppe);
        public static Treasure asET3 = new Treasure("Eastern Tors 3", "tre_gpda_018", TreasureArea.TheArchylteSteppe);
        public static Treasure asET4 = new Treasure("Eastern Tors 4", "tre_gpda_010", TreasureArea.TheArchylteSteppe);
        public static Treasure asET5 = new Treasure("Eastern Tors 5", "tre_gpda_011", TreasureArea.TheArchylteSteppe);
        public static Treasure asAP1 = new Treasure("Aggra's Pasture 1", "tre_gpda_025", TreasureArea.TheArchylteSteppe);
        public static Treasure asAP2 = new Treasure("Aggra's Pasture 2", "tre_gpda_024", TreasureArea.TheArchylteSteppe);
        public static Treasure asTHA1 = new Treasure("The Haerii Achaeopolis 1", "tre_gpda_027", TreasureArea.TheArchylteSteppe);
        public static Treasure asTHA2 = new Treasure("The Haerii Achaeopolis 2", "tre_gpda_028", TreasureArea.TheArchylteSteppe);
        public static Treasure asTHA3 = new Treasure("The Haerii Achaeopolis 3", "tre_gpda_026", TreasureArea.TheArchylteSteppe);

        #endregion

        #region Mah'habara

        public static Treasure mMotA1 = new Treasure("Maw of the Abyss 1", "tre_gpyu_001", TreasureArea.Mahhabara);
        public static Treasure mMotA2 = new Treasure("Maw of the Abyss 2", "tre_gpyu_016", TreasureArea.Mahhabara);
        public static Treasure mTE1 = new Treasure("The Earthworks 1", "tre_gpyu_002", TreasureArea.Mahhabara);
        public static Treasure mTE2 = new Treasure("The Earthworks 2", "tre_gpyu_003", TreasureArea.Mahhabara);
        public static Treasure mTC1 = new Treasure("Twilit Cavern 1", "tre_gpyu_011", TreasureArea.Mahhabara);
        public static Treasure mTC2 = new Treasure("Twilit Cavern 2", "tre_gpyu_004", TreasureArea.Mahhabara);
        public static Treasure mDG1 = new Treasure("Dusktide Grotto 1", "tre_gpyu_005", TreasureArea.Mahhabara);
        public static Treasure mDG2 = new Treasure("Dusktide Grotto 2", "tre_gpyu_012", TreasureArea.Mahhabara);
        public static Treasure mDG3 = new Treasure("Dusktide Grotto 3", "tre_gpyu_006", TreasureArea.Mahhabara);
        public static Treasure mDG4 = new Treasure("Dusktide Grotto 4? (Perfect Conductors 1)", "tre_gpyu_007", TreasureArea.Mahhabara);
        public static Treasure mAAfL1 = new Treasure("An Asylum from Light 1? (Perfect Conductors 2)", "tre_gpyu_015", TreasureArea.Mahhabara);
        public static Treasure mAAfL2 = new Treasure("An Asylum from Light 2", "tre_gpyu_014", TreasureArea.Mahhabara);
        public static Treasure mAAfL3 = new Treasure("An Asylum from Light 3", "tre_gpyu_008", TreasureArea.Mahhabara);
        public static Treasure mAAfL4 = new Treasure("An Asylum from Light 4? (Particle Accelerator 1)", "tre_gpyu_009", TreasureArea.Mahhabara);
        public static Treasure mAAfL5 = new Treasure("An Asylum from Light 5", "tre_gpyu_013", TreasureArea.Mahhabara);
        public static Treasure mAD1 = new Treasure("Abandoned Dig 1", "tre_gpyu_010", TreasureArea.Mahhabara);
        public static Treasure mAD2 = new Treasure("Abandoned Dig 2? (Particle Accelerator 2)", "tre_gpyu_018", TreasureArea.Mahhabara);
        public static Treasure mAD3 = new Treasure("Abandoned Dig 3", "tre_gpyu_017", TreasureArea.Mahhabara);

        #endregion

        #region Sulyya Springs

        public static Treasure ssSL1 = new Treasure("Subterranean Lake 1", "tre_gptk_001", TreasureArea.SulyyaSprings);
        public static Treasure ssSL2 = new Treasure("Subterranean Lake 2", "tre_gptk_002", TreasureArea.SulyyaSprings);
        public static Treasure ssSL3 = new Treasure("Subterranean Lake 3", "tre_gptk_010", TreasureArea.SulyyaSprings);
        public static Treasure ssSL4 = new Treasure("Subterranean Lake 4", "tre_gptk_008", TreasureArea.SulyyaSprings);
        public static Treasure ssSL5 = new Treasure("Subterranean Lake 5", "tre_gptk_003", TreasureArea.SulyyaSprings);
        public static Treasure ssSL6 = new Treasure("Subterranean Lake 6", "tre_gptk_004", TreasureArea.SulyyaSprings);
        public static Treasure ssSL7 = new Treasure("Subterranean Lake 7", "tre_gptk_005", TreasureArea.SulyyaSprings);
        public static Treasure ssSL8 = new Treasure("Subterranean Lake 8", "tre_gptk_011", TreasureArea.SulyyaSprings);
        public static Treasure ssSL9 = new Treasure("Subterranean Lake 9", "tre_gptk_009", TreasureArea.SulyyaSprings);
        public static Treasure ssCoS = new Treasure("Ceiling of Sky", "tre_gptk_006", TreasureArea.SulyyaSprings);
        public static Treasure ssTS = new Treasure("The Skyreach", "tre_gptk_007", TreasureArea.SulyyaSprings);

        #endregion

        #region Taejin's Tower

        public static Treasure ssTP = new Treasure("The Palisades", "tre_gptt_001", TreasureArea.TaejinsTower);
        public static Treasure ssGT1 = new Treasure("Ground Tier 1", "tre_gptt_004", TreasureArea.TaejinsTower);
        public static Treasure ssGT2 = new Treasure("Ground Tier 2", "tre_gptt_003", TreasureArea.TaejinsTower);
        public static Treasure ssGT3 = new Treasure("Ground Tier 3", "tre_gptt_002", TreasureArea.TaejinsTower);
        public static Treasure ssSecT = new Treasure("Second Tier", "tre_gptt_005", TreasureArea.TaejinsTower);
        public static Treasure ssTT1 = new Treasure("Third Tier 1", "tre_gptt_018", TreasureArea.TaejinsTower);
        public static Treasure ssTT2 = new Treasure("Third Tier 2", "tre_gptt_006", TreasureArea.TaejinsTower);
        public static Treasure ssFoT1 = new Treasure("Fourth Tier 1", "tre_gptt_007", TreasureArea.TaejinsTower);
        public static Treasure ssFoT2 = new Treasure("Fourth Tier 2", "tre_gptt_008", TreasureArea.TaejinsTower);
        public static Treasure ssFoT3 = new Treasure("Fourth Tier 3", "tre_gptt_009", TreasureArea.TaejinsTower);
        public static Treasure ssFiT1 = new Treasure("Fifth Tier 1", "tre_gptt_012", TreasureArea.TaejinsTower);
        public static Treasure ssFiT2 = new Treasure("Fifth Tier 2", "tre_gptt_011", TreasureArea.TaejinsTower);
        public static Treasure ssSiT1 = new Treasure("Sixth Tier 1", "tre_gptt_014", TreasureArea.TaejinsTower);
        public static Treasure ssSiT2 = new Treasure("Sixth Tier 2", "tre_gptt_010", TreasureArea.TaejinsTower);
        public static Treasure ssSiT3 = new Treasure("Sixth Tier 3", "tre_gptt_013", TreasureArea.TaejinsTower);
        public static Treasure ssSiT4 = new Treasure("Sixth Tier 4", "tre_gptt_019", TreasureArea.TaejinsTower);
        public static Treasure ssTCS1 = new Treasure("The Cloven Spire 1", "tre_gptt_016", TreasureArea.TaejinsTower);
        public static Treasure ssTCS2 = new Treasure("The Cloven Spire 2", "tre_gptt_015", TreasureArea.TaejinsTower);
        public static Treasure ssSevT = new Treasure("Seventh Tier", "tre_gptt_017", TreasureArea.TaejinsTower);

        #endregion

        #region Oerba

        public static Treasure oVP1 = new Treasure("Village Proper 1", "tre_gpwo_007", TreasureArea.Oerba);
        public static Treasure oVP2 = new Treasure("Village Proper 2", "tre_gpwo_001", TreasureArea.Oerba);
        public static Treasure oVP3 = new Treasure("Village Proper 3", "tre_gpwo_002", TreasureArea.Oerba);
        public static Treasure oDS1 = new Treasure("Deserted Schoolhouse 1", "tre_gpwo_006", TreasureArea.Oerba);
        public static Treasure oDS2 = new Treasure("Deserted Schoolhouse 2", "tre_gpwo_003", TreasureArea.Oerba);
        public static Treasure oRB1 = new Treasure("Rust-eaten Bridge 1", "tre_gpwo_004", TreasureArea.Oerba);
        public static Treasure oRB2 = new Treasure("Rust-eaten Bridge 2", "tre_gpwo_005", TreasureArea.Oerba);
        public static Treasure oRB3 = new Treasure("Rust-eaten Bridge 3", "tre_gpwo_008", TreasureArea.Oerba);

        #endregion

        #region Yaschas Massif

        public static Treasure ymTTH = new Treasure("The Tsubaddran Highlands", "tre_gpst_001", TreasureArea.YaschasMassif);
        public static Treasure ymTAS1 = new Treasure("The Ascendant Scrap 1", "tre_gpst_005", TreasureArea.YaschasMassif);
        public static Treasure ymTAS2 = new Treasure("The Ascendant Scrap 2", "tre_gpst_006", TreasureArea.YaschasMassif);
        public static Treasure ymTAS3 = new Treasure("The Ascendant Scrap 3", "tre_gpst_007", TreasureArea.YaschasMassif);
        public static Treasure ymTAS4 = new Treasure("The Ascendant Scrap 4", "tre_gpst_008", TreasureArea.YaschasMassif);
        public static Treasure ymTTB1 = new Treasure("The Tsumitran Basin 1", "tre_gpst_002", TreasureArea.YaschasMassif);
        public static Treasure ymTTB2 = new Treasure("The Tsumitran Basin 2", "tre_gpst_003", TreasureArea.YaschasMassif);
        public static Treasure ymTTB3 = new Treasure("The Tsumitran Basin 3", "tre_gpst_004", TreasureArea.YaschasMassif);
        public static Treasure ymTPoP = new Treasure("The Pass of Paddra", "tre_gpst_009", TreasureArea.YaschasMassif);
        public static Treasure ymTPA1 = new Treasure("The Paddraean Archaeopolis 1", "tre_gpst_010", TreasureArea.YaschasMassif);
        public static Treasure ymTPA2 = new Treasure("The Paddraean Archaeopolis 2", "tre_gpst_012", TreasureArea.YaschasMassif);
        public static Treasure ymTPA3 = new Treasure("The Paddraean Archaeopolis 3", "tre_gpst_011", TreasureArea.YaschasMassif);

        #endregion

        #region The Faultwarrens

        public static Treasure tfADoS1 = new Treasure("A Dance of Shadow 1", "tre_gpoc_005", TreasureArea.TheFaultwarrens);
        public static Treasure tfADoS2 = new Treasure("A Dance of Shadow 2? (Starblossom 1)", "tre_gpoc_001", TreasureArea.TheFaultwarrens);
        public static Treasure tfVL = new Treasure("Via Lunae (Should be Zealot's Amulet)", "tre_gpoc_002", TreasureArea.TheFaultwarrens);
        public static Treasure tfVS = new Treasure("Via Solis? (Starblossom 2)", "tre_gpoc_004", TreasureArea.TheFaultwarrens);
        public static Treasure tfTGP = new Treasure("The Gaian Path", "tre_gpoc_009", TreasureArea.TheFaultwarrens);
        public static Treasure tfTSP = new Treasure("The Sylphid Path? (Starblossom 3)", "tre_gpoc_006", TreasureArea.TheFaultwarrens);
        public static Treasure tfTNP = new Treasure("The Nereid Path", "tre_gpoc_007", TreasureArea.TheFaultwarrens);

        #endregion

        #region Eden

        public static Treasure eGPC1 = new Treasure("Grand Prix Circuit 1", "tre_eden_001", TreasureArea.Eden);
        public static Treasure eGPC2 = new Treasure("Grand Prix Circuit 2", "tre_eden_002", TreasureArea.Eden);
        public static Treasure eEx1 = new Treasure("Expressway 1", "tre_eden_003", TreasureArea.Eden);
        public static Treasure eEx2 = new Treasure("Expressway 2", "tre_eden_004", TreasureArea.Eden);
        public static Treasure eRI1 = new Treasure("Ramuh Interchange 1", "tre_eden_005", TreasureArea.Eden);
        public static Treasure eRI2 = new Treasure("Ramuh Interchange 2", "tre_eden_006", TreasureArea.Eden);
        public static Treasure eRI3 = new Treasure("Ramuh Interchange 3", "tre_eden_007", TreasureArea.Eden);
        public static Treasure eSP1 = new Treasure("Siren Park 1", "tre_eden_008", TreasureArea.Eden);
        public static Treasure eSP2 = new Treasure("Siren Park 2", "tre_eden_010", TreasureArea.Eden);
        public static Treasure eSP3 = new Treasure("Siren Park 3", "tre_eden_011", TreasureArea.Eden);
        public static Treasure eSP4 = new Treasure("Siren Park 4", "tre_eden_009", TreasureArea.Eden);
        public static Treasure eLP1 = new Treasure("Leviathan Plaza 1", "tre_eden_012", TreasureArea.Eden);
        public static Treasure eLP2 = new Treasure("Leviathan Plaza 2", "tre_eden_018", TreasureArea.Eden);
        public static Treasure eLP3 = new Treasure("Leviathan Plaza 3", "tre_eden_017", TreasureArea.Eden);
        public static Treasure eLP4 = new Treasure("Leviathan Plaza 4", "tre_eden_013", TreasureArea.Eden);
        public static Treasure eLP5 = new Treasure("Leviathan Plaza 5", "tre_eden_014", TreasureArea.Eden);
        public static Treasure eEGF = new Treasure("Edenhall Grand Foyer", "tre_eden_015", TreasureArea.Eden);
        public static Treasure eEd1 = new Treasure("Edenhall 1", "tre_eden_016", TreasureArea.Eden);
        public static Treasure eEd2 = new Treasure("Edenhall 2", "tre_eden_019", TreasureArea.Eden);

        #endregion

        #region Orphan's Cradle

        public static Treasure ocTT1 = new Treasure("The Tesseracts 1st Section 1", "tre_lasd_001", TreasureArea.OrphansCradle);
        public static Treasure ocTT2 = new Treasure("The Tesseracts 1st Section 2", "tre_lasd_002", TreasureArea.OrphansCradle);
        public static Treasure ocTT3 = new Treasure("The Tesseracts 1st Section 3", "tre_lasd_003", TreasureArea.OrphansCradle);
        public static Treasure ocTT4 = new Treasure("The Tesseracts 2nd Section 1", "tre_lasd_005", TreasureArea.OrphansCradle);
        public static Treasure ocTT5 = new Treasure("The Tesseracts 2nd Section 2", "tre_lasd_008", TreasureArea.OrphansCradle);
        public static Treasure ocTT6 = new Treasure("The Tesseracts 2nd Section 3", "tre_lasd_009", TreasureArea.OrphansCradle);
        public static Treasure ocTT7 = new Treasure("The Tesseracts 2nd Section 4", "tre_lasd_006", TreasureArea.OrphansCradle);
        public static Treasure ocTT8 = new Treasure("The Tesseracts 3rd Section 1", "tre_lasd_007", TreasureArea.OrphansCradle);
        public static Treasure ocTT9 = new Treasure("The Tesseracts 3rd Section 2", "tre_lasd_012", TreasureArea.OrphansCradle);
        public static Treasure ocTT10 = new Treasure("The Tesseracts 3rd Section 3", "tre_lasd_004", TreasureArea.OrphansCradle);
        public static Treasure ocTT11 = new Treasure("The Tesseracts 3rd Section 4", "tre_lasd_010", TreasureArea.OrphansCradle);
        public static Treasure ocTT12 = new Treasure("The Tesseracts 3rd Section 5", "tre_lasd_011", TreasureArea.OrphansCradle);
        public static Treasure ocTT13 = new Treasure("The Tesseracts 4th Section 1", "tre_lasd_013", TreasureArea.OrphansCradle);
        public static Treasure ocTT14 = new Treasure("The Tesseracts 4th Section 2", "tre_lasd_014", TreasureArea.OrphansCradle);
        public static Treasure ocTT15 = new Treasure("The Tesseracts 4th Section 3", "tre_lasd_015", TreasureArea.OrphansCradle);
        public static Treasure ocTT16 = new Treasure("The Tesseracts 4th Section 4", "tre_lasd_016", TreasureArea.OrphansCradle);
        public static Treasure ocTT17 = new Treasure("The Tesseracts 4th Section 5", "tre_lasd_017", TreasureArea.OrphansCradle);
        public static Treasure ocTT18 = new Treasure("The Tesseracts 5th Section 1", "tre_lasd_018", TreasureArea.OrphansCradle);
        public static Treasure ocTT19 = new Treasure("The Tesseracts 5th Section 2", "tre_lasd_019", TreasureArea.OrphansCradle);
        public static Treasure ocTT20 = new Treasure("The Tesseracts 5th Section 3", "tre_lasd_021", TreasureArea.OrphansCradle);
        public static Treasure ocTT21 = new Treasure("The Tesseracts 5th Section 4", "tre_lasd_020", TreasureArea.OrphansCradle);
        public static Treasure ocTT22 = new Treasure("The Tesseracts 6th Section 1", "tre_lasd_022", TreasureArea.OrphansCradle);
        public static Treasure ocTT23 = new Treasure("The Tesseracts 6th Section 2", "tre_lasd_023", TreasureArea.OrphansCradle);
        public static Treasure ocTN = new Treasure("The Narthex", "tre_lasd_024", TreasureArea.OrphansCradle);

        #endregion

        #region Missions

        public static Treasure mission1 = new Treasure("Mission 1", "tre_ms_n001_01", TreasureArea.Mission);
        public static Treasure mission1Repeat = new Treasure("Mission 1 Repeat", "tre_ms_n001_02", TreasureArea.Mission);
        public static Treasure mission2 = new Treasure("Mission 2", "tre_ms_n002_01", TreasureArea.Mission);
        public static Treasure mission2Repeat = new Treasure("Mission 2 Repeat", "tre_ms_n002_02", TreasureArea.Mission);
        public static Treasure mission3 = new Treasure("Mission 3", "tre_ms_n003_01", TreasureArea.Mission);
        public static Treasure mission3Repeat = new Treasure("Mission 3 Repeat", "tre_ms_n003_02", TreasureArea.Mission);
        public static Treasure mission4 = new Treasure("Mission 4", "tre_ms_t001_01", TreasureArea.Mission);
        public static Treasure mission4Repeat = new Treasure("Mission 4 Repeat", "tre_ms_t001_02", TreasureArea.Mission);
        public static Treasure mission5 = new Treasure("Mission 5", "tre_ms_n004_01", TreasureArea.Mission);
        public static Treasure mission5Repeat = new Treasure("Mission 5 Repeat", "tre_ms_n004_02", TreasureArea.Mission);
        public static Treasure mission6 = new Treasure("Mission 6", "tre_ms_t002_01", TreasureArea.Mission);
        public static Treasure mission6Repeat = new Treasure("Mission 6 Repeat", "tre_ms_t002_02", TreasureArea.Mission);
        public static Treasure mission7 = new Treasure("Mission 7", "tre_ms_k001_01", TreasureArea.Mission);
        public static Treasure mission7Repeat = new Treasure("Mission 7 Repeat", "tre_ms_k001_02", TreasureArea.Mission);
        public static Treasure mission8 = new Treasure("Mission 8", "tre_ms_t003_01", TreasureArea.Mission);
        public static Treasure mission8Repeat = new Treasure("Mission 8 Repeat", "tre_ms_t003_02", TreasureArea.Mission);
        public static Treasure mission9 = new Treasure("Mission 9", "tre_ms_t004_01", TreasureArea.Mission);
        public static Treasure mission9Repeat = new Treasure("Mission 9 Repeat", "tre_ms_t004_02", TreasureArea.Mission);
        public static Treasure mission10 = new Treasure("Mission 10", "tre_ms_n005_01", TreasureArea.Mission);
        public static Treasure mission10Repeat = new Treasure("Mission 10 Repeat", "tre_ms_n005_02", TreasureArea.Mission);

        public static Treasure mission11 = new Treasure("Mission 11", "tre_ms_n006_01", TreasureArea.Mission);
        public static Treasure mission11Repeat = new Treasure("Mission 11 Repeat", "tre_ms_n006_02", TreasureArea.Mission);
        public static Treasure mission12 = new Treasure("Mission 12", "tre_ms_k002_01", TreasureArea.Mission);
        public static Treasure mission12Repeat = new Treasure("Mission 12 Repeat", "tre_ms_k002_02", TreasureArea.Mission);
        public static Treasure mission13 = new Treasure("Mission 13", "tre_ms_n008_01", TreasureArea.Mission);
        public static Treasure mission13Repeat = new Treasure("Mission 13 Repeat", "tre_ms_n008_02", TreasureArea.Mission);
        public static Treasure mission14 = new Treasure("Mission 14", "tre_ms_n007_01", TreasureArea.Mission);
        public static Treasure mission14Repeat = new Treasure("Mission 14 Repeat", "tre_ms_n007_02", TreasureArea.Mission);
        public static Treasure mission15 = new Treasure("Mission 15", "tre_ms_n011_01", TreasureArea.Mission);
        public static Treasure mission15Repeat = new Treasure("Mission 15 Repeat", "tre_ms_n011_02", TreasureArea.Mission);
        public static Treasure mission16 = new Treasure("Mission 16", "tre_ms_n012_01", TreasureArea.Mission);
        public static Treasure mission16Repeat = new Treasure("Mission 16 Repeat", "tre_ms_n012_02", TreasureArea.Mission);
        public static Treasure mission17 = new Treasure("Mission 17", "tre_ms_t005_01", TreasureArea.Mission);
        public static Treasure mission17Repeat = new Treasure("Mission 17 Repeat", "tre_ms_t005_02", TreasureArea.Mission);
        public static Treasure mission18 = new Treasure("Mission 18", "tre_ms_t006_01", TreasureArea.Mission);
        public static Treasure mission18Repeat = new Treasure("Mission 18 Repeat", "tre_ms_t006_02", TreasureArea.Mission);
        public static Treasure mission19 = new Treasure("Mission 19", "tre_ms_t007_01", TreasureArea.Mission);
        public static Treasure mission19Repeat = new Treasure("Mission 19 Repeat", "tre_ms_t007_02", TreasureArea.Mission);
        public static Treasure mission20 = new Treasure("Mission 20", "tre_ms_t008_01", TreasureArea.Mission);
        public static Treasure mission20Repeat = new Treasure("Mission 20 Repeat", "tre_ms_t008_02", TreasureArea.Mission);

        public static Treasure mission21 = new Treasure("Mission 21", "tre_ms_z001_01", TreasureArea.Mission);
        public static Treasure mission21Repeat = new Treasure("Mission 21 Repeat", "tre_ms_z001_02", TreasureArea.Mission);
        public static Treasure mission22 = new Treasure("Mission 22", "tre_ms_z002_01", TreasureArea.Mission);
        public static Treasure mission22Repeat = new Treasure("Mission 22 Repeat", "tre_ms_z002_02", TreasureArea.Mission);
        public static Treasure mission23 = new Treasure("Mission 23", "tre_ms_z003_01", TreasureArea.Mission);
        public static Treasure mission23Repeat = new Treasure("Mission 23 Repeat", "tre_ms_z003_02", TreasureArea.Mission);
        public static Treasure mission24 = new Treasure("Mission 24", "tre_ms_z004_01", TreasureArea.Mission);
        public static Treasure mission24Repeat = new Treasure("Mission 24 Repeat", "tre_ms_z004_02", TreasureArea.Mission);
        public static Treasure mission25 = new Treasure("Mission 25", "tre_ms_z006_01", TreasureArea.Mission);
        public static Treasure mission25Repeat = new Treasure("Mission 25 Repeat", "tre_ms_z006_02", TreasureArea.Mission);
        public static Treasure mission26 = new Treasure("Mission 26", "tre_ms_z005_01", TreasureArea.Mission);
        public static Treasure mission26Repeat = new Treasure("Mission 26 Repeat", "tre_ms_z005_02", TreasureArea.Mission);
        public static Treasure mission27 = new Treasure("Mission 27", "tre_ms_n013_01", TreasureArea.Mission);
        public static Treasure mission27Repeat = new Treasure("Mission 27 Repeat", "tre_ms_n013_02", TreasureArea.Mission);
        public static Treasure mission28 = new Treasure("Mission 28", "tre_ms_t009_01", TreasureArea.Mission);
        public static Treasure mission28Repeat = new Treasure("Mission 28 Repeat", "tre_ms_t009_02", TreasureArea.Mission);
        public static Treasure mission29 = new Treasure("Mission 29", "tre_ms_n015_01", TreasureArea.Mission);
        public static Treasure mission29Repeat = new Treasure("Mission 29 Repeat", "tre_ms_n015_02", TreasureArea.Mission);
        public static Treasure mission30 = new Treasure("Mission 30", "tre_ms_k003_01", TreasureArea.Mission);
        public static Treasure mission30Repeat = new Treasure("Mission 30 Repeat", "tre_ms_k003_02", TreasureArea.Mission);

        public static Treasure mission31 = new Treasure("Mission 31", "tre_ms_t010_01", TreasureArea.Mission);
        public static Treasure mission31Repeat = new Treasure("Mission 31 Repeat", "tre_ms_t010_02", TreasureArea.Mission);
        public static Treasure mission32 = new Treasure("Mission 32", "tre_ms_n014_01", TreasureArea.Mission);
        public static Treasure mission32Repeat = new Treasure("Mission 32 Repeat", "tre_ms_n014_02", TreasureArea.Mission);
        public static Treasure mission33 = new Treasure("Mission 33", "tre_ms_n016_01", TreasureArea.Mission);
        public static Treasure mission33Repeat = new Treasure("Mission 33 Repeat", "tre_ms_n016_02", TreasureArea.Mission);
        public static Treasure mission34 = new Treasure("Mission 34", "tre_ms_n023_01", TreasureArea.Mission);
        public static Treasure mission34Repeat = new Treasure("Mission 34 Repeat", "tre_ms_n023_02", TreasureArea.Mission);
        public static Treasure mission35 = new Treasure("Mission 35", "tre_ms_n035_01", TreasureArea.Mission);
        public static Treasure mission35Repeat = new Treasure("Mission 35 Repeat", "tre_ms_n035_02", TreasureArea.Mission);
        public static Treasure mission36 = new Treasure("Mission 36", "tre_ms_n019_01", TreasureArea.Mission);
        public static Treasure mission36Repeat = new Treasure("Mission 36 Repeat", "tre_ms_n019_02", TreasureArea.Mission);
        public static Treasure mission37 = new Treasure("Mission 37", "tre_ms_n020_01", TreasureArea.Mission);
        public static Treasure mission37Repeat = new Treasure("Mission 37 Repeat", "tre_ms_n020_02", TreasureArea.Mission);
        public static Treasure mission38 = new Treasure("Mission 38", "tre_ms_n021_01", TreasureArea.Mission);
        public static Treasure mission38Repeat = new Treasure("Mission 38 Repeat", "tre_ms_n021_02", TreasureArea.Mission);
        public static Treasure mission39 = new Treasure("Mission 39", "tre_ms_n022_01", TreasureArea.Mission);
        public static Treasure mission39Repeat = new Treasure("Mission 39 Repeat", "tre_ms_n022_02", TreasureArea.Mission);
        public static Treasure mission40 = new Treasure("Mission 40", "tre_ms_n009_01", TreasureArea.Mission);
        public static Treasure mission40Repeat = new Treasure("Mission 40 Repeat", "tre_ms_n009_02", TreasureArea.Mission);

        public static Treasure mission41 = new Treasure("Mission 41", "tre_ms_n024_01", TreasureArea.Mission);
        public static Treasure mission41Repeat = new Treasure("Mission 41 Repeat", "tre_ms_n024_02", TreasureArea.Mission);
        public static Treasure mission42 = new Treasure("Mission 42", "tre_ms_n025_01", TreasureArea.Mission);
        public static Treasure mission42Repeat = new Treasure("Mission 42 Repeat", "tre_ms_n025_02", TreasureArea.Mission);
        public static Treasure mission43 = new Treasure("Mission 43", "tre_ms_n026_01", TreasureArea.Mission);
        public static Treasure mission43Repeat = new Treasure("Mission 43 Repeat", "tre_ms_n026_02", TreasureArea.Mission);
        public static Treasure mission44 = new Treasure("Mission 44", "tre_ms_n027_01", TreasureArea.Mission);
        public static Treasure mission44Repeat = new Treasure("Mission 44 Repeat", "tre_ms_n027_02", TreasureArea.Mission);
        public static Treasure mission45 = new Treasure("Mission 45", "tre_ms_n028_01", TreasureArea.Mission);
        public static Treasure mission45Repeat = new Treasure("Mission 45 Repeat", "tre_ms_n028_02", TreasureArea.Mission);
        public static Treasure mission46 = new Treasure("Mission 46", "tre_ms_n033_01", TreasureArea.Mission);
        public static Treasure mission46Repeat = new Treasure("Mission 46 Repeat", "tre_ms_n033_02", TreasureArea.Mission);
        public static Treasure mission47 = new Treasure("Mission 47", "tre_ms_n030_01", TreasureArea.Mission);
        public static Treasure mission47Repeat = new Treasure("Mission 47 Repeat", "tre_ms_n030_02", TreasureArea.Mission);
        public static Treasure mission48 = new Treasure("Mission 48", "tre_ms_n031_01", TreasureArea.Mission);
        public static Treasure mission48Repeat = new Treasure("Mission 48 Repeat", "tre_ms_n031_02", TreasureArea.Mission);
        public static Treasure mission49 = new Treasure("Mission 49", "tre_ms_n032_01", TreasureArea.Mission);
        public static Treasure mission49Repeat = new Treasure("Mission 49 Repeat", "tre_ms_n032_02", TreasureArea.Mission);
        public static Treasure mission50 = new Treasure("Mission 50", "tre_ms_n029_01", TreasureArea.Mission);
        public static Treasure mission50Repeat = new Treasure("Mission 50 Repeat", "tre_ms_n029_02", TreasureArea.Mission);

        public static Treasure mission51 = new Treasure("Mission 51", "tre_ms_n036_01", TreasureArea.Mission);
        public static Treasure mission51Repeat = new Treasure("Mission 51 Repeat", "tre_ms_n036_02", TreasureArea.Mission);
        public static Treasure mission52 = new Treasure("Mission 52", "tre_ms_n010_01", TreasureArea.Mission);
        public static Treasure mission52Repeat = new Treasure("Mission 52 Repeat", "tre_ms_n010_02", TreasureArea.Mission);
        public static Treasure mission53 = new Treasure("Mission 53", "tre_ms_n044_01", TreasureArea.Mission);
        public static Treasure mission53Repeat = new Treasure("Mission 53 Repeat", "tre_ms_n044_02", TreasureArea.Mission);
        public static Treasure mission54 = new Treasure("Mission 54", "tre_ms_k004_01", TreasureArea.Mission);
        public static Treasure mission54Repeat = new Treasure("Mission 54 Repeat", "tre_ms_k004_02", TreasureArea.Mission);
        public static Treasure mission55 = new Treasure("Mission 55", "tre_ms_n018_01", TreasureArea.Mission);
        public static Treasure mission55Repeat = new Treasure("Mission 55 Repeat", "tre_ms_n018_02", TreasureArea.Mission);
        public static Treasure mission56 = new Treasure("Mission 56", "tre_ms_n037_01", TreasureArea.Mission);
        public static Treasure mission56Repeat = new Treasure("Mission 56 Repeat", "tre_ms_n037_02", TreasureArea.Mission);
        public static Treasure mission57 = new Treasure("Mission 57", "tre_ms_n038_01", TreasureArea.Mission);
        public static Treasure mission57Repeat = new Treasure("Mission 57 Repeat", "tre_ms_n038_02", TreasureArea.Mission);
        public static Treasure mission58 = new Treasure("Mission 58", "tre_ms_n039_01", TreasureArea.Mission);
        public static Treasure mission58Repeat = new Treasure("Mission 58 Repeat", "tre_ms_n039_02", TreasureArea.Mission);
        public static Treasure mission59 = new Treasure("Mission 59", "tre_ms_n040_01", TreasureArea.Mission);
        public static Treasure mission59Repeat = new Treasure("Mission 59 Repeat", "tre_ms_n040_02", TreasureArea.Mission);
        public static Treasure mission60 = new Treasure("Mission 60", "tre_ms_n041_01", TreasureArea.Mission);
        public static Treasure mission60Repeat = new Treasure("Mission 60 Repeat", "tre_ms_n041_02", TreasureArea.Mission);

        public static Treasure mission61 = new Treasure("Mission 61", "tre_ms_n042_01", TreasureArea.Mission);
        public static Treasure mission61Repeat = new Treasure("Mission 61 Repeat", "tre_ms_n042_02", TreasureArea.Mission);
        public static Treasure mission62 = new Treasure("Mission 62", "tre_ms_n043_01", TreasureArea.Mission);
        public static Treasure mission62Repeat = new Treasure("Mission 62 Repeat", "tre_ms_n043_02", TreasureArea.Mission);
        public static Treasure mission63 = new Treasure("Mission 63", "tre_ms_n017_01", TreasureArea.Mission);
        public static Treasure mission63Repeat = new Treasure("Mission 63 Repeat", "tre_ms_n017_02", TreasureArea.Mission);
        public static Treasure mission64 = new Treasure("Mission 64", "tre_ms_n034_01", TreasureArea.Mission);
        public static Treasure mission64Repeat = new Treasure("Mission 64 Repeat", "tre_ms_n034_02", TreasureArea.Mission);

        #endregion
    }
}
