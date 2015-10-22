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
    public class PieniadzeTests
    {
        #region Porownywanie wartosci
        #region Operator ==
        [TestMethod()]
        public void Equals_PorownaniePieniedzyOZgodnejWalucieIRownychWartosciach()
        {
            Pieniadze p1 = new Pieniadze(10000);
            Pieniadze p2 = new Pieniadze(10000);
            Assert.AreEqual(p1, p2);
        }


        [TestMethod()]
        public void Equals_PorownaniePieniedzyONiezgodnejWalucieIRownychWartosciach()
        {
            Pieniadze p1 = new Pieniadze(10000);
            Pieniadze p2 = new Pieniadze(10000,Pieniadze.Waluty.USD);
            Assert.AreNotEqual(p1, p2);
        }

        [TestMethod()]
        public void Equals_PorownaniePieniedzyOZgodnejWalucieIRoznychWartosciach()
        {
            Pieniadze p1 = new Pieniadze(10000);
            Pieniadze p2 = new Pieniadze(20000);
            Assert.AreNotEqual(p1, p2);
        }


        [TestMethod()]
        public void Equals_PorownaniePieniedzyONiezgodnejWalucieIRoznychWartosciach()
        {
            Pieniadze p1 = new Pieniadze(10000);
            Pieniadze p2 = new Pieniadze(20000, Pieniadze.Waluty.USD);
            Assert.AreNotEqual(p1, p2);
        }

        #endregion

        #region Operatory: <, <=, >, >=
        [TestMethod()]
        public void LowerThan_PorownaniePieniedzyOZgodnejWalucieIRoznychWartosciach()
        {
            Pieniadze p1 = new Pieniadze(10000);
            Pieniadze p2 = new Pieniadze(20000);
            Assert.IsTrue(p1 < p2,"p1 nie jest mniejsze od p2");
        }


        [TestMethod()]
        [ExpectedException(typeof(RozneWalutyException))]
        public void LowerThan_PorownaniePieniedzyONiezgodnejWalucieIRoznychWartosciach()
        {
            Pieniadze p1 = new Pieniadze(10000);
            Pieniadze p2 = new Pieniadze(20000,Pieniadze.Waluty.USD);
            Assert.IsTrue(p1 < p2, "p1 nie jest mniejsze od p2");
        }


        [TestMethod()]
        public void LowerOrEqual_PorownaniePieniedzyOZgodnejWalucieIRoznychWartosciach()
        {
            Pieniadze p1 = new Pieniadze(10000);
            Pieniadze p2 = new Pieniadze(20000);
            Assert.IsTrue(p1 <= p2, "p1 nie jest mniejsze bądź równe p2");
        }

        [TestMethod()]
        [ExpectedException(typeof(RozneWalutyException))]
        public void LowerOrEqual_PorownaniePieniedzyONiezgodnejWalucieIRoznychWartosciach()
        {
            Pieniadze p1 = new Pieniadze(10000);
            Pieniadze p2 = new Pieniadze(20000, Pieniadze.Waluty.USD);
            Assert.IsTrue(p1 <= p2, "p1 nie jest mniejsze bądź równe p2");
        }


        [TestMethod()]
        public void GreaterThan_PorownaniePieniedzyOZgodnejWalucieIRoznychWartosciach()
        {
            Pieniadze p1 = new Pieniadze(20000);
            Pieniadze p2 = new Pieniadze(10000);
            Assert.IsTrue(p1 > p2,"p1 nie jest większe od p2");
        }


        [TestMethod()]
        [ExpectedException(typeof(RozneWalutyException))]
        public void GreaterThan_PorownaniePieniedzyONiezgodnejWalucieIRoznychWartosciach()
        {
            Pieniadze p1 = new Pieniadze(10000);
            Pieniadze p2 = new Pieniadze(20000,Pieniadze.Waluty.USD);
            Assert.IsTrue(p1 > p2, "p1 nie jest większe od p2");
        }


        [TestMethod()]
        public void GreaterOrEqual_PorownaniePieniedzyOZgodnejWalucieIRoznychWartosciach()
        {
            Pieniadze p1 = new Pieniadze(20000);
            Pieniadze p2 = new Pieniadze(10000);
            Assert.IsTrue(p1 >= p2, "p1 nie jest większe bądź równe p2");
        }

        [TestMethod()]
        [ExpectedException(typeof(RozneWalutyException))]
        public void GreaterOrEqual_PorownaniePieniedzyONiezgodnejWalucieIRoznychWartosciach()
        {
            Pieniadze p1 = new Pieniadze(20000);
            Pieniadze p2 = new Pieniadze(10000, Pieniadze.Waluty.USD);
            Assert.IsTrue(p1 >= p2, "p1 nie jest większe bądź równe p2");
        }


        #endregion
        #endregion


        #region Dodawanie i odejmowanie
        [TestMethod()]
        public void Plus_DodawaniePieniedzyOZgodnejWalucie()
        {
            Pieniadze p1 = new Pieniadze(10000);
            Pieniadze p2 = new Pieniadze(10000);
            Assert.AreEqual(new Pieniadze(20000), p1 + p2);
        }


        [TestMethod()]
        [ExpectedException(typeof(RozneWalutyException))]
        public void Plus_DodawaniePieniedzyONiezgodnejWalucie()
        {
            Pieniadze p1 = new Pieniadze(10000);
            Pieniadze p2 = new Pieniadze(10000,Pieniadze.Waluty.USD);
            Pieniadze p3 = p1 + p2;
        }

        [TestMethod()]
        public void Minus_OdejmowaniePieniedzyOZgodnejWalucie()
        {
            Pieniadze p1 = new Pieniadze(10000);
            Pieniadze p2 = new Pieniadze(10000);
            Assert.AreEqual(new Pieniadze(0), p1 - p2);
        }


        [TestMethod()]
        [ExpectedException(typeof(RozneWalutyException))]
        public void Minus_OdejmowaniePieniedzyONiezgodnejWalucie()
        {
            Pieniadze p1 = new Pieniadze(10000);
            Pieniadze p2 = new Pieniadze(10000, Pieniadze.Waluty.USD);
            Pieniadze p3 = p1 - p2;
        }

        [TestMethod()]
        [ExpectedException(typeof(ArgumentException))]
        public void Minus_OdejmowanieZaDuzejWartosci()
        {
            Pieniadze p1 = new Pieniadze(10000);
            Pieniadze p2 = new Pieniadze(20000);
            Pieniadze p3 = p1 - p2;
        }

        #endregion
    }
}
