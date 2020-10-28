using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATN.Utils.MathExt.Numerical
{
    public static class Trigonometry
    {


    }

    public class AngleRadian
    {
        public double Value { get; set; }

        public AngleRadian(double value)
        {
            this.Value = value;
        }

        public AngleDegree ToRadian()
        {
            return new AngleDegree(this.Value.ToDegree());
        }

        public override string ToString()
        {
            return Value.ToString();
        }
    }

    public class AngleDegree
    {
        public double Value { get; set; }

        public AngleDegree(double value)
        {
            this.Value = value;
        }

        public AngleRadian ToRadian()
        {
            return new AngleRadian(this.Value.ToRadians());
        }

        public override string ToString()
        {
            return Value.ToString();
        }
    }
}
