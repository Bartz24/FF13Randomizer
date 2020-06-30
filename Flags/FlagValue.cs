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
    public partial class FlagValue : UserControl, IFlagData
    {
        // When advanced setting is on...
        public enum ValueAdvancedLevel
        {
            None = 0, // nothing is shown
            Value = 1, // only the value can be changed
            MinMax = 2 // min max can be adjusted
        }

        public ValueAdvancedLevel Level { get; set; } = ValueAdvancedLevel.Value;

        public FlagValue(Flag flag)
        {
            InitializeComponent();

            Range.MinRange.MinRange = 0;
            Range.MinRange.Value = 0;
            Range.MaxRange.MaxRange = 100;
            Range.MaxRange.Value = 100;
            Range.Value = 20;
            Range.OnAnyValueChanged += Range_OnValueChanged;
            Range.OnAnyValueChanged(null, null);

            trackBar1.ValueChanged += TrackBar1_ValueChanged + new EventHandler(flag.OnChangedEvent);
            numericUpDown1.ValueChanged += NumericUpDown1_ValueChanged + new EventHandler(flag.OnChangedEvent);
        }

        private void Range_OnValueChanged(object sender, EventArgs e)
        {
            numericUpDown1.Minimum = Range.MinRange.Value;
            numericUpDown1.Maximum = Range.MaxRange.Value;
            numericUpDown1.Value = Range.Value;
            trackBar1.Minimum = Range.MinRange.Value;
            trackBar1.Maximum = Range.MaxRange.Value;
            trackBar1.Value = Range.Value;
        }

        private void NumericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            trackBar1.Value = (int) numericUpDown1.Value;
            Range.Value = (int)numericUpDown1.Value;
        }

        private void TrackBar1_ValueChanged(object sender, EventArgs e)
        {
            numericUpDown1.Value = trackBar1.Value;
            Range.Value = trackBar1.Value;
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
            FlagInfoValue flagInfo = new FlagInfoValue
            {
                FlagValue = this
            };
            flagInfo.setEvents();
            return flagInfo;
        }

        public FormattingMap GetFormattingMap()
        {
            FormattingMap map = new FormattingMap();
            map.addMapping("Value", flagValue => ((FlagValue)flagValue).Range.Value.ToString());
            map.addMapping("Min", flagValue => ((FlagValue)flagValue).Range.MinRange.Value.ToString());
            map.addMapping("Max", flagValue => ((FlagValue)flagValue).Range.MaxRange.Value.ToString());
            return map;
        }

        public string getFlagString()
        {
            switch (Level)
            {
                case ValueAdvancedLevel.None:
                    return "";
                case ValueAdvancedLevel.Value:
                    return $"[{Range.Value}]";
                case ValueAdvancedLevel.MinMax:
                    return $"[{Range.MinRange.Value}:{Range.Value}:{Range.MaxRange.Value}]";
            }
            return "";
        }

        public string readFlagString(string value, bool simulate)
        {
            switch (Level)
            {
                case ValueAdvancedLevel.None:
                    return value;
                case ValueAdvancedLevel.Value:
                    if (value.Contains('[') && value.Contains(']'))
                    {
                        int val = Int32.Parse(value.Substring(value.IndexOf('[') + 1, value.IndexOf(']') - (value.IndexOf('[') + 1)));
                        if (!simulate)
                            Range.Value = val;
                        return value.Substring(0, value.IndexOf('['));
                    }
                    else
                        return value;
                case ValueAdvancedLevel.MinMax:
                    if (value.Contains('[') && value.Contains(']'))
                    {
                        string[] contents = value.Substring(value.IndexOf('[') + 1, value.IndexOf(']') - (value.IndexOf('[') + 1)).Split(':');
                        int[] values = { Int32.Parse(contents[0]), Int32.Parse(contents[2]), Int32.Parse(contents[1]) };
                        if (!simulate)
                        {
                            Range.MinRange.Value = values[0];
                            Range.MaxRange.Value = values[1];
                            Range.Value = values[2];
                        }
                        return value.Substring(0, value.IndexOf('['));
                    }
                    else
                        return value;
            }
            return value;
        }

        public NumericRangeMinMax<int> Range { get; set; } = new NumericRangeMinMax<int>();
    }
}
