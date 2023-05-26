namespace ExceptionHandlerDemo
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Initialize exception handler
            ExceptionHandler handler = new ExceptionHandler();

            // Start of main application logic, can be extracted in a separate class

            //Check for valid input, so the while loop can stop executing when the input is valid
            bool validInput = false;

            while (!validInput)
            {
                try
                {
                    Console.WriteLine("Please enter a name between 2 and 20 characters.");
                    string name = Console.ReadLine();
                    Console.WriteLine("Please enter an age between 0 and 150 years");
                    int age = int.Parse(Console.ReadLine());
                    Person person = new Person(age,name);
                    validInput = true;
                }
                catch (Exception e)
                {
                    //Handler exception through the exceptionHandler class
                    validInput = handler.HandleException(e);
                    //Print message for invalid input to the user
                    handler.ReportError();
                }

            }
            //End of main application logic

            //Display log of all errors
            handler.ListErrors();
        }
    }
}