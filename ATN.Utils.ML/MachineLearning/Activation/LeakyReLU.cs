using System;
using System.Collections.Generic;
using System.Text;

namespace ATN.Utils.MachineLearning.Activation
{
    public class LeakyReLU : ActivationBase
    {
        double NegativeSlope { get; set; }
        double PossitiveSlope { get; set; }
        public LeakyReLU(double negativeSlope = 0.25, double possitiveSlope = 1)
        {
            this.NegativeSlope = negativeSlope;
            this.PossitiveSlope = possitiveSlope;
        }
        public override double Activate(double value)
        {
            if (value < 0)
            {
                return NegativeSlope * value;
            }
            else
            {
                return PossitiveSlope * value;
            }
        }

        public override double Derivate(double value)
        {
            if (value < 0)
            {
                return NegativeSlope;
            }
            else
            {
                return PossitiveSlope;
            }
        }
    }
}
