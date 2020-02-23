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

        public static Item Gil = new Item("");

        #region Consumables

        public static Item Potion = new Item("it_potion");
        public static Item PhoenixDown = new Item("it_phenxtal");
        public static Item Elixir = new Item("it_elixir");
        public static Item Antidote = new Item("it_antidote");
        public static Item HolyWater = new Item("it_holywater");
        public static Item Painkiller = new Item("it_sedative");
        public static Item FoulLiquid = new Item("it_stinkwater");
        public static Item Wax = new Item("it_wax");
        public static Item Mallet = new Item("it_tonkati");
        public static Item Librascope = new Item("it_libra");

        public static Item Aegisol = new Item("it_barsmoke");
        public static Item Fortisol = new Item("it_powersmoke");
        public static Item Deceptisol = new Item("it_sneaksmoke");
        public static Item Ethersol = new Item("it_tpsmoke");

        #endregion

        #region Accessories

        public static Item IronBangle = new Item("acc_000_000");
        public static Item SilverBangle = new Item("acc_000_001");
        public static Item TungstenBangle = new Item("acc_000_002");
        public static Item TitaniumBangle = new Item("acc_000_003");
        public static Item GoldBangle = new Item("acc_000_004");
        public static Item MythrilBangle = new Item("acc_000_005");
        public static Item PlatinumBangle = new Item("acc_000_006");
        public static Item DiamondBangle = new Item("acc_000_007");
        public static Item AdamantBangle = new Item("acc_000_008");
        public static Item WurtziteBangle = new Item("acc_000_009");

        public static Item PowerWristband = new Item("acc_000_100");
        public static Item BrawlersWristband = new Item("acc_000_101");
        public static Item WarriorsWristband = new Item("acc_000_102");
        public static Item PowerGlove = new Item("acc_000_103");
        public static Item KaiserKnuckles = new Item("acc_000_104");

        public static Item MagiciansMark = new Item("acc_000_200");
        public static Item ShamansMark = new Item("acc_000_201");
        public static Item SorcerersMark = new Item("acc_000_202");
        public static Item WeirdingGlyph = new Item("acc_000_203");
        public static Item MagistralCrest = new Item("acc_000_204");

        public static Item BlackBelt = new Item("acc_000_300");
        public static Item GeneralsBelt = new Item("acc_000_301");
        public static Item ChampionsBelt = new Item("acc_000_302");

        public static Item RuneBracelet = new Item("acc_000_400");
        public static Item WitchsBracelet = new Item("acc_000_401");
        public static Item MagussBracelet = new Item("acc_000_402");

        public static Item RoyalArmlet = new Item("acc_000_500");
        public static Item ImperialArmlet = new Item("acc_000_501");

        public static Item EmberRing = new Item("acc_001_000");
        public static Item BlazeRing = new Item("acc_001_001");
        public static Item SalamandrineRing = new Item("acc_001_002");

        public static Item FrostRing = new Item("acc_002_000");
        public static Item IcicleRing = new Item("acc_002_001");
        public static Item BorealRing = new Item("acc_002_002");

        public static Item SparkRing = new Item("acc_003_000");
        public static Item FulmenRing = new Item("acc_003_001");
        public static Item RaijinRing = new Item("acc_003_002");

        public static Item AquaRing = new Item("acc_004_000");
        public static Item RiptideRing = new Item("acc_004_001");
        public static Item NereidRing = new Item("acc_004_002");

        public static Item ZephyrRing = new Item("acc_005_000");
        public static Item GaleRing = new Item("acc_005_001");
        public static Item SylphidRing = new Item("acc_005_002");

        public static Item ClayRing = new Item("acc_006_000");
        public static Item StilstoneRing = new Item("acc_006_001");
        public static Item GaianRing = new Item("acc_006_002");

        public static Item EntiteRing = new Item("acc_007_000");

        public static Item GiantsGlove = new Item("acc_009_000");
        public static Item WarlocksGlove = new Item("acc_009_001");

        public static Item GlassBuckle = new Item("acc_010_000");
        public static Item TektiteBuckle = new Item("acc_010_001");

        public static Item MetalArmband = new Item("acc_011_000");
        public static Item CeramicArmband = new Item("acc_011_001");

        public static Item SerenitySachet = new Item("acc_012_000");
        public static Item SafeguardSachet = new Item("acc_012_001");

        public static Item GlassOrb = new Item("acc_013_000");
        public static Item DragonflyOrb = new Item("acc_013_001");

        public static Item StarPendant = new Item("acc_014_000");
        public static Item StarfallPendant = new Item("acc_014_001");

        public static Item PearlNecklace = new Item("acc_015_000");
        public static Item GemstoneNecklace = new Item("acc_015_001");

        public static Item WardingTalisman = new Item("acc_016_000");
        public static Item HexbaneTalisman = new Item("acc_016_001");

        public static Item PainDampener = new Item("acc_017_000");
        public static Item PainDeflector = new Item("acc_017_001");

        public static Item WhiteCape = new Item("acc_018_000");
        public static Item EffulgentCape = new Item("acc_018_001");

        public static Item RainbowAnklet = new Item("acc_019_000");
        public static Item MoonbowAnklet = new Item("acc_019_001");

        public static Item CherubsCrown = new Item("acc_020_000");
        public static Item SeraphsCrown = new Item("acc_020_001");

        public static Item Ribbon = new Item("acc_023_000");
        public static Item SuperRibbon = new Item("acc_023_001");

        public static Item GuardianAmulet = new Item("acc_025_000");
        public static Item ShieldTalisman = new Item("acc_025_001");

        public static Item AuricAmulet = new Item("acc_026_000");
        public static Item SoulfontTalisman = new Item("acc_026_001");

        public static Item WatchmansAmulet = new Item("acc_027_000");
        public static Item ShroudingTalisman = new Item("acc_027_001");

        public static Item HerosAmulet = new Item("acc_028_000");
        public static Item MoraleTalisman = new Item("acc_028_001");

        public static Item SaintsAmulet = new Item("acc_029_000");
        public static Item BlessedTalisman = new Item("acc_029_001");

        public static Item ZealotAmulet = new Item("acc_030_000");
        public static Item BattleTalisman = new Item("acc_030_001");

        public static Item FlamebaneBrooch = new Item("acc_031_000");
        public static Item FlameshieldEarring = new Item("acc_031_001");

        public static Item FrostbaneBrooch = new Item("acc_032_000");
        public static Item FrostshieldEarring = new Item("acc_032_001");

        public static Item SparkbaneBrooch = new Item("acc_033_000");
        public static Item SparkshieldEarring = new Item("acc_033_001");

        public static Item AquabaneBrooch = new Item("acc_034_000");
        public static Item AquashieldEarring = new Item("acc_034_001");

        public static Item HermesSandals = new Item("acc_035_000");
        public static Item SprintShoes = new Item("acc_035_001");

        public static Item TetradicCrown = new Item("acc_036_000");
        public static Item TetradicTiara = new Item("acc_036_001");

        public static Item WhistlewindScarf = new Item("acc_037_000");
        public static Item AuroraScarf = new Item("acc_037_001");

        public static Item NimbletoeBoots = new Item("acc_038_000");

        public static Item CollectorCatalog = new Item("acc_039_000");
        public static Item ConnoisseurCatalog = new Item("acc_039_001");

        public static Item GoldWatch = new Item("acc_040_000");
        public static Item ChampionsBadge = new Item("acc_040_001");
        public static Item SurvivalistCatalog = new Item("acc_040_002");

        public static Item HuntersFriend = new Item("acc_041_000");
        public static Item SpeedSash = new Item("acc_041_001");
        public static Item EnergySash = new Item("acc_041_002");

        public static Item GenjiGlove = new Item("acc_042_001");

        public static Item GrowthEgg = new Item("acc_045_000");

        public static Item TwentySidedDie = new Item("acc_046_000");

        public static Item FireCharm = new Item("acc_047_000");
        public static Item IceCharm = new Item("acc_048_000");
        public static Item LightningCharm = new Item("acc_049_000");
        public static Item WaterCharm = new Item("acc_050_000");
        public static Item Windharm = new Item("acc_051_000");
        public static Item EarthCharm = new Item("acc_052_000");

        public static Item DoctorsCode = new Item("acc_053_000");
        public static Item GoddesssFavor = new Item("acc_054_000");

        #endregion

        #region Components

        public static Item InsulatedCabling = new Item("material_j000");
        public static Item FibreOpticCable = new Item("material_j001");
        public static Item LiquidCrystalLens = new Item("material_j002");
        public static Item RingJoint = new Item("material_j003");
        public static Item EpicyclicGear = new Item("material_j004");
        public static Item Crankshaft = new Item("material_j005");
        public static Item ElectrolyticCapacitor = new Item("material_j006");
        public static Item Flywheel = new Item("material_j007");
        public static Item Sprocket = new Item("material_j008");
        public static Item Actuator = new Item("material_j009");
        public static Item SparkPlug = new Item("material_j010");
        public static Item IridiumPlug = new Item("material_j011");        
        public static Item NeedleValve = new Item("material_j012");
        public static Item ButterflyValve = new Item("material_j013");
        public static Item AnalogCircuit = new Item("material_j014");
        public static Item DigitalCircuit = new Item("material_j015");
        public static Item Gyroscope = new Item("material_j016");
        public static Item Electrode = new Item("material_j017");
        public static Item CeramicArmor = new Item("material_j018");
        public static Item ChobhamArmor = new Item("material_j019");
        public static Item RadialBearing = new Item("material_j020");
        public static Item ThrustBearing = new Item("material_j021");
        public static Item Solenoid = new Item("material_j022");
        public static Item MobiusCoil = new Item("material_j023");
        public static Item TungstenTube = new Item("material_j024");
        public static Item TitaniumTube = new Item("material_j025");
        public static Item PassiveDetector = new Item("material_j026");
        public static Item ActiveDetector = new Item("material_j027");
        public static Item Transformer = new Item("material_j028");
        public static Item Amplifier = new Item("material_j029");
        public static Item Carburetor = new Item("material_j030");
        public static Item Supercharger = new Item("material_j031");
        public static Item PiezoelectricElement = new Item("material_j032");
        public static Item CrystalOscillator = new Item("material_j033");
        public static Item ParaffinOil = new Item("material_j034");        
        public static Item SiliconeOil = new Item("material_j035");
        public static Item SyntheticMuscle = new Item("material_j036");
        public static Item Turboprop = new Item("material_j037");
        public static Item Turbojet = new Item("material_j038");
        public static Item TeslaTurbine = new Item("material_j039");
        public static Item PolymerEmulsion = new Item("material_j040");
        public static Item FerroelectricFilm = new Item("material_j041");
        public static Item Superconductor = new Item("material_j042");
        public static Item PerfectConductor = new Item("material_j043");
        public static Item ParticalAccelerator = new Item("material_j044");
        public static Item UltracompactReactor = new Item("material_j045");
        public static Item CreditChip = new Item("material_j046");
        public static Item IncentiveChip = new Item("material_j047");
        public static Item CactuarDoll = new Item("material_j048");
        public static Item MooglePuppet = new Item("material_j049");
        public static Item TonberryFigurine = new Item("material_j050");
        public static Item PlushChocobo = new Item("material_j051");

        public static Item BegrimedClaw = new Item("material_m000");
        public static Item BestialClaw = new Item("material_m001");
        public static Item GargantuanClaw = new Item("material_m002");
        public static Item HellishTalon = new Item("material_m003");
        public static Item ShatteredBone = new Item("material_m004");
        public static Item SturdyBone = new Item("material_m005");
        public static Item OtherworldlyBone = new Item("material_m006");
        public static Item AncientBone = new Item("material_m007");
        public static Item MoistenedScale = new Item("material_m009");
        public static Item SeapetalScale = new Item("material_m010");
        public static Item AbyssalScale = new Item("material_m011");
        public static Item SeakingsBeard = new Item("material_m012");
        public static Item SegmentedCarapace = new Item("material_m013");
        public static Item IronShell = new Item("material_m014");
        public static Item ArmoredShell = new Item("material_m015");
        public static Item RegeneratingCarapace = new Item("material_m016");
        public static Item ChippedFang = new Item("material_m017");
        public static Item WickedFang = new Item("material_m018");
        public static Item MonstrousFang = new Item("material_m019");
        public static Item SinisterFang = new Item("material_m020");
        public static Item SeveredWing = new Item("material_m021");
        public static Item ScaledWing = new Item("material_m022");
        public static Item AbominableWing = new Item("material_m023");
        public static Item MenacingWings = new Item("material_m024");
        public static Item MoltedTail = new Item("material_m025");
        public static Item BarbedTail = new Item("material_m026");
        public static Item DiabolicTail = new Item("material_m027");
        public static Item EntrancingTail = new Item("material_m028");
        public static Item TornLeather = new Item("material_m029");
        public static Item ThickenedHide = new Item("material_m030");
        public static Item SmoothHide = new Item("material_m031");
        public static Item SuppleLeather = new Item("material_m032");
        public static Item GummyOil = new Item("material_m033");
        public static Item FragrantOil = new Item("material_m034");
        public static Item MedicinalOil = new Item("material_m035");
        public static Item EsotericOil = new Item("material_m036");
        public static Item ScragglyWool = new Item("material_m037");
        public static Item RoughWool = new Item("material_m038");
        public static Item ThickWool = new Item("material_m039");
        public static Item FluffyWool = new Item("material_m040");
        public static Item BombAshes = new Item("material_m041");
        public static Item BombFragment = new Item("material_m042");
        public static Item BombShell = new Item("material_m043");
        public static Item BombCore = new Item("material_m044");
        public static Item MurkyOoze = new Item("material_m045");
        public static Item VibrantOoze = new Item("material_m046");
        public static Item TransparentOoze = new Item("material_m047");
        public static Item WonderGel = new Item("material_m048");
        public static Item FracturedHorn = new Item("material_m049");
        public static Item SpinedHorn = new Item("material_m050");
        public static Item FiendishHorn = new Item("material_m051");
        public static Item InfernalHorn = new Item("material_m052");
        public static Item StrangeFluid = new Item("material_m053");
        public static Item EnigmaticFluid = new Item("material_m054");
        public static Item MysteriousFluid = new Item("material_m055");
        public static Item IneffableFluid = new Item("material_m056");
        public static Item CiethTear = new Item("material_m057");
        public static Item TearOfFrustration = new Item("material_m058");
        public static Item TearOfRemorse = new Item("material_m059");
        public static Item TearOfWoe = new Item("material_m060");
        public static Item ChocoboPlume = new Item("material_m061");
        public static Item ChocoboTailFeather = new Item("material_m062");
        public static Item GreenNeedle = new Item("material_m063");
        public static Item DawnlightDew = new Item("material_m064");
        public static Item DusklightDew = new Item("material_m065");
        public static Item Gloomstalk = new Item("material_m066");
        public static Item Sunpetal = new Item("material_m067");
        public static Item RedMycelium = new Item("material_m068");
        public static Item BlueMycelium = new Item("material_m069");
        public static Item WhiteMycelium = new Item("material_m070");
        public static Item BlackMycelium = new Item("material_m071");
        public static Item SucculentFruit = new Item("material_m072");
        public static Item MalodorousFruit = new Item("material_m073");
        public static Item MoonblossomSeed = new Item("material_m074");
        public static Item StarblossomSeed = new Item("material_m075");
        public static Item Perfume = new Item("material_m076");


        public static Item Millerite = new Item("material_o000");
        public static Item Rhodochrosite = new Item("material_o001");
        public static Item Cobaltite = new Item("material_o002");
        public static Item Perovskite = new Item("material_o003");
        public static Item Uraninite = new Item("material_o004");
        public static Item MnarStone = new Item("material_o005");
        public static Item Scarletite = new Item("material_o006");
        public static Item Adamantite = new Item("material_o007");
        public static Item DarkMatter = new Item("material_o008");
        public static Item Trapezohedron = new Item("material_o009");
        public static Item GoldDust = new Item("material_o010");
        public static Item GoldNugget = new Item("material_o011");
        public static Item PlatinumIngot = new Item("material_o012");

        #endregion

        #region Weapons

        public static Item Godslayer = new Item("wea_lig_000");
        public static Item BlazefireSaber = new Item("wea_lig_001");
        public static Item Flamberge = new Item("wea_lig_002");
        public static Item OmegaWeapon1 = new Item("wea_lig_017");
        public static Item AxisBlade = new Item("wea_lig_003");
        public static Item Enkindler = new Item("wea_lig_004");
        public static Item OmegaWeapon2 = new Item("wea_lig_018");
        public static Item EdgedCarbine = new Item("wea_lig_005");
        public static Item RazorCarbine = new Item("wea_lig_006");
        public static Item OmegaWeapon3 = new Item("wea_lig_019");
        public static Item Lifesaber = new Item("wea_lig_007");
        public static Item Peacemaker = new Item("wea_lig_008");
        public static Item OmegaWeapon4 = new Item("wea_lig_020");
        public static Item Gladius = new Item("wea_lig_009");
        public static Item Helterskelter = new Item("wea_lig_010");
        public static Item OmegaWeapon5 = new Item("wea_lig_021");
        public static Item Organyx = new Item("wea_lig_011");
        public static Item Apocalypse = new Item("wea_lig_012");
        public static Item OmegaWeapon6 = new Item("wea_lig_022");
        public static Item Hauteclaire = new Item("wea_lig_013");
        public static Item Durandal = new Item("wea_lig_014");
        public static Item OmegaWeapon7 = new Item("wea_lig_023");
        public static Item Lionheart = new Item("wea_lig_015");
        public static Item UltimaWeapon = new Item("wea_lig_016");
        public static Item OmegaWeapon8 = new Item("wea_lig_024");

        public static Item DeathPenalties = new Item("wea_saz_000");
        public static Item Vega42s = new Item("wea_saz_001");
        public static Item Altairs = new Item("wea_saz_002");
        public static Item TotalEclipses1 = new Item("wea_saz_017");
        public static Item SpicaDefenders = new Item("wea_saz_003");
        public static Item SiriusSidearms = new Item("wea_saz_004");
        public static Item TotalEclipses2 = new Item("wea_saz_018");
        public static Item DenebDuellers = new Item("wea_saz_005");
        public static Item CanopusAMPs = new Item("wea_saz_006");
        public static Item TotalEclipses3 = new Item("wea_saz_019");
        public static Item Rigels = new Item("wea_saz_007");
        public static Item PolarisSpecials = new Item("wea_saz_008");
        public static Item TotalEclipses4 = new Item("wea_saz_020");
        public static Item Aldebarans = new Item("wea_saz_009");
        public static Item Sadalmeliks = new Item("wea_saz_010");
        public static Item TotalEclipses5 = new Item("wea_saz_021");
        public static Item PleiadesHiPowers = new Item("wea_saz_011");
        public static Item HyadesMagnums = new Item("wea_saz_012");
        public static Item TotalEclipses6 = new Item("wea_saz_022");
        public static Item AntaresDeluxes = new Item("wea_saz_013");
        public static Item FomalhautElites = new Item("wea_saz_014");
        public static Item TotalEclipses7 = new Item("wea_saz_023");
        public static Item Procyons = new Item("wea_saz_015");
        public static Item BetelgeuseCustoms = new Item("wea_saz_016");
        public static Item TotalEclipses8 = new Item("wea_saz_024");

        public static Item Omnipotence = new Item("wea_sno_000");
        public static Item WildBear = new Item("wea_sno_001");
        public static Item FeralPride = new Item("wea_sno_002");
        public static Item SaveTheQueen1 = new Item("wea_sno_017");
        public static Item Paladin = new Item("wea_sno_003");
        public static Item WingedSaint = new Item("wea_sno_004");
        public static Item SaveTheQueen2 = new Item("wea_sno_018");
        public static Item RebelHeart = new Item("wea_sno_005");
        public static Item WarriorsEmblem = new Item("wea_sno_006");
        public static Item SaveTheQueen3 = new Item("wea_sno_019");
        public static Item PowerCircle = new Item("wea_sno_007");
        public static Item BattleStandard = new Item("wea_sno_008");
        public static Item SaveTheQueen4 = new Item("wea_sno_020");
        public static Item Feymark = new Item("wea_sno_009");
        public static Item SoulBlazer = new Item("wea_sno_010");
        public static Item SaveTheQueen5 = new Item("wea_sno_021");
        public static Item SacrificialCircle = new Item("wea_sno_011");
        public static Item Indomitus = new Item("wea_sno_012");
        public static Item SaveTheQueen6 = new Item("wea_sno_022");
        public static Item UnsettingSun = new Item("wea_sno_013");
        public static Item MidnightSun = new Item("wea_sno_014");
        public static Item SaveTheQueen7 = new Item("wea_sno_023");
        public static Item Umbra = new Item("wea_sno_015");
        public static Item Solaris = new Item("wea_sno_016");
        public static Item SaveTheQueen8 = new Item("wea_sno_024");

        public static Item RisingSun = new Item("wea_hop_000");
        public static Item Airwing = new Item("wea_hop_001");
        public static Item Skycutter = new Item("wea_hop_002");
        public static Item Nue1 = new Item("wea_hop_017");
        public static Item Hawkeye = new Item("wea_hop_003");
        public static Item Eagletalon = new Item("wea_hop_004");
        public static Item Nue2 = new Item("wea_hop_018");
        public static Item Otshirvani = new Item("wea_hop_005");
        public static Item Urubutsin = new Item("wea_hop_006");
        public static Item Nue3 = new Item("wea_hop_019");
        public static Item Ninurta = new Item("wea_hop_007");
        public static Item Jatayu = new Item("wea_hop_008");
        public static Item Nue4 = new Item("wea_hop_020");
        public static Item Vidofnir = new Item("wea_hop_009");
        public static Item Hresvelgr = new Item("wea_hop_010");
        public static Item Nue5 = new Item("wea_hop_021");
        public static Item Simurgh = new Item("wea_hop_011");
        public static Item Tezcatlipoca = new Item("wea_hop_012");
        public static Item Nue6 = new Item("wea_hop_022");
        public static Item Malphas = new Item("wea_hop_013");
        public static Item Naberius = new Item("wea_hop_014");
        public static Item Nue7 = new Item("wea_hop_023");
        public static Item Alicanto = new Item("wea_hop_015");
        public static Item Caladrius = new Item("wea_hop_016");
        public static Item Nue8 = new Item("wea_hop_024");

        public static Item FaerieTail = new Item("wea_van_000");
        public static Item BindingRod = new Item("wea_van_001");
        public static Item HuntersRod = new Item("wea_van_002");
        public static Item Nirvana1 = new Item("wea_van_017");
        public static Item Tigerclaw = new Item("wea_van_003");
        public static Item Wyrmfang = new Item("wea_van_004");
        public static Item Nirvana2 = new Item("wea_van_018");
        public static Item HealersStaff = new Item("wea_van_005");
        public static Item PhysiciansStaff = new Item("wea_van_006");
        public static Item Nirvana3 = new Item("wea_van_019");
        public static Item PearlwingStaff = new Item("wea_van_007");
        public static Item BrightwingStaff = new Item("wea_van_008");
        public static Item Nirvana4 = new Item("wea_van_020");
        public static Item RodOfThorns = new Item("wea_van_009");
        public static Item OrochiRod = new Item("wea_van_010");
        public static Item Nirvana5 = new Item("wea_van_021");
        public static Item Mistilteinn = new Item("wea_van_011");
        public static Item ErinyesCane = new Item("wea_van_012");
        public static Item Nirvana6 = new Item("wea_van_022");
        public static Item BelladonnaWand = new Item("wea_van_013");
        public static Item MalboroWand = new Item("wea_van_014");
        public static Item Nirvana7 = new Item("wea_van_023");
        public static Item HeavenlyAxis = new Item("wea_van_015");
        public static Item Abraxas = new Item("wea_van_016");
        public static Item Nirvana8 = new Item("wea_van_024");

        public static Item Longinus = new Item("wea_fan_000");
        public static Item BladedLance = new Item("wea_fan_001");
        public static Item Glaive = new Item("wea_fan_002");
        public static Item KainsLance1 = new Item("wea_fan_017");
        public static Item DragoonLance = new Item("wea_fan_003");
        public static Item Dragonhorn = new Item("wea_fan_004");
        public static Item KainsLance2 = new Item("wea_fan_018");
        public static Item Partisan = new Item("wea_fan_005");
        public static Item Rhomphaia = new Item("wea_fan_006");
        public static Item KainsLance3 = new Item("wea_fan_019");
        public static Item ShamanicSpear = new Item("wea_fan_007");
        public static Item HereticsHalberd = new Item("wea_fan_008");
        public static Item KainsLance4 = new Item("wea_fan_020");
        public static Item Punisher = new Item("wea_fan_009");
        public static Item BanescissorSpear = new Item("wea_fan_010");
        public static Item KainsLance5 = new Item("wea_fan_021");
        public static Item PandoranSpear = new Item("wea_fan_011");
        public static Item CalamitySpear = new Item("wea_fan_012");
        public static Item KainsLance6 = new Item("wea_fan_022");
        public static Item TamingPole = new Item("wea_fan_013");
        public static Item VenusGospel = new Item("wea_fan_014");
        public static Item KainsLance7 = new Item("wea_fan_023");
        public static Item GaeBolg = new Item("wea_fan_015");
        public static Item Gungnir = new Item("wea_fan_016");
        public static Item KainsLance8 = new Item("wea_fan_024");

        #endregion


        public static Item shop0 = new Item("key_shop_00");
        public static Item shop1 = new Item("key_shop_01");
        public static Item shop2 = new Item("key_shop_02");
        public static Item shop3 = new Item("key_shop_03");
        public static Item shop4 = new Item("key_shop_04");
        public static Item shop5 = new Item("key_shop_05");
        public static Item shop6 = new Item("key_shop_06");
        public static Item shop7 = new Item("key_shop_07");
        public static Item shop8 = new Item("key_shop_08");
        public static Item shop9 = new Item("key_shop_09");
        public static Item shop10 = new Item("key_shop_10");
        public static Item shop11 = new Item("key_shop_11");
        public static Item shop12 = new Item("key_shop_12");
        public static Item shop13 = new Item("key_shop_13");

        public static Item ctool = new Item("key_ctool");
    }
}
