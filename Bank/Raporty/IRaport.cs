using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Bank.Raporty
{
    public interface IRaport
    {
        void ObsluzHistorie(WpisWHistorii historia);
        void ObsluzOperacje(IOperacja operacja);
        void ObsluzKlienta(Klient klient);

        // W sumie tu powinny być jeszcze metody do obslugi wszystkich klas podrzędnych do produktu bankowego
        void ObsluzProduktBankowy(ProduktBankowy produkt);

        string Wynik();
    }
}
