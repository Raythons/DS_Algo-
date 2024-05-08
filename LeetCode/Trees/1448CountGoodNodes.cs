using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace H1202.Desktop.DS_ALgo.LeetCode.Trees
{
    public class 1448
    {
        
        private int _CountGoodNodesOnly(TreeNode curr, int maximmumSoFar)
    {
        if (curr is null)
            return 0;
        int currGoodNode = curr.data >= maximmumSoFar ? 1 : 0;

        int LeftGoodNodes = _CountGoodNodesOnly(curr.left, int.Max(curr.data, maximmumSoFar));
        int RightGoodNodes = _CountGoodNodesOnly(curr.right, int.Max(curr.data, maximmumSoFar));

        return LeftGoodNodes + RightGoodNodes + currGoodNode;
    }
    //leet 1448
    public int CountGoodNodesOnly(TreeNode root)
    {
        if (root is null)
            return 0;

        return _CountGoodNodesOnly(root, root.data);
    }
}
}