namespace Gaming_Forum.Exeptions
{
    public class UnauthorizedOperationException : ApplicationException
    {
        public UnauthorizedOperationException(string message)
            : base(message)
        {
        }
    }

}
