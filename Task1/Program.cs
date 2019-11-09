using Model.Task1;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text.RegularExpressions;
using Task1;
using Task1.Method;
using Task1.Model;

class Program
{
    /// <summary>
    /// \w*\s*OBJECT-TYPE\s*SYNTAX.*\s*ACCESS.*\s*STATUS.*\s*DESCRIPTION\s*.* - dziala do desc
    /// </summary>

    static string rgx = "\\w*\\s*OBJECT-TYPE\\s*SYNTAX.*?ACCESS.*?STATUS.*?DESCRIPTION\\s*\".*?\"\\s*::=\\s*{.*?}";
    static string rgxPro = "(?<name>\\w*)\\s*OBJECT-TYPE\\s*SYNTAX(?<syntax>.*?)ACCESS(?<access>.*?)STATUS(?<status>.*?)DESCRIPTION\\s*\"(?<description>.*?)\"\\s*::=\\s*{.*?}";
    static string dataTypeRGX = "\\w*\\s*::=\\s*\\[\\s*\\w*\\s*(?<typeID>\\d+)\\s*\\]\\s*\\w+\\s+(?<parentType>\\w+\\s*\\w*)\\s* (?<restrictions>\\(?.*?\\)\\)?)";
    // static string dataTypeRGXwithName = (?< NAME >\w*\s*)::=\s*\[\s*\w*\s*(?<typeID>\d+)\s*\]\s*\w+\s+(?<parentType>\w+\s*\w*)\s* (?<restrictions>\(?.*?\)\)?)
    //static string dataTypeRGXverOne = "(?<TypeName>\\w*\\s*)::=\\s*\\[\\s*\\w*\\s*(?<typeID>\\d+)\\s*\\]\\s* (?<typeTYPE>\\w+)\\s+(?<parentType>\\w+\\s*\\w*)\\s* (?<restrictions>\\(?.*?\\)\\)?)";
    static string dataTypeRGXverOne = "(?<TypeName>\\w*\\s*)::=\\s*\\[(?<APP>\\s*\\w*\\s*)(?<typeID>\\d+)\\s*\\]\\s*(?<typeTYPE>\\w+)\\s+(?<parentType>\\w+\\s*\\w*)\\s*(?<restrictions>\\(?.*?\\)\\)?)";
    static string objectTypeRgx = "";
    static List<Leaf> leafs = new List<Leaf>();

    static void Main()
    {
        InitTree();
        MatchCollection leafsRGX = Regex.Matches(TaskMethods.ReadFile("data/FC1155SMI.txt"), RegexString.DataRGX, RegexOptions.Singleline | RegexOptions.Compiled | RegexOptions.CultureInvariant);


        foreach (Match match in leafsRGX) {
            string name = match.Groups[1].Value.RemoveSpecialCharacter();
            string[] positions = match.Groups[2].Value.RemoveSpecialCharacter().Split(' '); ;

            string parentName = positions[0];
            Leaf parentLeaf = leafs.Find(x => x.Name == parentName);
            for (int i = 0; i < positions.Length - 1; i++)
            {
                parentLeaf = leafs.Find(x => x.Name == parentName);

            }
            string newNode = positions[positions.Length - 1];
            Leaf newLeaf = new Leaf()
            {
                Id = 0,
                Name = name,
                Index = Int32.Parse(positions[positions.Length - 1]),
                ParentName = parentLeaf.Name
                
            };
             
                                  
            foreach(string item in positions)
            {
                if(item.Contains("(") && item.Contains(")"))
                {

                }
                else
                {
                    var leaf = new Leaf()
                    {
                        Id = 0,
                        Name = name
                    };                 
                }
            }
            

        }


        MatchCollection matchesData = Regex.Matches(TaskMethods.ReadFile("data/FC1155SMI.txt"), dataTypeRGXverOne, RegexOptions.Singleline | RegexOptions.Compiled | RegexOptions.CultureInvariant);
        var dataTypes = new List<DataType>();
        foreach (Match match in matchesData)
        {
            string name = match.Groups[1].Value.RemoveSpecialCharacter();
            string type = match.Groups[2].Value.RemoveSpecialCharacter();
            string typeId = match.Groups[3].Value.RemoveSpecialCharacter();
            string visibility = match.Groups[4].Value.RemoveSpecialCharacter();
            string datatype = match.Groups[5].Value.RemoveSpecialCharacter();
            string size = match.Groups[6].Value.RemoveSpecialCharacter();

            var dataType = new DataType()
            {
                Id = 0,
                Name = name,
                Type = TaskMethods.ToType(type),
                TypeIndex = int.Parse(typeId),
                Visibility = TaskMethods.ToVisibility(visibility),
                Datatype = TaskMethods.ToDatatype(datatype),
                Size = size
                //Visibility = TaskMethods.ToVisibility(typeName),
                //Keyword = TaskMethods.ToKeyword(visibility)
            };
            dataTypes.Add(dataType);

        }
        MatchCollection matches = Regex.Matches(TaskMethods.ReadFile("data/MIB.txt"), rgxPro, RegexOptions.Singleline | RegexOptions.Compiled | RegexOptions.CultureInvariant);


        List <LeafData> listOfLeafs = new List<LeafData>();
        
        
        foreach (Match match in matches)
        {
            string name = match.Groups[1].Value.RemoveSpecialCharacter();
            string syntax = match.Groups[2].Value.RemoveSpecialCharacter();
            string access = match.Groups[3].Value.RemoveSpecialCharacter();
            string status = match.Groups[4].Value.RemoveSpecialCharacter();

            //Descirption
            string desc = match.Groups[5].Value.RemoveSpecialCharacter();
            do
            {
                desc = desc.Replace("  ", " ");

            } while (desc.Contains("  "));

            LeafData leaf = new LeafData()
            {
                ObjectType = name,
                Status = TaskMethods.ToStatus(status),
                Access = TaskMethods.ToAccess(access),
                Description = desc
                
            };
            listOfLeafs.Add(leaf);



        }

        Console.ReadKey();
    }
    static void InitTree()
    {
        Leaf RootNode = new Leaf()
        {
            Id = 0,
            Name = "Root-Node",
            ParentName = "null",
            Index = 0
        };
        leafs.Add(RootNode);
        Leaf ccitt = new Leaf()
        {
            Id = 1,
            Name = "ccitt",
            ParentName = "Root-Node",
            Index = 0
        };
        leafs.Add(ccitt);
        Leaf iso = new Leaf()
        {
            Id = 2,
            Name = "iso",
            ParentName = "Root-Node",
            Index = 1
        };
        leafs.Add(iso);

    }
}