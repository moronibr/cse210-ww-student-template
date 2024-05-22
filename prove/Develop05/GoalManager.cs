using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;


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
                            Console.WriteLine("4");
                            break;
                        case 5:
                            Console.WriteLine("5");
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

                        _goals.Add(new SimpleGoal(name, description, points));

                        SimpleGoal simpleGoal = new SimpleGoal(name, description, points);
                        
                        break;
                    case 2:

                        Console.WriteLine("What is the name of your goal?");

                        string _name = Console.ReadLine();

                        Console.WriteLine("What is a short description of it?");

                        string _description = Console.ReadLine();

                        Console.WriteLine("What is the amount of points associated with this goal?");

                        string _points = Console.ReadLine();

                        _goals.Add(new EternalGoal(_name, _description, _points));

                        EternalGoal eternalGoal = new EternalGoal(_name, _description, _points);

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

                        _goals.Add(new CheckListGoal(_checkName, _checkDescription, _checkPoints, int.Parse(_checkTarget), int.Parse(_checkBonus)));

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
                    Console.WriteLine($"{index + 1}. [] {goal._name} ({goal._description})");
                }
                if (goal is EternalGoal)
                {
                    Console.WriteLine($"{index + 1}. [] {goal._name} ({goal._description})");
                }
                if (goal is CheckListGoal)
                {
                    Console.WriteLine($"{index + 1}. [] {goal._name} ({goal._description}) -- Currently completed: {0}");
                }
                
            }
            
            
        }

        private void SaveGoals()
        {
            Console.WriteLine("What is the filename for the goal file?");

            string _filename = Console.ReadLine();

            using (StreamWriter outputFile = new StreamWriter(_filename))
            {
                foreach (var goal in _goals)
                {
                    if (goal is SimpleGoal)
                    {
                        SimpleGoal simpleGoal = (SimpleGoal)goal;
                        outputFile.WriteLine($"{simpleGoal._name}|{simpleGoal._description}|{simpleGoal._points}");

                    }
                    if (goal is EternalGoal)
                    {
                        EternalGoal eternalGoal = (EternalGoal)goal;
                        outputFile.WriteLine($"{eternalGoal._name}|{eternalGoal._description}|{eternalGoal._points}");
                    }
                    if (goal is CheckListGoal)
                    {
                        CheckListGoal checkListGoal = (CheckListGoal)goal;
                        outputFile.WriteLine($"{checkListGoal._name}|{checkListGoal._description}|{checkListGoal._points}|{checkListGoal._target}|{checkListGoal._bonus}");
                    }
                }
            }
        }
       




    }
