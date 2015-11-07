using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bank
{
    /// <summary>
    /// Interfejs definiujący operacje
    /// </summary>
    public interface IOperacja
    {
        bool Wykonaj();
    }
}
