﻿using CosmeticsShop.Commands;
using CosmeticsShop.Exceptions;

using System;
using System.Collections.Generic;

namespace CosmeticsShop.Core
{
    public class Engine
    {
        private const string TERMINATION_COMMAND = "exit";

        private readonly CommandFactory commandFactory;
        private readonly CosmeticsRepository productRepository;

        public Engine()
        {
            this.commandFactory = new CommandFactory();
            this.productRepository = new CosmeticsRepository();
        }

        public void Start()
        {
            while (true)
            {
                string commandLine = Console.ReadLine();
                if (commandLine.ToLower() == TERMINATION_COMMAND)
                {
                    break;
                }

                this.ProcessCommand(commandLine);
            }
        }

        private void ProcessCommand(string commandLine)
        {
            try
            {
                string commandName = this.ParseCommand(commandLine);
                List<string> parameters = this.ParseParameters(commandLine);
                ICommand command = this.commandFactory.CreateCommand(commandName, this.productRepository);
                string result = command.Execute(parameters);
                Console.WriteLine(result);
            }
            catch (InvalidUserInputException e)
            {
                Console.WriteLine(e.Message);
            }
            catch (DuplicateEntityException e)
            {
                Console.WriteLine(e.Message);
            }
            catch (InvalidOperationException e)
            {
                Console.WriteLine(e.Message);
            }
            catch (Exception)
            {
                Console.WriteLine("Unknown error has occurred. Please try another command.");
            }
        }

        private string ParseCommand(string commandLine)
        {
            string commandName = commandLine.Split(" ")[0];
            return commandName;
        }

        private List<string> ParseParameters(string commandLine)
        {
            string[] commandParts = commandLine.Split(" ");
            List<string> parameters = new List<string>();
            for (int i = 1; i < commandParts.Length; i++)
            {
                parameters.Add(commandParts[i]);
            }
            return parameters;
        }
    }
}