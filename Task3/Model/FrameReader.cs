using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task3.Model;

namespace Task3.Model
{
    public class FrameReader
    {
        public string Loopback { get; set; }
        public string InternetProtocol { get; set; }
        public string UserDiagramProtocol { get; set; }
        public SimpleNetworkProtocol SNProtocol { get; set; }

    }
}
