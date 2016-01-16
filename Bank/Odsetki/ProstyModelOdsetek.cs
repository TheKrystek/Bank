using Bank.Odsetki;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bank
{
  public  class LiniowyModelOdsetek : IModelOdsetek
    {
        double oprocentowanie;
        public LiniowyModelOdsetek(double oprocentowanie) {
            this.oprocentowanie = oprocentowanie;
        }

        public Pieniadze Oblicz(ProduktBankowy produkt)
        {
            return Oblicz((Pieniadze)produkt.DostepneSrodki().Clone());
        }


        // Prosty iloczyn odsetki = kwota * oprocentowanie
        public Pieniadze Oblicz(Pieniadze odsetki)
        {
            double nowaWartosc = odsetki.Wartosc * oprocentowanie / 100;
            odsetki.Wartosc = (int)nowaWartosc;
            return odsetki;           
        }
    }
}
