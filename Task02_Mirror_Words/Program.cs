using System;
using System.Text.RegularExpressions;
using System.Collections.Generic;
using System.Linq;

namespace Task02_Mirror_Words
{
    class Program
    {
        static void Main(string[] args)
        {
            string patern = @"(@|#)([A-Z|a-z]{3,})\1\1([A-Z|a-z]{3,})\1";

            Regex findHiddenWords = new Regex(patern);

            string text = Console.ReadLine();

            MatchCollection hiddenWords = findHiddenWords.Matches(text);

            if(hiddenWords.Count == 0)
            {
                Console.WriteLine("No word pairs found!");
                Console.WriteLine("No mirror words!");
            }
            else
            {
                Console.WriteLine($"{hiddenWords.Count} word pairs found!");
                int mirrorWordCounter = 0;
                List<string> mirrorWords = new List<string>();

                foreach (Match element in hiddenWords)
                    {
                        string wordOne = element.Groups[2].ToString();
                        string wordTwo = element.Groups[3].ToString();
                        string mirrorWordTwo = new string(wordTwo.Reverse().ToArray());
                        
                        //s = new string(s.Reverse().ToArray());

                        //Console.WriteLine($"{wordOne} <-> {wordTwo}");

                        if(wordOne == mirrorWordTwo)
                        {
                            mirrorWords.Add(new string(wordOne + " <=> " + wordTwo));

                            mirrorWordCounter++;

                        }
                    }

                if(mirrorWords.Count == 0)
                {
                    Console.WriteLine("No mirror words!");
                }
                else
                {
                    Console.WriteLine("The mirror words are:");
                    Console.WriteLine(string.Join(", ", mirrorWords));
                }

            }
        }
    }
}
