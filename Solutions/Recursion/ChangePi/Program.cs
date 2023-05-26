using System.Text;

namespace ChangePi
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            Console.WriteLine((ChangePi(input)).ToString());
        }

        static String ChangePi(string input)
        {
            StringBuilder sb = new StringBuilder();
            if (input.Length == 0)
            {
                return "";
            }

            else if (input.Length >= 2 && input[0] == 'p' && input[1] == 'i')
            {
                sb.Append("3.14");
                return sb + ChangePi(input.Substring(2, input.Length - 2));
            }

            else 
            {
                sb.Append(input[0]);
                return sb + ChangePi(input.Substring(1, input.Length - 1));
            }

        }
    }
}