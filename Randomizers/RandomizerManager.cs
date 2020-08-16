using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FF13Randomizer
{
    public class RandomizerManager : List<Randomizer>
    {
        public T Get<T>(string id) where T : Randomizer
        {
            foreach(Randomizer randomizer in this)
            {
                if (randomizer.GetID() == id)
                    return (T)randomizer;
            }
            return null;
        }
    }
}
