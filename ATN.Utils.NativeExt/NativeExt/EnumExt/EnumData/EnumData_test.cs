using Xunit;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATN.Utils.NativeExt.EnumExt
{
    
    public class EnumDataTest
    {
        enum Test_enum
        {
            test1,
            test2,
            test3,
            test4
        }

        enum Test_enum_int2
        {
            test1 = 2,
            test2 = 4,
            test3 = 7,
            test4 = 19
        }

        enum Test_enum_byte : byte
        {
            test1,
            test2,
            test3,
            test4
        }

        [Fact]
        public void Constructor_int()
        {
            new EnumData<Test_enum>();
        }
        [Fact]
        public void Constructor_int2()
        {
           new EnumData<Test_enum_int2>();
        }
        [Fact]
        public void Constructor_byte()
        {
            new EnumData<Test_enum_byte>();
        }

        [Fact]
        public void Count()
        {
            var count = new EnumData<Test_enum>().Count();

            Assert.Equal(4, count);
        }

        [Fact]
        public void GetValues()
        {
            var values = new EnumData<Test_enum>().GetAllEnumVales();
            var list = new List<Test_enum> { Test_enum.test1, Test_enum.test2, Test_enum.test3, Test_enum.test4 };

            Assert.Equal(list, values);
        }

        [Fact]
        public void GetBinary()
        {
            var values = new EnumData<Test_enum>().GetBinary(Test_enum.test3).ToArray();
            var list = new double[] { 0, 0, 1, 0 };

            Assert.Equal(list, values);
        }

        [Fact]
        public void GetRandom()
        {
            var list = new List<Test_enum>();

            var data = new EnumData<Test_enum>();

            for (int i = 0; i < 200; i++)
            {
                var randomEnum = data.GetRanom();
                list.Add(randomEnum);
            }

            var histogram = data.GetHistogram(list);

            Debug.WriteLine(String.Join(", ", histogram));
                
            Assert.Equal("", "");
        }

        [Fact]
        public void ToStrings()
        {
            var values = new EnumData<Test_enum>().ToStrings();
            var list = new string[] { "test1", "test2", "test3", "test4" };

            Assert.Equal(list, values);
        }
    }
}
