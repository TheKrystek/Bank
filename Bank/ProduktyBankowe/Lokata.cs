using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bank
{
    public class Lokata : RachunekBankowy
    {
        private IModelOdsetek modelOdsetek;
        private bool rozwiazana = false;

        public bool Rozwiazana
        {
            get { return rozwiazana; }
            set { rozwiazana = value; }
        }

        public IModelOdsetek ModelOdsetek
        {
            get { return modelOdsetek; }
        }


        private DateTime dataZakonczenia;

        public DateTime DataZakonczenia
        {
            get { return dataZakonczenia; }
        }

        public Lokata(Klient klient, IModelOdsetek modelOdsetek, DateTime terminZakonczenia, Int64 id = 0)
            : base(klient, id)
        {
            this.modelOdsetek = modelOdsetek;
            this.dataZakonczenia = terminZakonczenia;
        }

        public override string ToString()
        {
            return String.Format("lokata klienta {0}", klient);
        }

    }
}
