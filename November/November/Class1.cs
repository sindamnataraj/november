using System;
using System.Collections.Generic;
using System.Text;

namespace November
{
  public class ListNode {
      public int val;
      public ListNode next;
      public ListNode(int x) { val = x; }
  }
    public class Solution
    {
        public ListNode MergeTwoLists(ListNode l1, ListNode l2)
        {
            ListNode head = null;
            ListNode tail = null;

            while (l1 != null && l2 != null)
            {
                if (l1.val <= l2.val)
                {
                    if (head == null && tail == null)
                    {
                        head = l1;
                        tail = l1;

                        l1 = l1.next;
                        head.next = null;
                    }
                    else
                    {
                        tail.next = l1;
                        l1 = l1.next;
                        tail = tail.next;
                        tail.next = null;
                    }
                }
                else
                {
                    if (head == null && tail == null)
                    {
                        head = l2;
                        tail = l2;
                        l2 = l2.next;
                        head.next = null;
                    }
                    else
                    {
                        tail.next = l2;
                        l2 = l2.next;
                        tail = tail.next;
                        tail.next = null;
                    }
                }
            }


            while (l1 != null)
            {

                if (head == null && tail == null)
                {
                    head = l1;
                    tail = l1;
                    l1 = l1.next;
                    head.next = null;
                }
                else
                {
                    tail.next = l1;
                    l1 = l1.next;
                    tail = tail.next;
                    tail.next = null;
                }

            }

            while (l2 != null)
            {

                if (head == null && tail == null)
                {
                    head = l2;
                    tail = l2;
                    l2 = l2.next;
                    head.next = null;
                }
                else
                {
                    tail.next = l1;
                    l2 = l2.next;
                    tail = tail.next;
                    tail.next = null;
                }

            }


            return head;

        }
    }
}
