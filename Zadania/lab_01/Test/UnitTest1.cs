using Microsoft.VisualStudio.TestTools.UnitTesting;
using lab_01;
using System.Collections.Generic;

namespace Test
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestKonstruntora()
        {
            var a = new U�amek(1, 2);
            Assert.AreEqual(1, a.Licznik);
            Assert.AreEqual(2, a.Mianownik);
        }
        [TestMethod]
        public void TestToString()
        {
            var a = new U�amek(3, 4);
            Assert.AreEqual($"licznik: {a.Licznik}, ,mianownik {a.Mianownik}", a.ToString());
        }
        [TestMethod]
        public void TestOperator�w()
        {
            var expected = new U�amek(3, 4);
            var a = new U�amek(1 , 4);
            var b = new U�amek(2 , 4);
            var wynik = a + b;
            Assert.AreEqual(expected.Licznik/expected.Mianownik,wynik.Licznik/expected.Mianownik);
        }
        [TestMethod]
        public void TestInterface()
        {
            var lista = new List<U�amek>() { new U�amek(1, 4), new U�amek(3, 4), new U�amek(2, 4) };
            lista.Sort();
            Assert.AreEqual(2, lista[1].Licznik);
        }
        [TestMethod]
        public void TestGettera()
        {        
            var a = new U�amek(1, 2);
            Assert.AreEqual(1, a.Licznik);
        }
        [TestMethod]
        public void TestWlasnychMetod()
        {
            var a = new U�amek(1, 2);
            Assert.AreEqual(0, a.RoundDown());
            Assert.AreEqual(1, a.RoundUp());
        }
    }
}
