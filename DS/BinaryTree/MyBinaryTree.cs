using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Numerics;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace BinaryTreees
{
    public class MyBinaryTree
    {
        public TreeNode root { get; set; }
        public MyBinaryTree(TreeNode root)
        {
            this.root = root;
        }

        private void _PrintInOrder(TreeNode curr)
        {
            if (curr is null)
                return;

            _PrintInOrder(curr.left);
            Console.WriteLine(curr.data);
            _PrintInOrder(curr.right);

        }
        public void PirntInOrder()
        {
            _PrintInOrder(root);
            Console.WriteLine();
        }


        private TreeNode SortedArrayToBST(int[] nums, int start, int end)
        {
            if (start > end)
                return null;

            int mid = (start + end) / 2;

            TreeNode root = new TreeNode(nums[mid]);

            root.left = SortedArrayToBST(nums, start, mid - 1);
            root.left = SortedArrayToBST(nums, mid + 1, end);
            return root;

        }
        public TreeNode SortedArrayToBST(int[] nums)
        {
            return SortedArrayToBST(nums, 0, nums.Length - 1);
        }



        public void Add(List<int> values, List<char> direction)
        {
            if (values.Count != direction.Count)
                throw new ArgumentException("Values and directions must have the same size.");

            TreeNode current = root;
            for (int i = 0; i < values.Count; ++i)
            {
                if (direction[i] == 'L')
                {
                    if (current.left == null)
                        current.left = new TreeNode(values[i]);
                    else if (current.left.data != values[i])
                        throw new InvalidOperationException("Inconsistent value detected.");
                    current = current.left;
                }
                else
                {
                    if (current.right == null)
                        current.right = new TreeNode(values[i]);
                    else if (current.right.data != values[i])
                        throw new InvalidOperationException("Inconsistent value detected.");
                    current = current.right;
                }
            }
        }

        private bool isMirror(TreeNode? first, TreeNode? second)
        {
            if (first is null && second is null)
                return true;

            if (
                first is null && second.right is not null ||
                first is not null && second is null ||
                first.data != second.data
                )
                return false;

            return isMirror(first.left, second.right) && isMirror(first.right, second.left);

        }

        public bool IsSymmetric1Tree101(TreeNode root)
        {
            if (root is null)
                return true;
            if (root.left is null && root.right != null
                || root.left != null && root.right == null)
                return false;

            return isMirror(root.left, root.right);
        }


        private string Parenthesize(TreeNode? curr, bool isLeft = true)
        {
            if (curr is null) return "()";

            string representation = "(" + curr.ToString();

            if (isLeft)
            {
                if (curr.left is not null)
                    representation += Parenthesize(curr.left, isLeft);
                else
                    representation += "()";

                if (curr.right is not null)
                    representation += Parenthesize(curr.right, isLeft);
                else
                    representation += "()";
            }
            else
            {
                if (curr.right is not null)
                    representation += Parenthesize(curr.right, isLeft);
                else
                    representation += "()";

                if (curr.left is not null)
                    representation += Parenthesize(curr.left, isLeft);
                else
                    representation += "()";
            }
            representation += ")";

            return representation;
        }

        public bool IsSymmetric1Tree101UsingParen(TreeNode root)
        {
            if (root is null)
                return true;
            if (root.left is null && root.right is null) return true;

            if (root.left is null && root.right != null
                || root.left != null && root.right == null)
                return false;

            return Parenthesize(root.left, true) == Parenthesize(root.right, false);
        }



        public bool _IsFullTree(TreeNode curr)
        {
            if (curr is null)
                return true;

            if (!IsFullNode(curr))
                return false;

            var IsLeftTreeFull = _IsFullTree(curr.left);
            var IsRightTreeFull = _IsFullTree(curr.right);

            if (IsLeftTreeFull && IsRightTreeFull)
                return true;

            return false;
        }

        private bool IsFullNode(TreeNode curr)
        {
            return (curr.left is not null && curr.right is not null) || (curr.left is null && curr.right is null);
        }

        public bool IsFullTree(TreeNode root)
        {
            return _IsFullTree(root);
        }
        private int _SumOfLeft(TreeNode curr)
        {
            if (curr is null)
                return 0;

            int SumLeft = _SumOfLeft(curr.left);
            int SumRight = _SumOfLeft(curr.right);

            if (IsLeftNodeLeaf(curr))
                SumLeft += curr.left.data;

            return SumLeft + SumRight;
        }

        private int _IsCusionsNode(TreeNode curr, int x, int y, int depth)
        {
            if (curr is null) return 0;

            if (curr.data == x || curr.data == y)
                return depth;

            var leftCusion = _IsCusionsNode(curr.left, x, y, depth + 1);
            var rightCusion = _IsCusionsNode(curr.right, x, y, depth + 1);
            if (leftCusion == rightCusion)
            {
                if (!_IsParentOf(curr, x, y))
                    return 1;
                else
                    return -1;
            }
            return leftCusion > rightCusion ? leftCusion : rightCusion;
        }

        public string ParenthesizeCanonical(TreeNode root)
        {
            if (root is null)
                return "()";

            string repr = "(" + root.data.ToString();
            List<string> v = new List<string>();

            if (root.left is not null)
                v.Add(ParenthesizeCanonical(root.left));
            else
                v.Add("()");

            if (root.right is not null)
                v.Add(ParenthesizeCanonical(root.right));
            else
                v.Add("()");

            v.Sort();
            for (int i = 0; i < v.Count; i++)
                repr += v[i];

            repr += ")";

            return repr;
        }
        private bool _IsParentOf(TreeNode curr, int x, int y)
        {
            if (curr.left is null && curr.right is null) return true;

            return ((curr.left.data == x || curr.left.data == y) && (curr.right.data == x || curr.right.data == y));
        }

        public bool IsCusionsNode(TreeNode curr, int x, int y) => _IsCusionsNode(curr, x, y, 0) == 1;
        private static bool IsLeftNodeLeaf(TreeNode curr)
        {
            return curr.left != null && curr.left.left == null && curr.left.right is null;
        }

        private bool isLeafNode(TreeNode curr)
        {
            return curr != null && curr.left is null && curr.right is null;
        }
        public bool IsPerfectTree(TreeNode curr)
        {

            if (curr is null)
                return false;

            if (isLeafNode(curr.left) && isLeafNode(curr.right))
                return true;

            bool LeftTree = IsPerfectTree(curr.left);
            bool RightTree = IsPerfectTree(curr.right);
            if (LeftTree && RightTree)
                return true;

            return false;
        }

        public (bool, int) IsPerfectTreeBigON(TreeNode root)
        {
            if (root is null)
                return (false, 0);

            if (root.left is null && root.right is null)
                return (true, 1);

            var left = IsPerfectTreeBigON(root.left);
            var right = IsPerfectTreeBigON(root.right);

            bool perfect = left.Item1 && right.Item1 && (left.Item2 == right.Item2);

            return (perfect, 1 + left.Item2 + right.Item2);
        }

        public void PrintLevelOrder(TreeNode root)
        {
            Queue<TreeNode> NodesQueue = new();
            NodesQueue.Enqueue(root);


            while (NodesQueue.Count != 0)
            {
                var currNode = NodesQueue.Peek();
                NodesQueue.Dequeue();

                Console.WriteLine(currNode.data);
                if (currNode.left is not null)
                    NodesQueue.Enqueue(currNode.left);

                if (currNode.right is not null)
                    NodesQueue.Enqueue(currNode.right);
            }
            Console.WriteLine();
        }
        public void PrintLevelOrderWithLevel(TreeNode root)
        {
            Queue<TreeNode> NodesQueue = new();
            NodesQueue.Enqueue(root);

            int level = 0;

            while (NodesQueue.Count != 0)
            {
                int size = NodesQueue.Count;
                Console.WriteLine($"level: ${level} ");
                while (size-- != 0)
                {
                    var currNode = NodesQueue.Peek();
                    NodesQueue.Dequeue();

                    Console.WriteLine(currNode.data);
                    if (currNode.left is not null)
                        NodesQueue.Enqueue(currNode.left);

                    if (currNode.right is not null)
                        NodesQueue.Enqueue(currNode.right);
                }
                level++;
            }

            Console.WriteLine();
        }


        // Deqeueu Is Data Strcture GG
        public List<List<int>> PrintLevelZigZag(TreeNode root)
        {
            LinkedList<TreeNode> NodesQueue = new();

            NodesQueue.AddFirst(root);

            bool ForwardLevel = true;
            List<List<int>> res = new();

            while (NodesQueue.Count != 0)
            {
                int size = NodesQueue.Count;
                List<int> Level = new List<int>();
                while (size-- != 0)
                {
                    TreeNode currNode;
                    if (ForwardLevel)
                    {
                        currNode = NodesQueue.First();
                        NodesQueue.RemoveFirst();

                        if (currNode.left is not null)
                            NodesQueue.AddLast(currNode.left);

                        if (currNode.right is not null)
                            NodesQueue.AddLast(currNode.right);
                    }
                    else
                    {
                        currNode = NodesQueue.Last();
                        NodesQueue.RemoveLast();

                        if (currNode.right is not null)
                            NodesQueue.AddFirst(currNode.right);

                        if (currNode.left is not null)
                            NodesQueue.AddFirst(currNode.left);
                    }
                    Level.Add(currNode.data);

                }
                ForwardLevel = !ForwardLevel;
                res.Add(Level);
            }
            Console.WriteLine();
            return res;
        }
        //didnt get it 
        public (int, int) DiameterOfBinmaryTree(TreeNode root)
        {
            // delim , height
            (int delim, int height) res = (0, 0);

            if (isLeafNode(root))
                return res;

            (int delim, int height) left_dlim = (0, 0);
            (int delim, int height) right_dlim = (0, 0);

            if (root.left is not null)
            {
                left_dlim = DiameterOfBinmaryTree(root.left);

                res.delim += 1 + left_dlim.height;
            }
            if (root.right is not null)
            {
                right_dlim = DiameterOfBinmaryTree(root.right);
                res.height += 1 + right_dlim.height;
            }

            res.delim = int.Max(res.delim, int.Max(left_dlim.delim, right_dlim.delim));

            res.height = 1 + int.Max(left_dlim.height, right_dlim.height);
            return res;

        }
        private bool _IsPerfectTreeBetter(TreeNode root, int h)
        {
            if (isLeafNode(root))
                return h == 0;

            if (_CheckIfOneOfChildsNull(root))
                return false;

            return _IsPerfectTreeBetter(root.left, h - 1) && _IsPerfectTreeBetter(root.right, h - 1);
        }

        private bool _CheckIfOneOfChildsNull(TreeNode root)
        {
            return root.left is null && root.right is not null || root.right is null && root.left is not null;
        }
        public bool IsPerfectTreeBetter(TreeNode root)
        {
            return _IsPerfectTreeBetter(root, this.MaximmumDepthEasy2(this.root));
        }

        public bool IsCousion5EasyBetterWay(TreeNode root, int x, int y)
        {
            if (FindNodeDepth(root, x) != FindNodeDepth(root, y))
                return false;


            if (FindParentNode(root, x, root) == FindParentNode(root, x, root))
                return false;

            return true;
        }

        private TreeNode FindParentNode(TreeNode root, int value, TreeNode Prent)
        {
            if (root is null)
                return null;

            if (root.data == value)
                return Prent;

            TreeNode leftParent = FindParentNode(root.left, value, root);
            if (leftParent is not null)
                return leftParent;

            return FindParentNode(root.right, value, root);
        }

        private int FindNodeDepth(TreeNode root, int value, int CurrDepth = 0)
        {
            if (root is null)
                return 0;

            if (root.data == value)
                return CurrDepth;

            int LeftDpeth = FindNodeDepth(root.left, value, CurrDepth + 1);
            if (LeftDpeth != 0)
                return LeftDpeth;


            return FindNodeDepth(root.right, value, CurrDepth + 1);
        }

        public int SumOfLeft(TreeNode curr) => _SumOfLeft(curr);
        public int MaxValueEasy1(TreeNode curr)
        {

            if (curr is null)
                return 0;


            return int.Max(curr.data, int.Max(MaxValueEasy1(curr.left), MaxValueEasy1(curr.right)));
        }
        //1   for 3 +  1 for 9 +  left now is 2 || right =>   1 for 20 +  ; 
        public int MaximmumDepthEasy2(TreeNode curr)
        {
            if (curr is null) return 0;
            return 1 + int.Max(MaximmumDepthEasy2(curr.left), MaximmumDepthEasy2(curr.right));
        }

        public bool IsPathSum(TreeNode curr, int Value, int Sum = 0)
        {
            if (curr is null)
                return false;

            // n of sum 

            Sum += curr.data;
            if (curr.left is null && curr.right is null)
            {
                if (Value != Sum)
                    Sum -= curr.data;
                return Value == Sum;
            }

            return IsPathSum(curr.left, Value, Sum) || IsPathSum(curr.right, Value, Sum);
        }

        public bool PathSum(int Value)
        {
            return IsPathSum(root, Value);
        }

        public bool PathSum_TeacherSolution(TreeNode root, int targetSum)
        {
            if (root is null) return false;

            if (isLeafNode(root) && targetSum == root.data)
                return true;

            return PathSum_TeacherSolution(root.left, targetSum - root.data) ||
                    PathSum_TeacherSolution(root.right, targetSum - root.data);
        }

        public void link (TreeNode from , TreeNode to)
        {
            if(from is not null)
                from.right = to;
            if(to is not null)
                to.left = from;
        }
  
        public (TreeNode head , TreeNode tail) BST_To_SortedDL(TreeNode root) {
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


        private int MinValue(TreeNode root)
        {
            while (root.left != null)
                root = root.left;

            return root.data;
        }


        public (bool isFound, int succesorValue) succesor(int target)
        {
            var ansestors = new List<TreeNode>();

            if (!FindChild(root, target, ansestors))
                return (false, -1);

            TreeNode ChildNode = GetNext(ansestors);

            if (ChildNode.right is not null)
                return (true ,MinValue(ChildNode.right));

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

            if(target == root.data)
                return true;

            if (target  > root.data)
                return FindChild(root.right, target, ansestors);

            return FindChild(root.left, target, ansestors);
        }
    }
}
