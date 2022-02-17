using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStrucutre
{
    public class MinHeap1
    {
        /* left child - 2i
         * right child 2i + 1
         * parent = Math.Floor(i/2)
         */
        List<int> minList = null;
        public MinHeap1()
        {
            minList = new List<int>();
        }

        public void Insert(int ele)
        {
            // compare with left child
            // compare with parent
            minList.Add(ele);
            if (minList.Count == 1)
            {
                return;
            }
            int index = minList.Count - 1; 
            while (index > 0)
            {
                //odd is left child
                //even is right child
                    var parent = (int)Math.Floor(index/2f);
                    if(minList[parent] < ele)
                    {
                        Swap(minList, index, parent);
                        index = parent;
                    }
                    else
                    {
                        return;
                    }
            }
        }

        public int Min()
        {
            return minList[0]; ;
        }

        public int RemoveMin()
        {
            var min = minList[0];
            int index = 0;
            while(index < minList.Count - 2)
            {
                int child1 = minList[2 * index];
                int child2 = 2 * index + 1 <= minList.Count-1? minList[2 * index + 1] : 0;
                if(child1 > child2)
                {
                    Swap(minList, (2 * index)+1, index);
                    index = 2 * index;
                }
                else
                {
                    Swap(minList, 2 * index, index);
                    index = (2 * index + 1)+1;
                }
            }

            minList.Remove(minList.Count - 1);

            return min;
        }
        void Swap(List<int> nums, int i, int j)
        {
            var temp = nums[i];
            nums[i] = nums[j];
            nums[j] = temp;
        }

    }
}
