///**
// * Definition for a binary tree node.
// * public class TreeNode {
// *     public int val;
// *     public TreeNode left;
// *     public TreeNode right;
// *     public TreeNode(int val=0, TreeNode left=null, TreeNode right=null) {
// *         this.val = val;
// *         this.left = left;
// *         this.right = right;
// *     }
// * }
// */
//public class Solution
//{
//    public bool IsCompleteTree(TreeNode root)
//    {
//        var q = new Queue<TreeNode>();
//        q.Enqueue(root);
//        var level = 0;
//        var didNulled = false;

//        while (q.Count > 0)
//        {
//            var current = q.Dequeue();

//            if (current == null)
//                didNulled = true;
//            else
//            {
//                if (didNulled) return false;
//                q.Enqueue(current.left);
//                q.Enqueue(current.right);
//            }
//        }
//        return true;
//    }

//}