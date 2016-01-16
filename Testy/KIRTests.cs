using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bank;
using Microsoft.VisualStudio.TestTools.UnitTesting;
namespace Bank.Tests
{
    [TestClass()]
    public class KIRTests
    {
        Bank bankA, bankB;
        Klient klient1, klient2;
        KIR kir;

        RachunekBankowy rachunekA, rachunekB;

        [TestInitialize]
        public void Initialize()
        {
            kir = new KIR();

            klient1 = new Klient("Jon", "Doe");
            klient2 = new Klient("Jan", "Nowak");

            bankA = new Bank(1); // Bank posiada rachunki zaczynajace się od 1 np. 10000 - 19999
            bankB = new Bank(5); // Bank posiada rachunki zaczynajace się od 1 np. 50000 - 59999

            rachunekA = bankA.DodajRachunekBankowy(klient1, 10001);
            rachunekB = bankB.DodajRachunekBankowy(klient2, 55555);

            bankA.Wykonaj(new Wplata(rachunekA, new Pieniadze(10000)));
            bankB.Wykonaj(new Wplata(rachunekB, new Pieniadze(20000)));
        }


        [TestMethod()]
        public void ZarejestrujBanki()
        {
            kir.RejestrujBank(bankA);
            kir.RejestrujBank(bankB);

            Assert.AreEqual(2, kir.Banki.Count);
        }

        [TestMethod()]
        public void WykonajPrzelewZBankuADoB()
        {
            kir.RejestrujBank(bankA);
            kir.RejestrujBank(bankB);

            bankA.Wykonaj(new PrzelewZewnetrzny(rachunekA, 55555, new Pieniadze(10000), bankA));
            bankA.PrzeslijPrzelewy();

            kir.Wykonaj();

            Assert.AreEqual(30000, rachunekB.DostepneSrodki().Wartosc);
            Assert.AreEqual(0, rachunekA.DostepneSrodki().Wartosc);
        }

    }
}
