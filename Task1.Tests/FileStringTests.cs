using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task1.Tests
{
    [TestClass]
    public class FileStringTests
    {
        [TestMethod]
        public void TestReturnFilePAth()
        {
            Assert.AreEqual("FC1155SMI.txt", Method.FileString.ReturnFilePath("RFC1155-SMI"));
        }
    }
}
