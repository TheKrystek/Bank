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
    public class DebetTests
    {
        Debet debet;
        [TestInitialize]
        public void Initialize()
        {
            debet = new Debet(new Pieniadze(1000));
        }


        [TestMethod()]
        public void Pobierz_MniejNizLimit_CzySiePowiodlo()
        {  
            Assert.IsTrue(debet.Pobierz(new Pieniadze(500)));
        }

        [TestMethod()]
        public void Pobierz_MniejNizLimit_CzyPoprawniePobralo()
        {
            debet.Pobierz(new Pieniadze(500));
            Assert.AreEqual(new Pieniadze(500), debet.Stan);
        }

        [TestMethod()]
        public void Pobierz_MniejNizLimit_CzyLimitSieNieZmienil()
        {
            debet.Pobierz(new Pieniadze(500));
            Assert.AreEqual(new Pieniadze(1000), debet.Limit);
        }

        [TestMethod()]
        public void Pobierz_WiecejNizLimit_CzySieNiePowiodlo()
        {
            Assert.IsFalse(debet.Pobierz(new Pieniadze(1500)));
        }

        [TestMethod()]
        public void Pobierz_WInnejWalucie_CzySieNiePowiodlo()
        {
            Assert.IsFalse(debet.Pobierz(new Pieniadze(500,Pieniadze.Waluty.USD)));
        }

        [TestMethod()]
        public void Dodaj_MniejNizLimit_CzyDobryStan()
        {
            debet.Pobierz(new Pieniadze(1000)); // Stan 0/1000
            debet.Dodaj(new Pieniadze(500));
            Assert.AreEqual(new Pieniadze(500), debet.Stan);
        }

        [TestMethod()]
        public void Dodaj_MniejNizLimit_CzyDobraReszta()
        {
            debet.Pobierz(new Pieniadze(1000)); // Stan 0/1000
            Assert.AreEqual(new Pieniadze(), debet.Dodaj(new Pieniadze(500)));
        }

        [TestMethod()]
        public void Dodaj_RownoDoLimitu_CzyDobryStan()
        {
            debet.Pobierz(new Pieniadze(700)); // Stan 300/1000
            debet.Dodaj(new Pieniadze(700));   // Stan 1000/1000
            Assert.AreEqual(new Pieniadze(1000), debet.Stan);
        }

        [TestMethod()]
        public void Dodaj_RownoDoLimitu_CzyDobraReszta()
        {
            debet.Pobierz(new Pieniadze(700)); // Stan 0/1000
            Assert.AreEqual(new Pieniadze(0), debet.Dodaj(new Pieniadze(700)));
        }

        [TestMethod()]
        public void Dodaj_PonadLimit_CzyDobryStan()
        {
            debet.Pobierz(new Pieniadze(700)); // Stan 300/1000
            debet.Dodaj(new Pieniadze(1000));   // Stan 1000/1000, reszta 300
            Assert.AreEqual(new Pieniadze(1000), debet.Stan);
        }

        [TestMethod()]
        public void Dodaj_PonadLimit_CzyDobraReszta()
        {
            debet.Pobierz(new Pieniadze(700)); // Stan 0/1000
            Assert.AreEqual(new Pieniadze(300), debet.Dodaj(new Pieniadze(1000))); // Stan 1000/1000, reszta 300
        }

    }
}
