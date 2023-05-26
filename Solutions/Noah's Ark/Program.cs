namespace Noah_s_Ark
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            SortedDictionary<string, int> animals = new SortedDictionary<string, int>();
            for (int i = 0; i < n; i++)
            {
                string input = Console.ReadLine();
                if (!animals.ContainsKey(input))
                {
                    animals.Add(input, 1);
                }
                else
                {
                    animals[input]++;
                }
            }
            foreach (var item in animals)
            {
                Console.WriteLine($"{item.Key} {item.Value} {IsEven(item.Value)}");
            }
        }
        public static string IsEven(int value)
        {
            if (value % 2 == 0)
            {
                return "Yes";
            }
            else
            {
                return "No";
            }
        }
    }
}