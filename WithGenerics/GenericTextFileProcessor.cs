using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Generics.WithGenerics
{
    public static class GenericTextFileProcessor
    {
        public static List<T> LoadFromtTextFile<T>(string filepath) where T : class, new()
        {
            var lines = System.IO.File.ReadAllLines(filepath);
            List<T> output = new List<T>();
            T entry = new T();
            var cols = entry.GetType().GetProperties();

            if (lines.Count() < 2)
                throw new ArgumentOutOfRangeException("");

            var headers = lines[0].Split(',');

            foreach (var row in lines)
            {
                entry = new T();

                var vals = row.Split(',');

                for (int i = 0; i < headers.Length; i++)
                {
                    foreach(var col in cols)
                    {
                        if (col.Name == headers[i])
                        {
                            col.SetValue(entry, Convert.ChangeType(vals[i], col.PropertyType));
                        }
                    }
                }
                output.Add(entry);
            }
            return output;
        }

        public static void SaveToTextFile<T>(List<T> data, string filepath) where T : class
        {
            List<string> lines = new List<string>();
            StringBuilder line = new StringBuilder();

            if (data == null || data.Count() == 0)
            {
                throw new ArgumentNullException("data","You must populate the data parameter with at least one data");
            }

            var cols = data[0].GetType().GetProperties();

            foreach (var col in cols)
            {
                line.Append(col.Name);
                line.Append(",");
            }


            lines.Add(line.ToString().Substring(0, line.Length - 1));

            foreach(var row in data)
            {
                line = new StringBuilder();
                foreach (var col in cols)
                {
                    line.Append(col.GetValue(row));
                    line.Append(",");
                }
                lines.Add(line.ToString().Substring(0, line.Length - 1));
            }

            System.IO.File.WriteAllLines(filepath, lines);
        }
    }
}
