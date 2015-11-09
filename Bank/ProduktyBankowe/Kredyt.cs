using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bank
{
    public class Kredyt : ProduktBankowy
    {
        private Pieniadze kwotaKredytu;     
        private Pieniadze splacono;
        private int iloscRat;
        private int splaconychRat;
        private DateTime terminSplaty; 
        private IModelOdsetek modelOdsetek;
 
        public Kredyt(Pieniadze kwota, IModelOdsetek modelOdsetek, int rat = 1 ) :
            this(kwota,rat,DateTime.Now.AddMonths(1),modelOdsetek)
        {
        }

        public Kredyt(Pieniadze kwota, int rat, DateTime termin, IModelOdsetek modelOdsetek)
        {
            this.splacono = new Pieniadze(0,kwota.Waluta);
            this.kwotaKredytu = kwota;
            this.iloscRat = rat;
            this.splaconychRat = 0;
            this.terminSplaty = termin;
            this.modelOdsetek = modelOdsetek;
        }


        #region Properties
        public Pieniadze KwotaKredytu
        {
            get { return kwotaKredytu; }
        }
        public Pieniadze Splacono
        {
            get { return splacono; }
            set { splacono = value; }
        }

        public Pieniadze DoSplaty
        {
            get { return kwotaKredytu - splacono; }
        }
        public int IloscRat
        {
            get { return iloscRat; }
        }
        public int SplaconychRat
        {
            get { return splaconychRat; }
            set { splaconychRat++; }
        }
        public DateTime TerminSplaty
        {
            get { return terminSplaty; }
        }
        #endregion

        public Pieniadze ObliczWysokoscRaty(int rata)
        {
            Pieniadze kwotaRaty = ObliczCzescSplaty(rata);
            kwotaRaty += modelOdsetek.Oblicz(kwotaRaty);
            return kwotaRaty;
        }

        public Pieniadze ObliczCzescSplaty(int rata)
        {
            Pieniadze kwotaRaty = new Pieniadze(DoSplaty.Wartosc / (1 + iloscRat - rata), kwotaKredytu.Waluta);
            return kwotaRaty;
        }

        public override Pieniadze DostepneSrodki()
        {
            return DoSplaty;
        }

        public override string ToString()
        {
            return String.Format("kredyt klienta {0}", klient);
        }
    }
}
