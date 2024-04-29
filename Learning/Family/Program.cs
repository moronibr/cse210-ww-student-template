using System;

public class Person
{
    public string  _givenName;
    public string _familyName;

    public int _age;

    public void ShowEasternName()
    {
        Console.WriteLine($"{_familyName}, {_givenName}");
        Console.WriteLine($"{_age}");
    }

        // A method that displays the person's full name as used in western 
        // countries or <given name family name>.
    public void ShowWesternName()
    {
        Console.WriteLine($"{_givenName} {_familyName}");
        Console.WriteLine($"{_age}");
    }

      public static void Main(string[] args)
    {
        // Create an instance of Person
        Person person1 = new Person();
        
        // Set the given name and family name
        person1._givenName = "Joseph";
        person1._familyName = "Smith";
        person1._age = 25;
        // Display the names
        person1.ShowEasternName();
        person1.ShowWesternName();

        Person person2 = new Person();

        person2._givenName = "Emma";
        person2._familyName = "Smith";
        person2._age = 22;

        person2.ShowEasternName();
        person2.ShowWesternName();
    }
}

