public void link(TreeNode from, TreeNode to)
{
    if (from is not null)
        from.right = to;
    if (to is not null)
        to.left = from;
}

public (TreeNode head, TreeNode tail) BST_To_SortedDL(TreeNode root)
{
    if (root is null)
        return (null, null);

    (TreeNode head, TreeNode tail) left = BST_To_SortedDL(root.left);
    (TreeNode head, TreeNode tail) right = BST_To_SortedDL(root.right);

    // to handle null values
    TreeNode head = root;
    TreeNode tail = root;

    if (left.head is not null)
    {
        link(left.tail, root);
        head = left.head;

    }

    if (right.head is not null)
    {
        link(root, right.head);
        tail = right.tail;
    }

    return (head, tail);
}