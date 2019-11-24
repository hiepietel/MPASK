using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task1.Tests
{
    [TestClass]
    public class EnumsTests
    {
        [TestMethod]
        public void TestToStatus()
        {
            string testString = "mandatory";
            Assert.AreEqual(Enums.STATUS.mandatory, Method.ConverterToEnum.ToStatus(testString));
            testString = "current";
            Assert.AreEqual(Enums.STATUS.current, Method.ConverterToEnum.ToStatus(testString));
            testString = "obsolete";
            Assert.AreEqual(Enums.STATUS.obsolete, Method.ConverterToEnum.ToStatus(testString));
            testString = "deprecated";
            Assert.AreEqual(Enums.STATUS.deprecated, Method.ConverterToEnum.ToStatus(testString));
            testString = "optional";
            Assert.AreEqual(Enums.STATUS.optional, Method.ConverterToEnum.ToStatus(testString));
        }
        [TestMethod]
        public void TestToAccess()
        {
            Assert.AreEqual(Enums.ACCESS.read_only, Method.ConverterToEnum.ToAccess("read-only"));
            Assert.AreEqual(Enums.ACCESS.not_accessible, Method.ConverterToEnum.ToAccess("not-accessible"));
            Assert.AreEqual(Enums.ACCESS.read_write, Method.ConverterToEnum.ToAccess("read-write"));
        }
    }
}
