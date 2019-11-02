using System;
using System.IO;
using System.Text.RegularExpressions;


public enum SYNTAX
{
    
}
public enum ACCESS
{
    read_only, read_write, not_accessible,
}
public enum STATUS
{
    mandatory, deprecated
}
public class Leaf
{
    public int Id { get; set; }
    public int ParentId { get; set; }

    public string ObjectType { get; set; }
    public string Description { get; set; }
    public ACCESS Access { get; set; }
    public STATUS Status { get; set; }


}
class Program
{
    /// <summary>
    /// \w*\s*OBJECT-TYPE\s*SYNTAX.*\s*ACCESS.*\s*STATUS.*\s*DESCRIPTION\s*.* - dziala do desc
    /// </summary>

    static string rgx = "\\w*\\s*OBJECT-TYPE\\s*SYNTAX.*?ACCESS.*?STATUS.*?DESCRIPTION\\s*\".*?\"\\s*::=\\s*{.*?}";
    static string rgxPro = "(?<name>\\w*)\\s*OBJECT-TYPE\\s*SYNTAX(?<syntax>.*?)ACCESS(?<access>.*?)STATUS(?<status>.*?)DESCRIPTION\\s*\"(?<description>.*?)\"\\s*::=\\s*{.*?}";

static string objectTypeRgx = "";
    static void Main()
    {
        string input = "";
        try
        {   
            using (StreamReader sr = new StreamReader("data/MIBshort.txt"))
            {
                input = sr.ReadToEnd();
                //Console.WriteLine(line);
            }
        }
        catch (IOException e)
        {
            Console.WriteLine("The file could not be read:");
            Console.WriteLine(e.Message);
        }

        MatchCollection matches = Regex.Matches(input, rgxPro, RegexOptions.Singleline | RegexOptions.Compiled | RegexOptions.CultureInvariant);

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
            
            
            {
                leafData = leafData.Replace("  ", " ");
            }
            


            for (int i = 1; i < match.Groups.Count; i++)
            {
                Console.WriteLine(match.Groups[i].Value.Trim().Replace("\r", "").Replace("\n", ""));
            }

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