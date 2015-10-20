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
    public class PrzelewTests
    {

        RachunekBankowy rachunekA, rachunekB;
        Klient klientA, klientB;
        Bank bank;

        [TestInitialize]
        public void Initialize()
        {
            bank = new Bank();
            klientA = bank.dodajKlienta(new Klient("Jon", "Doe"));
            klientB = bank.dodajKlienta(new Klient("Tyler", "Durden"));
            rachunekA = bank.dodajRachunekBankowy(klientA);
            rachunekB = bank.dodajRachunekBankowy(klientA);
            bank.Wykonaj(new Wplata(rachunekA, new Pieniadze(10000)));
        }

        [TestMethod()]
        public void Przelew_PrzelejMniejNizMaNaKoncie()
        {
            bank.Wykonaj(new Przelew(rachunekA,rachunekB, new Pieniadze(5000)));
            Assert.AreEqual(new Pieniadze(5000),rachunekB.Pieniadze);
        }

        [TestMethod()]
        public void Przelew_PrzelejWiecejNizMaNaKoncie()
        {
            Assert.IsFalse(bank.Wykonaj(new Przelew(rachunekA,rachunekB, new Pieniadze(50000))));
        }

        [TestMethod()]
        public void Przelew_PrzelejDokladnieIleNaKoncie()
        {
            Assert.IsTrue(bank.Wykonaj(new Przelew(rachunekA,rachunekB, new Pieniadze(10000))));
        }


        [TestMethod()]
        public void Przelew_PrzelejWInnejWalucie()
        {
            Assert.IsFalse(bank.Wykonaj(new Przelew(rachunekA, rachunekB, new Pieniadze(10000,Pieniadze.Waluty.USD))));
        }


    }
}
