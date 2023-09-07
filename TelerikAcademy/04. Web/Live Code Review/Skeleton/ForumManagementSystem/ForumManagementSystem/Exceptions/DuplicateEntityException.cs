namespace ForumManagementSystem.Exceptions
{
    public class DuplicateEntityException : ApplicationException
    {
        public DuplicateEntityException(string type, string attribute, string value) 
            :base($"{type} with {attribute} {value} already exists.")
        {

        }
    }
}
