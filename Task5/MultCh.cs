using System.Reflection.Emit;
using System.Reflection.PortableExecutable;
using Task5;

class MultCh : Question
{
    public List<string> Options { get; set; }
    public List<int> CorrectAnswers { get; set; }

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

        Console.WriteLine("Choose answers (e.g. 1,3)");
    }

    public override bool Checking(string answer)
    {
        string[] inputs = answer.Split(',');
        if (inputs.Length != CorrectAnswers.Count)
            return false;

        foreach (string s in inputs)
        {
            int choice = int.Parse(s.Trim());
            if (!CorrectAnswers.Contains(choice))
                return false;
        }
        return true;
    }
}
