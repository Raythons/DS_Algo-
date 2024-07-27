namespace AVLTree
{
    public class clsAvlTree
    {
        public int Data { get; set; }
        public int Height { get; set; }
        public clsAvlTree Left { get; set; } = null;
        public clsAvlTree Right { get; set; } = null;

        public int ChildHeight (clsAvlTree treeNode)
        {
            if(treeNode is null)
                return -1;
            return treeNode.Height;
        }
        public void UpdateHeight ()
        {
               Height = int.Max (ChildHeight(Left), ChildHeight(Right));
        }
        public int balanceFactor ()
        {
            return ChildHeight(Left) - ChildHeight(Right);
        }
        public clsAvlTree RightRotation (clsAvlTree p)
        {
            clsAvlTree Q = p.Left;
            p.Left = Q.Right;
            Q.Right = p;
            Q.UpdateHeight();
            p.UpdateHeight();
            return Q;

        }
        public clsAvlTree LeftRotation (clsAvlTree Q)
        {
            clsAvlTree P = Q.Right;
            Q.Right = P.Left;
            Q.Left = P;
            P.UpdateHeight();
            Q.UpdateHeight();
            return P;
        }

        public clsAvlTree Balance (clsAvlTree node)
        {
            if(node.balanceFactor() == 2 )
            {
                if (node.Left.balanceFactor() == -1)
                    node.Left = LeftRotation(node.Left);

                node = node.RightRotation(node);
            }
            else if (node.balanceFactor() == -2)
            {
                if ( node.Right.balanceFactor() == 1)
                    node.Right = RightRotation(node.Right);
                node = LeftRotation(node);
            }
            return node;
        }

        public clsAvlTree  InsertNode (int target , clsAvlTree node)
        {
            if ( target < node.Data)
            {
                if (node.Left is null)
                    node.Left = new clsAvlTree();
                else 
                    node.Left = InsertNode(target , node.Left);
            }
            else if (target > node.Data)
            {
                if (node.Right is null)
                    node.Right = new clsAvlTree();
                else
                    node.Right = InsertNode(target, node.Left);
            }
            node.UpdateHeight();
            return Balance(node); 
        }

    }
}
