using System;
using System.Collections.Generic;

public partial class Program
{
    const int MaxTasks = 10;

    public static void Main(string[] args)
    {
        // TASK 1
        Console.WriteLine("Erva Şeval Şimşek");
        Console.WriteLine("python");
        Console.WriteLine("I want to learn .NET because I want to learn how backend works and how to create a backend application");

        // TASK 2
        int studentAge = 22;
        string courseName = "C#";
        bool alreadyKnowCSharp = true;
        const int MaxDailyTasks = 5;

        Console.WriteLine($"Student age: {studentAge}");
        Console.WriteLine($"Course name: {courseName}");
        Console.WriteLine($"Knows C#: {alreadyKnowCSharp}");
        Console.WriteLine($"Maximum daily tasks: {MaxDailyTasks}");

        // TASK 3 (commented out: replaced by the main loop in Task 5)
        /*
        Console.WriteLine("1. Add task");
        Console.WriteLine("2. View tasks");
        Console.WriteLine("3. Complete task");
        Console.WriteLine("4. Remove task");
        Console.WriteLine("0. Exit");

        Console.Write("Please select an option: ");
        int option = int.Parse(Console.ReadLine());

        switch (option)
        {
            case 1:
                Console.WriteLine("You selected: Add Task");
                break;

            case 2:
                Console.WriteLine("You selected: View Tasks");
                break;

            case 3:
                Console.WriteLine("You selected: Complete Task");
                break;

            case 4:
                Console.WriteLine("You selected: Remove Task");
                break;

            case 0:
                Console.WriteLine("You selected: Exit");
                break;
        }
        */

        // TASK 4
        List<string> tasks = new List<string>();
        bool running = true;

        // TASK 4 loop (commented out: split into methods in Task 5)
        /*
        while (running)
        {
            Console.WriteLine();
            Console.WriteLine("1. Add task");
            Console.WriteLine("2. View tasks");
            Console.WriteLine("3. Remove task");
            Console.WriteLine("0. Exit");

            Console.Write("Choose: ");
            int option2 = int.Parse(Console.ReadLine());

            switch (option2)
            {
                case 1:
                    Console.Write("Enter Task: ");
                    string task = Console.ReadLine();
                    tasks.Add(task);
                    break;

                case 2:
                    for (int i = 0; i < tasks.Count; i++)
                    {
                        Console.WriteLine($"{i + 1}. {tasks[i]}");
                    }
                    break;

                case 3:
                    Console.Write("Enter Task Number to Remove:  ");
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
                    break;

                case 0:
                    running = false;
                    break;

                default:
                    Console.WriteLine("Invalid option. Please try again.");
                    break;
            }
        }
        */

        // TASK 5: main loop
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
                    Console.WriteLine("Invalid option. Please try again.");
                    break;
            }
        }

        // METHODS (TASK 5)
        void ShowMenu()
        {
            Console.WriteLine();
            Console.WriteLine("1. Add task");
            Console.WriteLine("2. View tasks");
            Console.WriteLine("3. Remove task");
            Console.WriteLine("4. Show task count");
            Console.WriteLine("0. Exit");
        }

        // TASK 6: MaxTasks check
        void AddTask(List<string> tasks)
        {
            if (tasks.Count >= MaxTasks)
            {
                Console.WriteLine("Maximum number of tasks reached.");
                return;
            }

            Console.Write("Enter Task: ");
            string task = Console.ReadLine();
            tasks.Add(task);
            Console.WriteLine("Task added.");
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

        void RemoveTask(List<string> tasks)
        {
            Console.Write("Enter Task Number to Remove: ");
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

        // TASK 6: show task count
        void ShowTaskCount(List<string> tasks)
        {
            Console.WriteLine($"You currently have {tasks.Count} tasks.");
            Console.WriteLine($"Maximum allowed: {MaxTasks}");
            Console.WriteLine($"Remaining capacity: {MaxTasks - tasks.Count}");
        }
    }
}