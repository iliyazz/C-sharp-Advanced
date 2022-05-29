namespace WordCount
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Text.RegularExpressions;

    public class WordCount
    {
        static void Main()
        {
            string wordPath = @"..\..\..\Files\words.txt";
            string textPath = @"..\..\..\Files\text.txt";
            string outputPath = @"..\..\..\Files\output.txt";

            CalculateWordCounts(wordPath, textPath, outputPath);
        }

        public static void CalculateWordCounts(string wordsFilePath, string textFilePath, string outputFilePath)
        {
            List<string> words = new List<string>();
            ReadFromFile(textFilePath, words);
            List<string> wordsForIntersection = new List<string>();
            ReadFromFile(wordsFilePath, wordsForIntersection);
            Dictionary<string, int> wordCounts = new Dictionary<string, int>();
            foreach (var item1 in words)
            {
                foreach (var item2 in wordsForIntersection)
                {
                    if (item1 == item2)
                    {

                        if (wordCounts.ContainsKey(item1))
                        {
                            wordCounts[item1]++;
                        }
                        else
                        {
                            wordCounts.Add(item1, 1);
                        }
                    }
                }
            }
            StreamWriter writer = new StreamWriter(outputFilePath);
            using (writer)
            {
                foreach (var item in wordCounts.OrderByDescending(x => x.Value))
                {
                    writer.WriteLine($"{item.Key} - {item.Value}");
                }

            }
        }

        private static void ReadFromFile(string filePath, List<string> words)
        {
            using(StreamReader reader = new StreamReader(filePath))
            {
                Regex regex = new Regex(@"[A-Za-z']+");

                StringBuilder sb = new StringBuilder();
                string line = string.Empty;

                while ((line = reader.ReadLine()) != null)
                {
                    sb.Append(line);
                }
                MatchCollection matches = regex.Matches(sb.ToString());
                foreach (var item in matches)
                {
                    words.Add(item.ToString().ToLower());
                }
            }
        }
    }
}
