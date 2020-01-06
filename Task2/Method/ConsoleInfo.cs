using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task2.Enums;
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
            foreach (KeyValuePair<string, string> obj in constructedDataSchema.Objects)
            {
                Console.Write("     " + obj.Key + " ");
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine(obj.Value);
                Console.ForegroundColor = ConsoleColor.White;
            }
            Console.WriteLine("}");
        }
        public static void CreatedData(string name, Tag tag, SimpleData simpleData)
        {
            Console.Write(name + " ");
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.Write((DataType)tag.TagNumber);
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine(" ::= " + simpleData.Value);
            Console.ForegroundColor = ConsoleColor.White;

        }
        public static void RestrictionsFailed(Restricion restricion, string type, string value, string oid)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("ERROR!");
            Console.ForegroundColor = ConsoleColor.White;
            Console.Error.WriteLine("Cannot assign value: " + value + " for oid: " + oid);
            if (restricion.HasSize)
            {

                Console.Error.Write("Enabled: ");
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write(type);
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine(" SIZE(" + restricion.Min.ToString() + ".." + restricion.Max.ToString() + ")");
            }
            else
            {
                Console.Error.Write("Enabled: ");
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write(type);
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine(" (" + restricion.Min.ToString() + ".." + restricion.Max.ToString() + ")");
            }
        }
        public static void IncorrectVisibility(string visibility)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("WARN");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("Visibility {0} is not allowed", visibility);
        }
        //TODO - ConstructedData

    }
}
