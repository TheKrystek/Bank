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
    public class WyplataTests
    {

        RachunekBankowy rachunek;
        Klient klient;
        Bank bank;

        [TestInitialize]
        public void Initialize()
        {
            bank = new Bank();
            klient = bank.dodajKlienta(new Klient("Jon", "Doe"));
            rachunek = bank.dodajRachunekBankowy(klient);
            bank.Wykonaj(new Wplata(rachunek, new Pieniadze(10000)));
        }

        [TestMethod()]
        public void Wyplac_PieniadzeWZgodnejWalucie()
        {
            bank.Wykonaj(new Wyplata(rachunek, new Pieniadze(10000)));
            Assert.AreEqual(new Pieniadze(0),rachunek.Pieniadze);
        }

        [TestMethod()]
        public void Wyplac_TrochePieniedzy()
        {
            Assert.IsTrue(bank.Wykonaj(new Wyplata(rachunek, new Pieniadze(1000))));
        }


        [TestMethod()]
        public void Wyplac_PieniadzeWInnejWalucie()
        {
            Assert.IsFalse(bank.Wykonaj(new Wyplata(rachunek, new Pieniadze(10000,Pieniadze.Waluty.USD))));
        }

        [TestMethod()]
        public void Wplac_ZaDuzoPieniedzy()
        {
            Assert.IsFalse(bank.Wykonaj(new Wyplata(rachunek, new Pieniadze(20000))));
        }


    }
}
