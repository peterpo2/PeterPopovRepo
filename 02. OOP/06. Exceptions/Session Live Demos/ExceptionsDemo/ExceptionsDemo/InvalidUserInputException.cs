using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExceptionsDemo
{
    public class InvalidUserInputException:ApplicationException
    {
        public InvalidUserInputException(string message):base(message) 
        { 
        }
    }
}
