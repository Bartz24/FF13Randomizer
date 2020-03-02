using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FF13Data
{
    public class Items
    {
        public static List<Item> items = new List<Item>();

        public static Item Gil = new Item("Gil", "");

        #region Consumables

        public static Item Potion = new Item("Potion", "it_potion");
        public static Item PhoenixDown = new Item("PhoenixDown", "it_phenxtal");
        public static Item Elixir = new Item("Elixir", "it_elixir");
        public static Item Antidote = new Item("Antidote", "it_antidote");
        public static Item HolyWater = new Item("HolyWater", "it_holywater");
        public static Item Painkiller = new Item("Painkiller", "it_sedative");
        public static Item FoulLiquid = new Item("FoulLiquid", "it_stinkwater");
        public static Item Wax = new Item("Wax", "it_wax");
        public static Item Mallet = new Item("Mallet", "it_tonkati");
        public static Item Librascope = new Item("Librascope", "it_libra");

        public static Item Aegisol = new Item("Aegisol", "it_barsmoke");
        public static Item Fortisol = new Item("Fortisol", "it_powersmoke");
        public static Item Deceptisol = new Item("Deceptisol", "it_sneaksmoke");
        public static Item Ethersol = new Item("Ethersol", "it_tpsmoke");

        #endregion

        #region Accessories

        public static Item IronBangle = new Item("IronBangle", "acc_000_000");
        public static Item SilverBangle = new Item("SilverBangle", "acc_000_001");
        public static Item TungstenBangle = new Item("TungstenBangle", "acc_000_002");
        public static Item TitaniumBangle = new Item("TitaniumBangle", "acc_000_003");
        public static Item GoldBangle = new Item("GoldBangle", "acc_000_004");
        public static Item MythrilBangle = new Item("MythrilBangle", "acc_000_005");
        public static Item PlatinumBangle = new Item("PlatinumBangle", "acc_000_006");
        public static Item DiamondBangle = new Item("DiamondBangle", "acc_000_007");
        public static Item AdamantBangle = new Item("AdamantBangle", "acc_000_008");
        public static Item WurtziteBangle = new Item("WurtziteBangle", "acc_000_009");

        public static Item PowerWristband = new Item("PowerWristband", "acc_000_100");
        public static Item BrawlersWristband = new Item("BrawlersWristband", "acc_000_101");
        public static Item WarriorsWristband = new Item("WarriorsWristband", "acc_000_102");
        public static Item PowerGlove = new Item("PowerGlove", "acc_000_103");
        public static Item KaiserKnuckles = new Item("KaiserKnuckles", "acc_000_104");

        public static Item MagiciansMark = new Item("MagiciansMark", "acc_000_200");
        public static Item ShamansMark = new Item("ShamansMark", "acc_000_201");
        public static Item SorcerersMark = new Item("SorcerersMark", "acc_000_202");
        public static Item WeirdingGlyph = new Item("WeirdingGlyph", "acc_000_203");
        public static Item MagistralCrest = new Item("MagistralCrest", "acc_000_204");

        public static Item BlackBelt = new Item("BlackBelt", "acc_000_300");
        public static Item GeneralsBelt = new Item("GeneralsBelt", "acc_000_301");
        public static Item ChampionsBelt = new Item("ChampionsBelt", "acc_000_302");

        public static Item RuneBracelet = new Item("RuneBracelet", "acc_000_400");
        public static Item WitchsBracelet = new Item("WitchsBracelet", "acc_000_401");
        public static Item MagussBracelet = new Item("MagussBracelet", "acc_000_402");

        public static Item RoyalArmlet = new Item("RoyalArmlet", "acc_000_500");
        public static Item ImperialArmlet = new Item("ImperialArmlet", "acc_000_501");

        public static Item EmberRing = new Item("EmberRing", "acc_001_000");
        public static Item BlazeRing = new Item("BlazeRing", "acc_001_001");
        public static Item SalamandrineRing = new Item("SalamandrineRing", "acc_001_002");

        public static Item FrostRing = new Item("FrostRing", "acc_002_000");
        public static Item IcicleRing = new Item("IcicleRing", "acc_002_001");
        public static Item BorealRing = new Item("BorealRing", "acc_002_002");

        public static Item SparkRing = new Item("SparkRing", "acc_003_000");
        public static Item FulmenRing = new Item("FulmenRing", "acc_003_001");
        public static Item RaijinRing = new Item("RaijinRing", "acc_003_002");

        public static Item AquaRing = new Item("AquaRing", "acc_004_000");
        public static Item RiptideRing = new Item("RiptideRing", "acc_004_001");
        public static Item NereidRing = new Item("NereidRing", "acc_004_002");

        public static Item ZephyrRing = new Item("ZephyrRing", "acc_005_000");
        public static Item GaleRing = new Item("GaleRing", "acc_005_001");
        public static Item SylphidRing = new Item("SylphidRing", "acc_005_002");

        public static Item ClayRing = new Item("ClayRing", "acc_006_000");
        public static Item StilstoneRing = new Item("StilstoneRing", "acc_006_001");
        public static Item GaianRing = new Item("GaianRing", "acc_006_002");

        public static Item EntiteRing = new Item("EntiteRing", "acc_007_000");

        public static Item GiantsGlove = new Item("GiantsGlove", "acc_009_000");
        public static Item WarlocksGlove = new Item("WarlocksGlove", "acc_009_001");

        public static Item GlassBuckle = new Item("GlassBuckle", "acc_010_000");
        public static Item TektiteBuckle = new Item("TektiteBuckle", "acc_010_001");

        public static Item MetalArmband = new Item("MetalArmband", "acc_011_000");
        public static Item CeramicArmband = new Item("CeramicArmband", "acc_011_001");

        public static Item SerenitySachet = new Item("SerenitySachet", "acc_012_000");
        public static Item SafeguardSachet = new Item("SafeguardSachet", "acc_012_001");

        public static Item GlassOrb = new Item("GlassOrb", "acc_013_000");
        public static Item DragonflyOrb = new Item("DragonflyOrb", "acc_013_001");

        public static Item StarPendant = new Item("StarPendant", "acc_014_000");
        public static Item StarfallPendant = new Item("StarfallPendant", "acc_014_001");

        public static Item PearlNecklace = new Item("PearlNecklace", "acc_015_000");
        public static Item GemstoneNecklace = new Item("GemstoneNecklace", "acc_015_001");

        public static Item WardingTalisman = new Item("WardingTalisman", "acc_016_000");
        public static Item HexbaneTalisman = new Item("HexbaneTalisman", "acc_016_001");

        public static Item PainDampener = new Item("PainDampener", "acc_017_000");
        public static Item PainDeflector = new Item("PainDeflector", "acc_017_001");

        public static Item WhiteCape = new Item("WhiteCape", "acc_018_000");
        public static Item EffulgentCape = new Item("EffulgentCape", "acc_018_001");

        public static Item RainbowAnklet = new Item("RainbowAnklet", "acc_019_000");
        public static Item MoonbowAnklet = new Item("MoonbowAnklet", "acc_019_001");

        public static Item CherubsCrown = new Item("CherubsCrown", "acc_020_000");
        public static Item SeraphsCrown = new Item("SeraphsCrown", "acc_020_001");

        public static Item Ribbon = new Item("Ribbon", "acc_023_000");
        public static Item SuperRibbon = new Item("SuperRibbon", "acc_023_001");

        public static Item GuardianAmulet = new Item("GuardianAmulet", "acc_025_000");
        public static Item ShieldTalisman = new Item("ShieldTalisman", "acc_025_001");

        public static Item AuricAmulet = new Item("AuricAmulet", "acc_026_000");
        public static Item SoulfontTalisman = new Item("SoulfontTalisman", "acc_026_001");

        public static Item WatchmansAmulet = new Item("WatchmansAmulet", "acc_027_000");
        public static Item ShroudingTalisman = new Item("ShroudingTalisman", "acc_027_001");

        public static Item HerosAmulet = new Item("HerosAmulet", "acc_028_000");
        public static Item MoraleTalisman = new Item("MoraleTalisman", "acc_028_001");

        public static Item SaintsAmulet = new Item("SaintsAmulet", "acc_029_000");
        public static Item BlessedTalisman = new Item("BlessedTalisman", "acc_029_001");

        public static Item ZealotAmulet = new Item("ZealotAmulet", "acc_030_000");
        public static Item BattleTalisman = new Item("BattleTalisman", "acc_030_001");

        public static Item FlamebaneBrooch = new Item("FlamebaneBrooch", "acc_031_000");
        public static Item FlameshieldEarring = new Item("FlameshieldEarring", "acc_031_001");

        public static Item FrostbaneBrooch = new Item("FrostbaneBrooch", "acc_032_000");
        public static Item FrostshieldEarring = new Item("FrostshieldEarring", "acc_032_001");

        public static Item SparkbaneBrooch = new Item("SparkbaneBrooch", "acc_033_000");
        public static Item SparkshieldEarring = new Item("SparkshieldEarring", "acc_033_001");

        public static Item AquabaneBrooch = new Item("AquabaneBrooch", "acc_034_000");
        public static Item AquashieldEarring = new Item("AquashieldEarring", "acc_034_001");

        public static Item HermesSandals = new Item("HermesSandals", "acc_035_000");
        public static Item SprintShoes = new Item("SprintShoes", "acc_035_001");

        public static Item TetradicCrown = new Item("TetradicCrown", "acc_036_000");
        public static Item TetradicTiara = new Item("TetradicTiara", "acc_036_001");

        public static Item WhistlewindScarf = new Item("WhistlewindScarf", "acc_037_000");
        public static Item AuroraScarf = new Item("AuroraScarf", "acc_037_001");

        public static Item NimbletoeBoots = new Item("NimbletoeBoots", "acc_038_000");

        public static Item CollectorCatalog = new Item("CollectorCatalog", "acc_039_000");
        public static Item ConnoisseurCatalog = new Item("ConnoisseurCatalog", "acc_039_001");

        public static Item GoldWatch = new Item("GoldWatch", "acc_040_000");
        public static Item ChampionsBadge = new Item("ChampionsBadge", "acc_040_001");
        public static Item SurvivalistCatalog = new Item("SurvivalistCatalog", "acc_040_002");

        public static Item HuntersFriend = new Item("HuntersFriend", "acc_041_000");
        public static Item SpeedSash = new Item("SpeedSash", "acc_041_001");
        public static Item EnergySash = new Item("EnergySash", "acc_041_002");

        public static Item GenjiGlove = new Item("GenjiGlove", "acc_042_001");

        public static Item GrowthEgg = new Item("GrowthEgg", "acc_045_000");

        public static Item TwentySidedDie = new Item("TwentySidedDie", "acc_046_000");

        public static Item FireCharm = new Item("FireCharm", "acc_047_000");
        public static Item IceCharm = new Item("IceCharm", "acc_048_000");
        public static Item LightningCharm = new Item("LightningCharm", "acc_049_000");
        public static Item WaterCharm = new Item("WaterCharm", "acc_050_000");
        public static Item Windharm = new Item("Windharm", "acc_051_000");
        public static Item EarthCharm = new Item("EarthCharm", "acc_052_000");

        public static Item DoctorsCode = new Item("DoctorsCode", "acc_053_000");
        public static Item GoddesssFavor = new Item("GoddesssFavor", "acc_054_000");

        #endregion

        #region Components

        public static Item InsulatedCabling = new Item("InsulatedCabling", "material_j000");
        public static Item FibreOpticCable = new Item("FibreOpticCable", "material_j001");
        public static Item LiquidCrystalLens = new Item("LiquidCrystalLens", "material_j002");
        public static Item RingJoint = new Item("RingJoint", "material_j003");
        public static Item EpicyclicGear = new Item("EpicyclicGear", "material_j004");
        public static Item Crankshaft = new Item("Crankshaft", "material_j005");
        public static Item ElectrolyticCapacitor = new Item("ElectrolyticCapacitor", "material_j006");
        public static Item Flywheel = new Item("Flywheel", "material_j007");
        public static Item Sprocket = new Item("Sprocket", "material_j008");
        public static Item Actuator = new Item("Actuator", "material_j009");
        public static Item SparkPlug = new Item("SparkPlug", "material_j010");
        public static Item IridiumPlug = new Item("IridiumPlug", "material_j011");        
        public static Item NeedleValve = new Item("NeedleValve", "material_j012");
        public static Item ButterflyValve = new Item("ButterflyValve", "material_j013");
        public static Item AnalogCircuit = new Item("AnalogCircuit", "material_j014");
        public static Item DigitalCircuit = new Item("DigitalCircuit", "material_j015");
        public static Item Gyroscope = new Item("Gyroscope", "material_j016");
        public static Item Electrode = new Item("Electrode", "material_j017");
        public static Item CeramicArmor = new Item("CeramicArmor", "material_j018");
        public static Item ChobhamArmor = new Item("ChobhamArmor", "material_j019");
        public static Item RadialBearing = new Item("RadialBearing", "material_j020");
        public static Item ThrustBearing = new Item("ThrustBearing", "material_j021");
        public static Item Solenoid = new Item("Solenoid", "material_j022");
        public static Item MobiusCoil = new Item("MobiusCoil", "material_j023");
        public static Item TungstenTube = new Item("TungstenTube", "material_j024");
        public static Item TitaniumTube = new Item("TitaniumTube", "material_j025");
        public static Item PassiveDetector = new Item("PassiveDetector", "material_j026");
        public static Item ActiveDetector = new Item("ActiveDetector", "material_j027");
        public static Item Transformer = new Item("Transformer", "material_j028");
        public static Item Amplifier = new Item("Amplifier", "material_j029");
        public static Item Carburetor = new Item("Carburetor", "material_j030");
        public static Item Supercharger = new Item("Supercharger", "material_j031");
        public static Item PiezoelectricElement = new Item("PiezoelectricElement", "material_j032");
        public static Item CrystalOscillator = new Item("CrystalOscillator", "material_j033");
        public static Item ParaffinOil = new Item("ParaffinOil", "material_j034");        
        public static Item SiliconeOil = new Item("SiliconeOil", "material_j035");
        public static Item SyntheticMuscle = new Item("SyntheticMuscle", "material_j036");
        public static Item Turboprop = new Item("Turboprop", "material_j037");
        public static Item Turbojet = new Item("Turbojet", "material_j038");
        public static Item TeslaTurbine = new Item("TeslaTurbine", "material_j039");
        public static Item PolymerEmulsion = new Item("PolymerEmulsion", "material_j040");
        public static Item FerroelectricFilm = new Item("FerroelectricFilm", "material_j041");
        public static Item Superconductor = new Item("Superconductor", "material_j042");
        public static Item PerfectConductor = new Item("PerfectConductor", "material_j043");
        public static Item ParticalAccelerator = new Item("ParticalAccelerator", "material_j044");
        public static Item UltracompactReactor = new Item("UltracompactReactor", "material_j045");
        public static Item CreditChip = new Item("CreditChip", "material_j046");
        public static Item IncentiveChip = new Item("IncentiveChip", "material_j047");
        public static Item CactuarDoll = new Item("CactuarDoll", "material_j048");
        public static Item MooglePuppet = new Item("MooglePuppet", "material_j049");
        public static Item TonberryFigurine = new Item("TonberryFigurine", "material_j050");
        public static Item PlushChocobo = new Item("PlushChocobo", "material_j051");

        public static Item BegrimedClaw = new Item("BegrimedClaw", "material_m000");
        public static Item BestialClaw = new Item("BestialClaw", "material_m001");
        public static Item GargantuanClaw = new Item("GargantuanClaw", "material_m002");
        public static Item HellishTalon = new Item("HellishTalon", "material_m003");
        public static Item ShatteredBone = new Item("ShatteredBone", "material_m004");
        public static Item SturdyBone = new Item("SturdyBone", "material_m005");
        public static Item OtherworldlyBone = new Item("OtherworldlyBone", "material_m006");
        public static Item AncientBone = new Item("AncientBone", "material_m007");
        public static Item MoistenedScale = new Item("MoistenedScale", "material_m009");
        public static Item SeapetalScale = new Item("SeapetalScale", "material_m010");
        public static Item AbyssalScale = new Item("AbyssalScale", "material_m011");
        public static Item SeakingsBeard = new Item("SeakingsBeard", "material_m012");
        public static Item SegmentedCarapace = new Item("SegmentedCarapace", "material_m013");
        public static Item IronShell = new Item("IronShell", "material_m014");
        public static Item ArmoredShell = new Item("ArmoredShell", "material_m015");
        public static Item RegeneratingCarapace = new Item("RegeneratingCarapace", "material_m016");
        public static Item ChippedFang = new Item("ChippedFang", "material_m017");
        public static Item WickedFang = new Item("WickedFang", "material_m018");
        public static Item MonstrousFang = new Item("MonstrousFang", "material_m019");
        public static Item SinisterFang = new Item("SinisterFang", "material_m020");
        public static Item SeveredWing = new Item("SeveredWing", "material_m021");
        public static Item ScaledWing = new Item("ScaledWing", "material_m022");
        public static Item AbominableWing = new Item("AbominableWing", "material_m023");
        public static Item MenacingWings = new Item("MenacingWings", "material_m024");
        public static Item MoltedTail = new Item("MoltedTail", "material_m025");
        public static Item BarbedTail = new Item("BarbedTail", "material_m026");
        public static Item DiabolicTail = new Item("DiabolicTail", "material_m027");
        public static Item EntrancingTail = new Item("EntrancingTail", "material_m028");
        public static Item TornLeather = new Item("TornLeather", "material_m029");
        public static Item ThickenedHide = new Item("ThickenedHide", "material_m030");
        public static Item SmoothHide = new Item("SmoothHide", "material_m031");
        public static Item SuppleLeather = new Item("SuppleLeather", "material_m032");
        public static Item GummyOil = new Item("GummyOil", "material_m033");
        public static Item FragrantOil = new Item("FragrantOil", "material_m034");
        public static Item MedicinalOil = new Item("MedicinalOil", "material_m035");
        public static Item EsotericOil = new Item("EsotericOil", "material_m036");
        public static Item ScragglyWool = new Item("ScragglyWool", "material_m037");
        public static Item RoughWool = new Item("RoughWool", "material_m038");
        public static Item ThickWool = new Item("ThickWool", "material_m039");
        public static Item FluffyWool = new Item("FluffyWool", "material_m040");
        public static Item BombAshes = new Item("BombAshes", "material_m041");
        public static Item BombFragment = new Item("BombFragment", "material_m042");
        public static Item BombShell = new Item("BombShell", "material_m043");
        public static Item BombCore = new Item("BombCore", "material_m044");
        public static Item MurkyOoze = new Item("MurkyOoze", "material_m045");
        public static Item VibrantOoze = new Item("VibrantOoze", "material_m046");
        public static Item TransparentOoze = new Item("TransparentOoze", "material_m047");
        public static Item WonderGel = new Item("WonderGel", "material_m048");
        public static Item FracturedHorn = new Item("FracturedHorn", "material_m049");
        public static Item SpinedHorn = new Item("SpinedHorn", "material_m050");
        public static Item FiendishHorn = new Item("FiendishHorn", "material_m051");
        public static Item InfernalHorn = new Item("InfernalHorn", "material_m052");
        public static Item StrangeFluid = new Item("StrangeFluid", "material_m053");
        public static Item EnigmaticFluid = new Item("EnigmaticFluid", "material_m054");
        public static Item MysteriousFluid = new Item("MysteriousFluid", "material_m055");
        public static Item IneffableFluid = new Item("IneffableFluid", "material_m056");
        public static Item CiethTear = new Item("CiethTear", "material_m057");
        public static Item TearOfFrustration = new Item("TearOfFrustration", "material_m058");
        public static Item TearOfRemorse = new Item("TearOfRemorse", "material_m059");
        public static Item TearOfWoe = new Item("TearOfWoe", "material_m060");
        public static Item ChocoboPlume = new Item("ChocoboPlume", "material_m061");
        public static Item ChocoboTailFeather = new Item("ChocoboTailFeather", "material_m062");
        public static Item GreenNeedle = new Item("GreenNeedle", "material_m063");
        public static Item DawnlightDew = new Item("DawnlightDew", "material_m064");
        public static Item DusklightDew = new Item("DusklightDew", "material_m065");
        public static Item Gloomstalk = new Item("Gloomstalk", "material_m066");
        public static Item Sunpetal = new Item("Sunpetal", "material_m067");
        public static Item RedMycelium = new Item("RedMycelium", "material_m068");
        public static Item BlueMycelium = new Item("BlueMycelium", "material_m069");
        public static Item WhiteMycelium = new Item("WhiteMycelium", "material_m070");
        public static Item BlackMycelium = new Item("BlackMycelium", "material_m071");
        public static Item SucculentFruit = new Item("SucculentFruit", "material_m072");
        public static Item MalodorousFruit = new Item("MalodorousFruit", "material_m073");
        public static Item MoonblossomSeed = new Item("MoonblossomSeed", "material_m074");
        public static Item StarblossomSeed = new Item("StarblossomSeed", "material_m075");
        public static Item Perfume = new Item("Perfume", "material_m076");


        public static Item Millerite = new Item("Millerite", "material_o000");
        public static Item Rhodochrosite = new Item("Rhodochrosite", "material_o001");
        public static Item Cobaltite = new Item("Cobaltite", "material_o002");
        public static Item Perovskite = new Item("Perovskite", "material_o003");
        public static Item Uraninite = new Item("Uraninite", "material_o004");
        public static Item MnarStone = new Item("MnarStone", "material_o005");
        public static Item Scarletite = new Item("Scarletite", "material_o006");
        public static Item Adamantite = new Item("Adamantite", "material_o007");
        public static Item DarkMatter = new Item("DarkMatter", "material_o008");
        public static Item Trapezohedron = new Item("Trapezohedron", "material_o009");
        public static Item GoldDust = new Item("GoldDust", "material_o010");
        public static Item GoldNugget = new Item("GoldNugget", "material_o011");
        public static Item PlatinumIngot = new Item("PlatinumIngot", "material_o012");

        #endregion

        #region Weapons

        public static Item Godslayer = new Item("Godslayer", "wea_lig_000");
        public static Item BlazefireSaber = new Item("BlazefireSaber", "wea_lig_001");
        public static Item Flamberge = new Item("Flamberge", "wea_lig_002");
        public static Item OmegaWeapon1 = new Item("OmegaWeapon1", "wea_lig_017");
        public static Item AxisBlade = new Item("AxisBlade", "wea_lig_003");
        public static Item Enkindler = new Item("Enkindler", "wea_lig_004");
        public static Item OmegaWeapon2 = new Item("OmegaWeapon2", "wea_lig_018");
        public static Item EdgedCarbine = new Item("EdgedCarbine", "wea_lig_005");
        public static Item RazorCarbine = new Item("RazorCarbine", "wea_lig_006");
        public static Item OmegaWeapon3 = new Item("OmegaWeapon3", "wea_lig_019");
        public static Item Lifesaber = new Item("Lifesaber", "wea_lig_007");
        public static Item Peacemaker = new Item("Peacemaker", "wea_lig_008");
        public static Item OmegaWeapon4 = new Item("OmegaWeapon4", "wea_lig_020");
        public static Item Gladius = new Item("Gladius", "wea_lig_009");
        public static Item Helterskelter = new Item("Helterskelter", "wea_lig_010");
        public static Item OmegaWeapon5 = new Item("OmegaWeapon5", "wea_lig_021");
        public static Item Organyx = new Item("Organyx", "wea_lig_011");
        public static Item Apocalypse = new Item("Apocalypse", "wea_lig_012");
        public static Item OmegaWeapon6 = new Item("OmegaWeapon6", "wea_lig_022");
        public static Item Hauteclaire = new Item("Hauteclaire", "wea_lig_013");
        public static Item Durandal = new Item("Durandal", "wea_lig_014");
        public static Item OmegaWeapon7 = new Item("OmegaWeapon7", "wea_lig_023");
        public static Item Lionheart = new Item("Lionheart", "wea_lig_015");
        public static Item UltimaWeapon = new Item("UltimaWeapon", "wea_lig_016");
        public static Item OmegaWeapon8 = new Item("OmegaWeapon8", "wea_lig_024");

        public static Item DeathPenalties = new Item("DeathPenalties", "wea_saz_000");
        public static Item Vega42s = new Item("Vega42s", "wea_saz_001");
        public static Item Altairs = new Item("Altairs", "wea_saz_002");
        public static Item TotalEclipses1 = new Item("TotalEclipses1", "wea_saz_017");
        public static Item SpicaDefenders = new Item("SpicaDefenders", "wea_saz_003");
        public static Item SiriusSidearms = new Item("SiriusSidearms", "wea_saz_004");
        public static Item TotalEclipses2 = new Item("TotalEclipses2", "wea_saz_018");
        public static Item DenebDuellers = new Item("DenebDuellers", "wea_saz_005");
        public static Item CanopusAMPs = new Item("CanopusAMPs", "wea_saz_006");
        public static Item TotalEclipses3 = new Item("TotalEclipses3", "wea_saz_019");
        public static Item Rigels = new Item("Rigels", "wea_saz_007");
        public static Item PolarisSpecials = new Item("PolarisSpecials", "wea_saz_008");
        public static Item TotalEclipses4 = new Item("TotalEclipses4", "wea_saz_020");
        public static Item Aldebarans = new Item("Aldebarans", "wea_saz_009");
        public static Item Sadalmeliks = new Item("Sadalmeliks", "wea_saz_010");
        public static Item TotalEclipses5 = new Item("TotalEclipses5", "wea_saz_021");
        public static Item PleiadesHiPowers = new Item("PleiadesHiPowers", "wea_saz_011");
        public static Item HyadesMagnums = new Item("HyadesMagnums", "wea_saz_012");
        public static Item TotalEclipses6 = new Item("TotalEclipses6", "wea_saz_022");
        public static Item AntaresDeluxes = new Item("AntaresDeluxes", "wea_saz_013");
        public static Item FomalhautElites = new Item("FomalhautElites", "wea_saz_014");
        public static Item TotalEclipses7 = new Item("TotalEclipses7", "wea_saz_023");
        public static Item Procyons = new Item("Procyons", "wea_saz_015");
        public static Item BetelgeuseCustoms = new Item("BetelgeuseCustoms", "wea_saz_016");
        public static Item TotalEclipses8 = new Item("TotalEclipses8", "wea_saz_024");

        public static Item Omnipotence = new Item("Omnipotence", "wea_sno_000");
        public static Item WildBear = new Item("WildBear", "wea_sno_001");
        public static Item FeralPride = new Item("FeralPride", "wea_sno_002");
        public static Item SaveTheQueen1 = new Item("SaveTheQueen1", "wea_sno_017");
        public static Item Paladin = new Item("Paladin", "wea_sno_003");
        public static Item WingedSaint = new Item("WingedSaint", "wea_sno_004");
        public static Item SaveTheQueen2 = new Item("SaveTheQueen2", "wea_sno_018");
        public static Item RebelHeart = new Item("RebelHeart", "wea_sno_005");
        public static Item WarriorsEmblem = new Item("WarriorsEmblem", "wea_sno_006");
        public static Item SaveTheQueen3 = new Item("SaveTheQueen3", "wea_sno_019");
        public static Item PowerCircle = new Item("PowerCircle", "wea_sno_007");
        public static Item BattleStandard = new Item("BattleStandard", "wea_sno_008");
        public static Item SaveTheQueen4 = new Item("SaveTheQueen4", "wea_sno_020");
        public static Item Feymark = new Item("Feymark", "wea_sno_009");
        public static Item SoulBlazer = new Item("SoulBlazer", "wea_sno_010");
        public static Item SaveTheQueen5 = new Item("SaveTheQueen5", "wea_sno_021");
        public static Item SacrificialCircle = new Item("SacrificialCircle", "wea_sno_011");
        public static Item Indomitus = new Item("Indomitus", "wea_sno_012");
        public static Item SaveTheQueen6 = new Item("SaveTheQueen6", "wea_sno_022");
        public static Item UnsettingSun = new Item("UnsettingSun", "wea_sno_013");
        public static Item MidnightSun = new Item("MidnightSun", "wea_sno_014");
        public static Item SaveTheQueen7 = new Item("SaveTheQueen7", "wea_sno_023");
        public static Item Umbra = new Item("Umbra", "wea_sno_015");
        public static Item Solaris = new Item("Solaris", "wea_sno_016");
        public static Item SaveTheQueen8 = new Item("SaveTheQueen8", "wea_sno_024");

        public static Item RisingSun = new Item("RisingSun", "wea_hop_000");
        public static Item Airwing = new Item("Airwing", "wea_hop_001");
        public static Item Skycutter = new Item("Skycutter", "wea_hop_002");
        public static Item Nue1 = new Item("Nue1", "wea_hop_017");
        public static Item Hawkeye = new Item("Hawkeye", "wea_hop_003");
        public static Item Eagletalon = new Item("Eagletalon", "wea_hop_004");
        public static Item Nue2 = new Item("Nue2", "wea_hop_018");
        public static Item Otshirvani = new Item("Otshirvani", "wea_hop_005");
        public static Item Urubutsin = new Item("Urubutsin", "wea_hop_006");
        public static Item Nue3 = new Item("Nue3", "wea_hop_019");
        public static Item Ninurta = new Item("Ninurta", "wea_hop_007");
        public static Item Jatayu = new Item("Jatayu", "wea_hop_008");
        public static Item Nue4 = new Item("Nue4", "wea_hop_020");
        public static Item Vidofnir = new Item("Vidofnir", "wea_hop_009");
        public static Item Hresvelgr = new Item("Hresvelgr", "wea_hop_010");
        public static Item Nue5 = new Item("Nue5", "wea_hop_021");
        public static Item Simurgh = new Item("Simurgh", "wea_hop_011");
        public static Item Tezcatlipoca = new Item("Tezcatlipoca", "wea_hop_012");
        public static Item Nue6 = new Item("Nue6", "wea_hop_022");
        public static Item Malphas = new Item("Malphas", "wea_hop_013");
        public static Item Naberius = new Item("Naberius", "wea_hop_014");
        public static Item Nue7 = new Item("Nue7", "wea_hop_023");
        public static Item Alicanto = new Item("Alicanto", "wea_hop_015");
        public static Item Caladrius = new Item("Caladrius", "wea_hop_016");
        public static Item Nue8 = new Item("Nue8", "wea_hop_024");

        public static Item FaerieTail = new Item("FaerieTail", "wea_van_000");
        public static Item BindingRod = new Item("BindingRod", "wea_van_001");
        public static Item HuntersRod = new Item("HuntersRod", "wea_van_002");
        public static Item Nirvana1 = new Item("Nirvana1", "wea_van_017");
        public static Item Tigerclaw = new Item("Tigerclaw", "wea_van_003");
        public static Item Wyrmfang = new Item("Wyrmfang", "wea_van_004");
        public static Item Nirvana2 = new Item("Nirvana2", "wea_van_018");
        public static Item HealersStaff = new Item("HealersStaff", "wea_van_005");
        public static Item PhysiciansStaff = new Item("PhysiciansStaff", "wea_van_006");
        public static Item Nirvana3 = new Item("Nirvana3", "wea_van_019");
        public static Item PearlwingStaff = new Item("PearlwingStaff", "wea_van_007");
        public static Item BrightwingStaff = new Item("BrightwingStaff", "wea_van_008");
        public static Item Nirvana4 = new Item("Nirvana4", "wea_van_020");
        public static Item RodOfThorns = new Item("RodOfThorns", "wea_van_009");
        public static Item OrochiRod = new Item("OrochiRod", "wea_van_010");
        public static Item Nirvana5 = new Item("Nirvana5", "wea_van_021");
        public static Item Mistilteinn = new Item("Mistilteinn", "wea_van_011");
        public static Item ErinyesCane = new Item("ErinyesCane", "wea_van_012");
        public static Item Nirvana6 = new Item("Nirvana6", "wea_van_022");
        public static Item BelladonnaWand = new Item("BelladonnaWand", "wea_van_013");
        public static Item MalboroWand = new Item("MalboroWand", "wea_van_014");
        public static Item Nirvana7 = new Item("Nirvana7", "wea_van_023");
        public static Item HeavenlyAxis = new Item("HeavenlyAxis", "wea_van_015");
        public static Item Abraxas = new Item("Abraxas", "wea_van_016");
        public static Item Nirvana8 = new Item("Nirvana8", "wea_van_024");

        public static Item Longinus = new Item("Longinus", "wea_fan_000");
        public static Item BladedLance = new Item("BladedLance", "wea_fan_001");
        public static Item Glaive = new Item("Glaive", "wea_fan_002");
        public static Item KainsLance1 = new Item("KainsLance1", "wea_fan_017");
        public static Item DragoonLance = new Item("DragoonLance", "wea_fan_003");
        public static Item Dragonhorn = new Item("Dragonhorn", "wea_fan_004");
        public static Item KainsLance2 = new Item("KainsLance2", "wea_fan_018");
        public static Item Partisan = new Item("Partisan", "wea_fan_005");
        public static Item Rhomphaia = new Item("Rhomphaia", "wea_fan_006");
        public static Item KainsLance3 = new Item("KainsLance3", "wea_fan_019");
        public static Item ShamanicSpear = new Item("ShamanicSpear", "wea_fan_007");
        public static Item HereticsHalberd = new Item("HereticsHalberd", "wea_fan_008");
        public static Item KainsLance4 = new Item("KainsLance4", "wea_fan_020");
        public static Item Punisher = new Item("Punisher", "wea_fan_009");
        public static Item BanescissorSpear = new Item("BanescissorSpear", "wea_fan_010");
        public static Item KainsLance5 = new Item("KainsLance5", "wea_fan_021");
        public static Item PandoranSpear = new Item("PandoranSpear", "wea_fan_011");
        public static Item CalamitySpear = new Item("CalamitySpear", "wea_fan_012");
        public static Item KainsLance6 = new Item("KainsLance6", "wea_fan_022");
        public static Item TamingPole = new Item("TamingPole", "wea_fan_013");
        public static Item VenusGospel = new Item("VenusGospel", "wea_fan_014");
        public static Item KainsLance7 = new Item("KainsLance7", "wea_fan_023");
        public static Item GaeBolg = new Item("GaeBolg", "wea_fan_015");
        public static Item Gungnir = new Item("Gungnir", "wea_fan_016");
        public static Item KainsLance8 = new Item("KainsLance8", "wea_fan_024");

        #endregion


        public static Item shop0 = new Item("shop0", "key_shop_00");
        public static Item shop1 = new Item("shop1", "key_shop_01");
        public static Item shop2 = new Item("shop2", "key_shop_02");
        public static Item shop3 = new Item("shop3", "key_shop_03");
        public static Item shop4 = new Item("shop4", "key_shop_04");
        public static Item shop5 = new Item("shop5", "key_shop_05");
        public static Item shop6 = new Item("shop6", "key_shop_06");
        public static Item shop7 = new Item("shop7", "key_shop_07");
        public static Item shop8 = new Item("shop8", "key_shop_08");
        public static Item shop9 = new Item("shop9", "key_shop_09");
        public static Item shop10 = new Item("shop10", "key_shop_10");
        public static Item shop11 = new Item("shop11", "key_shop_11");
        public static Item shop12 = new Item("shop12", "key_shop_12");
        public static Item shop13 = new Item("shop13", "key_shop_13");

        public static Item ctool = new Item("ctool", "key_ctool");
    }
}
