using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATN.Utils.CustomCollection.Que
{
    public interface IQueue<T>
    {
        /// <summary>
        /// Returns true if que is full
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        bool Enqueue(T obj);

        bool IsFull { get; }

        int Count { get; }

        void Clear();

        IEnumerable<string> ToStrings();

        string ToString(string separator = ", ");
    }
}
