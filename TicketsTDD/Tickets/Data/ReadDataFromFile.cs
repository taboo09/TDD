using System;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using Tickets.Models;

namespace Tickets.Data
{
    public class ReadDataFromFile
    {
        public static async Task<TicketsData> GetData(string path)
        {
            var ticketsData = new TicketsData();

            var fileStream = new FileStream(path, FileMode.Open, FileAccess.Read);
            using (var streamReader = new StreamReader(fileStream,  Encoding.UTF8))
            {
                string line;
                line = await streamReader.ReadLineAsync();

                ticketsData.People = Convert.ToInt32(line.Split(" ")[0]);
                ticketsData.Windows = Convert.ToInt32(line.Split(" ")[1]);

                var destinations = Convert.ToInt32(line.Split(" ")[2]);

                for(var i = 0; i < destinations; i++)
                {
                    line = await streamReader.ReadLineAsync();
                    ticketsData.Destinations.Add(line.Split(" ")[0], Convert.ToInt32(line.Split(" ")[1]));
                }

                for(var i = 0; i < ticketsData.People; i++)
                {
                    line = await streamReader.ReadLineAsync();
                    ticketsData.PersonDestinations.Enqueue(line);
                }
            }

            return ticketsData;
        }
    }
}