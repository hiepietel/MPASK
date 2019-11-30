using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Task1.Method;

namespace Task1.Tests
{
    [TestClass]
    public class ConsoleColorTests
    {
        [TestMethod]
        public void TestRemoveSpaces()
        {
            string testString = "a    bcc";
            Assert.AreEqual("a bcc", testString.RemoveSpaces());
        }
        public void TestConsoleColor()
        {
            LeafNode leafNode = new LeafNode
            {
                LeafData = null
            };
            Assert.AreEqual(ConsoleColor.White, TaskMethods.ReturnConsoleColor(leafNode));
        }
    }
}
