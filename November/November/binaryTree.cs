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
                this.n = val;
            }
        }

        private binaryTreeNode head;

        public binaryTree()
        {
            head = null;
        }

        public void Insert(int n)
        {
            head = insertInOrder(head, n);
        }

        private static binaryTreeNode insertInOrder(binaryTreeNode head, int val)
        {
            if (head == null)
            {
                return new binaryTreeNode(val);
            }

            Queue<binaryTreeNode> q = new Queue<binaryTreeNode>();
            q.Enqueue(head);
            

            
            binaryTreeNode temp = null;
            while (q.Count > 0)
            {
                
                temp = q.Dequeue();

                if (temp != null)
                {
                    if (temp.left != null) q.Enqueue(temp.left);
                    else
                    {
                        temp.left = new binaryTreeNode(val);
                        return head; 
                    }

                    if (temp.right != null) q.Enqueue(temp.right);
                    else {
                        temp.right = new binaryTreeNode(val);
                        return head;
                    }
                }
                

            }

            return head;
        }


        private static binaryTreeNode insert(binaryTreeNode head, int val)
        {
            if (head == null)
            {
                return new binaryTreeNode(val);
            }

            if (val < head.n)
            {
                head.left = insert(head.left, val);
            }
            else
            {
                head.right = insert(head.right, val);
            }
            return head;
        }

        public void printTree()
        {
            printTree(head);
        }

        // level order traversal
        private void printTree(binaryTreeNode head)
        {
            if (head == null) return;
            Queue<binaryTreeNode> q = new Queue<binaryTreeNode>();
            q.Enqueue(head);
            q.Enqueue(null);

            while(q.Count>0)
            {
                binaryTreeNode temp = q.Dequeue();
                if (temp != null)
                {
                    Console.Write("{0} ", temp.n);
                    if (temp.left != null) q.Enqueue(temp.left);
                    if (temp.right != null) q.Enqueue(temp.right);
                }
                else
                {
                    if (q.Count > 0) {
                        Console.WriteLine();
                        q.Enqueue(null);
                    }
                }
            }
        }

        // in order traversal
        public void inOrder()
        {
            inorder_Recursive(head);
        }

        private void inorder_Recursive(binaryTreeNode head)
        {
            if (head != null)
            {
                inorder_Recursive(head.left);
                Console.Write("{0} ",head.n);
                inorder_Recursive(head.right);
            }
        }


        // pre order traversal 
        public void preOrder()
        {
            preorder_Recursive(head);
        }

        private void preorder_Recursive(binaryTreeNode head)
        {
            if (head != null)
            {
                Console.Write("{0} ",head.n);
                preorder_Recursive(head.left);
                preorder_Recursive(head.right);
            }
        }

        // post order
        public void postOrder()
        {
            postOrder_Recursive(head);
        }

        public void postOrder_Recursive(binaryTreeNode head)
        {
            if (head == null) return;
            postOrder_Recursive(head.left);
            postOrder_Recursive(head.right);
            Console.Write("{0} ",head.n);
        }

        // search in binary tree - 
        public bool search(int n)
        {
            return search(head, n);
        }

        private bool search(binaryTreeNode head,int n)
        {
            if (head == null) return false;
            if (head.n == n) return false;
            return search(head.left, n) || search(head.right, n);

        }

        // deepest node in binary tree
        public void deepestNode()
        {
            binaryTreeNode node = deepestNode(head);
            Console.WriteLine("Deepest Node is {0} ",node.n);
        }

        private binaryTreeNode deepestNode(binaryTreeNode head)
        {
            if (head == null) return null;
            Queue<binaryTreeNode> q = new Queue<binaryTreeNode>();
            q.Enqueue(head);
            q.Enqueue(null);
            binaryTreeNode prevNode = null;
            binaryTreeNode temp = null;
            while (q.Count > 0)
            {
                prevNode = temp;
                temp = q.Dequeue();
                if (temp != null)
                {
                    if (temp.left != null) q.Enqueue(temp.left);
                    if (temp.right != null) q.Enqueue(temp.right);
                }
                else
                {
                    if (q.Count == 0)
                    {
                        return prevNode;
                    }
                    else
                    {
                        q.Enqueue(null);
                    }
                }
            }

            return prevNode;
        }

        // full nodes
        public int fullNodes()
        {
        }
        
        private 

    }
}
