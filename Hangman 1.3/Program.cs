﻿namespace Hangman_1._3
{
    internal class Program
    {
        static void Main(string[] args)
        {
            const int NUMBER_OF_CHANCES = 8;
            int Chances = NUMBER_OF_CHANCES;
            string[] Words = { "aircraft", "bootcamp", "pizzeria" };
            Random random = new Random();
            string WordToGUess = Words[random.Next(Words.Length)];
            //char[] GuessWord = new string('_', WordToGUess.Length).ToCharArray();
            //bool WordGuessed = true;

            char[] hiddenWord = new char[WordToGUess.Length];

            for (int i = 0; i < hiddenWord.Length; i++)
            {
                hiddenWord[i] = '_';
            }

            Console.WriteLine("Hello, let us play some Hangman \nI`m gonna choose a word, you try to guess it by choosing letters.");
            Console.WriteLine("\nChosen word is: " + new string(hiddenWord));
            Console.WriteLine("Remaining chances: " + Chances);
            Console.WriteLine("Ok, now, guess a letter");
            Console.WriteLine();
            Console.WriteLine("\n");

            while (Chances > 0)

            {
                char Guess = Console.ReadKey().KeyChar;

                List<char> AlreadyGuessedLetters = new List<char>();


                if (WordToGUess.Contains(Guess))
                {

                    for (int i = 0; i < WordToGUess.Length; i++)
                    {

                        if (WordToGUess[i] == Guess)
                        {
                            hiddenWord[i] = Guess;
                        }
                    }

                    Console.WriteLine("\n");
                    Console.WriteLine(hiddenWord);
                    Console.WriteLine("nice one, let`s go");
                    Console.WriteLine("\n");
                }

                else
                {
                    Chances--;
                    Console.WriteLine("\nWrong Letter, try another");
                    Console.WriteLine("Remaining chances: " + Chances);
                    AlreadyGuessedLetters.Add(Guess);
                   

                    if (AlreadyGuessedLetters.Contains(Guess))
                    {
                     Console.WriteLine("You guessed that one already");
                    }
                }
            }
        }
    }
}