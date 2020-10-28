using ATN.Utils.Trade.Forex.Wallet;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATN.Utils.Trade.Forex.SimpleSimulation
{
    public class SimpleWallet : IWallet
    {
        public double Balance { get; set; }

        TradeHandlerMid tradeHandler;


        protected List<double> profitHistory = new List<double>();
        protected List<double> valueHistory = new List<double>();

        public List<double> ProfitHistory { get { return profitHistory; } }
        public List<double> ValueHistory { get { return valueHistory; } }

        public SimpleWallet(double balance, double spread)
        {
            this.Balance = balance;

            valueHistory.Add(this.Balance);
            profitHistory.Add(0);

            tradeHandler = new TradeHandlerMid(spread);
        }

        public bool Open(TradeType tradeType, double units, double rate)
        {
            Balance -= tradeHandler.Open(units, tradeType, rate);
            UpdateValue(rate);
            return true;
        }

        public bool Close(double rate)
        {
            Balance += tradeHandler.Close(rate);
            UpdateValue(rate);
            return true;
        }

        public bool Hold(double rate)
        {
            UpdateValue(rate);
            return true;
        }

        private void UpdateValue(double rate)
        {
            double value = GetValue(rate);
            double profit = GetProfit(rate);

            valueHistory.Add(value);
            profitHistory.Add(profit);
        }

        public double GetProfit(double rate)
        {
            return GetValue(rate) - valueHistory.Last();
        }

        public double GetValue(double rate)
        {
            return Balance + tradeHandler.GetValue(rate);
        }

        public double GetChangeRatio()
        {
            return valueHistory.Last() / valueHistory.First();
        }


    }
}
