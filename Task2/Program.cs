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
            Tag tag = Coder.CodeTag("INTEGER");
            Coder.CodeData("127", tag);
        }
    }
}
