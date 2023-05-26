# BoardR - Task Organizing System
_Part 4_

## 1. Description

**BoardR** is a task-management system which will evolve in the next several weeks. During the course of the project, we will follow the best practices of `Object-Oriented Programming` and `Design`. 

## 2. Goals
Your task we will refactor the **BoardItem** class to serve as a true base class. We will also provide **interfaces** for the main components of our application

You will achieve this by applying the OOP principle of **Abstraction**.

## 3. BoardItem class
### Description
Currently, the purpose of this class is to serve as a base class for the **Task** and **Issue**. Most of the logic in both classes is the same and we moved that logic into the base class so we can reuse it.

However, while **Task** and **Issue** are specific and serve different purposes (tasks have assignees, issues have descriptions), the **BoardItem** may have become too general and now it represents an incomplete task/issue. 
So, creating instances of that class may lead to some problems where **it is not clear what kind of item we have in the board**. To prevent accidental instantiation of the class, we can mark it as `abstract`.

```cs
var tomorrow = DateTime.Now.AddDays(1);
var issue = new Issue("App flow tests?", "We need to test the App!", tomorrow);
var task = new Task("Test the application flow", "Peter", tomorrow);

// this MUST not compile: "Cannot create an instance of the abstract class or interface BoardItem"
var item = new BoardItem("title", tomorrow);
```

One problem with reusing logic was that both **Task** and **Issue** have the same functionality for Advancing/Reverting statuses. For example, **Issues** should only be Open or Verified, while Tasks should be able to use all Statuses from Todo to Verified. Abstract classes provide us with the benefit that we can define `abstract` methods inside of them. Abstract methods are intended to be given implementation by classes that derive from the abstract class. Go ahead and mark `AdvanceStatus()` and `RevertStatus()` as abstract. You will notice that the compiler wants you to remove the body.

```cs
// Abstract methods have no body
public abstract void RevertStatus(); 

public abstract void AdvanceStatus();
```

## 4. Issue class
### Description
If you go to the class now you will see that the compiler complains - "_Issue does not implement inherited abstract method_". 

> **Note**: This is because abstract methods MUST be implemented in derived classes. Otherwise, if you create an instance of the `Issue` class and call `AdvanceStatus()`, what will happen if there is no code to be run?

Provide implementation for both methods. `AdvanceStatus()` should set the status as `Verified` and do nothing if already `Verified`. `RevertStatus()` should set `Verified` to `Open` and do nothing if already opened. Both methods should also log what they did. (Remember that in a previous activity we made `AddEventLog()` is protected and you have access to it.)


#### Example

```cs
var tomorrow = DateTime.Now.AddDays(1);
var issue = new Issue("App flow tests?", "We need to test the App!", tomorrow);

issue.RevertStatus();
issue.AdvanceStatus();
issue.AdvanceStatus();
issue.RevertStatus();

Console.WriteLine(issue.ViewHistory());
```
```
[20200617|14:07:50.2606]Created Issue: 'App flow tests?', [Open|18-06-2020]. Description: We need to test the App!
[20200617|14:07:50.2607]Issue status already Open
[20200617|14:07:50.2608]Issue status set to Verified
[20200617|14:07:50.2608]Issue status already Verified
[20200617|14:07:50.2608]Issue status set to Open
```

## 5. Task class
### Description
This class must also implement the abstract methods. The implementation can be different from the one in the `Issue` class, which is a huge benefit.
The flow for the advance method is `Todo -> InProgress -> Done -> Verified`. The revert method has that flow reversed.

#### Example

```cs
var tomorrow = DateTime.Now.AddDays(1);
var task = new Task("App flow tests?", "Peter", tomorrow);

task.RevertStatus();
task.AdvanceStatus();
task.AdvanceStatus();
task.RevertStatus();
task.AdvanceStatus();
task.AdvanceStatus();

Console.WriteLine(task.ViewHistory());
```
```
[20200617|14:17:51.5744]Created Task: 'App flow tests?', [Todo|18-06-2020]
[20200617|14:17:51.5746]Task status already Todo
[20200617|14:17:51.5747]Task changed from Todo to InProgress
[20200617|14:17:51.5747]Task changed from InProgress to Done
[20200617|14:17:51.5747]Task changed from Done to InProgress
[20200617|14:17:51.5747]Task changed from InProgress to Done
[20200617|14:17:51.5747]Task changed from Done to Verified
```

## 6. Logging BoardItems
### Description
Currently, we are logging the history of each board item by calling the `ViewHistory()` method from some instance. What is we want to log all history? The Board class maintains the collection of items, but it is private and inaccessible from the outside world. Fortunately, we can add a method to that class that does the logging.
### Methods
`void LogHistory()` - should be accessible from outside the class. This method must iterate over the items and access their history (through `BoardItem.ViewHistory()`). Write that history to the console.

#### Examples
```cs
var tomorrow = DateTime.Now.AddDays(1);
var task = new Task("Write unit tests", "Peter", tomorrow);
var issue = new Issue("Review tests", "Someone must review Peter's tests.", tomorrow);

Board.AddItem(task);
Board.AddItem(issue);
task.AdvanceStatus();
issue.AdvanceStatus();

Board.LogHistory();
```
```
[20200617|15:59:32.2325]Created Task: 'Write unit tests', [Todo|18-06-2020]
[20200617|15:59:32.2331]Task changed from Todo to InProgress
[20200617|15:59:32.2327]Created Issue: 'Review tests', [Open|18-06-2020]. Description: Someone must review Peter's tests.
[20200617|15:59:32.2331]Issue status set to Verified
```

> **Notes**. The `ViewHistory()` method is defined on the BoardItem class, that's why you can call that method. The Board is **not concerned** if the concrete instance behind the current **BoardItem** is a **Task** or an **Issue**.

## 7. ILogger
### Description
Instead of the `Board` using the `Console`, we can move the logging logic into a dedicated class. This way, we can choose to log to a different place. For example, into a file and not to the console. However, if we have a call to `Console.WriteLine` inside `Board.LogHistory()` there is no easy way to change that without editing the class. 

> **Note**: When refactoring, we want to be able to edit **as few classes as possible**.

We can provide an abstraction to the Board that provides the signature for the necessary logging method. We can use an interface for that - `ILogger`.

Create a new folder 'Loggers', and inside of it create a new interface file - `ILogger`

### Methods
`void Log(string value);` - this is enough, interface methods don't have implementation, they only define the signature.

We will implement the interface later.

> **Notes** - now that we have the interface, we can use it to control where the Board class logs items
> We'll talk about the OOP principle of polymorphism and we can change behavior at runtime in the next part.