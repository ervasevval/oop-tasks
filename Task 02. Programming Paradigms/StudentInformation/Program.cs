List<double> grades = new List<double>();

Console.WriteLine("Enter 5 grades");

for (int i = 0; i < 5; i++)
{
    Console.Write($"Grade {i + 1}: ");

    // Ask again until the input is a valid number
    double grade;
    while (!double.TryParse(Console.ReadLine(), out grade) || grade < 0 || grade > 100)
    {
        Console.Write("Invalid grade. Enter a number between 0 and 100: ");
    }

    grades.Add(grade);
}

Console.WriteLine();
Console.WriteLine($"Maximum: {grades.Max()}");
Console.WriteLine($"Minimum: {grades.Min()}");
Console.WriteLine($"Average: {grades.Average()}");