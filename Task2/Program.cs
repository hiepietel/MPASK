using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task1;
using Task2.Model;

namespace Task2
{
    class Program
    {
        static void Main(string[] args)
        {
            //Reader.Read();
            //MIBreader mibreader = new MIBreader();
            //mibreader.Import();
            //mibreader.leafs.PrintTree(mibreader.leafs);
            //Console.ReadKey();

            Tag tag = Coder.CodeTag("BIT STRING");
            string bitstring = "0";
            //byte bitsstring = 0x10;
            byte[] a = { 0x20, 0xcf, 0xff, 0xaf, 0xdd };
            Coder.CodeData(bitstring, tag);
        }
    }
}
