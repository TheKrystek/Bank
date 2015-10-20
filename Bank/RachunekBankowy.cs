using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bank
{
    public class RachunekBankowy : ProduktBankowy
    {
        protected Klient klient;
        protected Pieniadze pieniadze;
        public Pieniadze Pieniadze
        {
            get { return pieniadze; }
        }

        public RachunekBankowy(Klient klient, Int64 id = 0)
        {
            this.klient = klient;
            this.pieniadze = new Pieniadze(0);
            this.Id = id;
        }

        public virtual bool WyplacPieniadze(Pieniadze pieniadze)
        {
            try
            {
                this.pieniadze -= pieniadze;
            }
            catch (Exception)
            {
                return false;
            }
            return true;  
        }

        public virtual bool WplacPieniadze(Pieniadze pieniadze)
        {
            try
            {
                this.pieniadze += pieniadze;
            }
            catch (Exception)
            {
                return false;
            }
            return true;
        }

        protected virtual bool CzyDostepnePieniadze(Pieniadze pieniadze)
        {
            try
            {
                return (Pieniadze >= pieniadze);
            }
            catch (Exception)
            { }
            return false;  
        }

        public override string ToString()
        {
            return String.Format("rachunek {0} klienta {1}. Saldo: {2}", Id, klient, pieniadze);
        }

    }
}
