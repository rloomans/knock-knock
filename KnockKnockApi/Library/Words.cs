using System;
using System.Collections.Generic;

namespace KnockKnockApi.Library
{
    /// <summary>
    ///     Class for lists of words.
    /// </summary>
    public class Words
    {
        private const string WordSeparator = " ";
        
        private readonly List<string> _words = new List<string>();

        /// <summary>
        ///     Construct a Words instance from a string by splitting on spaces
        /// </summary>
        /// <param name="sentence">A sentence</param>
        public Words(string sentence)
        {
            if (string.IsNullOrEmpty(sentence)) return;

            foreach (var word in sentence.Split(WordSeparator)) _words.Add(word);
        }

        /// <summary>
        ///     Construct a Words instance from a sequence of strings
        /// </summary>
        /// <param name="words">A sequence of words</param>
        protected Words(IEnumerable<string> words)
        {
            _words.AddRange(words);
        }

        /// <summary>
        ///     Convert the word list to a string.
        /// </summary>
        /// <returns>string</returns>
        public override string ToString()
        {
            return string.Join(' ', _words);
        }

        /// <summary>
        ///     Creates a new Words instance with each word reversed.
        /// </summary>
        /// <returns>Words</returns>
        public Words ReverseWords()
        {
            var reversedWords = new List<string>();

            foreach (var word in _words) reversedWords.Add(_reverse(word));

            return new Words(reversedWords);
        }

        private static string _reverse(string s)
        {
            var chars = s.ToCharArray();
            Array.Reverse(chars);
            return new string(chars);
        }
    }
}