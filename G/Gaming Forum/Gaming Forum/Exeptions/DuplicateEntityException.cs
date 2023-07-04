namespace Gaming_Forum.Exeptions
{
    public class DuplicateEntityException : ApplicationException
    {
        public DuplicateEntityException(string message)
            : base(message)
        {
        }
    }

}
