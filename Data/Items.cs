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

        public static Item Gil = new Item("Gil", "", null);

        #region Consumables

        public static Item Potion = new Item("Potion", "it_potion", Shops.unicornMart);
        public static Item PhoenixDown = new Item("Phoenix Down", "it_phenxtal", Shops.unicornMart);
        public static Item Librascope = new Item("Librascope", "it_libra", Shops.edenPharmaceuticals);
        public static Item Antidote = new Item("Antidote", "it_antidote", Shops.unicornMart);
        public static Item HolyWater = new Item("Holy Water", "it_holywater", Shops.unicornMart);
        public static Item Painkiller = new Item("Painkiller", "it_sedative", Shops.unicornMart);
        public static Item Mallet = new Item("Mallet", "it_tonkati", Shops.unicornMart);
        public static Item FoulLiquid = new Item("Foul Liquid", "it_stinkwater", Shops.unicornMart);
        public static Item Wax = new Item("Wax", "it_wax", Shops.unicornMart);
        public static Item Elixir = new Item("Elixir", "it_elixir", Shops.unicornMart);

        public static Item Fortisol = new Item("Fortisol", "it_powersmoke", Shops.edenPharmaceuticals);
        public static Item Aegisol = new Item("Aegisol", "it_barsmoke", Shops.edenPharmaceuticals);
        public static Item Deceptisol = new Item("Deceptisol", "it_sneaksmoke", Shops.edenPharmaceuticals);
        public static Item Ethersol = new Item("Ethersol", "it_tpsmoke", Shops.edenPharmaceuticals);

        #endregion

        #region Weapons

        public static Item Godslayer = new Item("Godslayer", "wea_lig_000", Shops.rdDepot);
        public static Item BlazefireSaber = new Item("Blazefire Saber", "wea_lig_001", Shops.upInArms);
        public static Item Flamberge = new Item("Flamberge", "wea_lig_002", Shops.upInArms);
        public static Item OmegaWeapon1 = new Item("Omega Weapon 1", "wea_lig_017", Shops.upInArms);
        public static Item AxisBlade = new Item("Axis Blade", "wea_lig_003", Shops.plautusWorkshop);
        public static Item Enkindler = new Item("Enkindler", "wea_lig_004", Shops.plautusWorkshop);
        public static Item OmegaWeapon2 = new Item("Omega Weapon 2", "wea_lig_018", Shops.plautusWorkshop);
        public static Item EdgedCarbine = new Item("Edged Carbine", "wea_lig_005", Shops.upInArms);
        public static Item RazorCarbine = new Item("Razor Carbine", "wea_lig_006", Shops.upInArms);
        public static Item OmegaWeapon3 = new Item("OmegaWeapon 3", "wea_lig_019", Shops.upInArms);
        public static Item Lifesaber = new Item("Lifesaber", "wea_lig_007", Shops.plautusWorkshop);
        public static Item Peacemaker = new Item("Peacemaker", "wea_lig_008", Shops.plautusWorkshop);
        public static Item OmegaWeapon4 = new Item("Omega Weapon 4", "wea_lig_020", Shops.plautusWorkshop);
        public static Item Gladius = new Item("Gladius", "wea_lig_009", Shops.upInArms);
        public static Item Helterskelter = new Item("Helterskelter", "wea_lig_010", Shops.upInArms);
        public static Item OmegaWeapon5 = new Item("Omega Weapon 5", "wea_lig_021", Shops.upInArms);
        public static Item Organyx = new Item("Organyx", "wea_lig_011", Shops.gilgameshInc);
        public static Item Apocalypse = new Item("Apocalypse", "wea_lig_012", Shops.gilgameshInc);
        public static Item OmegaWeapon6 = new Item("Omega Weapon 6", "wea_lig_022", Shops.gilgameshInc);
        public static Item Hauteclaire = new Item("Hauteclaire", "wea_lig_013", Shops.gilgameshInc);
        public static Item Durandal = new Item("Durandal", "wea_lig_014", Shops.gilgameshInc);
        public static Item OmegaWeapon7 = new Item("Omega Weapon 7", "wea_lig_023", Shops.gilgameshInc);
        public static Item Lionheart = new Item("Lionheart", "wea_lig_015", Shops.plautusWorkshop);
        public static Item UltimaWeapon = new Item("Ultima Weapon", "wea_lig_016", Shops.plautusWorkshop);
        public static Item OmegaWeapon8 = new Item("Omega Weapon 8", "wea_lig_024", Shops.plautusWorkshop);

        public static Item DeathPenalties = new Item("Death Penalties", "wea_saz_000", Shops.rdDepot);
        public static Item Vega42s = new Item("Vega 42s", "wea_saz_001", Shops.upInArms);
        public static Item Altairs = new Item("Altairs", "wea_saz_002", Shops.upInArms);
        public static Item TotalEclipses1 = new Item("Total Eclipses 1", "wea_saz_017", Shops.upInArms);
        public static Item SpicaDefenders = new Item("Spica Defenders", "wea_saz_003", Shops.plautusWorkshop);
        public static Item SiriusSidearms = new Item("Sirius Sidearms", "wea_saz_004", Shops.plautusWorkshop);
        public static Item TotalEclipses2 = new Item("Total Eclipses 2", "wea_saz_018", Shops.plautusWorkshop);
        public static Item DenebDuellers = new Item("Deneb Duellers", "wea_saz_005", Shops.upInArms);
        public static Item CanopusAMPs = new Item("Canopus AMPs", "wea_saz_006", Shops.upInArms);
        public static Item TotalEclipses3 = new Item("Total Eclipses 3", "wea_saz_019", Shops.upInArms);
        public static Item Rigels = new Item("Rigels", "wea_saz_007", Shops.gilgameshInc);
        public static Item PolarisSpecials = new Item("Polaris Specials", "wea_saz_008", Shops.gilgameshInc);
        public static Item TotalEclipses4 = new Item("Total Eclipses 4", "wea_saz_020", Shops.gilgameshInc);
        public static Item Aldebarans = new Item("Aldebarans", "wea_saz_009", Shops.gilgameshInc);
        public static Item Sadalmeliks = new Item("Sadalmeliks", "wea_saz_010", Shops.gilgameshInc);
        public static Item TotalEclipses5 = new Item("Total Eclipses 5", "wea_saz_021", Shops.gilgameshInc);
        public static Item PleiadesHiPowers = new Item("Pleiades Hi Powers", "wea_saz_011", Shops.gilgameshInc);
        public static Item HyadesMagnums = new Item("Hyades Magnums", "wea_saz_012", Shops.gilgameshInc);
        public static Item TotalEclipses6 = new Item("Total Eclipses 6", "wea_saz_022", Shops.gilgameshInc);
        public static Item AntaresDeluxes = new Item("Antares Deluxes", "wea_saz_013", Shops.plautusWorkshop);
        public static Item FomalhautElites = new Item("Fomalhaut Elites", "wea_saz_014", Shops.plautusWorkshop);
        public static Item TotalEclipses7 = new Item("Total Eclipses 7", "wea_saz_023", Shops.plautusWorkshop);
        public static Item Procyons = new Item("Procyons", "wea_saz_015", Shops.plautusWorkshop);
        public static Item BetelgeuseCustoms = new Item("Betelgeuse Customs", "wea_saz_016", Shops.plautusWorkshop);
        public static Item TotalEclipses8 = new Item("Total Eclipses 8", "wea_saz_024", Shops.plautusWorkshop);

        public static Item Omnipotence = new Item("Omnipotence", "wea_sno_000", Shops.rdDepot);
        public static Item WildBear = new Item("Wild Bear", "wea_sno_001", Shops.upInArms);
        public static Item FeralPride = new Item("Feral Pride", "wea_sno_002", Shops.upInArms);
        public static Item SaveTheQueen1 = new Item("Save The Queen 1", "wea_sno_017", Shops.upInArms);
        public static Item Paladin = new Item("Paladin", "wea_sno_003", Shops.plautusWorkshop);
        public static Item WingedSaint = new Item("Winged Saint", "wea_sno_004", Shops.plautusWorkshop);
        public static Item SaveTheQueen2 = new Item("Save The Queen 2", "wea_sno_018", Shops.plautusWorkshop);
        public static Item RebelHeart = new Item("Rebel Heart", "wea_sno_005", Shops.plautusWorkshop);
        public static Item WarriorsEmblem = new Item("Warriors Emblem", "wea_sno_006", Shops.plautusWorkshop);
        public static Item SaveTheQueen3 = new Item("Save The Queen 3", "wea_sno_019", Shops.plautusWorkshop);
        public static Item PowerCircle = new Item("Power Circle", "wea_sno_007", Shops.upInArms);
        public static Item BattleStandard = new Item("Battle Standard", "wea_sno_008", Shops.upInArms);
        public static Item SaveTheQueen4 = new Item("Save The Queen4", "wea_sno_020", Shops.upInArms);
        public static Item Feymark = new Item("Feymark", "wea_sno_009", Shops.gilgameshInc);
        public static Item SoulBlazer = new Item("Soul Blazer", "wea_sno_010", Shops.gilgameshInc);
        public static Item SaveTheQueen5 = new Item("Save The Queen 5", "wea_sno_021", Shops.gilgameshInc);
        public static Item SacrificialCircle = new Item("Sacrificial Circle", "wea_sno_011", Shops.gilgameshInc);
        public static Item Indomitus = new Item("Indomitus", "wea_sno_012", Shops.gilgameshInc);
        public static Item SaveTheQueen6 = new Item("Save The Queen 6", "wea_sno_022", Shops.gilgameshInc);
        public static Item UnsettingSun = new Item("Unsetting Sun", "wea_sno_013", Shops.gilgameshInc);
        public static Item MidnightSun = new Item("Midnight Sun", "wea_sno_014", Shops.gilgameshInc);
        public static Item SaveTheQueen7 = new Item("Save The Queen 7", "wea_sno_023", Shops.gilgameshInc);
        public static Item Umbra = new Item("Umbra", "wea_sno_015", Shops.plautusWorkshop);
        public static Item Solaris = new Item("Solaris", "wea_sno_016", Shops.plautusWorkshop);
        public static Item SaveTheQueen8 = new Item("Save The Queen 8", "wea_sno_024", Shops.plautusWorkshop);

        public static Item RisingSun = new Item("Rising Sun", "wea_hop_000", Shops.rdDepot);
        public static Item Airwing = new Item("Airwing", "wea_hop_001", Shops.plautusWorkshop);
        public static Item Skycutter = new Item("Skycutter", "wea_hop_002", Shops.plautusWorkshop);
        public static Item Nue1 = new Item("Nue 1", "wea_hop_017", Shops.plautusWorkshop);
        public static Item Hawkeye = new Item("Hawkeye", "wea_hop_003", Shops.upInArms);
        public static Item Eagletalon = new Item("Eagletalon", "wea_hop_004", Shops.upInArms);
        public static Item Nue2 = new Item("Nue 2", "wea_hop_018", Shops.upInArms);
        public static Item Otshirvani = new Item("Otshirvani", "wea_hop_005", Shops.plautusWorkshop);
        public static Item Urubutsin = new Item("Urubutsin", "wea_hop_006", Shops.plautusWorkshop);
        public static Item Nue3 = new Item("Nue 3", "wea_hop_019", Shops.plautusWorkshop);
        public static Item Ninurta = new Item("Ninurta", "wea_hop_007", Shops.upInArms);
        public static Item Jatayu = new Item("Jatayu", "wea_hop_008", Shops.upInArms);
        public static Item Nue4 = new Item("Nue 4", "wea_hop_020", Shops.upInArms);
        public static Item Vidofnir = new Item("Vidofnir", "wea_hop_009", Shops.plautusWorkshop);
        public static Item Hresvelgr = new Item("Hresvelgr", "wea_hop_010", Shops.plautusWorkshop);
        public static Item Nue5 = new Item("Nue 5", "wea_hop_021", Shops.plautusWorkshop);
        public static Item Simurgh = new Item("Simurgh", "wea_hop_011", Shops.gilgameshInc);
        public static Item Tezcatlipoca = new Item("Tezcatlipoca", "wea_hop_012", Shops.gilgameshInc);
        public static Item Nue6 = new Item("Nue 6", "wea_hop_022", Shops.gilgameshInc);
        public static Item Malphas = new Item("Malphas", "wea_hop_013", Shops.gilgameshInc);
        public static Item Naberius = new Item("Naberius", "wea_hop_014", Shops.gilgameshInc);
        public static Item Nue7 = new Item("Nue 7", "wea_hop_023", Shops.gilgameshInc);
        public static Item Alicanto = new Item("Alicanto", "wea_hop_015", Shops.gilgameshInc);
        public static Item Caladrius = new Item("Caladrius", "wea_hop_016", Shops.gilgameshInc);
        public static Item Nue8 = new Item("Nue 8", "wea_hop_024", Shops.gilgameshInc);

        public static Item FaerieTail = new Item("Faerie Tail", "wea_van_000", Shops.rdDepot);
        public static Item BindingRod = new Item("Binding Rod", "wea_van_001", Shops.upInArms);
        public static Item HuntersRod = new Item("Hunters Rod", "wea_van_002", Shops.upInArms);
        public static Item Nirvana1 = new Item("Nirvana 1", "wea_van_017", Shops.upInArms);
        public static Item Tigerclaw = new Item("Tigerclaw", "wea_van_003", Shops.gilgameshInc);
        public static Item Wyrmfang = new Item("Wyrmfang", "wea_van_004", Shops.gilgameshInc);
        public static Item Nirvana2 = new Item("Nirvana 2", "wea_van_018", Shops.gilgameshInc);
        public static Item HealersStaff = new Item("Healers Staff", "wea_van_005", Shops.plautusWorkshop);
        public static Item PhysiciansStaff = new Item("Physicians Staff", "wea_van_006", Shops.plautusWorkshop);
        public static Item Nirvana3 = new Item("Nirvana 3", "wea_van_019", Shops.plautusWorkshop);
        public static Item PearlwingStaff = new Item("Pearlwing Staff", "wea_van_007", Shops.upInArms);
        public static Item BrightwingStaff = new Item("Brightwing Staff", "wea_van_008", Shops.upInArms);
        public static Item Nirvana4 = new Item("Nirvana 4", "wea_van_020", Shops.upInArms);
        public static Item RodOfThorns = new Item("Rod Of Thorns", "wea_van_009", Shops.upInArms);
        public static Item OrochiRod = new Item("Orochi Rod", "wea_van_010", Shops.upInArms);
        public static Item Nirvana5 = new Item("Nirvana 5", "wea_van_021", Shops.upInArms);
        public static Item Mistilteinn = new Item("Mistilteinn", "wea_van_011", Shops.plautusWorkshop);
        public static Item ErinyesCane = new Item("Erinyes Cane", "wea_van_012", Shops.plautusWorkshop);
        public static Item Nirvana6 = new Item("Nirvana 6", "wea_van_022", Shops.plautusWorkshop);
        public static Item BelladonnaWand = new Item("Belladonna Wand", "wea_van_013", Shops.plautusWorkshop);
        public static Item MalboroWand = new Item("Malboro Wand", "wea_van_014", Shops.plautusWorkshop);
        public static Item Nirvana7 = new Item("Nirvana 7", "wea_van_023", Shops.plautusWorkshop);
        public static Item HeavenlyAxis = new Item("Heavenly Axis", "wea_van_015", Shops.gilgameshInc);
        public static Item Abraxas = new Item("Abraxas", "wea_van_016", Shops.gilgameshInc);
        public static Item Nirvana8 = new Item("Nirvana 8", "wea_van_024", Shops.gilgameshInc);

        public static Item Longinus = new Item("Longinus", "wea_fan_000", Shops.rdDepot);
        public static Item BladedLance = new Item("Bladed Lance", "wea_fan_001", Shops.upInArms);
        public static Item Glaive = new Item("Glaive", "wea_fan_002", Shops.upInArms);
        public static Item KainsLance1 = new Item("Kains Lance 1", "wea_fan_017", Shops.upInArms);
        public static Item DragoonLance = new Item("Dragoon Lance", "wea_fan_003", Shops.gilgameshInc);
        public static Item Dragonhorn = new Item("Dragonhorn", "wea_fan_004", Shops.gilgameshInc);
        public static Item KainsLance2 = new Item("Kains Lance 2", "wea_fan_018", Shops.gilgameshInc);
        public static Item Partisan = new Item("Partisan", "wea_fan_005", Shops.upInArms);
        public static Item Rhomphaia = new Item("Rhomphaia", "wea_fan_006", Shops.upInArms);
        public static Item KainsLance3 = new Item("Kains Lance 3", "wea_fan_019", Shops.upInArms);
        public static Item ShamanicSpear = new Item("Shamanic Spear", "wea_fan_007", Shops.gilgameshInc);
        public static Item HereticsHalberd = new Item("Heretics Halberd", "wea_fan_008", Shops.gilgameshInc);
        public static Item KainsLance4 = new Item("Kains Lance 4", "wea_fan_020", Shops.gilgameshInc);
        public static Item Punisher = new Item("Punisher", "wea_fan_009", Shops.plautusWorkshop);
        public static Item BanescissorSpear = new Item("Banescissor Spear", "wea_fan_010", Shops.plautusWorkshop);
        public static Item KainsLance5 = new Item("Kains Lance 5", "wea_fan_021", Shops.plautusWorkshop);
        public static Item PandoranSpear = new Item("Pandoran Spear", "wea_fan_011", Shops.gilgameshInc);
        public static Item CalamitySpear = new Item("Calamity Spear", "wea_fan_012", Shops.gilgameshInc);
        public static Item KainsLance6 = new Item("Kains Lance 6", "wea_fan_022", Shops.gilgameshInc);
        public static Item TamingPole = new Item("Taming Pole", "wea_fan_013", Shops.gilgameshInc);
        public static Item VenusGospel = new Item("Venus Gospel", "wea_fan_014", Shops.gilgameshInc);
        public static Item KainsLance7 = new Item("Kains Lance 7", "wea_fan_023", Shops.gilgameshInc);
        public static Item GaeBolg = new Item("Gae Bolg", "wea_fan_015", Shops.plautusWorkshop);
        public static Item Gungnir = new Item("Gungnir", "wea_fan_016", Shops.plautusWorkshop);
        public static Item KainsLance8 = new Item("Kains Lance 8", "wea_fan_024", Shops.plautusWorkshop);

        #endregion

        #region Accessories

        public static Item IronBangle = new Item("Iron Bangle", "acc_000_000", Shops.bwOutfitter);
        public static Item SilverBangle = new Item("Silver Bangle", "acc_000_001", Shops.bwOutfitter);
        public static Item TungstenBangle = new Item("Tungsten Bangle", "acc_000_002", Shops.bwOutfitter);
        public static Item TitaniumBangle = new Item("Titanium Bangle", "acc_000_003", Shops.bwOutfitter);
        public static Item GoldBangle = new Item("Gold Bangle", "acc_000_004", Shops.bwOutfitter);
        public static Item MythrilBangle = new Item("Mythril Bangle", "acc_000_005", Shops.bwOutfitter);
        public static Item PlatinumBangle = new Item("Platinum Bangle", "acc_000_006", Shops.sanctumLabs);
        public static Item DiamondBangle = new Item("Diamond Bangle", "acc_000_007", Shops.sanctumLabs);
        public static Item AdamantBangle = new Item("Adamant Bangle", "acc_000_008", Shops.rdDepot);
        public static Item WurtziteBangle = new Item("Wurtzite Bangle", "acc_000_009", Shops.rdDepot);

        public static Item PowerWristband = new Item("Power Wristband", "acc_000_100", Shops.bwOutfitter);
        public static Item BrawlersWristband = new Item("Brawlers Wristband", "acc_000_101", Shops.bwOutfitter);
        public static Item WarriorsWristband = new Item("Warriors Wristband", "acc_000_102", Shops.bwOutfitter);
        public static Item PowerGlove = new Item("Power Glove", "acc_000_103", Shops.sanctumLabs);
        public static Item KaiserKnuckles = new Item("Kaiser Knuckles", "acc_000_104", Shops.rdDepot);

        public static Item MagiciansMark = new Item("Magicians Mark", "acc_000_200", Shops.bwOutfitter);
        public static Item ShamansMark = new Item("Shamans Mark", "acc_000_201", Shops.bwOutfitter);
        public static Item SorcerersMark = new Item("Sorcerers Mark", "acc_000_202", Shops.bwOutfitter);
        public static Item WeirdingGlyph = new Item("Weirding Glyph", "acc_000_203", Shops.sanctumLabs);
        public static Item MagistralCrest = new Item("Magistral Crest", "acc_000_204", Shops.rdDepot);

        public static Item BlackBelt = new Item("Black Belt", "acc_000_300", Shops.bwOutfitter);
        public static Item GeneralsBelt = new Item("Generals Belt", "acc_000_301", Shops.bwOutfitter);
        public static Item ChampionsBelt = new Item("Champions Belt", "acc_000_302", Shops.sanctumLabs);

        public static Item RuneBracelet = new Item("Rune Bracelet", "acc_000_400", Shops.bwOutfitter);
        public static Item WitchsBracelet = new Item("Witchs Bracelet", "acc_000_401", Shops.bwOutfitter);
        public static Item MagussBracelet = new Item("Maguss Bracelet", "acc_000_402", Shops.sanctumLabs);

        public static Item RoyalArmlet = new Item("Royal Armlet", "acc_000_500", Shops.sanctumLabs);
        public static Item ImperialArmlet = new Item("Imperial Armlet", "acc_000_501", Shops.rdDepot);

        public static Item EmberRing = new Item("Ember Ring", "acc_001_000", Shops.magicalMoments);
        public static Item BlazeRing = new Item("Blaze Ring", "acc_001_001", Shops.magicalMoments);
        public static Item SalamandrineRing = new Item("Salamandrine Ring", "acc_001_002", Shops.moogleworks);

        public static Item FrostRing = new Item("Frost Ring", "acc_002_000", Shops.magicalMoments);
        public static Item IcicleRing = new Item("Icicle Ring", "acc_002_001", Shops.magicalMoments);
        public static Item BorealRing = new Item("Boreal Ring", "acc_002_002", Shops.moogleworks);

        public static Item SparkRing = new Item("Spark Ring", "acc_003_000", Shops.magicalMoments);
        public static Item FulmenRing = new Item("Fulmen Ring", "acc_003_001", Shops.magicalMoments);
        public static Item RaijinRing = new Item("Raijin Ring", "acc_003_002", Shops.moogleworks);

        public static Item AquaRing = new Item("Aqua Ring", "acc_004_000", Shops.magicalMoments);
        public static Item RiptideRing = new Item("Riptide Ring", "acc_004_001", Shops.magicalMoments);
        public static Item NereidRing = new Item("Nereid Ring", "acc_004_002", Shops.moogleworks);

        public static Item ZephyrRing = new Item("Zephyr Ring", "acc_005_000", Shops.magicalMoments);
        public static Item GaleRing = new Item("Gale Ring", "acc_005_001", Shops.magicalMoments);
        public static Item SylphidRing = new Item("Sylphid Ring", "acc_005_002", Shops.moogleworks);

        public static Item ClayRing = new Item("Clay Ring", "acc_006_000", Shops.magicalMoments);
        public static Item StilstoneRing = new Item("Stilstone Ring", "acc_006_001", Shops.magicalMoments);
        public static Item GaianRing = new Item("Gaian Ring", "acc_006_002", Shops.moogleworks);

        public static Item GiantsGlove = new Item("Giants Glove", "acc_009_000", Shops.bwOutfitter);
        public static Item WarlocksGlove = new Item("Warlocks Glove", "acc_009_001", Shops.bwOutfitter);

        public static Item GlassBuckle = new Item("Glass Buckle", "acc_010_000", Shops.bwOutfitter);
        public static Item TektiteBuckle = new Item("Tektite Buckle", "acc_010_001", Shops.bwOutfitter);

        public static Item MetalArmband = new Item("Metal Armband", "acc_011_000", Shops.bwOutfitter);
        public static Item CeramicArmband = new Item("Ceramic Armband", "acc_011_001", Shops.bwOutfitter);

        public static Item SerenitySachet = new Item("Serenity Sachet", "acc_012_000", Shops.bwOutfitter);
        public static Item SafeguardSachet = new Item("Safeguard Sachet", "acc_012_001", Shops.bwOutfitter);

        public static Item GlassOrb = new Item("Glass Orb", "acc_013_000", Shops.bwOutfitter);
        public static Item DragonflyOrb = new Item("Dragonfly Orb", "acc_013_001", Shops.bwOutfitter);

        public static Item StarPendant = new Item("Star Pendant", "acc_014_000", Shops.bwOutfitter);
        public static Item StarfallPendant = new Item("Starfall Pendant", "acc_014_001", Shops.bwOutfitter);

        public static Item PearlNecklace = new Item("Pearl Necklace", "acc_015_000", Shops.bwOutfitter);
        public static Item GemstoneNecklace = new Item("Gemstone Necklace", "acc_015_001", Shops.bwOutfitter);

        public static Item WardingTalisman = new Item("Warding Talisman", "acc_016_000", Shops.bwOutfitter);
        public static Item HexbaneTalisman = new Item("Hexbane Talisman", "acc_016_001", Shops.bwOutfitter);

        public static Item PainDampener = new Item("Pain Dampener", "acc_017_000", Shops.bwOutfitter);
        public static Item PainDeflector = new Item("Pain Deflector", "acc_017_001", Shops.bwOutfitter);

        public static Item WhiteCape = new Item("White Cape", "acc_018_000", Shops.bwOutfitter);
        public static Item EffulgentCape = new Item("Effulgent Cape", "acc_018_001", Shops.bwOutfitter);

        public static Item RainbowAnklet = new Item("Rainbow Anklet", "acc_019_000", Shops.bwOutfitter);
        public static Item MoonbowAnklet = new Item("Moonbow Anklet", "acc_019_001", Shops.bwOutfitter);

        public static Item CherubsCrown = new Item("Cherubs Crown", "acc_020_000", Shops.bwOutfitter);
        public static Item SeraphsCrown = new Item("Seraphs Crown", "acc_020_001", Shops.bwOutfitter);

        public static Item GuardianAmulet = new Item("Guardian Amulet", "acc_025_000", Shops.magicalMoments);
        public static Item ShieldTalisman = new Item("Shield Talisman", "acc_025_001", Shops.magicalMoments);

        public static Item AuricAmulet = new Item("Auric Amulet", "acc_026_000", Shops.magicalMoments);
        public static Item SoulfontTalisman = new Item("Soulfont Talisman", "acc_026_001", Shops.magicalMoments);

        public static Item WatchmansAmulet = new Item("Watchmans Amulet", "acc_027_000", Shops.magicalMoments);
        public static Item ShroudingTalisman = new Item("Shrouding Talisman", "acc_027_001", Shops.magicalMoments);

        public static Item HerosAmulet = new Item("Heros Amulet", "acc_028_000", Shops.magicalMoments);
        public static Item MoraleTalisman = new Item("Morale Talisman", "acc_028_001", Shops.magicalMoments);

        public static Item SaintsAmulet = new Item("Saints Amulet", "acc_029_000", Shops.magicalMoments);
        public static Item BlessedTalisman = new Item("Blessed Talisman", "acc_029_001", Shops.magicalMoments);

        public static Item ZealotAmulet = new Item("Zealot Amulet", "acc_030_000", Shops.magicalMoments);
        public static Item BattleTalisman = new Item("Battle Talisman", "acc_030_001", Shops.magicalMoments);

        public static Item FlamebaneBrooch = new Item("Flamebane Brooch", "acc_031_000", Shops.magicalMoments);
        public static Item FlameshieldEarring = new Item("Flameshield Earring", "acc_031_001", Shops.magicalMoments);

        public static Item FrostbaneBrooch = new Item("Frostbane Brooch", "acc_032_000", Shops.magicalMoments);
        public static Item FrostshieldEarring = new Item("Frostshield Earring", "acc_032_001", Shops.magicalMoments);

        public static Item SparkbaneBrooch = new Item("Sparkbane Brooch", "acc_033_000", Shops.magicalMoments);
        public static Item SparkshieldEarring = new Item("Sparkshield Earring", "acc_033_001", Shops.magicalMoments);

        public static Item AquabaneBrooch = new Item("Aquabane Brooch", "acc_034_000", Shops.magicalMoments);
        public static Item AquashieldEarring = new Item("Aquashield Earring", "acc_034_001", Shops.magicalMoments);

        public static Item HermesSandals = new Item("Hermes Sandals", "acc_035_000", Shops.moogleworks);
        public static Item SprintShoes = new Item("Sprint Shoes", "acc_035_001", Shops.sanctumLabs);

        public static Item TetradicCrown = new Item("Tetradic Crown", "acc_036_000", Shops.moogleworks);
        public static Item TetradicTiara = new Item("Tetradic Tiara", "acc_036_001", Shops.rdDepot);

        public static Item WhistlewindScarf = new Item("Whistlewind Scarf", "acc_037_000", Shops.moogleworks);
        public static Item AuroraScarf = new Item("Aurora Scarf", "acc_037_001", Shops.moogleworks);

        public static Item NimbletoeBoots = new Item("Nimbletoe Boots", "acc_038_000", Shops.moogleworks);

        public static Item GoldWatch = new Item("Gold Watch", "acc_040_000", Shops.moogleworks);
        public static Item ChampionsBadge = new Item("Champions Badge", "acc_040_001", Shops.sanctumLabs);
        public static Item SurvivalistCatalog = new Item("Survivalist Catalog", "acc_040_002", Shops.rdDepot);

        public static Item CollectorCatalog = new Item("Collector Catalog", "acc_039_000", Shops.moogleworks);
        public static Item ConnoisseurCatalog = new Item("Connoisseur Catalog", "acc_039_001", Shops.sanctumLabs);

        public static Item HuntersFriend = new Item("Hunters Friend", "acc_041_000", Shops.moogleworks);
        public static Item SpeedSash = new Item("Speed Sash", "acc_041_001", Shops.moogleworks);
        public static Item EnergySash = new Item("Energy Sash", "acc_041_002", Shops.sanctumLabs);

        public static Item DoctorsCode = new Item("Doctors Code", "acc_053_000", Shops.rdDepot);

        public static Item GrowthEgg = new Item("Growth Egg", "acc_045_000", Shops.sanctumLabs);

        public static Item EntiteRing = new Item("Entite Ring", "acc_007_000", Shops.rdDepot);

        public static Item GoddesssFavor = new Item("Goddesss Favor", "acc_054_000", Shops.rdDepot);

        public static Item Ribbon = new Item("Ribbon", "acc_023_000", Shops.sanctumLabs);
        public static Item SuperRibbon = new Item("Super Ribbon", "acc_023_001", Shops.rdDepot);

        public static Item GenjiGlove = new Item("Genji Glove", "acc_042_001", Shops.sanctumLabs);

        public static Item FireCharm = new Item("Fire Charm", "acc_047_000", Shops.magicalMoments);
        public static Item IceCharm = new Item("Ice Charm", "acc_048_000", Shops.magicalMoments);
        public static Item LightningCharm = new Item("Lightning Charm", "acc_049_000", Shops.magicalMoments);
        public static Item WaterCharm = new Item("Water Charm", "acc_050_000", Shops.magicalMoments);
        public static Item WindCharm = new Item("Wind Charm", "acc_051_000", Shops.magicalMoments);
        public static Item EarthCharm = new Item("Earth Charm", "acc_052_000", Shops.magicalMoments);

        public static Item TwentySidedDie = new Item("Twenty Sided Die", "acc_046_000", Shops.moogleworks);

        #endregion

        #region Components

        public static Item BegrimedClaw = new Item("Begrimed Claw", "material_m000", Shops.creatureComforts);
        public static Item BestialClaw = new Item("Bestial Claw", "material_m001", Shops.creatureComforts);
        public static Item GargantuanClaw = new Item("Gargantuan Claw", "material_m002", Shops.creatureComforts);
        public static Item HellishTalon = new Item("Hellish Talon", "material_m003", Shops.creatureComforts);
        public static Item ShatteredBone = new Item("Shattered Bone", "material_m004", Shops.creatureComforts);
        public static Item SturdyBone = new Item("Sturdy Bone", "material_m005", Shops.creatureComforts);
        public static Item OtherworldlyBone = new Item("Otherworldly Bone", "material_m006", Shops.creatureComforts);
        public static Item AncientBone = new Item("Ancient Bone", "material_m007", Shops.creatureComforts);
        public static Item MoistenedScale = new Item("Moistened Scale", "material_m009", Shops.creatureComforts);
        public static Item SeapetalScale = new Item("Seapetal Scale", "material_m010", Shops.creatureComforts);
        public static Item AbyssalScale = new Item("Abyssal Scale", "material_m011", Shops.creatureComforts);
        public static Item SeakingsBeard = new Item("Seakings Beard", "material_m012", Shops.creatureComforts);
        public static Item SegmentedCarapace = new Item("Segmented Carapace", "material_m013", Shops.creatureComforts);
        public static Item IronShell = new Item("Iron Shell", "material_m014", Shops.creatureComforts);
        public static Item ArmoredShell = new Item("Armored Shell", "material_m015", Shops.creatureComforts);
        public static Item RegeneratingCarapace = new Item("Regenerating Carapace", "material_m016", Shops.creatureComforts);
        public static Item ChippedFang = new Item("Chipped Fang", "material_m017", Shops.creatureComforts);
        public static Item WickedFang = new Item("Wicked Fang", "material_m018", Shops.creatureComforts);
        public static Item MonstrousFang = new Item("Monstrous Fang", "material_m019", Shops.creatureComforts);
        public static Item SinisterFang = new Item("Sinister Fang", "material_m020", Shops.creatureComforts);
        public static Item SeveredWing = new Item("Severed Wing", "material_m021", Shops.creatureComforts);
        public static Item ScaledWing = new Item("Scaled Wing", "material_m022", Shops.creatureComforts);
        public static Item AbominableWing = new Item("Abominable Wing", "material_m023", Shops.creatureComforts);
        public static Item MenacingWings = new Item("Menacing Wings", "material_m024", Shops.creatureComforts);
        public static Item MoltedTail = new Item("Molted Tail", "material_m025", Shops.creatureComforts);
        public static Item BarbedTail = new Item("Barbed Tail", "material_m026", Shops.creatureComforts);
        public static Item DiabolicTail = new Item("Diabolic Tail", "material_m027", Shops.creatureComforts);
        public static Item EntrancingTail = new Item("Entrancing Tail", "material_m028", Shops.creatureComforts);
        public static Item TornLeather = new Item("Torn Leather", "material_m029", Shops.creatureComforts);
        public static Item ThickenedHide = new Item("Thickened Hide", "material_m030", Shops.creatureComforts);
        public static Item SmoothHide = new Item("Smooth Hide", "material_m031", Shops.creatureComforts);
        public static Item SuppleLeather = new Item("Supple Leather", "material_m032", Shops.creatureComforts);
        public static Item GummyOil = new Item("Gummy Oil", "material_m033", Shops.creatureComforts);
        public static Item FragrantOil = new Item("Fragrant Oil", "material_m034", Shops.creatureComforts);
        public static Item MedicinalOil = new Item("Medicinal Oil", "material_m035", Shops.creatureComforts);
        public static Item EsotericOil = new Item("Esoteric Oil", "material_m036", Shops.creatureComforts);
        public static Item ScragglyWool = new Item("Scraggly Wool", "material_m037", Shops.creatureComforts);
        public static Item RoughWool = new Item("Rough Wool", "material_m038", Shops.creatureComforts);
        public static Item ThickWool = new Item("Thick Wool", "material_m039", Shops.creatureComforts);
        public static Item FluffyWool = new Item("Fluffy Wool", "material_m040", Shops.creatureComforts);
        public static Item MurkyOoze = new Item("Murky Ooze", "material_m045", Shops.creatureComforts);
        public static Item VibrantOoze = new Item("Vibrant Ooze", "material_m046", Shops.creatureComforts);
        public static Item TransparentOoze = new Item("Transparent Ooze", "material_m047", Shops.creatureComforts);
        public static Item WonderGel = new Item("Wonder Gel", "material_m048", Shops.creatureComforts);
        public static Item FracturedHorn = new Item("Fractured Horn", "material_m049", Shops.creatureComforts);
        public static Item SpinedHorn = new Item("Spined Horn", "material_m050", Shops.creatureComforts);
        public static Item FiendishHorn = new Item("Fiendish Horn", "material_m051", Shops.creatureComforts);
        public static Item InfernalHorn = new Item("Infernal Horn", "material_m052", Shops.creatureComforts);
        public static Item StrangeFluid = new Item("Strange Fluid", "material_m053", Shops.creatureComforts);
        public static Item EnigmaticFluid = new Item("Enigmatic Fluid", "material_m054", Shops.creatureComforts);
        public static Item MysteriousFluid = new Item("Mysterious Fluid", "material_m055", Shops.creatureComforts);
        public static Item IneffableFluid = new Item("Ineffable Fluid", "material_m056", Shops.creatureComforts);
        public static Item CiethTear = new Item("Cieth Tear", "material_m057", Shops.creatureComforts);
        public static Item TearOfFrustration = new Item("Tear Of Frustration", "material_m058", Shops.creatureComforts);
        public static Item TearOfRemorse = new Item("Tear Of Remorse", "material_m059", Shops.creatureComforts);
        public static Item TearOfWoe = new Item("Tear Of Woe", "material_m060", Shops.creatureComforts);
        public static Item RedMycelium = new Item("Red Mycelium", "material_m068", Shops.creatureComforts);
        public static Item BlueMycelium = new Item("Blue Mycelium", "material_m069", Shops.creatureComforts);
        public static Item WhiteMycelium = new Item("White Mycelium", "material_m070", Shops.creatureComforts);
        public static Item BlackMycelium = new Item("Black Mycelium", "material_m071", Shops.creatureComforts);
        public static Item DawnlightDew = new Item("Dawnlight Dew", "material_m064", Shops.creatureComforts);
        public static Item DusklightDew = new Item("Dusklight Dew", "material_m065", Shops.creatureComforts);
        public static Item Gloomstalk = new Item("Gloomstalk", "material_m066", Shops.creatureComforts);
        public static Item Sunpetal = new Item("Sunpetal", "material_m067", Shops.creatureComforts);
        public static Item MoonblossomSeed = new Item("Moonblossom Seed", "material_m074", Shops.creatureComforts);
        public static Item StarblossomSeed = new Item("Starblossom Seed", "material_m075", Shops.creatureComforts);
        public static Item ChocoboPlume = new Item("Chocobo Plume", "material_m061", Shops.creatureComforts);
        public static Item ChocoboTailFeather = new Item("Chocobo Tail Feather", "material_m062", Shops.creatureComforts);
        public static Item SucculentFruit = new Item("Succulent Fruit", "material_m072", Shops.creatureComforts);
        public static Item MalodorousFruit = new Item("Malodorous Fruit", "material_m073", Shops.creatureComforts);
        public static Item GreenNeedle = new Item("Green Needle", "material_m063", Shops.rdDepot);
        public static Item Perfume = new Item("Perfume", "material_m076", Shops.creatureComforts);

        public static Item InsulatedCabling = new Item("Insulated Cabling", "material_j000", Shops.lenorasGarage);
        public static Item FibreOpticCable = new Item("Fibre Optic Cable", "material_j001", Shops.lenorasGarage);
        public static Item LiquidCrystalLens = new Item("Liquid Crystal Lens", "material_j002", Shops.lenorasGarage);
        public static Item RingJoint = new Item("Ring Joint", "material_j003", Shops.lenorasGarage);
        public static Item EpicyclicGear = new Item("Epicyclic Gear", "material_j004", Shops.lenorasGarage);
        public static Item Crankshaft = new Item("Crankshaft", "material_j005", Shops.lenorasGarage);
        public static Item ElectrolyticCapacitor = new Item("Electrolytic Capacitor", "material_j006", Shops.lenorasGarage);
        public static Item Flywheel = new Item("Flywheel", "material_j007", Shops.lenorasGarage);
        public static Item Sprocket = new Item("Sprocket", "material_j008", Shops.lenorasGarage);
        public static Item Actuator = new Item("Actuator", "material_j009", Shops.lenorasGarage);
        public static Item SparkPlug = new Item("Spark Plug", "material_j010", Shops.lenorasGarage);
        public static Item IridiumPlug = new Item("Iridium Plug", "material_j011", Shops.lenorasGarage);
        public static Item NeedleValve = new Item("Needle Valve", "material_j012", Shops.lenorasGarage);
        public static Item ButterflyValve = new Item("Butterfly Valve", "material_j013", Shops.lenorasGarage);
        public static Item BombAshes = new Item("Bomb Ashes", "material_m041", Shops.lenorasGarage);
        public static Item BombFragment = new Item("Bomb Fragment", "material_m042", Shops.lenorasGarage);
        public static Item BombShell = new Item("Bomb Shell", "material_m043", Shops.lenorasGarage);
        public static Item BombCore = new Item("Bomb Core", "material_m044", Shops.lenorasGarage);
        public static Item AnalogCircuit = new Item("Analog Circuit", "material_j014", Shops.lenorasGarage);
        public static Item DigitalCircuit = new Item("Digital Circuit", "material_j015", Shops.lenorasGarage);
        public static Item Gyroscope = new Item("Gyroscope", "material_j016", Shops.lenorasGarage);
        public static Item Electrode = new Item("Electrode", "material_j017", Shops.lenorasGarage);
        public static Item CeramicArmor = new Item("Ceramic Armor", "material_j018", Shops.lenorasGarage);
        public static Item ChobhamArmor = new Item("Chobham Armor", "material_j019", Shops.lenorasGarage);
        public static Item RadialBearing = new Item("Radial Bearing", "material_j020", Shops.lenorasGarage);
        public static Item ThrustBearing = new Item("Thrust Bearing", "material_j021", Shops.lenorasGarage);
        public static Item Solenoid = new Item("Solenoid", "material_j022", Shops.lenorasGarage);
        public static Item MobiusCoil = new Item("Mobius Coil", "material_j023", Shops.lenorasGarage);
        public static Item TungstenTube = new Item("Tungsten Tube", "material_j024", Shops.lenorasGarage);
        public static Item TitaniumTube = new Item("Titanium Tube", "material_j025", Shops.lenorasGarage);
        public static Item PassiveDetector = new Item("Passive Detector", "material_j026", Shops.lenorasGarage);
        public static Item ActiveDetector = new Item("Active Detector", "material_j027", Shops.lenorasGarage);
        public static Item Transformer = new Item("Transformer", "material_j028", Shops.lenorasGarage);
        public static Item Amplifier = new Item("Amplifier", "material_j029", Shops.lenorasGarage);
        public static Item Carburetor = new Item("Carburetor", "material_j030", Shops.lenorasGarage);
        public static Item Supercharger = new Item("Supercharger", "material_j031", Shops.lenorasGarage);
        public static Item PiezoelectricElement = new Item("Piezoelectric Element", "material_j032", Shops.lenorasGarage);
        public static Item CrystalOscillator = new Item("Crystal Oscillator", "material_j033", Shops.lenorasGarage);
        public static Item ParaffinOil = new Item("Paraffin Oil", "material_j034", Shops.lenorasGarage);
        public static Item SiliconeOil = new Item("Silicone Oil", "material_j035", Shops.lenorasGarage);
        public static Item SyntheticMuscle = new Item("Synthetic Muscle", "material_j036", Shops.lenorasGarage);
        public static Item Turboprop = new Item("Turboprop", "material_j037", Shops.lenorasGarage);
        public static Item Turbojet = new Item("Turbojet", "material_j038", Shops.lenorasGarage);
        public static Item TeslaTurbine = new Item("Tesla Turbine", "material_j039", Shops.lenorasGarage);
        public static Item PolymerEmulsion = new Item("Polymer Emulsion", "material_j040", Shops.lenorasGarage);
        public static Item FerroelectricFilm = new Item("Ferroelectric Film", "material_j041", Shops.lenorasGarage);
        public static Item Superconductor = new Item("Superconductor", "material_j042", Shops.lenorasGarage);
        public static Item PerfectConductor = new Item("Perfect Conductor", "material_j043", Shops.lenorasGarage);
        public static Item ParticleAccelerator = new Item("Particle Accelerator", "material_j044", Shops.rdDepot);
        public static Item UltracompactReactor = new Item("Ultracompact Reactor", "material_j045", Shops.rdDepot);

        public static Item CreditChip = new Item("Credit Chip", "material_j046", null);
        public static Item IncentiveChip = new Item("Incentive Chip", "material_j047", null);
        public static Item CactuarDoll = new Item("Cactuar Doll", "material_j048", null);
        public static Item MooglePuppet = new Item("Moogle Puppet", "material_j049", null);
        public static Item TonberryFigurine = new Item("Tonberry Figurine", "material_j050", null);
        public static Item PlushChocobo = new Item("Plush Chocobo", "material_j051", null);
        public static Item GoldDust = new Item("Gold Dust", "material_o010", null);
        public static Item GoldNugget = new Item("Gold Nugget", "material_o011", null);
        public static Item PlatinumIngot = new Item("Platinum Ingot", "material_o012", null);


        public static Item Millerite = new Item("Millerite", "material_o000", Shops.theMotherlode);
        public static Item Rhodochrosite = new Item("Rhodochrosite", "material_o001", Shops.theMotherlode);
        public static Item Cobaltite = new Item("Cobaltite", "material_o002", Shops.theMotherlode);
        public static Item Perovskite = new Item("Perovskite", "material_o003", Shops.theMotherlode);
        public static Item Uraninite = new Item("Uraninite", "material_o004", Shops.theMotherlode);
        public static Item MnarStone = new Item("Mnar Stone", "material_o005", Shops.theMotherlode);
        public static Item Scarletite = new Item("Scarletite", "material_o006", Shops.theMotherlode);
        public static Item Adamantite = new Item("Adamantite", "material_o007", Shops.rdDepot);
        public static Item DarkMatter = new Item("Dark Matter", "material_o008", Shops.rdDepot);
        public static Item Trapezohedron = new Item("Trapezohedron", "material_o009", Shops.rdDepot);

        #endregion



        public static Item UnicornMart = new Item("Unicorn Mart", "key_shop_00", null);
        public static Item EdenPharmaceuticals = new Item("Eden Pharmaceuticals", "key_shop_01", null);
        public static Item UpInArms = new Item("Up In Arms", "key_shop_02", null);
        public static Item PlautusWorkshop = new Item("Plautus's Workshop", "key_shop_03", null);
        public static Item GilgameshInc = new Item("Gilgamesh, Inc.", "key_shop_05", null);
        public static Item BWOutfitters = new Item("B&W Outfitters", "key_shop_06", null);
        public static Item MagicalMoments = new Item("Magical Moments", "key_shop_07", null);
        public static Item Moogleworks = new Item("Moogleworks", "key_shop_08", null);
        public static Item SanctumLabs = new Item("Sanctum Labs", "key_shop_09", null);
        public static Item CreatureComforts = new Item("Creature Comforts", "key_shop_10", null);
        public static Item TheMotherlode = new Item("The Motherlode", "key_shop_11", null);
        public static Item LenorasGarage = new Item("Lenora's Garage", "key_shop_12", null);
        public static Item RDDepot = new Item("R&D Depot", "key_shop_13", null);

        public static Item ctool = new Item("ctool", "key_ctool", null);
    }
}
