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
    public class RozwiazLokateTests
    {

        RachunekBankowy rachunek;
        Lokata lokata;
        Klient klient;
        Bank bank;

        [TestInitialize]
        public void Initialize()
        {
            bank = new Bank();
            klient= bank.dodajKlienta(new Klient("Jon", "Doe"));
            rachunek= bank.DodajRachunekBankowy(klient);
            lokata = bank.DodajLokate(klient, DateTime.Now, 10);
            bank.Wykonaj(new Wplata(rachunek, new Pieniadze(10000)));
            bank.Wykonaj(new Wplata(lokata, new Pieniadze(10000)));
        }

        [TestMethod()]
        public void RozwiazLokate_PrzedTerminemPustaLokata()
        {
            bank.Wykonaj(new RozwiazLokate(lokata,rachunek,DateTime.Now.AddDays(-1)));
            Assert.AreEqual(new Pieniadze(),lokata.Pieniadze);
        }

        [TestMethod()]
        public void RozwiazLokate_PrzedTerminemWplataNaRachunek()
        {
            bank.Wykonaj(new RozwiazLokate(lokata, rachunek, DateTime.Now.AddDays(-1)));
            Assert.AreEqual(new Pieniadze(20000), rachunek.Pieniadze);
        }

        [TestMethod()]
        public void RozwiazLokate_PrzedTerminem_DwaRazy()
        {
            bank.Wykonaj(new RozwiazLokate(lokata, rachunek, DateTime.Now.AddDays(-1)));
           
            Assert.IsFalse(bank.Wykonaj(new RozwiazLokate(lokata, rachunek, DateTime.Now.AddDays(-1))));
        }


    }
}
