using System;
using System.Collections;

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
                    throw new Exception();
                }
                else
                {
                    testInPercent = score;
                }

            
            return testInPercent;

        }
         static public int ExamScore(int score)
         {
            int examInPercent = 0;

                if (score > 70 || score < 0)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("EXAM SCORE CAN'T BE GREATER THAN 70 OR LESS THAN 0");
                    Console.ResetColor();
                    throw new Exception();
                }
                else
                {
                    examInPercent = score;

                }
             return examInPercent;

         }

        static public void TermScore()
        {
            bool incorrect = true;

            int studentVol = 0;
            ArrayList EndofTerm = new ArrayList();
            bool arrayLenght = true;

            while(incorrect){
                int minInClass = 30;
                int maxInClass = 35;

                try
                {
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine("WELCOME TO FORCADOES HIGH SCHOOL");
                    Console.ResetColor();

                    Console.WriteLine("Input the number of students in your class");
                    studentVol = Convert.ToInt32(Console.ReadLine());

                    if (studentVol >= minInClass && studentVol <= maxInClass)
                    {
                        while (arrayLenght)
                        {
                            if (EndofTerm.Count < studentVol)
                            {
                              int exam = 0;
                              int test = 0;
                              if (EndofTerm.Count > 0)
                              {
                                    if (EndofTerm.Count == 1)
                                    {
                                        Console.ForegroundColor = ConsoleColor.Blue;
                                        Console.WriteLine($"({EndofTerm.Count} student saved) {EndofTerm.Count} of {studentVol} \n");
                                        Console.ResetColor();
                                    }
                                    else
                                    {
                                        Console.ForegroundColor = ConsoleColor.Blue;
                                        Console.WriteLine($"({EndofTerm.Count} students saved) {EndofTerm.Count} of {studentVol} \n");
                                        Console.ResetColor();
                                    }
                              }

                                string studentName;


                                while (true)
                                {
                                  Console.WriteLine("Input Student's Name");
                                  studentName = Console.ReadLine();
                                    if (string.IsNullOrEmpty(studentName) || studentName == " ")
                                    {
                                        Console.ForegroundColor = ConsoleColor.Red;
                                        Console.WriteLine("Student Name can't be empty!");
                                        Console.ResetColor();
                                    }
                                    else
                                    {
                                        break;
                                    }

                                }


                                while (true)
                                {
                                    try
                                    {
                                        Console.WriteLine($"\nInput {studentName} C.A Score");
                                        int numb;

                                        while (true)
                                        {
                                            string studentCA = Console.ReadLine();
                                            if (int.TryParse(studentCA, out numb))
                                            {
                                               test = TestScore(numb);
                                               break;

                                            }
                                            else
                                            {
                                                Console.ForegroundColor = ConsoleColor.Red;
                                                Console.WriteLine("Input Must be a Number");
                                                Console.ResetColor();
                                            }

                                        }
                                        
                                    }
                                    catch (Exception)
                                    {
                                        continue;
                                    }



                                    while (true)
                                    {
                                        try
                                        {
                                            Console.WriteLine($"\nInput {studentName} Exam Score");
                                            int numb2;
                                            while (true)
                                            {
                                                string studentExam = Console.ReadLine();
                                                if (int.TryParse(studentExam, out numb2))
                                                {
                                                    exam = ExamScore(numb2);
                                                    break;

                                                }
                                                else
                                                {
                                                    Console.ForegroundColor = ConsoleColor.Red;
                                                    Console.WriteLine("Input Must be a Number");
                                                    Console.ResetColor();

                                                }

                                            }
                                            break;


                                        }
                                        catch (Exception)
                                        {
                                            continue;
                                        }

                                    }


                                        Console.Clear();
  
                                        float studTermScore = test + exam / 100f * 100;

                                        EndofTerm.Add(new Student(studentName, (int)studTermScore));
                                        break;
                                }

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

            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine($"({EndofTerm.Count} students saved) {EndofTerm.Count} of {studentVol} \n");
            Console.ResetColor();

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
