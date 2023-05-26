namespace Army_Lunch_2_100
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int soldiersNumber = int.Parse(Console.ReadLine());
            string[] soldiersOrder = new string[soldiersNumber];
            soldiersOrder = Console.ReadLine().Split(' ');

            var sergents = new List<string>();
            var corporals = new List<string>();
            var privates = new List<string>();  

            foreach (var soldier in soldiersOrder)
            {
                if (soldier.StartsWith("C"))
                {
                    corporals.Add(soldier);
                }
                else if (soldier.StartsWith("P"))
                {
                    privates.Add(soldier);
                }
                else if(soldier.StartsWith("S"))
                {
                    sergents.Add(soldier);
                }
            }
            Console.WriteLine($"{string.Join(" ", sergents)} {string.Join(" ", corporals)} {string.Join(" ", privates)}");
        }
    }
}