using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Task2.Enums;
using Task2.Model;

namespace Task2.Tests
{
    [TestClass]
    public class CoderTagTests
    {
        [TestMethod]
        public void AssignIntegerTagTest()
        {
            
            Tag tag = new Tag()
            {
                TPC = TagPC.Primitive,
                TClass = TagClass.universal,
                TagNumber = 2
            };
            Tag codedTag = Coder.CodeTag("INTEGER");
            Assert.AreEqual(tag.TClass, codedTag.TClass);
            Assert.AreEqual(tag.TPC, codedTag.TPC);
            Assert.AreEqual(tag.TagNumber, codedTag.TagNumber);
        }
        [TestMethod]
        public void AssignNullTagTest()
        {
            Tag tag = new Tag()
            {
                TPC = TagPC.Primitive,
                TClass = TagClass.universal,
                TagNumber = 5
            };
            Tag codedTag = Coder.CodeTag("NULL");
            Assert.AreEqual(tag.TClass, codedTag.TClass);
            Assert.AreEqual(tag.TPC, codedTag.TPC);
            Assert.AreEqual(tag.TagNumber, codedTag.TagNumber);
        }
        [TestMethod]
        public void AssignOctetStringTagTest()
        {
            Tag tag = new Tag()
            {
                TPC = TagPC.Primitive,
                TClass = TagClass.universal,
                TagNumber = 4
            };
            Tag codedTag = Coder.CodeTag("OCTET STRING");
            Assert.AreEqual(tag.TClass, codedTag.TClass);
            Assert.AreEqual(tag.TPC, codedTag.TPC);
            Assert.AreEqual(tag.TagNumber, codedTag.TagNumber);
        }
        [TestMethod]
        public void AssignObjectIdentifierTagTest()
        {
            Tag tag = new Tag()
            {
                TPC = TagPC.Primitive,
                TClass = TagClass.universal,
                TagNumber = 6
            };
            Tag codedTag = Coder.CodeTag("OBJECT IDENTIFIER");
            Assert.AreEqual(tag.TClass, codedTag.TClass);
            Assert.AreEqual(tag.TPC, codedTag.TPC);
            Assert.AreEqual(tag.TagNumber, codedTag.TagNumber);
        }
        public void AssignBitStringTagTest()
        {
            Tag tag = new Tag()
            {
                TPC = TagPC.Primitive,
                TClass = TagClass.universal,
                TagNumber = 3
            };
            Tag codedTag = Coder.CodeTag("BIT STRING");
            Assert.AreEqual(tag.TClass, codedTag.TClass);
            Assert.AreEqual(tag.TPC, codedTag.TPC);
            Assert.AreEqual(tag.TagNumber, codedTag.TagNumber);
        }

    }
}
