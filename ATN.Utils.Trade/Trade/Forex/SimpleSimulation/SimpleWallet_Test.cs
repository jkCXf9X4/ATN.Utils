using Xunit;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATN.Utils.Trade.Forex.SimpleSimulation
{

    public class SimpleWallet_Test
    {

        [Fact]
        public void SimpleSenario()
        {
            var wallet = new SimpleWallet(100000, 0.0001);

            wallet.Open(TradeType.Long, 100000, 1.1);

            Assert.Equal(9091, System.Math.Round(wallet.Balance));

            wallet.Open(TradeType.Short, 100000, 1.2);

            Assert.Equal(25748, System.Math.Round(wallet.Balance));

            wallet.Close(1.0);

            Assert.Equal(125738, System.Math.Round(wallet.Balance));

            wallet.Open(TradeType.Long, 100000, 1.1);

            Assert.Equal(34828, System.Math.Round(wallet.Balance));

            wallet.Close(0.9);

            Assert.Equal(107548, System.Math.Round(wallet.Balance));

            wallet.Open(TradeType.Long, 100000, 1.2);
            wallet.Open(TradeType.Short, 100000, 1.0);

            Assert.Equal(-9125, System.Math.Round(wallet.Balance));

            wallet.Close(0.9);

            Assert.Equal(100864, System.Math.Round(wallet.Balance));

            Debug.WriteLine(String.Join(", ", wallet.ProfitHistory));
            Debug.WriteLine(String.Join(", ", wallet.ValueHistory));
        }
        [Fact]
        public void SimpleSenario_History()
        {
            var wallet = new SimpleWallet(100000, 0.0001);

            wallet.Open(TradeType.Long, 100000, 1.1);
            wallet.Open(TradeType.Long, 100000, 1.2);
            wallet.Close(1.0);
            wallet.Open(TradeType.Short, 100000, 1.1);
            wallet.Close(0.9);

            wallet.Open(TradeType.Long, 100000, 1.2);
            wallet.Open(TradeType.Short, 100000, 1.0);
            wallet.Close(0.9);

            Debug.WriteLine(String.Join(", ", wallet.ProfitHistory));
            Debug.WriteLine(String.Join(", ", wallet.ValueHistory));

            Assert.Equal(9, wallet.ProfitHistory.Count);
            Assert.Equal(9, wallet.ValueHistory.Count);
        }

        [Fact]
        public void SimpleSenario_DoubleClose()
        {
            var wallet = new SimpleWallet(100, 0.01);

            wallet.Open(TradeType.Long, 100000, 1.2);
            wallet.Close(1.0);
            wallet.Close(0.9);

            Debug.WriteLine(String.Join(", ", wallet.ProfitHistory));
            Debug.WriteLine(String.Join(", ", wallet.ValueHistory));

            Assert.Equal(119, System.Math.Round(wallet.Balance));
        }

        [Fact]
        public void SimpleSenario_DoubleOpenShort()
        {
            var wallet = new SimpleWallet(100, 0.01);

            wallet.Open(TradeType.Short, 100000, 1.2);
            wallet.Open(TradeType.Short, 100000, 1.0);
            wallet.Close(0.9);

            Debug.WriteLine(String.Join(", ", wallet.ProfitHistory));
            Debug.WriteLine(String.Join(", ", wallet.ValueHistory));

            Assert.Equal(129, System.Math.Round(wallet.Balance));
        }

        [Fact]
        public void SimpleSenario_DoubleOpenLong()
        {
            var wallet = new SimpleWallet(100, 0.01);

            wallet.Open(TradeType.Long, 100, 1.2);
            wallet.Open(TradeType.Long, 100, 1.0);
            wallet.Open(TradeType.Long, 100, 1.0);
            wallet.Open(TradeType.Long, 100, 1.0);
            wallet.Close(0.9);

            Debug.WriteLine(String.Join(", ", wallet.ProfitHistory));
            Debug.WriteLine(String.Join(", ", wallet.ValueHistory));

            Assert.Equal(69, System.Math.Round(wallet.Balance));
        }

    }
}
