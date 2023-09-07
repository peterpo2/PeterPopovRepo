# C# Technical Questionnaire

This is a list of questions that you will most likely be asked on formal assessments as part of the Alpha program as well as on technical interviews during your job application process. Regard these questions as your personal learning guide as well as an accurate measurement of your knowledge and understanding of fundamental technical topics. The questions are separated into two groups:

**1.   The first group are questions that we expect you know the answer of in great details and could answer and explain additional questions regarding them. These questions are related to the material we have covered during our classes.**

**2.   The second set consists of questions that we expect you to know about and can give a basic answer, without diving deep into the subject. These questions are usually based on additional resources we provide inside the Learning Management System. You should research those topics in your spare time.**

## Core Programming

#### Questions that you must be able to answer in detail:

- What is C#? Is C# managed or unmanaged? Why is C# considered statically typed and type safe?
- What is the _.NET Framework_? What is _.NET Core_? What are the differences between these two major flavors (variations) of .NET?
- What is the difference between `continue` and `break` statements in C#?
- What is _method overloading_?  
- What is _string immutability_? What are the benefits of string immutability?
- What is the difference between `string` and `StringBuilder` 

#### Questions you should have general knowledge of and should answer in a few words:

- What is the difference between `as` and `is` operators in C#?
- Why use the _Nullable Coalescing Operator_ in C#?
- What is a _delegate_ in C#?
- What is _.NET Standard_?
- What is the role of the Common Language Runtime?
- How is C# code converted into machine instructions?
- What is Ahead-of-time (AOT) compilation and Intermediate Language (IL) in C#?
- What is Just-in-time (JIT) compilation in C#?
- Explain the garbage collection process in C#?

***

## Object-oriented programming (OOP)

#### Questions that you must be able to answer in detail:

- What is the difference between a class and an object?
- What is the difference between a struct and a class? 
- What is the difference between static and instance class members (fields, methods & properties)?
- What is the difference between static and instance constructors?
- What is the difference between `const` and `readonly` variables in C#?
- What is the difference between value types and referent types?
- What is the difference between passing data by value and passing data by reference?
- What is the difference between `==` and `Equals()`?
- What is boxing and unboxing in C#?
- What is data encapsulation and what are the benefits of it?
- What are access modifiers?
- What is inheritance and what are the benefits of it?
- What is the purpose of the modifier `sealed`?
- What is composition in terms of OOP? 
- What is polymorphism and what are the benefits of it?
- What is the difference between overloading and overriding?
- What is the purpose of the `virtual` keyword? What are virtual members?
- What is the difference between abstract classes and interfaces?
- What are exceptions? How does the _try-catch_ construction work? What is the purpose of the `finally` block?
- What is the purpose of unit tests?
- What makes a unit test high-quality?

#### Questions you should have general knowledge of and should answer in a few words:

- What is the difference between `new` and `override`?
- What is the difference between _in_, _out_ and _ref_ parameters in C#? 
- What is _member hiding_ in C#?
- Explain _partial_ class in C#?
- What are indexers in C#?
- What are attributes in C#?
- What is the difference between _dispose_ and _finalize_ variables in C#?
- Explain access modifier _protected internal_ in C#? 

***

## Data Structures and Algorithms

#### Questions that you must be able to answer in detail:

- What is a data structure?  
- What is an Abstract Data Type (ADT)?
- What operations can we perform on data structures?
- What is the difference between static and dynamic data structures? Give examples.  
- What is a linear data structure? What is a non-linear data structure? Give examples.
- What is a linked list data structure?   
- What is a doubly-linked list?
- What is the difference between **Array**, **List**, and **LinkedList** in C#?
- What is an algorithm?  
- Why do we need to do an algorithm analysis?  
- What is a stack data structure?   
- What operations can be performed on a stack?  
- List some applications of the stack data structure.  
- What is a queue data structure?   
- What operations can be performed on a queue?  
- List some applications of the queue data structure.  
- What is linear search?
- What is binary search?
- What are hashing functions? How are they used by the hash table?
- What is the difference between **HashSet** and **Dictionary** in C#? 
- What is a tree?
- What is post-order, pre-order, in-order traversal?
- What is a binary tree?
- What is a binary search tree?
- What is depth-first traversal and how does it work?
- What is breadth-first traversal and how does it work?
- What is a recursive function?
- What are the advantages and disadvantages of the recursion?

#### Questions you should have general knowledge of and should answer in a few words:

- Suggest a way to determine whether a linked list has a loop.  
- How does the merge sort work?  
- How does the selection sort work?  
- Explain divide and conquer algorithms?
- What is dynamic programming?
- What is backtracking?
- What is a graph data structure?  
- What are the applications of graph data structure?  
- What is interpolation search?
- Describe how heaps work.

***

## Databases

#### Questions that you must be able to answer in detail:

- What is SQL?
- What are the different types of table relations?
- What type of JOIN clauses do you know in SQL?
- What is Object–relational Mapping (ORM)?
- What is database normalization?

#### Questions you should have general knowledge of and should answer in a few words:

- What is a database transaction?

***

## Web

#### Questions that you must be able to answer in detail:

- What is HTTP?
- What are the main HTTP verbs (methods)?
- What are HTTP headers?
- What are HTTP status codes?
- What is the format of an HTTP request and response?
- What is the difference between HTTP GET and HTTP POST?
- What is the difference between HTTP PUT and HTTP POST?
- What are query parameters?
- What is a REST?
- What are the REST principles?
- What is an API and how can you use it?
- What is a web server?
- What is Dependency Inversion?
- What is Inversion of Control?
- What is Dependency Injection?
- Explain the difference between Dependency Inversion, Inversion of Control & Dependency Injection.

#### Questions you should have general knowledge of and should answer in a few words:

- What is HTTP/2? How is it different?
- What is HTTPS?
- What is Web caching?
- What is the difference between dynamic web pages and single page applications (SPA)? 
- Monolithic architecture vs Microservice architecture?

***

## ASP.NET Core and SOLID principles

#### Questions that you must be able to answer in detail:

- What is an IoC Container?
- Explain startup process in ASP.NET Core.
- Explain services lifetime cycles in ASP.NET Core.
- Explain Middleware in ASP.NET Core.
- Explain the MVC design pattern.
- What is a Controller?
- What is routing?
- What is wwwroot folder in ASP.NET Core?
- What is a View?
- What is a Partial View?
- How are Views resolved in ASP.NET Core?
- What is the purpose of the \_Layout.cshtml?
- What is the purpose of the \_ViewImports.cshtml?
- What is the purpose of the \_ViewStart.cshtml?
- What is SOLID?
- Give an example for each of the SOLID principles (also think of a real life example).

#### Questions you should have general knowledge of and should answer in a few words:

- How do dependency injection containers work under the hood?
- Explain the repository pattern. What are the benefits of it?
- What are the differences between client-side and server-side validation?
- What are the benefits of each type of validation?
- What is an asynchronous request?
