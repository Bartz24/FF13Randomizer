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
    public partial class FlagInfo : UserControl
    {
        public FlagInfo()
        {
            InitializeComponent();

            Update();
        }
        private Flag flag = Flag.Empty;
        public Flag Flag
        {
            get => flag;
            set
            {
                if (value != flag)
                {
                    flag = value;
                    Update();
                    panel1.Controls.Clear();

                    IFlagData flagData = (IFlagData)Flag.FlagData;
                    if (flagData != null)
                    {
                        UserControl control = flagData.getFlagInfo();

                        control.Dock = DockStyle.Fill;
                        panel1.Controls.Add(control);
                    }
                    panel1.Refresh();
                }
            }
        }

        public new void Update()
        {
            this.Visible = Flag != Flag.Empty;

            labelName.Text = Flag.Text;            
            textBoxDesc.Text = Flag.FullDescription;

            this.panel1.Enabled = Flag.FlagEnabled;

            base.Update();
        }
    }
}
