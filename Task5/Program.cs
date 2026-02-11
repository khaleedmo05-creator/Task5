using System.Data;
using System.Reflection.Emit;

namespace Task5
{
    internal class Program
    {
        static List<Question> questionBank = new List<Question>();

        static void Main()
        {
            while (true)
            {
                Console.WriteLine("1) Doctor Mode");
                Console.WriteLine("2) Student Mode");
                Console.WriteLine("3) Exit");

                int choice = int.Parse(Console.ReadLine());

                if (choice == 1)
                    DoctorMode();
                else if (choice == 2)
                    StudentMode();
                else
                    break;
            }
        }

        static void DoctorMode()
        {
            Console.Write("Enter number of questions: ");
            int num = int.Parse(Console.ReadLine());

            for (int i = 0; i < num; i++)
            {
                Console.WriteLine("Choose Question Type:");
                Console.WriteLine("1) True / False");
                Console.WriteLine("2) Choose One");
                Console.WriteLine("3) Multiple Choice");
                int type = int.Parse(Console.ReadLine());


                Console.Write("Enter Header: ");
                string header = Console.ReadLine();

                Console.Write("Enter Marks: ");
                int marks = int.Parse(Console.ReadLine());

                Console.WriteLine("Choose Level: 1-Easy 2-Medium 3-Hard");
                QuestionLevel level = (QuestionLevel)int.Parse(Console.ReadLine());

                if (type == 1)
                {
                    TrFaQuestion q = new TrFaQuestion();
                    q.Header = header;
                    q.Marks = marks;
                    q.Level = level;

                    Console.Write("Enter Correct Answer (true/false): ");
                    q.CorrectAnswer = bool.Parse(Console.ReadLine());

                    questionBank.Add(q);
                }
                else if (type == 2)
                {
                    ChooseOneQ q = new ChooseOneQ();
                    q.Header = header;
                    q.Marks = marks;
                    q.Level = level;
                    q.Options = new List<string>();

                    for (int j = 0; j < 4; j++)
                    {
                        Console.Write($"Enter option {j + 1}: ");
                        q.Options.Add(Console.ReadLine());
                    }

                    Console.Write("Enter correct option number: ");
                    q.CorrectAnswer = int.Parse(Console.ReadLine()).ToString();

                    questionBank.Add(q);
                }
                else if (type == 3)
                {
                    MultCh q = new MultCh();
                    q.Header = header;
                    q.Marks = marks;
                    q.Level = level;
                    q.Options = new List<string>();
                    q.CorrectAnswers = new List<int>();

                    for (int j = 0; j < 4; j++)
                    {
                        Console.Write($"Enter option {j + 1}: ");
                        q.Options.Add(Console.ReadLine());
                    }

                    Console.Write("Enter correct answers (comma separated): ");
                    string[] correct = Console.ReadLine().Split(',');

                    foreach (string c in correct)
                    {
                        q.CorrectAnswers.Add(int.Parse(c.Trim()));
                    }

                    questionBank.Add(q);
                }

            }

            Console.WriteLine("Questions Added Successfully");
        }
        static void StudentMode()
        {
            int totalMarks = 0;
            int studentMark = 0;

            Console.WriteLine("Choose Exam Type:");
            Console.WriteLine("1) Practical");
            Console.WriteLine("2) Final");
            int examType = int.Parse(Console.ReadLine());

            Console.WriteLine("Choose Level: 1-Easy 2-Medium 3-Hard");
            QuestionLevel level = (QuestionLevel)int.Parse(Console.ReadLine());
            List<Question> examQuestions = new List<Question>();
            foreach (Question q in questionBank)
            {
                if (q.Level == level)
                    examQuestions.Add(q);
            }

            if (examType == 1)
            {
                examQuestions = examQuestions.Take(examQuestions.Count / 2).ToList();
            }

            foreach (Question q in examQuestions)
            {
                q.Display();
                Console.Write("Your Answer: ");
                string ans = Console.ReadLine();

                totalMarks += q.Marks;

                if (q.Checking(ans))
                    studentMark += q.Marks;
            }
            Console.WriteLine($"Your Result: {studentMark} / {totalMarks}");
        }
    }
}
