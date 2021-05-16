using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FF13Data
{
    public class Passives
    {
        public static List<PassiveSet> passives = new List<PassiveSet>();

        public static PassiveSet Uncapped = new PassiveSet(PassiveType.Weapon, LockingLevel.Fixed)
            .Add("Uncapped HP/Damage", "slimit", 1, 1, "", "", 0, 0, 0);
        public static PassiveSet None = new PassiveSet(PassiveType.Weapon, LockingLevel.SameType)
            .Add("None", "", 1, 1, "", "", 0, 0, 0);
        public static PassiveSet AttackATBCharge = new PassiveSet(PassiveType.Weapon)
            .Add("Attack ATB Charge", "awp_c000_000", 0.4f, 0.4f, "", "$awp_c000_000h", 0, 0, 0)
            .Add("Attack ATB Charge II", "awp_c000_050", 0.4f, 0.4f, "", "$awp_c000_050h", 0, 0, 0);
        public static PassiveSet ImprovedRaise = new PassiveSet(PassiveType.Weapon)
            .Add("Improved Raise", "awp_c000_100", 0.55f, 0.95f, "", "$awp_c000_100h", 0, 0, 0)
            .Add("Improved Raise II", "awp_c000_150", 0.55f, 0.95f, "", "$awp_c000_150h", 0, 0, 0);
        public static PassiveSet Leadenstrike = new PassiveSet(PassiveType.Weapon, LockingLevel.SameType)
            .Add("Leadenstrike", "awp_all_100", 1.25f, 1.25f, "", "$awp_all_100h", 0, 0, 0)
            .Add("Ironstrike", "awp_all_150", 1.25f, 1.25f, "", "$awp_all_150h", 0, 0, 0);
        public static PassiveSet StaggerLock = new PassiveSet(PassiveType.Weapon)
            .Add("Stagger Lock", "awp_all_000", 0.9f, 0.9f, "", "$awp_all_000h", 0, 0, 0);
        public static PassiveSet QuickStagger = new PassiveSet(PassiveType.Weapon)
            .Add("Quick Stagger", "awp_c000_200", 0.6f, 0.6f, "", "$awp_c000_200h", 0, 0, 0);
        public static PassiveSet AugmentMaintenance = new PassiveSet(PassiveType.Weapon)
            .Add("Augment Maintenance", "awp_c002_000", 0.8f, 0.8f, "", "$awp_c002_000h", 0, 0, 0)
            .Add("Augment Maintenance II", "awp_c002_050", 0.8f, 0.8f, "", "$awp_c002_050h", 0, 0, 0);
        public static PassiveSet PaperTiger = new PassiveSet(PassiveType.Weapon, LockingLevel.Fixed)
            .Add("Paper Tiger", "", 2.4f, 2.4f, "$awp_all_400", "$awp_all_400h", -60, 3, 1)
            .Add("Silk Tiger", "", 2.4f, 2.4f, "$awp_all_450", "$awp_all_450h", -40, 3, 1);
        public static PassiveSet ChainBonusBoost = new PassiveSet(PassiveType.Weapon)
            .Add("Chain Bonus Boost", "awp_c002_100", 0.6f, 0.6f, "", "$awp_c002_100h", 0, 0, 0)
            .Add("Chain Bonus Boost II", "awp_c002_150", 0.6f, 0.6f, "", "$awp_c002_150h", 0, 0, 0);
        public static PassiveSet StaggerMaintenance = new PassiveSet(PassiveType.Weapon)
            .Add("Stagger Maintenance", "awp_c002_200", 0.4f, 0.4f, "", "$awp_c002_200h", 0, 0, 0)
            .Add("Stagger Maintenance II", "awp_c002_250", 0.4f, 0.4f, "", "$awp_c002_250h", 0, 0, 0);
        public static PassiveSet ImprovedGuard = new PassiveSet(PassiveType.Weapon)
            .Add("Improved Guard", "awp_c001_000", 0.85f, 0.65f, "", "$awp_c001_000h", 0, 0, 0)
            .Add("Improved Guard II", "awp_c001_050", 0.85f, 0.65f, "", "$awp_c001_050h", 0, 0, 0);
        public static PassiveSet CriticalPowerSurge = new PassiveSet(PassiveType.Weapon)
            .Add("Critical Power Surge", "awp_c001_100", 0.6f, 0.6f, "", "$awp_c001_100h", 0, 0, 0)
            .Add("Critical Power Surge II", "awp_c001_150", 0.6f, 0.6f, "", "$awp_c001_150h", 0, 0, 0);
        public static PassiveSet Enfeeblement = new PassiveSet(PassiveType.Weapon, LockingLevel.SameType)
            .Add("Enfeeblement", "awp_all_200", 0, 1.5f, "", "$awp_all_200h", 0, 0, 0)
            .Add("Hindrance", "awp_all_250", 0, 1.5f, "", "$awp_all_250h", 0, 0, 0);
        public static PassiveSet ImprovedWard = new PassiveSet(PassiveType.Weapon)
            .Add("Improved Ward", "awp_c001_200", 1.1f, 0.7f, "", "$awp_c001_200h", 0, 0, 0)
            .Add("Improved Ward II", "awp_c001_250", 1.1f, 0.7f, "", "$awp_c001_250h", 0, 0, 0);
        public static PassiveSet CriticalShield = new PassiveSet(PassiveType.Weapon)
            .Add("Critical Shield", "awp_c003_000", 0.8f, 0.7f, "", "$awp_c003_000h", 0, 0, 0)
            .Add("Critical Shield II", "awp_c003_050", 0.8f, 0.7f, "", "$awp_c003_050h", 0, 0, 0);
        public static PassiveSet SiphonBoost = new PassiveSet(PassiveType.Weapon)
            .Add("Siphon Boost", "awp_c003_100", 0.75f, 0.75f, "", "$awp_c003_100h", 0, 0, 0)
            .Add("Siphon Boost II", "awp_c003_150", 0.75f, 0.75f, "", "$awp_c003_150h", 0, 0, 0);
        public static PassiveSet DefenseMaintenance = new PassiveSet(PassiveType.Weapon)
            .Add("Defense Maintenance", "awp_c003_200", 0.8f, 0.8f, "", "$awp_c003_200h", 0, 0, 0)
            .Add("Defense Maintenance II", "awp_c003_250", 0.8f, 0.8f, "", "$awp_c003_250h", 0, 0, 0);
        public static PassiveSet StifledMagic = new PassiveSet(PassiveType.Weapon, LockingLevel.SameType)
            .Add("Stifled Magic", "awp_all_300", 1.5f, 0, "", "$awp_all_300h", 0, 0, 0)
            .Add("Fettered Magic", "awp_all_350", 1.5f, 0, "", "$awp_all_350h", 0, 0, 0);
        public static PassiveSet ImprovedCure = new PassiveSet(PassiveType.Weapon)
            .Add("Improved Cure", "awp_c004_000", 0.2f, 0.6f, "", "$awp_c004_000h", 0, 0, 0)
            .Add("Improved Cure II", "awp_c004_050", 0.2f, 0.6f, "", "$awp_c004_050h", 0, 0, 0);
        public static PassiveSet AllyKOPowerSurge = new PassiveSet(PassiveType.Weapon)
            .Add("Ally KO Power Surge", "awp_c004_100", 0.6f, 0.6f, "", "$awp_c004_100h", 0, 0, 0)
            .Add("Ally KO Power Surge II", "awp_c004_150", 0.6f, 0.6f, "", "$awp_c004_150h", 0, 0, 0);
        public static PassiveSet ImprovedDebuffing = new PassiveSet(PassiveType.Weapon)
            .Add("Improved Debuffing", "awp_c004_200", 0.65f, 0.85f, "", "$awp_c004_200h", 0, 0, 0)
            .Add("Improved Debuffing II", "awp_c004_250", 0.65f, 0.85f, "", "$awp_c004_250h", 0, 0, 0);
        public static PassiveSet StaggerTPCharge = new PassiveSet(PassiveType.Weapon)
            .Add("Stagger TP Charge", "awp_c005_000", 0.9f, 0.9f, "", "$awp_c005_000h", 0, 0, 0)
            .Add("Stagger TP Charge II", "awp_c005_050", 0.9f, 0.9f, "", "$awp_c005_050h", 0, 0, 0);
        public static PassiveSet ImprovedDebilitation = new PassiveSet(PassiveType.Weapon)
            .Add("Improved Debilitation", "awp_c005_100", 0.65f, 0.85f, "", "$awp_c005_100h", 0, 0, 0)
            .Add("Improved Debilitation II", "awp_c005_150", 0.65f, 0.85f, "", "$awp_c005_150h", 0, 0, 0);
        public static PassiveSet ImprovedCounter = new PassiveSet(PassiveType.Weapon, LockingLevel.Any, "lshf")
            .Add("Improved Counter", "awp_c005_200", 1.1f, 0.3f, "", "$awp_c005_200h", 0, 0, 0)
            .Add("Improved Counter II", "awp_c005_250", 1.1f, 0.3f, "", "$awp_c005_250h", 0, 0, 0);

        public static PassiveSet HP = new PassiveSet(PassiveType.Accessory, LockingLevel.Fixed)
            .Add("HP +X", "", 1, 1, "", "$auto_hp_01", -1, 2, 1);
        public static PassiveSet Strength = new PassiveSet(PassiveType.Accessory, LockingLevel.Fixed)
            .Add("Strength +X", "", 1, 1, "", "$auto_att_00", -1, 2, 5);
        public static PassiveSet Magic = new PassiveSet(PassiveType.Accessory, LockingLevel.Fixed)
            .Add("Magic +X", "", 1, 1, "", "$auto_matt_00", -1, 2, 6);
        public static PassiveSet ResistPhysical = new PassiveSet(PassiveType.Accessory, LockingLevel.Fixed)
            .Add("Resist Physical +X%", "", 1, 1, "", "$auto_def_00", -1, 3, 16);
        public static PassiveSet ResistMagic = new PassiveSet(PassiveType.Accessory, LockingLevel.Fixed)
            .Add("Resist Magic +X%", "", 1, 1, "", "$auto_mdef_00", -1, 3, 17);
        public static PassiveSet ResistDamage = new PassiveSet(PassiveType.Accessory, LockingLevel.Fixed)
            .Add("Resist Damage +X%", "", 1, 1, "", "$auto_fdef_00", -1, 3, 4368);
        public static PassiveSet ResistFire = new PassiveSet(PassiveType.Accessory, LockingLevel.Fixed)
            .Add("Resist Fire +X%", "", 1, 1, "", "$auto_fdef_00", -1, 3, 18);
        public static PassiveSet ResistIce = new PassiveSet(PassiveType.Accessory, LockingLevel.Fixed)
            .Add("Resist Ice +X%", "", 1, 1, "", "$auto_idef_00", -1, 3, 19);
        public static PassiveSet ResistLightning = new PassiveSet(PassiveType.Accessory, LockingLevel.Fixed)
            .Add("Resist Lightning +X%", "", 1, 1, "", "$auto_ldef_00", -1, 3, 20);
        public static PassiveSet ResistWater = new PassiveSet(PassiveType.Accessory, LockingLevel.Fixed)
            .Add("Resist Water +X%", "", 1, 1, "", "$auto_wdef_00", -1, 3, 21);
        public static PassiveSet ResistWind = new PassiveSet(PassiveType.Accessory, LockingLevel.Fixed)
            .Add("Resist Wind +X%", "", 1, 1, "", "$auto_adef_00", -1, 3, 22);
        public static PassiveSet ResistEarth = new PassiveSet(PassiveType.Accessory, LockingLevel.Fixed)
            .Add("Resist Earth +X%", "", 1, 1, "", "$auto_edef_00", -1, 3, 23);
        public static PassiveSet ResistDebrave = new PassiveSet(PassiveType.Accessory, LockingLevel.Fixed)
            .Add("Resist Debrave +X%", "", 1, 1, "", "$auto_sdef_00", -1, 3, 37);
        public static PassiveSet ResistDefaith = new PassiveSet(PassiveType.Accessory, LockingLevel.Fixed)
            .Add("Resist Defaith +X%", "", 1, 1, "", "$auto_sdef_01", -1, 3, 38);
        public static PassiveSet ResistDeprotect = new PassiveSet( PassiveType.Accessory, LockingLevel.Fixed)
            .Add("Resist Deprotect +X%", "", 1, 1, "", "$auto_sdef_02", -1, 3, 32);
        public static PassiveSet ResistDeshell = new PassiveSet(PassiveType.Accessory, LockingLevel.Fixed)
            .Add("Resist Deshell +X%", "", 1, 1, "", "$auto_sdef_03", -1, 3, 33);
        public static PassiveSet ResistSlow = new PassiveSet(PassiveType.Accessory, LockingLevel.Fixed)
            .Add("Resist Slow +X%", "", 1, 1, "", "$auto_sdef_04", -1, 3, 25);
        public static PassiveSet ResistPoison = new PassiveSet(PassiveType.Accessory, LockingLevel.Fixed)
            .Add("Resist Poison +X%", "", 1, 1, "", "$auto_sdef_05", -1, 3, 30);
        public static PassiveSet ResistImperil = new PassiveSet(PassiveType.Accessory, LockingLevel.Fixed)
            .Add("Resist Imperil +X%", "", 1, 1, "", "$auto_sdef_06", -1, 3, 26);
        public static PassiveSet ResistCurse = new PassiveSet(PassiveType.Accessory, LockingLevel.Fixed)
            .Add("Resist Curse +X%", "", 1, 1, "", "$auto_sdef_07", -1, 3, 28);
        public static PassiveSet ResistPain = new PassiveSet(PassiveType.Accessory, LockingLevel.Fixed)
            .Add("Resist Pain +X%", "", 1, 1, "", "$auto_sdef_08", -1, 3, 27);
        public static PassiveSet ResistFog = new PassiveSet(PassiveType.Accessory, LockingLevel.Fixed)
            .Add("Resist Fog +X%", "", 1, 1, "", "$auto_sdef_09", -1, 3, 24);
        public static PassiveSet ResistDaze = new PassiveSet(PassiveType.Accessory, LockingLevel.Fixed)
            .Add("Resist Daze +X%", "", 1, 1, "", "$auto_sdef_10", -1, 3, 29);
        public static PassiveSet ResistDeath = new PassiveSet(PassiveType.Accessory, LockingLevel.Fixed)
            .Add("Resist Death +X%", "", 1, 1, "", "$auto_sdef_11", -1, 3, 52);
        public static PassiveSet AutoProtect = new PassiveSet(PassiveType.Accessory)
            .Add("Critical Protect", "auto_p_prot", 0.8f, 0.6f, "", "", 0, 0, 0)
            .Add("Auto Protect", "auto_prot", 0.8f, 0.6f, "", "", 0, 0, 0);
        public static PassiveSet AutoShell = new PassiveSet(PassiveType.Accessory)
            .Add("Critical Shell", "auto_p_shel", 0.6f, 0.8f, "", "", 0, 0, 0)
            .Add("Auto Shell", "auto_shel", 0.6f, 0.8f, "", "", 0, 0, 0);
        public static PassiveSet AutoVeil = new PassiveSet(PassiveType.Accessory)
            .Add("Critical Veil", "auto_p_veil", 0.7f, 0.7f, "", "", 0, 0, 0)
            .Add("Auto Veil", "auto_veil", 0.7f, 0.7f, "", "", 0, 0, 0);
        public static PassiveSet AutoBravery = new PassiveSet(PassiveType.Accessory)
            .Add("Critical Bravery", "auto_p_brav", 1.1f, 0.3f, "", "", 0, 0, 0)
            .Add("Auto Bravery", "auto_brav", 1.1f, 0.3f, "", "", 0, 0, 0);
        public static PassiveSet AutoFaith = new PassiveSet(PassiveType.Accessory)
            .Add("Critical Faith", "auto_p_fait", 0.3f, 1.1f, "", "", 0, 0, 0)
            .Add("Auto Faith", "auto_fait", 0.3f, 1.1f, "", "", 0, 0, 0);
        public static PassiveSet AutoVigilance = new PassiveSet(PassiveType.Accessory)
            .Add("Critical Vigilance", "auto_p_forc", 0.7f, 0.7f, "", "", 0, 0, 0)
            .Add("Auto Vigilance", "auto_forc", 0.7f, 0.7f, "", "", 0, 0, 0);
        public static PassiveSet AutoBarfire = new PassiveSet(PassiveType.Accessory)
            .Add("Critical Barfire", "auto_p_bafa", 0.7f, 0.7f, "", "", 0, 0, 0)
            .Add("Auto Barfire", "auto_bafa", 0.7f, 0.7f, "", "", 0, 0, 0);
        public static PassiveSet AutoBarfrost = new PassiveSet(PassiveType.Accessory)
            .Add("Critical Barfrost", "auto_p_babl", 0.7f, 0.7f, "", "", 0, 0, 0)
            .Add("Auto Barfrost", "auto_babl", 0.7f, 0.7f, "", "", 0, 0, 0);
        public static PassiveSet AutoBarthunder = new PassiveSet(PassiveType.Accessory)
            .Add("Critical Barthunder", "auto_p_bali", 0.7f, 0.7f, "", "", 0, 0, 0)
            .Add("Auto Barthunder", "auto_bali", 0.7f, 0.7f, "", "", 0, 0, 0);
        public static PassiveSet AutoBarwater = new PassiveSet(PassiveType.Accessory)
            .Add("Critical Barwater", "auto_p_bawa", 0.7f, 0.7f, "", "", 0, 0, 0)
            .Add("Auto Barwater", "auto_bawa", 0.7f, 0.7f, "", "", 0, 0, 0);
        public static PassiveSet AutoHaste = new PassiveSet(PassiveType.Accessory)
            .Add("Critical Haste", "auto_p_hast ", 0.6f, 0.6f, "", "", 0, 0, 0)
            .Add("Auto Haste", "auto_hast ", 0.6f, 0.6f, "", "", 0, 0, 0);
        public static PassiveSet AutoTetradefense = new PassiveSet(PassiveType.Accessory)
            .Add("Critical Tetradefense", "auto_p_myte", 0.6f, 0.6f, "", "", 0, 0, 0)
            .Add("Auto Tetradefense", "auto_myte", 0.6f, 0.6f, "", "", 0, 0, 0);
        public static PassiveSet FirstStrike = new PassiveSet(PassiveType.Accessory)
            .Add("ATB Advantage", "auto_00_0", 0.9f, 0.9f, "", "", 0, 0, 0)
            .Add("First Strike", "auto_00_1", 0.9f, 0.9f, "", "", 0, 0, 0);
        public static PassiveSet ImprovedEvasion = new PassiveSet(PassiveType.Accessory)
            .Add("Improved Evasion", "auto_evade", 0.8f, 0.8f, "", "", 10, 2, 9);
        public static PassiveSet TimeExtension = new PassiveSet(PassiveType.Accessory)
            .Add("Time Extension", "auto_evaluate", 0.65f, 0.65f, "", "", 0, 0, 0);
        public static PassiveSet VictoryTPCharge = new PassiveSet(PassiveType.Accessory)
            .Add("Victory TP Charge", "auto_tpbonus", 0.75f, 0.75f, "", "", 0, 0, 0);
        public static PassiveSet ShroudScavenger = new PassiveSet(PassiveType.Accessory)
            .Add("Shroud Scavenger", "auto_helper", 0.5f, 0.5f, "", "", 0, 0, 0);
        public static PassiveSet ItemScavenger = new PassiveSet(PassiveType.Accessory)
            .Add("Item Scavenger", "auto_drop_0", 0.5f, 0.5f, "", "", 0, 0, 0)
            .Add("Item Collector", "auto_drop_1", 0.5f, 0.5f, "", "", 0, 0, 0);
        public static PassiveSet KillLibra = new PassiveSet(PassiveType.Accessory)
            .Add("Kill Libra", "auto_b_libra", 0.65f, 0.65f, "", "", 0, 0, 0);
        public static PassiveSet KillATBTP = new PassiveSet(PassiveType.Accessory)
            .Add("Kill ATB Charge", "auto_b_atb", 0.8f, 0.8f, "", "", 0, 0, 0)
            .Add("Kill TP Charge", "auto_b_tp", 0.8f, 0.8f, "", "", 0, 0, 0);
        public static PassiveSet ImprovedPotions = new PassiveSet(PassiveType.Accessory)
            .Add("Improved Potions", "auto_medi", 0.4f, 0.4f, "", "", 0, 0, 0);
        public static PassiveSet CPx2 = new PassiveSet(PassiveType.Accessory)
            .Add("CP x2", "auto_cp", 0.4f, 0.4f, "", "", 0, 0, 0);
        public static PassiveSet ResistElements = new PassiveSet(PassiveType.Accessory, LockingLevel.Fixed)
            .Add("Resist Elements +X%", "", 1, 1, "", "$auto_6def_00", -1, 3, 60);
        public static PassiveSet RapidRecovery = new PassiveSet(PassiveType.Accessory)
            .Add("Rapid Recovery", "auto_shorten", 0.8f, 0.8f, "", "", 0, 0, 0);
        public static PassiveSet Resilience = new PassiveSet(PassiveType.Accessory, LockingLevel.Fixed)
            .Add("Resilience +X%", "", 1, 1, "", "$auto_def_s1", -1, 3, 10);
        public static PassiveSet UncappedDamage = new PassiveSet(PassiveType.Accessory)
            .Add("Uncapped Damage", "auto_sdlimit", 0.7f, 0.7f, "", "", 0, 0, 0);
        public static PassiveSet RandomFireEater = new PassiveSet(PassiveType.Accessory)
            .Add("Random Fire Eater", "auto_randf", 0.8f, 0.8f, "", "", 0, 0, 0);
        public static PassiveSet RandomIceEater = new PassiveSet(PassiveType.Accessory)
            .Add("Random Ice Eater", "auto_randb", 0.8f, 0.8f, "", "", 0, 0, 0);
        public static PassiveSet RandomLightningEater = new PassiveSet(PassiveType.Accessory)
            .Add("Random Lightning Eater", "auto_randl", 0.8f, 0.8f, "", "", 0, 0, 0);
        public static PassiveSet RandomWaterEater = new PassiveSet(PassiveType.Accessory)
            .Add("Random Water Eater", "auto_randw", 0.8f, 0.8f, "", "", 0, 0, 0);
        public static PassiveSet RandomWindEater = new PassiveSet(PassiveType.Accessory)
            .Add("Random Wind Eater", "auto_randa", 0.8f, 0.8f, "", "", 0, 0, 0);
        public static PassiveSet RandomEarthEater = new PassiveSet(PassiveType.Accessory)
            .Add("Random Earth Eater", "auto_rande", 0.8f, 0.8f, "", "", 0, 0, 0);
        public static PassiveSet RandomNullifyDamage = new PassiveSet(PassiveType.Accessory)
            .Add("Random Nullify Damage", "auto_rand0", 0.9f, 0.9f, "", "", 0, 0, 0);
    }
}
