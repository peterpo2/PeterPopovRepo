namespace NoahsArk
{
    public class Program
    {
        static void Main()
        {
            int n = int.Parse(Console.ReadLine());

            SortedDictionary<string, int> ark = new SortedDictionary<string, int>();

            for (int i = 0; i < n; i++)
            {
                string animal = Console.ReadLine();

                if (!ark.TryAdd(animal, 1)) 
                {
                    ark[animal]++;
                }
            }

            foreach (var animal in ark)
            {
                string message = animal.Value % 2 == 0 ? "Yes" : "No";
                Console.WriteLine($"{animal.Key} {animal.Value} {message}");
            }
        }
    }
}