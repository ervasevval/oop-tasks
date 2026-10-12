const int MaxDailyTasks = 5;
const string AppName = "Student Task Manager";
const int MaxTasks = 10;

// Step 1
ShowTitle();
Console.WriteLine("Welcome to the application!");
Console.WriteLine("Erva Şeval Şimşek");
Console.WriteLine("Favorite programming language: Python");
Console.WriteLine("I want to learn .NET because I want to learn how backend works and how to create a backend application");

Console.Write("Hello ");
Console.Write("World");
Console.WriteLine();
Console.WriteLine("Hello");
Console.WriteLine("World");

// Step 2
Console.WriteLine();
Console.Write("Enter your name: ");
string name = Console.ReadLine();

Console.Write("How many tasks do you want to complete today? ");
int taskGoal = int.Parse(Console.ReadLine());

Console.Write("How many hours do you have available? ");
double availableHours = double.Parse(Console.ReadLine());

Console.WriteLine();
Console.WriteLine($"Hello {name}!");
Console.WriteLine($"Your goal is {taskGoal} tasks.");
Console.WriteLine($"You have {availableHours} hours available.");

string studentName = "Alex";
int taskCount = 5;
double studyHours = 2.5;
decimal budget = 100.50m;
bool isCompleted = false;
char grade = 'A';
Console.WriteLine($"{studentName}, {taskCount}, {studyHours}, {budget}, {isCompleted}, {grade}");

var courseTitle = ".NET Development";
var maxTasks = 10;
Console.WriteLine($"{courseTitle}, {maxTasks}");

Console.WriteLine($"Application: {AppName}");
Console.WriteLine($"Maximum recommended daily tasks: {MaxDailyTasks}");

Console.Write("Enter a number: ");
bool valid = int.TryParse(Console.ReadLine(), out int number);
Console.WriteLine($"Valid number: {valid}");
Console.WriteLine($"Number: {number}");

int studentAge = 22;
string courseName = "C#";
bool alreadyKnowCSharp = true;

Console.WriteLine($"Student age: {studentAge}");
Console.WriteLine($"Course name: {courseName}");
Console.WriteLine($"Knows C#: {alreadyKnowCSharp}");
Console.WriteLine($"Maximum daily tasks: {MaxDailyTasks}");

// Step 3
Console.WriteLine();
Console.Write("How many tasks have you completed today? ");
int completedTasks = int.Parse(Console.ReadLine());

if (completedTasks == 0)
{
    Console.WriteLine("Time to get started!");
}
else if (completedTasks < 3)
{
    Console.WriteLine("Good start. Keep going!");
}
else
{
    Console.WriteLine("Great progress!");
}

int plannedTasks = 4;
bool hasTime = true;

if (plannedTasks >= 3 && hasTime)
{
    Console.WriteLine("You can probably finish your daily goal.");
}

Console.WriteLine();
Console.WriteLine("1. Add task");
Console.WriteLine("2. View tasks");
Console.WriteLine("3. Complete task");
Console.WriteLine("4. Remove task");
Console.WriteLine("0. Exit");

Console.Write("Choose an option: ");
int menuOption = int.Parse(Console.ReadLine());

switch (menuOption)
{
    case 1:
        Console.WriteLine("Adding a task...");
        break;

    case 2:
        Console.WriteLine("Showing tasks...");
        break;

    case 3:
        Console.WriteLine("Completing a task...");
        break;

    case 4:
        Console.WriteLine("Removing a task...");
        break;

    case 0:
        Console.WriteLine("Goodbye!");
        break;

    default:
        Console.WriteLine("Invalid option.");
        break;
}

// Step 4
Console.WriteLine();
List<string> tasks = new List<string>();

tasks.Add("Review C# variables");
tasks.Add("Practice loops");
tasks.Add("Create a Console application");

Console.WriteLine($"Number of tasks: {tasks.Count}");

foreach (string task in tasks)
{
    Console.WriteLine(task);
}

for (int i = 0; i < tasks.Count; i++)
{
    Console.WriteLine($"{i + 1}. {tasks[i]}");
}

Console.Write("Enter a new task: ");
string newTask = Console.ReadLine();

tasks.Add(newTask);

Console.WriteLine("Task added.");

// Step 5
ShowMessage("Application started.");
ShowMessage("Task added.");

int count = GetTaskCount(tasks);
Console.WriteLine($"You currently have {count} tasks.");

ShowTasks(tasks);

// Step 6
TaskPriority priority = TaskPriority.High;

Console.WriteLine(priority);

switch (priority)
{
    case TaskPriority.Low:
        Console.WriteLine("This task can wait.");
        break;

    case TaskPriority.Medium:
        Console.WriteLine("Try to finish this task today.");
        break;

    case TaskPriority.High:
        Console.WriteLine("Prioritize this task.");
        break;
}

bool running = true;

while (running)
{
    ShowMenu();

    Console.Write("Choose: ");
    int option = int.Parse(Console.ReadLine());

    switch (option)
    {
        case 1:
            AddTask(tasks);
            break;

        case 2:
            ShowTasks(tasks);
            break;

        case 3:
            RemoveTask(tasks);
            break;

        case 4:
            ShowTaskCount(tasks);
            break;

        case 0:
            running = false;
            break;

        default:
            Console.WriteLine("Invalid option.");
            break;
    }
}

void ShowTitle()
{
    Console.WriteLine();
    Console.WriteLine("Student Task Manager");
    Console.WriteLine("====================");
}

void ShowMessage(string message)
{
    Console.WriteLine($"[INFO] {message}");
}

int GetTaskCount(List<string> tasks)
{
    return tasks.Count;
}

void ShowTasks(List<string> tasks)
{
    if (tasks.Count == 0)
    {
        Console.WriteLine("No tasks available.");
        return;
    }

    for (int i = 0; i < tasks.Count; i++)
    {
        Console.WriteLine($"{i + 1}. {tasks[i]}");
    }
}

void ShowMenu()
{
    Console.WriteLine();
    Console.WriteLine("1. Add task");
    Console.WriteLine("2. View tasks");
    Console.WriteLine("3. Remove task");
    Console.WriteLine("4. Show task count");
    Console.WriteLine("0. Exit");
}

void AddTask(List<string> tasks)
{
    if (tasks.Count >= MaxTasks)
    {
        Console.WriteLine("Maximum number of tasks reached.");
        return;
    }

    Console.Write("Enter task: ");
    string task = Console.ReadLine();
    tasks.Add(task);
}

void RemoveTask(List<string> tasks)
{
    Console.Write("Task to remove: ");
    int taskNumber = int.Parse(Console.ReadLine());

    if (taskNumber > 0 && taskNumber <= tasks.Count)
    {
        tasks.RemoveAt(taskNumber - 1);
        Console.WriteLine("Task removed.");
    }
    else
    {
        Console.WriteLine("Invalid task number.");
    }
}

void ShowTaskCount(List<string> tasks)
{
    Console.WriteLine($"You currently have {tasks.Count} tasks.");
    Console.WriteLine($"Maximum allowed: {MaxTasks}");
    Console.WriteLine($"Remaining capacity: {MaxTasks - tasks.Count}");
}

enum TaskPriority
{
    Low,
    Medium,
    High
}