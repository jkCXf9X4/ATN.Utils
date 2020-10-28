using ATN.Utils.MachineLearning.Reinforcement.Base;
using ATN.Utils.MachineLearning.Reinforcement.Memory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATN.Utils.MachineLearning.Reinforcement.Agent
{
    public interface IAgent
    {
        void Remember(IMemory memory);

        /// <summary>
        /// Returns Action dependent on state
        /// </summary>
        /// <param name="state"></param>
        /// <returns></returns>
        ModelAction Evaluate(ModelState state);

        double Replay(int epoch, int batchSize);
    }
}
