using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bank
{
    public class PrzelewZewnetrzny : OperacjaProsta
    {

        private IOperacja operacja;
        private RachunekBankowy rachunek;
        private int rachunekDocelowy;
        private Bank bank;
        PrzelewanePieniadze p;

        public PrzelewZewnetrzny(RachunekBankowy rachunek, int rachunekDocelowy, Pieniadze pieniadze, Bank bank)
        {
            this.rachunek = rachunek;
            this.rachunekDocelowy = rachunekDocelowy;
            this.bank = bank;

            p = new PrzelewanePieniadze
            {
                id = rachunekDocelowy,
                pieniadze = pieniadze
            };

            operacja = new Wyplata(rachunek, pieniadze);
        }



        public override string Opis()
        {
            return string.Format("przelew z {0} na {1}", rachunek, rachunekDocelowy);
        }

        public override bool Wykonaj()
        {
            if (!operacja.Wykonaj())
                return false;

            bank.DodajDoPaczki(p);

            return true;
        }
    }
}
