using System;
using System.Collections.Generic;
using System.Text;

namespace November
{

    public class binaryTree
    {
        public class binaryTreeNode {
            public int n;
            public binaryTreeNode left;
            public binaryTreeNode right;

            public binaryTreeNode(int val)
            {
                left = null;
                right = null;
                n = val;
            }
        }

        private binaryTreeNode head;

        public binaryTree()
        {
            head = null;
        }

        public void Insert(int n)
        {
            
        }

        //private static binaryTreeNode insert(binaryTreeNode head, int val)
        //{
            
        //}






    }
}
