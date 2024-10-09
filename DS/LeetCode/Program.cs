// See https://aka.ms/new-console-template for more information
using LeetCode;
using System.Diagnostics;

Console.WriteLine("Hello, World!");
//_1360NumberBetween2Days.Run();
//_121BestTimeToBuyAndSell.Run();

var gg = new int[] { 2, 3, -1, 8, 4 };

//Console.WriteLine(_1991FindMiddleElement.FindMiddleIndex(gg));

//TreeNode treeNode2 = new TreeNode(2);
//TreeNode treeNode1 = new TreeNode(1);
//TreeNode treeNode3 = new TreeNode(3);
//treeNode2.left = treeNode1;
//treeNode2.right = treeNode3;
//Console.WriteLine(_230KthSmallestNode.KthSmallest(treeNode2, 3));

_128LCN.Run();
//MinStack.Run();

var trie = new Trie();
trie.Insert("app");
trie.Insert("apple");
trie.Insert("add");
trie.Search("app");
