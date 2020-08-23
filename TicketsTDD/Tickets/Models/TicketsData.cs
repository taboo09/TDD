using System.Collections.Generic;

namespace Tickets.Models
{
    public class TicketsData
    {
        public TicketsData()
        {
            Destinations = new Dictionary<string, int>();
            PersonDestinations = new Queue<string>();
        }
        
        public int People { get; set; }
        public Dictionary<string, int> Destinations { get; internal set; }
        public int Windows { get; set; }
        public Queue<string> PersonDestinations { get; internal set; }
    }
}