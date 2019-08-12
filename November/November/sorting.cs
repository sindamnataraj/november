using System;
using System.Collections.Generic;
using System.Text;

namespace November
{
    public class sorting {
        // S I B Q M B 
        // 1. Selection Sort
        public static void selectionSort(int[] A)
        {
            for (int i = 0; i < A.Length; i++)
            {
                int min = i;
                for (int j = i + 1; j < A.Length; j++)
                {
                    if (A[j] < A[min]) min = j;
                }
                if (min != i) sorting.swap(A, i, min);
            }
        }

        // 2. Insertion Sort
        //  Worst case - O(n2)
        // best case - sorted - O(n)
        public static void insertionSort(int[] A)
        {
            for (int i = 1; i < A.Length; i++)
            {
                int j = i - 1;
                int k = A[i];
                while (j >= 0 && A[j] > k)
                {
                    A[j + 1] = A[j];
                    j--;
                }

                A[j+1] = k;
            }
            
        }

        // 3 . Bubble Sort 
        // Worst and best case are same as O(n2)
        public static void bubbleSort(int[] A)
        {
            if (A.Length < 2) return;
            for (int i = A.Length - 1; i > 0; i--)
            {
                int j = 1;
                while (j <= i)
                {
                    if (A[j - 1] > A[j]) sorting.swap(A, j - 1, j);
                    j++;
                }
            }
        }

        // 4 Quick sort
        // worst case O(n2)
        // best case O(nlogn)
        public static void quickSort(int[] A, int p, int q)
        {
            if (p < q)
            {
                int r = partition(A, p, q);
                quickSort(A, p, r - 1);
                quickSort(A, r + 1, q);
            }
        }
        
        // O(n)
        public static int partition(int[] A, int p, int q)
        {
            int k = A[q];
            int i = p - 1;
            int j = p;

            while (j < q)
            {
                if(A[j] <= k)
                {
                    sorting.swap(A, i + 1, j);
                    i++;
                }
                j++;
            }

            A[q] = A[i + 1];
            A[i + 1] = k;
            return i + 1;
        }

        // 5. merge sort
        // always O(nlog n)
        public static void mergeSort(int[] A, int p, int q)
        {
            if (p < q)
            {
                int mid = p + (q - p) / 2;
                mergeSort(A, p, mid);
                mergeSort(A, mid + 1, q);
                merge(A, p, mid, q);
            }
        }

        public static void merge(int[] A, int p, int mid, int q)
        {
            int l1 = mid - p + 1;
            int[] left = new int[l1];
            for (int i1 = 0; i1 < l1; i1++)
            {
                left[i1] = A[p + i1];
            }

            int l2 = q - mid;
            int[] right = new int[l2];
            for (int i2 = 0; i2 < l2; i2++)
            {
                right[i2] = A[mid + 1 + i2];
            }

            int i = 0;
            int j = 0;
            int k = p;

            while (i < l1 && j < l2)
            {
                if (left[i] <= right[j])
                {
                    A[k] = left[i];
                    i++;
                }
                else {
                    A[k] = right[j];
                    j++;
                }
                k++;
            }

            while (i < l1)
            {
                
                A[k] = left[i];
                i++;
                k++;
            }

            while (j < l2)
            {
                A[k] = right[j];
                j++;   
                k++;
            }



        }

        // 6. Counting Sort
        public static void countingSort(int[] A, int k)
        {
            int[] B = new int[A.Length];
            Array.Copy(A, B, A.Length);

            int[] C = new int[k];

            for (int i = 0; i < A.Length; i++)
            {
                C[A[i]]++;
            }

            for (int i = 1; i < C.Length; i++)
            {
                C[i] = C[i - 1] + 1;
            }

            for (int i = 0; i < B.Length; i++)
            {
                A[C[B[i]] - 1] = B[i];
                C[B[i]]--;
            }


        }


        // 7. radix sort 
        // A has numbers with d digits like 123, 231, 453, 890
        public static void radixSort(int[] A, int k, int d)
        {
            for (int i = 1; i <= d; i++)
            {
                A = countingSort(A, 10, i);
            }
        }

        // counting sort on the i'th digit
        public static int[] countingSort(int[] A, int k, int i)
        {
            int[] B = new int[A.Length];
            Array.Copy(A, B, A.Length);

            int[] C = new int[k];

            for (int j = 0; j < A.Length; j++)
            {
                int temp = getIthDigit(A[j], i);
                if (temp > 9)
                {
                    Console.WriteLine("A[j] - {0}   i - {1}", A[j], i);
                }
                C[temp]++;
            }

            for (int j=1 ; j < C.Length ; j++)
            {
                C[j] = C[j - 1] + 1;
            }

            for (int j = 0; j < A.Length; j++)
            {
                B[C[getIthDigit(A[j], i)] - 1] = A[j];
                C[getIthDigit(A[j], i)]--;

            }

            return B;

        }

        public static int getIthDigit(int n, int i)
        {
            return n % ((int)Math.Pow(10, i));
        }

        
        public static void swap(int[] A, int i, int j)
        {

            int temp = A[i];
            A[i] = A[j];
            A[j] = temp;

            List<int> res = new List<int>() { 1,2,3};
        }
    }
}
