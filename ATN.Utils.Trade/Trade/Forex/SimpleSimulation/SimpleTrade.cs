using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATN.Utils.Trade.Forex.SimpleSimulation
{
    public class SimpleTrade
    {
        double initialRate;
        double currentRate;

        public TradeStatus tradeStatus = TradeStatus.NA;

        public TradeType TypeOfTrade;

        public double Units { get; set; }

        public double InitialBalance
        {
            get { return Units / initialRate; }
        }

        public double Balance
        {
            get
            {
                return InitialBalance + Profit;
            }
        }

        public double Profit
        {
            get
            {
                return InitialBalance * EffectiveRate;
            }
        }

        public double EffectiveRate
        {
            get
            {
                if (TypeOfTrade == TradeType.Long)
                {
                    return this.currentRate - initialRate;
                }
                else
                {
                    return initialRate - this.currentRate;
                }
            }
        }

        public SimpleTrade(double units, TradeType type)
        {
            TypeOfTrade = type;
            this.Units = System.Math.Abs(units);
        }

        public double Open(double rate)
        {
            CheckClosed();
            tradeStatus = TradeStatus.Open;

            this.initialRate = rate;
            this.currentRate = rate;

            return InitialBalance;
        }

        public void SetCurrentRate(double rate)
        {
            CheckClosed();
            this.currentRate = rate;
        }

        public double GetBalance(double rate)
        {
            CheckClosed();
            this.currentRate = rate;

            return Balance;
        }

        public double Close(double rate)
        {
            SetCurrentRate(rate);
            return Close();
        }

        /// <summary>
        /// Return final value of trade
        /// </summary>
        /// <param name="units"></param>
        /// <param name="currentRate"></param>
        /// <returns></returns>
        public double Close()
        {
            CheckClosed();

            this.tradeStatus = TradeStatus.Closed;

            return Balance;
        }

        private void CheckClosed()
        {
            if (this.tradeStatus == TradeStatus.Closed)
            {
                throw new Exception("Trade is already closed");
            }
        }
    }
}
