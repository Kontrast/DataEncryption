using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ZIvVS_lab4
{
    public partial class MainForm : Form
    {
        //private List<String> _dictionary = new List<string>() { "how", "go", "street", "while", "for", "walk"};
        private List<String> _dictionary = new List<string>() { "птица", "сидит", "под", "куст", "кустом", "дождь" };

        public MainForm()
        {
            InitializeComponent();
        }

        private void textBoxNewWord_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {
                String newWord = textBoxNewWord.Text.ToLower().Replace(" ", "");
                if (!_dictionary.Contains(newWord))
                {
                    _dictionary.Add(newWord);
                    textBoxNewWord.Text = "";
                    RedrawDictionary();
                }
            }
        }

        private void RedrawDictionary()
        {
            StringBuilder sb = new StringBuilder();
            foreach (String word in _dictionary)
            {
                sb.Append(word + ";" + System.Environment.NewLine);
            }
            textBoxDictionary.Text = sb.ToString();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            textBoxMessage.Focus();
            RedrawDictionary();
        }

        private void textBoxMessage_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {
                Dict dict = new Dict();

                String message = textBoxMessage.Text.ToLower().Replace(" ", "");
                String noisy = DecodeUtils.Noisy(message, dict);
                textBoxNoisy.Text = noisy;

                StringBuilder sb = new StringBuilder();
                foreach (List<String> str in DecodingTree.DecodeMessage(noisy, _dictionary, dict))
                {
                    foreach (String word in str)
                    {
                        sb.Append(word + " ");
                    }
                    sb.Append(";" + System.Environment.NewLine);
                }
                textBoxResult.Text = sb.ToString();

                textBoxDebug.Text = DecodingTree.GetDebug();
            }
        }
    }
}
