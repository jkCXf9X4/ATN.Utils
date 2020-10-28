using Xunit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATN.Utils.MathExt.Numerical
{

    public class UnitCircleTest
    {
        [Fact]
        public void Constructor_0deg_1_0()
        {
            var unitCircle = new UnitCircle(new AngleDegree(0));
            Assert.Equal("1;0", unitCircle.ToString(";"));
        }

        [Fact]
        public void Constructor_90Deg_0_1()
        {
            var unitCircle = new UnitCircle(new AngleDegree(90));
            Assert.Equal("0;1", unitCircle.ToString(";"));
        }

        [Fact]
        public void Constructor_1Rad_1_0()
        {
            var unitCircle = new UnitCircle(new AngleRadian(System.Math.PI*2));
            Assert.Equal("1;-0", unitCircle.ToString(";"));
        }

        [Fact]
        public void Constructor_Pi_neg1_0()
        {
            var unitCircle = new UnitCircle(new AngleRadian(System.Math.PI));
            Assert.Equal("-1;0", unitCircle.ToString(";"));
        }

        [Fact]
        public void Constructor_half_ned1_0()
        {
            var unitCircle = new UnitCircle(0.5);
            Assert.Equal("-1;0", unitCircle.ToString(";"));
        }

        [Fact]
        public void Constructor_Quarter_0_1()
        {
            var unitCircle = new UnitCircle(0.25);
            Assert.Equal("0;1", unitCircle.ToString(";"));
        }

        [Fact]
        public void ToString_Quarter_0_1()
        {
            var unitCircle = new UnitCircle(0.25);
            var str = unitCircle.ToString();
            Assert.Equal("0;1", str);
        }

        [Fact]
        public void ToString_Eight_0_1()
        {
            var unitCircle = new UnitCircle(0.125);
            var str = unitCircle.ToString();
            Assert.Equal("0.70711;0.70711", str);
        }
    }
}
