using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataProcess
{
    public static class InitialDataProcess
    {
        public static List<double> UpdateAvarageMethod (List<double> y_Set)
        {
            List<double> new_y_Set = new List<double>();
            for(int i = 0; i < y_Set.Count; i++)
            {
                if(i==0)
                {
                    new_y_Set.Add(y_Set[i]);
                    continue;
                }
                new_y_Set.Add(new_y_Set.ElementAt(i - 1) + (1.0 / (i + 1)) * (y_Set.ElementAt(i) - new_y_Set.ElementAt(i - 1)));
            }
            return new_y_Set;
        }

        public static List<double> MovingAvarageMethod(List<double> y_set, int L)
        {
            int count = y_set.Count;
            double[] new_y_Set = new double[y_set.Count];
            for (int i = 0; i < count; i++)
            {
                if (i > count - L / 2 - 1)
                {
                    new_y_Set[i] = y_set[i];
                    continue;
                }
                if (i < L / 2) new_y_Set[i] = y_set[i];
                new_y_Set[i + (L / 2)] = (1.0 / L) * y_set.Skip(i).Take(L).Sum();
            }
            return new_y_Set.ToList();
        }
    }
}
