using Xunit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATN.Utils.Collection.Que
{
    
    public class FixedSizedQueue_Test
    {
        [Fact]
        public void Test_ToString()
        {
            var que = new FixedSizedQueue<int>(5);

            foreach(var i in new List<int>() { 1, 2, 3, 4 })
            {
                que.Enqueue(i);
            }
            

            Assert.Equal("1, 2, 3, 4", que.ToString());
        }

        [Fact]
        public void BasicAdd()
        {
            var que = new FixedSizedQueue<int>(5);

            foreach (var i in new List<int>() { 1, 2, 3, 4 })
            {
                que.Enqueue(i);
            }

            que.Enqueue(5);

            Assert.Equal("1, 2, 3, 4, 5", que.ToString());
        }


        [Fact]
        public void BasicAdd2()
        {
            var que = new FixedSizedQueue<int>(5) ;

            foreach (var i in new List<int>() { 1, 2, 3, 4, 5 })
            {
                que.Enqueue(i);
            }

            que.Enqueue(6);

            Assert.Equal("2, 3, 4, 5, 6", que.ToString());
        }

        [Fact]
        public void BasicAdd3()
        {
            var que = new FixedSizedQueue<int>(5) ;

            foreach (var i in new List<int>() { 1, 2, 3, 4, 5, 6, 7 })
            {
                que.Enqueue(i);
            }

            Assert.Equal("3, 4, 5, 6, 7", que.ToString());
        }
    }
}
