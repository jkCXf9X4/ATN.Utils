using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATN.Utils.Time
{
    public enum DatetimeFormat
    {
        /// <summary>
        /// If “UNIX” is specified DateTime fields will be specified or returned in the “12345678.000000123” format.
        /// </summary>
        Unix,

        /// <summary>
        /// If “RFC3339” is specified DateTime will be specified or returned in “YYYY-MM-DDTHH:MM:SS.nnnnnnnnnZ” format.
        /// </summary>
        RFC3339
    }
}
