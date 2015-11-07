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
    public class KredytTests
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

        [TestMethod()]
        public void ObliczWysokoscRatyTest()
        {
            // 10tys na dwie raty i 10% stale oproc = 5500
            Kredyt k = new Kredyt(new Pieniadze(1000000), new ProstyModelOdsetek(10), 2);      
            Pieniadze rata = k.ObliczWysokoscRaty(1);
            Assert.AreEqual(new Pieniadze(550000),rata);
        }
    }
}
