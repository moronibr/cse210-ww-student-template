using System;

class Program
{
    static string answer;  
    static string randomString;  
    static void Main(string[] args)
    {   
        int menu = 0;
       

        while (menu != 5 )  
        {

            

            Console.WriteLine("Please select one of the following choices:");
            Console.WriteLine("1. Write");
            Console.WriteLine("2. Display");
            Console.WriteLine("3. Save");
            Console.WriteLine("4. Load");
            Console.WriteLine("5. Quit");

            Console.Write("What would you like to do? ");

            menu = int.Parse(Console.ReadLine());

            switch(menu)
            {
                case 1:
                    Write();
                    break;
                case 2:
                    Display();
                    break;
                case 3:
                    Console.WriteLine("You chose 3");
                    break;
                case 4:
                    Console.WriteLine("You chose 4");
                    break;
                case 5:
                    Console.WriteLine("Quiting...");
                    break;

            }
        }    

        static void Write()
        {
            string [] questions = {
                "Who was the most interesting person I interacted with today?",
                "What was the best part of my day?",
                "How did I see the hand of the Lord in my life today?",
                "What was the strongest emotion I felt today?",
                "If I had one thing I could do over today, what would it be?",
            };

            Random random = new Random();
            int index = random.Next(0, questions.Length);
            randomString = questions[index]; 

            Console.WriteLine(randomString);
            
            answer = Console.ReadLine();

        }

        static void Display()
        {
            DateTime theCurrentTime = DateTime.Now;
            string dateText = theCurrentTime.ToShortDateString();
            
            Console.WriteLine($"{dateText} {randomString} {answer}");

           
        }
    }
}