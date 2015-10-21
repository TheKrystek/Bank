using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bank
{
    public abstract class ProduktBankowy
    {
        private Int64 id;
        private Klient klient;
        private DateTime dataUtworzenia;


        protected Int64 Id
        {
            get { return id; }
            set { id = value; }
        }

       protected Klient Klient
        {
            get { return klient; }
            set { klient = value; }
        }
       protected DateTime DataUtworzenia
       {
           get { return dataUtworzenia; }
           set { dataUtworzenia = value; }
       }

    }
}
