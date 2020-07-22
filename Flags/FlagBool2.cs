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
    public partial class FlagBool2 : Flag
    {
        public FlagBool2(string extraName, string extraName2)
        {
            InitializeComponent();
            checkExtra.Location = new Point(checkExtra.Location.X, ExtraInfoTop);
            labelExtra.Location = new Point(labelExtra.Location.X, ExtraInfoTop + 5);
            checkExtra.Text = extraName;

            checkExtra.CheckedChanged += new EventHandler(OnChangedEvent);

            checkExtra2.Location = new Point(checkExtra2.Location.X, ExtraInfoTop + 50);
            labelExtra2.Location = new Point(labelExtra2.Location.X, ExtraInfoTop + 50 + 5);
            checkExtra2.Text = extraName2;

            checkExtra2.CheckedChanged += new EventHandler(OnChangedEvent);
        }

        public override int FlagHeight => base.FlagHeight + 100;

        public bool ExtraSelected
        {
            get => checkExtra.Checked;
            set => checkExtra.Checked = value;
        }
        public bool ExtraSelected2
        {
            get => checkExtra2.Checked;
            set => checkExtra2.Checked = value;
        }

        public string ExtraDescriptionFormat { get; set; }
        public string ExtraDescriptionFormat2 { get; set; }
        public string ExtraDescription
        {
            get => DescriptionFormatting.apply(ExtraDescriptionFormat, this);
        }
        public string ExtraDescription2
        {
            get => DescriptionFormatting.apply(ExtraDescriptionFormat2, this);
        }
        public override void OnChangedEvent(object sender = null, EventArgs e = null)
        {
            base.OnChangedEvent(sender, e);
            labelExtra.Text = ExtraDescription;
            labelExtra2.Text = ExtraDescription2;
            checkExtra.Enabled = checkExtra2.Enabled = labelExtra.Enabled = FlagEnabled;
            if (!FlagEnabled)
            {
                checkExtra.Checked = false;
                checkExtra2.Checked = false;
            }
        }
        public override string GetExtraFlagString()
        {
            if (!ExtraSelected && !ExtraSelected2)
                return "";
            else
            {
                bool[] values = { ExtraSelected, ExtraSelected2 };
                return "[" + String.Join(":", values.Select(b => b ? "On" : "Off").ToList()) + "]";
            }
        }

        public override void SetExtraFlagString(string value, bool simulate)
        {
            if (value.Contains(":"))
            {
                bool[] values = value.Split(':').Select(s => s == "On").ToArray();
                if (!simulate)
                {
                    ExtraSelected = values[0];
                    ExtraSelected2 = values[1];
                }
            }
        }
    }
}
