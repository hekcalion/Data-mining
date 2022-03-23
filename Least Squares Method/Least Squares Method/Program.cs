using System;
using System.Collections.Generic;

namespace Least_Squares_Method
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Межі табуляції [-5;5]
            int leftLimit = -5;
            int rightLimit = 5;

            // Крок при табуляції
            double step = 0.1;

            // Функція y = 2 - 3 * x - 0.2 * x^2
            Function F = new Function(delegate (double x) { return 2.0 - 3.0 * x - 0.2 * x * x; });
            F.FuncTabulation(leftLimit, rightLimit, step);


            // Розрахунок при L = 1
            List<double> Y1_Set_Noised = F.MakeNoise(0.0, 0.5, 1);
            double a , b, c;
            (a, b, c) = LeastSquares.ParabolicLeastSquaresMethod(F.X_Set, Y1_Set_Noised);
            Function F1_LeastSquares = new Function(delegate (double x) { return a + b * x + c * x * x; });
            F1_LeastSquares.FuncTabulation(leftLimit, rightLimit, step);
            (a, b) = LeastSquares.LinearLeastSquaresMethod(F.X_Set, Y1_Set_Noised);
            Function F1_LinearLeastSquares = new Function( delegate (double x) { return a + b * x; });
            F1_LinearLeastSquares.FuncTabulation(leftLimit, rightLimit, step);

            // Графік при L = 1
            string[] Titles1 =
            {
                "Метод найменших квадратів (квадратична емпірична формула) (L =1)",
                "Табульована функція",
                "Функція з шумом",
                "Функція після обробки даних",
                "ParabolicLeastSquaresMethod(L = 1)"
            };
            F.PlotFunction(F.X_Set, F.Y_Set, Y1_Set_Noised, F1_LeastSquares.Y_Set, Titles1);

            string[] Titles2 =
            {
                "Метод найменших квадратів (лінійна емпірична формула) (L =1)",
                "Табульована функція",
                "Функція з шумом",
                "Функція після обробки даних",
                "LinearLeastSquaresMethod(L = 1)"
            };
            F.PlotFunction(F.X_Set, F.Y_Set, Y1_Set_Noised, F1_LinearLeastSquares.Y_Set, Titles2);


            // Розрахунок при L = 10
            List<double> Y2_Set_Noised = F.MakeNoise(0.0, 0.5, 10);
            (a, b, c) = LeastSquares.ParabolicLeastSquaresMethod(F.X_Set, Y2_Set_Noised);
            Function F2_LeastSquares = new Function(delegate (double x) { return a + b * x + c * x * x; });
            F2_LeastSquares.FuncTabulation(leftLimit, rightLimit, step);
            (a, b) = LeastSquares.LinearLeastSquaresMethod(F.X_Set, Y2_Set_Noised);
            Function F2_LinearLeastSquares = new Function(delegate (double x) { return a + b * x; });
            F2_LinearLeastSquares.FuncTabulation(leftLimit, rightLimit, step);

            // Графік при L = 10
            Titles1[0] = "Метод найменших квадратів (квадратична емпірична формула) (L = 10)";
            Titles1[4] = "ParabolicLeastSquaresMethod(L = 10)";
            F.PlotFunction(F.X_Set, F.Y_Set, Y2_Set_Noised, F2_LeastSquares.Y_Set, Titles1);

            Titles2[0] = "Метод найменших квадратів (лінійна емпірична формула) (L =10)";
            Titles2[4] = "LinearLeastSquaresMethod(L = 10)";
            F.PlotFunction(F.X_Set, F.Y_Set, Y2_Set_Noised, F2_LinearLeastSquares.Y_Set, Titles2);


            // Розрахунок при L = 100
            List<double> Y3_Set_Noised = F.MakeNoise(0, 0.5, 100);
            (a, b, c) = LeastSquares.ParabolicLeastSquaresMethod(F.X_Set, Y3_Set_Noised);
            Function F3_LeastSquares = new Function(delegate (double x) { return a + b * x + c * x * x; });
            F3_LeastSquares.FuncTabulation(leftLimit, rightLimit, step);
            (a, b) = LeastSquares.LinearLeastSquaresMethod(F.X_Set, Y3_Set_Noised);
            Function F3_LinearLeastSquares = new Function(delegate (double x) { return a + b * x; });
            F3_LinearLeastSquares.FuncTabulation(leftLimit, rightLimit, step);


            // Графік при L = 100
            Titles1[0] = "Метод найменших квадратів (квадратична емпірична формула) (L = 100)";
            Titles1[4] = "ParabolicLeastSquaresMethod(L = 100)";
            F.PlotFunction(F.X_Set, F.Y_Set, Y3_Set_Noised, F3_LeastSquares.Y_Set, Titles1);

            Titles2[0] = "Метод найменших квадратів (лінійна емпірична формула) (L =100)";
            Titles2[4] = "LinearLeastSquaresMethod(L = 100)";
            F.PlotFunction(F.X_Set, F.Y_Set, Y3_Set_Noised, F3_LinearLeastSquares.Y_Set, Titles2);
        }
    }
}
