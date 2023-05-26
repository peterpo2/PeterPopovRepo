namespace Baseball_Game
{
    internal class Program
    {
        public int CalPoints(string[] ops)
        {
            Stack<int> record = new Stack<int>();
            int sum = 0;
            foreach (string op in ops)
            {
                if (op == "C")
                {
                    int removed = record.Pop();
                    sum -= removed;
                }
                else if (op == "D")
                {
                    int previous = record.Peek();
                    int doubled = previous * 2;
                    record.Push(doubled);
                    sum += doubled;
                }
                else if (op == "+")
                {
                    int previous = record.Pop();
                    int twoBack = record.Peek();
                    int added = previous + twoBack;
                    record.Push(previous);
                    record.Push(added);
                    sum += added;
                }
                else
                {
                    int value = int.Parse(op);
                    record.Push(value);
                    sum += value;
                }
            }
            return sum;
        }
    }
}