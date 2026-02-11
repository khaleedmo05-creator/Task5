using System;
using System.Collections.Generic;
using System.Text;

namespace Task5
{
    class ChooseOneQ : Question
    {
        public List<string> Options { get; set; }
        public string CorrectAnswer { get; set; }
        public override void Display()
        {
            Console.WriteLine($"Question: {Header}");
            Console.WriteLine($"Marks: {Marks}");
            Console.WriteLine($"Level: {Level}");
            Console.WriteLine("Options:");
            for (int i = 0; i < Options.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {Options[i]}");
            }
        }
        public override bool Checking(string answer)
        {
            return answer == CorrectAnswer;
        }
    }
}
