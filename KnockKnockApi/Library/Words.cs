using System;
using System.Collections.Generic;

namespace KnockKnockApi.Library
{
    /// <summary>
    /// Class for lists of words.
    /// </summary>
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

        public override string ToString() 
        {
            return String.Join(' ', _words);
        }

        /// <summary>
        /// Creates a new Words instance with each word reversed.
        /// </summary>
        /// <returns>Words</returns>
        public Words ReverseWords() {
            var reversed_words = new List<string>();

            foreach (var word in _words) {
                reversed_words.Add(_reverse(word));
            }

            return new Words(reversed_words);
        }

        private static string _reverse(string s)
        {
            char[] chars = s.ToCharArray();
            Array.Reverse(chars);
            return new string(chars);
        }
    }
}
