namespace OddLines
{
    using System.IO;
	
    public class OddLines
    {
        static void Main()
        {
            string inputFilePath = @"..\..\..\Files\input.txt";
            string outputFilePath = @"..\..\..\Files\output.txt";

            ExtractOddLines(inputFilePath, outputFilePath);
        }

        public static void ExtractOddLines(string inputFilePath, string outputFilePath)
        {
            StreamReader reader = new StreamReader(inputFilePath);
            using(reader)
            {
                StreamWriter writer = new StreamWriter(outputFilePath);
                using(writer)
                {
                    int lineNumberCounter = 0;
                    string line = string.Empty;
                    while ((line = reader.ReadLine()) != null)
                    {
                        if (lineNumberCounter % 2 == 1)
                        {
                            writer.WriteLine(line);
                        }
                        lineNumberCounter++;
                    }

                }
            }
        }
    }
}
