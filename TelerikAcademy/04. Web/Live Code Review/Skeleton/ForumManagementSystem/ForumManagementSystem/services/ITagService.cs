using ForumManagementSystem.Models;

namespace ForumManagementSystem.services
{
    public interface ITagService
    {
        List<Tag> GetAll();

        Tag GetById(int id);

        void Create(Tag tag);

        void Update(Tag tag);

        void Delete(int id);
    }
}
