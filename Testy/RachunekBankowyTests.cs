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
    public class RachunekBankowyTests
    {

        RachunekBankowy r1;

        [TestInitialize]
        public void Initialize()
        {
            r1 = new RachunekBankowy(new Klient("Jon", "Doe"));
        }

        [TestMethod()]
        public void WplacPieniadze_WplacKwoteWDomyslnejWalucie()
        {
            r1.WplacPieniadze(new Pieniadze(1000));
            Assert.AreEqual(new Pieniadze(1000), r1.Pieniadze);
        }

        [TestMethod()]
        public void WplacPieniadze_WplacKwoteWInnejWalucie()
        {
            Assert.IsFalse(r1.WplacPieniadze(new Pieniadze(1000, Pieniadze.Waluty.USD)), "jednak udało sie wplacic");
        }

        [TestMethod()]
        public void WyplacPieniadze_WyplacKwoteMniejszaOdStanuRachunku()
        {
            r1.WplacPieniadze(new Pieniadze(2000));
            r1.WyplacPieniadze(new Pieniadze(1000));
            Assert.AreEqual(new Pieniadze(1000), r1.Pieniadze);
        }

        [TestMethod()]
        public void WyplacPieniadze_WyplacKwoteRownaStanowiRachunku()
        {
            r1.WplacPieniadze(new Pieniadze(2000));
            r1.WyplacPieniadze(new Pieniadze(2000));
            Assert.AreEqual(new Pieniadze(0), r1.Pieniadze);
        }

        [TestMethod()]
        public void WyplacPieniadze_WyplacKwoteWiekszaOdStanuRachunku()
        {
            r1.WplacPieniadze(new Pieniadze(2000));
            Assert.IsFalse(r1.WyplacPieniadze(new Pieniadze(3000)));
        }

        [TestMethod()]
        public void WyplacPieniadze_WyplacWInnejWalucie()
        {
            r1.WplacPieniadze(new Pieniadze(2000));
            Assert.IsFalse(r1.WyplacPieniadze(new Pieniadze(3000, Pieniadze.Waluty.USD)));
        }


    }
}
