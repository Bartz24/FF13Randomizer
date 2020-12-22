using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FF13Data
{
    public class DataStoreIDCrystarium : DataStoreID
    {
        public string Prefix => ID.Substring(0, 7);
        public int Stage => Int32.Parse(ID.Substring(7, 2));
        public int Node => Int32.Parse(ID.Substring(9, 2));
        public int SubNode => Int32.Parse(ID.Substring(11, 2));
        public int SubSubNode => Int32.Parse(ID.Substring(13, 1));

        public int CompareNode(DataStoreIDCrystarium other)
        {
            if (this.Node >= 90 && other.Node < 90)
                return -1;
            if (this.Node < 90 && other.Node >= 90)
                return 1;
            int node = this.Node.CompareTo(other.Node);
            if (node != 0)
                return node;
            return 0;
        }

        public int CompareTo(DataStoreIDCrystarium other)
        {
            int prefix = this.Prefix.CompareTo(other.Prefix);
            if (prefix != 0)
                return prefix;
            int stage = this.Stage.CompareTo(other.Stage);
            if (stage != 0)
                return stage;
            int node = this.CompareNode(other);
            if (node != 0)
                return node;
            int subnode = this.SubNode.CompareTo(other.SubNode);
            if (subnode != 0)
                return subnode;
            int subsubnode = this.SubSubNode.CompareTo(other.SubSubNode);
            if (subsubnode != 0)
                return subsubnode;
            return 0;
        }
    }
}
