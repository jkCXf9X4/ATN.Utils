using ATN.Utils.MachineLearning.Reinforcement.Base;
using ATN.Utils.MachineLearning.Reinforcement.Memory;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATN.Utils.MachineLearning.Reinforcement.Environment
{
    public interface IEnvironment<S, A>
    {
        S State { get; }

        S Reset();

        (double, S, bool, object) Step(A action);

        bool IsDone { get; }

        int ActionCount { get; }
    }

    public interface IEnvironment : IEnvironment<ModelState, ModelAction>
    {

    }
}
