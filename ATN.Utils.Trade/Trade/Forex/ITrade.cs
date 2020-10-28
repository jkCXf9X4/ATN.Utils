using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATN.Utils.Trade.Forex
{
    public interface ITrade
    {
        bool Open(double units, double rate);

        bool Close();
    }
}
