using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FF13Data
{
    public class Enemies
    {
        public static List<Enemy> enemies = new List<Enemy>();

        public static Enemy pantheron = new Enemy("Pantheron", "m001");
        public static Enemy silverLobo = new Enemy("Silver Lobo", "m002");
        public static Enemy gorgonopsid = new Enemy("Gorgonopsid", "m003");
        public static Enemy adamantheron = new Enemy("Adamantheron", "m004");
        public static Enemy managarmr = new Enemy("Managarmr", "m005");

        public static Enemy rustPudding = new Enemy("Rust Pudding", "m007");
        public static Enemy corrosiveCustard = new Enemy("Corrosive Custard", "m007l", null, EnemyType.Rare);
        public static Enemy ferruginousPudding = new Enemy("Ferruginous Pudding", "m007m", null, EnemyType.Rare);
        public static Enemy flandragora = new Enemy("Flandragora", "m008");
        public static Enemy hybridFlora = new Enemy("Hybrid Flora", "m008l");
        public static Enemy flanborg = new Enemy("Flanborg", "m010");

        public static Enemy dreadnought1 = new Enemy("Dreadnought 1", "m012", null, EnemyType.Boss);
        public static Enemy dreadnought2 = new Enemy("Dreadnought 2", "m012_2", null, EnemyType.Boss);

        public static Enemy feralBehemoth = new Enemy("Feral Behemoth", "m015");
        public static Enemy betaBehemoth = new Enemy("Beta Behemoth", "m016");
        public static Enemy betaBehemoth2 = new Enemy("Beta Behemoth 2", "m016_x1", betaBehemoth);

        public static Enemy corpsMarksman = new Enemy("Corps Marksman", "m017");

        public static Enemy orion = new Enemy("Orion", "m018");

        public static Enemy ushu2 = new Enemy("Ushumgal Subjugator 2", "m019", null, EnemyType.Boss);
        public static Enemy ushuHope = new Enemy("Ushumgal Subjugator Hope", "m019_hope", null, EnemyType.Boss);
        public static Enemy ushu1 = new Enemy("Ushumgal Subjugator 1", "m019_x1", null, EnemyType.Boss);
        public static Enemy ushu1Berserk = new Enemy("Ushumgal Subjugator 1 Berserk", "m019_x1_berserk", ushu1, EnemyType.Boss);

        public static Enemy havocSkytank = new Enemy("Havoc Skytank", "m020", null, EnemyType.Boss);
        public static Enemy havocSkytankVuln = new Enemy("Havoc Skytank Vulnerable", "m020_x1", havocSkytank, EnemyType.Boss);
        public static Enemy portsideTurret = new Enemy("Portside Turret", "m020_gun_l");
        public static Enemy starboardTurret = new Enemy("Starboard Turret", "m020_gun_r");
        public static Enemy portsideHull = new Enemy("Portside Hull", "m020_missile_l");
        public static Enemy starboardHull = new Enemy("Starboard Hull", "m020_missile_r");

        public static Enemy skatane = new Enemy("Skata'ne", "m034");
        public static Enemy incubus = new Enemy("Incubus", "m035");
        public static Enemy yaksha = new Enemy("Yaksha", "m036");

        public static Enemy triffid = new Enemy("Triffid", "m037");
        public static Enemy vespid = new Enemy("Vespid", "m038");
        public static Enemy barbedSpecter = new Enemy("Barbed Specter", "m039");
        public static Enemy vespidSoldier = new Enemy("Vespid Soldier", "m040");

        public static Enemy gremlin = new Enemy("Gremlin", "m041");
        public static Enemy imp = new Enemy("Imp", "m042");
        public static Enemy zwergScandroid = new Enemy("Zwerg Scandroid", "m043");
        public static Enemy leyak = new Enemy("Leyak", "m045");

        public static Enemy alphaBehemoth = new Enemy("Alpha Behemoth", "m047");
        public static Enemy alphaBehemoth2 = new Enemy("Alpha Behemoth 2", "m047_x1", alphaBehemoth);

        public static Enemy garudaInterceptor1 = new Enemy("Garuda Interceptor 1", "m048", null, EnemyType.Boss);
        public static Enemy garudaInterceptor2 = new Enemy("Garuda Interceptor 2", "m048_s1", null, EnemyType.Boss);
        public static Enemy garudaInterceptor2Stagger = new Enemy("Garuda Interceptor 2 Staggered", "m048_s2", garudaInterceptor2, EnemyType.Boss);

        public static Enemy kalavinkaStriker1 = new Enemy("Kalavinka Striker 1", "m049", null, EnemyType.Boss);
        public static Enemy kalavinkaStriker2 = new Enemy("Kalavinka Striker 2", "m049_2", null, EnemyType.Boss);

        public static Enemy wyvern = new Enemy("Wyvern", "m050", null, EnemyType.Rare);

        public static Enemy munchkin = new Enemy("Munchkin", "m054");
        public static Enemy borgbear = new Enemy("Borgbear", "m055");
        public static Enemy goblinChieftan = new Enemy("Goblin Chieftan", "m056");
        public static Enemy munchkinMaestro = new Enemy("Munchkin Maestro", "m057");
        public static Enemy borgbearHero = new Enemy("Borgbear Hero", "m058", null, EnemyType.Rare);

        public static Enemy sahagin = new Enemy("Sahagin", "m059");
        public static Enemy orobon = new Enemy("Orobon", "m060");
        public static Enemy dagonite = new Enemy("Dagonite", "m061");

        public static Enemy corpsWatchman = new Enemy("Corps Watchman", "m062");

        public static Enemy pulseworkSoldier = new Enemy("Pulsework Soldier", "m063");
        public static Enemy pulseworkSoldierStagger = new Enemy("Pulsework Soldier Staggered", "m063_x1", pulseworkSoldier);
        public static Enemy pulseworkKnight = new Enemy("Pulsework Knight", "m064");
        public static Enemy pulseworkKnightStagger = new Enemy("Pulsework Knight Staggered", "m064_x2", pulseworkKnight);
        public static Enemy pulseworkGladiator = new Enemy("Pulsework Gladiator", "m065");
        public static Enemy pulseworkGladiatorStagger = new Enemy("Pulsework Gladiator Staggered", "m065_x3", pulseworkGladiatorStagger);

        public static Enemy bomb = new Enemy("Bomb", "m066");

        public static Enemy navidon = new Enemy("Navidon", "m069");
        public static Enemy navidonStagger = new Enemy("Navidon Staggered", "m069_break", navidon);
        public static Enemy scalebeast = new Enemy("Scalebeast", "m070", null, EnemyType.Rare);
        public static Enemy scalebeastStagger = new Enemy("Scalebeast Staggered", "m070_break", scalebeast, EnemyType.Rare);
        public static Enemy lucidon = new Enemy("Lucidon", "m071", null, EnemyType.Rare);
        public static Enemy lucidonStagger = new Enemy("Lucidon Stagger", "m071_break", lucidon, EnemyType.Rare);
        public static Enemy thermadon = new Enemy("Thermadon", "m072");
        public static Enemy thermadonStagger = new Enemy("Thermadon Staggered", "m072_break", thermadon);

        public static Enemy greaterBehemoth = new Enemy("Greater Behemoth", "m075");
        public static Enemy greaterBehemothStand = new Enemy("Greater Behemoth Standing", "m075_x1");
        public static Enemy protoBehemoth = new Enemy("Proto-Behemoth", "m077", null, EnemyType.Rare);
        public static Enemy protoBehemothStand = new Enemy("Proto-Behemoth", "m077_x1", protoBehemoth, EnemyType.Rare);

        public static Enemy flanitor = new Enemy("Flanitor", "m079");

        public static Enemy psicomPredator = new Enemy("PSICOM Predator", "m080");
        public static Enemy psicomRanger = new Enemy("PSICOM Ranger", "m081");
        public static Enemy psicomRangerSnow = new Enemy("PSICOM Ranger Solo Snow", "m081_zo", psicomRanger);
        public static Enemy psicomWarden = new Enemy("PSICOM Warden", "m082");
        public static Enemy psicomInfiltrator = new Enemy("PSICOM Infiltrator", "m083");

        public static Enemy sanctumArchangel = new Enemy("Sanctum Archangel", "m084");

        public static Enemy flan = new Enemy("Flan", "m091");
        public static Enemy monstrousFlan = new Enemy("Monstrous Flan", "m091l", null, EnemyType.Rare);
        public static Enemy direFlan = new Enemy("Dire Flan", "m091m");

        public static Enemy goblin = new Enemy("Goblin", "m094");

        public static Enemy asterProto = new Enemy("Aster Protoflorian", "m097", null, EnemyType.Boss);
        public static Enemy asterProtoFire = new Enemy("Aster Protoflorian Exofire", "m097_f", asterProto, EnemyType.Boss);
        public static Enemy asterProtoIce = new Enemy("Aster Protoflorian Exoice", "m097_i", asterProto, EnemyType.Boss);
        public static Enemy asterProtoThunder = new Enemy("Aster Protoflorian Exothunder", "m097_t", asterProto, EnemyType.Boss);
        public static Enemy asterProtoWater = new Enemy("Aster Protoflorian Exowater", "m097_w", asterProto, EnemyType.Boss);

        public static Enemy vernalHarvester = new Enemy("Vernal Harvester", "m098", null, EnemyType.Rare);
        public static Enemy vernalHarvesterFire = new Enemy("Vernal Harvester Exofire", "m098_f", vernalHarvester, EnemyType.Rare);
        public static Enemy vernalHarvesterIce = new Enemy("Vernal Harvester Exoice", "m098_i", vernalHarvester, EnemyType.Rare);
        public static Enemy vernalHarvesterThunder = new Enemy("Vernal Harvester Exothunder", "m098_t", vernalHarvester, EnemyType.Rare);
        public static Enemy vernalHarvesterWater = new Enemy("Vernal Harvester Exowater", "m098_w", vernalHarvester, EnemyType.Rare);

        public static Enemy crawler = new Enemy("Crawler", "m099");
        public static Enemy noctilucale = new Enemy("Nuctilucale", "m100");
        public static Enemy alraune = new Enemy("Alraune", "m101");
        public static Enemy fragLeech = new Enemy("Frag Leech", "m102");

        public static Enemy ghast = new Enemy("Ghast", "m104");
        public static Enemy taxim = new Enemy("Taxim", "m105");
        public static Enemy strigoi = new Enemy("Strigoi", "m106");
        public static Enemy vampire = new Enemy("Vampire", "m107");

        public static Enemy wight = new Enemy("Wight", "m108");
        public static Enemy nelapsi = new Enemy("Nelapsi", "m109");
        public static Enemy pijavica = new Enemy("Pijavica", "m110");
        public static Enemy varcolaci = new Enemy("Varcolaci", "m111");

        public static Enemy uhlan = new Enemy("Uhlan", "m115");
        public static Enemy bulwarker = new Enemy("Bulwarker", "m116", null, EnemyType.Rare);

        public static Enemy ciconiaVelocycle = new Enemy("Ciconia Velocycle", "m117", null, EnemyType.Rare);
        public static Enemy ciconiaVelocycle2 = new Enemy("Ciconia Velocycle 2", "m117_s2", ciconiaVelocycle, EnemyType.Rare);

        public static Enemy milvusVelocycle = new Enemy("Milvus Velocycle", "m118", null, EnemyType.Rare);
        public static Enemy milvusVelocycle2 = new Enemy("Milvus Velocycle 2", "m118_s2", milvusVelocycle, EnemyType.Rare);

        public static Enemy falcoVelocycle = new Enemy("Falco Velocycle", "m119", null, EnemyType.Rare);
        public static Enemy falcoVelocycle2 = new Enemy("Falco Velocycle 2", "m119_s2", falcoVelocycle, EnemyType.Rare);

        public static Enemy aquilaVelocycle = new Enemy("Aquila Velocycle", "m120");
        public static Enemy aquilaVelocycle2 = new Enemy("Aquila Velocycle 2", "m120_s2", aquilaVelocycle);

        public static Enemy bloodfangBass = new Enemy("Bloodfang Bass", "m123");
        public static Enemy breshanBass = new Enemy("Breshan Bass", "m124");
        public static Enemy hedgeFrog = new Enemy("Hedge Frog", "m125");
        public static Enemy mudFrog = new Enemy("Mud Frog", "m126");
        public static Enemy ceratosaur = new Enemy("Ceratosaur", "m127");
        public static Enemy ceratoraptor = new Enemy("Ceratoraptor", "m128");

        public static Enemy manasvinWarmech1 = new Enemy("Manasvin Warmech 1", "m129", null, EnemyType.Boss);
        public static Enemy manasvinWarmech1Part2 = new Enemy("Manasvin Warmech 1 Part 2", "m129_01", null, EnemyType.Boss);
        public static Enemy manasvinWarmech2 = new Enemy("Manasvin Warmech 2", "m130", null, EnemyType.Boss);
        public static Enemy anavataptaWarmech = new Enemy("Anavatapta Warmech", "m131", null, EnemyType.Boss);
        public static Enemy anavataptaWarmechBarrier = new Enemy("Anavatapta Warmech Barrier", "m131_barrier", anavataptaWarmech, EnemyType.Boss);

        public static Enemy midlight = new Enemy("Midlight Reaper", "m132", null, EnemyType.Boss);
        public static Enemy midlightCharge = new Enemy("Midlight Reaper Charging", "m132_powup", midlight, EnemyType.Boss);

        public static Enemy megrimThrasher = new Enemy("Megrim Thrasher", "m133");

        public static Enemy tiamat = new Enemy("Tiamat Eliminator", "m137", null, EnemyType.Boss);
        public static Enemy tiamat2 = new Enemy("Tiamat Eliminator 2", "m137_x1", tiamat, EnemyType.Boss);

        public static Enemy psicomAerialRecon = new Enemy("PSICOM Aerial Recon", "m139");
        public static Enemy psicomAerialSniper = new Enemy("PSICOM Aerial Sniper", "m140");
        public static Enemy psicomDragoon = new Enemy("PSICOM Dragoon", "m141");

        public static Enemy psicomHuntress = new Enemy("PSICOM Huntress", "m144");
        public static Enemy sanctumInquisitrix = new Enemy("Sanctum Inquisitrix", "m145");

        public static Enemy thexteron = new Enemy("Thexteron", "m150");
        public static Enemy myrmidon = new Enemy("Myrmidon", "m151", null, EnemyType.Rare);
        public static Enemy myrmidonHanging = new Enemy("Myrmidon Hanging Edge", "m151_hang", myrmidon, EnemyType.Rare);

        public static Enemy viking = new Enemy("Viking", "m152");

        public static Enemy watchdrone = new Enemy("Watchdrone", "m153");

        public static Enemy proudclad2 = new Enemy("Proudclad 2", "m154", null, EnemyType.Boss);
        public static Enemy proudclad1 = new Enemy("Proudclad 1", "m154_ez", null, EnemyType.Boss);
        public static Enemy proudclad1Phase2 = new Enemy("Proudclad 1 Phase 1?", "m154_ez_pw", proudclad1, EnemyType.Boss);
        public static Enemy proudclad2Phase2 = new Enemy("Proudclad 2 Phase 2?", "m154_pw", proudclad2, EnemyType.Boss);
        public static Enemy proudclad2Phase3 = new Enemy("Proudclad 2 Phase 3?", "m154_x1", proudclad2, EnemyType.Boss);
        public static Enemy proudclad2Phase4 = new Enemy("Proudclad 2 Phase 4?", "m154_x1_pw", proudclad2, EnemyType.Boss);

        public static Enemy corpsTranquifex = new Enemy("Corps Tranquifex", "m155");
        public static Enemy corpsPacfiex = new Enemy("Corps Pacifex", "m156");
        public static Enemy corpsGunner = new Enemy("Corps Gunner", "m157");
        public static Enemy corpsRegular = new Enemy("Corps Regular", "m158");
        public static Enemy corpsDefender = new Enemy("Corps Defender", "m159");
        public static Enemy corpsSteward = new Enemy("Corps Steward", "m160");

        public static Enemy psicomScavenger = new Enemy("PSICOM Scavenger", "m161");
        public static Enemy psicomTracker = new Enemy("PSICOM Tracker", "m162");
        public static Enemy psicomTracker2 = new Enemy("PSICOM Tracker 2", "m162_zo", psicomTracker);
        public static Enemy psicomEnforcer = new Enemy("PSICOM Enforcer", "m163");
        public static Enemy psicomEnforcer2 = new Enemy("PSICOM Enforcer 2", "m163_bhg");
        public static Enemy psicomRaider = new Enemy("PSICOM Raider", "m164");
        public static Enemy psicomRaider2 = new Enemy("PSICOM Raider 2", "m164_guard");

        public static Enemy sanctumSeraph = new Enemy("Sanctum Seraph", "m165");

        public static Enemy psicomMarauder = new Enemy("PSICOM Marauder", "m166",null, EnemyType.Rare);
        public static Enemy psicomWarlord = new Enemy("PSICOM Warlord", "m167",null, EnemyType.Rare);
        public static Enemy psicomReaver = new Enemy("PSICOM Reaver", "m168",null, EnemyType.Rare);

        public static Enemy sanctumTemplar = new Enemy("Sanctum Templar", "m169",null, EnemyType.Rare);

        public static Enemy phosphoricOoze = new Enemy("Phosphoric Ooze", "m172");
        public static Enemy alchemicOoze = new Enemy("Alchemic Ooze", "m172l",null, EnemyType.Rare);
        public static Enemy alchemicOoze2 = new Enemy("Alchemic Ooze 2", "m172m", alchemicOoze, EnemyType.Rare);

        public static Enemy garchimacera = new Enemy("Garchimacera", "m173");
        public static Enemy rangda = new Enemy("Rangda", "m174");

        public static Enemy amphisbaena = new Enemy("Amphisbaena", "m175");

        public static Enemy behemothKing = new Enemy("Behemoth King", "m176");
        public static Enemy behemothKingStand = new Enemy("Behemoth King Standing", "m176_x1", behemothKing);

        public static Enemy berserker = new Enemy("Berserker", "m177",null, EnemyType.Rare);
        public static Enemy tyrant = new Enemy("Tyrant", "m178");
        public static Enemy immortal = new Enemy("Immortal", "m179",null, EnemyType.Rare);

        public static Enemy boxedPhalanx = new Enemy("Boxed Phalanx", "m180");

        public static Enemy hoplite = new Enemy("Hoplite", "m182");

        public static Enemy stikini = new Enemy("Stikini", "m183");
        public static Enemy succubus = new Enemy("Succubus", "m184");
        public static Enemy yakshini = new Enemy("Yakshini", "m185");

        public static Enemy adamantoise = new Enemy("Adamantoise", "m186",null, EnemyType.Rare);
        public static Enemy adamantoiseDown = new Enemy("Adamantoise Down", "m186_x1", adamantoise, EnemyType.Rare);

        public static Enemy adamantortoise = new Enemy("Adamantortoise", "m186a",null, EnemyType.Rare);
        public static Enemy adamantortoiseDown = new Enemy("Adamantortoise Down", "m186a_x1", adamantortoise, EnemyType.Rare);

        public static Enemy adamantortoiseLeft = new Enemy("Adamantortoise Left Foreleg", "m186alleg");
        public static Enemy adamantortoiseRight = new Enemy("Adamantortoise Right Foreleg", "m186arleg");
        public static Enemy adamantoiseLeft = new Enemy("Adamantoise Left Foreleg", "m186lleg");
        public static Enemy adamantoiseRight = new Enemy("Adamantortoise Right Foreleg", "m186rleg");

        public static Enemy adamanchelid = new Enemy("Adamanchelid", "m187",null, EnemyType.Rare);

        public static Enemy ochu = new Enemy("Ochu", "m189",null, EnemyType.Rare);
        public static Enemy microchu = new Enemy("Microchu", "m190");

        public static Enemy bituitus = new Enemy("Bituitus", "m191",null, EnemyType.Rare);

        public static Enemy chonchon = new Enemy("Chonchon", "m192");

        public static Enemy seeker = new Enemy("Seeker", "m193");

        public static Enemy ghoul = new Enemy("Ghoul", "m194");

        public static Enemy geiseric = new Enemy("Geiseric", "m195",null, EnemyType.Rare);
        public static Enemy geisericFist = new Enemy("Geiseric's Fist", "m195_hand");

        public static Enemy attacus = new Enemy("Attacus", "m197",null, EnemyType.Rare);

        public static Enemy vetala = new Enemy("Vetala", "m199");
        public static Enemy vetalaBarrier = new Enemy("Vetala Barrier", "m199_guard", vetala);

        public static Enemy verci1 = new Enemy("Vercingetorix 1", "m201",null, EnemyType.Rare);
        public static Enemy verci2 = new Enemy("Vercingetorix 2", "m201_4w", verci1, EnemyType.Rare);
        public static Enemy verci3 = new Enemy("Vercingetorix 3", "m201_6w", verci1, EnemyType.Rare);
        public static Enemy verci4 = new Enemy("Vercingetorix 4", "m201_8w", verci1, EnemyType.Rare);
        public static Enemy verci5 = new Enemy("Vercingetorix 5", "m201_invi", verci1, EnemyType.Rare);
        public static Enemy verci6 = new Enemy("Vercingetorix 6", "m201_invi_4w", verci1, EnemyType.Rare);
        public static Enemy verci7 = new Enemy("Vercingetorix 7", "m201_invi_6w", verci1, EnemyType.Rare);
        public static Enemy verci8 = new Enemy("Vercingetorix 8", "m201_invi_8w", verci1, EnemyType.Rare);

        public static Enemy anima = new Enemy("Anima", "m203", null, EnemyType.Boss);

        public static Enemy deckdrone = new Enemy("Deckdrone", "m205");

        public static Enemy ahriman = new Enemy("Ahriman", "m206",null, EnemyType.Rare);

        public static Enemy pulseworkCenturion = new Enemy("Pulsework Centurion", "m207");
        public static Enemy pulseworkCenturionStagger = new Enemy("Pulsework Centurion Staggered", "m207_x4", pulseworkCenturion);

        public static Enemy dahaka1 = new Enemy("Dahaka 1", "m210", null, EnemyType.Boss);
        public static Enemy dahaka2 = new Enemy("Dahaka 2", "m210_f", dahaka1, EnemyType.Boss);
        public static Enemy dahaka3 = new Enemy("Dahaka 3", "m210_i", dahaka1, EnemyType.Boss);
        public static Enemy dahaka4 = new Enemy("Dahaka 4", "m210_x1", dahaka1, EnemyType.Boss);
        public static Enemy dahaka5 = new Enemy("Dahaka 5", "m210_z", dahaka1, EnemyType.Boss);

        public static Enemy zwergMetrodroid = new Enemy("Zwerg Metrodroid", "m211");

        public static Enemy megistotherian = new Enemy("Megistotherian", "m212");

        public static Enemy svarog = new Enemy("Svarog", "m213");

        public static Enemy circuitron = new Enemy("Circuitron", "m214");
        public static Enemy cryohedron = new Enemy("Cryohedron", "m215");

        public static Enemy juggernaut = new Enemy("Juggernaut", "m216");

        public static Enemy syphax = new Enemy("Syphax", "m222",null, EnemyType.Rare);

        public static Enemy animaManip1 = new Enemy("Anima Maniuplator L/R?", "m223");
        public static Enemy animaManip2 = new Enemy("Anima Maniuplator L/R?", "m224");

        public static Enemy psicomBombardier = new Enemy("PSICOM Bombardier", "m229");
        public static Enemy psicomDestroyer = new Enemy("PSICOM Destroyer", "m230");

        public static Enemy sanctumCelebrant = new Enemy("Sanctum Celebrant", "m231");

        public static Enemy cid = new Enemy("Cid Raines", "m232", null, EnemyType.Boss);
        public static Enemy cidCOM = new Enemy("Cid Raines COM", "m232_atk", cid, EnemyType.Boss);
        public static Enemy cidSEN = new Enemy("Cid Raines SEN", "m232_def", cid, EnemyType.Boss);
        public static Enemy cid2 = new Enemy("Cid Raines 2", "m232_full", cid, EnemyType.Boss);
        public static Enemy cidMED = new Enemy("Cid Raines MED", "m232_hlr", cid, EnemyType.Boss);

        public static Enemy enlil = new Enemy("Enlil", "m233", null, EnemyType.Boss);
        public static Enemy enlil2 = new Enemy("Enlil 2", "m233_a", enlil, EnemyType.Boss);

        public static Enemy enki = new Enemy("Enki", "m234", null, EnemyType.Boss);
        public static Enemy enki2 = new Enemy("Enki 2", "m234_a", enki, EnemyType.Boss);

        public static Enemy bandersnatch = new Enemy("Bandersnatch", "m235", null, EnemyType.Rare);
        public static Enemy jabberwocky = new Enemy("Jabberwocky", "m236", null, EnemyType.Rare);

        public static Enemy numidia = new Enemy("Numidia", "m241");

        public static Enemy wladislaus = new Enemy("Wladislaus", "m242");

        public static Enemy lodestarBehemoth = new Enemy("Lodestar Behemoth", "m243",null, EnemyType.Rare);
        public static Enemy lodestarBehemothStand = new Enemy("Lodestar Behemoth Standing", "m243_x1", lodestarBehemoth, EnemyType.Rare);

        public static Enemy sacrifice = new Enemy("Sacrifice", "m250");

        public static Enemy cactuar = new Enemy("Cactuar", "m253");
        public static Enemy cactuarPrime = new Enemy("Cactuar Prime", "m253_l",null, EnemyType.Rare);
        public static Enemy cactuarGiant = new Enemy("Giant Cactuar", "m253_m");

        public static Enemy tonberry1 = new Enemy("Tonberry 1", "m254",null,EnemyType.Rare);
        public static Enemy tonberry2 = new Enemy("Tonberry 2", "m254_x1", tonberry1,EnemyType.Rare);
        public static Enemy tonberry3 = new Enemy("Tonberry 3", "m254_x2", tonberry1, EnemyType.Rare);
        public static Enemy tonberry4 = new Enemy("Tonberry 4", "m254_x3", tonberry1, EnemyType.Rare);
        public static Enemy tonberry5 = new Enemy("Tonberry 5", "m254_x4", tonberry1, EnemyType.Rare);

        public static Enemy floweringCactuar = new Enemy("Flowering Cactuar", "m256");

        public static Enemy gigantuar = new Enemy("Gigantuar", "m257",null, EnemyType.Rare);

        public static Enemy crusader = new Enemy("Crusader", "m260",null, EnemyType.Rare);

        public static Enemy psicomExecutioner = new Enemy("PSICOM Executioner", "m261",null, EnemyType.Rare);

        public static Enemy bart1 = new Enemy("Barthandelus 1 Phase 1", "m300", null, EnemyType.Boss);
        public static Enemy bart1Phase2 = new Enemy("Barthandelus 1 Phase 2", "m300_hard", bart1, EnemyType.Boss);
        public static Enemy bart1Face1 = new Enemy("Barthandelus 1 Face 1", "m301");
        public static Enemy bart1Face2 = new Enemy("Barthandelus 1 Face 2", "m302");
        public static Enemy bart1Face3 = new Enemy("Barthandelus 1 Face 3", "m303");
        public static Enemy bart1Face4 = new Enemy("Barthandelus 1 Face 4", "m304");

        public static Enemy bart2 = new Enemy("Barthandelus 2", "m310", null, EnemyType.Boss);
        public static Enemy bart2Phase2 = new Enemy("Barthandelus 2 Phase 2", "m310_s1", bart2, EnemyType.Boss);

        public static Enemy bart3 = new Enemy("Barthandelus 3", "m320", null, EnemyType.Boss);

        public static Enemy orphan1 = new Enemy("Orphan 1", "m350", null, EnemyType.Boss);
        public static Enemy orphan1Phase2 = new Enemy("Orphan 1 Phase 2", "m350_father", orphan1, EnemyType.Boss);

        public static Enemy orphan2 = new Enemy("Orphan 2", "m360", null, EnemyType.Boss);
        public static Enemy orphan2Stagger = new Enemy("Orphan 2 Staggered", "m360_brk", orphan2, EnemyType.Boss);

        public static Enemy uridimmu = new Enemy("Uridimmu", "m400");

        public static Enemy adroa = new Enemy("Adroa", "m401");

        public static Enemy pulseworkChampion = new Enemy("Pulsework Champion", "m402",null, EnemyType.Rare);
        public static Enemy pulseworkChampionStagger = new Enemy("Pulsework Champion Staggered", "m402_x3", pulseworkChampion, EnemyType.Rare);

        public static Enemy amam = new Enemy("Amam", "m403");

        public static Enemy rakshasa = new Enemy("Rakshasa", "m404",null, EnemyType.Rare);

        public static Enemy neochu = new Enemy("Neochu", "m405", null, EnemyType.Rare);

        public static Enemy gurangatch = new Enemy("Gurangatch", "m406",null, EnemyType.Rare);
        public static Enemy gurangatchStagger = new Enemy("Gurangatch Staggered", "m406_break", gurangatch, EnemyType.Rare);

        public static Enemy kaiserBehemoth = new Enemy("Kaiser Behemoth", "m407",null, EnemyType.Rare);
        public static Enemy kaiserBehemothStand = new Enemy("Kaiser Behemoth Standing", "m407_x1", kaiserBehemoth, EnemyType.Rare);

        public static Enemy zirnitra = new Enemy("Zirnitra", "m408",null, EnemyType.Rare);

        public static Enemy verdelet = new Enemy("Verdelet", "m409");

        public static Enemy edimmu = new Enemy("Edimmu", "m410",null, EnemyType.Rare);

        public static Enemy mithridates = new Enemy("Mithridates", "m411",null, EnemyType.Rare);

        public static Enemy rafflesia = new Enemy("Rafflesia", "m412");

        public static Enemy mushussu = new Enemy("Mushussu", "m413");

        public static Enemy raktavija = new Enemy("Raktavija", "m414", null, EnemyType.Rare);
        public static Enemy raktavijaBarrier = new Enemy("Raktavija Barrier", "m414_guard", raktavija, EnemyType.Rare);

        public static Enemy humbaba = new Enemy("Humbaba", "m415");
        public static Enemy humbabaStand = new Enemy("Humbaba Standing", "m415_x1", humbaba);

        public static Enemy amblingBellows = new Enemy("Ambling Bellows", "m416");

        public static Enemy ugallu = new Enemy("Ugallu", "m417", null, EnemyType.Rare);

        public static Enemy penangallan = new Enemy("Penanggalan", "m418",null, EnemyType.Rare);

        public static Enemy ectopudding = new Enemy("Ectopudding", "m419",null, EnemyType.Rare);
        public static Enemy gelatitan = new Enemy("Gelatitan", "m420",null, EnemyType.Rare);

        public static Enemy shaolongGui = new Enemy("Shaolong Gui", "m421", null, EnemyType.Rare);

        public static Enemy longGui = new Enemy("Long Gui", "m422", null, EnemyType.Rare);
        public static Enemy longGuiDown = new Enemy("Long Gui Down", "m422_x1", longGui, EnemyType.Rare);
        public static Enemy longGuiLeft = new Enemy("Long Gui Left Foreleg", "m422lleg");
        public static Enemy longGuiRight = new Enemy("Long Gui Right Foreleg", "m422rleg");

        public static Enemy picochu = new Enemy("Picochu", "m423");

        public static Enemy cryptos = new Enemy("Cryptos", "m424");

        public static Enemy odin = new Enemy("Odin", "s151");
        public static Enemy stiria = new Enemy("Stiria", "s251");
        public static Enemy nix = new Enemy("Nix", "s253");
        public static Enemy brynhildr = new Enemy("Brynhildr", "s351");
        public static Enemy alexander = new Enemy("Alexander", "s451");
        public static Enemy hecatoncheir = new Enemy("Hecatoncheir", "s551");
        public static Enemy bahamut = new Enemy("Bahamut", "s651");

        public static Enemy targetingBeacon1 = new Enemy("Targeting Beacon 1", "w633_2");
        public static Enemy targetingBeacon2 = new Enemy("Targeting Beacon 2", "w633_5");

        public static Enemy berserkerCenturionBlade = new Enemy("Berserker's Centurion Blade", "w661");
        public static Enemy tyrantCenturionBlade = new Enemy("Tyrant's Centurion Blade", "w662");
        public static Enemy immortalCenturionBlade = new Enemy("Immortal's Centurion Blade", "w663");
    }
}
