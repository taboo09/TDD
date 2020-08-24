using System;

namespace MaxMin
{
    class Program
    {
        static void Main(string[] args)
        {
            var arr = new int[] { 10, 100, 300, 200, 1000, 20, 30 };
            var k = 3;

            var expexted = App.GetSubArr(arr, k);

            foreach(var item in expexted)
            {
                Console.Write(item + " ");
            }
        }
    }
}
