public (bool isFound, int succesorValue) succesor(int target)
{
    var ansestors = new List<TreeNode>();

    if (!FindChild(root, target, ansestors))
        return (false, -1);

    TreeNode ChildNode = GetNext(ansestors);

    if (ChildNode.right is not null)
        return (true, MinValue(ChildNode.right));

    TreeNode ParentNode = GetNext(ansestors);

    while (ParentNode != null && ParentNode.right == ChildNode)
    {
        ChildNode = ParentNode;
        ParentNode = GetNext(ansestors);
    }

    if (ParentNode is not null)
        return (true, ParentNode.data);

    return (false, -1);
}

private TreeNode GetNext(List<TreeNode> ansestors)
{
    if (ansestors.Count == 0)
        return null;
    TreeNode node = ansestors.Last();
    ansestors.RemoveAt(ansestors.Count - 1);
    return node;

}

private bool FindChild(TreeNode root, int target, List<TreeNode> ansestors)
{
    ansestors.Add(root);

    if (target == root.data)
        return true;

    if (target > root.data)
        return FindChild(root.right, target, ansestors);

    return FindChild(root.left, target, ansestors);
}