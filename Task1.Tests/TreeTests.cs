using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task1.Tests
{
    [TestClass]
    public class TreeTests
    {
        [TestMethod]
        public void TestSearchOID()
        {
            MIBreader mibreader = new MIBreader();
            mibreader.Import();
            //check if tree node is not null
            Assert.IsNotNull(mibreader.leafs.SearchByOID("1.3.6.1", mibreader.leafs)); //internet
            Assert.IsNotNull(mibreader.leafs.SearchByOID("1.3.6.1.2.1.1.1", mibreader.leafs)); //sysDescr
            Assert.IsNotNull(mibreader.leafs.SearchByOID("1.3.6.1.2.1.2.2.1", mibreader.leafs)); //ifEntry
            Assert.IsNotNull(mibreader.leafs.SearchByOID("1.3.6.1.2.1.2", mibreader.leafs)); //interfaces
            Assert.IsNotNull(mibreader.leafs.SearchByOID("1.3.6.1.2.1.3.1.1.3", mibreader.leafs)); //atNetAddress
            Assert.IsNotNull(mibreader.leafs.SearchByOID("1", mibreader.leafs)); //iso
            Assert.IsNotNull(mibreader.leafs.SearchByOID("1.3.6.1.4.1", mibreader.leafs)); //enteprises
            //check if tree has proper name
            Assert.AreEqual("internet", mibreader.leafs.SearchByOID("1.3.6.1", mibreader.leafs).Name);
            Assert.AreEqual("sysDescr", mibreader.leafs.SearchByOID("1.3.6.1.2.1.1.1", mibreader.leafs).Name); //sysDescr
            Assert.AreEqual("ifEntry", mibreader.leafs.SearchByOID("1.3.6.1.2.1.2.2.1", mibreader.leafs).Name); //ifEntry
            Assert.AreEqual("interfaces", mibreader.leafs.SearchByOID("1.3.6.1.2.1.2", mibreader.leafs).Name); //interfaces
            Assert.AreEqual("atNetAddress", mibreader.leafs.SearchByOID("1.3.6.1.2.1.3.1.1.3", mibreader.leafs).Name); //atNetAddress
            Assert.AreEqual("iso",mibreader.leafs.SearchByOID("1", mibreader.leafs).Name); //iso
            Assert.AreEqual("enterprises", mibreader.leafs.SearchByOID("1.3.6.1.4.1", mibreader.leafs).Name); //enteprises
        }
        [TestMethod]
        public void TestSearchNode()
        {
            MIBreader mibreader = new MIBreader();
            mibreader.Import();
            //check if exists
            Assert.IsNotNull(mibreader.leafs.SearchNode("internet", mibreader.leafs));
            Assert.IsNotNull(mibreader.leafs.SearchNode("sysDescr", mibreader.leafs));
            Assert.IsNotNull(mibreader.leafs.SearchNode("ifEntry", mibreader.leafs));
            Assert.IsNotNull(mibreader.leafs.SearchNode("internet", mibreader.leafs));
            Assert.IsNotNull(mibreader.leafs.SearchNode("interfaces", mibreader.leafs));
            Assert.IsNotNull(mibreader.leafs.SearchNode("atNetAddress", mibreader.leafs));
            Assert.IsNotNull(mibreader.leafs.SearchNode("iso", mibreader.leafs));
            Assert.IsNotNull(mibreader.leafs.SearchNode("enterprises", mibreader.leafs));
            //check if name is correct
            Assert.AreEqual("internet", mibreader.leafs.SearchNode("internet", mibreader.leafs).Name);
            Assert.AreEqual("sysDescr", mibreader.leafs.SearchNode("sysDescr", mibreader.leafs).Name);
            Assert.AreEqual("ifEntry", mibreader.leafs.SearchNode("ifEntry", mibreader.leafs).Name);
            Assert.AreEqual("internet", mibreader.leafs.SearchNode("internet", mibreader.leafs).Name);
            Assert.AreEqual("interfaces", mibreader.leafs.SearchNode("interfaces", mibreader.leafs).Name);
            Assert.AreEqual("atNetAddress", mibreader.leafs.SearchNode("atNetAddress", mibreader.leafs).Name);
            Assert.AreEqual("iso", mibreader.leafs.SearchNode("iso", mibreader.leafs).Name);
            Assert.AreEqual("enterprises", mibreader.leafs.SearchNode("enterprises", mibreader.leafs).Name);

        }
        [TestMethod]
        public void TestDatatypeIsNull()
        {
            MIBreader mibreader = new MIBreader();
            mibreader.Import();
            //check is datatype is null
            Assert.IsNull(mibreader.leafs.SearchNode("internet", mibreader.leafs).LeafData);
            Assert.IsNull(mibreader.leafs.SearchByOID("1.3.6.1", mibreader.leafs).LeafData);            
            Assert.IsNull(mibreader.leafs.SearchNode("interfaces", mibreader.leafs).LeafData);
            Assert.IsNull(mibreader.leafs.SearchByOID("1.3.6.1.2.1.2", mibreader.leafs).LeafData);
            //check if datatype is not null
            Assert.IsNotNull(mibreader.leafs.SearchNode("sysDescr", mibreader.leafs).LeafData);
            Assert.IsNotNull(mibreader.leafs.SearchByOID("1.3.6.1.2.1.1.1", mibreader.leafs).LeafData);
            Assert.IsNotNull(mibreader.leafs.SearchNode("ifEntry", mibreader.leafs).LeafData);
            Assert.IsNotNull(mibreader.leafs.SearchByOID("1.3.6.1.2.1.2.2.1", mibreader.leafs).LeafData);
        }
        [TestMethod]
        public void TestDataTypeSequence()
        {
            MIBreader mibreader = new MIBreader();
            mibreader.Import();
            Assert.IsNotNull(mibreader.leafs.SearchNode("ifEntry", mibreader.leafs).LeafData.SequenceObjectType);
            Assert.IsNotNull(mibreader.leafs.SearchByOID("1.3.6.1.2.1.2.2.1", mibreader.leafs).LeafData.SequenceObjectType);
            Assert.IsNotNull(mibreader.leafs.SearchNode("atTable", mibreader.leafs).LeafData.SequenceObjectType);
            Assert.IsNotNull(mibreader.leafs.SearchByOID("1.3.6.1.2.1.3.1", mibreader.leafs).LeafData.SequenceObjectType);
        }
    }
}
