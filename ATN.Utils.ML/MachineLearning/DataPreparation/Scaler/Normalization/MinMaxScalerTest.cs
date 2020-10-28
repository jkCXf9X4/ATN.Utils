using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xunit;

namespace ATN.Utils.MachineLearning.DataPreparation.Scaler.Normalization
{
    
    public class MinMaxScalerTest
    {
        [Fact]
        public void Between_0_1_no_scaling()
        {
            var scaler = new MinMaxScaler(0, 1);

            var data = new List<double>() { 0.0, 0.2, 0.5, 0.6, 1.0 };

            scaler.Fit(data);

            var scaledData = scaler.Transform(data);

            Debug.WriteLine(scaledData);

            Assert.Equal(
                new List<double>() { 0.0, 0.2, 0.5, 0.6, 1.0 }, 
                scaledData.Select(x=> System.Math.Round(x,4)));
        }

        [Fact]
        public void Between_0_1_caling_1000_to_1()
        {
            var scaler = new MinMaxScaler(0, 1);

            var data = new List<double>() { 0.0, 1000, 0.0 };

            scaler.Fit(data);

            var scaledData = scaler.Transform(data);

            Debug.WriteLine(scaledData);

            Assert.Equal(
                new List<double>() { 0.0, 1.0, 0.0 },
                scaledData.Select(x => System.Math.Round(x, 4)));
        }

        [Fact]
        public void Between_0_1_To_neg_1_1 ()
        {
            var scaler = new MinMaxScaler(-1, 1);

            var data = new List<double>() { 0.0, 0.4, 0.5, 0.6, 1.0 };

            scaler.Fit(data);

            var scaledData = scaler.Transform(data);

            Console.WriteLine(scaledData);

            Assert.Equal(
                new List<double>() { -1.0, -0.2, 0, 0.2, 1.0 }, 
                scaledData.Select(x => System.Math.Round(x, 4)));
        }

        [Fact]
        public void Between_05_1_no_scaling()
        {
            var scaler = new MinMaxScaler(0, 1);

            var data = new List<double>() { 0.5, 0.6, 0.7, 0.8, 0.9, 1.0 };

            scaler.Fit(data);

            var scaledData = scaler.Transform(data);

            var roundedData = scaledData.Select(x => System.Math.Round(x, 4)).ToList();

            Debug.WriteLine(scaledData);

            Assert.Equal(
                new List<double>() { 0.0, 0.2, 0.4, 0.6, 0.8, 1 }, roundedData);
        }

        [Fact]
        public void Reversed_data1()
        {
            var scaler = new MinMaxScaler(0, 1);

            var data = new List<double>() { 0.5, 0.6, 0.7, 0.8, 0.9, 1.0 };

            scaler.Fit(data);

            var scaledData = scaler.Transform(data);


            var reversedData = scaler.Reverse(scaledData).ToList();

            var roundedData = reversedData.Select(x => System.Math.Round(x, 4)).ToList();

            Debug.WriteLine(reversedData);

            Assert.Equal(data, roundedData);
        }

    }
}
