using Xunit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ATN.Utils.UnitTests.Helper
{
    public class ClassesTest
    {
        [Fact]
        public void testClass_Compare_Correct()
        {
            var reference = new Equatable("j");
            var obj = new Equatable("j");

            Assert.Equal(reference, obj);
        }

        [Fact]
        public void testClass_Compare_Incorrect()
        {
            var reference = new Equatable("j");
            var obj = new Equatable("b");

            Assert.NotEqual(reference, obj);
        }
    }
}

