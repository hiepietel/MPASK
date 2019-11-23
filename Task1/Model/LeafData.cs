using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task1.Enums;

namespace Task1.Model
{
    public class LeafData
    {
        /// <summary>
        /// DisplayString
        /// </summary>
        public string Syntax { get; set; }
        /// <summary>
        ///  (SIZE (0..255))
        /// </summary>
        public string Restrictions { get; set; }
        /// <summary>
        ///  read-only
        /// </summary>
        public ACCESS Access { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public STATUS Status { get; set; }
        /// <summary>
        /// mandatory
        /// </summary>
        public string Description { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string[] Index { get; set; }
            
    }
}
