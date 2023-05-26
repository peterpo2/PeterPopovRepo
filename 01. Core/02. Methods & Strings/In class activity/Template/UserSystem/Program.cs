using System;

namespace UserSystem
{
    class Program
    {
        static void Main(string[] args)
        {
            string command = Console.ReadLine();
            string[,] userTable = new string[4, 2];

            // main loop
            while (command != "end")
            {
                string[] commandArgs = command.Split(" ");
                switch (commandArgs[0])
                {
                    case "register":
                        {
                            // validate arguments
                            if (commandArgs.Length < 3)
                            {
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.WriteLine("Too few parameters.");
                                break;
                            }

                            string username = commandArgs[1];
                            string password = commandArgs[2];

                            // validate username
                            if (username.Length < 3)
                            {
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.WriteLine("Username must be at least 3 characters long.");
                                break;
                            }

                            // validate password
                            if (password.Length < 3)
                            {
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.WriteLine("Password must be at least 3 characters long.");
                                break;
                            }

                            // check if username exists
                            bool usernameExists = false;
                            for (int i = 0; i < userTable.GetLength(0); i++)
                            {
                                if (userTable[i, 0] == username)
                                {   
                                    usernameExists = true;
                                }
                            }

                            if (usernameExists)
                            {
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.WriteLine("Username already exists.");
                                break;
                            }

                            // find free slot
                            int freeSlotIndex = -1;
                            for (int i = 0; i < userTable.GetLength(0); i++)
                            {
                                if (userTable[i, 0] == null)
                                {
                                    freeSlotIndex = i;
                                }
                            }

                            // no free slots
                            if (freeSlotIndex == -1)
                            {
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.WriteLine("The system supports a maximum number of 4 users.");
                                break;
                            }

                            // save user
                            userTable[freeSlotIndex, 0] = username;
                            userTable[freeSlotIndex, 1] = password;

                            Console.ForegroundColor = ConsoleColor.DarkGreen;
                            Console.WriteLine("Registered user.");

                            break;
                        }
                    case "delete":
                        {
                            // validate arguments
                            if (commandArgs.Length < 3)
                            {
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.WriteLine("Too few parameters.");
                                break;
                            }

                            string username = commandArgs[1];
                            string password = commandArgs[2];

                            // validate username
                            if (username.Length < 3)
                            {
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.WriteLine("Username must be at least 3 characters long");
                                break;
                            }

                            // validate password
                            if (password.Length < 3)
                            {
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.WriteLine("Password must be at least 3 characters long.");
                                break;
                            }

                            // find account to delete
                            int accountIndex = -1;
                            for (int i = 0; i < userTable.GetLength(0); i++)
                            {
                                if (userTable[i, 0] == username &&
                                    userTable[i, 1] == password)
                                {
                                    accountIndex = i;
                                }
                            }

                            if (accountIndex == -1)
                            {
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.WriteLine("Invalid account/password.");
                                break;
                            }

                            userTable[accountIndex, 0] = null;
                            userTable[accountIndex, 1] = null;

                            Console.ForegroundColor = ConsoleColor.DarkGreen;
                            Console.WriteLine("Deleted account.");

                            break;
                        }
                }

                Console.ResetColor();
                // read next command
                command = Console.ReadLine();
            }
        }
    }
}
