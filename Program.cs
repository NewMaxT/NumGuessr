using System;

namespace NumGuessr
{
    internal class Program
    {
        private struct Game
        {
            private string? _userInput;
            private int _randomNumber = 0;
            private int _playerGuess = 0;
            private int _lowerRandomNumber = 0;
            private int _upperRandomNumber = 0;
            private readonly Random _random;
            private bool _playAgain = false;
            private bool _errorState = false;

            private void Settings()
            {
                /*  INITIALISATION DES VARIABLES  */

                Console.WriteLine("- Settings -\n\n");

                Console.WriteLine("Choose the lowest number : \n");
                do
                {
                    if (_errorState)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine($"Please insert a correct number :");
                        Console.ForegroundColor = ConsoleColor.White;
                    }
                    _errorState = !int.TryParse(Console.ReadLine() ?? "", out _lowerRandomNumber);
                } while (_errorState);

                Console.WriteLine("Choose the highest number : \n");
                do
                {
                    if (_errorState)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine($"Please insert a correct number :");
                        Console.ForegroundColor = ConsoleColor.White;
                    }
                    _errorState = !int.TryParse(Console.ReadLine() ?? "", out _upperRandomNumber) || _upperRandomNumber < _lowerRandomNumber;
                } while (_errorState);

                Console.WriteLine("The game is now ready :)\n");
            }

            public void Play()
            {
                _randomNumber = _random.Next(_lowerRandomNumber, _upperRandomNumber);

                Console.WriteLine($"Insert a number ({_lowerRandomNumber}-{_upperRandomNumber}) :");
                do
                {
                    if (_errorState)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine($"Please insert a correct number between {_lowerRandomNumber} and {_upperRandomNumber} :");
                        Console.ForegroundColor = ConsoleColor.White;
                    }
                    _errorState = !int.TryParse(Console.ReadLine() ?? "", out _playerGuess) || (_playerGuess < _lowerRandomNumber || _playerGuess > _upperRandomNumber);
                } while (_errorState);

                if (_playerGuess == _randomNumber)
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine($"You WON ! The number was {_randomNumber}");
                    Console.ForegroundColor = ConsoleColor.White;
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine($"You LOST ! The number was {_randomNumber}");
                    Console.ForegroundColor = ConsoleColor.White;
                }

                Console.WriteLine("Try it again ?");
                Console.ForegroundColor = ConsoleColor.DarkGray;

                Console.WriteLine(" Any key for yes / N for No ");
                Console.ForegroundColor = ConsoleColor.White;

                _userInput = Console.ReadLine() ?? "";

                _playAgain = _userInput != "N" && _userInput != "n";
            }

            public readonly bool GetPlayState()
            {
                return _playAgain;
            }

            public Game(Random rnd)
            {
                _random = rnd;
                Settings();
            }
            public Game(Random rnd, int lowerRandomNumber, int upperRandomNumber)
            {
                _random = rnd;
                _lowerRandomNumber = lowerRandomNumber;
                _upperRandomNumber = upperRandomNumber;
            }
        }



        private static void Main(string[] args)
        {

            /*  GREETINGS  */

            Console.ForegroundColor = ConsoleColor.DarkGray; // Change la couleur du texte en Gris
            Console.WriteLine("\n--------------------------");
            Console.WriteLine("420-163-CH");
            Console.WriteLine("Programmation Structurée");
            Console.WriteLine("Nom : Maxence Goutteratel");
            Console.WriteLine("#DA : 2310020");
            Console.WriteLine("--------------------------\n");
            Console.ForegroundColor = ConsoleColor.White; // Change la couleur du texte en Blanc

            Game numGuessr = new(new Random());

            do
            {
                numGuessr.Play();
            } while (numGuessr.GetPlayState());

            Console.ForegroundColor = ConsoleColor.Blue; // Change la couleur du texte en Blanc
            Console.WriteLine("\nThanks for playing NumGuessr !");
        }
    }
}