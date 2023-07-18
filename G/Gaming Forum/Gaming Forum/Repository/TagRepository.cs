using Gaming_Forum.Data;
using Gaming_Forum.Models;
using Gaming_Forum.Repository.Contracts;

namespace Gaming_Forum.Repository
{
    public class TagRepository : ITagRepository
    {
        private readonly ApplicationContext context;

        public TagRepository(ApplicationContext context)
        {
            this.context = context;
        }

        public Tag Create(Tag tag)
        {
            context.Tags.Add(tag);
            context.SaveChanges();
            return tag;
        }

        public Tag GetById(int tagId)
        {
            return context.Tags.FirstOrDefault(t => t.Id == tagId);
        }

        public Tag GetByValue(string value)
        {
            var tags = context.Tags.ToList();
            return tags.FirstOrDefault(t => t.Value.Equals(value, StringComparison.OrdinalIgnoreCase));
        }

        public List<Tag> GetAll()
        {
            return context.Tags.ToList();
        }

    }
}
