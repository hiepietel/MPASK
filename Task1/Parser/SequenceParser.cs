using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Task1.Method;
using Task1.Model;
using Task1.Rgx;

namespace Task1.Parser
{
    public static class SequenceParser
    {
        public static List<ElementOfSequnce> ReturnElementsOfSequnece(string data)
        {
            data = data.Remove(0, data.IndexOf('{')+1);
            data = data.Remove(data.IndexOf('}'));
            List<ElementOfSequnce> elementOfSequnces = new List<ElementOfSequnce>();
            MatchCollection matchCollection = TaskMethods.CollectionRegex(data, RgxString.ImportSEQUENCEelements, false);
            foreach (Match item in matchCollection)
            {
                ElementOfSequnce elementOfSequnce = new ElementOfSequnce()
                {
                    Name = item.Groups[2].Value.RemoveSpecialCharacter(),
                    Data = item.Groups[3].Value.RemoveSpecialCharacter(),
                    Restrictions = RestricionParser.ReturnRestricion(item.Groups[4].Value.RemoveSpecialCharacter())

                };
                if(elementOfSequnce.Name != "" || elementOfSequnce.Data !="")
                    elementOfSequnces.Add(elementOfSequnce);
            }
            return elementOfSequnces;
        }

        public static Sequence? ReturnSequence(string filepath, string seqq)
        {
            MatchCollection matchesData = TaskMethods.CollectionRegex("data/" + filepath.ReturnFilePath(), RgxString.ImportSEQUENCE);
            // MatchCollection matchesData = TaskMethods.CollectionRegex("data/" + mainFilePath.ReturnFilePath(), RegexString.DataTypeRGX);
            //List<DataType> list = DoTree(matchesData, dataTypes);
            foreach  (Match match in matchesData)
            {
                string seq = seqq.RemoveSpecialCharacter();
                seq = seq.RemoveSpecialCharacter();
                string name = match.Groups[1].Value.RemoveSpecialCharacter();
                
                bool isSequenceOf = false;
                string sequenceOf = "SEQUENCE OF ";
                if (seq.Contains(sequenceOf))
                {                    
                    isSequenceOf = true;
                    seq = seq.Replace(sequenceOf, "");
                }
                if(name == seq)
                {
                    Sequence sequence = new Sequence()
                    {
                        Name = !isSequenceOf ? name : sequenceOf + seq,
                        IsSequenceOf = isSequenceOf,
                        ElementsOfSequnces = ReturnElementsOfSequnece(match.Value)
                    };
                    return sequence;
                }
                
            }
            return null;
        }

    }
}
