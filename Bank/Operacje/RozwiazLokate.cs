using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bank
{
    public class RozwiazLokate : OpracjaZlozona
    {
        private Pieniadze pieniadze;
        private RachunekBankowy rachunek;
        private Lokata lokata;
        private DateTime dataRozwiazania;
        private bool rozwiazana = false;


        // okresl date rozwiazania bo chcemy rozwiazac albo przed terminem lokaty albo po
        public RozwiazLokate(Lokata lokata, RachunekBankowy rachunek, DateTime dataRozwiazania)
        {
            this.lokata = lokata;
            this.rachunek = rachunek;
            this.dataRozwiazania = dataRozwiazania;


            operacjaPierwsza = new NaliczOdsetkiNaRachunku(lokata, lokata.ModelOdsetek);
            operacjaDruga = new Przelew(lokata,rachunek,lokata.Pieniadze);
        }

        public override string Opis()
        {
            return String.Format("rozwiazanie lokaty {0} i wplata na {1}",lokata,rachunek);
        }

        public override bool Wykonaj()
        {
            // Nie mozna rozwiazac juz roziazanej lokaty
            if (rozwiazana)
                return false;

            // Jezeli chcemy rozwiazac lokate przed czasem to nie naliczamy odsetek
            if (dataRozwiazania < lokata.DataZakonczenia)
            {
                // Wykonaj przelew z lokaty na rachunek i zwroc wynik
                return (rozwiazana = operacjaDruga.Wykonaj());
            }

            // Jezeli data rozwiazania jest pozniejsza to najpierw nalicz odsetki
            if (operacjaPierwsza.Wykonaj())
                // Wykonaj przelew z lokaty na rachunek i zwroc wynik
                return (rozwiazana = operacjaDruga.Wykonaj());

            return false;
        }


        public override Klient Klient()
        {
            return lokata.Klient();
        }

        public override ProduktBankowy Produkt()
        {
            return lokata;
        }
    }
}
