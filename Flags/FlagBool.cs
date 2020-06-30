using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FF13Randomizer
{
    public partial class FlagBool : UserControl, IFlagData
    {

        public FlagBool(Flag flag)
        {
            InitializeComponent();

            checkBox1.CheckedChanged += new EventHandler(flag.OnChangedEvent);
        }

        public string getDescription(string format)
        {
            return GetFormattingMap().apply(format, this);
        }

        public Flag getParentFlag()
        {
            Control control = this;
            while (!(control is Flag))
            {
                if (control.Parent == null)
                    return null;
                control = control.Parent;
            }
            return (Flag) control;
        }

        public UserControl getFlagInfo()
        {
            return null;
        }

        public FormattingMap GetFormattingMap()
        {
            FormattingMap map = new FormattingMap();
            map.addMapping("Value", flagBool => ((FlagBool)flagBool).Value.ToString());
            return map;
        }

        public string getFlagString()
        {
            throw new NotImplementedException();
        }

        public string readFlagString(string value, bool simulate)
        {
            throw new NotImplementedException();
        }

        public bool Value
        {
            get => checkBox1.Checked;
            set => checkBox1.Checked = value;
        }

        public string Name {
            get => checkBox1.Text;
            set => checkBox1.Text = value;
        }
    }
}
