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
    public partial class Flag : UserControl
    {
        public event EventHandler OnChanged;

        public Flag()
        {
            InitializeComponent();
            checkBoxEnabled.CheckedChanged += OnChangedEvent;

        }

        public Flag Register()
        { 
            Flags.flags.Add(this);
            return this;

        }

        public Flag SetFlagData(Control flagData = null)
        {
            FlagData = flagData;
            if (FlagData != null)
            {
                FlagData.Dock = DockStyle.Fill;
                panel1.Controls.Add(FlagData);
            }
            return this;
        }

        public string DescriptionFormat { get; set; } = "";
        public string Description
        {
            get
            {
                if (FlagData == null || !(FlagData is IFlagData))
                    return DescriptionFormat;
                return ((IFlagData)FlagData).getDescription(DescriptionFormat);
            }
        }

        public string FullDescriptionFormat { get; set; } = "";
        public string FullDescription
        {
            get
            {
                if (FullDescriptionFormat == "")
                    return Description;
                if (FlagData == null || !(FlagData is IFlagData))
                    return FullDescriptionFormat;
                return ((IFlagData)FlagData).getDescription(FullDescriptionFormat);
            }
        }
        [EditorBrowsable(EditorBrowsableState.Always)]
        [Browsable(true)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        [Bindable(true)]
        public override string Text
        {
            get => checkBoxEnabled.Text;
            set => checkBoxEnabled.Text = value;
        }

        public bool FlagEnabled
        {
            get => checkBoxEnabled.Checked;
            set => checkBoxEnabled.Checked = value;
        }

        public string FlagID { get; set; }

        public Control FlagData { get; set; }        

        public static readonly Flag Empty = emptyFlag();

        private static Flag emptyFlag()
        {
            Flag flag = new Flag();
            flag.Text = "";
            return flag;
        }

        public void OnChangedEvent(object sender = null, EventArgs e = null)
        {
            labelDesc.Text = Description;
            if (FlagData != null)
                FlagData.Enabled = checkBoxEnabled.Checked;
            if (OnChanged != null)
                OnChanged.Invoke(this, null);
        }
    }
}
