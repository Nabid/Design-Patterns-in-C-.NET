using System;
using System.Collections.Generic;

namespace DesignPatternsUdemy.Flyweight
{
    public static class Exercise
    {
        public static void Demo()
        {
            var sentence = new Sentence("hello new world in visual studio");
            sentence[1].Capitalize = true;
            sentence[4].Capitalize = true;
            Console.WriteLine(sentence);
        }
    }

    public class Sentence
    {
        private string[] words;
        private Dictionary<int, WordToken> tokens = new Dictionary<int, WordToken>();

        public Sentence(string plainText)
        {
            words = plainText.Split(' ');
        }

        public WordToken this[int index]
        {
            get
            {
                WordToken wt = new WordToken();
                tokens.Add(index, wt);
                return tokens[index];
            }
        }

        public override string ToString()
        {
            var finalWords = new List<string>();
            for (var i = 0; i < words.Length; i++)
            {
                var word = words[i];
                if (tokens.ContainsKey(i) && tokens[i].Capitalize)
                {
                    word = word.ToUpperInvariant();
                }
                finalWords.Add(word);
            }
            return string.Join(" ", finalWords);
        }

        public class WordToken
        {
            public bool Capitalize;
        }
    }
}
