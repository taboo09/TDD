using System;

namespace Fraudulent
{
    public class Client
    {
        public static int ActivityNotifications(int[] expenditure, int d)
        {
            var notifications = 0;

            for (int i = 0; i < expenditure.Length - d; i++)
            {
                var subArr = new int[d];

                Array.Copy(expenditure, i, subArr, 0, d);

                var test = Median(subArr);
                if ((int)(Median(subArr) * 2) <= expenditure[d + i]) notifications++;
            }

            return notifications;
        }

        // get median of array, the middle number of the average of the 2 number in the middle
        // array needs to be sort
        public static double Median(int[] arr)
        {
            var index = arr.Length / 2;
            var even = true;

            if (arr.Length % 2 == 1)
            {
                even = false;
                index = (arr.Length - 1) / 2;
            }

            for (int k = 1; k <= index + 1; k++)
            {
                var arr_sorted = false;

                for (int i = 0; i < arr.Length - k; i++)
                {
                    if (arr[i] > arr[i + 1])
                    {
                        var temp = arr[i];
                        arr[i] = arr[i + 1];
                        arr[i + 1] = temp;

                        arr_sorted = true;
                    }
                }

                if (!arr_sorted) break;
            }

            if (even) return ((double)arr[index - 1] + (double)arr[index]) / 2;

            return (double)arr[index];
        }
    }
}