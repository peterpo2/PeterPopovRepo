# BoardR - Task Organizing System
_Part 3_

## 1. Description

**BoardR** is a task-management system which will evolve in the next several weeks. During the course of the project, we will follow the best practices of `Object-Oriented Programming` and `Design`. 

## 2. Goals
Your task will be to further specify the **BoardItem** class into two more specialized classes: **Task** and **Issue**.   
You will achieve this by applying the OOP principle of **Inheritance**.

## 3. Task class
### Description
Instances of this class will be used to describe work that needs to be done. They extend the functionality of a board item by adding an **Assignee** property.

### Constructor
- Parameters: `title` (_string_), `assignee` (_string_) and `dueDate` (_DateTime_)
- A new Task should have its initial status as `ToDo`
#### Example:
```cs
var task = new Task("Test the application flow", "Peter", DateTime.Now.AddDays(1));
Console.WriteLine(task.Title); // Test the application flow
Console.WriteLine(task.DueDate); // 29/01/2020 3:11:07 PM
Console.WriteLine(task.Status); // ToDo
Console.WriteLine(task.Assignee); // Peter
```

### Properties
- Inherits all props from **BoardItem**
- **Assignee**: _string_, should never be null or empty, length should be [5..30]

> **Hint**: When you implement the assignee setter, you will need to think of a way to also add an activity log. The activity log list is currently a private field inside the base class. There is a way to expose the ability to add new activity logs **only for derived** classes.

> **Hint II** - You will need to find a way to reuse the `Status` property and `AdvanceStatus()`, `RevertStatus()` methods from the base class while also having the ability to start at `Status.ToDo`. The easiest way to achieve this is to pass an `initialStatus` value from the child to the parent when constructing a new instance.

### Methods
- Inherits all methods from **BoardItem**

#### Example
```cs
var task = new Task("Test the application flow", "Peter", DateTime.Now.AddDays(1));
task.AdvanceStatus();
task.AdvanceStatus();
task.Assignee = "George";
Console.WriteLine(task.ViewHistory());
```
```
[20200519|16:24:12.1770]Created Task: 'Test the application flow', [ToDo|20-05-2020]
[20200519|16:24:12.1774]Status changed from ToDo to InProgress
[20200519|16:24:12.1774]Status changed from InProgress to Done
[20200519|16:24:12.1776]Assignee changed from Peter to George
```

## 4. Issue class
### Description
Instances of this class will be used to describe a problem that needs attention. Their status will start at open
### Constructor
- Parameters: `title` (_string_), `description` (_string_), `dueDate` (_DateTime_)
- A new Issue should have its initial status as `Open`
#### Example
```cs
var issue = new Issue(
      "App flow tests?", 
      "We need to test the App!",
      DateTime.Now.AddDays(1));
Console.WriteLine(issue.Title); // App flow tests?
Console.WriteLine(issue.Description); // We need to test the App!
Console.WriteLine(issue.Status); // Open
```
### Properties
- Inherit all properties from BoardItem
- **Description**: _string_ - if someone tries to assign `null` set to `No description`
    - Description can't be changed once set.
### Methods
- Inherits all methods from BoardItem

#### Example

```cs
var issue = new Issue("App flow tests?", "We need to test the App!", DateTime.Now.AddDays(1));
issue.AdvanceStatus();
issue.DueDate = issue.DueDate.AddDays(1);
Console.WriteLine(issue.ViewHistory());
```
```
[20200519|16:33:55.0610]Created Issue: 'App flow tests?', [Open|20-05-2020]. Description: We need to test the App!
[20200519|16:33:55.0612]Status changed from Open to ToDo
[20200519|16:33:55.0614]DueDate changed from '20-05-2020' to '21-05-2020'
```

## 5. Board class

The board class should continue to work as before without any changes.

```cs
var tomorrow = DateTime.Now.AddDays(1);
var issue = new Issue("App flow tests?", "We need to test the App!", tomorrow);
var task = new Task("Test the application flow", "Peter", tomorrow);

Board.AddItem(issue);
Board.AddItem(task);
Console.WriteLine(Board.TotalItems); // 2
```

> Remarks: 
You must have noticed that we can treat two distinct types (Issue and Task) as similar and add them into a collection of a more general type (BoardItem). This feature is another OOP principle supported by C#. We'll study more about this principle in the next sessions.