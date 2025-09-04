namespace APTEKA_Software.Exeptions
{
    public class UnauthorizedOperationException : ApplicationException
    {
        public UnauthorizedOperationException(string message)
            : base(message)
        {
        }
    }

}
