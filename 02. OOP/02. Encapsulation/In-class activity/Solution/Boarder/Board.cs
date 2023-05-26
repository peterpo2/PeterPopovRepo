using System;
using System.Collections.Generic;

namespace Boarder
{
    // This class is 'static' in order to prevent making instances of it.
    public static class Board
    {
        private static List<BoardItem> items = new List<BoardItem>();

        public static void AddItem(BoardItem item)
        {
            if (items.Contains(item))
            {
                throw new InvalidOperationException("item already exists");
            }

            items.Add(item);
        }

        public static int TotalItems
        {
            get
            {
                return items.Count;
            }
        }
    }
}
