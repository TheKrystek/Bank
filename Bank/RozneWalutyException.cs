using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bank
{
     public class RozneWalutyException : Exception
    {
         public RozneWalutyException(string message)
            : base(message)
        { }
    }

}
