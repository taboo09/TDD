using System;
using System.Collections.Generic;
using Tickets.Models;

namespace Tickets
{
    public class App
    {
        public static OutputData PriceCalculation(TicketsData ticketData)
        {
            var output = new OutputData();

            decimal totalPrice = 0M;

            // records last dest per windows
            var windowLastDest = InitializeList(new List<string>(), ticketData.Windows, "None");

            // records the window number per customers
            var windows = new List<int>();

            for (int i = 0; i < ticketData.People; i++)
            {
                var personDestination = ticketData.PersonDestinations.Dequeue();
                var index = windowLastDest.IndexOf(personDestination);

                if ( index > -1)
                {
                    // destination has been previously used
                    windows.Add(index + 1);
                    totalPrice = totalPrice + Convert.ToDecimal(
                        ticketData.Destinations[personDestination] - 
                        (ticketData.Destinations[personDestination] * 0.2)
                    );
                }
                else 
                {
                    // assign new dest to an empty item or to the first one
                    AssignDestination(windowLastDest, personDestination, windows);
                    totalPrice = totalPrice + ticketData.Destinations[personDestination];
                }
            }

            output.Windows = windows;
            output.TotalPrice = totalPrice;

            return output;
        }

        private static void AssignDestination(List<string> previousDestinations, string destination, List<int> windows)
        {
            // find an unused ticket window or go to 1st one
            var index = previousDestinations.FindIndex(x => x == "None");

            if (index > -1) 
            {
                previousDestinations[index] = destination;
                windows.Add(index + 1);
            }
            else 
            {
                previousDestinations[0] = destination;
                windows.Add(1);
            }
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