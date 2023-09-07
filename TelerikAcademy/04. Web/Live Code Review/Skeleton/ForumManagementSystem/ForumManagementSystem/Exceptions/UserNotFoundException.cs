namespace ForumManagementSystem.Exceptions
{
    public class UserNotFoundException : ApplicationException
    {
        public UserNotFoundException(string attribute, string value)
            : base($"User with {attribute} {value} not found!")
        {
        }
    }
}
