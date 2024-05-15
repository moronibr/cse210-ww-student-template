using System;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Hello Learning04 World!");

        WritingAssignment assignment = new WritingAssignment("Mary Waters", "European History", "The Causes of World War II");

        Console.WriteLine(assignment.GetSummary());
        Console.WriteLine(assignment.GetWritingInformation());

        MathAssignment math = new MathAssignment("Roberto Rodriguez", "Fractions", "frac-3-4", "frac-3-4");
        Console.WriteLine(math.GetSummary());
        Console.WriteLine(math.GetHomeworkList());


    }
}