using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bank
{
    class WpisWHistorii
    {
        private Klient klient;
        private Operacja operacja;

        public Klient Klient
        {
            get { return klient; }
        }

        public Operacja Operacja
        {
            get { return operacja; }
        }

        public WpisWHistorii(Klient klient, Operacja operacja) {
            this.klient = klient;
            this.operacja = operacja;
        }

        public override string ToString()
        {
            return String.Format("[{0}] {1}", operacja.DataWykonania, operacja.Opis());
        }


    }
}
