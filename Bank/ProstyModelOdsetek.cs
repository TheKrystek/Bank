using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bank
{
  public  class ProstyModelOdsetek : IModelOdsetek
    {
        double oprocentowanie;

        public ProstyModelOdsetek(double oprocentowanie) {
            this.oprocentowanie = oprocentowanie;
        }

        public double DajOprocentowania(int rata = 0)
        {
            return oprocentowanie;
        }

        public double DajKapitalizacje()
        {
            return 1;
        }


        public Pieniadze Oblicz(Pieniadze kwota, int rata)
        {
            return new Pieniadze((int)(DajOprocentowania() / 100 * kwota.Wartosc),
                kwota.Waluta);
        }
    }
}
