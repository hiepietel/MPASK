using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Task1.Method;
using Task1.Model;
using Task1.Rgx;
using Model;

namespace Task1.Parser
{
    public static class RestricionParser
    {
        public static Restricion ReturnRestricion(string restricion)
        {
            if (restricion != "")
            {

                Restricion res = new Restricion();
                if (restricion.Contains("SIZE"))
                {
                    res.HasSize = true;
                }
                Match resMatch = TaskMethods.MatchRegex(restricion, RgxString.ImportRestricion, false);
                res.Min = Int32.Parse(resMatch.Groups[1].Value.RemoveSpecialCharacter());
                res.Max = Int32.Parse(resMatch.Groups[2].Value.RemoveSpecialCharacter());
                return res;
            }
            return null;
        }
        public static Restricion ReturnRestricionFromEnum(Dictionary<int, string> dict)
        {
            int max = dict.Keys.Max();
            int min = dict.Keys.Min();
            Restricion res = new Restricion()
            {
                HasSize = false,
                Min = min,
                Max = max
            };
            return res;
        }
    }
}
