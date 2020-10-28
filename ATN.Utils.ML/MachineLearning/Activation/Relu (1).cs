using System;
using System.Collections.Generic;
using System.Text;

namespace ATN.Utils.MachineLearning.Activation
{
    public class ReLU : ActivationBase
    {
        public ReLU()
        {

        }

        public override double Activate(double value)
        {
            if (value < 0)
            {
                return 0;
            }
            else
            {
                return value;
            }
        }

        public override double Derivate(double value)
        {
            if (value < 0)
            {
                return 0;
            }
            else
            {
                return 1;
            }
        }
    }
}
