using System;
using System.IO;
using static System.IO.File;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Linq;

namespace Counting_unique_words
{
    class UniqueWords : IDisposable
    {
        Dictionary<string, int> uniqueWords = new Dictionary<string, int> { };

        public void CountingUniqueWords(string PATH)
        {
            using (StreamReader sr = new StreamReader(PATH))
            {
                string line;

                while ((line = sr.ReadLine()) != null)
                {
                    line = Regex.Replace(line, @"\d+", "");
                    Regex regex = new Regex(@"\w+(-|')?\w*", RegexOptions.IgnoreCase);
                    MatchCollection words = regex.Matches(line);

                    foreach (object word in words)
                    {
                        if (uniqueWords.ContainsKey(word.ToString().ToLower()))
                        {
                            ++uniqueWords[word.ToString().ToLower()];
                        }
                        else
                        {
                            uniqueWords.Add(word.ToString().ToLower(), 1);
                        }
                    }
                }

                CreateFile();
            }
        }

        private void CreateFile()
        {
            CreateText("output.txt");

            SortWord();

            using (StreamWriter sw = new StreamWriter(@"C:\prj\Counting_unique_words\output.txt"))
            {
                foreach (KeyValuePair<string, int> keyValue in this.uniqueWords)
                {
                    sw.WriteLine(keyValue.Key + " - " + keyValue.Value);
                }
            }

            Console.WriteLine("Completed successfully");
        }

        public void SortWord()
        {

            Dictionary<string, int> sortedUniqueWords = new Dictionary<string, int> { };

            foreach (KeyValuePair<string, int> pair in uniqueWords.OrderByDescending(pair => pair.Value))
            {
                sortedUniqueWords.Add(pair.Key, pair.Value);
            }

            uniqueWords = sortedUniqueWords;
        }

        public void Dispose()
        {
            
        }
    }
}