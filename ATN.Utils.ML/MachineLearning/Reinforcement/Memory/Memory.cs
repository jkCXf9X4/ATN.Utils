using ATN.Utils.MachineLearning.Reinforcement.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATN.Utils.MachineLearning.Reinforcement.Memory
{
    public class Memory : IMemory
    {
        public ModelState State { get; set; }

        public ModelAction Action { get; set; }

        public double Reward { get; set; }

        public bool Done { get; set; }

        public ModelState ResultingState { get; set; }

        public Memory()
        {

        }

        public Memory(ModelState state, ModelAction action, double reward, bool done, ModelState resultingState)
        {
            this.State = state;
            this.Action = action;
            this.Reward = reward;
            this.Done = done;
            this.ResultingState = resultingState;
        }

        public bool IsComplete
        {
            get
            {
                return State != null &&
                    Action != null &&
                    ResultingState != null;
            }
        }
    }
}
