using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Task5
{
     class TrueFalseQuestion : Question
    {
        private bool correctAnswer;
        public override bool TakeInput()
        {
            try {
                Console.WriteLine("Enter Question Header :");
                string input_header = Console.ReadLine();
                if (string.IsNullOrEmpty(input_header)) { throw new ArgumentException(); }
                this.Header = input_header;
                Console.WriteLine("Enter The Marks :");
                this.Marks = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("Enter The Correct Answer : (T/F)");
                string answer = Console.ReadLine();
                switch (answer.ToLower()[0])
                {
                    case 't':
                        correctAnswer = true;
                        return true;
                    case 'f':
                        correctAnswer = false;
                        return true;
                }

            }
            catch (Exception ex)
            { Console.WriteLine(ex.Message); }
            return false;
            }
        public override void Display()
        {
            Console.WriteLine($"Question : {Header}         Marks : {Marks}");
            Console.WriteLine("1. True");
            Console.WriteLine("2. False");
        }

        public override bool CheckAnswers()
        {
            string InputAnswer="";
            try
            {
                Console.WriteLine("Enter Your Answer :");
                 InputAnswer = Console.ReadLine();
            }
            catch (Exception ex) { Console.WriteLine(ex.Message); }
            //if (string.IsNullOrEmpty(InputAnswer)) return false;
            bool studentAnswer;
                switch (InputAnswer.ToLower()[0])
                {
                    case 't':
                        studentAnswer = true;
                        break;
                    case 'f':
                        studentAnswer = false;
                        break;
                    default:
                        Console.WriteLine("Wrong Input");
                        return false;
                }
                return studentAnswer == correctAnswer;
           
        }
        
    }
}
