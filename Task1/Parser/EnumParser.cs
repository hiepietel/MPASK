using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Task1.Method;
namespace Task1.Parser
{
    public static class EnumParser
    {
        public static Dictionary<int, string> ReturnEnum(string enumm)
        {
            if(enumm != "")
            {
                Dictionary<int, string> dict = new Dictionary<int, string>();
                MatchCollection collection = TaskMethods.CollectionRegex(enumm, RegexString.ImportEnum, false);
                foreach(Match col in collection)
                {
                    string name = col.Groups[1].Value.RemoveSpecialCharacter();
                    int index = Int32.Parse(col.Groups[2].Value.RemoveSpecialCharacter());
                    dict.Add(index, name);
                }
                return dict;
            }
            return null;
        }
    }
}
