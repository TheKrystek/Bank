using Bank.Raporty;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bank
{
   public  class Klient : IRaportowalny
    {

       private String PESEL, imie, nazwisko, ulica, numerDomu, miasto;
       private int numerMieszkania;
       private DateTime dataUrodzenia, dataRejestracj;
       private HistoriaKlienta historia; 


        public Klient(String imie, String nazwisko) {
            this.imie = imie;
            this.nazwisko = nazwisko;
            this.dataRejestracj = DateTime.Now;
            this.historia = new HistoriaKlienta(this);
        }


        public override string ToString()
        {
            return String.Format("{0} {1}",imie,nazwisko);
        }

        public void WyswietlHistorie() {
            historia.Wyswietl();
        }

        public HistoriaKlienta Historia()
        {
            return historia;
        }

        public void Raportuj(IRaport raport)
        {
            raport.ObsluzKlienta(this);
        }
    }

}
