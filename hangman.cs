using System;
using System.Text;

namespace hangmanlast
{
    class hangman
    {
        Random rand = new Random();

        int AmountofGuess;
        StringBuilder wrongLetters;
        char[] hiddenWord;
        string word;

        public hangman(int AmountOfGuesses, string[] wordList)
        {
            this.AmountofGuess = AmountOfGuesses;
            this.word = wordList[this.rand.Next(0, wordList.Length)];

            this.hiddenWord = new char[word.Length];

            for (int i = 0; i<word.Length; i++)
            {
                hiddenWord[i] = '_';
            }

            wrongLetters = new StringBuilder("", AmountOfGuesses);

        }
        public string StartRound()
        {
            Console.WriteLine("You have this many guesses left " + AmountofGuess.ToString());

            Console.WriteLine("Guessed letters");

            Console.WriteLine(hiddenWord);

            Console.WriteLine(wrongLetters);

            Console.Write("Enter a letter or a word: ");

            string Choice = Console.ReadLine();

            return Choice;
        }

        public void LetterGuess(char Choice)

        {

            bool newChar = true;

            for (int i = 0; i<hiddenWord.Length; i++)
            {
                if (hiddenWord[i]==Choice)
                {
                    newChar=false;
                }

            }

            if (newChar)
            {
                AmountofGuess -=1;

                wrongLetters.Append(Choice);


                for (int i = 0; i<word.Length; i++)
                {
                    if (word[i]==Choice)
                    {
                        hiddenWord[i]=Choice;
                    }

                }
            }



        }
        public bool WordGuess(string Choice)
        {
            AmountofGuess-=1;

            if (word==Choice)
            {
                Console.WriteLine("You won!");
                return false;
            }
            return true;
        }

        public bool WinCheck()
        {
            bool Cont = false;

            for (int i = 0; i<word.Length; i++)
            {
                if (word[i]!=hiddenWord[i])
                {
                    Cont=true;

                }


            }

            if (Cont==false)
            {
                Console.WriteLine("You win!");

            }


            else if (AmountofGuess>0)
            {
                Cont=true;

            }

            else
            {
                Console.WriteLine("You loose!");
                Cont=false;
            }


            return Cont;

        }

        public void StartAgainGame()
        {
            bool cont = true;
            while (cont)
            {
                string Choice = StartRound();

                if (Choice.Length==1)
                {
                    LetterGuess(Choice.ToCharArray()[0]);

                }
                else if (Choice.Length>1)
                {
                    cont=WordGuess(Choice);

                }

                if (cont)
                {
                    cont=WinCheck();
                }

            }

            Console.WriteLine("The correct word was: " + word.ToString());
        }


    }
}
