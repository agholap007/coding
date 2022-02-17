using DS.Array;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DS.Stack
{
    public class ArrayStack
    {
        //push
        //pop
        //peek
        //isempty
        //count
        ArrayList lst = null;
        int count = 0;

        public ArrayStack()
        {
            lst = new ArrayList();
        }

        public int Count()
        {
            return count;
        }

        public void Push(int i)
        {
            lst.Add(count++);
        }

        public int Pop()
        {
            if(count == 0)
            {
                throw new Exception("Empty stack");
            }

            return lst.Get(count-- - 1);
        }

        public int Peek()
        {
            if(count == 0)
            {
                throw new Exception("Empty stack");
            }

            return lst.Get(count - 1);
        }
        
    }
}
