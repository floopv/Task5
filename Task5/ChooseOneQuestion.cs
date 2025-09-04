using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace Task5
{
     class ChooseOneQuestion : Question
    {
        private const int noOfChoices = 4;
        private string[] choices = new string[noOfChoices];
        public string[] Choices
        {
            get
            { return choices; }
            set
            {
                for (int i = 0; i < choices.Length; i++)
                {
                    choices[i] = value[i];
                }
            }
        }

        private int correctAnswer;

        public override bool TakeInput()
        {
            try
            {
                Console.WriteLine("Enter Question Header :");
                string input_header = Console.ReadLine();
                if (string.IsNullOrWhiteSpace(input_header)) { throw new ArgumentException(); }
                this.Header = input_header;
                Console.WriteLine("Enter The Marks :");
                this.Marks = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("Enter 4 Choices :");
                for (int i = 0; i < 4; i++)
                {
                    Console.WriteLine($"Enter Choice NO. {i + 1}");
                    string EnteredChoice = Console.ReadLine();
                    if (string.IsNullOrWhiteSpace(EnteredChoice)) { throw new ArgumentException(); }
                    this.Choices[i] = EnteredChoice;
                }
                Console.WriteLine("Enter Correct Choice Number :");
                int CorrectChoiceNumber = Convert.ToInt32(Console.ReadLine());
                CorrectChoiceNumber--;
                if (CorrectChoiceNumber >= 0 && CorrectChoiceNumber <= noOfChoices-1)
                {
                    correctAnswer = CorrectChoiceNumber;
                    return true;
                }

                else throw new ArgumentException();
            }
            catch (Exception ex) { Console.WriteLine(ex.Message); }
            return false;
        }
        public override void Display()
        {
            Console.WriteLine($"Question : {Header}      , Marks : {Marks}");
            for (int i = 0;i < this.Choices.Length; i++)
            {
                Console.WriteLine($"{i+1}. {Choices[i]}");
            }
        }

        public override bool CheckAnswers()
        {
            int InputAnswer=0;
            try
            {
                Console.WriteLine("Enter Your Answer (Choice Number) :");
                InputAnswer = Convert.ToInt32(Console.ReadLine());
            }
            catch (Exception ex) { Console.WriteLine(ex.Message); }
            InputAnswer--;
            if (InputAnswer < 0 || InputAnswer >= noOfChoices)
                return false;
            return InputAnswer == correctAnswer;
        }

        }
    }
