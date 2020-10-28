using System;
using System.Collections.Generic;
using System.Text;

namespace ATN.Utils.MachineLearning.Activation
{
    public class Sigmoid : ActivationBase
    {
        public Sigmoid()
        {

        }

        public override double Activate(double value)
        {
            return 1.0 / (1.0 + System.Math.Exp(-value));
        }

        public override double Derivate(double value)
        {
            return Activate(value) * (1 - Activate(value));
        }
    }
}
