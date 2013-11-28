using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ZIvVS_lab4
{
    class DecodeUtils
    {
        public static String Noisy(String message, Dict dict)
        {
            StringBuilder result = new StringBuilder();
            Random rand = new Random();
            foreach (char ch in message)
            {
                result.Append(dict.GetChar(AddNoise(ToBinary(dict.GetCode(ch), dict.Size), ToBinary(rand.Next(Convert.ToInt32(Math.Pow(2, dict.Size))), dict.Size))));
            }
            return result.ToString();
        }

        public static char AddNoise(List<bool> ch, List<bool> noise)
        {
            for (int i = 0; i < ch.Count; i++)
            {
                ch[i] ^= noise[i];
            }
            return Convert.ToChar(ToInt(ch));
        }

        public static List<bool> ToBinary(int number, int length)
        {
            List<bool> bin = new List<bool>();
            int n = number;
            for (int i = 0; i < length; i++)
            {
                bin.Add((n % 2) == 1);
                n /= 2;
            }
            return bin;
        }

        public static int ToInt(List<bool> bin)
        {
            int result = 0;
            for (int i = bin.Count - 1; i >= 0; i--)
            {
                result *= 2;
                result += (bin[i] ? 1 : 0);
            }
            return result;
        }

        public static String ToBinaryString(int number, int length)
        {
            StringBuilder sb = new StringBuilder();
            int n = number;
            for (int i = 0; i < length; i++)
            {
                sb.Append((n % 2).ToString());
                n /= 2;
            }
            return sb.ToString();
        }

        public static bool StringStartsWith(String str, String prefix)
        {
            if (str.Length < prefix.Length)
            {
                return false;
            }
            for (int i = 0; i < prefix.Length; i++)
            {
                if (Convert.ToInt32(str[i]) != Convert.ToInt32(prefix[i]))
                {
                    return false;
                }
            }
            return true;
        }
    }
}
