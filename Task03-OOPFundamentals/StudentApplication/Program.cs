int number = 10;

// object creation
// invoke constructor
// the app reserve memory for the object
Student s1 = new Student();
Console.WriteLine(s1);

Student s4 = new Student("John", 20); // parameterized constructor
Console.WriteLine(s4);
//s1.Name = "Tom";  // accessing public fields for that object
//s1.Age = 19;
//s1.Career = "IT";
//Student s5 = new Student("Jerry", 21, "CS"); // parameterized constructor, 3 tane parameterli constructor overloadu var. 3 parametreli constructor overloadu çağırılır. ama bizimki iki tane

// read operation
Console.WriteLine($"Student 1's name is {s1.Name}");
Console.WriteLine($"Student 1's name is {s1.Age}");
Console.WriteLine($"Student 1's name is {s1.Career}");


Student s2 = new();
Console.WriteLine("What is the name of student 2?");
s2.Name = Console.ReadLine();

Console.WriteLine("What is the age of student 2?");
s2.Age = int.Parse(Console.ReadLine());

Console.WriteLine("What is the career of student 2?");
s2.Career = Console.ReadLine();

//Console.WriteLine(s2);

List<Student> list = new List<Student>(); // list is an instance (object) of List<T> class
list.Add(s1);
list.Add(s2);

foreach (Student s in list)
{
    Console.WriteLine(s);
}

Student s3 = s1;
Console.WriteLine($"Student 3: {s3}");

s3.Name = "Jerry";
Console.WriteLine($"Student 1: {s1.Name}");

s2 = s3; //artık hepsi s1 in main memory adresini gösteriyor. s2 artık s1 in main memory adresini gösteriyor.
Console.WriteLine($"Student 2: {s2.Name}");


// challenge 1
Teacher t1 = new Teacher("Maria", "Math", 8);
Teacher t2 = new Teacher("David", "Physics", 3);
Console.WriteLine($"{t1.Name} - {t1.Subject} - {t1.YearsOfExperience}");
Console.WriteLine($"{t2.Name} - {t2.Subject} - {t2.YearsOfExperience}");

// challenge 2
t1.ShowProfile();
t2.ShowProfile();

// challenge 3
List<Teacher> teachers = new List<Teacher>();
teachers.Add(t1);
teachers.Add(t2);
teachers.Add(new Teacher("Elena", "History", 12));

foreach (Teacher t in teachers)
{
    t.ShowProfile();
}

// challenge 4, negative years and empty subject should not work
t1.YearsOfExperience = -5;
t1.Subject = "";
t1.ShowProfile(); // old values are still there