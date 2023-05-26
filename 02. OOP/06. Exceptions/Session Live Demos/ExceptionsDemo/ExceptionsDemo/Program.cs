namespace ExceptionsDemo
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<string> errorLog = new List<string>();
            //You should create a text.txt file in the folder C:\text;
            using (StreamWriter sw = new StreamWriter(@"C:\text\text.txt", true))
            {

                Console.WriteLine("Enter your age: ");

                bool success = false;

                while (!success)
                {
                    try
                    {
                        int age = int.Parse(Console.ReadLine());

                        if (age < 0 || age > 150)
                        {
                            throw new InvalidUserInputException("Age must be between 0 and 150.");
                        }
                        success = true;
                        Console.WriteLine($"You are {age} years old.");
                    }
                    catch (FormatException ex)
                    {
                        Console.WriteLine("Enter your age: ");
                        //errorLog.Add($"{DateTime.Now} - {ex.Message}");
                        sw.WriteLine($"{DateTime.Now} - {ex.Message}");
                    }
                    catch (InvalidUserInputException ex)
                    {
                        Console.WriteLine("Enter your age: ");
                        //errorLog.Add($"{DateTime.Now} - {ex.Message}");
                        sw.WriteLine($"{DateTime.Now} - {ex.Message}");
                    }

                    finally
                    {
                        Console.WriteLine("This is always executed!");
                    }
                }
                Console.WriteLine("Program was executed without interruption.");

                Console.WriteLine("List of errors:");

                foreach (string exceptionInfo in errorLog)
                {
                    Console.WriteLine(exceptionInfo);
                }
            }
            /*int personAge = int.Parse(Console.ReadLine());

            try
            {
                Person person = new Person(personAge);
                Console.WriteLine(person.Age);
            }
            catch (InvalidUserInputException ex)
            {
                errorLog.Add($"{DateTime.Now} - {ex.Message}");
            }*/

            


        }
    }
}