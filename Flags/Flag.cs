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
    public partial class Flag : UserControl
    {
        public event EventHandler OnChanged;

        public Flag()
        {
            InitializeComponent();
            checkBoxEnabled.CheckedChanged += OnChangedEvent;
            Experimental = experimental;
        }

        //public override Color BackColor => FlagID == null ? Color.White : Color.FromArgb(Math.Abs(FlagID.GetHashCode() % 255), Math.Abs((FlagID.GetHashCode() * 7) % 255), Math.Abs((FlagID.GetHashCode() - 54) % 255));

        public Flag Register(FlagType type, bool isTweak = false)
        {
            if (isTweak)
                Tweaks.tweaks.Add(this);
            else
                Flags.flags.Add(this);
            FlagType = type;
            return this;

        }
        public FlagType FlagType { get; set; }

        private bool experimental = false;
        public bool Experimental
        {
            get => experimental;
            set
            {
                experimental = value;
                if (experimental)
                    checkBoxEnabled.BackColor = experimental ? Color.Gold : Color.White;
            }
        }

        public string DescriptionFormat { get; set; } = "";
        public string Description
        {
            get => (experimental ? "[EXPERIMENTAL]\n" : "") + DescriptionFormatting.apply(CurrentDescriptionFormat, this);
        }

        public virtual string CurrentDescriptionFormat
        {
            get => DescriptionFormat;
        }

        public virtual FormattingMap DescriptionFormatting
        {
            get => new FormattingMap();
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
        private string flagID;
        public string FlagID
        {
            get => flagID; 
            set
            {
                if (Flags.flags.Where(f => f != this && f.FlagID == value).Count() + Tweaks.tweaks.Where(f => f != this && f.FlagID == value).Count() > 0)
                    throw new Exception("Duplicate name for the " + value + " flag already exists!");
                flagID = value;
            }
        }

        public string GetFlagString()
        {
            if (!this)
                return "";
            string output = "-" + FlagID;
            output += GetExtraFlagString();
            return output;
        }

        public virtual string GetExtraFlagString()
        {
            return "";
        }

        public void SetFlagString(string value, bool simulate)
        {
            string input = value;
            string name;
            if (input.Contains("["))
                name = input.Substring(1, input.IndexOf('[') - 1);
            else
                name = input.Substring(1);
            if (name == FlagID)
            {
                if (!simulate)
                    FlagEnabled = true;
                if (input.Contains("[") && input.Contains("]"))
                    SetExtraFlagString(input.Substring(input.IndexOf("[") + 1, input.IndexOf("]") - input.IndexOf("[") - 1), simulate);
            }
        }

        public virtual void SetExtraFlagString(string value, bool simulate)
        {
        }

        public static readonly Flag Empty = EmptyFlag();

        private static Flag EmptyFlag()
        {
            Flag flag = new Flag();
            flag.Text = "";
            return flag;
        }

        public virtual void OnChangedEvent(object sender = null, EventArgs e = null)
        {
            labelDesc.Text = Description;
            if (OnChanged != null)
                OnChanged.Invoke(this, null);
        }

        public FF13Data.Random Random { get; set; }

        public void ResetRandom(int seed)
        {
            Random = new FF13Data.Random(seed + FlagID[0] * FlagID.Length - Description.Length);
        }

        public void SetRand()
        {
            RandomNum.SetRand(Random);
        }

        protected int ExtraInfoTop
        {
            get => Math.Max(55, labelDesc.Height + 35);
        }

        public virtual int FlagHeight
        {
            get => ExtraInfoTop;
        }

        public override Size MaximumSize { get => new Size(base.MaximumSize.Width, FlagHeight); set => base.MaximumSize = value; }
        public override Size MinimumSize { get => new Size(base.MinimumSize.Width, FlagHeight); set => base.MinimumSize = value; }

        public static implicit operator bool(Flag f)
        {
            return f.FlagEnabled;
        }
    }
}
