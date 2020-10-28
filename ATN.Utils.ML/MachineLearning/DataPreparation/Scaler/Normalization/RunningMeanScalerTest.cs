using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xunit;

namespace ATN.Utils.MachineLearning.DataPreparation.Scaler.Normalization
{

    public class RunningMeanScalerTest
    {
        [Fact]
        public void GetAvareges1()
        {
            var scaler = new RunningMeanScaler(3);

            var data = new List<double>() { 1, 2, 3, 4, 5, 6 };

            var scaledData = scaler.Transform(data);

            Assert.Equal(
                new List<double>() {double.NaN, double.NaN, 2, 3, 4, 5 }, 
                scaledData.Select(x=> System.Math.Round(x,4)));
        }

        [Fact]
        public void GetAvareges2()
        {
            var scaler = new RunningMeanScaler(3);

            List<double> list = new List<double>(); 

            list.Add(scaler.ComputeAverage(1));
            list.Add(scaler.ComputeAverage(2));
            list.Add(scaler.ComputeAverage(3));
            list.Add(scaler.ComputeAverage(4));
            list.Add(scaler.ComputeAverage(5));
            list.Add(scaler.ComputeAverage(6));

            Assert.Equal(
                new List<double>() { double.NaN, double.NaN, 2, 3, 4, 5 }, list);
        }

        [Fact]
        public void Test_croped_list()
        {
            var scaler = new RunningMeanScaler(3);

            var data = new List<double>() { 1, 2, 3, 4, 5, 6 };

            var cropedData = scaler.Crop(data);

            Assert.Equal(
                new List<double>() { 3, 4, 5, 6 },
                cropedData
                );
        }
    }
}
