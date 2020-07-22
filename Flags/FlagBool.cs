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
    public partial class FlagBool : Flag
    {
        public FlagBool(string extraName)
        {
            InitializeComponent();
            checkExtra.Location = new Point(checkExtra.Location.X, ExtraInfoTop);
            labelExtra.Location = new Point(labelExtra.Location.X, ExtraInfoTop);
            checkExtra.Text = extraName;

            checkExtra.CheckedChanged += new EventHandler(OnChangedEvent);
        }

        public override int FlagHeight => base.FlagHeight + 50;

        public bool ExtraSelected
        {
            get => checkExtra.Checked;
            set => checkExtra.Checked = value;
        }

        public string ExtraDescriptionFormat { get; set; }
        public string ExtraDescription
        {
            get => DescriptionFormatting.apply(ExtraDescriptionFormat, this);
        }
        public override void OnChangedEvent(object sender = null, EventArgs e = null)
        {
            base.OnChangedEvent(sender, e);
            labelExtra.Text = ExtraDescription;
            checkExtra.Enabled = labelExtra.Enabled = FlagEnabled;
            if (!FlagEnabled)
                checkExtra.Checked = false;
        }
        public override string GetExtraFlagString()
        {
            if (ExtraSelected)
            { 
                return "[On]";
            }
            return "";
        }

        public override void SetExtraFlagString(string value, bool simulate)
        {
            if(value == "On" && !simulate)
            {
                ExtraSelected = true;
            }
        }
    }
}
