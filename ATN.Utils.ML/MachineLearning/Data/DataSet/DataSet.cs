using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATN.Utils.MachineLearning.Data.DataSet
{
    public class DataSet<T> : IDataSet<T>
    {
        int position = -1;
        protected List<T> Data;

        public DataSet()
        {

        }

        public DataSet(List<T> values)
        {
            Data = values;
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return (IEnumerator)GetEnumerator();
        }

        public DataSet<T> GetEnumerator()
        {
            return this;
        }

        public void Reset()
        {
            position = -1;
        }

        public void SetPosition(int pos)
        {
            position = pos;
        }
        public int Count
        {
            get
            {
                return Data.Count;
            }
        }

        object IEnumerator.Current
        {
            get
            {
                return Current;
            }
        }

        public T Current
        {
            get
            {
                return Data[position];
            }
        }

        public T this[int index]
        {
            get
            {
                return (this.Data[index]);
            }
        }

        public bool MoveNext()
        {
            position++;
            return (position < Data.Count);
        }

        public DataSet<T> GetRange(int index, int count)
        {
            return new DataSet<T>(this.Data.GetRange(index, count));
        }
    }
}
