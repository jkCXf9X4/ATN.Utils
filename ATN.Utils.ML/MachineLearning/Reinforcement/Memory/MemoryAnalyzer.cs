using ATN.Utils.MachineLearning.Reinforcement.Base;
using ATN.Utils.MachineLearning.Reinforcement.Memory;
using ATN.Utils.ObjectExt;
using ATN.Utils.Trading.Forex.Wallet;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATN.Utils.MachineLearning.Reinforcement.Memory
{
    public class MemoryAnalyzer
    {
        protected List<IMemory> memories = new List<IMemory>();

        public MemoryAnalyzer()
        {

        }

        public int Count
        {
            get { return memories.Count; }
        }

        public MemoryAnalyzer(List<IMemory> memories)
        {
            this.memories = memories;
        }

        public void Add(IMemory memory)
        {
            memories.Add(memory);
        }

        public List<ModelState> GetStates()
        {
            return memories.Select(x => x.State).ToList();
        }

        public List<ModelAction> GetActions()
        {
            return memories.Select(x => x.Action).ToList();
        }

        public List<double> GetRewards()
        {
            return memories.Select(x => x.Reward).ToList();
        }

        public List<ModelState> GetResultingStates()
        {
            return memories.Select(x => x.ResultingState).ToList();
        }

        public List<int> GetActionCount()
        {
            var counter = (0).ToList(4);
            List<ModelAction> actions = GetActions();

            foreach (var action in actions)
            {
                counter[action.Action] += 1;
            }
            return counter;
        }

        public List<double> GetActionPercentage()
        {
            return GetActionCount().Select(x => x / (double)memories.Count).ToList();
        }
    }
}
