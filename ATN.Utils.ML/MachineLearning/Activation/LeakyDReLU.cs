using System;
using System.Collections.Generic;
using System.Text;

namespace ATN.Utils.MachineLearning.Activation
{
    public class LeakyDReLU : ActivationBase
    {
        double NegativeSlope { get; set; }
        double PossitiveSlope { get; set; }
        double Threshhold { get; set; }
        double ThreshholdSlope { get; set; }
        public LeakyDReLU(double negativeSlope = 0.25, double possitiveSlope = 1, double threshhold = 4, double threshholdSlope = 0.25)
        {
            this.NegativeSlope = negativeSlope;
            this.PossitiveSlope = possitiveSlope;
            this.Threshhold = threshhold;
            this.ThreshholdSlope = threshholdSlope;
        }
        public override double Activate(double value)
        {
            if (value < 0)
            {
                return NegativeSlope * value;
            }
            else if (value > Threshhold)
            {
                return value * ThreshholdSlope;
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
            else if (value > Threshhold)
            {
                return ThreshholdSlope;
            }
            else
            {
                return PossitiveSlope;
            }
        }
    }
}
