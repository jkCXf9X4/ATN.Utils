using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;


namespace ATN.Utils.MathExt
{

    public class ExtensionsTest
    {
        [Fact]
        public void ToRadians_90Deg_HalfPi()
        {
            double angleDegree = 90;
            var angleRad = angleDegree.ToRadians();

            Assert.Equal(angleRad, System.Math.PI/2);

        }

    }
}
