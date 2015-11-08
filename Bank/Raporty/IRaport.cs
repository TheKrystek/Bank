using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Bank.Raporty
{
    interface IRaport
    {
        string Wynik();

        void Generuj();
    }
}
