
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using ATN.Utils.NativeExt.ObjectExt;

namespace ATN.Utils.NativeExt.EnumExt
{
    public class EnumData<T>
    {
        readonly Dictionary<int, T> valueDict = new Dictionary<int, T>();
        readonly Dictionary<T, int> keyDict = new Dictionary<T, int>();

        Random random = new Random();

        public EnumData()
        {
            CheckType();
            var i = 0;
            foreach( T value in GetAllEnumVales())
            {
                try
                {
                    valueDict.Add(i, value);
                    keyDict.Add(value, i);
                }
                catch (ArgumentException ex)
                {
                    throw new ArgumentException($"All vales must be uniqe in Enum, {ex.Message}");
                }
                i++;
            }
        }

        public List<T> GetAllEnumVales()
        {
            return new List<T>((T[])Enum.GetValues(typeof(T)));
        }

        public int Count()
        {
            return GetAllEnumVales().Count();
        }

        public T GetRanom()
        {
            var randomIndex = random.Next(0, Count());
            return valueDict[randomIndex];
        }

        public IEnumerable<T> Cast(IEnumerable<int> i)
        {
            return i.Select(x => Cast(x));
        }

        public T Cast(int i)
        {
            return (T)Enum.ToObject(typeof(T), i);
        }

        public IEnumerable<T> CastByIndex(IEnumerable<int> i)
        {
            return i.Select(x => CastByIndex(x));
        }

        public T CastByIndex(int i)
        {
            return valueDict[i];
        }

        /// <summary>
        /// Get histogram of list
        /// eg. [2][4][0][9] if the enum has four possible choices
        /// </summary>
        /// <param name="list"></param>
        /// <returns></returns>
        public IEnumerable<double> GetHistogram(IEnumerable<T> list)
        {
            var counter = (0.0).ToList(Count());

            foreach(T i in list)
            {
                int EnumPlacemnet = keyDict[i];
                counter[EnumPlacemnet] += 1;
            }
            return counter;
        }

        /// <summary>
        /// Return binary representation of Enum
        /// eg. [0][0][1][0] if the enum has four values
        /// Must be able to cast as a int.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public IEnumerable<double> GetBinary(T item)
        {
            return GetHistogram(new T[] { item });
        }


        private void CheckType()
        {
            if (!typeof(T).IsEnum)
            {
                throw new ArgumentException("T must be an enumerated type");
            }
        }

        public IEnumerable<string> ToStrings()
        {
            return GetAllEnumVales().Select(x => x.ToString());
        }

    }
}
