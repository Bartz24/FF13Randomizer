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
    }
}
