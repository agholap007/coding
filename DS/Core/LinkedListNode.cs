using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DS
{
    public class LinkedListNode
    {
        public int val { get; set; }
        public LinkedListNode next { get; set; }
        public LinkedListNode prev { get; set; }

        public  LinkedListNode(int val, LinkedListNode next = null, LinkedListNode prev = null)
        {
            this.val = val;
            this.next = next;
            this.prev = prev;
        }
    }
}
