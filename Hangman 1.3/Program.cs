using System.Collections.Frozen;

namespace Hangman_1._3
{
    internal class Program
    {
        static void Main(string[] args)
        {
            const int NUMBER_OF_CHANCES = 8;
            int Chances = NUMBER_OF_CHANCES;
            string[] Words = { "aircraft", "bootcamp", "pizzeria" };
            Random random = new Random();
            string wordToGuess = Words[random.Next(Words.Length)];

            char[] hiddenWord = new char[wordToGuess.Length];

            for (int i = 0; i < hiddenWord.Length; i++)
            {
                hiddenWord[i] = '_';
            }
            
            Console.WriteLine("Hello, let us play some Hangman \nI`m gonna choose a word, you try to guess it by choosing letters.");
            Console.WriteLine("\nChosen word is: ");

            for (int i = 0; i < hiddenWord.Length; i++)
            {
                Console.Write(" _");
                
            }

            Console.WriteLine("\n");
            Console.WriteLine("Remaining chances: " + Chances);
            Console.WriteLine("Ok, now, guess a letter");
            Console.WriteLine();
            Console.WriteLine("\n");
            List<char> wrongLettersGuessed = new List<char>();
            List<char> lettersGuessed = new List<char>();


            while (Chances > 0)
            {
                char Guess = Console.ReadKey().KeyChar;

                if (!char.IsLetter(Guess))
                {
                    Console.WriteLine("\nInvalid input. Please enter a letter of the alphabet.");
                    continue;
                }

                if (wrongLettersGuessed.Contains(Guess))
                {
                    Console.WriteLine("\nYou guessed that one already");
                    continue;
                }

                if (lettersGuessed.Contains(Guess))
                {
                    Console.WriteLine("\nYou guessed that one already");
                    continue;
                }

                if (wordToGuess.Contains(Guess))
                {
                    for (int i = 0; i < wordToGuess.Length; i++)
                    {
                        if (wordToGuess[i] == Guess)
                        {
                            hiddenWord[i] = Guess;
                        }
                    }

                    Console.WriteLine("\n");
                    Console.WriteLine(hiddenWord);
                    Console.WriteLine("nice one, let`s go");
                    Console.WriteLine("\n");
                    lettersGuessed.Add(Guess);
                }
                else
                {
                    Chances--;
                    Console.WriteLine("\nWrong Letter, try another");
                    Console.WriteLine("Remaining chances: " + Chances + "\n");
                    wrongLettersGuessed.Add(Guess);
                }

             

                if (new string(hiddenWord) == wordToGuess) 
                {
                    Console.WriteLine("Well done mate, you got the word right! " + wordToGuess.ToUpper());
                    break;
                }
            }

            if (Chances == 0) 
            {
                Console.WriteLine("Ooops...You run out of chances, you are HANG. hehe. \n");
            }
        }
    }
}