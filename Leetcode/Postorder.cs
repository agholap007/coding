using Xunit;

public class Postorder
{
    public static int[] GetPostorder(TreeNode node)
    {
        if (node == null) { return null; }
        List<int> results = new List<int>();
        Stack<TreeNode> stack = new Stack<TreeNode>();
        TreeNode curr = node;
        while(curr != null || stack.Count > 0){
            while(curr != null){
                if(curr.right != null){
                    stack.Push(curr.right);
                }
                stack.Push(curr);
                curr = curr.left;
            }
            curr = stack.Pop();
            if(stack.Count > 0 && stack.Peek() == curr.right){
                var temp = stack.Pop();
                stack.Push(curr);
                curr = temp;
            }
            else{
                results.Add(curr.val);
                curr = null;
            }
        }

        return results.ToArray();
    }

    [Fact]
    public void TestGetPostOrder()
    {
        /*
                1
                /\
               2  3
              /\  /\
             4  5 6 7
             postorder = 4,5,2,6,7,3,1

            */
        int[] nums = new int[] { 1, 2, 3, 4, 5, 6, 7 };
        // Console.WriteLine(JsonConvert.SerializeObject(TreeNode.GetTreeNode(nums, 0), Formatting.Indented));
        var result1 = GetPostorder(TreeNode.GetTreeNode(nums, 0));
        var postorder1 = new int[] { 4, 5, 2, 6, 7, 3, 1 };
        Console.WriteLine(JsonConvert.SerializeObject(result1));
        Console.WriteLine(JsonConvert.SerializeObject(postorder1));
        CollectionAssert.AreEqual(postorder1, result1);
    }
}