using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BAIST3150ConsoleAppWepApi.Domain
{
    internal class Item
    {
        public int ItemNumber { get; set; }
        public string Description { get; set; } = string.Empty;
        public decimal UnitPrice { get; set; }
        
    }
}
