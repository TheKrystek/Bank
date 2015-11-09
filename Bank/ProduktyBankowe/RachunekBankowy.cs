using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bank
{
    public class RachunekBankowy : ProduktBankowy
    {
        protected Pieniadze pieniadze;
        public Pieniadze Pieniadze
        {
            get { return pieniadze; }
        }

        public RachunekBankowy(Klient klient, Int64 id = 0)
        {
            this.DataUtworzenia = DateTime.Now;
            this.klient = klient;
            if (this.pieniadze == null)
                this.pieniadze = new Pieniadze(0);
            this.Id = id;
        }

        public virtual bool WyplacPieniadze(Pieniadze pieniadze)
        {
            try
            {
                this.pieniadze -= pieniadze;
                return true;  
            }
            catch (Exception)
            {
                return false;
            }         
        }

        public virtual bool WplacPieniadze(Pieniadze pieniadze)
        {
            try
            {
                this.pieniadze += pieniadze;
                return true;
            }
            catch (Exception)
            {
                return false;
            }         
        }

        protected virtual bool CzyDostepnePieniadze(Pieniadze pieniadze)
        {
            try
            {
                return (Pieniadze >= pieniadze);
            }
            catch (Exception)
            {
                return false;  
            }      
        }

        public override string ToString()
        {
            return String.Format("rachunek klienta {0}", klient);
        }


        public override Pieniadze DostepneSrodki()
        {
            return Pieniadze;
        }
    }
}
