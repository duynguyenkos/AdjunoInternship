using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTOs
{
    public class GetSearchItemDTO
    {
        public IEnumerable<string> Origins { get; set; }
        public IEnumerable<string> OriginPorts { get; set; }
        public IEnumerable<string> Factories { get; set; }
        public IEnumerable<string> Suppliers { get; set; }
        public IEnumerable<string> Status { get; set; }
        public IEnumerable<string> Depts { get; set; }

    }
}
