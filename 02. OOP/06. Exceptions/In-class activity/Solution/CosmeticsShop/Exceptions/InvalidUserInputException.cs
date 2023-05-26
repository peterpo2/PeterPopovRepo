using System;

namespace CosmeticsShop.Exceptions
{
    class InvalidUserInputException : ApplicationException
    {
        public InvalidUserInputException(string name)
            : base(name)
        {
        }
    }
}
