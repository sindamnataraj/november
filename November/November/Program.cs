using System;

namespace November
{
    class Program
    {
        static void Main(string[] args)
        {

            int[] A = new int[5] { 5,4,3,2,1};

            int[] A1 = new int[5] { 123, 234,111,901,100};
            sorting.radixSort(A1, 10, 3);

            utility.printArray(A);

            Console.ReadLine();
        }
    }

    public class utility
    {
        public static void swap(int[] A, int i, int j)
        {
            int a = A[i];
            A[i] = A[j];
            A[j] = a;
        }

        public static void printArray(int[] A)
        {
            foreach (int a in A)
            {
                Console.Write("{0} ",a);
            }
            Console.WriteLine();
        }

        public static bool isEven(int n)
        {
            if (n % 2 == 0) return true;
            return false;
        }

    }
}
