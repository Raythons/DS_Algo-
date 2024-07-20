using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;

namespace Tries
{
    public class Trie
    {
        const int MaxChar = 26;
        List<Trie> child;
        public bool isLeaf;
        public Trie() {

            child = new List<Trie>(MaxChar);
            isLeaf = false;
            child.AddRange(Enumerable.Repeat<Trie>(null, MaxChar));
        }

        public void insert(string word, int idx = 0)
        {
            if (idx == word.Length)
                isLeaf = true;
            else
            {
                int cur = word[idx] - 'a';
                Console.WriteLine(cur);
                Console.WriteLine(child.ElementAt(1));
                if (child[cur] == null)
                    child[cur] = new Trie();

                child[cur].insert(word, idx + 1);
            }
        }
        public void insertIterative(string word, int idx = 0)
        {
            Trie currTrie = this;
            int cur;
            while (idx != word.Length)
            {
                cur = word[idx] - 'a';
                if (currTrie.child[cur] == null)
                    currTrie.child[cur] = new Trie();

                currTrie = currTrie.child[cur];
                idx++;
            }
            currTrie.isLeaf = true;
        }

        public bool WordExist(string str, int idx = 0)
        {
            if (idx == str.Length)
                return isLeaf;

            int curr = str[idx] - 'a';
            if (child[curr] is null)
                return false;
            return child[curr].WordExist(str, idx + 1);
        }

        public bool WordExistIterative(string word, int idx = 0)
        {
            Trie currTrie = this;
            int cur;
            while (idx != word.Length)
            {
                cur = word[idx] - 'a';
                if (currTrie.child[cur] == null)
                    return false;

                currTrie = currTrie.child[cur];
                idx++;
            }
            return currTrie.isLeaf = true;

        }
        public string  MinimalPrefixHelper(ref string word, int idx = 0,string prefixSoFar = "")
        {

            if (idx == word.Length)
                return prefixSoFar ?? word;
            
            int cur = word[idx] - 'a';
            if (child[cur] is not null && isLeaf)
            {
                prefixSoFar += word[idx];
                return prefixSoFar;
            }
            else if (child[cur] is not null && !isLeaf)
            {
                prefixSoFar += word[idx];
                return MinimalPrefixHelper(ref word, ++idx, prefixSoFar);
            }

            return word;
                 
        }

        public string MinimalPrefix(ref string word)
        {
           return MinimalPrefixHelper(ref word);

        }

        public void GetAllStrings(ref List<string> wordsList, string CurrString = "")
        {
            if(isLeaf)
                wordsList.Add(CurrString);

            for (int i = 0; i < MaxChar; i++)
            {
                child[i]?.GetAllStrings(ref wordsList, CurrString + (char)(i + 'a') );
            }
        }
        public void AutoComplete(ref List<string> wordsList, string prefix = "")
        {

            Trie currTrie = this;
            int cur;
            int currentIndex = 0;
            while (currentIndex != prefix.Length) {
                cur = prefix[currentIndex] - 'a';
                if (currTrie.child[cur] == null)
                    return ;

                currTrie = currTrie.child[cur];
                currentIndex++;
            }

            currTrie.GetAllStrings(ref wordsList, prefix);
            return;
        }
    
        public bool wordExisitWithOneChange (string word)
        {
            StringBuilder wordBuilder = new StringBuilder(word);

            for (int i = 0; i < wordBuilder.Length; i++)
            {
                char currentChar = word[i];
                for (char ch = 'a'; ch < 'z'; ch++)
                {
                    if (currentChar == ch)
                        continue;
                    wordBuilder[i] = ch;

                    if (WordExist(wordBuilder.ToString()))
                        return true;
                }
                wordBuilder[i] = currentChar;
            }
            return false;
        }
    }
}
