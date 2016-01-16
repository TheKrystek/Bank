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
            Assert.IsTrue(bank.Wykonaj(new NaliczOdsetki(rachunek,new LiniowyModelOdsetek(10))));
        }


        [TestMethod()]
        public void NaliczOdsetki_NaliczProcent()
        {
            bank.Wykonaj(new NaliczOdsetki(rachunek));
            Assert.AreEqual(new Pieniadze(11000), rachunek.Pieniadze);
        }


        [TestMethod()]
        public void NaliczOdsetki_DwaRazy()
        {
            bank.Wykonaj(new NaliczOdsetki(rachunek)); // 10000 *= 1.10 = 11000
            bank.Wykonaj(new NaliczOdsetki(rachunek)); // 11000 *= 1.10 = 12100
            Assert.AreEqual(new Pieniadze(12100), rachunek.Pieniadze);
        }

        [TestMethod()]
        public void NaliczOdsetki_10Razy()
        {
            for (int i = 0; i < 10; i++)
                bank.Wykonaj(new NaliczOdsetki(rachunek)); 
           
            Assert.AreEqual(new Pieniadze(25934), rachunek.Pieniadze);
        }



    }
}
