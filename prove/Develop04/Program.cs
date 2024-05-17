using System;
using System.Collections.Generic;
using System.Threading;

public class Activity
{
    private string _name;
    private string _description;
    private int _duration;

    public Activity(string name, string description, int duration)
    {
        _name = name;
        _description = description;
        _duration = duration;
    }

    public (string, string) DisplayStartingMessage()
    {
        string welcome = $"Welcome to {_name}";
        string objective = $"This activity will {_description}";

        return (welcome, objective);
    }

    public void DisplayEndingMessage()
    {
        Console.WriteLine($"Activity {_name} completed!");
    }

    public void ShowSpinner()
    {
        Console.WriteLine("Get ready...");

        List<string> animationStrings = new List<string>();
        animationStrings.Add("|");
        animationStrings.Add("/");
        animationStrings.Add("-");
        animationStrings.Add("\\");
        animationStrings.Add("|");
        animationStrings.Add("/");
        animationStrings.Add("-");
        animationStrings.Add("\\");

        foreach (string s in animationStrings)
        {
            Console.Write(s);
            Thread.Sleep(300);
            Console.Write("\b \b");
        }

        DateTime startTime = DateTime.Now;
        DateTime endTime = startTime.AddSeconds(1);

        int i = 0;

        while (DateTime.Now < endTime)
        {
            string s = animationStrings[i];
            Console.Write(s);
            Thread.Sleep(1000);
            Console.Write("\b \b");

            i++;

            if (i >= animationStrings.Count)
            {
                i = 0;
            }
        }
    }

    public void ShowCountDown(int seconds)
    {
        for (int i = seconds; i > 0; i--)
        {
            Console.WriteLine($"   {i} seconds remaining...");
            Thread.Sleep(1000); // Sleep for 1 second
        }
    }

    public class BreathingActivity : Activity
    {
        private int _count; // Attribute specific to breathing activities

        public BreathingActivity(string name, string description, int duration, int count)
            : base(name, description, duration)  // Call the base class constructor
        {
            _count = count;
        }

        public void Run()
        {
            var startingMessage = DisplayStartingMessage();  // Use this.DisplayStartingMessage() would work too
            Console.WriteLine($"{startingMessage.Item1}\n\n{startingMessage.Item2}\n");

            Console.WriteLine("How long, in seconds, would you like for your session?");
            if (int.TryParse(Console.ReadLine(), out int totalDuration))
            {
                Console.Clear();

                ShowSpinner();

                while (totalDuration > 0)
                {
                    // "Breathe in" for 4 seconds
                    Console.Write("Take a deep breath in...");
                    ShowCountDown(4);

                    totalDuration -= 4;

                    if (totalDuration > 0)
                    {
                        // "Breathe out" for 6 seconds
                        Console.Write("Now breathe out...");
                        ShowCountDown(6);

                        totalDuration -= 6;
                    }
                }

                Console.WriteLine("\nDone. Relax!");
            }
            else
            {
                Console.WriteLine("Invalid input. Please enter a valid integer for the session duration.");
                // Handle invalid input accordingly
            }
        }
    }

    public class ReflectingActivity : Activity
    {
        private List<string> _prompts = new List<string>();
        private List<string> _questions = new List<string>();

        public ReflectingActivity(string name, string description, int duration)
            : base(name, description, duration)
        {
        }

        public void Run()
        {
            var startingMessage = DisplayStartingMessage();  // Use this.DisplayStartingMessage() would work too
            Console.WriteLine($"{startingMessage.Item1}\n\n{startingMessage.Item2}\n");

            Console.WriteLine("How long, in seconds, would you like for your session?");
            if (int.TryParse(Console.ReadLine(), out int totalDuration))
            {
                Console.Clear();

                ShowSpinner();

                Console.WriteLine("Get ready...\n");

                Console.WriteLine("Consider the following prompt:\n");

                DisplayPrompt();

                Console.WriteLine("\n");

                Console.WriteLine("When you have something in mind, press enter to continue.");

                // Consume any remaining newline characters
                while (Console.KeyAvailable)
                {
                    Console.ReadKey(intercept: true);
                }

                // Wait for Enter key
                Console.ReadLine();

                Console.Clear();

                Console.WriteLine("Now ponder on each of the following questions as they relate to this experience.");
                Console.WriteLine($"You may begin now.\n");

                DisplayQuestion();

                Console.WriteLine("\nWell Done");
                Console.WriteLine("\nYou have completed another Reflecting Activity");
                Console.ReadLine();

                Console.Clear();
            }
            else
            {
                Console.WriteLine("Invalid input. Please enter a valid integer for the session duration.");
                // Handle invalid input accordingly
            }
        }

        public int CountDown()
        {
            int seconds = 5; // Set the countdown duration to 5 seconds

            for (int i = seconds; i > 0; i--)
            {
                Console.WriteLine($"   {i} seconds remaining...");
                Thread.Sleep(1000); // Sleep for 1 second
            }

            return seconds; // Return the duration for further calculation
        }

        public string GetRandomPrompt()
        {
            _prompts.Add("--- Think of a time when you did something really difficult ---");
            _prompts.Add("--- Think of a time when thought you couldn't do something but you did ---");
            _prompts.Add("--- Think of a time when you helped someone and felt good ---");

            Random random = new Random();
            int index = random.Next(_prompts.Count);
            return _prompts[index];
        }

        public string GetRandomQuestion()
        {
            _questions.Add("--- How did you feel when it was complete? ---");
            _questions.Add("--- What is your favorite thing about this experience?  ---");

            Random random = new Random();
            int index = random.Next(_questions.Count);
            return _questions[index];
        }

        public void DisplayPrompt()
        {
            string randomPrompt = GetRandomPrompt();
            Console.WriteLine(randomPrompt);
        }

        public void DisplayQuestion()
        {
            string randomQuestion = GetRandomQuestion();
            Console.WriteLine(randomQuestion);

            Console.WriteLine("Press Enter to continue...");
            Console.ReadLine(); // Wait for Enter key

            string randomQuestion2 = GetRandomQuestion();
            Console.WriteLine(randomQuestion2);
            Console.ReadLine();
        }
    }

    public class ListingActivity : Activity
    {
        int _count;
        private List<string> _prompts = new List<string>();

        public ListingActivity(string name, string description, int duration, int count)
            : base(name, description, duration)
        {
            _count = count;
        }

        public void Run()
        {
            var startingMessage = DisplayStartingMessage();  // Use this.DisplayStartingMessage() would work too
            Console.WriteLine($"{startingMessage.Item1}\n\n{startingMessage.Item2}\n");


                Console.WriteLine("This activity will have the time you want it to have, please press enter to move forward");
                Console.ReadLine();

                Console.Clear();
                ShowSpinner();
                Console.WriteLine("Get ready...\n");

                Console.WriteLine("List as many responses as you can to the following prompt:");

                string randomPrompt = GetRandomPrompt();
                Console.WriteLine(randomPrompt);

                GetListFromUser();

                Console.Clear();
        
        }

        public string GetRandomPrompt()
        {
            _prompts.Add("--- When have you felt The Holy Ghost this month? ---");
            _prompts.Add("--- What is you favorite scriptures this month? ---");
            _prompts.Add("--- What are you most grateful for this month? ---");

            Random random = new Random();
            int index = random.Next(_prompts.Count);
            return _prompts[index];
        }

        public List<string> GetListFromUser()
        {
            
            List<string> phrases = new List<string>();

            Console.WriteLine("Enter phrases (type 'done' to finish):");

            while (true)
            {
                string userInput = Console.ReadLine();

                if (userInput.ToLower() == "done")
                {
                    break; // Exit the loop when user enters 'done'
                }

                phrases.Add(userInput);
            }

            return phrases;
        }

        public int CountDown()
        {
            int seconds = 5; // Set the countdown duration to 5 seconds
            for (int i = seconds; i > 0; i--)
            {
                Console.WriteLine($"   {i} seconds remaining...");
                Thread.Sleep(1000); // Sleep for 1 second
            }
            return seconds; // Return the duration for further calculation
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            string choice = " ";

            while (choice != "4")
            {
                Console.WriteLine("Menu Options:");
                Console.WriteLine("  1. Start breathing Activity");
                Console.WriteLine("  2. Start reflecting Activity");
                Console.WriteLine("  3. Start Listing Activity");
                Console.WriteLine("  4. Quit");
                Console.WriteLine("Select a choice from the menu: ");

                // Get user input
                choice = Console.ReadLine();

                // Create and run the chosen activity
                switch (choice)
                {
                    case "1":
                        Console.Clear();
                        BreathingActivity breathingActivity = new BreathingActivity("Breathing Activity", "help you relax by walking you through" +
                            " breathing in and out slowly. Clear your mind and focus on your breathing.", 0, 0);
                        breathingActivity.Run();
                        break;
                    case "2":
                        Console.Clear();
                        ReflectingActivity reflectingActivity = new ReflectingActivity("Reflecting Activity", "help you reflect on times in your life when you have" +
                            " shown strength and resilience.\nThis will help you recognize the power you have and how you can use it in other aspects of your life.", 0);
                        reflectingActivity.Run();
                        break;
                    case "3":
                        Console.Clear();
                        ListingActivity listingActivity = new ListingActivity("Listing Activity", "help you reflect on the good things in your life by" +
                            " listing as many things as you can in a certain area.", 0, 0);
                        listingActivity.Run();
                        break;
                    case "4":
                        Console.WriteLine("Goodbye");
                        break;
                    default:
                        Console.WriteLine("Invalid choice.");
                        break;
                }
            }
        }
    }
}