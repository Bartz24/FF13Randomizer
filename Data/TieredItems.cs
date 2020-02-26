﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FF13Data
{
    public class TieredItems
    {
        public static TieredManager<Item> manager = new TieredManager<Item>();

        public static Tiered<Item> Gil = new Tiered<Item>
            (0, Items.Gil, 15, 100000, 2.7f)
            .Register(manager);

        #region Consumables

        public static Tiered<Item> HealingItem = new Tiered<Item>
            (8, Items.Potion, 20, 99, 0.85f)
            .Add(15, Items.PhoenixDown)
            .Add(100, Items.Elixir)
            .Register(manager);

        public static Tiered<Item> Antidote = new Tiered<Item>
            (12, Items.Antidote, 1, 99, 0.45f)
            .Register(manager);

        public static Tiered<Item> HolyWater = new Tiered<Item>
            (12, Items.HolyWater, 1, 99, 0.45f)
            .Register(manager);

        public static Tiered<Item> Painkiller = new Tiered<Item>
            (12, Items.Painkiller, 1, 99, 0.45f)
            .Register(manager);

        public static Tiered<Item> FoulLiquid = new Tiered<Item>
            (12, Items.FoulLiquid, 1, 99, 0.45f)
            .Register(manager);

        public static Tiered<Item> Wax = new Tiered<Item>
            (12, Items.Wax, 1, 99, 0.45f)
            .Register(manager);

        public static Tiered<Item> Mallet = new Tiered<Item>
            (12, Items.Mallet, 1, 99, 0.45f)
            .Register(manager);

        public static Tiered<Item> Ethersol = new Tiered<Item>
            (60, Items.Ethersol, 15)
            .Register(manager);

        public static Tiered<Item> Fortisol = new Tiered<Item>
            (50, Items.Fortisol, 15)
            .Register(manager);

        public static Tiered<Item> Aegisol = new Tiered<Item>
            (50, Items.Aegisol, 15)
            .Register(manager);

        public static Tiered<Item> Deceptisol = new Tiered<Item>
            (30, Items.Deceptisol, 15)
            .Register(manager);


        public static Tiered<Item> Librascope = new Tiered<Item>
            (25, Items.Librascope, 10, 99,0.6f)
            .Register(manager);
        #endregion

        #region Accessories

        public static Tiered<Item> Bangle = new Tiered<Item>
            (10, Items.IronBangle, 10)
            .Add(15, Items.SilverBangle)
            .Add(20, Items.TungstenBangle)
            .Add(28, Items.TitaniumBangle)
            .Add(36, Items.GoldBangle)
            .Add(45, Items.MythrilBangle)
            .Add(57, Items.PlatinumBangle)
            .Add(70, Items.DiamondBangle)
            .Add(85, Items.AdamantBangle)
            .Add(100, Items.WurtziteBangle)
            .Register(manager);

        public static Tiered<Item> Wristband = new Tiered<Item>
            (12, Items.PowerWristband, 8)
            .Add(20, Items.BrawlersWristband)
            .Add(35, Items.WarriorsWristband)
            .Add(66, Items.PowerGlove)
            .Add(94, Items.KaiserKnuckles)
            .Register(manager);

        public static Tiered<Item> Mark = new Tiered<Item>
            (12, Items.MagiciansMark, 8)
            .Add(20, Items.ShamansMark)
            .Add(35, Items.SorcerersMark)
            .Add(66, Items.WeirdingGlyph)
            .Add(94, Items.MagistralCrest)
            .Register(manager);

        public static Tiered<Item> Belt = new Tiered<Item>
            (16, Items.BlackBelt, 5)
            .Add(30, Items.GeneralsBelt)
            .Add(65, Items.ChampionsBelt)
            .Register(manager);

        public static Tiered<Item> Bracelet = new Tiered<Item>
            (16, Items.RuneBracelet, 5)
            .Add(30, Items.WitchsBracelet)
            .Add(65, Items.MagussBracelet)
            .Register(manager);

        public static Tiered<Item> Armlet = new Tiered<Item>
            (40, Items.RoyalArmlet, 5)
            .Add(70, Items.ImperialArmlet)
            .Register(manager);

        public static Tiered<Item> FireRing = new Tiered<Item>
            (10, Items.FlamebaneBrooch, 5)
            .Add(15, Items.EmberRing)
            .Add(28, Items.BlazeRing)
            .Add(36, Items.FlameshieldEarring)
            .Add(48, Items.FireCharm)
            .Add(52, Items.SalamandrineRing)
            .Add(74, Items.TwentySidedDie)
            .Register(manager);

        public static Tiered<Item> IceRing = new Tiered<Item>
            (10, Items.FrostbaneBrooch, 5)
            .Add(15, Items.FrostRing)
            .Add(28, Items.IcicleRing)
            .Add(36, Items.FrostshieldEarring)
            .Add(48, Items.IceCharm)
            .Add(52, Items.BorealRing)
            .Add(74, Items.TwentySidedDie)
            .Register(manager);

        public static Tiered<Item> ThunderRing = new Tiered<Item>
            (10, Items.SparkbaneBrooch, 5)
            .Add(15, Items.SparkRing)
            .Add(28, Items.FulmenRing)
            .Add(36, Items.SparkshieldEarring)
            .Add(48, Items.LightningCharm)
            .Add(52, Items.RaijinRing)
            .Add(74, Items.TwentySidedDie)
            .Register(manager);

        public static Tiered<Item> WaterRing = new Tiered<Item>
            (10, Items.AquabaneBrooch, 5)
            .Add(15, Items.AquaRing)
            .Add(28, Items.RiptideRing)
            .Add(36, Items.AquashieldEarring)
            .Add(48, Items.WaterCharm)
            .Add(52, Items.NereidRing)
            .Add(74, Items.TwentySidedDie)
            .Register(manager);

        public static Tiered<Item> WindRing = new Tiered<Item>
            (15, Items.ZephyrRing, 5)
            .Add(28, Items.GaleRing)
            .Add(52, Items.SylphidRing)
            .Register(manager);

        public static Tiered<Item> EarthRing = new Tiered<Item>
            (15, Items.ClayRing, 5)
            .Add(28, Items.StilstoneRing)
            .Add(52, Items.GaianRing)
            .Register(manager);


        public static Tiered<Item> EntiteRing = new Tiered<Item>
            (80, Items.EntiteRing, 3)
            .Register(manager);

        public static Tiered<Item> Glove = new Tiered<Item>
            (18, Items.GiantsGlove, 5)
            .Add(40, Items.WarlocksGlove)
            .Register(manager);

        public static Tiered<Item> Buckle = new Tiered<Item>
            (18, Items.GlassBuckle, 5)
            .Add(40, Items.TektiteBuckle)
            .Register(manager);

        public static Tiered<Item> Armband = new Tiered<Item>
            (18, Items.MetalArmband, 5)
            .Add(40, Items.CeramicArmband)
            .Register(manager);

        public static Tiered<Item> Sachet = new Tiered<Item>
            (18, Items.SerenitySachet, 5)
            .Add(40, Items.SafeguardSachet)
            .Register(manager);

        public static Tiered<Item> Orb = new Tiered<Item>
            (18, Items.GlassOrb, 5)
            .Add(40, Items.DragonflyOrb)
            .Register(manager);

        public static Tiered<Item> Pendant = new Tiered<Item>
            (18, Items.StarPendant, 5)
            .Add(40, Items.StarfallPendant)
            .Register(manager);

        public static Tiered<Item> Necklace = new Tiered<Item>
            (18, Items.PearlNecklace, 5)
            .Add(40, Items.GemstoneNecklace)
            .Register(manager);

        public static Tiered<Item> Talisman = new Tiered<Item>
            (18, Items.WardingTalisman, 5)
            .Add(40, Items.HexbaneTalisman)
            .Register(manager);

        public static Tiered<Item> Dampener = new Tiered<Item>
            (18, Items.PainDampener, 5)
            .Add(40, Items.PainDeflector)
            .Register(manager);

        public static Tiered<Item> Cape = new Tiered<Item>
            (18, Items.WhiteCape, 5)
            .Add(40, Items.EffulgentCape)
            .Register(manager);

        public static Tiered<Item> Anklet = new Tiered<Item>
            (18, Items.RainbowAnklet, 5)
            .Add(40, Items.MoonbowAnklet)
            .Register(manager);

        public static Tiered<Item> Crown = new Tiered<Item>
            (18, Items.CherubsCrown, 5)
            .Add(40, Items.SeraphsCrown)
            .Register(manager);

        public static Tiered<Item> Ribbon = new Tiered<Item>
            (45, Items.Ribbon, 5)
            .Add(90, Items.SuperRibbon)
            .Register(manager);

        public static Tiered<Item> ProtectAmulet = new Tiered<Item>
            (8, Items.GuardianAmulet, 5)
            .Add(36, Items.ShieldTalisman)
            .Register(manager);

        public static Tiered<Item> ShellAmulet = new Tiered<Item>
            (8, Items.AuricAmulet, 5)
            .Add(36, Items.SoulfontTalisman)
            .Register(manager);

        public static Tiered<Item> VeilAmulet = new Tiered<Item>
            (8, Items.WatchmansAmulet, 5)
            .Add(36, Items.ShroudingTalisman)
            .Register(manager);

        public static Tiered<Item> BraveryAmulet = new Tiered<Item>
            (8, Items.HerosAmulet, 5)
            .Add(36, Items.MoraleTalisman)
            .Register(manager);

        public static Tiered<Item> FaithAmulet = new Tiered<Item>
            (8, Items.SaintsAmulet, 5)
            .Add(36, Items.BlessedTalisman)
            .Register(manager);

        public static Tiered<Item> VigilanceAmulet = new Tiered<Item>
            (8, Items.ZealotAmulet, 5)
            .Add(36, Items.BattleTalisman)
            .Register(manager);

        public static Tiered<Item> HasteShoes = new Tiered<Item>
            (20, Items.HermesSandals, 5)
            .Add(50, Items.SprintShoes)
            .Register(manager);

        public static Tiered<Item> Tetradic = new Tiered<Item>
            (40, Items.TetradicCrown, 5)
            .Add(65, Items.TetradicTiara)
            .Register(manager);

        public static Tiered<Item> ScarfBoots = new Tiered<Item>
            (18, Items.WhistlewindScarf, 5)
            .Add(30, Items.NimbletoeBoots)
            .Add(48, Items.AuroraScarf)
            .Register(manager);

        public static Tiered<Item> Catalog = new Tiered<Item>
            (20, Items.SurvivalistCatalog, 3)
            .Add(45, Items.CollectorCatalog)
            .Add(78, Items.ConnoisseurCatalog)
            .Register(manager);

        public static Tiered<Item> KillSash = new Tiered<Item>
            (20, Items.HuntersFriend, 3)
            .Add(32, Items.SpeedSash)
            .Add(40, Items.EnergySash)
            .Register(manager);

        public static Tiered<Item> DoctorsCode = new Tiered<Item>
            (40, Items.DoctorsCode, 15)
            .Register(manager);

        public static Tiered<Item> WatchBadge = new Tiered<Item>
            (42, Items.GoldWatch, 3)
            .Add(70, Items.ChampionsBadge)
            .Register(manager);

        public static Tiered<Item> GenjiGlove = new Tiered<Item>
            (80, Items.GenjiGlove, 3)
            .Register(manager);

        public static Tiered<Item> GrowthEgg = new Tiered<Item>
            (80, Items.GrowthEgg, 3)
            .Register(manager);

        public static Tiered<Item> GoddesssFavor = new Tiered<Item>
            (74, Items.GoddesssFavor, 5)
            .Register(manager);

        #endregion

        #region Components

        public static Tiered<Item> Claw = new Tiered<Item>
            (0, Items.BegrimedClaw, 1, 99, 1.2f)
            .Add(20, Items.BestialClaw)
            .Add(45, Items.GargantuanClaw)
            .Add(88, Items.HellishTalon)
            .Register(manager);

        public static Tiered<Item> Bone = new Tiered<Item>
            (0, Items.ShatteredBone, 1, 99, 1.2f)
            .Add(20, Items.SturdyBone)
            .Add(45, Items.OtherworldlyBone)
            .Add(88, Items.AncientBone)
            .Register(manager);

        public static Tiered<Item> Scale = new Tiered<Item>
            (0, Items.MoistenedScale, 1, 99, 1.2f)
            .Add(20, Items.SeapetalScale)
            .Add(45, Items.AbyssalScale)
            .Add(88, Items.SeakingsBeard)
            .Register(manager);

        public static Tiered<Item> Carapace = new Tiered<Item>
            (0, Items.SegmentedCarapace, 1, 99, 1.2f)
            .Add(20, Items.IronShell)
            .Add(45, Items.ArmoredShell)
            .Add(88, Items.RegeneratingCarapace)
            .Register(manager);

        public static Tiered<Item> Fang = new Tiered<Item>
            (0, Items.ChippedFang, 1, 99, 1.2f)
            .Add(20, Items.WickedFang)
            .Add(45, Items.MonstrousFang)
            .Add(88, Items.SinisterFang)
            .Register(manager);

        public static Tiered<Item> Wing = new Tiered<Item>
            (0, Items.SeveredWing, 1, 99, 1.2f)
            .Add(20, Items.ScaledWing)
            .Add(45, Items.AbominableWing)
            .Add(88, Items.MenacingWings)
            .Register(manager);

        public static Tiered<Item> Tail = new Tiered<Item>
            (0, Items.MoltedTail, 1, 99, 1.2f)
            .Add(20, Items.BarbedTail)
            .Add(45, Items.DiabolicTail)
            .Add(88, Items.EntrancingTail)
            .Register(manager);

        public static Tiered<Item> Leather = new Tiered<Item>
            (0, Items.TornLeather, 1, 99, 1.2f)
            .Add(20, Items.ThickenedHide)
            .Add(45, Items.SmoothHide)
            .Add(88, Items.SuppleLeather)
            .Register(manager);

        public static Tiered<Item> Oil = new Tiered<Item>
            (0, Items.GummyOil, 1, 99, 1.2f)
            .Add(20, Items.FragrantOil)
            .Add(45, Items.MedicinalOil)
            .Add(88, Items.EsotericOil)
            .Register(manager);

        public static Tiered<Item> Wool = new Tiered<Item>
            (0, Items.ScragglyWool, 1, 99, 1.2f)
            .Add(20, Items.RoughWool)
            .Add(45, Items.ThickWool)
            .Add(88, Items.FluffyWool)
            .Register(manager);

        public static Tiered<Item> Ooze = new Tiered<Item>
            (0, Items.MurkyOoze, 1, 99, 1.2f)
            .Add(20, Items.VibrantOoze)
            .Add(45, Items.TransparentOoze)
            .Add(88, Items.WonderGel)
            .Register(manager);

        public static Tiered<Item> Horn = new Tiered<Item>
            (0, Items.FracturedHorn, 1, 99, 1.2f)
            .Add(20, Items.SpinedHorn)
            .Add(45, Items.FiendishHorn)
            .Add(88, Items.InfernalHorn)
            .Register(manager);

        public static Tiered<Item> Fluid = new Tiered<Item>
            (0, Items.StrangeFluid, 1, 99, 1.2f)
            .Add(20, Items.EnigmaticFluid)
            .Add(45, Items.MysteriousFluid)
            .Add(88, Items.IneffableFluid)
            .Register(manager);

        public static Tiered<Item> Tear = new Tiered<Item>
            (0, Items.CiethTear, 1, 99, 1.2f)
            .Add(20, Items.TearOfFrustration)
            .Add(45, Items.TearOfRemorse)
            .Add(88, Items.TearOfWoe)
            .Register(manager);

        public static Tiered<Item> Mycelium = new Tiered<Item>
            (0, Items.RedMycelium, 1, 99, 1.2f)
            .Add(20, Items.BlueMycelium)
            .Add(45, Items.WhiteMycelium)
            .Add(88, Items.BlackMycelium)
            .Register(manager);

        public static Tiered<Item> Dew = new Tiered<Item>
            (0, Items.DawnlightDew, 1, 99, 1.2f)
            .Add(20, Items.DusklightDew)
            .Add(34, Items.Gloomstalk)
            .Add(58, Items.Sunpetal)
            .Register(manager);

        public static Tiered<Item> Seed = new Tiered<Item>
            (46, Items.MoonblossomSeed, 1, 99, 1.2f)
            .Add(70, Items.StarblossomSeed)
            .Register(manager);

        public static Tiered<Item> Chocobo = new Tiered<Item>
            (0, Items.ChocoboPlume, 1, 99, 1.2f)
            .Add(20, Items.ChocoboTailFeather)
            .Register(manager);

        public static Tiered<Item> Fruit = new Tiered<Item>
            (32, Items.SucculentFruit, 1, 99, 1.2f)
            .Add(58, Items.MalodorousFruit)
            .Register(manager);

        public static Tiered<Item> NeedlePerfume = new Tiered<Item>
            (46, Items.GreenNeedle, 1, 99, 1.2f)
            .Add(65, Items.Perfume)
            .Register(manager);

        public static Tiered<Item> Cable = new Tiered<Item>
            (10, Items.InsulatedCabling, 1, 99, 1.2f)
            .Add(28, Items.FibreOpticCable)
            .Register(manager);

        public static Tiered<Item> Lens = new Tiered<Item>
            (10, Items.LiquidCrystalLens, 1, 99, 1.2f)
            .Add(28, Items.RingJoint)
            .Register(manager);

        public static Tiered<Item> Gear = new Tiered<Item>
            (10, Items.EpicyclicGear, 1, 99, 1.2f)
            .Add(28, Items.Crankshaft)
            .Register(manager);

        public static Tiered<Item> CapacitorFly = new Tiered<Item>
            (10, Items.ElectrolyticCapacitor, 1, 99, 1.2f)
            .Add(28, Items.Flywheel)
            .Register(manager);

        public static Tiered<Item> SprocketActuator = new Tiered<Item>
            (10, Items.Sprocket, 1, 99, 1.2f)
            .Add(28, Items.Actuator)
            .Register(manager);

        public static Tiered<Item> Plug = new Tiered<Item>
            (10, Items.SparkPlug, 1, 99, 1.2f)
            .Add(28, Items.IridiumPlug)
            .Register(manager);

        public static Tiered<Item> Valve = new Tiered<Item>
            (10, Items.NeedleValve, 1, 99, 1.2f)
            .Add(28, Items.ButterflyValve)
            .Register(manager);

        public static Tiered<Item> Bomb = new Tiered<Item>
            (10, Items.BombAshes, 1, 99, 1.2f)
            .Add(28, Items.BombFragment)
            .Add(48, Items.BombShell)
            .Add(70, Items.BombCore)
            .Register(manager);

        public static Tiered<Item> Circuit = new Tiered<Item>
            (10, Items.AnalogCircuit, 1, 99, 1.2f)
            .Add(28, Items.DigitalCircuit)
            .Add(48, Items.Gyroscope)
            .Add(70, Items.Electrode)
            .Register(manager);

        public static Tiered<Item> Armor = new Tiered<Item>
            (48, Items.CeramicArmor, 1, 99, 1.2f)
            .Add(70, Items.ChobhamArmor)
            .Register(manager);

        public static Tiered<Item> Bearing = new Tiered<Item>
            (28, Items.RadialBearing, 1, 99, 1.2f)
            .Add(42, Items.ThrustBearing)
            .Add(48, Items.Solenoid)
            .Add(70, Items.MobiusCoil)
            .Register(manager);

        public static Tiered<Item> Tube = new Tiered<Item>
            (48, Items.TungstenTube, 1, 99, 1.2f)
            .Add(70, Items.TitaniumTube)
            .Register(manager);

        public static Tiered<Item> Detector = new Tiered<Item>
            (48, Items.PassiveDetector, 1, 99, 1.2f)
            .Add(70, Items.ActiveDetector)
            .Register(manager);

        public static Tiered<Item> Transformer = new Tiered<Item>
            (10, Items.Transformer, 1, 99, 1.2f)
            .Add(28, Items.Amplifier)
            .Add(48, Items.Carburetor)
            .Add(70, Items.Supercharger)
            .Register(manager);

        public static Tiered<Item> ElementOscillator = new Tiered<Item>
            (48, Items.PiezoelectricElement, 1, 99, 1.2f)
            .Add(70, Items.CrystalOscillator)
            .Register(manager);

        public static Tiered<Item> MachineOil = new Tiered<Item>
            (10, Items.ParaffinOil, 1, 99, 1.2f)
            .Add(28, Items.SiliconeOil)
            .Add(48, Items.SyntheticMuscle)
            .Add(70, Items.Turboprop)
            .Register(manager);

        public static Tiered<Item> Turbojet = new Tiered<Item>
            (48, Items.Turbojet, 1, 99, 1.2f)
            .Add(70, Items.TeslaTurbine)
            .Register(manager);

        public static Tiered<Item> Conductor = new Tiered<Item>
            (10, Items.PolymerEmulsion, 1, 99, 1.2f)
            .Add(28, Items.FerroelectricFilm)
            .Add(48, Items.Superconductor)
            .Add(70, Items.PerfectConductor)
            .Register(manager);

        public static Tiered<Item> AcceleratorReactor = new Tiered<Item>
            (88, Items.ParticalAccelerator, 1, 99)
            .Add(100, Items.UltracompactReactor)
            .Register(manager);

        public static Tiered<Item> Chip = new Tiered<Item>
            (28, Items.CreditChip, 1, 99, 1.2f)
            .Add(50, Items.IncentiveChip)
            .Register(manager);

        public static Tiered<Item> Doll = new Tiered<Item>
            (60, Items.CactuarDoll, 1, 99, 1.2f)
            .Add(68, Items.MooglePuppet)
            .Add(88, Items.TonberryFigurine)
            .Add(96, Items.PlushChocobo)
            .Register(manager);

        public static Tiered<Item> Catalyst = new Tiered<Item>
            (0, Items.Millerite, 5)
            .Add(12, Items.Rhodochrosite)
            .Add(22, Items.Cobaltite)
            .Add(34, Items.Perovskite)
            .Add(48, Items.Uraninite)
            .Add(58, Items.MnarStone)
            .Add(72, Items.Scarletite)
            .Add(84, Items.Adamantite)
            .Add(92, Items.DarkMatter)
            .Add(120, Items.Trapezohedron)
            .Register(manager);

        public static Tiered<Item> GoldPlatinum = new Tiered<Item>
            (66, Items.GoldDust)
            .Add(84, Items.GoldNugget)
            .Add(110, Items.PlatinumIngot)
            .Register(manager);

        #endregion

        #region Weapons

        public static Tiered<Item> BlazefireSaber = new Tiered<Item>
            (15, Items.BlazefireSaber, 3)
            .Add(60, Items.Flamberge)
            .Add(100, Items.OmegaWeapon1)
            .Register(manager);

        public static Tiered<Item> AxisBlade = new Tiered<Item>
            (30, Items.AxisBlade, 3)
            .Add(86, Items.Enkindler)
            .Add(110, Items.OmegaWeapon2)
            .Register(manager);

        public static Tiered<Item> EdgedCarbine = new Tiered<Item>
            (15, Items.EdgedCarbine, 3)
            .Add(60, Items.RazorCarbine)
            .Add(100, Items.OmegaWeapon3)
            .Register(manager);

        public static Tiered<Item> Lifesaber = new Tiered<Item>
            (24, Items.Lifesaber, 3)
            .Add(72, Items.Peacemaker)
            .Add(108, Items.OmegaWeapon4)
            .Register(manager);

        public static Tiered<Item> Gladius = new Tiered<Item>
            (20, Items.Gladius, 3)
            .Add(68, Items.Helterskelter)
            .Add(105, Items.OmegaWeapon5)
            .Register(manager);

        public static Tiered<Item> Organyx = new Tiered<Item>
            (18, Items.Organyx, 3)
            .Add(64, Items.Apocalypse)
            .Add(102, Items.OmegaWeapon6)
            .Register(manager);

        public static Tiered<Item> Hauteclaire = new Tiered<Item>
            (20, Items.Hauteclaire, 3)
            .Add(68, Items.Durandal)
            .Add(105, Items.OmegaWeapon7)
            .Register(manager);

        public static Tiered<Item> Lionheart = new Tiered<Item>
            (24, Items.Lionheart, 3)
            .Add(72, Items.UltimaWeapon)
            .Add(108, Items.OmegaWeapon8)
            .Register(manager);

        public static Tiered<Item> Vega42s = new Tiered<Item>
            (15, Items.Vega42s, 3)
            .Add(60, Items.Altairs)
            .Add(100, Items.TotalEclipses1)
            .Register(manager);

        public static Tiered<Item> SpicaDefenders = new Tiered<Item>
            (24, Items.SpicaDefenders, 3)
            .Add(72, Items.SiriusSidearms)
            .Add(108, Items.TotalEclipses2)
            .Register(manager);

        public static Tiered<Item> DenebDuellers = new Tiered<Item>
            (15, Items.DenebDuellers, 3)
            .Add(60, Items.CanopusAMPs)
            .Add(100, Items.TotalEclipses3)
            .Register(manager);

        public static Tiered<Item> Rigels = new Tiered<Item>
            (20, Items.Rigels, 3)
            .Add(68, Items.PolarisSpecials)
            .Add(105, Items.TotalEclipses4)
            .Register(manager);

        public static Tiered<Item> Aldebarans = new Tiered<Item>
            (18, Items.Aldebarans, 3)
            .Add(64, Items.Sadalmeliks)
            .Add(102, Items.TotalEclipses5)
            .Register(manager);

        public static Tiered<Item> PleiadesHiPowers = new Tiered<Item>
            (15, Items.PleiadesHiPowers, 3)
            .Add(60, Items.HyadesMagnums)
            .Add(100, Items.TotalEclipses6)
            .Register(manager);

        public static Tiered<Item> AntaresDeluxes = new Tiered<Item>
            (20, Items.AntaresDeluxes, 3)
            .Add(68, Items.FomalhautElites)
            .Add(105, Items.TotalEclipses7)
            .Register(manager);

        public static Tiered<Item> Procyons = new Tiered<Item>
            (36, Items.Procyons, 3)
            .Add(94, Items.BetelgeuseCustoms)
            .Add(116, Items.TotalEclipses8)
            .Register(manager);

        public static Tiered<Item> WildBear = new Tiered<Item>
            (15, Items.WildBear, 3)
            .Add(60, Items.FeralPride)
            .Add(100, Items.SaveTheQueen1)
            .Register(manager);

        public static Tiered<Item> Paladin = new Tiered<Item>
            (24, Items.Paladin, 3)
            .Add(72, Items.WingedSaint)
            .Add(108, Items.SaveTheQueen2)
            .Register(manager);

        public static Tiered<Item> RebelHeart = new Tiered<Item>
            (20, Items.RebelHeart, 3)
            .Add(68, Items.WarriorsEmblem)
            .Add(105, Items.SaveTheQueen3)
            .Register(manager);

        public static Tiered<Item> PowerCircle = new Tiered<Item>
            (24, Items.PowerCircle, 3)
            .Add(72, Items.BattleStandard)
            .Add(108, Items.SaveTheQueen4)
            .Register(manager);

        public static Tiered<Item> Feymark = new Tiered<Item>
            (20, Items.Feymark, 3)
            .Add(68, Items.SoulBlazer)
            .Add(105, Items.SaveTheQueen5)
            .Register(manager);

        public static Tiered<Item> SacrificialCircle = new Tiered<Item>
            (24, Items.SacrificialCircle, 3)
            .Add(72, Items.Indomitus)
            .Add(108, Items.SaveTheQueen6)
            .Register(manager);

        public static Tiered<Item> UnsettingSun = new Tiered<Item>
            (15, Items.UnsettingSun, 3)
            .Add(60, Items.MidnightSun)
            .Add(100, Items.SaveTheQueen7)
            .Register(manager);

        public static Tiered<Item> Umbra = new Tiered<Item>
            (30, Items.Umbra, 3)
            .Add(86, Items.Solaris)
            .Add(110, Items.SaveTheQueen8)
            .Register(manager);

        public static Tiered<Item> Airwing = new Tiered<Item>
            (20, Items.Airwing, 3)
            .Add(68, Items.Skycutter)
            .Add(105, Items.Nue1)
            .Register(manager);

        public static Tiered<Item> Hawkeye = new Tiered<Item>
            (15, Items.Hawkeye, 3)
            .Add(60, Items.Eagletalon)
            .Add(100, Items.Nue2)
            .Register(manager);

        public static Tiered<Item> Otshirvani = new Tiered<Item>
            (24, Items.Otshirvani, 3)
            .Add(72, Items.Urubutsin)
            .Add(108, Items.Nue3)
            .Register(manager);

        public static Tiered<Item> Ninurta = new Tiered<Item>
            (15, Items.Ninurta, 3)
            .Add(60, Items.Jatayu)
            .Add(100, Items.Nue4)
            .Register(manager);

        public static Tiered<Item> Vidofnir = new Tiered<Item>
            (24, Items.Vidofnir, 3)
            .Add(72, Items.Hresvelgr)
            .Add(108, Items.Nue5)
            .Register(manager);

        public static Tiered<Item> Simurgh = new Tiered<Item>
            (20, Items.Simurgh, 3)
            .Add(68, Items.Tezcatlipoca)
            .Add(105, Items.Nue6)
            .Register(manager);

        public static Tiered<Item> Malphas = new Tiered<Item>
            (15, Items.Malphas, 3)
            .Add(60, Items.Naberius)
            .Add(100, Items.Nue7)
            .Register(manager);

        public static Tiered<Item> Alicanto = new Tiered<Item>
            (20, Items.Alicanto, 3)
            .Add(68, Items.Caladrius)
            .Add(105, Items.Nue8)
            .Register(manager);

        public static Tiered<Item> BindingRod = new Tiered<Item>
            (15, Items.BindingRod, 3)
            .Add(60, Items.HuntersRod)
            .Add(100, Items.Nirvana1)
            .Register(manager);

        public static Tiered<Item> Tigerclaw = new Tiered<Item>
            (18, Items.Tigerclaw, 3)
            .Add(64, Items.Wyrmfang)
            .Add(102, Items.Nirvana2)
            .Register(manager);

        public static Tiered<Item> HealersStaff = new Tiered<Item>
            (30, Items.HealersStaff, 3)
            .Add(86, Items.PhysiciansStaff)
            .Add(110, Items.Nirvana3)
            .Register(manager);

        public static Tiered<Item> PearlwingStaff = new Tiered<Item>
            (15, Items.PearlwingStaff, 3)
            .Add(60, Items.BrightwingStaff)
            .Add(100, Items.Nirvana4)
            .Register(manager);

        public static Tiered<Item> RodOfThorns = new Tiered<Item>
            (15, Items.RodOfThorns, 3)
            .Add(60, Items.OrochiRod)
            .Add(100, Items.Nirvana5)
            .Register(manager);

        public static Tiered<Item> Mistilteinn = new Tiered<Item>
            (24, Items.Mistilteinn, 3)
            .Add(72, Items.ErinyesCane)
            .Add(108, Items.Nirvana6)
            .Register(manager);

        public static Tiered<Item> BelladonnaWand = new Tiered<Item>
            (20, Items.BelladonnaWand, 3)
            .Add(68, Items.MalboroWand)
            .Add(105, Items.Nirvana7)
            .Register(manager);

        public static Tiered<Item> HeavenlyAxis = new Tiered<Item>
            (20, Items.HeavenlyAxis, 3)
            .Add(68, Items.Abraxas)
            .Add(105, Items.Nirvana8)
            .Register(manager);

        public static Tiered<Item> BladedLance = new Tiered<Item>
            (15, Items.BladedLance, 3)
            .Add(60, Items.Glaive)
            .Add(100, Items.KainsLance1)
            .Register(manager);

        public static Tiered<Item> DragoonLance = new Tiered<Item>
            (20, Items.DragoonLance, 3)
            .Add(68, Items.Dragonhorn)
            .Add(105, Items.KainsLance2)
            .Register(manager);

        public static Tiered<Item> Partisan = new Tiered<Item>
            (15, Items.Partisan, 3)
            .Add(60, Items.Rhomphaia)
            .Add(100, Items.KainsLance3)
            .Register(manager);

        public static Tiered<Item> ShamanicSpear = new Tiered<Item>
            (20, Items.ShamanicSpear, 3)
            .Add(68, Items.HereticsHalberd)
            .Add(105, Items.KainsLance4)
            .Register(manager);

        public static Tiered<Item> Punisher = new Tiered<Item>
            (24, Items.Punisher, 3)
            .Add(72, Items.BanescissorSpear)
            .Add(108, Items.KainsLance5)
            .Register(manager);

        public static Tiered<Item> PandoranSpear = new Tiered<Item>
            (24, Items.PandoranSpear, 3)
            .Add(72, Items.CalamitySpear)
            .Add(108, Items.KainsLance6)
            .Register(manager);

        public static Tiered<Item> TamingPole = new Tiered<Item>
            (20, Items.TamingPole, 3)
            .Add(68, Items.VenusGospel)
            .Add(105, Items.KainsLance7)
            .Register(manager);

        public static Tiered<Item> GaeBolg = new Tiered<Item>
            (24, Items.GaeBolg, 3)
            .Add(72, Items.Gungnir)
            .Add(108, Items.KainsLance8)
            .Register(manager);

        #endregion
    }
}
