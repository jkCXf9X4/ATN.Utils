using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATN.Utils.MachineLearning.Data.DataSet
{
    public class Data<X, Y>
    {
        public X XValue { get; }

        public Y YValue { get; }

        public Data(X current, Y next)
        {
            this.XValue = current;
            this.YValue = next;
        }
    }
}
