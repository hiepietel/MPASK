using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task1.Tests
{
    [TestClass]
    public class TreeDynamicTests
    {
       
        public void TestNode(LeafNode master)
        {
            //Place to test leaf
            Assert.IsNotNull(master.Name);
            Assert.IsNotNull(master.Index);
            if(master.LeafData != null)
            {
                Assert.IsNotNull(master.LeafData.Description);
                Assert.IsNotNull(master.LeafData.Access);
            }
            //end of testing leaf
            foreach(LeafNode leafnode in master.Children)
            {
                TestNode(leafnode);
            }
        }
        [TestMethod]
        public void TestTree()
        {
            MIBreader mibreader = new MIBreader();
            mibreader.Import();
            TestNode(mibreader.leafs);
        }
    }
}
