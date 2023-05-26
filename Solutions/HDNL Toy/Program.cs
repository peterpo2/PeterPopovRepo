namespace HDNL_Toy
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int lines = int.Parse(Console.ReadLine());

            var myQueue = new Queue<string>();
            var myStack = new Stack<string>();

            int intervalCounter = 0;
            string intervals = string.Empty;


            for (int i = 0; i < lines; i++)
            {
                myQueue.Enqueue(Console.ReadLine());
            }

            while (myQueue.Count > 0)
            {
                string currentTag = myQueue.Peek();
                if (myStack.Count == 0)
                {
                    PushDeqeue(myQueue, myStack, currentTag);
                    Console.WriteLine(CreateOpeningElement(intervals, currentTag));
                    continue;
                }
                int previousValue = GetValue(myStack.Peek());
                int currentValue = GetValue(currentTag);

                if (previousValue < currentValue)
                {
                    intervalCounter++;
                    PushDeqeue(myQueue, myStack, currentTag);
                    intervals = new string(' ', intervalCounter);
                    Console.WriteLine(CreateOpeningElement(intervals, currentTag));
                }
                else if (previousValue == currentValue)
                {
                    Console.WriteLine(CreateClosingElement(intervals, myStack.Pop()));
                    Console.WriteLine(CreateOpeningElement(intervals, currentTag));
                    PushDeqeue(myQueue, myStack, currentTag);
                }
                else
                {

                    while (previousValue > currentValue)
                    {
                        intervals = new string(' ', intervalCounter);
                        Console.WriteLine(CreateClosingElement(intervals, myStack.Pop()));
                        if (myStack.Count != 0) { intervalCounter--; }
                        if (myStack.Count == 0)
                        {
                            break;
                        }
                        previousValue = GetValue(myStack.Peek());
                        if (previousValue == currentValue)
                        {
                            intervals = new string(' ', intervalCounter);
                            Console.WriteLine(CreateClosingElement(intervals, myStack.Pop()));
                            PushDeqeue(myQueue, myStack, currentTag);
                            Console.WriteLine(CreateOpeningElement(intervals, currentTag));
                        }
                    }
                    if (currentValue > previousValue)
                    {
                        PushDeqeue(myQueue, myStack, currentTag);
                        Console.WriteLine(CreateOpeningElement(intervals, currentTag));
                        intervalCounter++;
                    }
                }
            }
            while (myStack.Count > 0)
            {

                intervals = new string(' ', intervalCounter);
                Console.WriteLine(CreateClosingElement(intervals, myStack.Pop()));
                if (myStack.Count != 0) { intervalCounter--; }
            }
        }
        static void PushDeqeue(Queue<string> myQueue, Stack<string> myStack, string currentTag)
        {
            myStack.Push(currentTag);
            myQueue.Dequeue();
        }

        static int GetValue(string str)
        {
            int num = int.Parse(str.Substring(1));
            return num;
        }
        static string CreateOpeningElement(string intervals, string value)
        {
            return $"{intervals}<{value}>";
        }


        static string CreateClosingElement(string intervals, string value)
        {
            return $"{intervals}</{value}>";
        }
    }
}
