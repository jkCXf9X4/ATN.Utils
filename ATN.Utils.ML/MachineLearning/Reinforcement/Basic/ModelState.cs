


using System;
using System.Collections.Generic;
using System.Linq;

namespace ATN.Utils.MachineLearning.Reinforcement.Base
{
    public class ModelState
    {
        public double[][][] state;
        protected int dim;

        public ModelState(double[][][] state)
        {
            this.state = state;
            this.dim = 3;
        }
        public ModelState(double[][] state) : this(new double[][][] { state }) { this.dim = 2; }

        public ModelState(double[] state) : this(new double[][] { state }) { this.dim = 1; }

        public (int, int, int) Size
        {
            get
            {
                return (this.state.Length, this.state[0].Length, this.state[0][0].Length);
            }
        }

        public static List<ModelState> ToStates(double[][][] states)
        {
            var temp = new List<ModelState>();
            foreach (double[][] i in states)
            {
                var instance = new ModelState(i);
                temp.Add(instance);
            }
            return temp;
        }

        public static double[][][] ToArray(List<ModelState> states)
        {
            return states.Select(x => x.state[0]).ToArray();
        }
    }
}
