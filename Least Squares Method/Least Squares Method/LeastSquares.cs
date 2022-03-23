using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Least_Squares_Method
{
    public static class LeastSquares
    {

        // y = a + b * x + c * x^2
        public static (double, double, double) ParabolicLeastSquaresMethod(List<double> x_Set, List<double> y_Set)
        {
            double sum_of_x_Set = x_Set.Sum();
            double sum_of_y_Set = y_Set.Sum();
            double sum_of_xy_Set = 0;
            for(int i = 0; i < x_Set.Count; i++)
            {
                sum_of_xy_Set+= x_Set[i] * y_Set[i];
            }
            double sum_of_x2y_Set = 0;
            for (int i = 0; i < x_Set.Count; i++)
            {
                sum_of_x2y_Set += x_Set[i] * x_Set[i] * y_Set[i];
            }
            double sum_of_x2_Set =  x_Set.Select(x => x * x).Sum();
            double sum_of_x3_Set =  x_Set.Select(x => x * x * x).Sum();
            double sum_of_x4_Set =  x_Set.Select(x => x * x * x * x).Sum();

            double[,] abc_CoefficientMatrix = new double[,]
            {
                { x_Set.Count, sum_of_x_Set, sum_of_x2_Set },
                { sum_of_x_Set, sum_of_x2_Set, sum_of_x3_Set },
                { sum_of_x2_Set, sum_of_x3_Set, sum_of_x4_Set }
            };

            double[] d_CoefficientVector = new double[] { sum_of_y_Set, sum_of_xy_Set, sum_of_x2y_Set };
            return LinearSystem.KramerMethod(abc_CoefficientMatrix, d_CoefficientVector);
        }


        // y = a + b * x
        public static (double, double) LinearLeastSquaresMethod(List<double> x_Set, List<double> y_Set)
        {
            double sum_of_x_Set = x_Set.Sum();
            double sum_of_y_Set = y_Set.Sum();
            double sum_of_xy_Set = 0;
            for (int i = 0; i < x_Set.Count; i++)
            {
                sum_of_xy_Set += x_Set[i] * y_Set[i];
            }
            double sum_of_x2_Set = x_Set.Select(x => x * x).Sum();

            double b = ((x_Set.Count * sum_of_xy_Set) - (sum_of_x_Set * sum_of_y_Set)) / ((x_Set.Count * sum_of_x2_Set) - (sum_of_x_Set * sum_of_x_Set));
            double a = ((sum_of_y_Set * sum_of_x2_Set) - (sum_of_xy_Set * sum_of_x_Set)) / ((x_Set.Count * sum_of_x2_Set) - (sum_of_x_Set * sum_of_x_Set));

            return (a, b);
        }
    }
}
