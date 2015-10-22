using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bank
{
    public class Bank
    {

        List<Klient> klienci;
        List<ProduktBankowy> produktyBankowe;
        Historia historia;

        String nazwa;
        Random random = new Random();


        public Bank()
        {
            produktyBankowe = new List<ProduktBankowy>();
            historia = new Historia();
        }

        public Klient dodajKlienta(Klient klient)
        {
            if (klienci == null)
                klienci = new List<Klient>();

            klienci.Add(klient);
            return klient;
        }

        public RachunekBankowy dodajRachunekBankowy(Klient klient)
        {
            if (!klienci.Contains(klient))
                klienci.Add(klient);

            RachunekBankowy rachunek = new RachunekBankowy(klient, random.Next(10000));

            produktyBankowe.Add(rachunek);
            return rachunek;
        }


        public RachunekDebetowy dodajRachunekDebetowy(Klient klient, Pieniadze debet)
        {
            if (!klienci.Contains(klient))
                klienci.Add(klient);

            RachunekDebetowy rachunek = new RachunekDebetowy(klient, new Debet(debet), random.Next(10000));

            produktyBankowe.Add(rachunek);
            return rachunek;
        }

        public int LiczbaKlientow() {
            return klienci.Count();
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


        public bool Wykonaj(Operacja operacja)
        {
            bool wynik = operacja.Wykonaj();
            if (wynik)
                historia.Dodaj(operacja);
            return wynik;
        }


    }
}
