using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bank
{
    public class NaliczOdsetkiNaRachunku : Operacja
    {

        private IModelOdsetek modelOdsetek;
        private RachunekBankowy rachunek;
        private int rata;

        public NaliczOdsetkiNaRachunku(RachunekBankowy rachunek, IModelOdsetek modelOdsetek, int rata = 1)
        {
            this.modelOdsetek = modelOdsetek;
            this.rachunek = rachunek;
            this.rata = rata;
        }

        public override string Opis()
        {
            return String.Format("naliczenie odsetek wys {0}% na koncie {1}", modelOdsetek.DajOprocentowania(rata), rachunek);
        }

        public override bool Wykonaj()
        {
            Pieniadze przyrost = modelOdsetek.Oblicz(rachunek.Pieniadze,rata);
            return rachunek.Pieniadze.Dodaj(przyrost);
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
