using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FF13Data
{
    public class TieredAbilities
    {
        public static TieredManager<Ability> manager = new TieredManager<Ability>();

        // Commando
        public static TieredDependent<Ability> Adrenaline = new TieredDependent<Ability>
            (0, Abilities.Adrenaline,Abilities.Attack,true)
            .AddDep(Abilities.Adrenaline,Abilities.Ruin)
            .Register(manager);
        public static TieredDependent<Ability> Blindside = new TieredDependent<Ability>
            (0, Abilities.Blindside,Abilities.Attack,true)
            .AddDep(Abilities.Blindside,Abilities.Ruin)
            .Register(manager);
        public static TieredDependent<Ability> Deathblow = new TieredDependent<Ability>
            (0, Abilities.Deathblow,Abilities.Attack,true)
            .AddDep(Abilities.Deathblow,Abilities.Ruin)
            .Register(manager);
        public static TieredDependent<Ability> Faultsiphon = new TieredDependent<Ability>
            (0, Abilities.Faultsiphon,Abilities.Attack)
            .Register(manager);
        public static TieredDependent<Ability> Jeopardize = new TieredDependent<Ability>
            (0, Abilities.Jeopardize,Abilities.Attack)
            .Register(manager);
        public static TieredDependent<Ability> Launch = new TieredDependent<Ability>
            (0, Abilities.Launch,Abilities.Attack)
            .Register(manager);
        public static TieredDependent<Ability> Lifesiphon = new TieredDependent<Ability>
            (0, Abilities.Lifesiphon,Abilities.Attack,true)
            .AddDep(Abilities.Lifesiphon, Abilities.Ruin)
            .Register(manager);
        public static TieredDependent<Ability> Powerchain = new TieredDependent<Ability>
            (0, Abilities.Powerchain, Abilities.Attack, true)
            .AddDep(Abilities.Powerchain, Abilities.Ruin)
            .Register(manager);
        public static TieredDependent<Ability> Ravage = new TieredDependent<Ability>
            (0, Abilities.Ravage,Abilities.Blitz,true)
            .AddDep(Abilities.Ravage,Abilities.Ruinga)
            .Register(manager);
        public static TieredDependent<Ability> Scourge = new TieredDependent<Ability>
            (0, Abilities.Scourge,Abilities.Attack)
            .Register(manager);
        public static TieredDependent<Ability> Smite = new TieredDependent<Ability>
            (0, Abilities.Smite,Abilities.Attack)
            .Register(manager);

        public static TieredDependent<Ability> Attack = new TieredDependent<Ability>
            (0, Abilities.Attack)
            .Register(manager);
        public static TieredDependent<Ability> Blitz = new TieredDependent<Ability>
            (0, Abilities.Blitz,Abilities.Attack)
            .Register(manager);
        public static TieredDependent<Ability> Ruin = new TieredDependent<Ability>
            (0, Abilities.Ruin)
            .Register(manager);
        public static TieredDependent<Ability> Ruinga = new TieredDependent<Ability>
            (0, Abilities.Ruinga,Abilities.Ruin)
            .Register(manager);



        // Ravager
        public static TieredDependent<Ability> Fearsiphon = new TieredDependent<Ability>
            (0, Abilities.Fearsiphon, Abilities.Fire, true)
            .AddDep(Abilities.Fearsiphon, Abilities.Water)
            .AddDep(Abilities.Fearsiphon, Abilities.Thunder)
            .AddDep(Abilities.Fearsiphon, Abilities.Blizzard)
            .Register(manager);
        public static TieredDependent<Ability> Overwhelm = new TieredDependent<Ability>
            (0, Abilities.Overwhelm, Abilities.Fire, true)
            .AddDep(Abilities.Overwhelm, Abilities.Water)
            .AddDep(Abilities.Overwhelm, Abilities.Thunder)
            .AddDep(Abilities.Overwhelm, Abilities.Blizzard)
            .Register(manager);
        public static TieredDependent<Ability> Vigor = new TieredDependent<Ability>
            (0, Abilities.Vigor, Abilities.Fire, true)
            .AddDep(Abilities.Vigor, Abilities.Water)
            .AddDep(Abilities.Vigor, Abilities.Thunder)
            .AddDep(Abilities.Vigor, Abilities.Blizzard)
            .Register(manager);

        public static TieredDependent<Ability> Aero = new TieredDependent<Ability>
            (0, Abilities.Aero)
            .Register(manager);
        public static TieredDependent<Ability> Aerora = new TieredDependent<Ability>
            (0, Abilities.Aerora)
            .Register(manager);
        public static TieredDependent<Ability> Aeroga = new TieredDependent<Ability>
            (0, Abilities.Aeroga)
            .Register(manager);

        public static TieredDependent<Ability> Blizzard = new TieredDependent<Ability>
            (0, Abilities.Blizzard)
            .Register(manager);
        public static TieredDependent<Ability> Blizzara = new TieredDependent<Ability>
            (0, Abilities.Blizzara)
            .Register(manager);
        public static TieredDependent<Ability> Blizzaga = new TieredDependent<Ability>
            (0, Abilities.Blizzaga)
            .Register(manager);

        public static TieredDependent<Ability> Fire = new TieredDependent<Ability>
            (0, Abilities.Fire)
            .Register(manager);
        public static TieredDependent<Ability> Fira = new TieredDependent<Ability>
            (0, Abilities.Fira)
            .Register(manager);
        public static TieredDependent<Ability> Firaga = new TieredDependent<Ability>
            (0, Abilities.Firaga)
            .Register(manager);

        public static TieredDependent<Ability> Thunder = new TieredDependent<Ability>
            (0, Abilities.Thunder)
            .Register(manager);
        public static TieredDependent<Ability> Thundara = new TieredDependent<Ability>
            (0, Abilities.Thundara)
            .Register(manager);
        public static TieredDependent<Ability> Thundaga = new TieredDependent<Ability>
            (0, Abilities.Thundaga)
            .Register(manager);

        public static TieredDependent<Ability> Water = new TieredDependent<Ability>
            (0, Abilities.Water)
            .Register(manager);
        public static TieredDependent<Ability> Watera = new TieredDependent<Ability>
            (0, Abilities.Watera)
            .Register(manager);
        public static TieredDependent<Ability> Waterga = new TieredDependent<Ability>
            (0, Abilities.Waterga)
            .Register(manager);

        public static TieredDependent<Ability> Aquastrike = new TieredDependent<Ability>
            (0, Abilities.Aquastrike)
            .Register(manager);
        public static TieredDependent<Ability> Flamestrike = new TieredDependent<Ability>
            (0, Abilities.Flamestrike)
            .Register(manager);
        public static TieredDependent<Ability> Froststrike = new TieredDependent<Ability>
            (0, Abilities.Froststrike)
            .Register(manager);
        public static TieredDependent<Ability> Sparkstrike = new TieredDependent<Ability>
            (0, Abilities.Sparkstrike)
            .Register(manager);


        // Sentinel
        public static TieredDependent<Ability> Counter = new TieredDependent<Ability>
            (0, Abilities.Counter,Abilities.Provoke,true)
            .AddDep(Abilities.Counter,Abilities.Challenge)
            .Register(manager);
        public static TieredDependent<Ability> Deathward = new TieredDependent<Ability>
            (0, Abilities.Deathward, Abilities.Provoke, true)
            .AddDep(Abilities.Deathward, Abilities.Challenge)
            .Register(manager);
        public static TieredDependent<Ability> Evade = new TieredDependent<Ability>
            (0, Abilities.Evade, Abilities.Provoke, true)
            .AddDep(Abilities.Evade, Abilities.Challenge)
            .Register(manager);
        public static TieredDependent<Ability> Fringeward = new TieredDependent<Ability>
            (0, Abilities.Fringeward, Abilities.Provoke, true)
            .AddDep(Abilities.Fringeward, Abilities.Challenge)
            .Register(manager);
        public static TieredDependent<Ability> Reprieve = new TieredDependent<Ability>
            (0, Abilities.Reprieve, Abilities.Provoke, true)
            .AddDep(Abilities.Reprieve, Abilities.Challenge)
            .Register(manager);

        public static TieredDependent<Ability> Challenge = new TieredDependent<Ability>
            (0, Abilities.Challenge)
            .Register(manager);
        public static TieredDependent<Ability> Elude = new TieredDependent<Ability>
            (0, Abilities.Elude)
            .Register(manager);
        public static TieredDependent<Ability> Entrench = new TieredDependent<Ability>
            (0, Abilities.Entrench)
            .Register(manager);
        public static TieredDependent<Ability> Mediguard = new TieredDependent<Ability>
            (0, Abilities.Mediguard)
            .Register(manager);
        public static TieredDependent<Ability> Provoke = new TieredDependent<Ability>
            (0, Abilities.Provoke)
            .Register(manager);
        public static TieredDependent<Ability> Steelguard = new TieredDependent<Ability>
            (0, Abilities.Steelguard)
            .Register(manager);
        public static TieredDependent<Ability> Vendetta = new TieredDependent<Ability>
            (0, Abilities.Vendetta)
            .Register(manager);


        // Synergist
        public static TieredDependent<Ability> Boon = new TieredDependent<Ability>
            (0, Abilities.Boon, Abilities.Bravery, true)
            .AddDep(Abilities.Boon, Abilities.Faith)
            .AddDep(Abilities.Boon, Abilities.Protect)
            .AddDep(Abilities.Boon, Abilities.Shell)
            .AddDep(Abilities.Boon, Abilities.Vigilance)
            .AddDep(Abilities.Boon, Abilities.Veil)
            .AddDep(Abilities.Boon, Abilities.Haste)
            .Register(manager);

        public static TieredDependent<Ability> Barfire = new TieredDependent<Ability>
            (0, Abilities.Barfire)
            .Register(manager);
        public static TieredDependent<Ability> Barfrost = new TieredDependent<Ability>
            (0, Abilities.Barfrost)
            .Register(manager);
        public static TieredDependent<Ability> Barthunder = new TieredDependent<Ability>
            (0, Abilities.Barthunder)
            .Register(manager);
        public static TieredDependent<Ability> Barwater = new TieredDependent<Ability>
            (0, Abilities.Barwater)
            .Register(manager);

        public static TieredDependent<Ability> Enfire = new TieredDependent<Ability>
            (0, Abilities.Enfire)
            .Register(manager);
        public static TieredDependent<Ability> Enfrost = new TieredDependent<Ability>
            (0, Abilities.Enfrost)
            .Register(manager);
        public static TieredDependent<Ability> Enthunder = new TieredDependent<Ability>
            (0, Abilities.Enthunder)
            .Register(manager);
        public static TieredDependent<Ability> Enwater = new TieredDependent<Ability>
            (0, Abilities.Enwater)
            .Register(manager);

        public static TieredDependent<Ability> Bravery = new TieredDependent<Ability>
            (0, Abilities.Bravery)
            .Register(manager);
        public static TieredDependent<Ability> Bravera = new TieredDependent<Ability>
            (0, Abilities.Bravera)
            .Register(manager);

        public static TieredDependent<Ability> Faith = new TieredDependent<Ability>
            (0, Abilities.Faith)
            .Register(manager);
        public static TieredDependent<Ability> Faithra = new TieredDependent<Ability>
            (0, Abilities.Faithra)
            .Register(manager);
        
        public static TieredDependent<Ability> Protect = new TieredDependent<Ability>
            (0, Abilities.Protect)
            .Register(manager);
        public static TieredDependent<Ability> Protectra = new TieredDependent<Ability>
            (0, Abilities.Protectra)
            .Register(manager);

        public static TieredDependent<Ability> Shell = new TieredDependent<Ability>
            (0, Abilities.Shell)
            .Register(manager);
        public static TieredDependent<Ability> Shellra = new TieredDependent<Ability>
            (0, Abilities.Shellra)
            .Register(manager);

        public static TieredDependent<Ability> Haste = new TieredDependent<Ability>
            (0, Abilities.Haste)
            .Register(manager);

        public static TieredDependent<Ability> Veil = new TieredDependent<Ability>
            (0, Abilities.Veil)
            .Register(manager);

        public static TieredDependent<Ability> Vigilance = new TieredDependent<Ability>
            (0, Abilities.Vigilance)
            .Register(manager);


        // Saboteur
        public static TieredDependent<Ability> Jinx = new TieredDependent<Ability>
            (0, Abilities.Jinx,Abilities.Curse,true)
            .AddDep(Abilities.Jinx, Abilities.Daze)
            .AddDep(Abilities.Jinx, Abilities.Slow)
            .AddDep(Abilities.Jinx, Abilities.Deprotect)
            .AddDep(Abilities.Jinx, Abilities.Deshell)
            .AddDep(Abilities.Jinx, Abilities.Poison)
            .AddDep(Abilities.Jinx, Abilities.Imperil)
            .Register(manager);

        public static TieredDependent<Ability> Curse = new TieredDependent<Ability>
            (0, Abilities.Curse)
            .Register(manager);
        public static TieredDependent<Ability> Cursega = new TieredDependent<Ability>
            (0, Abilities.Cursega)
            .Register(manager);

        public static TieredDependent<Ability> Daze = new TieredDependent<Ability>
            (0, Abilities.Daze)
            .Register(manager);
        public static TieredDependent<Ability> Dazega = new TieredDependent<Ability>
            (0, Abilities.Dazega)
            .Register(manager);

        public static TieredDependent<Ability> Deprotect = new TieredDependent<Ability>
            (0, Abilities.Deprotect)
            .Register(manager);
        public static TieredDependent<Ability> Deprotega = new TieredDependent<Ability>
            (0, Abilities.Deprotega)
            .Register(manager);

        public static TieredDependent<Ability> Deshell = new TieredDependent<Ability>
            (0, Abilities.Deshell)
            .Register(manager);
        public static TieredDependent<Ability> Deshellga = new TieredDependent<Ability>
            (0, Abilities.Deshellga)
            .Register(manager);

        public static TieredDependent<Ability> Fog = new TieredDependent<Ability>
            (0, Abilities.Fog)
            .Register(manager);
        public static TieredDependent<Ability> Fogga = new TieredDependent<Ability>
            (0, Abilities.Fogga)
            .Register(manager);

        public static TieredDependent<Ability> Imperil = new TieredDependent<Ability>
            (0, Abilities.Imperil)
            .Register(manager);
        public static TieredDependent<Ability> Imperilga = new TieredDependent<Ability>
            (0, Abilities.Imperilga)
            .Register(manager);

        public static TieredDependent<Ability> Pain = new TieredDependent<Ability>
            (0, Abilities.Pain)
            .Register(manager);
        public static TieredDependent<Ability> Painga = new TieredDependent<Ability>
            (0, Abilities.Painga)
            .Register(manager);

        public static TieredDependent<Ability> Poison = new TieredDependent<Ability>
            (0, Abilities.Poison)
            .Register(manager);
        public static TieredDependent<Ability> Poisonga = new TieredDependent<Ability>
            (0, Abilities.Poisonga)
            .Register(manager);

        public static TieredDependent<Ability> Slow = new TieredDependent<Ability>
            (0, Abilities.Slow)
            .Register(manager);
        public static TieredDependent<Ability> Slowga = new TieredDependent<Ability>
            (0, Abilities.Slowga)
            .Register(manager);

        public static TieredDependent<Ability> Dispel = new TieredDependent<Ability>
            (0, Abilities.Dispel)
            .Register(manager);


        // Medic
        public static TieredDependent<Ability> Cure = new TieredDependent<Ability>
            (0, Abilities.Cure)
            .Register(manager);
        public static TieredDependent<Ability> Cura = new TieredDependent<Ability>
            (0, Abilities.Cura,Abilities.Cure,true)
            .Register(manager);
        public static TieredDependent<Ability> Curasa = new TieredDependent<Ability>
            (0, Abilities.Curasa, Abilities.Cure, true)
            .Register(manager);
        public static TieredDependent<Ability> Curaja = new TieredDependent<Ability>
            (0, Abilities.Curaja, Abilities.Curasa, true)
            .Register(manager);

        public static TieredDependent<Ability> Esuna = new TieredDependent<Ability>
            (0, Abilities.Esuna, Abilities.Cure, true)
            .Register(manager);

        public static TieredDependent<Ability> Raise = new TieredDependent<Ability>
            (0, Abilities.Raise, Abilities.Cure, true)
            .Register(manager);


        // Techniques
        public static TieredDependent<Ability> Dispelga = new TieredDependent<Ability>
            (0, Abilities.Dispelga)
            .Register(manager);
        public static TieredDependent<Ability> Libra = new TieredDependent<Ability>
            (0, Abilities.Libra)
            .Register(manager);
        public static TieredDependent<Ability> Quake = new TieredDependent<Ability>
            (0, Abilities.Quake)
            .Register(manager);
        public static TieredDependent<Ability> Renew = new TieredDependent<Ability>
            (0, Abilities.Renew)
            .Register(manager);
        public static TieredDependent<Ability> Stopga = new TieredDependent<Ability>
            (0, Abilities.Stopga)
            .Register(manager);



        // Special
        public static TieredDependent<Ability> ArmyOfOne = new TieredDependent<Ability>
            (0, Abilities.ArmyOfOne)
            .Register(manager);
        public static TieredDependent<Ability> ColdBlood = new TieredDependent<Ability>
            (0, Abilities.ColdBlood)
            .Register(manager);
        public static TieredDependent<Ability> Death = new TieredDependent<Ability>
            (0, Abilities.Death)
            .Register(manager);
        public static TieredDependent<Ability> Highwind = new TieredDependent<Ability>
            (0, Abilities.Highwind)
            .Register(manager);
        public static TieredDependent<Ability> LastResort = new TieredDependent<Ability>
            (0, Abilities.LastResort)
            .Register(manager);
        public static TieredDependent<Ability> SovereignFist = new TieredDependent<Ability>
            (0, Abilities.SovereignFist)
            .Register(manager);

        static TieredAbilities()
        {
        }

        public static Ability Get(Tiered<Ability> tiered, List<Ability> obtained)
        {
            return manager.Get(0, tiered, a => ((TieredDependent<Ability>)tiered).MeetsRequirement(a, obtained)).Item1;
        }
    }
}
