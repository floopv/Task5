using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Task5.Enums;

namespace Task5
{
    class Student : Person
    {
        public void StudentMode()
        {
            try
            {
                Console.WriteLine("Welcome! Please Choose Your Exam Type :");
                string[] ExamTypes = Enum.GetNames(typeof(ExamType));
                for (int i = 0; i < ExamTypes.Length; i++)
                {
                    Console.WriteLine($"{i + 1}. {ExamTypes[i]}");
                }
                int exam_type = Convert.ToInt32(Console.ReadLine());
                if (exam_type < 1 || exam_type > 2)
                {
                    Console.WriteLine("Wrong Choice");
                    return;
                    //exam_type = Convert.ToInt32(Console.ReadLine());
                }
                Console.WriteLine("Please Choose Your Exam Level :");
                string[] ExamLevels = Enum.GetNames(typeof(LevelType));
                for (int i = 0; i < ExamLevels.Length; i++)
                {
                    Console.WriteLine($"{i + 1}. {ExamLevels[i]}");
                }
                int exam_level = Convert.ToInt32(Console.ReadLine());
                if (exam_level <1  || exam_level > 3) { Console.WriteLine("Wrong Choice"); return; }
                LevelType lvltype = (LevelType)exam_level - 1;
                List<Question> choosen_questions = null;
                int no_of_questions = 0;
                switch (lvltype)
                {
                    case LevelType.Easy:
                        choosen_questions = Doctor.getEasyLevel();
                        break;
                    case LevelType.Medium:
                        choosen_questions = Doctor.getMediumLevel();
                        break;
                    case LevelType.Hard:
                        choosen_questions = Doctor.getHardLevel();
                        break;
                }
                if (exam_type == 1) {
                    if (choosen_questions.Count != 1)
                    {
                        no_of_questions = choosen_questions.Count / 2;
                    }
                    else 
                        no_of_questions = 1;
                }
                else if (exam_type==2) { no_of_questions = choosen_questions.Count; }
                int total = 0;
                int score = 0;
                if (no_of_questions == 0 || choosen_questions == null)
                { Console.WriteLine("No Questions Available"); return; }
                for (int i = 0; i < no_of_questions; i++)
                {
                    Question q = choosen_questions[i];
                    q.Display();
                    bool result = q.CheckAnswers();
                    if (result) { score += q.Marks; }
                    total += q.Marks;
                }
                Console.WriteLine($"Your Score is {score} out of {total}.");
            }
            catch (Exception ex) { Console.WriteLine(ex.Message); }
        }
    }
}
