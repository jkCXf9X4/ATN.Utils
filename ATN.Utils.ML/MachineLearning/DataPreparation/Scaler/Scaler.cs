using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATN.Utils.MachineLearning.DataPreparation.Scaler
{
    [Serializable]
    public abstract class Scaler<I, O> : IScaler<I, O>
    {
        public abstract void Fit(IEnumerable<I> data);

        public abstract O Transform(I data);

        public IEnumerable<O> Transform(IEnumerable<I> data)
        {
            return data.Select(x => this.Transform(x));
        }

        public abstract I Reverse(O data);

        public IEnumerable<I> Reverse(IEnumerable<O> data)
        {
            return data.Select(x => this.Reverse(x));
        }
    }
}
