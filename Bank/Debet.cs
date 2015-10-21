using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bank
{
    public class Debet
    {
        Pieniadze limit;
        Pieniadze stan;

        public Debet(Pieniadze limit) {
            this.limit = limit;
            this.stan = limit;
        }

        public Pieniadze Limit
        {
            get { return limit; }
        }
     
        public Pieniadze Stan
        {
            get { return stan; }
            set { stan = value; }
        }


        public bool Pobierz(Pieniadze pieniadze) {
            try
            {
                this.stan -= pieniadze;
            }
            catch (Exception)
            {
                return false;
            }
            return true;  
        }

        /// <summary>
        /// Zwraca resztę, np. jeżeli limit wynosi 1000 a wpłacamy 1500 to 500 za dużo
        /// </summary>
        /// <param name="pieniadze"></param>
        /// <returns></returns>
        public Pieniadze Dodaj(Pieniadze pieniadze)
        {
            if (Pieniadze.RozneWaluty(stan,pieniadze))
                return pieniadze;

            if ((limit-stan) >= pieniadze)
            {
                stan += pieniadze;
                return new Pieniadze(0,pieniadze.Waluta);
            }
            Pieniadze reszta = pieniadze - (limit - stan);
            stan = limit;
            return reszta;
        }

    }
}
