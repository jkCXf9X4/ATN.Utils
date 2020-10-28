using Xunit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATN.Utils.MachineLearning.Reinforcement.Statistics
{
    
    public class ActionCounter_Test
    {
        enum TradeAction_temp
        {
            Buy,
            Close,
            Sell,
            Error
        }
        [Fact]
        public void Initialize()
        {
            var counter = new AnalyzeActions<TradeAction_temp>();

            Assert.Equal(4, counter.PossibleActions);
        }

        [Fact]
        public void FinalCounter()
        {
            var counter = new AnalyzeActions<TradeAction_temp>();

            counter.Step(TradeAction_temp.Buy);

            var finalCount = counter.GetCounter();

            Assert.Equal(new List<int>(){1,0,0,0} , finalCount);
        }

        [Fact]
        public void ToString_test()
        {
            var counter = new AnalyzeActions<TradeAction_temp>();

            counter.Step(TradeAction_temp.Buy);
            counter.Step(TradeAction_temp.Buy);
            counter.Step(TradeAction_temp.Buy);


            counter.Step(TradeAction_temp.Close);
            counter.Step(TradeAction_temp.Sell);

            var finalCount = counter.GetCounter();

            Assert.Equal("3, 1, 1, 0", counter.ToString());

        }

        [Fact]
        public void GetPercentages_test()
        {
            var counter = new AnalyzeActions<TradeAction_temp>();

            counter.Step(TradeAction_temp.Buy);
            counter.Step(TradeAction_temp.Buy);
            counter.Step(TradeAction_temp.Buy);


            counter.Step(TradeAction_temp.Close);
            counter.Step(TradeAction_temp.Sell);

            var finalCount = counter.GetActionPercentage();

            Assert.Equal(new List<double>() { 0.6, 0.2, 0.2, 0 }, finalCount);

        }


    }
}
