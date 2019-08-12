using System;
using System.Collections.Generic;
using System.Text;

namespace November
{
    public class searching
    {

        public static int findMissingElement(int[] A)
        {
            int[] J = new int[2] { 1, 2, };
            
            int n = A.Length + 1;
            int xor_all = 1;
            for (int i = 2; i <= n; i++)
            {
                xor_all = xor_all ^ i;
            }

            int xor_a = 0;
            foreach (int a in A)
            {
                xor_a ^= a;

            }

            return xor_a ^ xor_all;


        }


        // two a + b = k
        // A is sorted
        public static bool twoSumK(int[] A, int p, int q,int K, ref int res1, ref int res2)
        {
            if (p < q)
            {
                int curSum = A[p] + A[q];
                if (curSum == K)
                {
                    res1 = A[p];
                    res2 = A[q];
                }
                else if (curSum < K)
                {
                    return twoSumK(A, p + 1, q,K, ref res1, ref res2);
                }
                else
                {
                    return twoSumK(A, p, q-1, K, ref res1, ref res2);
                }

            }
            return false;
        }

        // sum closest  to 0 - a+b ~ 0
        // A is sorted
        public static int twoSumClosestZero(int[] A)
        {
            int prevSum = int.MaxValue;
            return twoSumClosestZero(A, 0, A.Length-1, prevSum);
        }

        public static int twoSumClosestZero(int[] A, int p, int q, int prevSum)
        {
            if (p < q)
            {
                int curSum = A[p] + A[q];
                if (curSum == 0)
                {
                    return 0;
                }
                else if (Math.Abs(curSum) < Math.Abs(prevSum))
                {
                    return twoSumClosestZero(A, p + 1, q, curSum);
                }
                else
                {
                    return twoSumClosestZero(A, p, q-1, prevSum );
                }

            }
            return prevSum;
        }


        // sum closest to k ( a + b ~ k )
        public static int twoSumClosest(int[] A, int k)
        {
            Array.Sort(A);
            int i = 0;
            int j = 0;
            return twoSumClosest(A, 0, A.Length - 1, k, int.MaxValue,ref i,ref j);
        }

        public static int twoSumClosest(int[] A, int p, int q, int target, int prevClosestSum,ref int i,ref int j)
        {
            if (p < q)
            {
                int curSum = A[p] + A[q];
                if (curSum == target) return curSum;

                int curDiff = Math.Abs(target - curSum);
                int prevDiff = Math.Abs(target - prevClosestSum);

                if (curDiff < prevDiff)
                {
                    prevClosestSum = curSum;
                    i = p;
                    j = q;
                }

                if (curSum < target)
                {
                    return twoSumClosest(A, p + 1, q, target, prevClosestSum,ref i, ref j);
                }
                else
                {
                    return twoSumClosest(A, p, q - 1, target, prevClosestSum, ref i, ref j);
                }


            }

            return prevClosestSum;
        }

        // three sum closest to k a + b + c ~ k
        public static int threeClosestSum(int[] A, int target)
        {
            Array.Sort(A);
            int prevClosestThreeSum = int.MaxValue;

            for (int i = 0; i < A.Length - 2; i++)
            {
                int twosumi = 0;
                int twosumj = 0;
                int curClosestTwoSum = twoSumClosest(A, i + 1, A.Length - 1, target - A[i], int.MaxValue, ref twosumi, ref twosumj);
                int curClosestThreeSum = curClosestTwoSum + A[i];
                if (curClosestThreeSum < prevClosestThreeSum) prevClosestThreeSum = curClosestThreeSum;
                
             }

            return prevClosestThreeSum;
        }

        //find pivot 
        public static int FindPivot(int[] A, int p, int q)
        {
            if (p <= q)
            {
                if (p == q)
                {
                    if (A[p] == 0) return p;
                    else return -1;
                }
                else if (p == q - 1)
                {
                    if (A[p] == 1 && A[q] == 0) return q;
                    if (A[p] == 0) return p;
                    return -1;
                }
                else
                {
                    int mid = p + (q - p) / 2;
                    if (A[mid] == 0 && A[mid - 1] == 1)
                    {
                        return mid;
                    }
                    else if (A[mid] == 0 && A[mid - 1] == 0)
                    {
                        return FindPivot(A, p, mid);
                    }
                    else
                    {
                        return FindPivot(A, mid + 1, q);
                    }
                }
            }
            return -1;
        }

        // Binary search
        // A is already sorted
        //public static int binarySearch(int[] A, int p, int q,int target)
        //{
        //    if (p == q)
        //    {
        //        if (A[p] == target) return p;
        //        return -1;
        //    }
        //    else if (p < q)
        //    {
        //        int mid = p + (q - p) / 2;
        //        if (A[mid] == target)
        //        {
        //            return mid;
        //        }
        //        else if (target < A[mid])
        //        {
        //            return binarySearch(A, p, mid - 1, target);
        //        }
        //        else
        //        {
        //            return binarySearch(A, mid + 1, q, target);
        //        }
        //    }
        //    return -1;
        //}

        public static bool binarySearch(int[] A, int p, int q, int target)
        {
            if (p <= q)
            {
                int mid = p + (q - p) / 2;
                if (A[mid] == target) {
                    return true;
                }
                else if (A[mid] < target)
                {
                    return binarySearch(A, mid + 1, q, target);
                }
                else
                {
                    return binarySearch(A, p, mid - 1, target);
                }
            }
            else
            {
                return false;
            }
        }

        //dutch flag problem - separate evens and odds
        public static void separateEvenOdds(int[] A)
        {
            int i = -1;


            int k = 0;
            while (k < A.Length)
            {
                if (utility.isEven(A[k]))
                {
                    utility.swap(A, i + 1, k);
                    i++;
                }
                k++;
            }

        }

        //separate 0s 1s 2s
        public static void separateThreeDigits(int[] A)
        {
            int i = -1;
            int j = A.Length;
            int k = 0;

            while (k < j)
            {
                if (A[k] == 0)
                {
                    utility.swap(A, i + 1, k);
                    i++;
                    k++;
                }
                else if (A[k] == 1)
                {
                    k++;
                }
                else {
                    //A[k] == 2
                    utility.swap(A, j - 1, k);
                    j--;
                }
            }
        }

    }
}
