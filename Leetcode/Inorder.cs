public class InOrder
{
    public static int[] GetInorder(TreeNode node)
    {
        if (node == null) { return null; }
        Stack<TreeNode> stack = new Stack<TreeNode>();
        List<int> results = new List<int>();
        TreeNode curr = node;
        while (curr != null || stack.Count > 0)
        {
            while (curr != null)
            {
                stack.Push(curr);
                curr = curr.left;
            }
            curr = stack.Pop();
            results.Add(curr.val);
            if (curr.right != null)
            {
                curr = curr.right;
            }
            else
            {
                curr = null;
            }
        }
        return results.ToArray();
    }

    [Fact]
    public void TestInorder()
    {
        /*
            1
            /\
           2  3
          /\  /\
         4  5 6 7
         inorder = 4,2,5,1,6,3,7

        */
        int[] nums = new int[] { 1, 2, 3, 4, 5, 6, 7 };
        Console.WriteLine(JsonConvert.SerializeObject(TreeNode.GetTreeNode(nums, 0), Formatting.Indented));
        var result1 = GetInorder(TreeNode.GetTreeNode(nums, 0));
        var inorder1 = new int[] { 4, 2, 5, 1, 6, 3, 7 };
        Console.WriteLine(JsonConvert.SerializeObject(result1));
        Console.WriteLine(JsonConvert.SerializeObject(inorder1));
        CollectionAssert.AreEqual(inorder1, result1);
    }
}