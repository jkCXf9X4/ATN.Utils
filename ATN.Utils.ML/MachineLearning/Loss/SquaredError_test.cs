using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace ATN.Utils.MachineLearning.Loss
{
    public class SquaredError_test
    {
        [Theory]
        [InlineData(4.0, 6.0, 2.0)]
        [InlineData(6.0, 4.0, 2.0)]
        public void Fx(double expe, double pred, double expeced_answer)
        {
            var se = new SquaredError();
            var expected = new[] { expe };
            var predicted = new[] { pred };
            var loss = se.GetLoss(expected, predicted);

            Assert.Equal(expeced_answer, loss[0]);
        }

        [Theory]
        [InlineData(4.0, 6.0, 2.0)]
        [InlineData(6.0, 4.0, -2.0)]
        public void dFx(double expe, double pred, double expeced_answer)
        {
            var se = new SquaredError();
            var expected = new[] { expe };
            var predicted = new[] { pred };
            var loss = se.GetDerivates(expected, predicted);

            Assert.Equal(expeced_answer, loss[0]);
        }

    }
}
