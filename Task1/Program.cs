using Model.Task1;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text.RegularExpressions;
using Task1;

class Program
{
    /// <summary>
    /// \w*\s*OBJECT-TYPE\s*SYNTAX.*\s*ACCESS.*\s*STATUS.*\s*DESCRIPTION\s*.* - dziala do desc
    /// </summary>

    static string rgx = "\\w*\\s*OBJECT-TYPE\\s*SYNTAX.*?ACCESS.*?STATUS.*?DESCRIPTION\\s*\".*?\"\\s*::=\\s*{.*?}";
    static string rgxPro = "(?<name>\\w*)\\s*OBJECT-TYPE\\s*SYNTAX(?<syntax>.*?)ACCESS(?<access>.*?)STATUS(?<status>.*?)DESCRIPTION\\s*\"(?<description>.*?)\"\\s*::=\\s*{.*?}";
    static string dataTypeRGX = "\\w*\\s*::=\\s*\\[\\s*\\w*\\s*(?<typeID>\\d+)\\s*\\]\\s*\\w+\\s+(?<parentType>\\w+\\s*\\w*)\\s* (?<restrictions>\\(?.*?\\)\\)?)";


    static string objectTypeRgx = "";
    static void Main()
    {

        MatchCollection matchesData = Regex.Matches(TaskMethods.ReadFile("data/FC1155SMI.txt"), dataTypeRGX, RegexOptions.Singleline | RegexOptions.Compiled | RegexOptions.CultureInvariant);

        MatchCollection matches = Regex.Matches(TaskMethods.ReadFile("data/MIB.txt"), rgxPro, RegexOptions.Singleline | RegexOptions.Compiled | RegexOptions.CultureInvariant);


        List <Leaf> listOfLeafs = new List<Leaf>();
        
        
        foreach (Match match in matches)
        {
            string name = match.Groups[1].Value.Trim().Replace("\r", "").Replace("\n", "");

            string syntax = match.Groups[2].Value.Trim().Replace("\r", "").Replace("\n", "");
            string access = match.Groups[3].Value.Trim().Replace("\r", "").Replace("\n", "");
            string status = match.Groups[4].Value.Trim().Replace("\r", "").Replace("\n", "");
            
            //Descirption
            string desc = match.Groups[5].Value.Trim().Replace("\r", "").Replace("\n", "");
            do
            {
                desc = desc.Replace("  ", " ");

            } while (desc.Contains("  "));



            Leaf leaf = new Leaf()
            {
                ObjectType = name,
                Status = TaskMethods.ToStatus(status),
                Access = TaskMethods.ToAccess(access),
                Description = desc
                
            };
            listOfLeafs.Add(leaf);
            //{
            //    leafData = leafData.Replace("  ", " ");
            //}
            


            //for (int i = 1; i < match.Groups.Count; i++)
            //{
            //    Console.WriteLine(match.Groups[i].Value.Trim().Replace("\r", "").Replace("\n", ""));
            //}

            //{

            //}

            //string leafData = match.Value.Trim().Replace("\r", "").Replace("\n", "");
            //while(leafData.Contains("  "))
            //{
            //    leafData = leafData.Replace("  ", " ");
            //}
            //int objectEnd = leafData.IndexOf("OBJECT-TYPE");
            //string objecttype = leafData.Substring(0, leafData.IndexOf("OBJECT-TYPE")).Trim();
            //leafData = leafData.Remove(0, leafData.IndexOf("SYNTAX");
            //int syntaxPos = leafData.IndexOf("SYNTAX".Length + "SYNTAX".Length;
            //string syntax = leafData.Substring(syntaxPos, leafData.IndexOf("STATUS")-syntaxPos);



        }

        Console.ReadKey();
    }
}