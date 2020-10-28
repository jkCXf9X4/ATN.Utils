using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATN.Utils.MachineLearning.DataPreparation.Scaler.Normalization
{
    [Serializable]
    public class MinMaxScaler : Scaler<double, double>
    {
        private readonly double RangeMin;
        private readonly double RangeMax;
        private readonly double finalRange;

        private double dataMin;
        private double dataMax;

        public MinMaxScaler(double rangeMin, double rangeMax)
        {
            RangeMin = rangeMin;
            RangeMax = rangeMax;
            finalRange = RangeMax - RangeMin;
        }

        public override void Fit(IEnumerable<double> data)
        {
            dataMin = data.Min();
            dataMax = data.Max();
        }

        public override double Transform(double data)
        {
            var x = (data - dataMin) / (dataMax - dataMin);
            x = x * finalRange + RangeMin;

            return x;
        }

        public override double Reverse(double data)
        {
            data = (data - RangeMin) / finalRange;
            data = data * (dataMax - dataMin) + dataMin;


            return data;
        }

        public override string ToString()
        {
            return $"Range: {RangeMax}-{RangeMin}, Data: {dataMax}-{dataMin}";
        }


    }
}
