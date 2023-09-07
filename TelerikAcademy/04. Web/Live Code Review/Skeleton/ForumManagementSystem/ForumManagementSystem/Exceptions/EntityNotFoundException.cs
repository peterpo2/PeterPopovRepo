namespace ForumManagementSystem.Exceptions
{
    public class EntityNotFoundException : ApplicationException
    {
        public EntityNotFoundException(string message)
            : base(message)
        {

        }

        public EntityNotFoundException(string type, int id)
            : base(string.Format("{0} with id {1} not found"))
        {

        }
    }
}
