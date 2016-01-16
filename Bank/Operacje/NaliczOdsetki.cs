using Bank.Odsetki;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bank
{
    public class NaliczOdsetki : OperacjaProsta
    {

        private IModelOdsetek modelOdsetek;
        private RachunekBankowy rachunek;
        private int rata;

        public NaliczOdsetki(RachunekBankowy rachunek, IModelOdsetek modelOdsetek)
        {
            this.modelOdsetek = modelOdsetek;
            this.rachunek = rachunek;
        }

        public NaliczOdsetki(RachunekBankowy rachunek)
        {
            this.rachunek = rachunek;
            if (rachunek is IOdsetki)
                this.modelOdsetek = ((IOdsetki)rachunek).dajModelOdsetek();
        }

        public override string Opis()
        {
            return String.Format("naliczenie odsetek");
        }

        public override bool Wykonaj()
        {
            if (!(rachunek is IOdsetki))
                return false;

            Pieniadze odsetki = modelOdsetek.Oblicz(rachunek);
            historia.Add(new WpisWHistorii(this, rachunek, odsetki));
            
            return rachunek.WplacPieniadze(odsetki);
        }

        public override List<WpisWHistorii> Historia()
        {
            return historia;
        }
    }
}
