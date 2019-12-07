using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Task1.Method;

namespace Task2
{
    public static class Reader
    {
       public static void Read()
        {

            MatchCollection matchCollection = TaskMethods.CollectionRegex("data/Assigment.txt", RegexString.SimpleDataRGX);
        }
    }
}
