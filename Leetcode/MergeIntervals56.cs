/*
Given an array of intervals where intervals[i] = [starti, endi], merge all overlapping intervals, and return an array of the non-overlapping
 intervals that cover all the intervals in the input.

 

Example 1:

Input: intervals = [[1,3],[2,6],[8,10],[15,18]]
Output: [[1,6],[8,10],[15,18]]
Explanation: Since intervals [1,3] and [2,6] overlaps, merge them into [1,6].
Example 2:

Input: intervals = [[1,4],[4,5]]
Output: [[1,5]]
Explanation: Intervals [1,4] and [4,5] are considered overlapping.
*/

using Microsoft.VisualStudio.TestTools.UnitTesting;
using Xunit;

public class MergeInterval
{
    public IEnumerable<int[]> MergeIntervals(int[][] intervals)
    {
        if (intervals == null) { return null; }

        Array.Sort(intervals, (x, y) => x[0].CompareTo(y[0]));
        int[] curr = intervals[0];
        List<int[]> results = new List<int[]>();
        for (int i = 1; i < intervals.Length; i++)
        {
            if (curr[1] > intervals[i][0])
            { // overlaps
                curr[1] = Math.Max(curr[1], intervals[i][1]);
            }
            else
            {
                results.Add(curr);
                curr = intervals[i];
            }
        }

        results.Add(curr);
        return results;
    }

    [Fact]
    public void Test()
    {
        var mergeInterval = new MergeInterval();
        var input1 = new List<int[]>{
            new int[]{1, 3 },
            new int[]{2, 6 },
            new int[]{8, 10 },
             new int[]{15, 18 }
        };
        IEnumerable<int[]> expected = new List<int[]>{
            new int[]{1, 6 },
            new int[]{8, 10 },
            new int[]{15, 18 },
        };
        var actual = mergeInterval.MergeIntervals(input1.ToArray());
        Xunit.Assert.Equal(actual, expected);
    }
}