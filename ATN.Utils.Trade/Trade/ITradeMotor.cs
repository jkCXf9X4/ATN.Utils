using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATN.Utils.Trade
{
    public interface ITradeMotor
    {
        bool Open(decimal units);

        Task<bool> OpenAsync(decimal units);

        bool Close();

        Task<bool> CloseAsync();
    }
}
