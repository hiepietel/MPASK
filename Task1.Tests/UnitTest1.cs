using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Task1.Tests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestRemoveSpaces()
        {
            string testString = "a    bcc";
            Assert.AreEqual("a bcc", testString.RemoveSpaces());
        }
    }
}
