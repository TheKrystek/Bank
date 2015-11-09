using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bank
{
    public class Przelew : OpracjaZlozona
    {
        private Pieniadze pieniadze;
        private RachunekBankowy rachunekA, rachunekB;


        public Przelew(RachunekBankowy rachunekA, RachunekBankowy rachunekB, Pieniadze pieniadze)
        {
            this.rachunekA = rachunekA;
            this.rachunekB = rachunekB;

            operacjaPierwsza = new Wyplata(rachunekA, pieniadze);
            operacjaDruga = new Wplata(rachunekB, pieniadze);
        }

        public override string Opis()
        {
            return String.Format("przelew z {0} na {1}", rachunekA, rachunekB);
        }

        public override bool Wykonaj()
        {
            if (!operacjaPierwsza.Wykonaj())
                return false;

            bool wynik = operacjaDruga.Wykonaj();
            return wynik;
        }
    }
}
