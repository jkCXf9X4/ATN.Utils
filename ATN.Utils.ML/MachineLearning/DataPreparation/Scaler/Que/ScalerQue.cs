using ATN.Utils.Collection.Que;
using ATN.Utils.MachineLearning.DataPreparation.Scaler;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATN.Utils.MachineLearning.DataPreparation.Scaler.Que
{
    public class ScalerQue<I, O> : FixedSizedQueue<O>
    {
        protected Scaler<I, O> scaler;

        public ScalerQue(Scaler<I, O> scaler, int size): base(size)
        {
            this.scaler = scaler;
        }
        /// <summary>
        /// Returns true if que is full
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public bool Add(I obj)
        {
            O scaledObj = scaler.Transform(obj);

            return base.Enqueue(scaledObj);
        }
    }
}
