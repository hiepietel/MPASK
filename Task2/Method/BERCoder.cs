using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task2.Model;
using Task2.Enums;

namespace Task2.Method
{
    class BERCoder
    {
        Dictionary<string, SimpleData> SimpleDataTypes = new Dictionary<string, SimpleData>();
        List<ConstructedDataSchema> ConstructedDataSchemas = new List<ConstructedDataSchema>();
        LeafNode MasterNode;
        
        public BERCoder()
        {
            Task1.MIBreader MibReader = new Task1.MIBreader();
            MibReader.Import();
            MasterNode = MibReader.leafs;
        }

        public void CodeViaOID(string oid, string value)
        {
            LeafNode treeNode = MasterNode.SearchNode("sysServices", MasterNode);
            string type = treeNode.LeafData.ClassicDataType.ToString();
            //validate
                
            //
            Code(oid, type, value);
        }
        public void Code(string name, string type, string value = "")
        {

            Tag tag = Coder.CodeTag(type);
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
