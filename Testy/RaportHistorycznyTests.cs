using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bank;
using Bank.Raporty;

using Microsoft.VisualStudio.TestTools.UnitTesting;
namespace Bank.Tests
{
    [TestClass()]
    public class RaportHistorycznyTests
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
        public void RaportHistoryczny_ObliczLiczbeWpisowWHistoriiBanku()
        {
            // Dodaj 4 wpisy
            bank.Wykonaj(new Wplata(rachunek, new Pieniadze(10000)));
            bank.Wykonaj(new Wplata(rachunek, new Pieniadze(20000)));
            bank.Wykonaj(new Wplata(rachunek, new Pieniadze(30000)));
            bank.Wykonaj(new Wplata(rachunek, new Pieniadze(40000)));

            // Generuj raport
            HistorycznyLiczbaWpisow raport = new HistorycznyLiczbaWpisow(bank.Historia);
            raport.Generuj();

            Assert.AreEqual(4,raport.LiczbaWpisow);
        }

    }
}
