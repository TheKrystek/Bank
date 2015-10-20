using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bank
{
    public class Debet
    {
        Pieniadze max;
        Pieniadze dostpieniadze;


        public Debet(Pieniadze max) {
            this.max = max;
            this.dostpieniadze = new Pieniadze(max.Wartosc,max.Waluta);
        }

        public Pieniadze Maxpieniadze
        {
            get { return max; }
        }
     
        public Pieniadze Dostpieniadze
        {
            get { return dostpieniadze; }
            set { dostpieniadze = value; }
        }


        public bool Pobierz(Pieniadze pieniadze) {
            if (Pieniadze.RozneWaluty(dostpieniadze,pieniadze))
                return false;

            if (dostpieniadze.Wartosc < pieniadze.Wartosc)
                return false;

            dostpieniadze.Odejmij(pieniadze);

            return true;
        }


        public Pieniadze Dodaj(Pieniadze pieniadze)
        {
            if (!Pieniadze.RozneWaluty(dostpieniadze,pieniadze))
                return pieniadze;

            if (pieniadze.Wartosc > max.Wartosc)
            {
                pieniadze.Odejmij(dostpieniadze);
                dostpieniadze = new Pieniadze(max.Wartosc, max.Waluta);
            }
            else
                dostpieniadze.Dodaj(new Pieniadze(0,max.Waluta));

            return pieniadze;
        }

    }
}
