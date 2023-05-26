# UserSystem
You are given a working user system which supports registering and deleting users. A _user_ is a combination of username and password.  
The database is represented by a matrix where each row is a user:

| | |
|-|-|
|john95|p@ss|
|john96|p@ss|
|null|null|
|null|null|

### Constraints 
_(all are implemented)_  
- The system currently supports a maximum of 4 users.
- The username and password must each be at least 3 characters long
- A username must be unique inside the database
- Error messages are printed in red, success message are printed in green

### Task

- Refactor the `Main()` method (_without breaking the existing functionality_)
- Extract and reuse methods where there is **obvious code repetition**
- Extract methods so that code **readability will be improved**

### Hints

- The code that prints a message with a specific color is an obvious repetition. Find and extract it, so that it is reusable. There are other parts where repetition is not that obvious, you must identify them on your own.
- There are two main _commands_ - `delete` and `register`, which are currently part of the main method. Extracting those commands in their own methods will improve readability immensely.

#### Sample input
```
register john95 p@ss
register john95
register john95 p@ss
register xx yoo
register john96 pp
register john96 p@ss
register john97 p@ss
register john98 p@ss
register john99 p@ss
delete john98 pass
delete john98 p@ss
register john99 p@ss
end
```
#### Sample output
```
Registration completed successfully!
Too few parameters.
Username already exists.
Username must be at least 3 characters long.
Password must be at least 3 characters long.
Registration completed successfully!
Registration completed successfully!
Registration completed successfully!
The system supports a maximum number of 4 users.
Invalid account/password.
Account has been deleted!
Registration completed successfully!
```
