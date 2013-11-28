using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ZIvVS_lab4
{
    class DecodingNode
    {
        private String _message;
        private List<String> _dictionary;
        private List<String> _words;
        private List<int> _wordPos;
        private List<int> _noises;
        private bool _isSheet;

        private static StringBuilder _debug = new StringBuilder();

        public static String Debug
        {
            get
            {
                return _debug.ToString();
            }
        }

        private DecodingNode _parent;
        private List<DecodingNode> _children;

        public DecodingNode Parent
        {
            get
            {
                return _parent;
            }
        }
        public List<DecodingNode> Children
        {
            get
            {
                return _children;
            }
        }

        public DecodingNode(DecodingNode parent, String message, List<String> dictionary, List<String> words, List<int> wordPos, List<int> noises)
        {
            _message = message;
            _dictionary = dictionary;
            _words = words;
            _wordPos = wordPos;
            _noises = noises;

            _children = new List<DecodingNode>();
            _parent = parent;
        }

        public void FindAllWords(Dict dict)
        {
            if (_wordPos[_wordPos.Count - 1] == _message.Length)
            {
                _isSheet = true;
                return;
            }

            Stack<int> stack = new Stack<int>();
            stack.Push(_wordPos[_wordPos.Count - 1]);
            
            StringBuilder currentWord = new StringBuilder(); 
            while (stack.Count > 0)
            {
                int info = stack.Pop();
                bool findMatch = false;
                for (int noise = _noises[info] + 1; (noise < Math.Pow(2, dict.Size)) && !findMatch; noise++)
                {
                    char ch = dict.GetChar(DecodeUtils.AddNoise(DecodeUtils.ToBinary(noise, dict.Size), DecodeUtils.ToBinary(dict.GetCode(_message[info]), dict.Size)));
                    String word = _dictionary.Find(w => w.Equals(currentWord.ToString() + ch.ToString()));
                    if (word != null)
                    {
                        if (info != _message.Length - 1)
                        {
                            _noises[info] = noise;
                            _noises.Add(-1);
                            stack.Push(info);
                            stack.Push(info + 1);
                            currentWord.Append(ch);
                            findMatch = true;
                        }

                        List<String> newWords = new List<string>(_words);
                        newWords.Add(word);
                        List<int> newWordPos = new List<int>(_wordPos);
                        newWordPos.Add(info + 1);
                        _children.Add(new DecodingNode(this, _message, _dictionary, newWords, newWordPos, new List<int>(_noises)));

                        foreach (String str in _words)
                        {
                            _debug.Append(str + " ");
                        }
                        _debug.Append(word + System.Environment.NewLine);
                    }
                    else if (_dictionary.Any(w => DecodeUtils.StringStartsWith(w, currentWord.ToString() + ch.ToString())) && 
                        (info != _message.Length - 1))
                    {
                        _noises[info] = noise;
                        _noises.Add(-1);
                        stack.Push(info);
                        stack.Push(info + 1);
                        currentWord.Append(ch);
                        findMatch = true;

                        foreach (String str in _words)
                        {
                            _debug.Append(str + " ");
                        }
                        _debug.Append(currentWord.ToString() + System.Environment.NewLine);
                    }
                }
                if (!findMatch && currentWord.Length > 0)
                {
                    currentWord.Remove(currentWord.Length - 1, 1);
                    _noises.RemoveAt(_noises.Count - 1);
                }
            }
            if (_children.Count != 0)
            {
                foreach (DecodingNode node in _children)
                {
                    node.FindAllWords(dict);
                }
            }
        }

        public List<List<String>> GetResults()
        {
            if (_isSheet)
            {
                return new List<List<string>>() { _words };
            }
            else
            {
                List<List<String>> result = new List<List<string>>();
                foreach (DecodingNode node in _children)
                {
                    result.AddRange(node.GetResults());
                }
                return result;
            }
        }
    }
}
