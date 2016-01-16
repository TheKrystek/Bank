using Bank.Raporty;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bank.Raporty
{
    /// <summary>
    /// Przykładowy raport wyliczający srednia kwote operacji 
    /// dla danej waluty dla danej historii, albo dla listy operacji
    /// </summary>
    public class SredniaKwota : IRaport
    {
        int ilosc = 0;
        Pieniadze.Waluty waluta;
        Pieniadze suma;
        Pieniadze srednia;

  

        public SredniaKwota(Pieniadze.Waluty waluta) {
            this.waluta = waluta;
            this.suma = new Pieniadze(0, waluta);
            this.srednia = new Pieniadze(0, waluta); ;
        }

        private void Sumuj(Pieniadze pieniadze) {
            if (pieniadze.Waluta != waluta)
                return;
            ilosc++;
            suma += pieniadze;
        }

        public void ObsluzHistorie(WpisWHistorii historia)
        {
            Sumuj(historia.Pieniadze);
        }

        public void ObsluzOperacje(IOperacja operacja)
        {
            // To jest bledne, tylko przyklad jak mozna skorzystac
            // Przy operacjach zlozonych czesto bywa tak, ze ta sama kwota pojawia sie raz jako strona WN a raz MA
            foreach (var historia in operacja.Historia())
                ObsluzHistorie(historia);
        }

        public void ObsluzKlienta(Klient klient)
        {
            // To jest bledne, tylko przyklad jak mozna skorzystac
            // Klient raczej powinien miec liste produktow bankowych i z tego obliczana powinna być suma srodkow
            foreach (var historia in klient.Historia().Wpisy())
                ObsluzHistorie(historia);
        }

        public void ObsluzProduktBankowy(ProduktBankowy produkt)
        {
            Sumuj(produkt.DostepneSrodki());
        }


        public string Wynik()
        {
            srednia = new Pieniadze(suma.Wartosc / ilosc,suma.Waluta);
            return string.Format("Srednia kwota operacji: {0}", srednia);
        }


        public Pieniadze Srednia
        {
            get { return srednia; }
        }

        public Pieniadze Suma
        {
            get { return suma; }
        }

        public int IloscWystapien
        {
            get { return ilosc; }
        }
        public Pieniadze.Waluty Waluta
        {
            get { return waluta; }
        }
    }
}
