using DS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStrucutre.LinkedList
{
    public class SinglyLinkedList
    {
        public SinglyListNode head { get; set; }

        //O(1)
        public void Add(int val)
        {
            SinglyListNode newNode = null;

            if (this.head != null)
            {
                newNode = new SinglyListNode(val, this.head);
            }
            else
            {
                newNode = new SinglyListNode(val);
            }
            this.head = newNode;
        }

        //O(N)
        public void Remove(int val)
        {
            SinglyListNode curr = this.head;
            SinglyListNode prev = curr;
            while(curr != null)
            {
                if(curr.val == val)
                {
                    prev.next = curr.next;
                    return;
                }

                prev = curr;
                curr = curr.next;
            }
        }
    }
}
