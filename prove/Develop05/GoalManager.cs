using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;


    public class GoalManager
    {
        public List<Goal> _goals;
        public int _score;

       
        public GoalManager()
        {

        }

        public void Start()
        {
            _goals = new List<Goal>();
            _score = 0;

            int menu = 0;
        
            while (menu != 6)
                {
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
                                    SimpleGoal simpleGoal = new SimpleGoal(name, description, points);

                                    
                                    break;
                                case 2:
                                   
                                    break;
                                case 3:
                                    CreateGoal();
                                    break;
                                case 4:
                                    Console.WriteLine("Going back to the main menu");
                                    break;
                                default:
                                    Console.WriteLine("Invalid input");
                                    break;
                            }


                        }
                            break;
                        case 2:
                            Console.WriteLine("2");
                            break;
                        case 3:
                            Console.WriteLine("3");
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

        }







    }
