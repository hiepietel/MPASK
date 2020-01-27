using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task3.Model;

namespace Task3.Method
{
    public static class ConsoleInfo
    {
        static void ColorWriteline(string name, string data, ConsoleColor consoleColor, bool newLine = true, int space = 0)
        {
            if(space > 0)
            {
                for (int i = 0; i < space; i++)
                {
                    Console.Write(" ");
                }
            }
            Console.Write(name+": ");
            Console.ForegroundColor = consoleColor;
            if (newLine)
            {
                Console.WriteLine(data);
                Console.ForegroundColor = ConsoleColor.White;
            }
            else
            {
                Console.Write(data);
                Console.ForegroundColor = ConsoleColor.White;
                Console.Write(" | ");
            }
            
        }
        public static void Dots(int howMany = 100)
        {
            Console.WriteLine("");
            Random rnd = new Random();
            for (int i = 0; i < howMany; i++)
            {
                Console.ForegroundColor = (ConsoleColor)rnd.Next(2, 14);
                Console.Write("*");
            }
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("");
        }
        public static void AnalyzedVariableBindings(AnalyzedVB analyzedVB)
        {
            Console.WriteLine("Analyzed:");
            ColorWriteline("Tag", analyzedVB.TagOID.ToString(), ConsoleColor.DarkMagenta, false, space: 6);
            ColorWriteline("Length", analyzedVB.LengthOID.ToString(), ConsoleColor.DarkMagenta, false);
            ColorWriteline("OID", analyzedVB.OID, ConsoleColor.DarkMagenta);
            ColorWriteline("Tag", analyzedVB.TagData.ToString(), ConsoleColor.DarkMagenta, false, space: 6);
            ColorWriteline("Length", analyzedVB.LengthData.ToString(), ConsoleColor.DarkMagenta, false);
            ColorWriteline("Data", analyzedVB.Data, ConsoleColor.DarkMagenta);
        }
        public static void InproperDataToDecode()
        {
            Console.WriteLine("CANNOT DECODE");
        }
        public static void DecodedFrame(FrameReader frameReader)
        {
            ColorWriteline("Loopback", frameReader.Loopback, ConsoleColor.Cyan);
            ColorWriteline("InternetProtocol",frameReader.InternetProtocol, ConsoleColor.Cyan);
            ColorWriteline("UserDiagramProtocol",frameReader.UserDiagramProtocol, ConsoleColor.Cyan);
            DecodedSNMP(frameReader.SNProtocol);
        }
        static void DecodedSNMP(SimpleNetworkProtocol simpleNetworkProtocol)
        {
            ColorWriteline("version",simpleNetworkProtocol.Version, ConsoleColor.Cyan, space:3);
            ColorWriteline("community",simpleNetworkProtocol.Community, ConsoleColor.Cyan, space:3);
            ColorWriteline("requestid", simpleNetworkProtocol.RequestId, ConsoleColor.Cyan, space:3);
            ColorWriteline("error-status", simpleNetworkProtocol.ErrorStatus, ConsoleColor.Cyan, space:3);
            ColorWriteline("error-index", simpleNetworkProtocol.ErrorIndex, ConsoleColor.Cyan, space:3);
            DecodedVariableBinding(simpleNetworkProtocol.VariableBindings);
        }
        static void DecodedVariableBinding(VariableBinding variableBinding)
        {
            ColorWriteline("Tag", variableBinding.TagOID, ConsoleColor.Magenta, false, space:6);
            ColorWriteline("Length",variableBinding.LengthOID, ConsoleColor.Magenta, false);
            ColorWriteline("OID",variableBinding.OID, ConsoleColor.Magenta);
            ColorWriteline("Tag",variableBinding.TagData, ConsoleColor.Magenta, false, space:6);
            ColorWriteline("Length",variableBinding.LengthData, ConsoleColor.Magenta, false);
            ColorWriteline("Data",variableBinding.Data,ConsoleColor.Magenta);
        }
    }
}
