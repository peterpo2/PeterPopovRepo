using System;

namespace UserSystem
{
    class Program
    {
        static void Main()
        {
            string command = Console.ReadLine();
            string[,] userTable = new string[4, 2];

            while (command != "end")
            {
                ProcessCommand(command, userTable);

                command = Console.ReadLine();
            }
        }

        static void ProcessCommand(string command, string[,] userTable)
        {
            string[] commandArgs = command.Split(" ");
            if (commandArgs.Length < 3)
            {
                PrintError("Too few parameters.");
                return;
            }

            string username = commandArgs[1];
            if (username.Length < 3)
            {
                PrintError("Username must be at least 3 characters long");
                return;
            }

            string password = commandArgs[2];
            if (password.Length < 3)
            {
                PrintError("Password must be at least 3 characters long.");
                return;
            }

            switch (commandArgs[0])
            {
                case "register":
                    RegisterUser(username, password, userTable);
                    break;
                case "delete":
                    DeleteUser(username, password, userTable);
                    break;
                default:
                    PrintError("Invalid command");
                    break;
            }
        }

        static void RegisterUser(string username, string password, string[,] userTable)
        {
            if (FindUserPosition(username, userTable) >= 0)
            {
                PrintError("Username already exists.");
                return;
            }

            int freePositionIndex = FindFreePosition(userTable);
            if (freePositionIndex == -1)
            {
                PrintError("The system supports a maximum number of 4 users.");
                return;
            }

            StoreUser(username, password, userTable, freePositionIndex);

            PrintInfo("Registration completed successfully!");
        }

        static void DeleteUser(string username, string password, string[,] userTable)
        {
            int accountIndex = FindUserPosition(username, userTable);
            if (accountIndex == -1 || userTable[accountIndex, 1] != password)
            {
                PrintError("Invalid account/password.");
                return;
            }

            DeleteUser(userTable, accountIndex);

            PrintInfo("Account has been deleted!");
        }

        static int FindFreePosition(string[,] userTable)
        {
            return FindUserPosition(null, userTable);
        }

        static int FindUserPosition(string username, string[,] userTable)
        {
            for (int i = 0; i < userTable.GetLength(0); i++)
            {
                if (userTable[i, 0] == username)
                {
                    return i;
                }
            }

            return -1;
        }

        static void DeleteUser(string[,] userTable, int userIndex)
        {
            StoreUser(null, null, userTable, userIndex);
        }

        static void StoreUser(string username, string password, string[,] userTable, int freePositionIndex)
        {
            userTable[freePositionIndex, 0] = username;
            userTable[freePositionIndex, 1] = password;
        }

        static void PrintError(string message)
        {
            Print(message, ConsoleColor.Red);
        }

        static void PrintInfo(string message)
        {
            Print(message, ConsoleColor.Green);
        }

        static void Print(string message, ConsoleColor color)
        {
            Console.ForegroundColor = color;
            Console.WriteLine(message);
            Console.ResetColor();
        }
    }
}
