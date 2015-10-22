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
            RachunekBankowy rachunekKrystiana = bank.dodajRachunekBankowy(krystian);
            RachunekDebetowy rachunekPawla = bank.dodajRachunekDebetowy(pawel,new Pieniadze(1000));

            // Wykonaj wplaty 1000 PLN na konto Krystiana i 500 PLN na konto Pawła
            bank.Wykonaj(new Wplata(rachunekKrystiana, new Pieniadze(1011)));
            bank.Wykonaj(new Wplata(rachunekPawla, new Pieniadze(500)));
            bank.Wykonaj(new Wyplata(rachunekPawla, new Pieniadze(2500)));
            bank.Wykonaj(new Wyplata(rachunekPawla, new Pieniadze(500)));

            //Wyswietl historie operacji
            bank.WyswietlHistorie();

            //bank.Wykonaj(new Przelew(rachunekPawla,rachunekKrystiana,new pieniadze(1500)));
            //bank.Wykonaj(new NaliczOdsetki(rachunekKrystiana,new ProstyModelOdsetek(10)));

            krystian.WyswietlHistorie();


            //// Wyswietl historie operacji
            //bank.WyswietlHistorie();

            Console.ReadLine();
        }

    }
}
