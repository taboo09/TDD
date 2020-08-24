using System;
using System.Linq;

namespace MaxMin
{
    public class App
    {
        public static int MaxMinCalc(int[] subArr)
        {
            var max = subArr.Max();
            var min = subArr.Min();

            return max - min;
        }

        public static int[] GetSubArr(int[] arr, int k)
        {
            if (arr.Length == k) return arr;

            // order arr
            Array.Sort(arr);

            var index = 0;
            var k_index = 0;
            var maxMinCalcValue = Int64.MaxValue;

            while (k_index <= arr.Length - k)
            {
                var subArrTemp = new int[k];

                Array.Copy(arr, k_index, subArrTemp, 0, k);

                var maxMinCalc = MaxMinCalc(subArrTemp);

                if (maxMinCalc < maxMinCalcValue)
                {
                    maxMinCalcValue = maxMinCalc;
                    index = k_index;
                }

                k_index++;

                if(maxMinCalcValue == 0) return subArrTemp;
            }

            var subArr = new int[k];

            Array.Copy(arr, index, subArr, 0, k);

            return subArr;
        }
    }
}