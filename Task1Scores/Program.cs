using System;
using System.Collections;
using System.Data;

namespace Task1Scores
{
    class Program
    {   
        public class myComparer : IComparer
        {
            int IComparer.Compare(Object xx, Object yy)
            {
                Student x = (Student)xx;
                Student y = (Student)yy;
                return y.Score.CompareTo(x.Score);
            }
        }
        
        static void Main(string[] args)
        { 
            TermScore();
            Console.ReadKey();
        }

        static public int TestScore(int score)
        {
            int testInPercent= 0;

            if (score > 30 || score < 0)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("C.A SCORE CAN'T BE GREATER THAN 30 OR LESS THAN 0");
                Console.ResetColor();
            }
            else
            {
                testInPercent = score;

            }
            return testInPercent;

        }
         static public int ExamScore(int score)
         {
            int testInPercent = 0;
            if (score > 70 || score < 0)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("EXAM SCORE CAN'T BE GREATER THAN 70 OR LESS THAN 0");
                Console.ResetColor();

            }
            else
            {
                testInPercent = score;

            }
             return testInPercent;




         }

        static public void TermScore()
        {
            bool incorrect = true;

            ArrayList EndofTerm = new ArrayList();
            bool arrayLenght = true;

            while(incorrect){
                int minInClass = 3;
                int maxInClass = 4;

                try
                {
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine("WELCOME TO FORCADOES HIGH SCHOOL");
                    Console.ResetColor();

                    Console.WriteLine("Input the number of student in your class");
                    int studentVol = Convert.ToInt32(Console.ReadLine());

                    if (studentVol >= minInClass && studentVol <= maxInClass)
                    {
                        while (arrayLenght)
                        {
                            if (EndofTerm.Count < studentVol)
                            {
                                Console.WriteLine("Input Student Name");
                                string studentName = Console.ReadLine();

                                Console.WriteLine($"Input {studentName} C.A Score");
                                int studentCA = Convert.ToInt32(Console.ReadLine());

                                Console.WriteLine($"Input {studentName} Exam Score");
                                int studentExam = Convert.ToInt32(Console.ReadLine());
                                Console.Clear();
                                int test = TestScore(studentCA);
                                int exam = ExamScore(studentExam);

                                float studTermScore = test + exam / 100f * 100;

                                // string studFinalSocre = $"{studentName} is {studTermScore}%";

                                EndofTerm.Add(new Student(studentName, (int)studTermScore));


                            }
                            else if (EndofTerm.Count == studentVol)
                            {
                                arrayLenght = false;
                            }

                        }
                        incorrect = false;
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine($"Sorry! you can not have more than {maxInClass} in a class or less than {minInClass}");
                        Console.WriteLine("PRESS ANY KEY TO CONTINUE :)");
                        Console.ResetColor();
                        Console.ReadKey();
                        Console.Clear();

                    }
                }
                catch (System.FormatException)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine(":( Sorry! Input can not be a letter or a special character");
                    Console.WriteLine("PRESS ANY KEY TO CONTINUE :)");
                    Console.ResetColor();
                    Console.ReadKey();
                    Console.Clear();
                    continue;
                }

               
            }

            EndofTerm.Sort(new myComparer());

            int positionIndex = 0;
            foreach (Student item in EndofTerm)
            {
                // Console.WriteLine("\n");
                if (positionIndex == 0)
                {
                    Console.WriteLine($"{++positionIndex}st Position --> Name: {item.Name} -->> Score: {item.Score}%");

                }
                else if (positionIndex == 1)
                {
                    Console.WriteLine($"{++positionIndex}nd Position --> Name: {item.Name} -->> Score: {item.Score}%");

                }
                else if (positionIndex == 2)
                {
                    Console.WriteLine($"{++positionIndex}rd Position --> Name: {item.Name} -->> Score: {item.Score}%");
                }
                else
                {
                    Console.WriteLine($"{++positionIndex} --> Name: {item.Name} -->> Score: {item.Score}%");
                }
                
            }

        }






    }
}
