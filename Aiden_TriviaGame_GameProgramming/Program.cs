using System;
using System.Collections.Generic;
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
        static int PlayerScore = 0;

        static int QuestionNum = 1;

        static string[] questionsArray = new string[] { "Q1", "Q2", "Q3", "Q4", "Q5", "Q6", "Q7", "Q8", "Q9", "Q10" };

        static string[,] answersArray = new string[,] {
                                                        { "Q1A1", "Q1A2", "Q1A3", "Q1A4" },
                                                        { "Q2A1", "Q2A2", "Q2A3", "Q2A4" },
                                                        { "Q3A1", "Q3A2", "Q3A3", "Q3A4" },
                                                        { "Q4A1", "Q4A2", "Q4A3", "Q4A4" },
                                                        { "Q5A1", "Q5A2", "Q5A3", "Q5A4" },
                                                        { "Q6A1", "Q6A2", "Q6A3", "Q6A4" },
                                                        { "Q7A1", "Q7A2", "Q7A3", "Q7A4" },
                                                        { "Q8A1", "Q8A2", "Q8A3", "Q8A4" },
                                                        { "Q9A1", "Q9A2", "Q9A3", "Q9A4" },
                                                        { "Q10A1", "Q10A2", "Q10A3", "Q10A4" } };

        static string[] correctAnswersArray = new string[] { "1", "3", "2", "1", "4", "3", "1", "4", "2", "2" };

        static void Questions()
        {
            for (int i = 0; i < questionsArray.Length; i++)
            {
                Console.WriteLine(questionsArray[i]);

                Console.WriteLine($"\n1:{answersArray[i, 0]}");
                Console.WriteLine($"2:{answersArray[i, 1]}");
                Console.WriteLine($"3:{answersArray[i, 2]}");
                Console.WriteLine($"4:{answersArray[i, 3]}");

                Console.WriteLine("\nPlease Enter Your Answer: ");
                Console.SetCursorPosition(26, 7);
                PlayerInput = Console.ReadLine().ToUpper();

                if(PlayerInput.Length > 1 || !int.TryParse(PlayerInput, out int j))
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

            Console.Clear();
            Console.WriteLine($"{PlayerName}: {PlayerScore}/{questionsArray.Length}");
            Console.ReadKey();
        }
    }
}
