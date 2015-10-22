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
            return String.Format("przelew {0} z {1} na {2}",pieniadze,rachunekA,rachunekB);
        }

        public override bool Wykonaj()
        {
            if (!operacjaPierwsza.Wykonaj())
                return false;

            return operacjaDruga.Wykonaj();
        }


        public override Klient Klient()
        {
            return rachunekA.Klient();
        }
    }
}
