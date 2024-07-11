/**
 * Definition for a binary tree node.
 * public class TreeNode {
 *     public int val;
 *     public TreeNode left;
 *     public TreeNode right;
 *     public TreeNode(int val=0, TreeNode left=null, TreeNode right=null) {
 *         this.val = val;
 *         this.left = left;
 *         this.right = right;
 *     }
 * }
 */
public class Solution
{
    public bool IsValidBSTHelper(TreeNode root, long min, long max)
    {
        bool status = min < root.val && max > root.val;
        if (!status) return false;

        bool leftBst = root.left is null || IsValidBSTHelper(root.left, min, root.val);
        if (!leftBst)
            return false;

        bool rightBst = root.right is null || IsValidBSTHelper(root.right, root.val, max);
        return rightBst;
    }

    public bool IsValidBST(TreeNode root)
    {
        if (root.left is null && root.right is null)
            return true;
        return IsValidBSTHelper(root, Int64.MinValue, Int64.MaxValue);
    }
}