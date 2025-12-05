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

        static string[] questionsArray = new string[] { "What Is A String?", "How Do You Write \"Hello World\" In The Console?", "What Is A Comment?", "What Is Void Used For In A Method?", "Q5", "Q6", "Q7", "Q8", "Q9", "Q10" };

        static string[,] answersArray = new string[,] {
                                                        { "A Sequence Of Characters", "A Single Character", "A Number", "That Stuff On Guitars" },
                                                        { "System.out.println(\"Hello World\");", "printf(\"Hello World\");", "Console.WriteLine(\"Hello World\")", "print(\"Hello World\")" },
                                                        { "A Value", "A Line(s) Within Code That Is Ignored", "A List Of Numbers", "A Method" },
                                                        { "The Return Type", "A Variable Type", "Another Term For Null", "The Blank Space Between Lines Of Code" },
                                                        { "Q5A1", "Q5A2", "Q5A3", "Q5A4" },
                                                        { "Q6A1", "Q6A2", "Q6A3", "Q6A4" },
                                                        { "Q7A1", "Q7A2", "Q7A3", "Q7A4" },
                                                        { "Q8A1", "Q8A2", "Q8A3", "Q8A4" },
                                                        { "Q9A1", "Q9A2", "Q9A3", "Q9A4" },
                                                        { "Q10A1", "Q10A2", "Q10A3", "Q10A4" } };

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

            Console.WriteLine($"{PlayerName}! Your Score Was: {PlayerScore}/{questionsArray.Length}!\n");
            Console.WriteLine(PlayerScoreStatus);
            Console.WriteLine("\nPress Any Key...");
            Console.CursorVisible = false;
            Console.ReadKey();
            Console.Clear();
            PlayAgain();
        }

        static void HUD(int QuestionNum)
        {
            Console.WriteLine($"{PlayerName}: {PlayerScore}, Question: {QuestionNum + 1}\n");
        }

        static void Questions()
        {
            for (int i = 0; i < questionsArray.Length; i++)
            {
                HUD(i);

                Console.WriteLine(questionsArray[i]);

                Console.WriteLine($"\n1:{answersArray[i, 0]}");
                Console.WriteLine($"2:{answersArray[i, 1]}");
                Console.WriteLine($"3:{answersArray[i, 2]}");
                Console.WriteLine($"4:{answersArray[i, 3]}");

                Console.WriteLine("\nPlease Enter Your Answer: ");
                Console.SetCursorPosition(26, 9);
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
