using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Task2.Enums;
using Task2.Model;

namespace Task2.Tests
{
    [TestClass]
    public class CoderTests
    {
        [TestMethod]
        public void AssignTagTest()
        {
            Tag tag = new Tag()
            {
                TPC = TagPC.Primitive,
                TClass = TagClass.universal,
                Length = 2
            };
            Tag codedTag = Coder.CodeTag("INTEGER");
            Assert.AreEqual(tag.TClass, codedTag.TClass);
            Assert.AreEqual(tag.TPC, codedTag.TPC);
            Assert.AreEqual(tag.Length, codedTag.Length);

        }
    }
}
