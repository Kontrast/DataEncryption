using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ZIvVS_lab4
{
    class Dict
    {
        private String _allChars = "abcdefghijklmnopqrstuvwxyzабвгдеёжзийклмнопрстуфхцчшщъыьэюя?!@#$";
        private int _size = 6;
        private Dictionary<char, int> _dictionary;

        public int Size
        {
            get
            {
                return _size;
            }
        }

        public Dict()
        {
            _dictionary = new Dictionary<char, int>();
            for (int i = 0; i < _allChars.Length; i++)
            {
                _dictionary.Add(_allChars[i], i);
            }
        }

        public char GetChar(int code)
        {
            return _allChars[code];
        }

        public int GetCode(char ch)
        {
            return _dictionary[ch];
        }
    }
}
