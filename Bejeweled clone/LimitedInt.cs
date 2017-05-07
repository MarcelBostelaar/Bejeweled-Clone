using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bejeweled_clone
{
    class LimitedInt
    {
        int low, high, value;
        /// <summary>
        /// An under and overflowing integer that is limited to a specific range.
        /// </summary>
        /// <param name="lowerLimit"></param>
        /// <param name="UpperLimit"></param>
        public LimitedInt(int lowerLimit, int UpperLimit)
        {
            low = lowerLimit;
            high = UpperLimit;
            Value = 0;
        }
        public int Value { get { return value; } set {
                if (value > high)
                {
                    var i = high - low +1;
                    this.value = value - i;
                    return;
                }
                if (value < low)
                {
                    var i = high - low + 1;
                    this.value = value + i;
                    return;
                }
                this.value = value;
            }
        }
        public static LimitedInt operator ++(LimitedInt variable)
        {
            variable.Value++;
            return variable;
        }
        public static LimitedInt operator --(LimitedInt variable)
        {
            variable.Value--;
            return variable;
        }
        public static LimitedInt operator +(LimitedInt variable, int num)
        {
            variable.Value = variable.Value + num;
            return variable;
        }
        public static LimitedInt operator -(LimitedInt variable, int num)
        {
            variable.Value = variable.Value - num;
            return variable;
        }
        public static LimitedInt operator *(LimitedInt variable, int num)
        {
            variable.Value = variable.Value * num;
            return variable;
        }
        public static LimitedInt operator /(LimitedInt variable, int num)
        {
            variable.Value = variable.Value / num;
            return variable;
        }
    }
}
