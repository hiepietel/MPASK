using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task1.Enums;
using Enums;
using Type = Enums.Type;

namespace Task1.Model
{
    public class DataType
    {
        public int Id { get; set; }
        /// <summary>
        /// e.g IpAddress
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// e.g APPLICATION
        /// </summary>
        public Type Type { get; set; }
        public int TypeIndex { get; set; }
        /// <summary>
        /// IMPLICIT
        /// </summary>
        public Visibility Visibility { get; set; }
        /// <summary>
        /// INTEGER
        /// </summary>
        public DATATYPE Datatype { get; set; }
        /// <summary>
        /// e.g(0..4294967295)
        /// </summary>
        public string Size { get; set; }
    }
}
