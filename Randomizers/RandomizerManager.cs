using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FF13Randomizer
{
    public class RandomizerManager : List<Randomizer>
    {
        public Randomizer Get(string id)
        {
            foreach(Randomizer randomizer in this)
            {
                if (randomizer.GetID() == id)
                    return randomizer;
            }
            return null;
        }
    }
}
