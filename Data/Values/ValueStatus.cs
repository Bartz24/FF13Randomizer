using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FF13Data
{
    [Flags]
    public enum Status : uint
    {
        None = 0x00000000,
        Death = 0x00000001,
        Stone = 0x00000002,
        Petrify = 0x00000004,
        Stop = 0x00000008,
        Sleep = 0x00000010,
        Confuse = 0x00000020,
        Doom = 0x00000040,
        Blind = 0x00000080,
        Poison = 0x00000100,
        Silence = 0x00000200,
        Sap = 0x00000400,
        Oil = 0x00000800,
        Reverse = 0x00001000,
        Disable = 0x00002000,
        Immobilize = 0x00004000,
        Slow = 0x00008000,
        Disease = 0x00010000,
        Lure = 0x00020000,
        Protect = 0x00040000,
        Shell = 0x00080000,
        Haste = 0x00100000,
        Bravery = 0x00200000,
        Faith = 0x00400000,
        Reflect = 0x00800000,
        Vanish = 0x01000000,
        Regen = 0x02000000,
        Float = 0x04000000,
        Berserk = 0x08000000,
        Bubble = 0x10000000,
        CriticalHP = 0x20000000,
        Libra = 0x40000000,
        XZone = 0x80000000
    }
}
