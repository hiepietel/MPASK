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
        public static VariableBinding CreateVariableBindings(string[] datas )
        {
            //0-1 pierwsze pominac
            //2 - tag OID
            //3 - (x) length OIDa
            //4-x OID
            // tag zapisanej wartosci
            // length zapisanej wielkoscie
            //zapisana wartosc
            string tagOID = datas[2];
            string lengthOID = datas[3];
            int lengthCountOID = int.Parse(lengthOID, System.Globalization.NumberStyles.HexNumber);
            int startOID = 4;
            string OIDhex = "";
            for (int i = startOID; i < startOID+lengthCountOID; i++)
            {
                OIDhex += datas[i];
            }
            int startData = startOID + lengthCountOID;
            string tagDATA = datas[startData];
            string lengthDATA = datas[startData + 1];
            int lengthCountDATA = int.Parse(lengthDATA, System.Globalization.NumberStyles.HexNumber);
            string OIDdata = "";
            for (int i = startData + 2; i < startData + 2 + lengthCountDATA; i++)
            {
                OIDdata += datas[i];
            }
            VariableBinding variableBinding = new VariableBinding()
            {
                TagOID = tagOID,
                LengthOID = lengthOID,
                OID = OIDhex,
                TagData = tagDATA,
                LengthData = lengthDATA,
                Data = OIDdata
            };
            return variableBinding;
        }

        public static SimpleNetworkProtocol CreateSimpleNetworkProtocol(string[] datas)
        {

            int startSNP = 32;

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
                    variableBindings += datas[startIndex] +" ";
                    startIndex++;
                }
                catch (Exception ex)
                {
                    endOfCode = false;
                }
            }
            variableBindings = variableBindings.TrimEnd();
            string[] variableBindingsDatas = variableBindings.Split(' ');
            VariableBinding variableBinding = CreateVariableBindings(variableBindings.Split(' '));
            SimpleNetworkProtocol simpleNetworkProtocol = new SimpleNetworkProtocol()
            {
                Version = version,
                Community = community,
                RequestId = requestId,
                ErrorIndex = errorIndex,
                ErrorStatus = errorStatus,
                VariableBindings = variableBinding

            };
            return simpleNetworkProtocol;


        }
        public static FrameReader CreateFrameReader(string[] datas)
        {
            string loopback = "";
            string internetprotocol = "";
            string userdiagramprotocol = "";

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
            frameReader.SNProtocol = CreateSimpleNetworkProtocol(datas);
            return frameReader;

        }
        public static FrameReader Decode(string code)
        {
            string[] datas = code.Split(' ');
            if (ValidateInput(datas))
            {
                FrameReader frameReader=  CreateFrameReader(datas);
                ConsoleInfo.DecodedFrame(frameReader);
                return frameReader;
            }
            return null;

        }
        public static bool ValidateInput(string[] datas)
        {
            
            foreach(string data in datas)
            {
                if (data.Length != 2) return false;
            }
            return true;
        }
    }
}
