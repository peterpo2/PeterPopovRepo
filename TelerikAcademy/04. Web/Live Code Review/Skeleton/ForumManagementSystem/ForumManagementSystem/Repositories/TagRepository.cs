using ForumManagementSystem.data;
using ForumManagementSystem.Models;
using Microsoft.EntityFrameworkCore;

namespace ForumManagementSystem.Repositories
{
    public class TagRepository : ITagRepository
    {
        private readonly ApplicationContext context;

        public TagRepository(ApplicationContext context)
        {
            this.context = context;
        }

        public void Create(Tag tag)
        {
            context.Tags.Add(tag);
            context.SaveChanges();

        }

        public void Delete(Tag tag)
        {
            context.Tags.Remove(tag);
            context.SaveChanges();
        }

        public List<Tag> GetAll()
        {
            return context.Tags.ToList();
        }

        public Tag GetById(int id)
        {
            return GetAll().FirstOrDefault(u => u.Id == id);
        }

        public Tag GetByName(string name)
        {
            return GetAll().FirstOrDefault(u => u.Name == name);
        }

        public void Update(Tag tag)
        {
            context.SaveChanges();
        }
    }
}
