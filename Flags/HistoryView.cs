using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using FF13Data;

namespace FF13Randomizer
{
    public partial class HistoryView : UserControl
    {
        public event EventHandler OnSet;

        public HistoryView(UserFlagsSeed usf)
        {
            InitializeComponent();
            FlagString = usf.FlagString;
            Seed = usf.Seed;
            Version = usf.Version;
            Valid = usf.Valid;
            TimeDate = usf.TimeDate;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Clipboard.SetText(FlagString);
            MessageBox.Show("Copied flag string to clipboard!");
        }

        public string FlagString
        {
            get => textFlags.Text;
            set => textFlags.Text = value;
        }

        public string Seed
        {
            get => textSeed.Text;
            set => textSeed.Text = value;
        }

        public string Version
        {
            get => labelVersion.Text;
            set => labelVersion.Text = value;
        }

        public string TimeDate
        {
            get => labelTime.Text.Substring("Created At: ".Length);
            set => labelTime.Text = "Created At: " + value;
        }

        public bool Valid
        {
            get => !labelInvalid.Visible;
            set
            {
                labelInvalid.Visible = !value;
                button12.Enabled = value;
            }
        }

        private void button12_Click(object sender, EventArgs e)
        {
            if (OnSet != null)
                OnSet.Invoke(this, null);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Clipboard.SetText(Seed);
            MessageBox.Show("Copied seed to clipboard!");
        }
    }
}
