using Microsoft.VisualStudio.TestTools.UnitTesting;
using lab_01;
namespace TestProject1
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestKonstruktora()
        {
            U³amek a = new U³amek(1, 2);
            Assert.AreEqual(1, a.Licznik);
            Assert.AreEqual(2, a.Mianownik);
        }
        [TestMethod]

    }
}
