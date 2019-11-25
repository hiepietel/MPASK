using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Task1.Method;
using Task1.Model;

namespace Task1.Parser
{
    public static class SequenceParser
    {
        public static Sequence? ReturnSequence(string filepath, string seqq)
        {
            MatchCollection matchesData = TaskMethods.CollectionRegex("data/" + filepath.ReturnFilePath(), RegexString.ImportSEQUENCE);
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
                        Name = !isSequenceOf ? name : sequenceOf+seq,
                        IsSequenceOf = isSequenceOf
                    };
                    return sequence;
                }
                
            }
            return null;
        }

    }
}
