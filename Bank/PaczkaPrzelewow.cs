using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bank
{
    public class PaczkaPrzelewow
    {
        Bank bank;
        List<PrzelewanePieniadze> przelewy;

        public PaczkaPrzelewow()
        {
            przelewy = new List<PrzelewanePieniadze>();
        }


        public void ustawBank(Bank bank){
            this.bank = bank;
        }

        public void Dodaj(PrzelewanePieniadze przelew)
        {
            przelewy.Add(przelew);
        }

        public List<PrzelewanePieniadze> Przelewy {
            get { return przelewy; }
        }

    }


    public struct PrzelewanePieniadze{
        public int id;
        public Pieniadze pieniadze;
    }

}
