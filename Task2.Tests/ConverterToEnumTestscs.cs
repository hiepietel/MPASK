using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task2.Enums;
using Task2.Method;

namespace Task2.Tests
{
    [TestClass]
    public class ConverterToEnumTestscs
    {
        [TestMethod]
        public void ToSimpleDataTypeTest()
        {
            DataType dataType = DataType.BIT_STRING;
            Assert.AreEqual(dataType, ConverterToEnum.ToSimpleDatatype("BIT STRING"));            
            dataType = DataType.INTEGER;
            Assert.AreEqual(dataType, ConverterToEnum.ToSimpleDatatype("INTEGER"));
            dataType = DataType.OCTET_STRING;
            Assert.AreEqual(dataType, ConverterToEnum.ToSimpleDatatype("OCTET STRING"));
            dataType = DataType.OBJECT_IDENTIFIER;
            Assert.AreEqual(dataType, ConverterToEnum.ToSimpleDatatype("OBJECT IDENTIFIER"));
            dataType = DataType.SEQUENCE;
            Assert.AreEqual(dataType, ConverterToEnum.ToSimpleDatatype("SEQUENCE"));
            dataType = DataType.UNKNOWN;
            Assert.AreEqual(dataType, ConverterToEnum.ToSimpleDatatype("?????"));
        }
    }
}
