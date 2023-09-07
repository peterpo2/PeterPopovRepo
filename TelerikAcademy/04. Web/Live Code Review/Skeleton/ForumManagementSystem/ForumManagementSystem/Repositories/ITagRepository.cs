using ForumManagementSystem.Models;

namespace ForumManagementSystem.Repositories
{
    public interface ITagRepository
    {
        List<Tag> GetAll();

        Tag GetById(int id);

        Tag GetByName(string name);

        void Create(Tag tag);

        void Update(Tag tag);

        void Delete(Tag tag);
    }
}
