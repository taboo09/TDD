using System.Collections.Generic;

namespace Tickets.Models
{
    public class OutputData
    {
        public decimal TotalPrice { get; set; }
        public List<int> Windows { get; set; }
    }
}