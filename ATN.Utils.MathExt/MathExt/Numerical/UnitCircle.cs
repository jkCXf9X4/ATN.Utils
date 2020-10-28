using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATN.Utils.MathExt.Numerical
{
    public class UnitCircle
    {
        public const double UnitCircleCicumference = 2 * System.Math.PI;

        double sectorPercent;
        double sectorCicumference;

        private double x;
        private double y;

        public AngleRadian angleRad { get; private set; }

        public double X
        {
            get
            {
                return System.Math.Round(x, 5);
            }
            private set
            {
                x = value;
            }
        }
        public double Y
        {
            get
            {
                return System.Math.Round(y, 5);
            }

            private set
            {
                y = value;
            }
        }

        public UnitCircle(double sectorPercent)
        {
            this.sectorPercent = sectorPercent;
            sectorCicumference = UnitCircleCicumference * this.sectorPercent;
            angleRad = new AngleRadian(sectorCicumference);
            SetCosAndSin();
        }

        public UnitCircle(AngleDegree angle)
        {
            this.angleRad = angle.ToRadian();
            SetCosAndSin();
        }

        public UnitCircle(AngleRadian angle)
        {
            this.angleRad = angle;
            SetCosAndSin();
        }

        void SetCosAndSin()
        {
            x = System.Math.Cos(angleRad.Value);
            y = System.Math.Sin(angleRad.Value);
        }

        public override string ToString()
        {
            return ToString(";");
        }

        public string ToString(string delimiter = ";")
        {
            var l = new object[] { X.ToString(), Y.ToString() };

            return String.Join(delimiter, l);
        }



    }
}
