using System;

namespace November
{
    class Program
    {
        static void Main(string[] args)
        {

            int[] A = new int[5] { 5,4,3,2,1};
            binaryTree bt = new binaryTree();
            bt.Insert(4);
            bt.Insert(2);
            bt.Insert(6);
            bt.Insert(1);
            bt.Insert(3);
            bt.Insert(5);
            bt.Insert(7);

            bt.inOrder();

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
