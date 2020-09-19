using System.Linq;

namespace Fraudulent
{
    public static class ArrayCountSortSolution
    {
        public static int ActivityNotifications(int[] expenditure, int d)
        {
            var notifications = 0;

            var countSortedArr = new int[201];

            for (int i = 0; i < d; i++) 
            {
                countSortedArr[expenditure[i]]++;
            }

            for (int i = d; i < expenditure.Length; i++) 
            {
                double median = Median(countSortedArr, d);

                if (expenditure[i] >= 2 * median) {
                    notifications++;

                }

                countSortedArr[expenditure[i]]++;
                countSortedArr[expenditure[i - d]]--;
            }

            return notifications;
        }

        public static double Median(int[] arr, int d)
        {
            double median = 0;

            if (d % 2 == 0) 
            {
                var m1 = -1;
                var m2 = -1;
                var count = 0;

                for (int j = 0; j < arr.Length; j++) 
                {
                    count += arr[j];

                    if (m1 == -1 && count >= d/2) 
                    {
                        m1 = j;
                    }
                    if (m2 == -1 && count >= d/2 + 1) 
                    {
                        m2 = j;
                        break;
                    }
                }
                median = (m1 + m2) / 2.0;
            }
            else 
            {
                int count = 0;
                for (int j = 0; j < arr.Length; j++) {
                    count += arr[j];
                    if (count > d/2) {
                        median = j;
                        break;
                    }
                }
            }

            return median;
        }
    }
}