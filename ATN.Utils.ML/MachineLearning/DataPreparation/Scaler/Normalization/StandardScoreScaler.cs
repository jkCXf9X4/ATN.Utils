using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using MathNet.Numerics.Statistics;

namespace ATN.Utils.MachineLearning.DataPreparation.Scaler.Normalization
{
    [Serializable]
    public class StandardScoreScaler : Scaler<double, double>
    {
        double RangePopulationStandardDeviation;
        double RangeAverage;

        public StandardScoreScaler()
        {

        }

        public override void Fit(IEnumerable<double> data)
        {
            RangeAverage = data.Average();
            RangePopulationStandardDeviation = data.PopulationStandardDeviation();
        }

        public override double Transform(double data)
        {
            return (data - RangeAverage) / RangePopulationStandardDeviation;
        }

        public override double Reverse(double data)
        {
            return (data * RangePopulationStandardDeviation) + RangeAverage;
        }

        public override string ToString()
        {
            return $"Standard deviation: {RangePopulationStandardDeviation}, Range average: {RangeAverage}";
        }


    }
}
