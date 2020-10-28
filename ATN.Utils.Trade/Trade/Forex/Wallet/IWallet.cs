using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATN.Utils.Trade.Forex.Wallet
{
    public interface IWallet
    {
        double Balance { get; set; }

        bool Open(TradeType tradeType, double units, double rate);

        bool Close(double rate);

        //double GetValue(double rate);

        //double GetProfit(double rate);

        //List<double> ProfitHistory { get; }
        //List<double> ValueHistory { get; }
    }
}
