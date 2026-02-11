using System;
using System.Collections.Generic;
using System.Reflection.Emit;
using System.Text;

namespace Task5
{
    enum QuestionLevel
    {
        Easy = 1,
        Medium,
        Hard
    }
    abstract class Question
    {
        public string Header { get; set; }
        public int Marks { get; set; }
        public QuestionLevel Level { get; set; }
        public abstract void Display();
        public abstract bool Checking(string answer);
    }

}