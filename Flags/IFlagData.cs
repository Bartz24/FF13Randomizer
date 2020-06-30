using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FF13Randomizer
{
    interface IFlagData
    {
        FormattingMap GetFormattingMap();
        string getDescription(string format);
        Flag getParentFlag();
        UserControl getFlagInfo();
        string getFlagString();
        string readFlagString(string value, bool simulate);
    }
}
