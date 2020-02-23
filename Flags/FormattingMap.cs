using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FF13Randomizer
{
    public class FormattingMap
    {
        private Dictionary<string, Func<object, string>> map = new Dictionary<string, Func<object, string>>();

        public void addMapping(string name, Func<object, string> replace)
        {
            map.Add(name, replace);
        }

        public string apply(string format, object obj)
        {
            map.Keys.ToList().ForEach(key => format = format.Replace($"${{{key}}}", map[key].Invoke(obj)));
            return format;
        }
    }
}
