# BoardR - Task Organizing System
_Part 2_

## 1. Description

**BoardR** is a task-management system which will evolve in the next several weeks. During the course of the project, we will follow the best practices of `Object-Oriented Programming` and `Design`. 

## 2. Goals
Your goals are to properly encapsulate **BoardItem** and **Board**.

You will also enhance individual board items and the board with the ability to **keep track of the history of their changes**.

## 3. Encapsulate the BoardItem Class
### Issues
Currently, the BoardItem class works well, but may be **misused**. All the members of the class are available outside the class, which may lead to mistakes. For example, the **status** can be freely changed:
```cs
var item = new BoardItem("Refactor this mess", DateTime.Now.AddDays(2));
item.AdvanceStatus(); // properly changing the status
item.AdvanceStatus();
Console.WriteLine(item.ViewInfo()); // Status: InProgress

item.status = Status.Open; // ??
Console.WriteLine(item.ViewInfo()); // Status: Open
```
> **Note**:
> Developers will not intentionally break code like in the example above; 
> however, a new developer on the team will not be aware that 
> we are not supposed to directly manipulate the **status** 
> field. This can lead to subtle bugs.
We can solve the issue with the **status** field by making it private. 
```csharp
private Status status;
```
To let the outside code read this value, we can create a getter:
```cs
public Status Status 
{
   get 
   {
      // return the value of the status field
      return this.status; 
   }
}
```
If you test this code now, compilation error will occur:

```cs
var item = new BoardItem("Refactor this mess", DateTime.Now.AddDays(2));
Console.WriteLine(item.Status); // OK: you can 'get' the value
item.status = Status.Open; // compilation error
```

### Description

We are done with the status field, but there are two more fields - **dueDate** and **title**. They are still public and can be freely changed. Encapsulate those fields.
- dueDate - can be changed, but the new value should not be in the past.
- title - can be changed, but the new title must be at least 5 characters long, and no more than 30.

You can use setters the perform the validations:
```cs
public string Title 
{
   get 
   {
      return this.title; 
   }
   set 
   {
      // 'value' is the special variable holding the new value
      Console.WriteLine($"New title = {value}");
      Console.WriteLine($"Current title = {this.title}");
      
      // perform validations

      // set only if validated, otherwise throw ex with some meaningful message
      this.title = value;
   }
}
```
> **Note**: The WriteLine-s in the example above are for testing. Remove them when you understand what's going on.

After the changes, test with the following code:
```cs
var item = new BoardItem("Rewrite everything", DateTime.Now.AddDays(1));
            
// compilation error if you uncomment the next line:
// item.title = "Rewrite everything immediately!!!";
            
item.Title = "Rewrite everything immediately!!!"; // property 'set'-ing
Console.WriteLine(item.Title); // property 'get'-ing

item.Title = "Huh?"; // Exception thrown: Please provide a title with length between 5 and 30 chars
```

Perform the same encapsulations for the dueDate field. Ensure that an exception is thrown if the new date is before DateTime.Now

## 4. EventLog class 
### Description
In order to keep track of each operation that we perform on an item or in the board, we need a proper model. At the very least, we need a description of **what** happened - a `string`, and a record of **when** it happened - a `DateTime`. 

An EventLog instance records an event that took place at a specific time. We can't go back in time and change that, so you must find a way to design the class to be effectively **immutable**. ([Hint]('https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/keywords/readonly#readonly-field-example))
### Constructor
- **description**: _string_; throw on null strings
### Properties
- **Description**: _string_ - description of the event that happened
- **Time**: _DateTime_ - when it happened
### Methods
- **ViewInfo**: - should return a displayable string representation of the event, for example `[{Time}]{Description}` e.g. `[20200125|13:57:55.7525]Created task`
#### Example
```cs
var log = new EventLog("An important thing happened");
Console.WriteLine(log.Description); // An important thing happened
Console.WriteLine(log.ViewInfo());  // [20200125|14:02:59.0361]An important thing happened

// if you uncomment any of the next two lines, compilation error must occur! (e.g. use readonly properties)
// log.Description = "new desc";
// log.Time = DateTime.Now;

var log2 = new EventLog(null);
// Unhandled exception. System.ArgumentNullException: Value cannot be null. (Parameter 'description')
```

> **Notes**  
> In the EventLog, we have bundled data (_Description, Time_) with methods that can access the data (_ViewInfo()_)  
> This process of 'bundling' is also known as **Encapsulation**.    
> 
> In addition, each instance of type EventLog is **ensured** to be valid:
> 1) The only constructor forces you and other developers to provide non-null strings
> 2) The datetime is calculated inside the constructor, which means that it will most likely be valid
> 3) There must be no way to change the values of these properties.
>   
> This is a fairly easy example of how we apply Encapsulation to ensure that each instance has a **valid state**  
> Let's take a look at the BoardItem class and how it manages its eventlog history


## 5. BoardItem class
### Extended functionality:
On each of these operations, you should add a new EventLog to the item's history
- When Constructed - `Item created: 'Refactor this mess', [Open|25-01-2020]`
- When Property changed - `{Property} changed from {previous} to {new}`
- When Revert/AdvanceStatus - `Status changed from {previous} to {next}` or some error message if the status cannot be changed.  

Add a new method:  
**string ViewHistory()** - returns the history for this item instance; display **info** about each event log on a new line in chronological order.

View the example below to get a better idea.

Some things to consider:
- How will you store all the EventLogs - will you need some sort of collection?
- If you choose a collection, will you make it **public/private** or something else?
- If the collection of event logs is public, will somebody be able to **modify it from outside** - perhaps adding a EventLog for **an event that never happened**?
- How do you approach this problem without breaking Encapsulation?


#### Example
```cs
var item = new BoardItem("Refactor this mess", DateTime.Now.AddDays(2));
item.DueDate = item.DueDate.AddYears(2);
item.Title = "Not that important";
item.RevertStatus();
item.AdvanceStatus();
item.RevertStatus();

Console.WriteLine(item.ViewHistory());

Console.WriteLine("\n--------------\n");

var anotherItem = new BoardItem("Don't refactor anything", DateTime.Now.AddYears(10));
anotherItem.AdvanceStatus();
anotherItem.AdvanceStatus();
anotherItem.AdvanceStatus();
anotherItem.AdvanceStatus();
anotherItem.AdvanceStatus();
Console.WriteLine(anotherItem.ViewHistory());
```
#### Output
```
[20200125|14:13:33.1216]Item created: 'Refactor this mess', [Open|25-01-2020]
[20200125|14:13:33.1218]DueDate changed from '25-01-2020' to '25-01-2030'
[20200125|14:13:33.1219]Title changed from 'Refactor this mess' to 'Not that important'
[20200125|14:13:33.1221]Can't revert, already at Open
[20200125|14:13:33.1223]Status changed from Open to Todo
[20200125|14:13:33.1223]Status changed from Todo to Open

--------------

[20200125|14:13:33.1288]Item created: 'Don't refactor anything', [Open|25-01-2030]
[20200125|14:13:33.1288]Status changed from Open to Todo
[20200125|14:13:33.1288]Status changed from Todo to InProgress
[20200125|14:13:33.1288]Status changed from InProgress to Done
[20200125|14:13:33.1288]Status changed from Done to Verified
[20200125|14:13:33.1288]Can't advance, already at Verified
```
## 6. Board class
Let's encapsulate the Board class, too. In the previous part, we had a **public** `List<BoardItem>` that was responsible for storing our items.  
This is convenient, but the List class has too many methods, and not all of them are useful for our Board.  
Check the examples:
```cs
var item1 = new BoardItem("Implement login/logout", DateTime.Now.AddDays(3));
var item2 = new BoardItem("Secure admin endpoints", DateTime.Now.AddDays(5));

Board.Items.Add(item1);
Board.Items.Add(item2); 
```
So far so good, we want to be able to add items.
```cs
int count = Board.Items.Count;
```
Also good, knowing how many items we have in total is useful.
```cs
Board.Items.Clear();
```
This looks like a problem - we don't want the allow others to Clear() the board - this will delete all items. What about all the unfinished tasks?
```cs
Board.Items.Add(item1);
Board.Items.Add(item2); 
Board.Items.Add(item1); 
Board.Items.Add(item1);

int count = Board.Items.Count;
// count: 4
```
The Add() method was useful, but it doesn't prevent you from adding duplicate items.
```cs
Board.Items[0] = new BoardItem("Just replaced the first item with a random one.", DateTime.Now);
```
This is also something that we want to prevent, the original first item is now gone.

There are more than 30 methods that the `List` class provides - like removing, sorting, reversing, replacing. The Board class exposes all of them through the Items property which is of **type List**.  
In other words, _the design of the Board class does not reflect the problems that we are trying to solve._

The first step is to fix the main problem - the List is **public**. You should consider hiding it from the outside world.  
Now the Items property is no longer visible outside the class, but we are no longer able to do anything with the Board. We should be able to at least add items. We can achieve that by introducing a new method to the Board:  

**void AddItem(BoardItem item)** - adds to the list of items inside the Board. This method has access to the private List. However, this will all be pointless if you leave the method as it is and just add items without checking if they exist. So, you should add the necessary check and see if such an item **already exists**. _Hint_: you can use the `bool List.Contains()` method to see if an item was already added.

The other useful functionality that we are missing is knowing how many items we have in the Board. You can add a property:  
**int TotalItems** - returns the count of items inside the Board.

```cs
var item1 = new BoardItem("Implement login/logout", DateTime.Now.AddDays(3));
var item2 = new BoardItem("Secure admin endpoints", DateTime.Now.AddDays(5));

Board.AddItem(item1); // add item1
Board.AddItem(item2); // add item2
Board.AddItem(item1); // do nothing - item1 already in the list
Board.AddItem(item2); // do nothing - item2 already in the list

int count = Board.TotalItems;
// count: 2
```

Let's focus on the following code:
```cs
Board.AddItem(item1); // add item1
Board.AddItem(item2); // add item2
Board.AddItem(item1); // do nothing - item1 already in the list
Board.AddItem(item2); // do nothing - item2 already in the list
```

While the **AddItem()** method is successful in adding only unique items, when a duplicate is detected the method invocation does **nothing**. Developers should be notified when an operation they perform goes wrong - for example, when you are accessing an index out of range in an array, you get an exception.

**Refactor** the code to throw an InvalidOperationException when a duplicate is added.

```cs
Board.AddItem(item1);
Board.AddItem(item2);
Board.AddItem(item1);
```

#### Output
```cs
Unhandled exception. System.InvalidOperationException: item already exists
   at Boarder.Board.AddItem(BoardItem item) ...
```

> **Notes**  
> The devs using our board will now be aware of this exceptional case and will handle it. You will also handle it in a future part of the workshop.