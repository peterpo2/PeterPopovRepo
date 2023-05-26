namespace Asteroid_Collision
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Solution solution = new Solution();

            Console.WriteLine("Enter the asteroids as a comma-separated list of integers:");
            int[] asteroids = Console.ReadLine().Split(',').Select(int.Parse).ToArray();

            int[] output = solution.AsteroidCollision(asteroids);
            Console.WriteLine("The resulting state of the asteroids is:");
            Console.WriteLine(string.Join(", ", output));
        }
        public class Solution
        {
            public int[] AsteroidCollision(int[] asteroids)
            {
                Stack<int> stack = new Stack<int>();
                foreach (int asteroid in asteroids)
                {
                    if (asteroid > 0)
                    {
                        stack.Push(asteroid);
                    }
                    else
                    {
                        while (stack.Count > 0 && stack.Peek() > 0 && stack.Peek() < -asteroid)
                        {
                            stack.Pop();
                        }
                        if (stack.Count == 0 || stack.Peek() < 0)
                        {
                            stack.Push(asteroid);
                        }
                        else if (stack.Peek() == -asteroid)
                        {
                            stack.Pop();
                        }
                    }
                }
                return stack.ToArray().Reverse().ToArray();
            }
        }
    }
}