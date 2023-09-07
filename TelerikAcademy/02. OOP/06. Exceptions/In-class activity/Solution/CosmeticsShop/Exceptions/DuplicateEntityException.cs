using System;

namespace CosmeticsShop.Exceptions
{
    class DuplicateEntityException : ApplicationException
    {
        public DuplicateEntityException(string message)
            : base(message)
        {
        }
    }
}
