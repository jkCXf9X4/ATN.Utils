using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ATN.Utils.MachineLearning.Activation
{
    public interface IActivation
    {
        double Activate(double value);

        double[] Activate(double[] values);

        double Derivate(double value);

        double[] Derivate(double[] values);
    }

    public abstract class ActivationBase :IActivation
    {
        public abstract double Activate(double value);

        public virtual double[] Activate(double[] values)
        {
            return values.Select(x=> this.Activate(x)).ToArray();
        }

        public abstract double Derivate(double value);

        public virtual double[] Derivate(double[] values)
        {
            return values.Select(x => this.Derivate(x)).ToArray();
        }
    }
}
