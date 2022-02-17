using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms
{
    public class BubbleSort
    {
        public void Sort(int[] nums)
        {
            for (int i = nums.Length-1; i >= 0; i--)
            {
                for(int j = 0; j < i; j++)
                {
                    if(nums[j] > nums[i])
                    {
                        Swap(nums, i, j);
                    }
                }
            }
        }

        public void Swap(int[] nums, int i, int j)
        {
            var temp = nums[i];
            nums[i] = nums[j];
            nums[j] = temp;
        }
    }


}
