using System;
using System.Collections.Generic;
using Boarder.Models;

namespace Boarder
{
    public static class Board
    {
        private static readonly List<BoardItem> Items = new List<BoardItem>();

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
    }
}
