using System;

namespace prove
{
    public class CheckListGoal : Goal
    {
        public int _amountCompleted;
        public int _target;
        public int _bonus;

        public CheckListGoal(string name, string description, string points, int target, int bonus, int amountCompleted) : base(name, description, points)
        {   
            _amountCompleted = amountCompleted;
            _target = target;
            _bonus = bonus;            
        }

        public int RecordCheckListEvent()
        {
            if (_amountCompleted < _target)
            {
                _amountCompleted++;
                int pointsEarned = int.Parse(_points);
                return pointsEarned;
            }
            else
            {
                _amountCompleted++;
                return _bonus; 
            }
        }
    }
}
