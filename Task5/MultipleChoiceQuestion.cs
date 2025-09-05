using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task5
{
    class MultipleChoiceQuestion : Question
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

        private List<int> correctAnswers = new List<int>();
        public List<int> CorrectAnswers
        {
            get { return correctAnswers; }
            set
            {
                for (int i = 0; i < choices.Length; i++)
                {
                    if (value[i] < 0 || value[i] > noOfChoices - 1)
                        throw new ArgumentException();
                    correctAnswers.Add(value[i]);
                }
            }
        }

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
                    if (choices.Contains(EnteredChoice))
                        throw new ArgumentException("Duplicate choices are not allowed.");
                    this.Choices[i] = EnteredChoice;
                }
                Console.WriteLine("Enter NO. Of Correct Choices:");
                int noOfCorrectChoices = Convert.ToInt32(Console.ReadLine());
                for (int i = 0; i < noOfCorrectChoices; i++)
                {
                    Console.WriteLine($"Enter The Correct Choice Number :");
                    int CorrectChoiceNumber = Convert.ToInt32(Console.ReadLine());
                    CorrectChoiceNumber--;
                    if (CorrectChoiceNumber >= 0 && CorrectChoiceNumber <= noOfChoices - 1)
                    {
                        if (correctAnswers.Contains(CorrectChoiceNumber))
                        { throw new ArgumentException("Duplicate choices are not allowed."); }
                        this.CorrectAnswers.Add(CorrectChoiceNumber);
                    }
                    else { Console.WriteLine("Wrong Input"); i--; }
                }
                ;


                return true;
            }
            catch (Exception ex) { Console.WriteLine(ex.Message); }
            return false;
        }

        public override void Display()
        {
            Console.WriteLine($"Question : {Header}      , (Choose {CorrectAnswers.Count} Choices)  Marks : {Marks}");
            for (int i = 0; i < this.Choices.Length; i++)
            {
                Console.WriteLine($"{i + 1}. {Choices[i]}");
            }
        }

        public override bool CheckAnswers()
        {
            int[] studentAnswers = new int[correctAnswers.Count];
            Console.WriteLine($"You must enter {correctAnswers.Count} answers:");
            try
            {
                for (int i = 0; i < correctAnswers.Count; i++)
                {
                    Console.Write($"Enter answer {i + 1}: ");
                    studentAnswers[i] = Convert.ToInt32(Console.ReadLine()) - 1;
                }
            }
            catch (Exception ex) { Console.WriteLine(ex.Message); }
            for (int i = 0; i < correctAnswers.Count; i++)
            {
                if (!studentAnswers.Contains(correctAnswers[i]))
                    return false;
            }
            return true;

        }
    }
}