using System;
using System.Collections.Generic;
using System.IO;
using System.Text.RegularExpressions;
using Task1;
using Task1.Method;
using Task1.Model;
using Task1.Parser;
using Task1.Rgx;

namespace Task1
{
    public partial class MIBreader
    {
        public LeafNode leafs { get; set; }
        public List<string> importedFiles { get; set; }
        public List<DataType> dataTypes { get; set; }
        string MainFilePath { get; set; }
        public MIBreader()
        {
            MainFilePath = "RFC1213";
            Init();
        }
        public MIBreader(string MFP)
        {
            MainFilePath = MFP;
            Init();
        }
        public void Import()
        {
            Import(MainFilePath);
            ReturnAllTree(MainFilePath);
        }
        partial void Import(string filePath);
        partial void Init();
        partial void ReturnAllTree(string from);
    }
    partial class MIBreader
    {
        partial void Init()
        {
            leafs = LeafParser.InitNodeTRee();
            importedFiles = new List<string>();
            dataTypes = new List<DataType>();

        }
        partial void ReturnAllTree(string from)
        {
            importedFiles.Add(from);
            dataTypes = DataTypeParser.ReturnTree(from, dataTypes);
            leafs = LeafParser.ReturnTree(from, leafs);
            leafs = LeafDataParser.ReturnTree(from, leafs, dataTypes);

        }
        partial void Import(string filePath)
        {

            Match imports = TaskMethods.MatchRegex("data/" + filePath.ReturnFilePath(), RgxString.ImportsRGX);
            string toImport = imports.Value.Replace("IMPORTS", "").RemoveSpecialCharacter().RemoveSpaces();
            MatchCollection importData = TaskMethods.CollectionRegex(toImport, RgxString.ImportSortedRGX, false);
            foreach (Match itemm in importData)
            {
                //List<string> datatypesToImport= itemm.Groups[1].Value.RemoveSpecialCharacter().Split(',').T;
                string[] items = itemm.Groups[1].Value.RemoveSpecialCharacter().Split(',');
                string from = itemm.Groups[2].Value.RemoveSpecialCharacter();


                if (!importedFiles.Contains(from))
                {
                    ReturnAllTree(from);
                    Import(from);
                }

            }
        }
    }


}
