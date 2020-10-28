using System;
using System.Collections.Generic;
using System.Text;

namespace ATN.Utils.MachineLearning.Activation
{
    public class Linear : ActivationBase
    {
        public Linear()
        {

        }

        public override double Activate(double value)
        {
            return value;
        }

        public override double Derivate(double value)
        {
            return 1;
        }
    }
}
