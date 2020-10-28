using ATN.Utils.Collection.Que;
using ATN.Utils.MachineLearning.Reinforcement.Base;
using ATN.Utils.MachineLearning.Reinforcement.Memory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATN.Utils.MachineLearning.Reinforcement.ReplayQue
{
    public interface IReplay : IQueue<IMemory>
    {
        new void Enqueue(IMemory memory);

        List<IMemory> GetList();
    }
}
