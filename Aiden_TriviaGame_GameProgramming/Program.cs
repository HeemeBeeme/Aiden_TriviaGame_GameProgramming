using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Aiden_TriviaGame_GameProgramming
{
    internal class Program
    {
        static string PlayerInput;
        static string PlayerName;
        static string PlayerScoreStatus;
        static int PlayerScore = 0;

        static string[] questionsArray = new string[] { "What Is A String?",
                                                        "How Do You Write \"Hello World\" In The C# Console?",
                                                        "What Is A Comment?",
                                                        "What Is Void Used For In A C# Method?",
                                                        "What Is C#?",
                                                        "What Is A Method?",
                                                        "What Is An Int?",
                                                        "What Is A Float?",
                                                        "How Do You Write An Int Tuple In C#?",
                                                        "What Is String.Length?" };

        static string[,] answersArray = new string[,] {
                                                        { "A Sequence Of Characters", "A Single Character", "A Number", "That Stuff On Guitars" },
                                                        { "System.out.println(\"Hello World\");", "printf(\"Hello World\");", "Console.WriteLine(\"Hello World\")", "print(\"Hello World\")" },
                                                        { "A Value", "A Line(s) Within Code That Is Ignored", "A List Of Numbers", "A Method" },
                                                        { "The Return Type", "A Variable Type", "Another Term For Null", "The Blank Space Between Lines Of Code" },
                                                        { "A Computer Company", "A Coding Application", "A Variable Type", "A Coding Language" },
                                                        { "A String Used For Storing Numbers", "Another Term For Class", "A Code Block That Contains A Series Of Statements", "A Way Of Doing Things" },
                                                        { "A Variable Type Used To Store Whole Numbers", "A Variable Type Used To Store Decimal Numbers", "A List Of Numbers", "A Class" },
                                                        { "A Type Of String", "A Variable Type Used To Store Characters", "A Method To Skip Lines Of Code", "A Variable Type Used To Store Decimal Numbers" },
                                                        { "Tuple(int)(int)", "(int, int)", "int, int", "Tuple.((int)(int))" },
                                                        { "A List Of Strings", "The Amount Of Characters In A String", "The Amount Of Words In A String", "An Amount Of Numbers Within A String" } };

        static string[] correctAnswersArray = new string[] { "1", "3", "2", "1", "4", "3", "1", "4", "2", "2" };

        static void PlayAgain()
        {
            Console.WriteLine("Would You Like To Play Again?\n");
            Console.WriteLine("Y/N:");
            Console.CursorVisible = true;
            Console.SetCursorPosition(5, 2);

            PlayerInput = Console.ReadLine().ToUpper();

            if(PlayerInput == "Y")
            {
                Console.Clear();
                PlayerScore = 0;
                Menu();
            }
            else if(PlayerInput == "N")
            {
                Environment.Exit(0);
            }
            else if(PlayerInput == "MAYBE")
            {
                Console.CursorVisible = false;
                Console.Clear();
                Console.WriteLine("Get Out");
                Thread.Sleep(1000);
                Console.Clear();
                Console.WriteLine("Get Out.");
                Thread.Sleep(1000);
                Console.Clear();
                Console.WriteLine("Get Out..");
                Thread.Sleep(1000);
                Console.Clear();
                Console.WriteLine("Get Out...");
                Thread.Sleep(1000);
                Environment.Exit(0);
            }
            else
            {
                Console.Clear();
                Console.WriteLine("Your Input Was Invalid!\n\nPlease Try Again!\n\nPress Any Key...");
                Console.ReadKey();
                PlayAgain();
            }
        }

        static void DisplayScore()
        {
            ConsoleColor(System.ConsoleColor.Gray);

            if (PlayerScore == 10)
            {
                PlayerScoreStatus = "You Must Be a Genious!";
            }
            else if (PlayerScore == 9)
            {
                PlayerScoreStatus = "Oh Man! So Close! I Believe In You!";
            }
            else if (PlayerScore == 8)
            {
                PlayerScoreStatus = "Wow, You Did GREAT! You're Almost There!";
            }
            else if (PlayerScore >= 7)
            {
                PlayerScoreStatus = "Hey! Keep To It And You'll Be A Pro In No Time!";
            }
            else if (PlayerScore >= 4)
            {
                PlayerScoreStatus = "You're Getting There, Just A Little More Work!";
            }
            else if (PlayerScore >= 0)
            {
                PlayerScoreStatus = "Oh Uh... Better Luck Next Time?";
            }

            ConsoleColor(System.ConsoleColor.Green);
            Console.Write($"{PlayerName}! ");
            ConsoleColor(System.ConsoleColor.Gray);
            Console.Write($"Your Score Was: ");
            ConsoleColor(System.ConsoleColor.Yellow);
            Console.Write($"{PlayerScore}/{questionsArray.Length}!\n\n");
            ConsoleColor(System.ConsoleColor.Gray);
            Console.WriteLine(PlayerScoreStatus);
            Console.WriteLine("\nPress Any Key...");
            Console.CursorVisible = false;
            Console.ReadKey();
            Console.Clear();
            PlayAgain();
        }

        static void ConsoleColor(ConsoleColor consoleColor)
        {
            Console.ForegroundColor = consoleColor;
        }

        static void HUD(int QuestionNum)
        {
            ConsoleColor(System.ConsoleColor.Green);
            Console.WriteLine($"{PlayerName}");
            ConsoleColor(System.ConsoleColor.Yellow);
            Console.Write($"Score: {PlayerScore}");
            ConsoleColor(System.ConsoleColor.Gray);
            Console.Write($", Question: {QuestionNum + 1}/{questionsArray.Length}\n\n");
        }

        static void Questions()
        {
            for (int i = 0; i < questionsArray.Length; i++)
            {
                HUD(i);

                ConsoleColor(System.ConsoleColor.Gray);
                Console.WriteLine(questionsArray[i]);

                ConsoleColor(System.ConsoleColor.Cyan);
                Console.WriteLine($"\n1:{answersArray[i, 0]}");
                Console.WriteLine($"2:{answersArray[i, 1]}");
                Console.WriteLine($"3:{answersArray[i, 2]}");
                Console.WriteLine($"4:{answersArray[i, 3]}");

                ConsoleColor(System.ConsoleColor.Gray);
                Console.WriteLine("\nPlease Enter Your Answer: ");
                Console.SetCursorPosition(26, 10);
                ConsoleColor(System.ConsoleColor.Cyan);
                PlayerInput = Console.ReadLine().ToUpper();

                if(PlayerInput.Length > 1 || !int.TryParse(PlayerInput, out int j) || int.Parse(PlayerInput) > 4 || int.Parse(PlayerInput) < 1)
                {
                    i--;
                }
                else if(PlayerInput == correctAnswersArray[i])
                {
                    PlayerScore++;
                }

                Console.Clear();
            }
        }

        static void Menu()
        {
            Console.WriteLine("Please Enter Your Name:");
            Console.SetCursorPosition(24, 0);
            PlayerName = Console.ReadLine().ToUpper();

            Console.Clear();
            Questions();
        }

        static void Main(string[] args)
        {
            Menu();
            DisplayScore();
        }
    }
}
