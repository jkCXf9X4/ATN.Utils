using Xunit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ATN.Utils.UnitTests.Helper
{
    [Serializable]
    public class Equatable : IEquatable<Equatable>
    {
        string i;
        public Equatable(string i)
        {
            this.i = i;
        }

        public bool Equals(Equatable other)
        {
            if (this.i == other.i)
            {
                return true;
            }

            return false;
        }
    }
}

