﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bank
{

    public class Bank
    {
        private List<Klient> klienci = new List<Klient>();
        private List<ProduktBankowy> produktyBankowe = new List<ProduktBankowy>();
        private Historia historia;
        private Random random = new Random();


        public Bank()
        {
            historia = new Historia();
        }

        public Klient dodajKlienta(Klient klient)
        {
            klienci.Add(klient);
            return klient;
        }

        public RachunekBankowy DodajRachunekBankowy(Klient klient)
        {
            if (!klienci.Contains(klient))
                klienci.Add(klient);

            RachunekBankowy rachunek = new RachunekBankowy(klient, random.Next(10000));

            produktyBankowe.Add(rachunek);
            return rachunek;
        }


        public RachunekDebetowy DodajRachunekDebetowy(Klient klient, Pieniadze debet)
        {
            if (!klienci.Contains(klient))
                klienci.Add(klient);

            RachunekDebetowy rachunek = new RachunekDebetowy(klient, new Debet(debet), random.Next(10000));

            produktyBankowe.Add(rachunek);
            return rachunek;
        }


        public Kredyt DodajKredyt(Klient klient, Pieniadze kwota, double oprocentowanie = 10, int iloscRat = 2)
        {
            if (!klienci.Contains(klient))
                klienci.Add(klient);

            Kredyt kredyt = new Kredyt(kwota, new ProstyModelOdsetek(oprocentowanie), iloscRat);

            produktyBankowe.Add(kredyt);
            return kredyt;
        }


        public Lokata DodajLokate(Klient klient, DateTime termin, double oprocentowanie = 3)
        {
            if (!klienci.Contains(klient))
                klienci.Add(klient);

            Lokata lokata = new Lokata(klient, new ProstyModelOdsetek(oprocentowanie), termin);

            produktyBankowe.Add(lokata);
            return lokata;
        }



        public int LiczbaKlientow()
        {
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
