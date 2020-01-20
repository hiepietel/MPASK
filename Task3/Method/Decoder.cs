using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task3.Model;

namespace Task3.Method
{
    public static class Decoder
    {
        //TODO CreateVariableBindings
       
        public static SimpleNetworkProtocol CreateSimpleNetworkProtocol(string code)
        {
            int startSNP = 32;
            string[] datas = code.Split(' ');

            string version = datas[startSNP + 4];
            string community = "";
            string requestId = "";
            for (int i = startSNP + 7; i < startSNP + 7 + 6; i++)
            {
                community += datas[i];
            }
            for (int i = 54; i < 58; i++)
            {
                requestId += datas[i];
            }
            string errorStatus = datas[53];
            string errorIndex = datas[56];
            //VariableBindings
            string variableBindings = "";
            bool endOfCode = true;
            int startIndex = 59;
            while (endOfCode)
            {
                try
                {
                    variableBindings += datas[startIndex];
                    startIndex++;
                }
                catch (Exception ex)
                {
                    endOfCode = false;
                }
            }
            SimpleNetworkProtocol simpleNetworkProtocol = new SimpleNetworkProtocol()
            {
                Version =version,
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
            frameReader.SNProtocol = CreateSimpleNetworkProtocol(code);
            return frameReader;

        }
        //TODO  Validate Input 
        public static bool ValidateInput(string code)
        {

            return true;
        }
    }
}
