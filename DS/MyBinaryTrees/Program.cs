// See https://aka.ms/new-console-template for more information

using BinaryTreees;

TreeNode root = new TreeNode(1);
TreeNode root2 = new TreeNode(1);
TreeNode root3 = new TreeNode(5);
TreeNode root4 = new TreeNode(3);
TreeNode root5 = new TreeNode(5);
TreeNode root6 = new TreeNode(2);

MyBinaryTree tree1IsPerfect = new MyBinaryTree(root);
MyBinaryTree tree2IsCusions = new MyBinaryTree(root2);
MyBinaryTree tree3PathSum = new MyBinaryTree(root3);
MyBinaryTree tree4SumOfLeftLeafs = new MyBinaryTree(root4);
MyBinaryTree Tree5IsFull = new MyBinaryTree(root5);

MyBinaryTree CountGoodNodesObly = new MyBinaryTree(root6);


CountGoodNodesObly.Add(new List<int> { 8, 2 }, new List<char> { 'L', 'L' });
CountGoodNodesObly.Add(new List<int> { 20, 5 }, new List<char> { 'R', 'R' });

CountGoodNodesObly.root.left.right = new TreeNode(4);
CountGoodNodesObly.root.right.left = new TreeNode(6);


Console.WriteLine(CountGoodNodesObly.CountGoodNodesOnly(root6));
//var gg = Tree5IsFull.PrintLevelZigZag(Tree5IsFull.root);


//Console.WriteLine(Tree5IsFull.ParenthesizeCanonical(Tree5IsFull.root));
//foreach (var item in gg)
//{
//    foreach (var item2 in item)
//    {
//        Console.WriteLine(item2);
//    }
//    Console.WriteLine();
//}

//Console.WriteLine(Tree5IsFull.IsFullTree(Tree5IsFull.root));
Console.WriteLine("Hello, World!");



//tree.Add(new List<int> {  9, 20,15,7 }, new List<char> { 'L',  'R', 'L', 'R' });

tree2IsCusions.Add(new List<int> { 2, 4 }, new List<char> { 'L', 'L' });
tree2IsCusions.Add(new List<int> { 3, 5 }, new List<char> { 'R', 'R' });
tree2IsCusions.root.left.right = new TreeNode(10);
tree2IsCusions.root.right.left = new TreeNode(10);

//tree1IsPerfect.Add(new List<int> { 2, 4 }, new List<char> { 'L', 'L' });
//tree1IsPerfect.Add(new List<int> { 3, 5 }, new List<char> { 'R', 'R' });
//tree1IsPerfect.root.left.right  = new TreeNode(8);
//tree1IsPerfect.root.right.left  = new TreeNode(6);

//Console.WriteLine(tree4SumOfLeftLeafs.SumOfLeft(tree4SumOfLeftLeafs.root));
//Console.WriteLine(tree2IsCusions.IsCusionsNode(tree2IsCusions.root, 4, 5));

//Console.WriteLine(tree2IsCusions.IsPerfectTreeBigON(tree2IsCusions.root));
















//tree2.Add(new List<int> { 99, 100, 200, 800 }, new List<char> { 'R', 'R', 'L', 'L' });

//tree3PathSum.Add(new List<int> { 4, 11, 2 }, new List<char> { 'L', 'L', 'R' });
//tree3PathSum.Add(new List<int> { 8, 4, 1 }, new List<char> { 'R', 'R', 'R' });
//tree3PathSum.root.right.left = new TreeNode(13);
//tree3PathSum.root.left.left.left = new TreeNode(7);


//tree4SumOfLeftLeafs.Add(new List<int> { 9}, new List<char> { 'L'});
//tree4SumOfLeftLeafs.Add(new List<int> { 20, 7, 9999999}, new List<char> { 'R', 'R', 'L'});
//tree4SumOfLeftLeafs.root.right.left = new TreeNode(15);


//Console.WriteLine(tree.MaxValueEasy1(tree.root));
//tree2.PirntInOrder();
//Console.WriteLine(tree3.MaxValueEasy1(tree3.root));
//Console.WriteLine(tree4.MaxValueEasy1(tree4.root));
//Console.WriteLine(tree.MaximmumDepthEasy2(tree2.root));
//tree.PirntInOrder();
//Console.WriteLine(tree3PathSum.PathSum(26));

