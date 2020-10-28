using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATN.Utils.Trade
{
    public enum TradeType
    {

        Short = 0,
        Long = 1,
        NA = 2
    }

    public enum TradeStatus
    {
        Closed = 0,
        Open = 1,
        NA = 2
    }

    public enum TradeAction
    {
        Buy = 0,
        Close= 1,
        Sell = 2,
        //Hold= 3,
    }
}
