using System;
using System.Collections.Generic;
using DataProcess;
using FunctionProcess;

namespace Methods_of_initial_data_processing
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Function F = new Function(delegate (double x) { return Math.Cos(0.1 * x) + Math.Cos(x);});
            F.FuncTabulation(1, 10, 0.1);
            List<double> Y_Set_Noised = F.MakeNoise(0.0, 0.5);
            List<double> Y_Set_UAM = InitialDataProcess.UpdateAvarageMethod(Y_Set_Noised);

            // Графік метод оновлюваної середньої
            string[] Titles =
            {
                "Метод оновлюваної середньої",
                "Табульована функція",
                "Функція з шумом",
                "Функція після обробки даних",
                "UpdateAvarageMethod"
            };
            F.PlotFunction(F.X_Set, F.Y_Set, Y_Set_Noised, Y_Set_UAM, Titles);

            // Графік метод ковзної середньої L = 2
            int L = 2;
            Titles[0] = "Метод ковзної середньої (l = 2)";
            Titles[4] = "MovingAvarageMethod_(l = 2)";
            List<double> Y_Set_MAM = InitialDataProcess.MovingAvarageMethod(Y_Set_Noised, L);
            F.PlotFunction(F.X_Set, F.Y_Set, Y_Set_Noised, Y_Set_MAM, Titles);

            // Графік метод ковзної середньої L = 4
            L = 4;
            Titles[0] = "Метод ковзної середньої (l = 4)";
            Titles[4] = "MovingAvarageMethod_(l = 4)";
            Y_Set_MAM = InitialDataProcess.MovingAvarageMethod(Y_Set_Noised, L);
            F.PlotFunction(F.X_Set, F.Y_Set, Y_Set_Noised, Y_Set_MAM, Titles);

            // Графік метод ковзної середньої L = 6
            L = 6;
            Titles[0] = "Метод ковзної середньої (l = 6)";
            Titles[4] = "MovingAvarageMethod_(l = 6)";
            Y_Set_MAM = InitialDataProcess.MovingAvarageMethod(Y_Set_Noised, L);
            F.PlotFunction(F.X_Set, F.Y_Set, Y_Set_Noised, Y_Set_MAM, Titles);

            // Графік метод ковзної середньої L = 8
            L = 8;
            Titles[0] = "Метод ковзної середньої (l = 8)";
            Titles[4] = "MovingAvarageMethod_(l = 8)";
            Y_Set_MAM = InitialDataProcess.MovingAvarageMethod(Y_Set_Noised, L);
            F.PlotFunction(F.X_Set, F.Y_Set, Y_Set_Noised, Y_Set_MAM, Titles);

            // Графік метод ковзної середньої L = 14
            L = 14;
            Titles[0] = "Метод ковзної середньої (l = 14)";
            Titles[4] = "MovingAvarageMethod_(l = 14)";
            Y_Set_MAM = InitialDataProcess.MovingAvarageMethod(Y_Set_Noised, L);
            F.PlotFunction(F.X_Set, F.Y_Set, Y_Set_Noised, Y_Set_MAM, Titles);
        }
    }
}
