#if NET5_0

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xunit;

namespace ATN.Utils.NativeExt.TupleExt
{
    public class TupleExt_test
    {
        [Fact]
        void CreateTuples()
        {
            var list1 = new List<int>() { 5, 6, 7, 8 };
            var list2 = new List<string> { "5", "6", "7", "8" };

            var actual = Extension.ToTuples (list1, list2).ToArray();

            var predicted0 = (5, "5");
            var predicted1 = (6, "6");
            var predicted2 = (7, "7");
            var predicted3 = (8, "8");

            Assert.Equal(predicted0, actual[0]);
            Assert.Equal(predicted1, actual[1]);
            Assert.Equal(predicted2, actual[2]);
            Assert.Equal(predicted3, actual[3]);
        }
    }
}
#endif
