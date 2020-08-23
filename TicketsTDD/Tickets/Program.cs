using System;
using System.Threading.Tasks;
using Tickets.Data;

namespace Tickets
{
    class Program
    {
        static async Task Main(string[] args)
        {
            // string path = "Data/Sample.txt";
            // string path2 = "Data/Sample2.txt";
            string path3 = "Data/Sample3.txt";

            var ticketsData = await ReadDataFromFile.GetData(path3);

            var output = App2.PriceCalculation(ticketsData);

            Console.WriteLine("************* RESULTS **************");
            Console.WriteLine("Total Price: " + output.TotalPrice);
            Console.Write("Windows: ");
            foreach(var w in output.Windows)
            {
                Console.Write(w + " ");
            }
            Console.WriteLine();
        }
    }
}
