using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FF13Data
{
    public class Abilities
    {
        public static List<Ability> abilities = new List<Ability>();
        // Commando
        public static Ability Adrenaline = new Ability(Role.Commando, "ade740_00");
        public static Ability Blindside = new Ability(Role.Commando, "aat540_00", "lsf")
            .Add("ac004_at540_00", "v");
        public static Ability Deathblow = new Ability(Role.Commando, "ade710_00");
        public static Ability Faultsiphon = new Ability(Role.Commando, "ade730_00");
        public static Ability Jeopardize = new Ability(Role.Commando, "ade700_00");
        public static Ability Launch = new Ability(Role.Commando, "aat500_00","lsf");
        public static Ability Lifesiphon = new Ability(Role.Commando, "ade720_00");
        public static Ability Powerchain = new Ability(Role.Commando, "aat550_00", "lszf");
        public static Ability Ravage = new Ability(Role.Commando, "aat530_00", "lsf")
            .Add("ac003_at530_00", "h");
        public static Ability Scourge = new Ability(Role.Commando, "aat570_00", "lszf")
            .Add("ac003_at570_00", "h")
            .Add("ac003_at570_00", "v");
        public static Ability Smite = new Ability(Role.Commando, "aat560_00", "lsf");

        public static Ability Attack = new Ability(Role.Commando, "at010_00", "sf")
            .Add("c000_at010_00","l")
            .Add("c002_at010_00", "z")
            .Add("c003_at010_00", "h")
            .Add("c004_at010_00", "v").SetStarting();
        public static Ability Blitz = new Ability(Role.Commando, "at520_00", "lsf")
            .Add("c002_at520_00", "z")
            .Add("c003_at520_00", "h");
        public static Ability Ruin = new Ability(Role.Commando, "ma000_00").SetStarting();
        public static Ability Ruinga = new Ability(Role.Commando, "ma020_00");



        // Ravager
        public static Ability Fearsiphon = new Ability(Role.Ravager, "ade800_00");
        public static Ability Overwhelm = new Ability(Role.Ravager, "ade810_00");
        public static Ability Vigor = new Ability(Role.Ravager, "ade820_00");

        public static Ability Aero = new Ability(Role.Ravager, "mb400_00").SetStarting();
        public static Ability Aerora = new Ability(Role.Ravager, "mb410_00").SetStarting();
        public static Ability Aeroga = new Ability(Role.Ravager, "mb420_00");

        public static Ability Blizzard = new Ability(Role.Ravager, "mb100_00").SetStarting();
        public static Ability Blizzara = new Ability(Role.Ravager, "mb110_00").SetStarting();
        public static Ability Blizzaga = new Ability(Role.Ravager, "mb120_00").SetStarting();

        public static Ability Fire = new Ability(Role.Ravager, "mb000_00").SetStarting();
        public static Ability Fira = new Ability(Role.Ravager, "mb010_00").SetStarting();
        public static Ability Firaga = new Ability(Role.Ravager, "mb020_00").SetStarting();

        public static Ability Thunder = new Ability(Role.Ravager, "mb200_00").SetStarting();
        public static Ability Thundara = new Ability(Role.Ravager, "mb210_00").SetStarting();
        public static Ability Thundaga = new Ability(Role.Ravager, "mb220_00").SetStarting();

        public static Ability Water = new Ability(Role.Ravager, "mb300_00").SetStarting();
        public static Ability Watera = new Ability(Role.Ravager, "mb310_00").SetStarting();
        public static Ability Waterga = new Ability(Role.Ravager, "mb320_00").SetStarting();

        public static Ability Aquastrike = new Ability(Role.Ravager, "at010_40", "lsf").SetStarting();
        public static Ability Flamestrike = new Ability(Role.Ravager, "at010_10", "lf")
            .Add("c002_at010_10", "z").SetStarting();
        public static Ability Froststrike = new Ability(Role.Ravager, "at010_20", "lsf").SetStarting();
        public static Ability Sparkstrike = new Ability(Role.Ravager, "at010_30", "lf")
            .Add("c002_at010_30", "z").SetStarting();


        // Sentinel
        public static Ability Counter = new Ability(Role.Sentinel, "ade110_00", "lshf");
        public static Ability Deathward = new Ability(Role.Sentinel, "ade600_00");
        public static Ability Evade = new Ability(Role.Sentinel, "ade010_00");
        public static Ability Fringeward = new Ability(Role.Sentinel, "ade610_00");
        public static Ability Reprieve = new Ability(Role.Sentinel, "ade620_00");

        public static Ability Challenge = new Ability(Role.Sentinel, "ac110_00").SetStarting();
        public static Ability Elude = new Ability(Role.Sentinel, "gd210_00").SetStarting();
        public static Ability Entrench = new Ability(Role.Sentinel, "gd410_00", "sf")
            .Add("c003_gd410_00", "h")
            .Add("c004_gd410_00", "v").SetStarting();
        public static Ability Mediguard = new Ability(Role.Sentinel, "gd110_00").SetStarting();
        public static Ability Provoke = new Ability(Role.Sentinel, "ac100_00").SetStarting();
        public static Ability Steelguard = new Ability(Role.Sentinel, "gd010_00").SetStarting();
        public static Ability Vendetta = new Ability(Role.Sentinel, "gd310_00", "sf")
            .Add("c002_gd310_00", "z")
            .Add("c003_gd310_00", "h").SetStarting();


        // Synergist
        public static Ability Boon = new Ability(Role.Synergist, "ade850_00");

        public static Ability Barfire = new Ability(Role.Synergist, "me530_00").SetStarting();
        public static Ability Barfrost = new Ability(Role.Synergist, "me540_00").SetStarting();
        public static Ability Barthunder = new Ability(Role.Synergist, "me550_00").SetStarting();
        public static Ability Barwater = new Ability(Role.Synergist, "me560_00").SetStarting();

        public static Ability Enfire = new Ability(Role.Synergist, "me030_00").SetStarting();
        public static Ability Enfrost = new Ability(Role.Synergist, "me040_00").SetStarting();
        public static Ability Enthunder = new Ability(Role.Synergist, "me050_00").SetStarting();
        public static Ability Enwater = new Ability(Role.Synergist, "me060_00").SetStarting();

        public static Ability Bravery = new Ability(Role.Synergist, "me000_00").SetStarting();
        public static Ability Bravera = new Ability(Role.Synergist, "me200_00").SetStarting();

        public static Ability Faith = new Ability(Role.Synergist, "me010_00").SetStarting();
        public static Ability Faithra = new Ability(Role.Synergist, "me210_00").SetStarting();
        
        public static Ability Protect = new Ability(Role.Synergist, "me500_00").SetStarting();
        public static Ability Protectra = new Ability(Role.Synergist, "me700_00").SetStarting();

        public static Ability Shell = new Ability(Role.Synergist, "me510_00").SetStarting();
        public static Ability Shellra = new Ability(Role.Synergist, "me710_00").SetStarting();

        public static Ability Haste = new Ability(Role.Synergist, "me020_00").SetStarting();

        public static Ability Veil = new Ability(Role.Synergist, "me520_00").SetStarting();

        public static Ability Vigilance = new Ability(Role.Synergist, "me070_00").SetStarting();


        // Saboteur
        public static Ability Jinx = new Ability(Role.Saboteur, "ade900_00");

        public static Ability Curse = new Ability(Role.Saboteur, "mg530_00").SetStarting();
        public static Ability Cursega = new Ability(Role.Saboteur, "mg730_00").SetStarting();

        public static Ability Daze = new Ability(Role.Saboteur, "mg540_00").SetStarting();
        public static Ability Dazega = new Ability(Role.Saboteur, "mg740_00").SetStarting();

        public static Ability Deprotect = new Ability(Role.Saboteur, "mg000_00").SetStarting();
        public static Ability Deprotega = new Ability(Role.Saboteur, "mg200_00").SetStarting();

        public static Ability Deshell = new Ability(Role.Saboteur, "mg010_00").SetStarting();
        public static Ability Deshellga = new Ability(Role.Saboteur, "mg210_00").SetStarting();

        public static Ability Fog = new Ability(Role.Saboteur, "mg510_00").SetStarting();
        public static Ability Fogga = new Ability(Role.Saboteur, "mg710_00").SetStarting();

        public static Ability Imperil = new Ability(Role.Saboteur, "mg030_00").SetStarting();
        public static Ability Imperilga = new Ability(Role.Saboteur, "mg230_00").SetStarting();

        public static Ability Pain = new Ability(Role.Saboteur, "mg520_00").SetStarting();
        public static Ability Painga = new Ability(Role.Saboteur, "mg720_00").SetStarting();

        public static Ability Poison = new Ability(Role.Saboteur, "mg020_00").SetStarting();
        public static Ability Poisonga = new Ability(Role.Saboteur, "mg220_00").SetStarting();

        public static Ability Slow = new Ability(Role.Saboteur, "mg500_00").SetStarting();
        public static Ability Slowga = new Ability(Role.Saboteur, "mg700_00").SetStarting();

        public static Ability Dispel = new Ability(Role.Saboteur, "mg240_00").SetStarting();


        // Medic
        public static Ability Cure = new Ability(Role.Medic, "mw000_00").SetStarting();
        public static Ability Cura = new Ability(Role.Medic, "mw010_00");
        public static Ability Curasa = new Ability(Role.Medic, "mw020_00");
        public static Ability Curaja = new Ability(Role.Medic, "mw030_00");

        public static Ability Esuna = new Ability(Role.Medic, "mw200_00");

        public static Ability Raise = new Ability(Role.Medic, "mw100_00");


        // Techniques
        public static Ability Dispelga = new Ability(Role.None, "tp300_00");
        public static Ability Libra = new Ability(Role.None, "tp100_00");
        public static Ability Quake = new Ability(Role.None, "tp400_00");
        public static Ability Renew = new Ability(Role.None, "tp000_00");
        public static Ability Stopga = new Ability(Role.None, "tp200_00");



        // Special
        public static Ability ArmyOfOne = new Ability(Role.Ravager, "c000_at900_00", "l");
        public static Ability ColdBlood = new Ability(Role.Ravager, "c002_at900_00", "z");
        public static Ability Death = new Ability(Role.Saboteur, "ms400_00", "v");
        public static Ability Highwind = new Ability(Role.Commando, "c005_at900_00", "f");
        public static Ability LastResort = new Ability(Role.Ravager, "ms200_00", "h");
        public static Ability SovereignFist = new Ability(Role.Commando, "c001_at900_00", "s");
    }
}
