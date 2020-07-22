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
    public partial class FlagValue : Flag
    {
        // When advanced setting is on...
        public enum ValueAdvancedLevel
        {
            None = 0, // nothing is shown
            Value = 1, // only the value can be changed
            MinMax = 2 // min max can be adjusted
        }

        public ValueAdvancedLevel Level { get; set; } = ValueAdvancedLevel.Value;

        public FlagValue(int min, int value, int max)
        {
            InitializeComponent();

            Range.MinRange.MinRange = min;
            Range.MinRange.Value = min;
            Range.MaxRange.MaxRange = max;
            Range.MaxRange.Value = max;
            Range.Value = value;
            Range.OnAnyValueChanged += Range_OnValueChanged;
            Range.OnAnyValueChanged(null, null);

            trackBar1.ValueChanged += TrackBar1_ValueChanged + new EventHandler(OnChangedEvent);
            numericUpDown1.ValueChanged += NumericUpDown1_ValueChanged + new EventHandler(OnChangedEvent);
            trackBar1.Location = new Point(trackBar1.Location.X, ExtraInfoTop);
            numericUpDown1.Location = new Point(numericUpDown1.Location.X, ExtraInfoTop);

            trackBar1.MouseWheel += TrackBar1_MouseWheel;
        }

        private void TrackBar1_MouseWheel(object sender, MouseEventArgs e)
        {
            HandledMouseEventArgs ee = (HandledMouseEventArgs)e;
            ee.Handled = false;
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
            trackBar1.Value = (int)numericUpDown1.Value;
            Range.Value = (int)numericUpDown1.Value;
        }

        private void TrackBar1_ValueChanged(object sender, EventArgs e)
        {
            numericUpDown1.Value = trackBar1.Value;
            Range.Value = trackBar1.Value;
        }

        public override FormattingMap DescriptionFormatting
        {
            get
            {
                FormattingMap map = base.DescriptionFormatting;
                map.addMapping("Value", flagValue => ((FlagValue)flagValue).Range.Value.ToString());
                map.addMapping("Min", flagValue => ((FlagValue)flagValue).Range.MinRange.Value.ToString());
                map.addMapping("Max", flagValue => ((FlagValue)flagValue).Range.MaxRange.Value.ToString());
                return map;
            }
        }

        public override string GetExtraFlagString()
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

        public override void SetExtraFlagString(string value, bool simulate)
        {
            switch (Level)
            {
                case ValueAdvancedLevel.None:
                    return;
                case ValueAdvancedLevel.Value:
                    int val = Int32.Parse(value);
                    if (!simulate)
                        Range.Value = val;
                    return;
                case ValueAdvancedLevel.MinMax:
                    string[] contents = value.Split(':');
                    int[] values = { Int32.Parse(contents[0]), Int32.Parse(contents[2]), Int32.Parse(contents[1]) };
                    if (!simulate)
                    {
                        Range.MinRange.Value = values[0];
                        Range.MaxRange.Value = values[1];
                        Range.Value = values[2];
                    }
                    return;
            }
        }

        public NumericRangeMinMax<int> Range { get; set; } = new NumericRangeMinMax<int>();

        public override int FlagHeight => base.FlagHeight + 35;
        public override void OnChangedEvent(object sender = null, EventArgs e = null)
        {
            base.OnChangedEvent(sender, e);
            trackBar1.Enabled = numericUpDown1.Enabled = FlagEnabled;
        }
    }
}
