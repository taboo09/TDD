using System;

namespace TDDapp
{
    class Program
    {
        static void Main(string[] args)
        {            
            var result = ArrayCircularRotation.ArrayRotation(new int[] {1, 2, 3, 4, 5}, 2, new int[] {2, 3, 4});

            foreach (var item in result)
            {
                Console.WriteLine(item);
            }
            
        }
    }
}
