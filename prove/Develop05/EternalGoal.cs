using System;

namespace prove
{
    public class EternalGoal : Goal
    {
        public EternalGoal(string name, string description, string points) : base(name, description, points)
        {
        }

        public int RecordEternalEvent()
        {
            
            int points = int.Parse(_points); 
            return points; 
            
        }
    }

}    