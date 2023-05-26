
using Dealership.Models.Contracts;
using System.Text;

namespace Dealership.Models
{
    public class Comment : IComment
    {
        public const int CommentMinLength = 3;
        public const int CommentMaxLength = 200;
        public const string InvalidCommentError = "Content must be between 3 and 200 characters long!";

        private const string CommentSeparator = "    ----------";

        public Comment(string content, string author)
        {
            Validator.ValidateIntRange(content.Length, CommentMinLength, CommentMaxLength, InvalidCommentError);

            Content = content;
            Author = author;
        }

        public string Content { get; }

        public string Author { get; }

        public override string ToString()
        {
            var sb = new StringBuilder();

            sb.AppendLine(CommentSeparator);
            sb.AppendLine($"    {Content}");
            sb.AppendLine($"      User: {Author}");
            sb.Append(CommentSeparator);

            return sb.ToString();
        }
    }
}
