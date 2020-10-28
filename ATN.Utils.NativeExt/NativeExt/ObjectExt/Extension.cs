
using System;
using System.Collections.Generic;
using System.Collections;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Text.RegularExpressions;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace ATN.Utils.NativeExt.ObjectExt
{

	public static class Extension
    {
        /// <summary>
        /// Return object as type T
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="obj"></param>
        /// <returns></returns>
        public static T As<T>(this object obj)
        {
            if (obj == null)
                throw new NullReferenceException("Object is null, unable to access");
            return (T)obj;
        }

        public static void IfNullThrowException(this object obj)
		{
			if(obj == null)
				throw new NullReferenceException("Object is null, unable to access");
		}

        public static T GetDeepCopy<T>(this T other)
        {
            MemoryStream memoryStream = new MemoryStream();
            MemoryStream ms = memoryStream;
            BinaryFormatter formatter = new BinaryFormatter();
            formatter.Serialize(ms, other);
            ms.Position = 0;
            return (T)formatter.Deserialize(ms);
        }

        public static List<T> ToList<T>(this T obj, int times)
        {
            var Tlist = new List<T>();
            for (int i = 0; i <times;i++)
            {
                Tlist.Add(obj);
            }
            return Tlist;
        }

        public static T[] ToArray<T>(this T obj, int times)
        {
            var array = new T[times];
            for (int i = 0; i < times; i++)
            {
                array[i] = obj;
            }
            return array;
        }
    }
}
