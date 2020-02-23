using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FF13Data
{
    public class TextDialog
    {
        public string Text { get; set; }
        public string Singular { get; set; }
        public string Plural { get; set; }

        public string GetFormattedOutput(int id)
        {
            string output = "{dialog " + id;

            if (!String.IsNullOrWhiteSpace(Singular))
                output += ", singular=\"" + Singular.TrimEnd() + " \"";
            if (!String.IsNullOrWhiteSpace(Plural))
                output += ", plural=\"" + Plural.TrimEnd() + "\"";
            output += "}\n";
            output += Text + "\n";
            output += "{/dialog}\n\n";
            return output;
        }
    }
}
