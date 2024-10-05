using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode
{
    public static partial class _230KthSmallestNode
    {
        public static PriorityQueue<int, int> minHeap;
        public static int K;
        public static int KthSmallest(TreeNode root, int k)
        {
            if (root is null)
                return 0;
            K = k;
            minHeap = new PriorityQueue<int, int>();
            helper(root);

            return minHeap.Dequeue();
        }
        public static void helper(TreeNode root)
        {
            if (root is null)
                return;
            minHeap.Enqueue(root.val, -root.val);
            Console.WriteLine($"Root value ${root.val}");
            Console.WriteLine($"MinHeap Count  ${minHeap.Count}");

            if (minHeap.Count > K)
            {
                var g = minHeap.Dequeue();
                Console.WriteLine(K);
                Console.WriteLine($"Dequeued value ${g}");
            }

            helper(root.left);
            helper(root.right);

        }
    }
}
