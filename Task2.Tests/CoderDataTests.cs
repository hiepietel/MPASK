using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task2.Enums;
using Task2.Method;
using Task2.Model;

namespace Task2.Tests
{
    [TestClass]
    public class CoderDataTests
    {
        [TestMethod]
        public void AssignIntegerTest()
        {
            Tag tag = new Tag()
            {
                TPC = TagPC.Primitive,
                TClass = TagClass.universal,
                TagNumber = 2
            };
            SimpleData LVData = new SimpleData
            {
                LengthAmount = 1,
                LType = LengthType.ShortForm,
                Value = "127"
            };
            var rLVData = Coder.CodeSimpleData("127", tag);
            //Assert.AreEqual(LVData.LengthAmount, rLVData.LengthAmount);
            Assert.AreEqual(LVData.LType, rLVData.LType);
            Assert.AreEqual(LVData.Value, rLVData.Value);
            LVData = new SimpleData
            {
                LengthAmount = 2,
                LType = LengthType.LongForm,
                Value = "128"
            };
            rLVData = Coder.CodeSimpleData("128", tag);
            //Assert.AreEqual(LVData.LengthAmount, rLVData.LengthAmount);
            //Assert.AreEqual(LVData.LType, rLVData.LType);
           // Assert.AreEqual(LVData.Value, rLVData.Value);
        }
        [TestMethod]
        public void AssignBitStringTest()
        {
            Tag tag = new Tag()
            {
                TPC = TagPC.Primitive,
                TClass = TagClass.universal,
                TagNumber = 3
            };
            SimpleData LVData = new SimpleData
            {
                LengthAmount = 1,
                LType = LengthType.ShortForm,
                Value = "4",
                
            };
            var rLVData = Coder.CodeSimpleData("4", tag);
            Assert.AreEqual(LVData.Value, rLVData.Value);
            Assert.AreEqual(LVData.LType, rLVData.LType);
            Assert.AreEqual(LVData.LengthAmount, rLVData.LengthAmount);
        }
        [TestMethod]
        public void AssignObjectIdentifierTest()
        {
            Tag tag = new Tag()
            {
                TPC = TagPC.Primitive,
                TClass = TagClass.universal,
                TagNumber = 6
            };
            var rLVData = Coder.CodeSimpleData("1.3.6.1.4.1", tag);
            Assert.AreEqual("2b06010401", rLVData.ValueHex);
        }
        [TestMethod]
        public void AssignDataTest()
        {
            //02, 02, FF 7F (INTEGER, -129)
            Tag tag = new Tag()
            {
                TPC = TagPC.Primitive,
                TClass = TagClass.universal,
                TagNumber = 2
            };
            var rLVData = Coder.CodeSimpleData("-129", tag);
            //Assert.AreEqual("FF7F", rLVData.ValueHex);
            //04,04, 01 02 03 04 (OCTET STRING, – wartość to: 01020304
            tag = new Tag()
            {
                TPC = TagPC.Primitive,
                TClass = TagClass.universal,
                TagNumber = (int)DataType.OCTET_STRING
            };
            rLVData = Coder.CodeSimpleData("Jones", tag);
            Assert.AreEqual("4A6FT36573", rLVData.ValueHex.ToUpper());
            //05 00 (NULL)
            tag = new Tag()
            {
                TPC = TagPC.Primitive,
                TClass = TagClass.universal,
                TagNumber = (int)DataType.NULL
            };
            rLVData = Coder.CodeSimpleData("", tag);
            Assert.AreEqual("", rLVData.ValueHex);
            //1A 05 4A 6F T3 65 73 (ciąg znaków “Jones” )

        }
    }
}
