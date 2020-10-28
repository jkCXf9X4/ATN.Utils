using ATN.Utils.ObjectExt;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATN.Utils.MachineLearning.Reinforcement.Statistics
{
    public class AnalyzeActions<A>
    {
        public int Counter= 0;
        public int PossibleActions = 0;
        List<int> actionCounter;

        public AnalyzeActions()
        {
            if (!typeof(A).IsEnum)
            {
                throw new ArgumentException("T must be an enumerated type");
            }

            PossibleActions = Enum.GetValues(typeof(A)).Length;

            actionCounter = (0).ToList(PossibleActions);
        }

        public void Step(A action)
        {
            Counter += 1;

            var actionInt = (int)Convert.ChangeType(action, typeof(int));
            actionCounter[actionInt] += 1;
        }

        public List<int> GetCounter()
        {
            return actionCounter;
        }


        public List<double> GetActionPercentage()
        {
            var percent = new List<double>();
            for (int i = 0; i < PossibleActions; i++)
            {
                double value = (double)actionCounter[i] / this.Counter;
                percent.Add(value);
            }
            return percent;
        }

        public override string ToString()
        {
            return String.Join(", ", actionCounter);
        }
    }
}
