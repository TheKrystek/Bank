using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bank
{
  public  class ProstyModelOdsetek : ModelOdsetek
    {
        double oprocentowanie;

        public ProstyModelOdsetek(double oprocentowanie) {
            this.oprocentowanie = oprocentowanie;
        }


        public double DajOprocentowania()
        {
            return oprocentowanie;
        }

        public double DajKapitalizacje()
        {
            return 1;
        }
    }
}
