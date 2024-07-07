namespace BinaryTreees
{
    public class TreeNode
    {
        public int data { get; set; }
        public TreeNode left { get; set; }
        public TreeNode right { get; set; }
        public TreeNode(int data)
        {
            this.data = data;
            left = null;
            right = null;
        }
    }
}
