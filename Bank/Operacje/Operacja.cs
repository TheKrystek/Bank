using Bank.Raporty;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bank
{
    public abstract class OperacjaProsta : IOperacja
    {
        protected DateTime dataWykonania;
        protected List<WpisWHistorii> historia;

        public OperacjaProsta(DateTime dataWykonania)
        {
            this.dataWykonania = dataWykonania;
        }

        public OperacjaProsta()
            : this(DateTime.Now)
        {
            if (historia == null)
                historia = new List<WpisWHistorii>();
        }

        public abstract String Opis();
        public abstract bool Wykonaj();
        public virtual List<WpisWHistorii> Historia()
        {
            return historia;
        }

        DateTime IOperacja.DataWykonania
        {

            get { return dataWykonania; }
            set
            {
                throw new InvalidOperationException();
            }
        }


        public void Raportuj(IRaport raport)
        {
            raport.ObsluzOperacje(this);
        }
    }
}
