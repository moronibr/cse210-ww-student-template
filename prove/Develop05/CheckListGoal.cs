using System;

public class CheckListGoal : Goal
{
    public int _amountCompleted;
    public int _target;
    public int _bonus;

    public CheckListGoal(string name, string description, string points, int target, int bonus) : base(name, description, points)
    {
        _target = target;
        _bonus = bonus;
    }
}