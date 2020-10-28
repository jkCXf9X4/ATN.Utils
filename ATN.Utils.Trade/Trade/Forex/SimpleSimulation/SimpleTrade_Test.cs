using Xunit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATN.Utils.Trade.Forex.SimpleSimulation
{

    public class SimpleTrade_Test
    {
        [Theory]
        [InlineData(100000, TradeType.Long, 1.09466, 91352.566)]
        [InlineData(100000, TradeType.Short, 1.09466, 91352.566)]
        public void Balance_open(double units, TradeType tradeType, double rate, double expected)
        {
            var pos = new SimpleTrade(units, tradeType);

            var balance = pos.Open(rate);

            Assert.Equal(expected, System.Math.Round(balance, 3));
        }

        [Theory]
        [InlineData(100000, TradeType.Long, 1.09496, 0.0003, 27.398)]
        [InlineData(100000, TradeType.Long, 1.09496, -0.0003, -27.398)]
        [InlineData(100000, TradeType.Short, 1.09496, -0.0003, 27.398)]
        [InlineData(100000, TradeType.Short, 1.09496, 0.0003, -27.398)]
        public void Profit(double units, TradeType tradeType, double rate, double changeInRate, double expected)
        {
            var pos = new SimpleTrade(units, tradeType);

            pos.Open(rate);

            var finalRate = rate + changeInRate;

            pos.Close(finalRate);

            Assert.Equal(expected, System.Math.Round(pos.Profit, 3));
        }

        [Theory]
        [InlineData(100000, TradeType.Long, 1.09466, 0.002, 91352.57, 91535.27)]
        [InlineData(100000, TradeType.Long, 1.09466, -0.002, 91352.57, 91169.86)]
        [InlineData(100000, TradeType.Short, 1.09466, 0.002, 91352.57, 91169.86)]
        [InlineData(100000, TradeType.Short, 1.09466, -0.002, 91352.57, 91535.27)]
        public void Balance2(double units, TradeType tradeType, double rate, double changeInRate, double expected , double expected2)
        {
            var pos = new SimpleTrade(units, tradeType);

            pos.Open(rate);

            Assert.Equal(expected, System.Math.Round(pos.Balance, 2));

            var finalRate = rate + changeInRate;

            pos.Close(finalRate);

            Assert.Equal(expected2, System.Math.Round(pos.Balance, 2));
        }

        [Theory]
        [InlineData(100000, TradeType.Long)]
        [InlineData(-100000, TradeType.Short)]
        public void PosType(double units, TradeType expected)
        {
            var pos = new SimpleTrade(units, expected);

            pos.Open(1.0);

            Assert.Equal(expected, pos.TypeOfTrade);
        }

        [Fact]
        public void FinalProfitLong_CatchClosed()
        {
            var units = 100000;
            var tradeType = TradeType.Long;
            var initialRate = 1.10375;

            var change = 0.002;

            var finalRate = initialRate + change;

            var pos = new SimpleTrade(units, tradeType);

            pos.Open(initialRate);

            pos.Close(finalRate);

            Assert.Throws<Exception>(() => pos.Close(finalRate));
        }

    }
}
