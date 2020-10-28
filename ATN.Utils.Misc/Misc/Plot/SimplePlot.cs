// using System;
// using System.Collections.Generic;
// using System.Text;
// using System.Linq;

// using OxyPlot;
// using OxyPlot.Series;
// using ATN.Utils.CollectionsExt.EnumExt;
// using System.Threading;
// using OxyPlot.WindowsForms;

// namespace ATN.Utils.Plot
// {
//     public partial class SimplePlot
//     {

//         public PlotModel MyModel { get; private set; }

//         public SimplePlot(IEnumerable<double> x, IEnumerable<double> y)
//         {
//             var x_y = (x, y).ToTuples();
//             var points = x_y.Select(point => new ScatterPoint(point.Item1, point.Item2));

//             CreateModel(points);
//         }

//         public SimplePlot(IEnumerable<double> x)
//         {
//             int i = 1;
//             var points = x.Select(x1 => new ScatterPoint(x1, i++));

//             CreateModel(points);
//         }

//         public void CreateModel(IEnumerable< ScatterPoint> scatterPoints)
//         {
//             this.MyModel = new PlotModel { Title = "SimplePlot" };
//             var scatterSeries = new ScatterSeries { MarkerType = MarkerType.Circle };

//             scatterSeries.Points.AddRange(scatterPoints);

//             this.MyModel.Series.Add(scatterSeries);
//         }

//         public void Save(string path)
//         {
//             PngExporter.Export(this.MyModel, path, 800, 600, OxyColor.FromRgb(0, 0, 0));
//         }



//     }
// }
