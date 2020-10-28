
using ATN.Utils.MachineLearning.Reinforcement.Base;
using ATN.Utils.MachineLearning.Reinforcement.Memory;
using ATN.Utils.ObjectExt;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATN.Utils.MachineLearning.Reinforcement.Environment
{

    public abstract class Environment<S, A> : IEnvironment<S, A>
    {
        protected int index = 0;
        protected List<S> states;

        public object DebugInfo { get; protected set; }

        public S State
        {
            get
            {
                return states[index];
            }
        }

        public bool IsDone
        {
            get
            {
                return !(this.index < states.Count-1);
            }
        }

        public abstract int ActionCount { get; }

        public Environment(IEnumerable<S> states)
        {
            this.states = states.ToList();
        }

        public S Reset()
        {
            this.index = 0;

            return State;
        }

        public (double, S, bool, object) Step(A action)
        {
            var reward = StepAction(action);
            index += 1;

            return (reward, State, IsDone, DebugInfo);

        }

        protected abstract double StepAction(A action);

    }

    //public abstract class Environment : Environment<ModelState, ModelAction>
    //{
    //    public Environment(List<ModelState> states) : base(states)
    //    {
    //    }
    //}
}
