using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATN.Utils.MachineLearning.Reinforcement.Basic
{
    public interface IModelData<T>
    {
        T GetData();

        string[] GetDataNames();

        bool IsPrimed { get; }
    }

    public interface IModelData : IModelData<double[]>
    {

    }
}
