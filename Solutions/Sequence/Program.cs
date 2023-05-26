namespace Sequence
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] input = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
            int K = input[0];
            int N = input[1];

            int result = 0;

            if (N == 0)
            {
                Console.WriteLine(result);
                return;
            }

            int[] arrayResults = new int[N];
            arrayResults[0] = K;
            int counter = 1;

            if (N == 1)
            {
                Console.WriteLine(arrayResults[0]);
                return;
            }

            int index = 0;

            while (counter < N)
            {
                K = arrayResults[index];

                if (counter < N)
                {
                    arrayResults[counter] = K + 1;
                    counter++;
                }

                if (counter < N)
                {
                    arrayResults[counter] = 2 * K + 1;
                    counter++;
                }

                if (counter < N)
                {
                    arrayResults[counter] = K + 2;
                    counter++;
                }

                index++;
            }

            Console.WriteLine(arrayResults[N - 1]);
        }
    }
}