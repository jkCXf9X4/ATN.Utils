using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATN.Utils.Misc.Data.IO
{
    public class Text
    {
        public static class Load
        {
            public static List<T> ReadFolder<T>(string folder, Func<string, T> func)
            {

                var list = new List<T>();

                string[] fileEntries = Directory.GetFiles(folder);
                foreach (string fileName in fileEntries)
                    list.AddRange(ReadFile(fileName, func));

                return list;
            }

            public static List<T> ReadFile<T>(string filename, Func<string, T> func)
            {
                var list = new List<T>();

                string[] lines = File.ReadAllLines(filename);

                foreach (var line in lines)
                {
                    list.Add(func(line));
                }
                return list;
            }
        }

        public static class Save
        {
            public static void Write(string path, IEnumerable<string> list)
            {
                using (StreamWriter outputFile = new StreamWriter(path, true))
                {
                    foreach (string line in list)
                    {
                        outputFile.WriteLine(line);
                    }
                }
            }
        }
    }
}
