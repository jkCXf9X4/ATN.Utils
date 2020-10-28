using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ATN.Utils.MachineLearning.Activation
{
    public class SoftMax : ActivationBase
    {
        public SoftMax()
        {

        }

        public override double Activate(double value)
        {
            throw new NotImplementedException();
        }

        public override double[] Activate(double[] values)
        {
            var z_exp = values.Select(Math.Exp);
 
            var sum_z_exp = z_exp.Sum();

            var softmax = z_exp.Select(i => i / sum_z_exp).ToArray();

            return softmax;
        }

        public override double Derivate(double value)
        {
            throw new NotImplementedException();
        }

        public override double[] Derivate(double[] values)
        {
            throw new NotImplementedException();
        }
    }
}
