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
    public class SplacRateKredytuTests
    {
        [TestMethod()]
        public void SplacRateTest()
        {
            Kredyt k = new Kredyt(new Pieniadze(1000000), new ProstyModelOdsetek(10), 2);
            SplacRateKredytu a = new SplacRateKredytu(k);
            a.Wykonaj();
            Assert.AreEqual(new Pieniadze(500000), k.Splacono);
        }

        [TestMethod()]
        public void SplacDwieRatyTest()
        {
            Kredyt k = new Kredyt(new Pieniadze(1000000), new ProstyModelOdsetek(10), 2);
            SplacRateKredytu a = new SplacRateKredytu(k);
            a.Wykonaj();
            a.Wykonaj();
            Assert.AreEqual(new Pieniadze(0), k.DoSplaty);
        }

    }
}
