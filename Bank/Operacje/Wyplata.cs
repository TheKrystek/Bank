using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bank
{
    public class Wyplata : OperacjaProsta
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
            return String.Format("wyplata pieniędzy z {0}",rachunek);
        }

        public override bool Wykonaj()
        {
            historia.Add(new WpisWHistorii(this, rachunek, pieniadze));
            return rachunek.WyplacPieniadze(pieniadze.Clone() as Pieniadze);
        }
    }
}
