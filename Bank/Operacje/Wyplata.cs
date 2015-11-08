using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bank
{
    public class Wyplata : Operacja
    {
        private Pieniadze pieniadze;
        private RachunekBankowy rachunek;


        public Wyplata(RachunekBankowy rachunek, Pieniadze pieniadze)
        {
            this.pieniadze = pieniadze;
            this.rachunek = rachunek;
        }

        public override string Opis()
        {
            return String.Format("wyplata {0} z {1}",pieniadze,rachunek);
        }

        public override bool Wykonaj()
        {
            return rachunek.WyplacPieniadze(pieniadze);
        }

        public override Klient Klient()
        {
            return rachunek.Klient();
        }
        public override ProduktBankowy Produkt()
        {
            return rachunek;
        }
    }
}
