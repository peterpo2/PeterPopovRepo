using System;
using System.Collections.Generic;
using Boarder.Loggers;
using Boarder.Models;

namespace Boarder
{
    public static class Board
    {
        private static readonly List<BoardItem> Items = new List<BoardItem>();
        private static readonly ILogger logger;

        public static void AddItem(BoardItem item)
        {
            if (Items.Contains(item))
            {
                throw new InvalidOperationException("item already exists");
            }

            Items.Add(item);
        }

        public static int TotalItems
        {
            get
            {
                return Items.Count;
            }
        }

        public static void LogHistory()
        {
            foreach (BoardItem item in Items)
            {
                Console.WriteLine(item.ViewHistory());
            }
        }
    }
}
