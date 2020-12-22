using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FF13Data
{
    public enum EnemyType
    {
        Normal,
        Rare, // Difficult or hard to find
        Boss // Only fought once
    }

    public class Enemy : Identifier
    {
        public static Dictionary<byte, ElementalRes> PhysMapping = GetPhysMapping();

        public string Name { get; set; }

        public EnemyType Type { get; set; }

        public Enemy ConnectedDrops { get; set; }

        public Enemy(string name, string id, Enemy connectDrops = null, EnemyType type = EnemyType.Normal)
        {
            this.Name = name;
            this.ID = id;
            this.Type = type;
            this.ConnectedDrops = connectDrops;
            Enemies.enemies.Add(this);
        }

        private static Dictionary<byte, ElementalRes> GetPhysMapping() {
            Dictionary<byte, ElementalRes> mapping = new Dictionary<byte, ElementalRes>();
            #region Set Physical Resistances
            mapping.Add(0x00, ElementalRes.Normal);
            mapping.Add(0x01, ElementalRes.Normal);
            mapping.Add(0x04, ElementalRes.Normal);
            mapping.Add(0x05, ElementalRes.Normal);
            mapping.Add(0x81, ElementalRes.Normal);

            mapping.Add(0x0D, ElementalRes.Halved);
            mapping.Add(0x10, ElementalRes.Halved);
            mapping.Add(0x11, ElementalRes.Halved);
            mapping.Add(0x14, ElementalRes.Halved);
            mapping.Add(0x15, ElementalRes.Halved);
            mapping.Add(0x91, ElementalRes.Halved);

            mapping.Add(0x18, ElementalRes.Resistant);
            mapping.Add(0x19, ElementalRes.Resistant);
            mapping.Add(0x1C, ElementalRes.Resistant);
            mapping.Add(0x1D, ElementalRes.Resistant);
            mapping.Add(0x98, ElementalRes.Resistant);

            mapping.Add(0x20, ElementalRes.Immune);
            mapping.Add(0x21, ElementalRes.Immune);
            mapping.Add(0x24, ElementalRes.Immune);
            mapping.Add(0x25, ElementalRes.Immune);
            #endregion
            return mapping;
            }
}
}
