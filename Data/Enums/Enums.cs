using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FF13Data
{
    public enum CrystariumType : byte
    {
        HP = 1,
        Strength = 2,
        Magic = 3,
        Accessory = 4,
        ATBLevel = 5,
        Ability = 6,
        RoleLevel = 7,
        Unknown = 0
    }

    public enum Role : byte
    {
        None = 0,
        Commando = 2,
        Ravager = 3,
        Sentinel = 1,
        Synergist = 4,
        Medic = 6,
        Saboteur = 5
    }

    public enum ElementalRes : byte
    {
        Weakness = 0,
        Normal = 1,
        Halved = 2,
        Resistant = 3,
        Immune = 4,
        Absorb = 5
    }

    public enum Element
    {
        Fire,
        Ice,
        Thunder,
        Water,
        Wind,
        Earth,
        Physical,
        Magical
    }

    public enum Debuff
    {
        Deprotect,
        Deshell,
        Poison,
        Imperil,
        Slow,
        Fog,
        Pain,
        Curse,
        Daze,
        //Provoke, Ignore as it is a hidden stat
        Death,
        Dispel
    }

    public enum ElementProperty
    {
        Normal,
        Bomb, // Absorb element does not change
        Skytank // Will ensure physical attacks are mapped to magic except Lightning's Attack
    }

    public enum Character
    {
        Lightning,
        Snow,
        Vanille,
        Sazh,
        Hope,
        Fang
    }

    public enum SynthesisGroup : byte
    {
        None = 0xC4,
        HighHPPowerSurge = 0x82,
        LowHPPowerSurge = 0x84,
        PhysicalWall = 0x86,
        MagicWall = 0x88,
        //PhysicalProofing = 0x8A, Wall but worse
        //MagicProofing = 0x8C, Wall but worse
        DamageWall = 0x8E,
        //DamageProofing = 0x90, Wall but worse
        EtherealMantle = 0x92,
        MagicDamper = 0x94,
        FireDamage = 0x96,
        IceDamage = 0x98,
        LightningDamage = 0x9A,
        WaterDamage = 0x9C,
        WindDamage = 0x9E,
        EarthDamage = 0xA0,
        DebraveDuration = 0xA2,
        DefaithDuration = 0xA4,
        DeprotectDuration = 0xA6,
        DeshellDuration = 0xA8,
        SlowDuration = 0xAA,
        PoisonDuration = 0xAC,
        ImperilDuration = 0xAE,
        CurseDuration = 0xB0,
        PainDuration = 0xB2,
        FogDuration = 0xB4,
        DazeDuration = 0xB6,
        ATBRate = 0xBC,
        RIC_GestaltTPBoost = 0xBE,
        BuffDuration = 0xC0,
        VampiricStrike = 0xC2        
    }
}
