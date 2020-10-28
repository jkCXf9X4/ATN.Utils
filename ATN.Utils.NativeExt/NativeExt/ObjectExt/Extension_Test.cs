using Xunit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATN.Utils.NativeExt.ObjectExt
{
    
    public class Extension_Test
    {
        [Fact]
        public void ToListTest()
        {
            var i = (0).ToList(4);
            Assert.Equal(new List<int>() { 0, 0, 0, 0 }, i);
        }

        [Fact]
        public void ToArrayTest()
        {
            var i = (0).ToArray(4);
            Assert.Equal(new int[] { 0, 0, 0, 0 }, i);
        }
    }
}
