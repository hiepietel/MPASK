﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task2.Model;
using Task2.Enums;
using Model;

namespace Task2.Method
{
    class BERCoder
    {
        //TODO - need to add create schema for sequence
        Dictionary<string, SimpleData> SimpleDataTypes = new Dictionary<string, SimpleData>();
        List<ConstructedDataSchema> ConstructedDataSchemas = new List<ConstructedDataSchema>();
        LeafNode MasterNode;
        Dictionary<string, MIBDataType> MIBDataType = new Dictionary<string, MIBDataType>();
        public BERCoder()
        {
            Task1.MIBreader MibReader = new Task1.MIBreader();
            MibReader.Import();
            ImportDataType(MibReader.dataTypes);
            MasterNode = MibReader.leafs;
            CreateSchemaTree(MibReader.leafs.ListOfSequences(MasterNode));
        }
        private void ImportDataType(List<Task1.Model.DataType> datatypes)
        {
            foreach (var item in datatypes)
            {
                MIBDataType mibDataType = new MIBDataType() {
                    Index = item.TypeIndex,
                    MibType = item.Type,
                    MibVisibility = item.Visibility
                };
                MIBDataType.Add(item.Name, mibDataType);
            }
            
        }
        private void CreateSchemaTree(List<LeafNode> listOfSequences)
        {
            foreach (var seq in listOfSequences)
            {
                //ConstructedDataSchema constructedDataSchema = new ConstructedDataSchema();
                //constructedDataSchema.Name = seq.Name;
                string strOfDatas = "";
                foreach ( var data in seq.LeafData.SequenceObjectType.ElementsOfSequnces)
                {
                    strOfDatas += data.Name + ":" + data.Data + ",";
                }
                strOfDatas =  strOfDatas.Remove(strOfDatas.LastIndexOf(','));
                CreateSchema(seq.Name, "SEQUENCE", strOfDatas);
            }
        }
        public void CodeViaOID(string oid, string value)
        {
            //sysDescr22
            LeafNode treeNode = MasterNode.SearchByOID(oid, MasterNode);
            bool isDataType = treeNode.LeafData.ClassicDataType != null ? true : false;
            string type = "";
            if (isDataType)
            {
                type = treeNode.LeafData.ClassicDataType.ToString();
                var restricion = treeNode.LeafData.DTRestricion;
                if (restricion != null)
                {
                    if (Validator.Validate(restricion, type, value))
                    {
                        Code(oid, type, value);
                    }
                    else
                    {
                        ConsoleInfo.RestrictionsFailed(restricion, type, value, oid);
                    }
                }
                else
                {
                    Code(oid, type, value);
                }
            }
            else 
            {
                type = treeNode.LeafData.SequenceObjectType.Name;
                bool isSeqCorrect = true;
                string[] values = value.Split(',');
                int itemIterator = 0;
                foreach (var item in treeNode.LeafData.SequenceObjectType.ElementsOfSequnces)
                {
                    if (item.Restrictions != null && isSeqCorrect)
                    {
                        if (Validator.Validate(item.Restrictions, item.Data, values[itemIterator]))
                        {
                            ConsoleInfo.RestrictionsFailed(item.Restrictions, item.Data, values[itemIterator], oid);
                            isSeqCorrect = false;
                            break;
                        }
                        else
                        {
                            itemIterator++;
                        }
                    }
                }
                if (isSeqCorrect)
                    Code(oid, type, value);
            }
            
            //string originalType = treeNode.LeafData.
            //validate
           
            
        }
        public void Code(string name, string type, string value = "", string visibility = "", string tagged = "")
        {
            Tag tag = Coder.CodeTag(type, visibility, tagged);
            if (name.IsOID())
            {
            }
            if(tag.TagNumber == (int)DataType.UNKNOWN)
            {
                ConstructedDataSchema schema = ConstructedDataSchemas.Find(x => x.Name.ToLower() == type.ToLower());
                
                tag = Coder.CodeTag(schema.DataType);
            }            

            if (tag.TPC == TagPC.Primitive)
            {
                SimpleData simpleData = Coder.CodeSimpleData(value, tag);


                ConsoleInfo.CreatedData(name, tag, simpleData);
                ConsoleInfo.HexValue(ConverterToHex.SimpleDataHex(tag, simpleData));
                try
                {
                    SimpleDataTypes.Add(name, simpleData);
                }
                catch(ArgumentException argumentException)
                {
                    Console.WriteLine("Varible name allready used");
                    Console.WriteLine(argumentException);
                }
            }
            else if (tag.TPC == TagPC.Constructed)
            {
                ConstructedDataSchema schema = ConstructedDataSchemas.Find(x => x.Name.ToLower() == type.ToLower());
                List<string> list = value.Split(',').ToList<string>();

                ConstructedData constructedData = Coder.CodeConstructedData(schema, list);
                ConsoleInfo.CreatedContructedData(name, type, tag, constructedData);
                ConsoleInfo.HexValue(ConverterToHex.ConstructedDataHex(tag, constructedData));
            }
        }
        public void CreateSchema(string name, string type, string datas)
        {
            Dictionary<string, string> dataDic = new Dictionary<string, string>();
            string[] dataTable = datas.Split(',');
            foreach (string data in dataTable)
            {
                string[] toAdd = data.Split(':');
                dataDic.Add(toAdd[0], toAdd[1]);
            }
            ConstructedDataSchema constructedDataSchema = new ConstructedDataSchema()
            {
                Objects = dataDic,
                DataType = type,
                Name = name
            };
            ConsoleInfo.CreatedSchema(constructedDataSchema);
            ConstructedDataSchemas.Add(constructedDataSchema);
        }
    }
}
