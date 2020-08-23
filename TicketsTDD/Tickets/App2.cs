using System;
using System.Collections.Generic;
using Tickets.Models;

namespace Tickets
{
    public class App2
    {
        public static OutputData PriceCalculation(TicketsData ticketData)
        {
            var output = new OutputData();

            decimal totalPrice = 0M;

            // records last dest per windows
            var windowLastDest = InitializeList(new List<string>(), ticketData.Windows, "None");

            // records the window number per customers
            var windows = new List<int>();

            // holds new M (windows ticket number) customer dest
            var nextDestinations = new List<string>();

            if (ticketData.People >= ticketData.Windows)
            {
                for (int i = 0; i < ticketData.Windows; i++)
                {
                    nextDestinations.Add(ticketData.PersonDestinations.Dequeue());
                }
            }
            else
            {
                for (int i = 0; i < ticketData.People; i++)
                {
                    nextDestinations.Add(ticketData.PersonDestinations.Dequeue());
                }
            }

           while (nextDestinations.Count > 0)
           {
               // find if dest has been used before
               var index = windowLastDest.IndexOf(nextDestinations[0]);

                if ( index > -1)
                {
                    windows.Add(index + 1);

                    totalPrice = totalPrice + Convert.ToDecimal(
                        ticketData.Destinations[nextDestinations[0]] - 
                        (ticketData.Destinations[nextDestinations[0]] * 0.2));
                }
                else
                {
                    // check if next dests have a match in windowLastDest list
                    var availableIndex = AssignDestination(windowLastDest, nextDestinations);
                    windows.Add(availableIndex + 1);

                    totalPrice = totalPrice + ticketData.Destinations[nextDestinations[0]];
                }

                // remove first element from temp dest list
                nextDestinations.RemoveAt(0);

                // remove first element from queue and add it to list if exists
                if (ticketData.PersonDestinations.Count > 0) nextDestinations.Add(ticketData.PersonDestinations.Dequeue());
           }

            output.Windows = windows;
            output.TotalPrice = totalPrice;

            return output;
        }

        private static int AssignDestination(List<string> prevDests, List<string> nextDests)
        {
            // find an unused ticket window or go to 1st one
            var index = prevDests.FindIndex(x => x == "None");

            if (index > -1) 
            {
                prevDests[index] = nextDests[0];
                
                return index;
            }
            else
            {
                var unavailableIndexes = GetUnavailableIndexes(prevDests, nextDests);
            
                for (int i = 0; i < prevDests.Count; i++)
                {
                    if (!unavailableIndexes.Contains(i)) return i;
                }
            }

            return 0;
        }

        private static List<int> GetUnavailableIndexes(List<string> prevDests, List<string> nextDests)
        {
            var unavailableIndexes = new List<int>();

            for (int i = 1; i < nextDests.Count; i++)
            {
                var prevDestIndex = prevDests.IndexOf(nextDests[i]);
                if (prevDestIndex > -1) unavailableIndexes.Add(prevDestIndex);
            }

            return unavailableIndexes;
        }

        private static List<string> InitializeList(List<string> list, int count, string value)
        {
            for (int i = 0; i < count; i++)
            {
                list.Add(value);
            }

            return list;
        }
    }
}