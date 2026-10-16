public class Teacher
{
    private string name = "No name";
    private string subject = "No subject";
    private int yearsOfExperience = 0;

    public string Name
    {
        get { return name; }
        set { name = value; }
    }

    public string Subject
    {
        get { return subject; }
        set
        {
            // subject can't be empty
            if (!string.IsNullOrWhiteSpace(value))
            {
                subject = value;
            }
            else
            {
                Console.WriteLine("Subject can't be empty");
            }
        }
    }

    public int YearsOfExperience
    {
        get { return yearsOfExperience; }
        set
        {
            // years can't be negative
            if (value >= 0)
            {
                yearsOfExperience = value;
            }
            else
            {
                Console.WriteLine("Years can't be negative");
            }
        }
    }

    public Teacher() // default values come from the fields
    {
    }

    // using the properties here so the checks also work in the constructor
    public Teacher(string n, string s, int y)
    {
        Name = n;
        Subject = s;
        YearsOfExperience = y;
    }

    public void ShowProfile()
    {
        Console.WriteLine($"{Name} teaches {Subject}, {YearsOfExperience} years of experience");
    }
}