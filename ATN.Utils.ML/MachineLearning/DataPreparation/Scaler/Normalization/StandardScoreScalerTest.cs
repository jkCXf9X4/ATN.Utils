using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xunit;

namespace ATN.Utils.MachineLearning.DataPreparation.Scaler.Normalization
{

    public class StandardScoreScalerTest
    {
        [Fact]
        public void Test1()
        {
            var scaler = new StandardScoreScaler();

            var data = new List<double>() { 0.0, 0.2, 0.5, 0.6, 1.0 };

            scaler.Fit(data);

            var scaledData = scaler.Transform(data).ToArray();

            Debug.WriteLine(scaledData);

            Assert.Equal(new List<double>() {
                -1.33685d,
                -0.75561d,
                0.11625d,
                0.40687d,
                1.56934d
            }, scaledData.Select(x => System.Math.Round(x, 5)));
        }

        [Fact]
        public void Reverse()
        {
            var scaler = new StandardScoreScaler();

            var data = new List<double>() { 0.0, 0.2, 0.5, 0.6, 1.0 };

            scaler.Fit(data);

            var scaledData = scaler.Transform(data).ToArray();

            var reversedData = scaler.Reverse(scaledData);

            Debug.WriteLine(scaledData);

            Assert.Equal(data, reversedData.Select(x => System.Math.Round(x, 3)));
        }
    }
}
