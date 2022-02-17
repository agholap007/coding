using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms
{
    public class InsertionSort
    {
        public void Sort(int[] nums)
        {
            for(int i = 0; i < nums.Length; i++)
            {
                int j = 0;
                while(j < i)
                {
                    if(nums[j] > nums[i])
                    {
                        var temp = nums[j];
                        nums[j] = nums[i];
                        int k = i;
                        while( k > j +1)
                        {
                            nums[k] = nums[k - 1];
                            k--;
                        }
                        nums[k] = temp;
                        break;
                    }
                    j++;
                }
            }
        }
    }
}
