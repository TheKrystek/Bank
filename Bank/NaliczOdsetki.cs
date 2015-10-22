using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bank
{
    public class NaliczOdsetki : Operacja
    {

        private ModelOdsetek modelOdsetek;
        private RachunekBankowy rachunek;


        public NaliczOdsetki(RachunekBankowy rachunek, ModelOdsetek modelOdsetek)
        {
            this.modelOdsetek = modelOdsetek;
            this.rachunek = rachunek;
        }

        public override string Opis()
        {
            return String.Format("naliczenie odsetek wys {0}% na koncie {1}", modelOdsetek.DajOprocentowania(), rachunek);
        }

        public override bool Wykonaj()
        {
            Pieniadze przyrost = new Pieniadze((int)modelOdsetek.DajOprocentowania() / 100 * rachunek.Pieniadze.Wartosc,
                rachunek.Pieniadze.Waluta);

            return rachunek.Pieniadze.Dodaj(przyrost);
        }

        public override Klient Klient()
        {
            return rachunek.Klient();
        }
    }
}
