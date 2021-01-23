using System;
using System.Text;
using System.Linq;

namespace Task01_Secret_Chat
{
    class Program
    {
        static void Main(string[] args)
        {
            string codeMessage = Console.ReadLine();

            while (true)
            {
                string[] comand = Console.ReadLine().Split(":|:", StringSplitOptions.RemoveEmptyEntries).ToArray();

                if(comand[0].ToUpper() == "REVEAL")
                {
                    break;
                }

                string typeComand = comand[0].ToUpper();

                switch (typeComand)
                {
                    case "INSERTSPACE":
                        
                        int index = int.Parse(comand[1]);
                        codeMessage = codeMessage.Insert(index, " ");

                        Console.WriteLine(codeMessage);

                        break;

                    case "REVERSE":

                        string substring = comand[1];
                        if(codeMessage.Contains(substring))
                        {
                            int helpIndex = codeMessage.IndexOf(substring);
                            codeMessage = codeMessage.Replace(substring, string.Empty);
                            string reverseSubstring = string.Empty;

                            for (int i = substring.Length - 1; i >= 0; i--)
                            {
                                reverseSubstring = reverseSubstring + substring[i];
                            }

                            codeMessage = codeMessage + reverseSubstring;

                            Console.WriteLine(codeMessage);
                        }
                        else
                        {
                            Console.WriteLine("error");
                        }

                        break;

                    case "CHANGEALL":

                        substring = comand[1];
                        string replacement = comand[2];

                        while (codeMessage.Contains(substring))
                        {
                            codeMessage = codeMessage.Replace(substring, replacement);
                        }

                        Console.WriteLine(codeMessage);

                        break;

                    default:
                        break;
                }
            }
            
            Console.WriteLine($"You have a new text message: {codeMessage}");
        }
    }
}
