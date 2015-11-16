using Bank.Raporty;
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

            // Wykonaj wplaty 1000 PLN na konto Krystiana i 1500 PLN na konto Pawła
            bank.Wykonaj(new Wplata(rachunekKrystiana, new Pieniadze(100000)));
            bank.Wykonaj(new Wyplata(rachunekKrystiana, new Pieniadze(150000))); // Nie powiedzie się i nie zapisze w historii
            bank.Wykonaj(new Wplata(rachunekPawla, new Pieniadze(150000)));


            // Utworz lokate dla Krystiana i wplac na nia 20 tys
            Lokata lokataKrystiana = bank.DodajLokate(krystian, DateTime.Now, 3);
            bank.Wykonaj(new Wplata(lokataKrystiana, new Pieniadze(2000000)));
            // Rozwiaz lokate przed jej uplywe - nie naliczy odsetek
            bank.Wykonaj(new RozwiazLokate(lokataKrystiana, rachunekKrystiana, DateTime.Now.AddDays(-1)));


            // Wykonaj raport na historii banku
            SredniaKwota sredniaOperacji = new SredniaKwota(Pieniadze.Waluty.PLN);
            GeneratorRaportow.Generuj(sredniaOperacji,bank.Historia);

            /* 
             Suma:  1000 zł [wpłata na konto Krystiana]
                    1500 zł [wpłata na konto Pawła] 
                   20000 zł [wpłata na lokate]
                   20000 zł [wypłata z lokaty]
                   20000 zł [wpłata na rachunek Krystiana]
                 = 62500 zł 
             Ilość: 5
             Wynik: 15250 zł
             */
            Console.WriteLine("Raport dla banku. " + sredniaOperacji.Wynik());

       
            // Wykonaj ten sam raport ale na historii Krystiana
            SredniaKwota sredniaKrystiana = new SredniaKwota(Pieniadze.Waluty.PLN);
            GeneratorRaportow.Generuj(sredniaKrystiana, krystian);
            Console.WriteLine("Raport dla Krystiana. " + sredniaKrystiana.Wynik());

            // Wykonaj nowy raport dla Krystiana
            Console.WriteLine();
            RaportZPodsumowaniem raport = new RaportZPodsumowaniem(Pieniadze.Waluty.PLN);
            GeneratorRaportow.Generuj(raport, krystian);
            Console.WriteLine(raport.Wynik());




            Console.ReadLine();
        }

    }
}
