
namespace APTEKA_Software.Exeptions
{
    public class InsufficientQuantityException : ApplicationException
    {
        public InsufficientQuantityException(string message)
            : base(message)
        {
        }
    }

}
