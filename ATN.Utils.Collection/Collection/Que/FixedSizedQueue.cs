using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATN.Utils.Collection.Que
{
    public class FixedSizedQueue<T> : ConcurrentQueue<T>, IQueue<T>
    {
        private readonly object syncObject = new object();
        
        public int Size { get; }

        public FixedSizedQueue(int size)
        {
            Size = size;
        }

        /// <summary>
        /// Returns true if que is full
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public new bool Enqueue(T obj)
        {
            base.Enqueue(obj);
            lock (syncObject)
            {
                while (base.Count > Size)
                {
                    T outObj;
                    base.TryDequeue(out outObj);
                }
            }
            
            return IsFull;
        }

        public bool IsFull
        {
            get
            {
                return base.Count == Size;
            }
        }

        public new void Clear()
        {
            T item;
            while (base.TryDequeue(out item))
            {
                // do nothing
            }
        }

        public List<T> GetList()
        {
            return this.ToList();
        }

        public IEnumerable<string> ToStrings()
        {
            return this.Select(x => x.ToString());
        }

        public string ToString(string separator = ", ")
        {
            return String.Join(separator, ToStrings());
        }
    }
}
