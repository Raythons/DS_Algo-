using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace H1202.Desktop.DS_ALgo.LeetCode.Trees
{
    public class 334
    {
            public int MaximmumDepthEasy2(TreeNode curr)
    {
        if (curr is null) return 0;
        return 1 + int.Max(MaximmumDepthEasy2(curr.left), MaximmumDepthEasy2(curr.right));
    }
}
}