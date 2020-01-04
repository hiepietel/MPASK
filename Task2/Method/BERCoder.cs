using System;
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
        }
        public void ImportDataType(List<Task1.Model.DataType> datatypes)
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
        public void CodeViaOID(string oid, string value)
        {
            //sysDescr22
            LeafNode treeNode = MasterNode.SearchByOID(oid, MasterNode);
            string type = treeNode.LeafData.ClassicDataType.ToString();
            //string originalType = treeNode.LeafData.
            //validate
            var restricion = treeNode.LeafData.DTRestricion;
            if(restricion != null)
            {
                if(Validator.Validate(restricion, type, value))
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
        public void Code(string name, string type, string value = "")
        {
            Tag tag = Coder.CodeTag(type);
            if (name.IsOID())
            {

            }
            if(tag.TagNumber == (int)DataType.UNKNOWN)
            {
                ConstructedDataSchema schema = ConstructedDataSchemas.Find(x => x.Name == type);
                tag = Coder.CodeTag(schema.DataType);
            }            

            if (tag.TPC == TagPC.Primitive)
            {
                SimpleData simpleData = Coder.CodeSimpleData(value, tag);


                ConsoleInfo.CreatedData(name, tag, simpleData);
                Console.WriteLine("HEX: " + ConverterToHex.SimpleDataHex(tag, simpleData));
                SimpleDataTypes.Add(name, simpleData);
            }
            else if (tag.TPC == TagPC.Constructed)
            {
                ConstructedDataSchema schema = ConstructedDataSchemas.Find(x => x.Name == type);
                List<string> list = value.Split(',').ToList<string>();

                ConstructedData constructedData = Coder.CodeConstructedData(schema, list);
                ConverterToHex.ConstructedDataHex(tag, constructedData);

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
