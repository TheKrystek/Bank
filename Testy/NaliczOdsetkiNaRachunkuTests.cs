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
    public class NaliczOdsetkiNaRachunkuTests
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
            bank.Wykonaj(new Wplata(rachunek, new Pieniadze(10000)));
        }

        [TestMethod()]
        public void NaliczOdsetki_PowiodloSie()
        {
            Assert.IsTrue(bank.Wykonaj(new NaliczOdsetkiNaRachunku(rachunek,new ProstyModelOdsetek(10))));
        }


        [TestMethod()]
        public void NaliczOdsetki_NaliczProcent()
        {
            bank.Wykonaj(new NaliczOdsetkiNaRachunku(rachunek, new ProstyModelOdsetek(10)));
            Assert.AreEqual(new Pieniadze(11000), rachunek.Pieniadze);
        }



    }
}
