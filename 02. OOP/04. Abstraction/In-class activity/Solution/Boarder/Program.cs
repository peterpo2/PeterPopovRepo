﻿using Boarder.Models;
using System;

namespace Boarder
{
    class Program
    {
        static void Main(string[] args)
        {
            var tomorrow = DateTime.Now.AddDays(1);
            var task = new Task("Write unit tests", "Peter", tomorrow);
            var issue = new Issue("Review tests", "Someone must review Pesho's tests.", tomorrow);

            Board.AddItem(task);
            Board.AddItem(issue);
            task.AdvanceStatus();
            issue.AdvanceStatus();

            Board.LogHistory();
        }
    }
}