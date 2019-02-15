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

        public static string Encrypt(string s, string type, Int16 shift)
        {
            StringBuilder res = new StringBuilder(s);
            switch (type)
            {
                case "shift":
                    for (int i = 0; i < s.Length; i++)
                    {
                        res[i] = (char)((res[i] - ' ' + shift) % ('~' - ' ' + 1) + ' ');
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
                        int dec_int = (res[i] - ' ' - shift) % ('~' - ' ' + 1);
                        if (dec_int < 0) dec_int += ('~' - ' ' + 1);
                        dec_int += ' ';
                        res[i] = (char)dec_int;
                    }
                    break;
            }
            return res.ToString();
        }
    }

    class PassList
    {

        private Dictionary<String, Node> data;
        public ValueTuple<String, String, String> this[String s]
        {
            get
            {
                return data[s].data;
            }
            set
            {
                Node new_site = new Node()
                {
                    site = value.Item1,
                    data = (value.Item1, value.Item2, value.Item3)
                };
                data.Add(s, new_site);
            }
        }
    }
}
