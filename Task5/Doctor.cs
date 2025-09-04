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
        private static List<Question> easyLevel = new List<Question>();
        private static List<Question> mediumLevel = new List<Question>();
        private static List<Question> hardLevel = new List<Question>();

        public static List<Question> getEasyLevel()
        {
            return easyLevel;
        }
        public static List<Question> getMediumLevel()
        {
            return mediumLevel;
        }
        public static List<Question> getHardLevel()
        {
            return hardLevel;
        }
        public void DoctorMode ()
        {
            
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
                    bool ok = false;
                    switch (TypeChoice)
                    {
                        
                        case 1:
                            q = new TrueFalseQuestion();
                            ok = q.TakeInput();
                            break;
                        case 2:
                            q = new ChooseOneQuestion();
                            ok = q.TakeInput();
                            break;
                        case 3:
                            q = new MultipleChoiceQuestion();
                            ok = q.TakeInput();
                            break;
                        default:
                            Console.WriteLine("wrong question type");
                            break;
                    }
                    //q.TakeInput();
                    if (q != null && ok == true)
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
                    //else throw new ArgumentException();
                        
                }
                Console.WriteLine("Question Added Successfully");
                MainMenu.Menu();
            }
            //catch (ArgumentException ex)
            //{
            //    Console.WriteLine("You Entered Wrong Value");
            //}

            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
           
        }
    }
}
