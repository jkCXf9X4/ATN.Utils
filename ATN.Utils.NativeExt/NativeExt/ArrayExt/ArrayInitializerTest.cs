using Xunit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using ATN.Utils.NativeExt.ArrayExt;

namespace ATN.Utils.NativeExt.ArrayExt
{
    
    public class ArrayInitializerTest
    {
        public class TestClass : IEquatable<TestClass>
        {
            readonly int i = 0;
            public TestClass(int i)
            {
                this.i = i;
            }

            public bool Equals(TestClass other)
            {
                if (this.i == other.i)
                {
                    return true;
                }
                return false;
            }
        }


        [Fact]
        public void TestInitilizer_primitive()
        {
            var array = ArrayInitializer.Initializer<int>(5, () => 7);

            var expected = new int[] { 7, 7, 7, 7, 7 };

            Assert.Equal(expected, array);
        }

        [Fact]
        public void TestInitilizer_object()
        {
            var i = 0;
            var array = ArrayInitializer.Initializer<TestClass>(3, () => new TestClass(i++));

            var expected = new TestClass[] { new TestClass(0), new TestClass(1), new TestClass(2)};

            Assert.Equal(expected, array);
        }

    }

}
