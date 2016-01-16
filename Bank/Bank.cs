using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bank
{

    public class Bank
    {
        private int code;
        private List<Klient> klienci = new List<Klient>();
        private Dictionary<int, ProduktBankowy> produktyBankowe = new Dictionary<int, ProduktBankowy>();
        private Historia historia;
        private Random random = new Random();
        private PaczkaPrzelewow paczka = new PaczkaPrzelewow();

        public Historia Historia
        {
            get { return historia; }
        }

        private int wygenerujNumer()
        {
            return Const.magicNumber * code + random.Next(Const.magicNumber);
        }

        public Bank(int code = 1)
        {
            this.code = code;
            historia = new Historia();
        }

        public Klient dodajKlienta(Klient klient)
        {
            klienci.Add(klient);
            return klient;
        }

        public RachunekBankowy DodajRachunekBankowy(Klient klient, int? idKonta = null)
        {
            if (!klienci.Contains(klient))
                klienci.Add(klient);

            if (idKonta == null)
                idKonta = wygenerujNumer();


            RachunekBankowy rachunek = new RachunekBankowy(klient, idKonta.Value);
            rachunek.ustawModelOdsetek(new LiniowyModelOdsetek(10));
            produktyBankowe.Add(idKonta.Value, rachunek);
            return rachunek;
        }


        public RachunekDebetowy DodajRachunekDebetowy(Klient klient, Pieniadze debet)
        {
            if (!klienci.Contains(klient))
                klienci.Add(klient);

            int id = wygenerujNumer();
            RachunekDebetowy rachunek = new RachunekDebetowy(klient, new Debet(debet), id);

            produktyBankowe.Add(id,rachunek);
            return rachunek;
        }


        public Kredyt DodajKredyt(Klient klient, Pieniadze kwota, double oprocentowanie = 10, int iloscRat = 2)
        {
            if (!klienci.Contains(klient))
                klienci.Add(klient);

            int id = wygenerujNumer();
            Kredyt kredyt = new Kredyt(kwota, new LiniowyModelOdsetek(oprocentowanie), iloscRat);

            produktyBankowe.Add(id, kredyt);
            return kredyt;
        }


        public Lokata DodajLokate(Klient klient, DateTime termin, double oprocentowanie = 3)
        {
            if (!klienci.Contains(klient))
                klienci.Add(klient);

            int id = wygenerujNumer();
            Lokata lokata = new Lokata(klient, new LiniowyModelOdsetek(oprocentowanie), termin);

            produktyBankowe.Add(id, lokata);
            return lokata;
        }

        public void WyswietlHistorie()
        {
            historia.Wyswietl();
            Console.WriteLine();
        }

        public void WyswietlKlientow()
        {
            Console.WriteLine("+++KLIENCI+++");
            foreach (var klient in klienci)
                Console.WriteLine(klient);
            Console.WriteLine();
        }

        public void WyswietlProdukty()
        {
            Console.WriteLine("+++PRODUKTY BANKOWE+++");
            foreach (var produkt in produktyBankowe)
                Console.WriteLine(produkt);
            Console.WriteLine();
        }


        public bool Wykonaj(IOperacja operacja)
        {
            bool wynik = operacja.Wykonaj();
            if (wynik)
                historia.Dodaj(operacja);
            return wynik;
        }

        private Izba komisja;

        public void DodajKomisje(Izba komisja)
        {
            this.komisja = komisja;
        }
      

        public void DodajDoPaczki(PrzelewanePieniadze p)
        {
            paczka.Dodaj(p);
        }


        public void PrzeslijPrzelewy()
        {
            komisja.PrzyjmijPrzelewy(this, paczka);
            paczka = new PaczkaPrzelewow();
        }


        public void OdbierzPrzelewy(PaczkaPrzelewow paczka)
        {
            foreach (var przelew in paczka.Przelewy)
            {
                if (!produktyBankowe.ContainsKey(przelew.id))
                    continue;

                RachunekBankowy rachunek = produktyBankowe[przelew.id] as RachunekBankowy;
                if (rachunek != null)
                    Wykonaj(new Wplata(rachunek, przelew.pieniadze));
            }
        }

        public int Kod
        {
            get
            {
                return code;
            }

            set
            {
                code = value;
            }
        }
    }
}
