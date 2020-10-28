using Xunit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATN.Utils.Trade.Forex.SimpleSimulation
{
    
    public class SimpleTradeHandler_Test
    {
        [Theory]
        [InlineData(100, TradeType.Long, 1, 100)]
        [InlineData(100, TradeType.Short, 1, 100)]
        [InlineData(100, TradeType.Long, 2, 50)]
        [InlineData(100, TradeType.Short, 2, 50)]
        [InlineData(100, TradeType.Long, 0.5, 200)]
        [InlineData(100, TradeType.Short, 0.5, 200)]
        public void OpenTrade(double units, TradeType tradeType, double rate, double expected)
        {
            var handler = new TradeHandlerMid(0);

            var cost =  handler.Open(units, tradeType, rate);

            Assert.Equal(expected, cost);
        }

        [Theory]
        [InlineData(100, TradeType.Long, 1)]
        [InlineData(100, TradeType.Short, 1)]
        [InlineData(100, TradeType.Long, 2)]
        [InlineData(100, TradeType.Short, 2)]
        [InlineData(100, TradeType.Long, 0.5)]
        [InlineData(100, TradeType.Short, 0.5)]
        public void CloseTrade(double units, TradeType tradeType, double rate)
        {
            var handler = new TradeHandlerMid(0);
            var cost = handler.Open(units, tradeType, rate);

            var profit = handler.Close(rate);

            Assert.Equal(cost, profit);
        }

        [Theory]
        [InlineData(100, TradeType.Long, 1, 100)]
        [InlineData(100, TradeType.Short, 1, 100)]
        [InlineData(100, TradeType.Long, 2, 50)]
        [InlineData(100, TradeType.Short, 2, 50)]
        [InlineData(100, TradeType.Long, 0.5, 200)]
        [InlineData(100, TradeType.Short, 0.5, 200)]
        public void GetValue(double units, TradeType tradeType, double rate, double expected)
        {
            var handler = new TradeHandlerMid(0);

            handler.Open(units, tradeType, rate);

            var value = handler.GetValue(rate);

            Assert.Equal(expected, value);
        }

        [Theory]
        [InlineData(100, TradeType.Long, 1)]
        [InlineData(100, TradeType.Short, 1)]
        [InlineData(100, TradeType.Long, 2)]
        [InlineData(100, TradeType.Short, 2)]
        [InlineData(100, TradeType.Long, 0.5)]
        [InlineData(100, TradeType.Short, 0.5)]
        public void CloseTrade_Spread(double units, TradeType tradeType, double rate)
        {
            var handler = new TradeHandlerMid(0.5);
            var cost = handler.Open(units, tradeType, rate);

            var profit = handler.Close(rate);

            Assert.Equal(cost/2, profit);
        }

        [Theory]
        [InlineData(100, TradeType.Long, 1)]
        [InlineData(100, TradeType.Short, 1)]
        [InlineData(100, TradeType.Long, 2)]
        [InlineData(100, TradeType.Short, 2)]
        [InlineData(100, TradeType.Long, 0.5)]
        [InlineData(100, TradeType.Short, 0.5)]
        public void GetValue_spread(double units, TradeType tradeType, double rate)
        {
            var handler = new TradeHandlerMid(0.5);

            var cost = handler.Open(units, tradeType, rate);

            var value = handler.GetValue(rate);

            Assert.Equal(cost*0.75, value);
        }

        [Theory]
        [InlineData(100, TradeType.Long, 1, 2, 200)]
        [InlineData(100, TradeType.Short, 1, 2, 0)]
        [InlineData(100, TradeType.Long, 1, 0.5, 50)]
        [InlineData(100, TradeType.Short, 1, 0.5, 150)]

        public void Close_diff_rate(double units, TradeType tradeType, double initialRate, double finalRate, double expected)
        {
            var handler = new TradeHandlerMid(0);

            handler.Open(units, tradeType, initialRate);

            var value = handler.Close(finalRate);

            Assert.Equal(expected, value);
        }

        [Theory]
        [InlineData(100, TradeType.Long, TradeType.Long, 1, 2, 4, 0, 400)]
        [InlineData(100, TradeType.Short, TradeType.Short, 1, 1.5, 1.8, 0, 20)]
        [InlineData(100, TradeType.Long, TradeType.Short, 1, 2, 1, 150, 250)]
        [InlineData(100, TradeType.Short, TradeType.Long, 1, 1.6, 1, -22.5, 2.5)]
        public void OpenOpenClose(
            double units, 
            TradeType firstTradeType, TradeType secondTradeType, 
            double initialRate, double secondRate, double finalRate, 
            double firstExpected, double secondExpected)
        {
            var handler = new TradeHandlerMid(0);

            var balance = 100.0;

            balance -= handler.Open(units, firstTradeType, initialRate);

            balance -= handler.Open(units, secondTradeType, secondRate);

            Assert.Equal(firstExpected, System.Math.Round( balance,2));

            balance += handler.Close(finalRate);

            Assert.Equal(secondExpected, System.Math.Round(balance, 2));
        }
    }
}
