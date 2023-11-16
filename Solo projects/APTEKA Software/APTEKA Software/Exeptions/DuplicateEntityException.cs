namespace APTEKA_Software.Exeptions
{
    public class DuplicateEntityException : ApplicationException
    {
        public DuplicateEntityException(string message)
            : base(message)
        {
        }
    }

}
