using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Linq;
using System.IO;

namespace prove
{
    public class GoalManager
    {
        public List<Goal> _goals;
        public int _score;

     
        public GoalManager()
        {
            _goals = new List<Goal>();
            _score = 0;
        }

        public void Start()
        {
            _goals = new List<Goal>();
            _score = 0;

            int menu = 0;
        
            while (menu != 6)
                {   
                    Console.WriteLine($"You have {_score} points");

                    Console.WriteLine("Menu Options: ");
                    Console.WriteLine("  1. Create New Goal");
                    Console.WriteLine("  2. List Goals");
                    Console.WriteLine("  3. Save Goals");
                    Console.WriteLine("  4. Load Goals");
                    Console.WriteLine("  5. Record Event");
                    Console.WriteLine("  6. Quit");
                    Console.Write("Select a choice from the menu: ");
                    menu = int.Parse(Console.ReadLine());
        
                    switch (menu)
                    {
                        case 1:
                            CreateGoal();
                            break;
                        case 2:
                            ListGoals(_goals);
                            break;
                        case 3:
                            SaveGoals();
                            break;
                        case 4:
                            _goals = LoadGoals();
                            ListGoals(_goals);
                            break;
                        case 5:
                            RecordEvent();
                            break;
                        case 6:
                            Console.WriteLine("Exiting program...");
                            break;
                        default:
                            Console.WriteLine("Invalid input");
                            break;
                    }
                }
        }

        public void CreateGoal()
        {
            int _goalType = 0;

    

            while (_goalType != 4)
            {
                Console.WriteLine("The types of goals are:");
                Console.WriteLine("1. Simple Goal");
                Console.WriteLine("2. Eternal Goal");
                Console.WriteLine("3. Checklist Goal");
                Console.WriteLine("4. Go back to the main menu");
                Console.WriteLine("What type of goal would you like to create?");
                _goalType = int.Parse(Console.ReadLine());
                switch (_goalType)
                {
                    case 1:
                        
                        
                        Console.WriteLine("What is the name of your goal?");

                        string name = Console.ReadLine();

                        Console.WriteLine("What is a short description of it?");

                        string description = Console.ReadLine();

                        Console.WriteLine("What is the amount of points associated with this goal?");

                        string points = Console.ReadLine();

                        _goals.Add(new SimpleGoal(name, description, points, false ));

                        
                        
                        break;
                    case 2:

                        Console.WriteLine("What is the name of your goal?");

                        string _name = Console.ReadLine();

                        Console.WriteLine("What is a short description of it?");

                        string _description = Console.ReadLine();

                        Console.WriteLine("What is the amount of points associated with this goal?");

                        string _points = Console.ReadLine();

                        _goals.Add(new EternalGoal(_name, _description, _points));

                    

                        break;
                    case 3:
                        
                        Console.WriteLine("What is the name of your goal?");

                        string _checkName = Console.ReadLine();

                        Console.WriteLine("What is a short description of it?");

                        string _checkDescription = Console.ReadLine();

                        Console.WriteLine("What is the amount of points associated with this goal?");

                        string _checkPoints = Console.ReadLine();

                        Console.WriteLine("How many times does this goal need to be accomplished for a bonus?");

                        string _checkTarget = Console.ReadLine();

                        Console.WriteLine("What is the bonus for accomplishing it that many times?");

                        string _checkBonus = Console.ReadLine();

                        _goals.Add(new CheckListGoal(_checkName, _checkDescription, _checkPoints, int.Parse(_checkTarget), int.Parse(_checkBonus) , 0));

                        break;
                    case 4:
                        Console.WriteLine("Going back to the main menu");
                        break;
                    default:
                        Console.WriteLine("Invalid input");
                        break;
                }
            }
        }

        public void ListGoals(List<Goal> goals)
        {   
            Console.WriteLine("The goals are: ");
            

            foreach (var(goal, index) in goals.Select((goals, index) => (goals, index)))
            {

                if (goal is SimpleGoal)
                {   
                    SimpleGoal simpleGoal = (SimpleGoal)goal;
                    Console.WriteLine($"{index + 1}. [] {goal._name} ({goal._description})");
                }
                if (goal is EternalGoal)
                {   
                    EternalGoal eternalGoal = (EternalGoal)goal;
                    Console.WriteLine($"{index + 1}. [] {goal._name} ({goal._description})");
                }
                if (goal is CheckListGoal)
                {
                    CheckListGoal checkListGoal = (CheckListGoal)goal;
                    Console.WriteLine($"{index + 1}. [] {goal._name} ({goal._description}) -- Currently completed: {checkListGoal._amountCompleted}/{checkListGoal._target}");
                }
                
            }
            
            
        }

        private void SaveGoals()
        {
            Console.WriteLine("What is the filename for the goal file?");

            string _filename = Console.ReadLine();

            using (StreamWriter outputFile = new StreamWriter(_filename))
            {   
                
                outputFile.WriteLine(_score);

                foreach (var goal in _goals)
                {   
                   

                    if (goal is SimpleGoal)
                    {    
                        SimpleGoal simpleGoal = (SimpleGoal)goal;
                        outputFile.WriteLine($"Simple Goal: {simpleGoal._name},{simpleGoal._description},{simpleGoal._points},{simpleGoal._isComplete}");

                    }
                    if (goal is EternalGoal)
                    {
                        EternalGoal eternalGoal = (EternalGoal)goal;
                        outputFile.WriteLine($"Eternal Goal:{eternalGoal._name},{eternalGoal._description},{eternalGoal._points}");
                    }
                    if (goal is CheckListGoal)
                    {
                        CheckListGoal checkListGoal = (CheckListGoal)goal;
                        outputFile.WriteLine($"Check List Goal: {checkListGoal._name},{checkListGoal._description},{checkListGoal._points},{checkListGoal._bonus}, {checkListGoal._target}, {checkListGoal._amountCompleted}");
                    }
                }
            }
        }
       
        public List<Goal> LoadGoals()
        {
            Console.WriteLine("What is the filename for the goal file?");
            string filename = Console.ReadLine();

            List<Goal> loadedGoals = new List<Goal>();

            if (File.Exists(filename))
            {
                string[] lines = File.ReadAllLines(filename);

                if (lines.Length > 0)
                {
                    int.TryParse(lines[0], out _score); // Update score from file

                    for (int i = 1; i < lines.Length; i++)
                    {
                        string line = lines[i];

                        string[] parts = line.Split(':');

                        if (parts.Length >= 2)
                        {
                            string[] data = parts[1].Split(',');

                            if (parts[0] == "Simple Goal" && data.Length == 4)
                            {
                                loadedGoals.Add(new SimpleGoal(data[0], data[1], data[2], bool.Parse(data[3])));
                            }
                            else if (parts[0] == "Eternal Goal" && data.Length == 3)
                            {
                                loadedGoals.Add(new EternalGoal(data[0], data[1], data[2]));
                            }
                            else if (parts[0] == "Check List Goal" && data.Length == 6)
                            {
                                loadedGoals.Add(new CheckListGoal(data[0], data[1], data[2], int.Parse(data[4]), int.Parse(data[3]), int.Parse(data[5])));
                            }
                        }
                    }
                }
            }
            else
            {
                Console.WriteLine("File not found.");
            }

            return loadedGoals;
        }

        public void RecordEvent()
        {
            _goals = LoadGoals();
            ListGoals(_goals);

            Console.WriteLine("Which goal did you accomplish?");
            int goalIndex = int.Parse(Console.ReadLine()) - 1;

            if (goalIndex >= 0 && goalIndex < _goals.Count)
            {
                Goal accomplishedGoal = _goals[goalIndex];
                
                int pointsEarned = 0; // Initialize points earned to 0
                
                // Call the appropriate method to record event for the specific goal type
                if (accomplishedGoal is SimpleGoal)
                {
                    pointsEarned = ((SimpleGoal)accomplishedGoal).RecordSimpleEvent();
                }
                else if (accomplishedGoal is EternalGoal)
                {
                    pointsEarned = ((EternalGoal)accomplishedGoal).RecordEternalEvent();
                }
                else if (accomplishedGoal is CheckListGoal)
                {
                    pointsEarned = ((CheckListGoal)accomplishedGoal).RecordCheckListEvent();
                }
                
                _score += pointsEarned; // Update _score with the earned points
                SaveGoals();
                ListGoals(_goals);
                Console.WriteLine($"You earned {pointsEarned} points.");
            }
            else
            {
                Console.WriteLine("Invalid input");
            }
        }



    }              
               
}