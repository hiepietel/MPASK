using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Task3.Enums;
using Task3.Method;

namespace Task3.ConverterToEnumTests
{
    [TestClass]
    public class ConverterToEnumTests
    {
        [TestMethod]
        public void ConvertToTimeticksTest()
        {
            DataType dataType = ConverterToEnum.ToSimpleDatatype("43");
            Assert.AreEqual(dataType, DataType.Timeticks);
        }
    }
}
