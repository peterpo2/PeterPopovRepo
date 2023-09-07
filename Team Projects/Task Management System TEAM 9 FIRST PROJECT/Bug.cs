using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using Task_Management_System.Enums;

namespace Task_Management_System
{
    public abstract class Bug
    {
            public string Title { get; set; }
            public string Description { get; set; }
            public Priority Priority { get; set; }
            public Severity Severity { get; set; }
            public Status Status { get; set; }
            public Developer AssignedDeveloper { get; set; }

            public Bug(string title, string description, Priority priority, Severity severity)
            {
                Title = title;
                Description = description;
                Priority = priority;
                Severity = severity;
                Status = Status.Active;
            }

            public void AssignDeveloper(Developer developer)
            {
                AssignedDeveloper = developer;
                Status = Status.Assigned;
            }
        }
        //public string Title { get; set; }
        //public string Description { get; set; }
        //public Priority BugPriority { get; set; }
        //public Severity BugSeverity { get; set; }
        //public Status BugStatus { get; set; }
        //public string AssignedTo { get; set; }
        //public List<string> StepsToReproduce { get; set; }

        //public string Title;
        //public string Description;
        //public string StepsToReproduce;
        //public int Priority;
        //public int Severity;
        //public string AssignedTo;
        //public string Status;
        //public Bug(string title, string description, string stepsToReproduce, int priority, int severity, string assignedTo, string status)
        //{
        //    Title = title;
        //    Description = description;
        //    StepsToReproduce = stepsToReproduce;
        //    Priority = priority;
        //    Severity = severity;
        //    AssignedTo = assignedTo;
        //    Status = status;
        //}

        //public override string ToString()
        //{
        //    return $"Title: {Title}\nDescription: {Description}\nSteps to Reproduce: {StepsToReproduce}\nPriority: {Priority}\nSeverity: {Severity}\nAssigned To: {AssignedTo}\nStatus: {Status}\n";
        //}

    }

    // ...

    //var newBug = new Bug
    //{
    //    Id = 1,
    //    Title = "The program freezes when the Log In button is clicked",
    //    Description = "This needs to be fixed quickly!",
    //    StepsToReproduce = new List<string> { "1. Open the application; 2. Click 'Log In'; 3. The application freezes!" },
    //    Priority = Priority.High,
    //    Severity = Severity.Critical,
    //    Status = Status.Active,
    //    Assignee = seniorDeveloper,
    //    Comments = new List<Comment>(),
    //    History = new List<string>()
    //};

