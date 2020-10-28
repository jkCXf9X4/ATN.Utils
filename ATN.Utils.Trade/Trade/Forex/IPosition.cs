using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATN.Utils.Trade.Forex
{
    public interface IPosition
    {
        bool Open(ITrade trade, decimal rate);

        bool Close(ITrade trade, decimal rate);
    }
}
