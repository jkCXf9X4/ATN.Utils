using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATN.Utils.MachineLearning.DataPreparation.Scaler
{

     public interface IScaler<I, O>
    {
        void Fit(IEnumerable<I> data);

        O Transform(I data);

        IEnumerable<O> Transform(IEnumerable<I> data);

        I Reverse(O data);

        IEnumerable<I> Reverse(IEnumerable<O> data);

    }
}
