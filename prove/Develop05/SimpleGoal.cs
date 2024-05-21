using System;

public class SimpleGoal : Goal
{

    public bool _isComplete;

    public SimpleGoal(string name, string description, string points) : base(name, description, points)
    {
        _isComplete = false;


    }

  
}