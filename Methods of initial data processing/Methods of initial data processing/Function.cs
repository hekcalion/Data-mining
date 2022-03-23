using System;
using System.Collections.Generic;
using System.Linq;

namespace FunctionProcess
{
    public delegate double Func (double x);
    public class Function
    {
        public Func function { get; set; }
        public List<double> X_Set { get; set; }
        public List<double> Y_Set { get; set; }
        public Function(Func function)
        {
            this.function = function;
            X_Set = new List<double>();
            Y_Set = new List<double>();    
        }
        public void FuncTabulation(int Start, int End, double Step)
        {
            for (double x = Start; x <= End; x += Step)
            {
                X_Set.Add(x);
                Y_Set.Add(function(x));
            }
        }

        public List<double> MakeNoise (double leftLimit, double rightLimit)
        {
            Random random = new Random();
            return Y_Set.Select(y => y + (random.NextDouble() * (rightLimit - leftLimit) + leftLimit)).ToList();
        }

        public void PlotFunction(List<double> x_Set, List<double> y1_Set, List<double> y2_Set, List<double> y3_Set, string[] Titles)
        {
            var plt = new ScottPlot.Plot(900, 700);
            plt.Title(Titles[0], size: 28, bold: true);
            plt.AddScatter(x_Set.ToArray(), y1_Set.ToArray(), color: System.Drawing.Color.Green, label:Titles[1]);
            plt.AddScatter(x_Set.ToArray(), y2_Set.ToArray(), color: System.Drawing.Color.Red, label:Titles[2]);
            plt.AddScatter(x_Set.ToArray(), y3_Set.ToArray(), color: System.Drawing.Color.Orange, label:Titles[3]);
            var legend = plt.Legend();
            legend.Location = ScottPlot.Alignment.UpperRight;
            legend.FontSize = 15;
            plt.SaveFig($"{Titles[4]}.jpeg");
        }
    }
}
