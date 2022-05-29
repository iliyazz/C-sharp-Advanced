namespace MergeFiles
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    public class MergeFiles
    {
        static void Main()
        {
            var firstInputFilePath = @"..\..\..\Files\input1.txt";
            var secondInputFilePath = @"..\..\..\Files\input2.txt";
            var outputFilePath = @"..\..\..\Files\output.txt";

            MergeTextFiles(firstInputFilePath, secondInputFilePath, outputFilePath);
        }

        public static void MergeTextFiles(string firstInputFilePath, string secondInputFilePath, string outputFilePath)
        {

            StreamReader reader1 = new StreamReader(firstInputFilePath);
            StreamReader reader2 = new StreamReader(secondInputFilePath);
            using (reader1)
            {
                using (reader2)
                {
                    StreamWriter writer = new StreamWriter(outputFilePath);
                    using (writer)
                    {
                        string command1 = reader1.ReadLine();
                        string command2 = reader2.ReadLine();
                        while (true)
                        {
                            if (command1 != null)
                            {
                                writer.WriteLine(command1);
                                command1 = reader1.ReadLine();
                            }
                            if (command2 != null)
                            {
                                writer.WriteLine(command2);
                                command2 = reader2.ReadLine();
                            }
                            if (command1 == null)
                                if( command2 == null)
                            {
                                break;
                            }
                        }
                    }
                }
            }
        }
    }
}
