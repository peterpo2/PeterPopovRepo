namespace _05_Foo_Method_3
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] array = { 5, 2, 4, -1, 0, 5 };
            Foo(array);

            // Returns -1, 5, 4, 2, 5
            // Ignores 0
        }
        public static void Foo(int[] array)
        {
            Stack<int> stack = new Stack<int>();

            foreach (int element in array)
            {
                if (element == 0)
                {
                    continue;
                }
                if (element < 0)
                {
                    Console.WriteLine(element);
                }
                else
                {
                    stack.Push(element);
                }
            }
            while (stack.Count > 0)
            {
                Console.WriteLine(stack.Pop());
            }
        }
    }
}