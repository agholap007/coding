using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DS.Array
{
    public class ArrayList
    {
        int capacity = 10;
        int[] arr = null;
        int curr = 0;

        public ArrayList()
        {
            arr = new int[capacity];
        }

        public void Add(int i)
        {
            if(curr == capacity)
            {
                var temp = arr;
                capacity *= capacity;
                arr = new int[capacity];
                temp.CopyTo(arr, 0);
            }
            arr[curr] = i;
            curr++;
        }

        public int Get(int index)
        {
            if(index >= curr)
            {
                throw new Exception("out of bound exception.");
            }
            return arr[index];
        }
    }
}
