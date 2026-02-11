using System;
using System.Collections.Generic;
using System.Reflection.Emit;
using System.Reflection.PortableExecutable;
using System.Text;

namespace Task5
{
    class TrFaQuestion : Question
    {
        public bool CorrectAnswer { get; set; }
        public override void Display()
        {
            Console.WriteLine($"Question: {Header}");
            Console.WriteLine($"Marks: {Marks}");
            Console.WriteLine($"Level: {Level}");
            Console.WriteLine("Options: True or False");
        }
        public override bool Checking(string answer)
        {
            bool userAnswer;
            if (bool.TryParse(answer, out userAnswer))
            {
                return userAnswer == CorrectAnswer;
            }
            return false;
        }
    }
}
