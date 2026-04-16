using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassTask
{
    public class MonthlyCosts
    {
        public TrainingCost[] TrainingCosts { get; set; }

        public static MonthlyCosts LoadFrom(string filename)
        {
            if (!File.Exists(filename)) throw new FileNotFoundException();

            MonthlyCosts result = new MonthlyCosts();
            result.TrainingCosts = new TrainingCost[FileLength(filename)];

            using (StreamReader sr = new StreamReader(filename))
            {
                int i = 0;
                while (!sr.EndOfStream)
                {
                    string line = sr.ReadLine();
                    result.TrainingCosts[i] = TrainingCost.Parse(line);
                    ++i;
                }
            }

            return result;
        }

        private static int FileLength(string filename)
        {
            return File.ReadAllLines(filename).Length;
        }
    }
}
