using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FF13Randomizer
{
    public class NumericRangeMinMax<T> where T : IComparable
    {
        public EventHandler OnAnyValueChanged;
        public NumericRangeMinMax()
        {
            MinRange.OnAnyValueChanged += Any_OnValueChanged;
            MaxRange.OnAnyValueChanged += Any_OnValueChanged;
            MinRange.OnValueChanged += Min_OnValueChanged;
            MaxRange.OnValueChanged += Max_OnValueChanged;
        }

        private void Any_OnValueChanged(object sender, EventArgs e)
        {
            OnAnyValueChanged?.Invoke(this, null);
        }

        private void Max_OnValueChanged(object sender, EventArgs e)
        {
            if (MaxRange.Value.CompareTo(MinRange.Value) < 0)
                MinRange.Value = MaxRange.Value;
            if (MaxRange.Value.CompareTo(Value) < 0)
                Value = MaxRange.Value;
        }

        private void Min_OnValueChanged(object sender, EventArgs e)
        {
            if (MinRange.Value.CompareTo(MaxRange.Value) > 0)
                MaxRange.Value = MinRange.Value;
            if (MinRange.Value.CompareTo(Value) > 0)
                Value = MinRange.Value;
        }

        private T val;
        public NumericRange<T> MinRange { get; set; } = new NumericRange<T>();
        public T Value {
            get => val;
            set
            {
                if (value.CompareTo(MaxRange.Value) > 0)
                    val = MaxRange.Value;
                else if (value.CompareTo(MinRange.Value) < 0)
                    val = MinRange.Value;
                else
                    val = value;
                MaxRange.MinRange = val;
                MinRange.MaxRange = val;
                OnAnyValueChanged?.Invoke(this, null);
            }
        }
        public NumericRange<T> MaxRange { get; set; } = new NumericRange<T>();
    }
}
