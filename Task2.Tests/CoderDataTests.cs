﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task2.Enums;
using Task2.Model;

namespace Task2.Tests
{
    [TestClass]
    public class CoderDataTests
    {
        [TestMethod]
        public void AssignDataTest()
        {
            Tag tag = new Tag()
            {
                TPC = TagPC.Primitive,
                TClass = TagClass.universal,
                TagNumber = 2
            };
            LengthValueData LVData = new LengthValueData
            {
                LengthAmount = 1,
                LType = LengthType.ShortForm,
                Value = "127"
            };
            var rLVData = Coder.CodeData("127", tag);
            //Assert.AreEqual(LVData.LengthAmount, rLVData.LengthAmount);
            Assert.AreEqual(LVData.LType, rLVData.LType);
            Assert.AreEqual(LVData.Value, rLVData.Value);
            LVData = new LengthValueData
            {
                LengthAmount = 2,
                LType = LengthType.LongForm,
                Value = "128"
            };
            rLVData = Coder.CodeData("128", tag);
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
            LengthValueData LVData = new LengthValueData
            {
                LengthAmount = 1,
                LType = LengthType.ShortForm,
                Value = "4",
                
            };
            var rLVData = Coder.CodeData("4", tag);
            Assert.AreEqual(LVData.Value, rLVData.Value);
            Assert.AreEqual(LVData.LType, rLVData.LType);
            Assert.AreEqual(LVData.LengthAmount, rLVData.LengthAmount);
        }
    }
}
