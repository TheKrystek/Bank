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
        private string opis; 

        public Klient Klient
        {
            get { return klient; }
        }

        public Operacja Operacja
        {
            get { return operacja; }
        }

        public WpisWHistorii(Operacja operacja) {
            this.klient = operacja.Klient();
            this.operacja = operacja;
            this.opis = operacja.Opis();
        }


        public override string ToString()
        {
            return String.Format("[{0}] {1}", operacja.DataWykonania, opis);
        }


    }
}
