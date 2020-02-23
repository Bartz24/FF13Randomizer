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
    public partial class FlagInfoValue : UserControl
    {
        public FlagInfoValue()
        {
            InitializeComponent();
        }

        public void setEvents()
        {
            FlagValue.Range.OnAnyValueChanged += RangeValueChanged;

            RangeValueChanged(null, null);
            numericUpDown1.ValueChanged += NumericUpDown1_ValueChanged;
            numericUpDown2.ValueChanged += NumericUpDown2_ValueChanged;
            numericUpDown3.ValueChanged += NumericUpDown3_ValueChanged;
        }

        private void RangeValueChanged(object sender, EventArgs e)
        {
            numericUpDown1.Minimum = FlagValue.Range.MinRange.MinRange;
            numericUpDown1.Maximum = FlagValue.Range.MinRange.MaxRange;
            numericUpDown1.Value = FlagValue.Range.MinRange.Value;
            numericUpDown2.Minimum = FlagValue.Range.MinRange.MinRange;
            numericUpDown2.Maximum = FlagValue.Range.MaxRange.MaxRange;
            numericUpDown2.Value = FlagValue.Range.Value;
            numericUpDown3.Minimum = FlagValue.Range.MaxRange.MinRange;
            numericUpDown3.Maximum = FlagValue.Range.MaxRange.MaxRange;
            numericUpDown3.Value = FlagValue.Range.MaxRange.Value;
        }

        private void NumericUpDown3_ValueChanged(object sender, EventArgs e)
        {
            FlagValue.Range.MaxRange.Value = (int)((NumericUpDown)sender).Value;
        }

        private void NumericUpDown2_ValueChanged(object sender, EventArgs e)
        {
            FlagValue.Range.Value = (int)((NumericUpDown)sender).Value;
        }

        private void NumericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            FlagValue.Range.MinRange.Value = (int)((NumericUpDown)sender).Value;
        }

        public FlagValue FlagValue { get; set; }
    }
}
