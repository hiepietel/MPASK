using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task2.Model;

namespace Task2.Method
{
    public static class ConsoleInfo
    {
        public static void CreatedSchema(ConstructedDataSchema constructedDataSchema)
        {
            Console.Write(constructedDataSchema.Name + " ::= ");
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.Write(constructedDataSchema.DataType);
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine(" {");
            foreach(KeyValuePair<string, string> obj in constructedDataSchema.Objects)
            {
                Console.Write("     "+obj.Key + " ");
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine(obj.Value);
                Console.ForegroundColor = ConsoleColor.White;
            }
            Console.WriteLine("}");
        }
        public static void CreatedData(string name,Tag tag, SimpleData simpleData)
        {
            Console.Write(name + " ");
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.Write(tag.TagNumber);
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write(" ::= "+simpleData.Value);
            Console.ForegroundColor = ConsoleColor.White;
        }
    }
}
