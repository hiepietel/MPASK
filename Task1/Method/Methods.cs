using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Task1.Logs;
using Task1.Parser;

namespace Task1.Parser
{
    public static class Methods
    {
        public static MatchCollection CollectionRegex(string source, string regex, bool readFromFile = true)
        {
            source = readFromFile ? ReadFile(source) : source;
            MatchCollection returnCollection = Regex.Matches(source, regex, RegexOptions.Singleline | RegexOptions.Compiled | RegexOptions.CultureInvariant);
            return returnCollection;
        }
        public static Match MatchRegex(string source, string regex, bool readFromFile=true)
        {
            source = readFromFile ? ReadFile(source) : source;
            Match returnMatch = Regex.Match(source, regex, RegexOptions.Singleline | RegexOptions.Compiled | RegexOptions.CultureInvariant);
            return returnMatch;
        }
        public static string RemoveSpecialCharacter(this string str)
        {
            return str.Trim().Replace("\r", "").Replace("\n", "");
        }
        public static string RemoveSpaces(this string str)
        {
            do
            {
                str = str.Replace("  ", " ");

            } while (str.Contains("  "));
            return str;

        }
        //public static string = "data/FC1155SMI.txt";
        public static string ReadFile(string source)
        {
            string toReturn = "";
            try
            {
                using (StreamReader sr = new StreamReader(source))
                {
                    while (!sr.EndOfStream)
                    {
                        string line = sr.ReadLine();
                        //if (line.Contains("--"))
                        //{
                        //    int pos = line.IndexOf("--");
                        //    line = line.Remove(pos, line.Length - pos);
                        //}
                        toReturn += line;
                    }
                }
            }
            catch (IOException e)
            {
                //Console.WriteLine("The file could not be read:");
                //Console.WriteLine(e.Message);
                Logs.Logger.Error("Cannot read file from path: " + source + " " + e.Message);
            }

            return toReturn;
        }
        
    }
}
