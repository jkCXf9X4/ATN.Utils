using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATN.Utils.MachineLearning.DataPreparation.Scaler.Normalization
{
    [Serializable]
    public class RunningMeanScaler
    {
        private Queue<double> samples;
        public readonly int windowSize;
        private double sampleAccumulator;

        public RunningMeanScaler(int windowSize)
        {
            this.windowSize = windowSize;
            Reset();
        }

        public void Reset()
        {
            samples = new Queue<double>();
            sampleAccumulator = 0;
        }

        public IEnumerable<T> Crop<T>(IEnumerable<T> data)
        {
            return data.Skip(this.windowSize - 1);
        }

        public IEnumerable<double> Transform(IEnumerable<double> data)
        {
            var averages = data.Select(x => ComputeAverage(x));

            return averages;
        }
        public double ComputeAverage(double newSample)
        {
            sampleAccumulator += newSample;
            samples.Enqueue(newSample);

            if (samples.Count > windowSize)
            {
                sampleAccumulator -= samples.Dequeue();
            }
            if (samples.Count >= windowSize)
            {
                return sampleAccumulator / samples.Count;
            }
            return double.NaN;

        }

        public override string ToString()
        {
            return $"Samplesize: {samples.Count}, Max size:{windowSize} Accumulator:{sampleAccumulator}";
        }
    }
}
