using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bank
{
    public class RachunekDebetowy : RachunekBankowy
    {
        private Debet debet;
        public RachunekDebetowy(Klient klient, Debet debet, Int64 id = 0)
            : base(klient, id)
        {
            this.debet = debet;
        }


        public override bool WplacPieniadze(Pieniadze pieniadze)
        {
            try
            {
                Pieniadze reszta = debet.Dodaj(pieniadze);     
                this.pieniadze += reszta;
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }


        public Pieniadze DostepneSrodki() {
            return debet.Stan + pieniadze;
        }

        public override bool WyplacPieniadze(Pieniadze pieniadze)
        {
            if (!CzyDostepnePieniadze(pieniadze))
                return false;

            // Jezeli mamy dostepne pieniadze to nie ruszamy debetu
            if (this.pieniadze >= pieniadze)
                return base.WyplacPieniadze(pieniadze);

            // Jezeli brakuje nam srodkow to sprawdz czy debet plus dost pieniadze zalatwiaja sprawe
            Pieniadze sumaSrodkow = new Pieniadze(0, pieniadze.Waluta);
            sumaSrodkow.Dodaj(this.pieniadze);
            sumaSrodkow.Dodaj(debet.Stan);

            if (sumaSrodkow.Wartosc >= pieniadze.Wartosc)
            {
                Pieniadze pobrane = new Pieniadze(pieniadze.Wartosc, pieniadze.Waluta);
                pobrane.Odejmij(this.pieniadze);

                this.pieniadze = new Pieniadze(0, pieniadze.Waluta);
                debet.Pobierz(pobrane);
                return true;
            }

            return false;
        }


        protected override bool CzyDostepnePieniadze(Pieniadze pieniadze)
        {
            if (this.pieniadze.Waluta != pieniadze.Waluta)
                return false;

            return (this.pieniadze.Wartosc + this.debet.Stan.Wartosc >= pieniadze.Wartosc);
        }


        public override string ToString()
        {
            Pieniadze suma = new Pieniadze();
            suma.Dodaj(pieniadze);
            suma.Dodaj(debet.Stan);
            return String.Format("Rachunek debetowy {0} klienta {1}.\r\nSaldo: {2}, Debet: {3}/{4}, Dostępne środki: {5}", Id, klient, pieniadze, debet.Stan, debet.Limit, suma);
        }

    }
}
