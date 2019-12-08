using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Task1.Method;
using Task2.Rgx;

namespace Task2
{
    public static class Reader
    {
       
       public static void Read()
        {
            string source = "data/Assigment.txt";
            try
            {
                using (StreamReader sr = new StreamReader(source))
                {
                    while (!sr.EndOfStream)
                    {
                        string line = sr.ReadLine();
                        
                    }
                }
            }
            catch (IOException e)
            {
                Console.WriteLine("The file could not be read:");
                Console.WriteLine(e.Message);
            }
            MatchCollection matchCollection = TaskMethods.CollectionRegex("data/Assigment.txt", RegexString.SimpleDataRGX);
        }
    }
}
