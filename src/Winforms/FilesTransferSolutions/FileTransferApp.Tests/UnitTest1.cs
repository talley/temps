using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace FileTransferApp.Tests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestPass()
        {
            Assert.AreEqual(1, 1);
        }

        [TestMethod]
        public void TestFail()
        {
            Assert.Fail();
        }
    }
}