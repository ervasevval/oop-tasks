public class TeacherManager
{
    private List<Teacher> teachers;

    public TeacherManager()
    {
        teachers = new List<Teacher>();
    }

    // 1. add teachers
    public void AddTeacher()
    {
        Console.Write("Name: ");
        string name = Console.ReadLine() ?? "";

        Console.Write("Subject: ");
        string subject = Console.ReadLine() ?? "";
        while (string.IsNullOrWhiteSpace(subject))
        {
            Console.Write("Subject can't be empty, try again: ");
            subject = Console.ReadLine() ?? "";
        }

        Console.Write("Years of experience: ");
        int years;
        while (!int.TryParse(Console.ReadLine(), out years) || years < 0)
        {
            Console.Write("Enter a number (0 or more): ");
        }

        teachers.Add(new Teacher(name, subject, years));
        Console.WriteLine("Teacher added");
    }

    // 2. show teachers
    public void ShowTeachers()
    {
        if (teachers.Count == 0)
        {
            Console.WriteLine("There are no teachers yet");
            return;
        }

        foreach (Teacher t in teachers)
        {
            t.ShowProfile();
        }
    }

    // 3. count teachers
    public void ShowCount()
    {
        Console.WriteLine($"Total teachers: {teachers.Count}");
    }

    // 4. average years of experience
    public void ShowAverage()
    {
        if (teachers.Count == 0)
        {
            Console.WriteLine("There are no teachers yet");
            return;
        }

        double total = 0;
        foreach (Teacher t in teachers)
        {
            total += t.YearsOfExperience;
        }

        Console.WriteLine($"Average experience: {total / teachers.Count:F1} years");
    }
}