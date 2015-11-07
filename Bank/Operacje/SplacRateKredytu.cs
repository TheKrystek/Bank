using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bank
{
    public class SplacRateKredytu : Operacja
    {
        private Kredyt kredyt;

        public SplacRateKredytu(Kredyt kredyt)
        {
            this.kredyt = kredyt;
        }

        public override string Opis()
        {
            return String.Format("splata raty nr {0} z {1}",kredyt.SplaconychRat,kredyt.IloscRat);
        }

        public override bool Wykonaj()
        {
            if (kredyt.DoSplaty.Wartosc == 0)
                return false;
            
            // Nalezaloby zrobic przelew na konto banku ale tego nie robimy bo mie sie nie chce
            kredyt.SplaconychRat++;
            Pieniadze czescSplaty = kredyt.ObliczCzescSplaty(kredyt.SplaconychRat); // Taka czesc splacilismy
            Pieniadze doSplacenia = kredyt.ObliczWysokoscRaty(kredyt.SplaconychRat); // Taka czesc musielismy wplacic: doSplacenia = czescSplaty+%
            kredyt.Splacono += czescSplaty;
            return true;
        }

        public override Klient Klient()
        {
            return kredyt.Klient();
        }
    }
}
