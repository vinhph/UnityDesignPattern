using System.Collections.Generic;
using System.Text;
using static System.Console;

namespace FlyweightCodingExercise
{
    public class Sentence
    {
        private Dictionary<int, WordToken> _formatting = new Dictionary<int, WordToken>();
        private readonly string _plainText;
        public Sentence(string plainText)
        {
            this._plainText = plainText;
        }

        public WordToken this[int index]
        {
            get
            {
                if (!_formatting.ContainsKey(index))
                {
                    _formatting.Add(index, new WordToken());
                }

                return _formatting[index];
            } 
            set
            {
                if (!_formatting.ContainsKey(index))
                {
                    _formatting.Add(index, new WordToken());
                }

                _formatting[index] = value;
            }
        }

        public override string ToString()
        {
            var sb = new StringBuilder();
            var plainTextArray = _plainText.Split(' ');

            for (var i = 0; i < plainTextArray.Length; i++)
            {
                var s = string.Empty;
                if (_formatting.ContainsKey(i) && _formatting[i].Capitalize)
                {
                    s = plainTextArray[i].ToUpper();
                }
                else
                {
                    s = plainTextArray[i];
                }
                sb.Append(s + " ");
            }

            return sb.ToString().TrimEnd(' ');
        }

        public class WordToken
        {
            public bool Capitalize;
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            var sentence = new Sentence("hello world");
            sentence[1].Capitalize = true;
            WriteLine(sentence);
            ReadLine();
        }
    }
}
