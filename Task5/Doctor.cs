using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Task5.Enums;

namespace Task5
{
     class Doctor : Person
    {
      public void DoctorMode ()
        {
            List<Question> easyLevel = new List<Question>();
            List<Question> mediumLevel = new List<Question>();
            List<Question> hardLevel = new List<Question>();
            int noOfQuestions;
            try
            {
                Console.WriteLine("Choose Number of Questions To Add :");
                noOfQuestions = Convert.ToInt32(Console.ReadLine());
                for (int i = 0; i < noOfQuestions; i++)
                {
                    Question q = null;
                    Console.WriteLine("Choose Type Of Question :");
                    Console.WriteLine("1. True/False.");
                    Console.WriteLine("2. Choose One Answer.");
                    Console.WriteLine("3. Choose Multiple Answers.");
                    int TypeChoice = Convert.ToInt32(Console.ReadLine());
                    switch (TypeChoice)
                    {
                        case 1:
                            q = new TrueFalseQuestion();
                            q.TakeInput();
                            break;
                        case 2:
                            q = new ChooseOneQuestion();
                            q.TakeInput();
                            break;
                        case 3:
                            q = new MultipleChoiceQuestion();
                            q.TakeInput();
                            break;
                    }
                    //q.TakeInput();
                    if (q != null)
                    {


                        Console.WriteLine("Choose Level :");
                        string[] levels = Enum.GetNames(typeof(LevelType));

                        for (int ii = 0; ii < levels.Length; ii++)
                        {
                            Console.WriteLine($"{ii + 1}. {levels[ii]}");
                        }
                        int LevelChoice = Convert.ToInt32(Console.ReadLine());
                        if (LevelChoice < 1 || LevelChoice > 3)
                            throw new ArgumentException("Wrong Choice");
                        else
                        {
                            LevelType selectedLevel = (LevelType)(LevelChoice - 1);
                            switch (selectedLevel)
                            {
                                case LevelType.Easy:
                                    easyLevel.Add(q);
                                    break;
                                case LevelType.Medium:
                                    mediumLevel.Add(q);
                                    break;
                                case LevelType.Hard:
                                    hardLevel.Add(q);
                                    break;
                            }
                        }
                    }
                    else throw new Exception();
                        
                }
                MainMenu.Menu();
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine("You Entered Wrong Value");
            }

            catch (Exception ex)
            {
                Console.WriteLine("Something Went Wrong");
            }
           
        }
    }
}
