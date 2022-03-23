using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Least_Squares_Method
{
    public delegate double Func(double x);
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
            for( double x = Start; x <= End; x+=Step)
            {
                X_Set.Add(x);
                Y_Set.Add(function(x));
            }
        }

        public List<double> MakeNoise(double leftLimit, double rightLimit, int L)
        {
            Random random = new Random();
            return Y_Set.Select(y => y + L * (random.NextDouble() * (rightLimit - leftLimit) + leftLimit)).ToList();
        }

        public void PlotFunction(List<double> x_Set, List<double> y1_Set, List<double> y2_Set, List<double> y3_Set, string[] Titles)
        {
            var plt = new ScottPlot.Plot(1920, 1080);
            plt.Title(Titles[0], size: 28, bold: true);
            plt.AddScatter(x_Set.ToArray(), y1_Set.ToArray(), color: System.Drawing.Color.Green, label: Titles[1], lineWidth:2, markerSize:7);
            plt.AddScatter(x_Set.ToArray(), y2_Set.ToArray(), color: System.Drawing.Color.Red, label: Titles[2], lineWidth: 2, markerSize: 7);
            plt.AddScatter(x_Set.ToArray(), y3_Set.ToArray(), color: System.Drawing.Color.Orange, label: Titles[3], lineWidth: 2, markerSize: 7);

            plt.YAxis.LabelStyle(fontSize: 24);
            plt.XAxis.LabelStyle(fontSize: 24);
            plt.XAxis2.LabelStyle(fontSize: 36);

            plt.YAxis.TickLabelStyle(fontSize: 18);
            plt.XAxis.TickLabelStyle(fontSize: 18);

            plt.YAxis.MajorGrid(lineWidth: 3);
            plt.XAxis.MajorGrid(lineWidth: 3);

            var legend = plt.Legend();
            legend.Location = ScottPlot.Alignment.UpperRight;
            legend.FontSize = 30;
            plt.SaveFig($"{Titles[4]}.jpeg");
        }
    }
}
