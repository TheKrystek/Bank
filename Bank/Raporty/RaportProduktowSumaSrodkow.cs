using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bank.Raporty
{
    class RaportProduktowSumaSrodkow : IRaportProdutkow
    {
        Pieniadze srodki;
        Pieniadze.Waluty waluta;
        ICollection<ProduktBankowy> produkty;

        public RaportProduktowSumaSrodkow(ICollection<ProduktBankowy> produkty, Pieniadze.Waluty waluta)
        {
            this.produkty = produkty;
            this.waluta = waluta;
            this.srodki = new Pieniadze(0,waluta);
        }

        public string Wynik()
        {
            return string.Format("Suma pieniędzy w walucie {0} wynosi: {1}", waluta,srodki);
        }

        public void Odwiedz(ICollection<ProduktBankowy> produkty)
        {
            foreach (var item in produkty)
                srodki += item.DostepneSrodki();
        }


        public void Generuj()
        {
            Odwiedz(produkty);
        }
    }
}
