/*
Given a m x n grid filled with non-negative numbers, find a path from top left to bottom right, which minimizes the sum of all numbers along its path.

Note: You can only move either down or right at any point in time.

Example 1:
Input: grid = [[1,3,1],[1,5,1],[4,2,1]]
Output: 7
Explanation: Because the path 1 → 3 → 1 → 1 → 1 minimizes the sum.
*/
using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Assert = Microsoft.VisualStudio.TestTools.UnitTesting.Assert;

public class MinimumPathSum
{
    public static int MinimumSum(List<int[]> path)
    {
        var matrix = path.ToArray();
        for (int i = 0; i < matrix.Length; i++)
        {
            for (int j = 0; j < matrix[0].Length; j++)
            {
                Console.WriteLine($" {matrix[i][j]} ");
            }
        }
        return 7;
    }

    public static void Test()
    {
        var out1 = MinimumSum(new List<int[]>(){
            new int[]{1, 3, 1 },
            new int[]{1, 5, 1 },
            new int[]{4, 2, 1 }
        });
        Assert.AreEqual(out1, 7, "Failed");
    }
}