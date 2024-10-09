using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode
{
    public class Trie
    {

        public (Trie trie, bool isWord)[] arr;
        public Trie()
        {
            arr = new (Trie trie, bool isWord)[27];
        }

        private  void Insert(string word, int idx = 0)
        {
            if (idx == word.Length)
                return;

            var ch = word[idx] - 'a';
            if (arr[ch].trie == null)
                arr[ch] = (new Trie(), idx == word.Length - 1);

            else if (!arr[ch].isWord)
                arr[ch].isWord = idx == word.Length - 1;

            

            //to handle last char im word in exising trie
            arr[ch].trie.Insert(word, idx + 1);

        }
        public void Insert(string word)
        {
             Insert(word, 0); 
        }

        private bool Search(string word, int idx)
        {
            if(idx == word.Length)
                return false;

            var ch = word[idx] - 'a';

            if (arr[ch].trie is null)
                return false;

            if (idx == word.Length -1 && arr[ch].isWord)
                return true;

         
            return arr[ch].trie.Search(word, idx + 1);    
        }


        public bool Search(string word)
        {
            return Search(word, 0);
        }

        private bool StartsWith(string prefix, int idx)
        {
            if (idx == prefix.Length)
                return false;

            var ch = prefix[idx] - 'a';

            if (arr[ch].trie is null)
                return false;

            if (idx == prefix.Length - 1 )
                return true;

            return arr[ch].trie.StartsWith(prefix, idx + 1);
        }

        public bool StartsWith(string prefix)
        {
            return StartsWith(prefix, 0);
        }
    }

    /**
     * Your Trie object will be instantiated and called as such:
     * Trie obj = new Trie();
     * obj.Insert(word);
     * bool param_2 = obj.Search(word);
     * bool param_3 = obj.StartsWith(prefix);
     */
}
