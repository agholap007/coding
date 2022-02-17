using DS.Array;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DS.Queue
{
    public class ArrayQueue
    {
        ArrayList list = null;
        //enqueue
        //dequeue
        //count
        int curr = -1;
        int count = 0;
        public ArrayQueue()
        {
            list = new ArrayList();
        }

        public int Count()
        {
            return count;
        }

        public void Enqueue(int i)
        {
            list.Add(count++);
        }

        public int Dequeue()
        {
            if(count == 0) { throw new Exception("Queue is empty"); }
            count--;
            return list.Get(++curr);
        }

    }
}
