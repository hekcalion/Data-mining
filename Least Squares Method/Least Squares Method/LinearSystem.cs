using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Least_Squares_Method
{
    public static  class LinearSystem
    {
        public static (double, double, double) KramerMethod (double[,] abc_CoefficientMatrix, double [] d_CoefficientVector)
        {
            double D = SarrusDeterminant3x3 (abc_CoefficientMatrix);

            double[,] D1_Matrix = new double[3,3];
            CopyMatrix(abc_CoefficientMatrix, D1_Matrix);
            for(int i = 0; i < 3; i++)
            {
                D1_Matrix[0, i] = d_CoefficientVector[i];
            }
            double D1 = SarrusDeterminant3x3(D1_Matrix);

            double[,] D2_Matrix = new double[3,3];
            CopyMatrix(abc_CoefficientMatrix, D2_Matrix);
            for (int i = 0; i < 3; i++)
            {
                D2_Matrix[1, i] = d_CoefficientVector[i];
            }
            double D2 = SarrusDeterminant3x3(D2_Matrix);

            double[,] D3_Matrix =  new double[3,3];
            CopyMatrix(abc_CoefficientMatrix, D3_Matrix);
            for (int i = 0; i < 3; i++)
            {
                D3_Matrix[2, i] = d_CoefficientVector[i];
            }
            double D3 = SarrusDeterminant3x3(D3_Matrix);

            return (D1/D, D2/D, D3/D);
        }

        // За звичайною формлою
        public static double Determinant3x3(double[,] SquareMatrix)
        {
            double result = 0;
            for (int i = 0; i < 3; i++)
            {
                result += (SquareMatrix[0, i] * (SquareMatrix[1, (i + 1) % 3] * SquareMatrix[2, (i + 2) % 3] - SquareMatrix[1, (i + 2) % 3] * SquareMatrix[2, (i + 1) % 3]));
            }
            return result;
        }


        // За правилом Саррюса
        public static double SarrusDeterminant3x3 (double [,] SquareMatrix)
        {
            double[,] supplementedMatrix = new double[5, 3];
            int k = 0;
            int l = 0;
            for(int i = 0; i < 5; i++)
            {
                for(int j = 0; j < 3; j++)
                {
                    if (i > 2 && k > 2) k = 0;
                    supplementedMatrix[i,j] = SquareMatrix[k, j];
                    l++;
                }
                k++;
                l = 0;
            }

            double determinant = 0;
            double product = 1;
            for (int i = 0; i< 3; i++)
            {               
                for(int j = 0; j < 3; j++)
                {
                    product *= supplementedMatrix[i+j,j];
                }
                determinant += product;
                product = 1;
            }

            product = 1;
            k = 0;
            for (int i = 0; i < 3; i++)
            {
                k = i;
                for (int j = 2; j > -1; j--)
                {
                    product *= supplementedMatrix[k, j];
                    k++;
                }
                k = 0;
                determinant -= product;
                product = 1;
            }
            return determinant;
        }

        private static void CopyMatrix (double [,] CopiedMatrix, double [,] DestinatonMatrix)
        {
            for(int i = 0; i < CopiedMatrix.GetLength(0); i++)
            {
                for(int j = 0; j < CopiedMatrix.GetLength(1); j++)
                {
                    DestinatonMatrix[i,j] = CopiedMatrix[i,j];
                }
            }
        }
    }
}
