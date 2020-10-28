
using Xunit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using ATN.Utils.UnitTests.Helper;
using ATN.Utils.NativeExt.EnumExt;

namespace ATN.Utils.UnitTests.NativeExt.EnumExt
{

    public class ExtensionsTest
    {
        enum Test
        {
            a,
            b,
            c,
            d
        };

        [Fact]
        public void Find_CorrectInputString_CcorrectOutput()
        {
            var result = new Test().Find("b");
            Assert.Equal(Test.b, result);
        }


        [Fact]
        public void CastAsObject_ArrayOfStrings_Correct()
        {
            var stringArray = new String[] { "jhjk", "hjkll", "crcrd", "opikop" };
            var reference = new object[] { "jhjk", "hjkll", "crcrd", "opikop" };
            var objcts = stringArray.Cast<object>();

            Assert.Equal(reference, objcts);

        }

        [Fact]
        public void CastAsObject_ListOfStrings_Correct()
        {
            var stringList = new List<String>() { "jhjk", "hjkll", "crcrd", "opikop" };
            var reference = new List<object> { "jhjk", "hjkll", "crcrd", "opikop" };
            var objcts = stringList.Cast<object>();

            Assert.Equal(reference, objcts);

        }

        [Fact]
        public void ToStrings_ListOfStrings_Correct()
        {
            var stringList = new List<int>() { 5, 6, 7, 8 };
            var reference = new List<string> { "5", "6", "7", "8" };
            var objcts = stringList.ToStrings();

            Assert.Equal(reference, objcts);

        }

        [Fact]
        public void CreateCollection_ListOfStrings_Correct()
        {
            var stringList = new List<String>() { "jj", "jj", "jj", "jj" };
            var createdListOfStrings = "jj".CreateCollection(4);


            Assert.Equal(stringList, createdListOfStrings);
        }

        [Fact]
        public void CreateCollection_ListOfObjects_Correct()
        {
            var stringList = new List<object>() { "jj", "jj", "jj", "jj" };
            var createdListOfStrings = ((object)"jj").CreateCollection(4);

            Assert.Equal(stringList, createdListOfStrings);
        }


        [Fact]
        public void CreateCollection_ListOfCustomClass_Correct()
        {
            var reference = new List<Equatable>() {
                new Equatable("j"),
                new Equatable("j"),
                new Equatable("j"),
                new Equatable("j")
            };
            var classRef = new Equatable("j");
            var objects = classRef.CreateCollection(4).ToList();



            Assert.Equal(reference, objects);
        }

        [Fact]
        public void RemoveAtWithNegative_removeLast_Correct()
        {
            var reference = new String[] { "jhjk", "hjkll", "crcrd" };

            var strings = new String[] { "jhjk", "hjkll", "crcrd", "opikop" };
            var obj = strings.RemoveAtWithNegative(-1).ToArray();


            Assert.Equal(reference, obj);

        }

        [Fact]
        public void RemoveAtWithNegative_removeFirst_Correct()
        {
            var reference = new String[] { "hjkll", "crcrd", "opikop" };

            var strings = new String[] { "jhjk", "hjkll", "crcrd", "opikop" };
            var obj = strings.RemoveAtWithNegative(0).ToArray();


            Assert.Equal(reference, obj);

        }

        [Fact]
        public void SelectWithNegative_getLast_Correct()
        {
            var reference = "opikop";

            var strings = new String[] { "jhjk", "hjkll", "crcrd", "opikop" };
            var obj = strings.SelectAtWithNegative(-1).ToArray();


            Assert.Equal(reference, obj);

        }

        [Fact]
        public void SelectWithNegative_getFirst_Correct()
        {
            var reference = "jhjk";

            var strings = new String[] { "jhjk", "hjkll", "crcrd", "opikop" };
            var obj = strings.SelectAtWithNegative(0).ToArray();


            Assert.Equal(reference, obj);

        }

        
        #if NET5_0
        [Fact]
        public void MaxIndex()
        {
            var anArray = new int[] { 1, 5, 7, 0 };

            var obj = anArray.MaxIndex();

            Assert.Equal(2, obj);

        }
        #endif
    }
}
