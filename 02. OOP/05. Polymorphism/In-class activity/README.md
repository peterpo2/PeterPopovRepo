# BoardR - Task Organizing System
_Part 5_

## 1. Description

**BoardR** is a task-management system which will evolve in the next several weeks. During the course of the project, we will follow the best practices of `Object-Oriented Programming` and `Design`. 

## 2. Goals
Your task will be to provide implementation for the `ILogger` interface from the previous activity and to override some of the behavior of `Task` and `Issue`  
You will achieve this by applying the OOP principle of **Polymorphism**

> **Notes:** You must have noticed that in the previous two activities we were dealing with Tasks and Issues, which are two kinds of BoardItem. The Board class stores those two types into a collection of type BoardItem:

```cs
public static class Board
{
      // ... code ...
      public static void AddItem(BoardItem item) { /* ... code ... */ }
      // ... code ...
}

// inside Program.Main():
Task task = new Task("Write unit tests", "Peter", tomorrow);
Issue issue = new Issue("Review tests", "Someone must review Peter's tests.", tomorrow);

Board.AddItem(task);  // treating type Task as type BoardItem
Board.AddItem(issue); // treating type Issue as type BoardItem
```

> **Notes:** From the Boards perspective, it has applied the **OO principle of Abstraction**, because it accepts all subtypes of a more abstract type - the `BoardItem`. 
On the other hand, each `Task` is polymorphic because it can be treated as a `BoardItem` or as a `Task`. The same applies for `Issue`. You will see many other examples throughout your career, where one line of code can be viewed as an example of two or more principles.

## 3. ConsoleLogger class
### Description

Remember the `ILogger` that we left from the previous activity? We said that we can use it to change the behavior of the `Board.LogHistory()` method and make it log to different outputs - console, file, etc..
Currently, the method looks like this:
```cs
public static void LogHistory()
{
      foreach (BoardItem item in Items)
      {
            Console.WriteLine(item.ViewHistory());
      }
}
```
So, how can we use the interface to remove the `Console.WriteLine` from there? We can pass it as a parameter to the method! The ILogger has this method: `void Log(string value);`. It declares that the ILogger implementation will know how to log, you just need to pass them a **string**. So, we can do this:
```cs
public static void LogHistory(ILogger logger) // accept an ILogger type
{
      foreach (BoardItem item in Items)
      {
            // call the Log() method and give it a string. (the ViewHistory() method returns a string)
            logger.Log(item.ViewHistory()); 
      }
}
```

Now, all that we need is a logger. We can create a ConsoleLogger, for example. Add a new file inside the 'Loggers' folder and write the class inside it.

```cs
namespace Boarder.Loggers
{
    public class ConsoleLogger : ILogger
    {
    }
}
```

You will notice that the `ILogger` is underlined as having an error in Visual Studio with the message "_ConsoleLogger does not implement interface member ILogger.Log(string)_". That's why we say the interfaces **act like contracts** - they will guarantee that classes implementing them provide implementation for all declared methods. Go ahead and add a `Log()` method to the `ConsoleLogger`. Implement so it writes the provided string to the console. 

After you are done, this code should work:
```cs
var tomorrow = DateTime.Now.AddDays(1);
var task = new Task("Write unit tests", "Peter", tomorrow);
var issue = new Issue("Review tests", "Someone must review Peter's tests.", tomorrow);
Board.AddItem(task);
Board.AddItem(issue);

ConsoleLogger logger = new ConsoleLogger();
Board.LogHistory(logger); // pass a ConsoleLogger type where an ILogger is expected:
```
```
[20200618|17:03:47.4035]Created Task: 'Write unit tests', [Todo|19-06-2020]
[20200618|17:03:47.4040]Created Issue: 'Review tests', [Open|19-06-2020]. Description: Someone must review Peter's tests.
```

> **Note**: Now, in theory, **we can change where the Board logs** without touching the `LogHistory` method! We achieved this by applying the principles of **Abstraction** and **Polymorphism**.

## 4. ViewInfo() overriding
### Description
Remember the method? It provides basic info about a BoardItem:
```cs
var tomorrow = DateTime.Now.AddDays(1);
var task = new Task("Write unit tests", "Peter", tomorrow);
var issue = new Issue("Review tests", "Someone must review Peter's tests.", tomorrow);
Console.WriteLine(task.ViewInfo());
Console.WriteLine(issue.ViewInfo());
```
```
'Write unit tests', [Todo|19-06-2020]
'Review tests', [Open|19-06-2020]
```
Currently, it logs information about the `Title`, the `Status`, and the `DueDate`. The method is defined inside the `BoardItem` and can access only properties defined for that class and **cannot** access properties defined in the `BoardItem` deriving classes, such as `Task` and `Issue`. However, `Tasks` have `Assignee` and `Issues` have `Description`. We want to add this useful information to the output of the `ViewInfo()`. We can do this by extending the base behavior inside each deriving class. C# provides a feature called **overriding** that can do this. 

First, we must mark the `ViewInfo()` method as **virtual**.
```cs
public virtual string ViewInfo()
{
      return $"'{this.Title}', [{this.Status}|{this.DueDate.ToString("dd-MM-yyyy")}]";
}
```

Now, we can extend this behavior inside any of the deriving classes:
```cs
public override string ViewInfo()
{
    var baseInfo = base.ViewInfo();

    // output info about the Type, the baseInfo, the Assignee
    return ...
}
```
You can now test the new, extended `ViewInfo()`:
```cs
static void Main() 
{
      var tomorrow = DateTime.Now.AddDays(1);
      BoardItem task = new Task("Write unit tests", "Peter", tomorrow);
      Console.WriteLine(task.ViewInfo());
}
```
The output should be:
```
Task: 'Write unit tests', [Todo|19-06-2020] Assignee: Pesho
```

Override the `ViewInfo()` method inside the `Issue` class. If you do everything correctly, this code should produce the following output:
```cs
var tomorrow = DateTime.Now.AddDays(1);
BoardItem task = new Task("Write unit tests", "Peter", tomorrow);
BoardItem issue = new Issue("Review tests", "Someone must review Peter's tests.", tomorrow);

Console.WriteLine(task.ViewInfo());
Console.WriteLine(issue.ViewInfo());
```
```
Task: 'Write unit tests', [Todo|19-06-2020] Assignee: Peter
Issue: 'Review tests', [Open|19-06-2020] Description: Someone must review Peter's tests.
```

> **Note**: Notice how both task and issue are both inside a variable of type `BoardItem`. Although the method `ViewInfo` is called from the perspective of the base `BoardItem` type, the **most overridden** method is found each time. This is an example of *dynamic, runtime* **polymorphism**.