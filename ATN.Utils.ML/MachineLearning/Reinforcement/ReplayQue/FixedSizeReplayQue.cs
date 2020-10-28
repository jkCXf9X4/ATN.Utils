using ATN.Utils.Collection.Que;
using ATN.Utils.MachineLearning.Reinforcement.Base;
using ATN.Utils.MachineLearning.Reinforcement.Memory;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATN.Utils.MachineLearning.Reinforcement.ReplayQue
{
    public class FixedSizeReplayQue : FixedSizedQueue<IMemory>, IReplay
    {
        public FixedSizeReplayQue(int size) : base(size)
        {
        }
    }
}
