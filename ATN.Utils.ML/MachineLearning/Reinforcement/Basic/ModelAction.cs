using ATN.Utils.CollectionsExt.EnumExt;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATN.Utils.MachineLearning.Reinforcement.Base
{


    public class ModelAction
    {
        public double[][] actionRaw;

        public ModelAction(double[][] action)
        {
            this.actionRaw = action;
        }

        public ModelAction(double[] action) : this(new double[][] { action })
        { }

        public int CountActions
        {
            get
            {
                return actionRaw.Length;
            }
        }
        public int Length
        {
            get
            {
                return actionRaw[0].Length;
            }
        }

        public int Action
        {
            get
            {
                return ArgMax();
            }
        }

        public int ArgMax()
        {
            return actionRaw[0].MaxIndex();
        }

        public static double[][] ToActionsArray(List<ModelAction> actions)
        {
            return actions.Select(x => x.actionRaw[0]).ToArray();
        }

        public static List<ModelAction> ToModelActions(double[][] actions)
        {
            var temp = new List<ModelAction>();
            foreach (double[] i in actions)
            {
                temp.Add(new ModelAction(i));
            }
            return temp;
        }
    }
}
