using ATN.Utils.MachineLearning.Reinforcement.Memory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATN.Utils.MachineLearning.Reinforcement.ReplayQue
{
    public class FixedSizePrioritizedReplayQue : FixedSizeReplayQue
    {
        readonly double limit;

        public FixedSizePrioritizedReplayQue(int size, double limit = 1.5) : base(size)
        {
            this.limit = limit;
        }

        public new void Enqueue(IMemory memory)
        {
            if ( this.Count < 15)
            {
                var rewards = new MemoryAnalyzer(this.GetList()).GetRewards();
                var average = rewards.Average();
                var std = ATN.Utils.MathExt.Statistics.Basic.PopulationStandardDeviation(rewards);

                var z = System.Math.Abs((memory.Reward - average) / std);

                var randomZ = new Random().NextDouble() * this.limit;
                if (z > randomZ)
                {
                    base.Enqueue(memory);
                }
            }
            else
            {
                base.Enqueue(memory);
            }
        }
    }
}
