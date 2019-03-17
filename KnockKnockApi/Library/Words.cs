using System;
using System.Collections.Generic;

namespace KnockKnockApi.Library
{
    public class Words
    {
        private List<string> _words = new List<string>();

        public Words(string sentence) {
            if (!String.IsNullOrEmpty(sentence)) {
                foreach(var word in sentence.Split(" ")) {
                    _words.Add(word);
                }
            }
        }

        protected Words(List<string> words) {
            _words.AddRange(words);
        }

        public string ToString() 
        {
            return String.Join(' ', _words);
        }

        public Words ReverseWords() {
            var reversed_words = new List<string>();

            foreach (var word in _words) {
                reversed_words.Add(Reverse(word));
            }

            return new Words(reversed_words);
        }

        public static string Reverse(string s)
        {
            char[] chars = s.ToCharArray();
            Array.Reverse(chars);
            return new string(chars);
        }
    }
}
