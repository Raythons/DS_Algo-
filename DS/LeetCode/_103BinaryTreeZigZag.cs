using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode
{
    public  static class _103BinaryTreeZigZag
    {
          public class TreeNode
         {
            public int val;
            public TreeNode left;
            public TreeNode right;
            public TreeNode(int val = 0, TreeNode left = null, TreeNode right = null)
                {
                this.val = val;
                this.left = left;
                this.right = right;
            }
         }

        public  static IList<IList<int>> ZigzagLevelOrder(TreeNode root)
        {
            if (root is null)
                return new int[][] { };

            var dqueue = new LinkedList<TreeNode>();
            var result = new List<IList<int>>();
            dqueue.AddFirst(root);

            var fromLeft = true;

            while (dqueue.Count > 0)
            {

                var levelNodesCount = dqueue.Count;
                var levelNodes = new List<int>();
                while (levelNodesCount-- > 0)
                {
                    Console.WriteLine($"levelNodesCount is ${levelNodesCount} and count is ${dqueue.Count}");
                    TreeNode currentNode;
                    if (fromLeft)
                    {
                        currentNode = dqueue.First.Value;
                        dqueue.RemoveFirst();

                        if (currentNode.right != null)
                            dqueue.AddLast(currentNode.right);
                        if (currentNode.left != null)
                            dqueue.AddLast(currentNode.left);
                    }
                    else
                    {
                        currentNode = dqueue.Last.Value;
                        dqueue.RemoveLast();

                        if (currentNode.left != null)
                            dqueue.AddFirst(currentNode.left);
                        if (currentNode.right != null)
                            dqueue.AddFirst(currentNode.right);

                    }
                    levelNodes.Add(currentNode.val);
                }
                result.Add(levelNodes);
                fromLeft = !fromLeft;
            }
            return result;
        }
    }
}
