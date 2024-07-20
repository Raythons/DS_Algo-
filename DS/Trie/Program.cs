// See https://aka.ms/new-console-template for more information

using Tries;

var Trieso = new Trie();
//Trieso.insertIterative("abcd");
//Trieso.insertIterative("ab");
//Trieso.insertIterative("abx");
//Trieso.insertIterative("xyz");
//Trieso.insertIterative("abyz");

Trieso.insertIterative("hello");
Trieso.insertIterative("leetcode");



var WordsList  = new List<string>();

Console.WriteLine(Trieso.wordExisitWithOneChange("hello"));
Console.WriteLine(Trieso.wordExisitWithOneChange("zello"));
Console.WriteLine(Trieso.wordExisitWithOneChange("xyllo"));


Trieso.AutoComplete(ref WordsList, "ab");
foreach (var word in WordsList)
{
    Console.WriteLine(word);
}



var TrieOnMap = new TrieOnMap();
Console.WriteLine("----------------Trie On Map ---------------------");

TrieOnMap.insertIterative("xyz");
TrieOnMap.insertIterative("xyze");
TrieOnMap.insertIterative("a");
TrieOnMap.insertIterative("bc");




Console.WriteLine(TrieOnMap.WordExistIterative("xyz"));
Console.WriteLine(TrieOnMap.WordExistIterative("xyze"));
Console.WriteLine(TrieOnMap.WordExistIterative("a"));
Console.WriteLine(TrieOnMap.WordExistIterative("bc"));
Console.WriteLine(TrieOnMap.WordExistIterative("abcdefg"));
