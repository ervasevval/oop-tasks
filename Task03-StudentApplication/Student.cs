public class Student
{

    public string Name;
    public int Age;
    public string Career;

    public Student() // default constructor
    {
        Name = "No name";
        Age = 0;
        Career = "No career";
    }


    // constructor overloading
    public Student(string n, int a) // parameterized constructor
    {
        Name = n;
        Age = a;
    }
    public override string ToString() // the eclass already has a method called ToString() which is inherited from the base class object. We are overriding that method to provide our own implementation.
    {
        // return base.ToString();
        return $"Student's name is {Name}, age is {Age} and career is {Career}";
    }


    // constructor overloading

}


