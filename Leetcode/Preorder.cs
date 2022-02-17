using System;
using System.Collections;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;
using Xunit;

public class Preorder
{
    public int[] GetPreOrder(TreeNode root)
    {
        if (root == null) { return null; }
        List<int> results = new List<int>();
        Stack<TreeNode> stack = new Stack<TreeNode>();
        TreeNode curr = null;
        stack.Push(root);

        while (stack.Count > 0)
        {
            curr = stack.Pop();
            results.Add(curr.val);
            if (curr.right != null)
            {
                stack.Push(curr.right);
            }
            if (curr.left != null)
            {
                stack.Push(curr.left);
            }
        }
        return results.ToArray();
    }

    [Fact]
    public void TestGetPreOrder()
    {        /*   
            1 ,2, 3, 4, 5, 6, 7, 8
            0 ,1, 2, 3, 4, 5, 6, 7
                
            root (n) = 1(0) - 2(1) - 3(2) 
            left(2n+1) = 2(1) - 4(3) - 6(5) 
            right(2n+2) = 3(2) - 5(4) -  7(6)

             1
            /\
           2  3
          /\  /\
         4  5 6 7

        pre - 1, 2, 4, 5, 3, 6, 7
        */
        int[] nums1 = new int[] { 1, 2, 3, 4, 5, 6, 7 };
        var pre1 = new int[] { 1, 2, 4, 5, 3, 6, 7 };
        var result1 = GetPreOrder(TreeNode.GetTreeNode(nums1, 0));
        // Console.WriteLine(JsonConvert.SerializeObject(result1));
        // Console.WriteLine(JsonConvert.SerializeObject(pre1));
        CollectionAssert.AreEqual(pre1, result1);
    }

}
public class TreeNode
{
    public int val { get; set; }
    public TreeNode left { get; set; }
    public TreeNode right { get; set; }
    public TreeNode(int val)
    {
        this.val = val;
    }

    public static TreeNode GetTreeNode(int[] nums, int i)
    {
        if (nums == null) { return null; }

        if (nums.Length <= i)
        {
            return null;
        }

        TreeNode root = new TreeNode(nums[i]);
        root.left = GetTreeNode(nums, i * 2 + 1);
        root.right = GetTreeNode(nums, i * 2 + 2);

        return root;

    }
}