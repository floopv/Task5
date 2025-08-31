using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Task5.Enums;

namespace Task5
{
    abstract class Question
    {
        private string header;
        public string Header {  get
            { return header; }
            set
            {
                if(string.IsNullOrEmpty(value))
                    throw new ArgumentException();
                header = value;
            }
                }

        private int marks;
        public int Marks { get
            { return marks; }
            set
            {
                if (value < 0) throw new ArgumentException();
                marks = value;
            }
                }

        public LevelType levelType { get; set; }
        //public virtual void Display() { }
        //public virtual void CheckAnswer() { }

        public abstract void Display();
        public abstract bool CheckAnswers();
        public abstract bool TakeInput();
    }
}

