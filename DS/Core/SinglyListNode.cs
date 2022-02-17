using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DS
{
    public class SinglyListNode
    {
        public int val { get; set; }
        public SinglyListNode next { get; set; }

        public SinglyListNode(int val, SinglyListNode next = null)
        {
            this.val = val;
            this.next = next;
        }
    }
}
