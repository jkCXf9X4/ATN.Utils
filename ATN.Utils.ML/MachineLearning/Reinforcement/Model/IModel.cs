using ATN.Utils.MachineLearning.Reinforcement.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATN.Utils.MachineLearning.Reinforcement.Model
{
    public interface IModel
    {
        (int, int) InputShape { get; }

        int OutputShape { get; }

        ModelAction Predict(ModelState state);

        List<ModelAction> Predict(List<ModelState> states);

        double Fit(List<ModelState> states, List<ModelAction> targets, int batchSize, int epochs);

        bool New();

        bool Save();

        bool Load(string filename);
    }
}
