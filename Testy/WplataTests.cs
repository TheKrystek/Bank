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
    public class WplataTests
    {

        RachunekBankowy rachunek;
        Klient klient;
        Bank bank;

        [TestInitialize]
        public void Initialize()
        {
            bank = new Bank();
            klient = bank.dodajKlienta(new Klient("Jon", "Doe"));
            rachunek = bank.DodajRachunekBankowy(klient);
        }

        [TestMethod()]
        public void Wplac_PieniadzeWZgodnejWalucie()
        {
            bank.Wykonaj(new Wplata(rachunek,new Pieniadze(10000)));
            Assert.AreEqual(new Pieniadze(10000),rachunek.Pieniadze);
        }

        [TestMethod()]
        public void Wplac_PieniadzeWInnejWalucie()
        {
            Assert.IsFalse(bank.Wykonaj(new Wplata(rachunek, new Pieniadze(10000,Pieniadze.Waluty.USD))));
        }


    }
}
