using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task3
{
    public static class TestFrames
    {
        /// <summary>
        ///  OID: 1.3.6.1.2.1.2.2.1.1
        ///  Value (Integer32): 1
        /// </summary>
        public static string Frame
        {
            //snmpset -v 1 -c public localhost ifEntry.1 i 1
            get
            {
                return "02 00 00 00 45 00 00 47 93 53 00 00 80 11 00 00" //0000
                      + "7f 00 00 01 7f 00 00 01 e0 b6 00 a1 00 33 4e 3e" //0010
                      + "30 29 02 01 00 04 06 70 75 62 6c 69 63 a3 1c 02" //0020
                      + "02 45 fd 02 01 00 02 01 00 30 10 30 0e 06 09 2b" //0030
                      + "06 01 02 01 02 02 01 01 02 01 01"; //0040
                ;
            }
        }
        /// <summary>
        ///  OID: 1.3.6.1.2.1.2.2.1.2
        ///  Value (OctetString): 68696570696574656c
        /// </summary>
        public static string Frame_hiepietel
        {
            //snmpset -v 1 -c public localhost ifEntry.2 s hiepietel
            get
            {
                return "02 00 00 00 45 00 00 4f 23 4b 00 00 80 11 00 00" //0000
                      + "7f 00 00 01 7f 00 00 01 eb 52 00 a1 00 3b 3d 07" //0010
                      + "30 31 02 01 00 04 06 70 75 62 6c 69 63 a3 24 02" //0020
                      + "02 1a d3 02 01 00 02 01 00 30 18 30 16 06 09 2b" //0030
                      + "06 01 02 01 02 02 01 02 04 09 68 69 65 70 69 65" //0040
                      + "74 65 6c" //0050
                ;
            }
        }
        /// <summary>
        ///  OID: 1.3.6.1.2.1.2.2.1.9
        ///  Value (Timeticks): 123
        /// </summary>
        public static string Frame_timeticks
        {
            //snmpset -v 1 -c public localhost ifEntry.9 t 123
            get
            {
                return "02 00 00 00 45 00 00 47 33 68 00 00 80 11 00 00" //0000
                      + "7f 00 00 01 7f 00 00 01 e6 d0 00 a1 00 33 2e fd" //0010
                      + "30 29 02 01 00 04 06 70 75 62 6c 69 63 a3 1c 02" //0020
                      + "02 64 5b 02 01 00 02 01 00 30 10 30 0e 06 09 2b" //0030
                      + "06 01 02 01 02 02 01 09 43 01 7b"; //0040
                     
                ;
            }
        }
    }
    public class FrameReader
    {
        public string Loopback { get; set; }
        public string InternetProtocol { get; set; }
        public string UserDiagramProtocol { get; set; }
        public SimpleNetworkProtocol SNProtocol { get; set; }

    }
    public class SimpleNetworkProtocol
    {
        public string Version { get; set; }
        public string Community { get; set; }
        public string RequestId { get; set; }
        public string ErrorStatus { get; set; }
        public string ErrorIndex { get; set; }
        public string VariableBindings { get; set; }
        public Dictionary<string, string> Data;
    }
    public static class Decoder
    {
        public static SimpleNetworkProtocol CreateSimpleNetworkProtocol(string code)
        {
            int startSNP = 32;
            string[] datas = code.Split(' ');

            string version = datas[startSNP + 4];
            string community = "";
            string requestId = "";
            for (int i = startSNP+ 7; i < startSNP + 7+ 6 ; i++)
            {
                community += datas[i];
            }
            for (int i = 54; i < 58; i++)
            {
                requestId += datas[i];
            }
            string errorStatus = datas[56];
            string errorIndex = datas[59];
            //VariableBindings
            string variableBindings = "";
            bool endOfCode = true;
            int startIndex = 46;
            while (endOfCode)
            {
                try
                {
                    variableBindings += datas[startIndex];
                    startIndex++;
                }
                catch(Exception ex)
                {
                    endOfCode = false;
                }
            }
            SimpleNetworkProtocol simpleNetworkProtocol = new SimpleNetworkProtocol()
            {
                Community = community,
                RequestId = requestId,
                ErrorIndex = errorIndex,
                ErrorStatus = errorStatus,
                VariableBindings = variableBindings
            };
            return simpleNetworkProtocol;


        }
        public static FrameReader CreateFrameReader(string code)
        {
            string loopback = "";
            string internetprotocol = "";
            string userdiagramprotocol = "";
            string[] datas = code.Split(' ');
            
            for (int i = 0; i < 4; i++)
            {
                loopback += datas[i];
            }
            for (int i = 4; i < 24; i++)
            {
                internetprotocol += datas[i];
            }
            for (int i = 24; i < 32; i++)
            {
                userdiagramprotocol += datas[i];
            }
            

            var frameReader = new FrameReader()
            {
                Loopback = loopback,
                InternetProtocol = internetprotocol,
                UserDiagramProtocol = userdiagramprotocol
            };
            frameReader.SNProtocol = CreateNetworkProtocol(code);
            return frameReader;

        }
    }
    class Program
    {
        public static void Decode(string frame)
        {

        }
        static void Main(string[] args)
        {
        }
    }
}
