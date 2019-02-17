using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1
{
    class Node
    {
        public string site { get; set; } //get/set turns it from a FIELD to a PROPERTY so that listbox can use it
        public ValueTuple<string, string, string> data { get; set; }
    }

    static class NodeUtils
    {
        private const int asciisize = 256;
        public const int ASCII_RANGE = '~' - ' ' + 1;
        public static string Encrypt(string s, string type, Int16 shift)
        {
            StringBuilder res = new StringBuilder(s);
            switch (type)
            {
                case "shift":
                    for (int i = 0; i < s.Length; i++)
                    {
                        res[i] = (char)((res[i] - ' ' + shift) % (ASCII_RANGE) + ' ');
                    }
                    break;
            }
            return res.ToString();
        }

        public static string Decrypt(string s, string type, Int16 shift)
        {
            StringBuilder res = new StringBuilder(s);
            switch (type)
            {
                case "shift":
                    for (int i = 0; i < s.Length; i++)
                    {
                        int dec_int = (res[i] - ' ' - shift) % ASCII_RANGE;
                        if (dec_int < 0) dec_int += ASCII_RANGE;
                        dec_int += ' ';
                        res[i] = (char)dec_int;
                    }
                    break;
            }
            return res.ToString();
        }
    }

    class Search
    {

        private class Search_Node
        {
            public bool is_a_word;
            private Search_Node[] letters;
            public List<int> pre_words;

            public Search_Node()
            {
                is_a_word = false;
                letters = new Search_Node[NodeUtils.ASCII_RANGE];
                for (int i = 0; i < NodeUtils.ASCII_RANGE; i++)
                {
                    letters[i] = null;
                }
                pre_words = new List<int>();
            }

            //overload [] to enable letters['a'] etc
            public Search_Node this[char c]
            {
                get
                {
                    return letters[(int)(c - ' ')];
                }

                set
                {
                    letters[(int)(c - ' ')] = value;
                }
            }

        }

        Dictionary<int, string> words;
        int counter;
        Search_Node head;

        public Search()
        {
            words = new Dictionary<int, string>();
            counter = 0;
            head = new Search_Node();
        }

        public void Add(string s)
        {
            char last_letter = ' ';
            Search_Node curr_node = head;
            Search_Node last_node = head;
            foreach (char c in s)
            {
                last_node = curr_node;
                if (null == curr_node[c]) curr_node[c] = new Search_Node();
                curr_node = curr_node[c];
                curr_node.pre_words.Add(counter);
                last_letter = c;
            }
            if (!last_node[last_letter].is_a_word)
            {
                last_node[last_letter].is_a_word = true;
                words.Add(counter++, s);
            }
        }

        //get all words that start with the prefix "s"
        public List<string> get_matches(string s)
        {
            Search_Node curr_node = head;
            foreach (char c in s)
            {
                curr_node = curr_node[c];
                if (null == curr_node) return null;
            }
            List<string> res = new List<string>();
            foreach (int i in curr_node.pre_words)
            {
                res.Add(words[i]);
            }
            return res;
        }

        /*public bool is_in_trie(string s)
        {
            bool res = false;
            Trie curr_trie = this;
            foreach (char c in s)
            {
                res = curr_trie.is_a_word;
                if (null != curr_trie.letters[c])
                {
                    curr_trie = curr_trie.letters[c];
                } else
                {
                    return false;
                }
            }
            return res;
        }*/
    }
}
