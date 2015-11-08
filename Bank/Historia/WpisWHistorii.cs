using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bank
{
    public class WpisWHistorii
    {
        private Klient klient;
        private Operacja operacja;
        private string opis;
        private ProduktBankowy produkt;

        public Klient Klient
        {
            get { return klient; }
        }

        public ProduktBankowy Produkt
        {
            get { return produkt; }
        }

        public Operacja Operacja
        {
            get { return operacja; }
        }

        public WpisWHistorii(Operacja operacja) {
            this.klient = operacja.Klient();
            this.operacja = operacja;
            this.opis = operacja.Opis();
            this.produkt = operacja.Produkt();
        }


        public override string ToString()
        {
            return String.Format("[{0}] {1}", operacja.DataWykonania, opis);
        }


    }
}
