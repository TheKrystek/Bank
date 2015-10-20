using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bank
{
   public  class Klient
    {

        String PESEL, imie, nazwisko, ulica, numerDomu, miasto;
        int numerMieszkania;
        DateTime dataUrodzenia, dataRejestracj;

        public Klient(String imie, String nazwisko) {
            this.imie = imie;
            this.nazwisko = nazwisko;
            this.dataRejestracj = DateTime.Now;
        }

        override
        public string ToString() {
            return String.Format("{0} {1}",imie,nazwisko);
        }

    }

}
