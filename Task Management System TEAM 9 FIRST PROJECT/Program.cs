using Task_Management_System.Enums;

namespace Task_Management_System
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Bug newBug = new Bug();
            newBug.Title = "The program freezes when the Log In button is clicked.";
            newBug.Description = "This needs to be fixed quickly!";
            newBug.BugPriority = Priority.High;
            newBug.BugSeverity = Severity.Critical;
            newBug.BugStatus = Status.Active;
            newBug.AssignedTo = "Senior Developer";
            newBug.StepsToReproduce = new List<string>() { "1. Open the application", "2. Click \"Log In\"", "3. The application freezes!" };
            Developer developer1 = new Developer("John");
            Developer developer2 = new Developer("Jane");

            // create a new developer
            Developer newDeveloper = new Developer("Mike");

            // create an existing team
            Team team = new Team("Team 1");

            // add existing developers to the team
            team.AddDeveloper(developer1);
            team.AddDeveloper(developer2);

            // create some bugs
            Bug bug1 = new Bug("The program freezes when the Log In button is clicked.", "This needs to be fixed quickly!", Priority.High, Severity.Critical);
            Bug bug2 = new Bug("The program crashes when the Save button is clicked.", "This needs to be fixed urgently!", Priority.High, Severity.Critical);
            Bug bug3 = new Bug("The program shows the wrong data in the report.", "This needs to be fixed before the next release.", Priority.Medium, Severity.Low);

            // assign bugs to the existing developers
            bug1.AssignDeveloper(developer1);
            bug2.AssignDeveloper(developer2);

            // assign all Critical bugs to the new developer
            List<Bug> criticalBugs = new List<Bug>();
            criticalBugs.Add(bug1);
            criticalBugs.Add(bug2);
            team.AssignBugsToDeveloper(newDeveloper, criticalBugs);

            // display the bugs assigned to the new developer
            Console.WriteLine("Bugs assigned to " + newDeveloper.Name + ":");
            foreach (Bug bug in newDeveloper.AssignedBugs)
            {
                Console.WriteLine(bug.Title);
            }
        }

    }
}
