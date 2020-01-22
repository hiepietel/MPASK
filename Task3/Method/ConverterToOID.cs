using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task3.Method
{
    public class ConverterToOID
    {
        public string ToOID(string hexOID)
        {
            //TODO first two oid
            
            string OID = "";
            for(int i=2; i<hexOID.Length; i += 2)
            {
                string temp = hexOID.ElementAt(i).ToString()+ hexOID.ElementAt(i+1).ToString();
                int num = int.Parse(temp, System.Globalization.NumberStyles.HexNumber);
                OID += num.ToString() + ".";
            }
            OID = OID.Remove(OID.LastIndexOf('.'), 1);
            return OID;
        }
    }
}
