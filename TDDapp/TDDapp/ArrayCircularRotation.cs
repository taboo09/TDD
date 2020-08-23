using System;

namespace TDDapp
{
    public static class ArrayCircularRotation
    {
        // public static int[] ArrayRotation(int[] a, int k, int[] q)
        // {
        //     if((k >= a.Length) && (k % a.Length == 0)) k = 1;
        //     else if(k > a.Length) k = k % a.Length;

        //     int[] result = new int[q.Length];

        //     for(var i = 0; i < q.Length; i++)
        //     {
        //         if(k + q[i] > a.Length) result[i] = a[(k + q[i] - 1) % a.Length];
        //         else result[i] = a[k + q[i] - 1];                
        //     }

        //     return result;
        // }

        public static int[] ArrayRotation(int[] a, int k, int[] q)
        {
            if((k >= a.Length) && (k % a.Length == 0)) k = 0;
            else if(k > a.Length) k = k % a.Length;

            int[] result = new int[q.Length];

            for(var i = 0; i < q.Length; i++)
            {
                if(k + q[i] > a.Length) result[i] = a[Math.Abs(k - q[i])];
                else result[i] = a[k + q[i] - 1];
                
            }

            return result;
        }
    }
}