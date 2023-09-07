using System;

namespace AspNetCoreDemo.Exceptions
{
    public class AuthenticationException : ApplicationException
    {
        public AuthenticationException(string message)
            : base(message)
        {
        }
    }
}
