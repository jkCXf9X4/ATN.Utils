using ATN.Utils.MachineLearning.Reinforcement.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATN.Utils.MachineLearning.Reinforcement.Model
{
    public interface ITargetChaserModels : IModel
    {
        List<ModelAction> PredictTarget(List<ModelState> states);
        bool UpdateTarget();
    }
}
