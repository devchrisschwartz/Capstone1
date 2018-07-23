using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Week1Capstone
{
    class Program
    {
        static void Main(string[] args)
        {

            Console.WriteLine("Welcome to the Pig Latin translator!");

            string userInput;

            char[] numbers = "1234567890".ToCharArray();
            char[] specialChars = "!@#$%^&*()".ToCharArray();
            char[] punctuation = { '!', '?', ',', '.' };
            char[] vowels = { 'a', 'e', 'i', 'o', 'u', 'A', 'E', 'I', 'O', 'U' };

            string userChoice = "y";

            while (userChoice.ToLower() == "y")
            {
                Console.Write("Please enter a sentence to be translated: ");
                userInput = Console.ReadLine();

                int firstVowel = userInput.IndexOfAny(vowels);
                string[] words = userInput.Split(' ');


                for (int i = 0; i < words.Length; i++)
                {
                    if (EndsWithPunctuation(words[i].ToLower(), punctuation) == true)
                    {
                        string punc;
                        punc = words[i].Substring(words[i].Length - 1, 1);

                        words[i] = words[i].Remove(words[i].Length - 1, 1);

                        Console.Write(Translation(words[i], vowels, firstVowel));

                        Console.Write(punc + " ");
                    }
                    else if (words[i].IndexOfAny(numbers) >= 0)
                    {
                        Console.Write(words[i] + " ");
                    }
                    else if (words[i].IndexOfAny(specialChars) >= 0)
                    {
                        Console.Write(words[i] + " ");
                    }
                    else
                    {
                        Console.Write(Translation(words[i], vowels, firstVowel) + " ");
                    }
                }
                Console.WriteLine("");
                Console.Write("Would you like to translate another sentence? (y/n): ");
                userChoice = Console.ReadLine();
            }
            Console.ReadKey();
        }

        public static bool StartsWithVowel(string input, char[] vowels)
        {
            if (input.IndexOfAny(vowels) == 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public static string Translation(string input, char[] vowelChars, int number)
        {
            if (ContainsVowels(input, vowelChars) == true)
            {
                if (StartsWithVowel(input, vowelChars) == true)
                {
                    if (IsAllUpper(input) == true)
                    {
                        return input = input + "WAY";
                    }
                    else if (IsTitleCase(input) == true)
                    {
                        input = input.ToLower();
                        return input = char.ToUpper(input[0]) + input.Substring(1) + "way";
                    }
                    else
                    {
                        return input = input + "way";
                    }
                }
                else
                {
                    if (IsAllUpper(input) == true)
                    {
                        return input = input.Substring(number) + input.Substring(0, number) + "AY";
                    }
                    else if (IsTitleCase(input) == true)
                    {
                        input = input.ToLower();
                        return input = char.ToUpper(input[number]) + input.Substring(number+1) + input.Substring(0, number) + "ay";
                        
                    }
                    else
                    {
                        return input = input.Substring(number) + input.Substring(0, number) + "ay";
                    }
                }
            }
            else
            {
                if (IsAllUpper(input) == true)
                {
                    return input = input + "WAY";
                }
                else if (IsTitleCase(input) == true)
                {
                    input = input.ToLower();
                    return input = char.ToUpper(input[0]) + input.Substring(1) + "way";
                }
                else
                {
                    return input = input + "way";
                }
            }
            
        }

        public static bool IsAllUpper(string input)
        {
            for (int i = 0; i < input.Length; i++)
            {
                if (Char.IsLetter(input[i]) && !Char.IsUpper(input[i]))
                {
                    return false;
                }
            }
            return true;
        }

        public static bool ContainsVowels(string input, char[] vowels)
        {
            if (input.IndexOfAny(vowels) >= 0)
            {
                return true;
            }
            return false;
        }

        public static bool EndsWithPunctuation(string input, char[] punctuation)
        {
            if (input.IndexOfAny(punctuation) == input.Length - 1)
            {
                return true;
            }
            return false;
        }

        public static bool IsTitleCase(string input)
        {
            if (char.IsUpper(input[0]) == true && char.IsUpper(input[1]) == false)
            {
                return true;
            }
            return false;
        }

        public static string ToTitleCase(string input)
        {
            if (input == null)
            {
                return null;
            }
            if (input.Length > 1)
            { 
                return char.ToUpper(input[0]) + input.Substring(1);
            }
            return input.ToUpper();
        }
    }
}
