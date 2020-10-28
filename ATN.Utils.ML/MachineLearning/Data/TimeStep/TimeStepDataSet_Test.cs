using Xunit;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATN.Utils.MachineLearning.Data.TimeStep
{

    public class TimeStepDataSet_Test
    {
        [Fact]
        public void Add_check_first()
        {
            List<int> X = new List<int> { 1, 2, 3, 4, 5 };

            var dataEnum = new TimeStepDataSet<int>(X, 1);

            Assert.Equal(1, dataEnum[0].XValue);
            Assert.Equal(2, dataEnum[0].YValue);
        }

        [Fact]
        public void Add_check_last()
        {
            List<int> X = new List<int> { 1, 2, 3, 4, 5 };

            var dataEnum = new TimeStepDataSet<int>(X, 1);

            Assert.Equal(4, dataEnum[3].XValue);
            Assert.Equal(5, dataEnum[3].YValue);
        }

        [Fact]
        public void Foreach_test()
        {
            List<int> X = new List<int> { 1, 2, 3, 4, 5 };

            var trainingData = new TimeStepDataSet<int>(X, 1);

            string output = "";

            foreach (var i in trainingData)
            {
                output += $"{i.XValue}:{i.YValue},";
            }
            Assert.Equal("1:2,2:3,3:4,4:5,", output);
        }
        [Fact]
        public void Foreach_test2()
        {
            List<int> X = new List<int> { 1, 2, 3, 4, 5 };

            var trainingData = new TimeStepDataSet<int>(X, 3);

            string output = "";

            foreach (var i in trainingData)
            {
                output += $"{i.XValue}:{i.YValue},";
            }
            Assert.Equal("1:4,2:5,", output);
        }

        [Fact]
        public void Posistion_start_test()
        {
            List<int> X = new List<int> { 1, 2, 3, 4, 5 };

            var trainingData = new TimeStepDataSet<int>(X, 1);

            Assert.Throws<ArgumentOutOfRangeException>(() => trainingData.Current);



        }

        [Fact]
        public void Posistion_first_step_test()
        {
            List<int> X = new List<int> { 1, 2, 3, 4, 5 };

            var trainingData = new TimeStepDataSet<int>(X, 1);

            trainingData.MoveNext();

            var i = trainingData.Current;

            Assert.Equal(1, i.XValue);
            Assert.Equal(2, i.YValue);
        }

        [Fact]
        public void Set_Posistion_test()
        {
            List<int> X = new List<int> { 1, 2, 3, 4, 5 };

            var trainingData = new TimeStepDataSet<int>(X, 2);

            trainingData.SetPosition(2);

            var i = trainingData.Current;

            Assert.Equal(3, i.XValue);
            Assert.Equal(5, i.YValue);
        }

        [Fact]
        public void Count_test()
        {
            List<int> X = new List<int> { 1, 2, 3, 4, 5 };

            var trainingData = new TimeStepDataSet<int>(X, 1);

            Assert.Equal(4, trainingData.Count);
        }
    }
}
