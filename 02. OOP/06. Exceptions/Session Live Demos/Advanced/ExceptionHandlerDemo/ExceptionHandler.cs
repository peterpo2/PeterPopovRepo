using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExceptionHandlerDemo
{
    public class ExceptionHandler
    {
        private const string newLineSeparator = "================================";
        private List<string> logs = new List<string>();
        public bool HandleException(Exception ex)
        {

            //Handle exceptions differently, according to the exception type
            
            if (ex is ArgumentOutOfRangeException)
            {
                logs.Add($"Argument out of range exception: {DateTime.Now} {ex.Message}");
                return false;
            }
            else if (ex is ArgumentException)
            {
                logs.Add($"Argument exception: {ex.Message}");
                return false;
            }
            else if(ex is FormatException)
            {
                logs.Add($"Format exception: {DateTime.Now} {ex.Message} {ex.StackTrace}");
                return false;
            }

            return true;
        }

        public void ReportError() 
        {
            Console.WriteLine(newLineSeparator);
            Console.WriteLine("Invalid data - please try again.");
            Console.WriteLine(newLineSeparator);
        }
        public void ListErrors() 
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("List of exceptions:");
            foreach (string log in logs)
            {
                sb.AppendLine(log);
                sb.AppendLine(newLineSeparator);
            }

            Console.WriteLine(sb.ToString());
        }

    }
}
