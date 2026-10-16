TeacherManager manager = new TeacherManager();
bool running = true;

while (running)
{
    Console.WriteLine();
    Console.WriteLine("--- Teacher System ---");
    Console.WriteLine("1. Add teacher");
    Console.WriteLine("2. Show teachers");
    Console.WriteLine("3. Count teachers");
    Console.WriteLine("4. Show average years of experience");
    Console.WriteLine("5. Exit");
    Console.Write("Choose an option: ");

    string? choice = Console.ReadLine();

    switch (choice)
    {
        case "1":
            manager.AddTeacher();
            break;
        case "2":
            manager.ShowTeachers();
            break;
        case "3":
            manager.ShowCount();
            break;
        case "4":
            manager.ShowAverage();
            break;
        case "5":
            running = false;
            break;
        default:
            Console.WriteLine("Invalid option");
            break;
    }
}