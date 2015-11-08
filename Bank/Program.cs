using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bank
{
    class Program
    {
        static void Main(string[] args)
        {
            // Stwórz bank oraz dodaj dwóch klientów
            Bank bank = new Bank();
            Klient krystian = bank.dodajKlienta(new Klient("Krystian", "Swidurski"));
            Klient pawel = bank.dodajKlienta(new Klient("Pawel", "Sudomir"));

            bank.WyswietlKlientow();

            // Stworz rachunki bankowe
            RachunekBankowy rachunekKrystiana = bank.DodajRachunekBankowy(krystian);
            RachunekDebetowy rachunekPawla = bank.DodajRachunekDebetowy(pawel, new Pieniadze(1000));


            // Wykonaj wplaty 1000 PLN na konto Krystiana i 500 PLN na konto Pawła
            bank.Wykonaj(new Wplata(rachunekKrystiana, new Pieniadze(100000)));
          //  bank.Wykonaj(new Wyplata(rachunekKrystiana, new Pieniadze(100000)));

            Lokata lokataKrystiana = bank.DodajLokate(krystian, DateTime.Now, 3);

            bank.Wykonaj(new Wplata(lokataKrystiana, new Pieniadze(10000000)));
            bank.Wykonaj(new RozwiazLokate(lokataKrystiana,rachunekKrystiana,DateTime.Now.AddDays(-1)));

            bank.WyswietlHistorie();

            Console.WriteLine(rachunekKrystiana.Pieniadze);



            Console.ReadLine();
        }

    }
}
