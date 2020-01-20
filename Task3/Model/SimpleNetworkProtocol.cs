using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task3.Model
{
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
}
