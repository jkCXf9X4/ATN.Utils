using ATN.Utils.MachineLearning.Data.DataSet;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATN.Utils.MachineLearning.Data.TimeStep
{
    public class TimeStepDataSet<X> : DataSet<Data<X, X>>
    {
        public TimeStepDataSet(List<X> values, int offset) :base()
        {
            this.Data = new List<Data<X, X>>();

            if (values.Count <= 0)
            {
                throw new ArgumentNullException(); 
            }

            var xValues = values.GetRange(0, values.Count - offset);
            var yValues = values.GetRange(offset, values.Count - offset);

            for (int i = 0; i < xValues.Count; i++)
            {
                Data.Add(new Data<X, X>(xValues[i], yValues[i]));
            }
        }
    }
}
