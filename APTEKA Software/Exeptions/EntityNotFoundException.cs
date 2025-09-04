namespace APTEKA_Software.Exeptions
{
    public class EntityNotFoundException : ApplicationException
    {
        public EntityNotFoundException(string message)
            : base($"{message} not found.")
        {
        }
    }

}
