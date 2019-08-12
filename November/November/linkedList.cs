using System;
using System.Collections.Generic;
using System.Text;

namespace November
{
    public class linkedList
    {
        public class linkedListNode {
            public int n;
            public linkedListNode next;

            public linkedListNode(int input)
            {
                this.n = input;
                this.next = null;
            }
        }

        private linkedListNode head;
        private linkedListNode tail;

        public linkedList()
        {
            head = null;
            tail = null;
        }

        public void insert(int n)
        {
            if (head == null && tail == null)
            {
                head = new linkedListNode(n);
                tail = head;
            }
            else {
                tail.next = new linkedListNode(n);
                tail = tail.next;
            }
        }

        public void printList()
        {
            linkedListNode temp = head;
            while (temp != null)
            {
                Console.Write("{0} ", temp.n);
                temp = temp.next;
            }
            Console.WriteLine();
        }


    }
}
