using System;

namespace Counting_unique_words
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter the path to the file");
            //C:\prj\Counting_unique_words\input.txt
            string PATH = Console.ReadLine();

            UniqueWords words = new UniqueWords();
            words.CountingUniqueWords(PATH);

            Console.ReadKey();
        }
    }
}
