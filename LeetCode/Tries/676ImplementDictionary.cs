#nullable enable
public class MagicDictionary
{
    const int MaxChar = 26;
    List<MagicDictionary?> child;
    public bool isLeaf;

    public MagicDictionary()
    {
        child = new List<MagicDictionary?>(MaxChar);
        isLeaf = false;
        child.AddRange(Enumerable.Repeat<MagicDictionary?>(null, MaxChar));
    }
    public void insert(string word, int idx = 0)
    {
        if (idx == word.Length)
            isLeaf = true;
        else
        {
            int cur = word[idx] - 'a';
            if (child[cur] == null)
                child[cur] = new MagicDictionary();

            child[cur]?.insert(word, idx + 1);
        }
    }
    public bool WordExist(string str, int idx = 0)
    {
        if (idx == str.Length)
            return isLeaf;

        int curr = str[idx] - 'a';
        if (child[curr] is null)
            return false;
        return child[curr]!.WordExist(str, idx + 1);
    }
    public void BuildDict(string[] dictionary)
    {

        for (int i = 0; i < dictionary.Length; i++)
        {
            if (!WordExist(dictionary[i]))
                insert(dictionary[i]);
        }
    }

    public bool Search(string searchWord)
    {
        StringBuilder wordBuilder = new StringBuilder(searchWord);

        for (int i = 0; i < wordBuilder.Length; i++)
        {
            char currentChar = searchWord[i];
            for (char ch = 'a'; ch <= 'z'; ch++)
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

/**
 * Your MagicDictionary object will be instantiated and called as such:
 * MagicDictionary obj = new MagicDictionary();
 * obj.BuildDict(dictionary);
 * bool param_2 = obj.Search(searchWord);
 */