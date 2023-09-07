namespace BoarderSolution
{
    public class Program
    {
        static void Main(string[] args)
        {
            var item = new BoardItem("Refactor this mess", DateTime.Now.AddDays(2));
            item.AdvanceStatus();
            var anotherItem = new BoardItem("Encrypt user data", DateTime.Now.AddDays(10));

            Board.items.Add(item);
            Board.items.Add(anotherItem);

            foreach (var boardItem in Board.items)
            {
                boardItem.AdvanceStatus();
            }

            foreach (var boardItem in Board.items)
            {
                Console.WriteLine(boardItem.ViewInfo());
            }

        }
    }
}