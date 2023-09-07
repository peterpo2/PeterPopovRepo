namespace ForumManagementSystem.Exceptions
{
    public class UnauthorizedOperationException : ApplicationException
    {
        public UnauthorizedOperationException(string msg)
            :base(msg)
        {

        }
    }
}
