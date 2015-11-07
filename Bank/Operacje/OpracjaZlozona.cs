using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bank
{
    /// <summary>
    /// Klasa rozszerzająca operację 
    /// </summary>
    public abstract class OpracjaZlozona : Operacja
    {
        protected Operacja operacjaPierwsza, operacjaDruga;
    }
}
