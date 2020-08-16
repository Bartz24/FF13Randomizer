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
        public static Ability Adrenaline = new Ability("Adrenaline", Role.Commando, "ade740_00");
        public static Ability Blindside = new Ability("Blindside", Role.Commando, "aat540_00", "lsf")
            .Add("ac004_at540_00", "v");
        public static Ability Deathblow = new Ability("Deathblow", Role.Commando, "ade710_00");
        public static Ability Faultsiphon = new Ability("Faultsiphon", Role.Commando, "ade730_00");
        public static Ability Jeopardize = new Ability("Jeopardize", Role.Commando, "ade700_00");
        public static Ability Launch = new Ability("Launch", Role.Commando, "aat500_00","lsf");
        public static Ability Lifesiphon = new Ability("Lifesiphon", Role.Commando, "ade720_00");
        public static Ability Powerchain = new Ability("Powerchain", Role.Commando, "aat550_00", "lszf");
        public static Ability Ravage = new Ability("Ravage", Role.Commando, "aat530_00", "lsf")
            .Add("ac003_at530_00", "h");
        public static Ability Scourge = new Ability("Scourge", Role.Commando, "aat570_00", "lszf")
            .Add("ac003_at570_00", "h")
            .Add("ac004_at570_00", "v");
        public static Ability Smite = new Ability("Smite", Role.Commando, "aat560_00", "lsf");

        public static Ability Attack = new Ability("Attack", Role.Commando, "at010_00", "sf")
            .Add("c000_at010_00","l")
            .Add("c002_at010_00", "z")
            .Add("c003_at010_00", "h")
            .Add("c004_at010_00", "v").SetStarting();
        public static Ability Blitz = new Ability("Blitz", Role.Commando, "at520_00", "lsf")
            .Add("c002_at520_00", "z")
            .Add("c003_at520_00", "h");
        public static Ability Ruin = new Ability("Ruin", Role.Commando, "ma000_00").SetStarting();
        public static Ability Ruinga = new Ability("Ruinga", Role.Commando, "ma020_00");



        // Ravager
        public static Ability Fearsiphon = new Ability("Fearsiphon", Role.Ravager, "ade800_00");
        public static Ability Overwhelm = new Ability("Overwhelm", Role.Ravager, "ade810_00");
        public static Ability Vigor = new Ability("Vigor", Role.Ravager, "ade820_00");

        public static Ability Aero = new Ability("Aero", Role.Ravager, "mb400_00").SetStarting();
        public static Ability Aerora = new Ability("Aerora", Role.Ravager, "mb410_00").SetStarting();
        public static Ability Aeroga = new Ability("Aeroga", Role.Ravager, "mb420_00");

        public static Ability Blizzard = new Ability("Blizzard", Role.Ravager, "mb100_00").SetStarting();
        public static Ability Blizzara = new Ability("Blizzara", Role.Ravager, "mb110_00").SetStarting();
        public static Ability Blizzaga = new Ability("Blizzaga", Role.Ravager, "mb120_00").SetStarting();

        public static Ability Fire = new Ability("Fire", Role.Ravager, "mb000_00").SetStarting();
        public static Ability Fira = new Ability("Fira", Role.Ravager, "mb010_00").SetStarting();
        public static Ability Firaga = new Ability("Firaga", Role.Ravager, "mb020_00").SetStarting();

        public static Ability Thunder = new Ability("Thunder", Role.Ravager, "mb200_00").SetStarting();
        public static Ability Thundara = new Ability("Thundara", Role.Ravager, "mb210_00").SetStarting();
        public static Ability Thundaga = new Ability("Thundaga", Role.Ravager, "mb220_00").SetStarting();

        public static Ability Water = new Ability("Water", Role.Ravager, "mb300_00").SetStarting();
        public static Ability Watera = new Ability("Watera", Role.Ravager, "mb310_00").SetStarting();
        public static Ability Waterga = new Ability("Waterga", Role.Ravager, "mb320_00").SetStarting();

        public static Ability Aquastrike = new Ability("Aquastrike", Role.Ravager, "at010_40", "lsf").SetStarting();
        public static Ability Flamestrike = new Ability("Flamestrike", Role.Ravager, "at010_10", "lf")
            .Add("c002_at010_10", "z").SetStarting();
        public static Ability Froststrike = new Ability("Froststrike", Role.Ravager, "at010_20", "lsf").SetStarting();
        public static Ability Sparkstrike = new Ability("Sparkstrike", Role.Ravager, "at010_30", "lf")
            .Add("c002_at010_30", "z").SetStarting();


        // Sentinel
        public static Ability Counter = new Ability("Counter", Role.Sentinel, "ade110_00", "lshf");
        public static Ability Deathward = new Ability("Deathward", Role.Sentinel, "ade600_00");
        public static Ability Evade = new Ability("Evade", Role.Sentinel, "ade010_00");
        public static Ability Fringeward = new Ability("Fringeward", Role.Sentinel, "ade610_00");
        public static Ability Reprieve = new Ability("Reprieve", Role.Sentinel, "ade620_00");

        public static Ability Challenge = new Ability("Challenge", Role.Sentinel, "ac110_00").SetStarting();
        public static Ability Elude = new Ability("Elude", Role.Sentinel, "gd210_00").SetStarting();
        public static Ability Entrench = new Ability("Entrench", Role.Sentinel, "gd410_00", "sf")
            .Add("c003_gd410_00", "h")
            .Add("c004_gd410_00", "v").SetStarting();
        public static Ability Mediguard = new Ability("Mediguard", Role.Sentinel, "gd110_00").SetStarting();
        public static Ability Provoke = new Ability("Provoke", Role.Sentinel, "ac100_00").SetStarting();
        public static Ability Steelguard = new Ability("Steelguard", Role.Sentinel, "gd010_00").SetStarting();
        public static Ability Vendetta = new Ability("Vendetta", Role.Sentinel, "gd310_00", "sf")
            .Add("c002_gd310_00", "z")
            .Add("c003_gd310_00", "h").SetStarting();


        // Synergist
        public static Ability Boon = new Ability("Boon", Role.Synergist, "ade850_00");

        public static Ability Barfire = new Ability("Barfire", Role.Synergist, "me530_00").SetStarting();
        public static Ability Barfrost = new Ability("Barfrost", Role.Synergist, "me540_00").SetStarting();
        public static Ability Barthunder = new Ability("Barthunder", Role.Synergist, "me550_00").SetStarting();
        public static Ability Barwater = new Ability("Barwater", Role.Synergist, "me560_00").SetStarting();

        public static Ability Enfire = new Ability("Enfire", Role.Synergist, "me030_00").SetStarting();
        public static Ability Enfrost = new Ability("Enfrost", Role.Synergist, "me040_00").SetStarting();
        public static Ability Enthunder = new Ability("Enthunder", Role.Synergist, "me050_00").SetStarting();
        public static Ability Enwater = new Ability("Enwater", Role.Synergist, "me060_00").SetStarting();

        public static Ability Bravery = new Ability("Bravery", Role.Synergist, "me000_00").SetStarting();
        public static Ability Bravera = new Ability("Bravera", Role.Synergist, "me200_00").SetStarting();

        public static Ability Faith = new Ability("Faith", Role.Synergist, "me010_00").SetStarting();
        public static Ability Faithra = new Ability("Faithra", Role.Synergist, "me210_00").SetStarting();
        
        public static Ability Protect = new Ability("Protect", Role.Synergist, "me500_00").SetStarting();
        public static Ability Protectra = new Ability("Protectra", Role.Synergist, "me700_00").SetStarting();

        public static Ability Shell = new Ability("Shell", Role.Synergist, "me510_00").SetStarting();
        public static Ability Shellra = new Ability("Shellra", Role.Synergist, "me710_00").SetStarting();

        public static Ability Haste = new Ability("Haste", Role.Synergist, "me020_00").SetStarting();

        public static Ability Veil = new Ability("Veil", Role.Synergist, "me520_00").SetStarting();

        public static Ability Vigilance = new Ability("Vigilance", Role.Synergist, "me070_00").SetStarting();


        // Saboteur
        public static Ability Jinx = new Ability("Jinx", Role.Saboteur, "ade900_00");

        public static Ability Curse = new Ability("Curse", Role.Saboteur, "mg530_00").SetStarting();
        public static Ability Cursega = new Ability("Cursega", Role.Saboteur, "mg730_00").SetStarting();

        public static Ability Daze = new Ability("Daze", Role.Saboteur, "mg540_00").SetStarting();
        public static Ability Dazega = new Ability("Dazega", Role.Saboteur, "mg740_00").SetStarting();

        public static Ability Deprotect = new Ability("Deprotect", Role.Saboteur, "mg000_00").SetStarting();
        public static Ability Deprotega = new Ability("Deprotega", Role.Saboteur, "mg200_00").SetStarting();

        public static Ability Deshell = new Ability("Deshell", Role.Saboteur, "mg010_00").SetStarting();
        public static Ability Deshellga = new Ability("Deshellga", Role.Saboteur, "mg210_00").SetStarting();

        public static Ability Fog = new Ability("Fog", Role.Saboteur, "mg510_00").SetStarting();
        public static Ability Fogga = new Ability("Fogga", Role.Saboteur, "mg710_00").SetStarting();

        public static Ability Imperil = new Ability("Imperil", Role.Saboteur, "mg030_00").SetStarting();
        public static Ability Imperilga = new Ability("Imperilga", Role.Saboteur, "mg230_00").SetStarting();

        public static Ability Pain = new Ability("Pain", Role.Saboteur, "mg520_00").SetStarting();
        public static Ability Painga = new Ability("Painga", Role.Saboteur, "mg720_00").SetStarting();

        public static Ability Poison = new Ability("Poison", Role.Saboteur, "mg020_00").SetStarting();
        public static Ability Poisonga = new Ability("Poisonga", Role.Saboteur, "mg220_00").SetStarting();

        public static Ability Slow = new Ability("Slow", Role.Saboteur, "mg500_00").SetStarting();
        public static Ability Slowga = new Ability("Slowga", Role.Saboteur, "mg700_00").SetStarting();

        public static Ability Dispel = new Ability("Dispel", Role.Saboteur, "mg240_00").SetStarting();


        // Medic
        public static Ability Cure = new Ability("Cure", Role.Medic, "mw000_00").SetStarting();
        public static Ability Cura = new Ability("Cura", Role.Medic, "mw010_00");
        public static Ability Curasa = new Ability("Curasa", Role.Medic, "mw020_00");
        public static Ability Curaja = new Ability("Curaja", Role.Medic, "mw030_00");

        public static Ability Esuna = new Ability("Esuna", Role.Medic, "mw200_00");

        public static Ability Raise = new Ability("Raise", Role.Medic, "mw100_00");


        // Techniques
        public static Ability Dispelga = new Ability("Dispelga", Role.None, "tp300_00");
        public static Ability Libra = new Ability("Libra", Role.None, "tp100_00");
        public static Ability Quake = new Ability("Quake", Role.None, "tp400_00");
        public static Ability Renew = new Ability("Renew", Role.None, "tp000_00");
        public static Ability Stopga = new Ability("Stopga", Role.None, "tp200_00");
        public static Ability Summon = new Ability("Summon", Role.None, "sm000", "");



        // Special
        public static Ability ArmyOfOne = new Ability("ArmyOfOne", Role.Ravager, "c000_at900_00", "l");
        public static Ability ColdBlood = new Ability("ColdBlood", Role.Ravager, "c002_at900_00", "z");
        public static Ability Death = new Ability("Death", Role.Saboteur, "ms400_00", "v");
        public static Ability Highwind = new Ability("Highwind", Role.Commando, "c005_at900_00", "f");
        public static Ability LastResort = new Ability("LastResort", Role.Ravager, "ms200_00", "h");
        public static Ability SovereignFist = new Ability("SovereignFist", Role.Commando, "c001_at900_00", "s");
    }
}
