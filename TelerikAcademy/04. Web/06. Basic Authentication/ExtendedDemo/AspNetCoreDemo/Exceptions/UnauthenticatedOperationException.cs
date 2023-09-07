using System;

namespace AspNetCoreDemo.Exceptions
{
    public class UnauthenticatedOperationException : ApplicationException
    {
        public UnauthenticatedOperationException(string message)
            : base(message)
        {
        }
    }
}
