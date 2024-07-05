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
    public TreeNode _SortedArrayToBST(int[] nums, int start, int end)
    {
        if (start > end)
            return null;

        int mid = (start + end) / 2;
        TreeNode root = new TreeNode(nums[mid]);
        root.left = _SortedArrayToBST(nums, start, mid - 1);
        root.right = _SortedArrayToBST(nums, mid + 1, end);

        return root;
    }
    public TreeNode SortedArrayToBST(int[] nums)
    {
        return _SortedArrayToBST(nums, 0, nums.Length - 1);
    }
}