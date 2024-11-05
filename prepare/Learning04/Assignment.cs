using System;

public class Assignment
{
    public string _studentName { get; set; }
    public string _topic { get; set; }

    public Assignment(string studentName, string topic)
    {
        _studentName = studentName;
        _topic = topic;
    }

    public string GetSummary()
    {
        return $"{_studentName} - {_topic}";
    }
}