using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FF13Data
{
    public enum PassiveType
    {
        Weapon,
        Accessory
    }
    public enum LockingLevel
    {
        Fixed,
        SameType,
        Any
    }


    public class PassiveSet
    {
        public string Characters { get; set; }
        public LockingLevel LockingLevel { get; set; }
        public PassiveType Type { get; set; }

        public class Passive : Identifier
        {
            public string Name { get; set; }
            public float StrengthModifier { get; set; }
            public float MagicModifier { get; set; }
            public string PassiveDisplayName { get; set; }
            public string PassiveHelp { get; set; }
            public short StatInitial { get; set; }
            public byte StatType1 { get; set; }
            public ushort StatType2 { get; set; }
        }

        private List<Passive> list = new List<Passive>();

        /// <summary>
        /// l=Lightning
        /// s=Snow
        /// v=Vanille
        /// z=Sazh
        /// h=Hope
        /// f=Fang
        /// </summary>
        /// <param name="characters"></param>
        public PassiveSet(PassiveType type, LockingLevel level = LockingLevel.Any, string characters = "lsvzhf")
        {
            this.Characters = characters;
            this.LockingLevel = level;
            this.Type = type;
            Passives.passives.Add(this);
        }

        public PassiveSet Add(string name, string id, float str, float mag, string dispName, string help, short statInit, byte type1, ushort type2)
        {
            list.Add(new Passive() { Name = name, ID = id, StrengthModifier = str, MagicModifier = mag, PassiveDisplayName = dispName, PassiveHelp = help, StatInitial = statInit, StatType1 = type1, StatType2 = type2 });
            return this;
        }

        public bool HasCharacter(string character)
        {
            for (int i = list.Count - 1; i >= 0; i--)
            {
                if (Characters.Contains(character))
                    return true;
            }
            return false;
        }

        public string GetCharacters()
        {
            return string.Join("", list.SelectMany(a => Characters.ToCharArray()).Distinct().OrderBy(c => "lsvzhf".ToCharArray().ToList().IndexOf(c)).Select(c =>
              {
                  switch (c)
                  {
                      case 'l':
                          return "L";
                      case 's':
                          return "Sn";
                      case 'v':
                          return "V";
                      case 'z':
                          return "Sz";
                      case 'h':
                          return "H";
                      case 'f':
                          return "F";
                      default:
                          return "";
                  }
              }));
        }

        public Passive GetPassive(string character, int tier, int tiers)
        {
            if (HasCharacter(character))
            {
                return GetPassiveDirect(tier, tiers);
            }
            throw new Exception($"{GetName(character)} cannot have the {list[0].Name} passive!");
        }

        public Passive GetPassiveDirect(int tier, int tiers)
        {
            if (tiers < list.Count)
                return list[list.Count - tiers + tier];
            else
                return list[Math.Min(list.Count - 1, tier)];
        }

        private Character GetName(string character)
        {
            switch (character)
            {
                case "l":
                    return Character.Lightning;
                case "s":
                    return Character.Snow;
                case "v":
                    return Character.Vanille;
                case "z":
                    return Character.Sazh;
                case "h":
                    return Character.Hope;
                case "f":
                    return Character.Fang;
            }
            return Character.Lightning;
        }

        public string[] GetIDs()
        {
            return list.Select(d => d.ID).ToArray();
        }

        public Passive[] GetPassives()
        {
            return list.ToArray();
        }
    }
}
