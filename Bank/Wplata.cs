using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bank
{
    public class Wplata : Operacja
    {
        private Pieniadze pieniadze;
        private RachunekBankowy rachunek;

        public Wplata(RachunekBankowy rachunek, Pieniadze pieniadze) {
            this.pieniadze = pieniadze;
            this.rachunek = rachunek;
        }

        public override string Opis()
        {
            return String.Format("wpłata {0} na {1}",pieniadze,rachunek);
        }

        public override bool Wykonaj()
        {
            return rachunek.WplacPieniadze(pieniadze);
        }
    }
}
