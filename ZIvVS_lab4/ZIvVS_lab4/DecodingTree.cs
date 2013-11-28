using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ZIvVS_lab4
{
    class DecodingTree
    {
        private DecodingNode _root;

        private DecodingTree(String message, List<String> dictionary, Dict dict)
        {
            _root = new DecodingNode(null, message, dictionary, new List<string>(), new List<int>() { 0 }, new List<int>() { -1 });
            _root.FindAllWords(dict);
        }

        public static List<List<String>> DecodeMessage(String message, List<String> dictionary, Dict dict)
        {
            DecodingTree tree = new DecodingTree(message, dictionary, dict);
            return tree.GetResults();
        }

        private List<List<String>> GetResults()
        {
            return _root.GetResults();
        }

        public static String GetDebug()
        {
            return DecodingNode.Debug;
        }
    }
}
