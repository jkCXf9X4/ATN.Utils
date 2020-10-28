using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATN.Utils.MachineLearning.Data.DataSet
{
    public interface IDataSet<T> : IEnumerable, IEnumerator
    {
        int Count { get;  }

        T this[int index] { get; }

        DataSet<T> GetRange(int index, int count);
    }
}
