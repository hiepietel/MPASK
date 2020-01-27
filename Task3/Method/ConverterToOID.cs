using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task3.Method
{
    public static class ConverterToOID
    {
        public static string ToOID(string hexOID)
        {
            string OID = "";
            //TODO first two oid
            string temp = hexOID.ElementAt(0).ToString() + hexOID.ElementAt(1).ToString();
            int num = int.Parse(temp, System.Globalization.NumberStyles.HexNumber);
            int firstElement = 0;
            int secondElement = 0;
            //if (num % 40 != 0) secondElement++;
            while (num % 40 != 0)
            {
                secondElement++;
                num --;
            }
            firstElement = num/40;
            
            OID += firstElement.ToString()+"."+secondElement.ToString()+".";
            
            
            for(int i=2; i<hexOID.Length; i += 2)
            {
                temp = hexOID.ElementAt(i).ToString()+ hexOID.ElementAt(i+1).ToString();
                num = int.Parse(temp, System.Globalization.NumberStyles.HexNumber);
                OID += num.ToString() + ".";
            }
            OID = OID.Remove(OID.LastIndexOf('.'), 1);
            return OID;
        }

        
    }
}
