using ATN.Utils.MachineLearning.Reinforcement.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATN.Utils.MachineLearning.Reinforcement.Memory
{
    public interface IMemory
    {
        ModelState State { get; set; }

        ModelAction Action { get; set; }

        double Reward { get; set; }

        bool Done { get; set; }

        ModelState ResultingState { get; set; }

        bool IsComplete { get; }
    }
}
