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
}
