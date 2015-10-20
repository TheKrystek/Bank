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

        protected Int64 Id
        {
            get { return id; }
            set { id = value; }
        }

       protected Klient klient;
       protected DateTime dataUtworzenia;

    }
}
