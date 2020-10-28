using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATN.Utils.Trade.Forex.SimpleSimulation
{
    public class TradeHandlerMid
    {
        double spread;

        SimpleTrade currentTrade;

        public TradeHandlerMid(double spread)
        {
            this.spread = spread;
        }
        /// <summary>
        /// Return the cost of the transaction
        /// </summary>
        /// <param name="units"></param>
        /// <param name="rate"></param>
        /// <returns></returns>
        public double Open(double units, TradeType tradeType, double rate)
        {
            double balance = 0;

            if (currentTrade != null)
            {
                if (tradeType == TradeType.Long && currentTrade?.TypeOfTrade == TradeType.Short
                    ||
                    tradeType == TradeType.Short && currentTrade?.TypeOfTrade == TradeType.Long)
                {
                    var closeValue = Close(rate);

                    var openValue = OpenInternal(units, tradeType, rate);

                    return openValue - closeValue;
                }
            }
            else
            {
                return OpenInternal(units, tradeType, rate);
            }
            return balance;
        }

        /// <summary>
        /// Return the sales value deducted by the spread
        /// </summary>
        /// <param name="rate"></param>
        /// <returns></returns>
        public double Close(double rate)
        {
            if (currentTrade?.tradeStatus == TradeStatus.Open)
            {
                var balance = currentTrade.Close(rate);
                currentTrade = null;

                return balance - Spread(balance, this.spread);
            }
            return 0;
        }

        private double OpenInternal(double units, TradeType tradeType, double rate)
        {
            if (currentTrade?.tradeStatus != TradeStatus.Open)
            {
                currentTrade = new SimpleTrade(units, tradeType);

                return currentTrade.Open(rate);
            }
            return 0;
        }

        /// <summary>
        /// Value of current trade deducted by half the spread
        /// </summary>
        /// <param name="rate"></param>
        /// <returns></returns>
        public double GetValue(double rate)
        {
            if (currentTrade?.tradeStatus == TradeStatus.Open)
            {
                var balance = currentTrade.GetBalance(rate);

                return balance - Spread(balance, this.spread) / 2.0;
            }
            return 0;

        }

        private double Spread(double units, double spread)
        {
            return units * spread;
        }
    }
}
