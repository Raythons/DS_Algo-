using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tries
{
    public class TrieOnMap
    {
        int MaxChar = 256;
        Dictionary<char, TrieOnMap> child;
        public bool isLeaf;
        public TrieOnMap()
        {

            child = new(MaxChar);
            isLeaf = false;
            //child.AddRange(Enumerable.Repeat<Trie?>(null, MaxChar));
        }

     

        public void insertIterative(string word, int idx = 0)
        {
            var currTrie = this;
            int cur;
            while (idx != word.Length)
            {
                if (!currTrie.child.TryGetValue(word[idx], out TrieOnMap val))
                    currTrie.child.Add(word[idx], new TrieOnMap());


                currTrie = currTrie.child.GetValueOrDefault(word[idx]);
                idx++;
            }
            currTrie!.isLeaf = true;
        }

        //public bool WordExist(string str, int idx = 0)
        //{
        //    if (idx == str.Length)
        //        return isLeaf;

        //    int curr = str[idx] - 'a';
        //    if (child[curr] is null)
        //        return false;
        //    return child[curr].WordExist(str, idx + 1);
        //}

        public bool WordExistIterative(string word, int idx = 0)
        {
            var currTrie = this;
            while (idx != word.Length)
            {
                if (!currTrie.child.TryGetValue(word[idx], out TrieOnMap val))
                    return false;

                currTrie = val;
                idx++;
            }
            return currTrie.isLeaf = true;

            //}
            //public string MinimalPrefixHelper(ref string word, int idx = 0, string prefixSoFar = "")
            //{

            //    if (idx == word.Length)
            //        return prefixSoFar ?? word;

            //    int cur = word[idx] - 'a';
            //    if (child[cur] is not null && isLeaf)
            //    {
            //        prefixSoFar += word[idx];
            //        return prefixSoFar;
            //    }
            //    else if (child[cur] is not null && !isLeaf)
            //    {
            //        prefixSoFar += word[idx];
            //        return MinimalPrefixHelper(ref word, ++idx, prefixSoFar);
            //    }

            //    return word;

            //}

            //public string MinimalPrefix(ref string word)
            //{
            //    return MinimalPrefixHelper(ref word);

            //}
        }
    }
}
