using System;

namespace prove
{


    public class SimpleGoal : Goal
    {

        public bool _isComplete;

        public SimpleGoal(string name, string description, string points, bool isComplete) : base(name, description, points)
        {
            _isComplete = isComplete;
        }

        public int RecordSimpleEvent()
        {
            if (!_isComplete)
            {
                _isComplete = true;
                return int.Parse(_points); 
            }

            return 0;
        }

    
    }

}