using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task1;
using Task2.Enums;
using Task2.Method;
using Task2.Model;

namespace Task2
{

    class Program
    {
        static void Main(string[] args)
        {
            //Reader.Read();
            MIBreader mibreader = new MIBreader();
            mibreader.Import();
            //mibreader.leafs.PrintTree(mibreader.leafs);
            //Console.ReadKey();
            LeafNode treeNode = mibreader.leafs.SearchNode("ifNumber", mibreader.leafs);

            BERCoder ber = new BERCoder();
            ber.CreateSchema("TwoInt", "SEQUENCE", "age:INTEGER");
            //ber.CreateSchema("MySequence", "SEQUENCE", "age:INTEGER,name:BIT STRING");
            //ber.Code("age", "INTEGER", "45");
            //ber.Code("var127", "INTEGER", "127");
            //ber.Code("var128", "INTEGER", "128");
            //ber.Code("null", "NULL");
            ber.Code("seq", "TwoInt", "127,128");


            Tag tag = Coder.CodeTag("BIT STRING");
            string bitstring = "0";
            //byte bitsstring = 0x10;
            byte[] a = { 0x20, 0xcf, 0xff, 0xaf, 0xdd };
            
            Coder.CodeSimpleData(bitstring, tag);
            
            var dic = new Dictionary<string, string>();
            dic.Add("INTEGER", "age");
            dic.Add("BIT STRING", "bit");

            ConstructedDataSchema contructedDataSchema = new ConstructedDataSchema() {
                DataType = "SEQUENCE",
                Name = "MySequence",
                Objects = dic
            };

            var list = new List<string>();
            list.Add("50");
            list.Add("1");

            ConstructedData constructedData = Coder.CodeConstructedData(contructedDataSchema, list);


        }
    }
}
