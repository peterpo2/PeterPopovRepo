using Gaming_Forum.Models;

namespace Gaming_Forum.Repository.Contracts
{
    public interface ITagRepository
    {
        Tag Create(Tag tag);
        Tag GetById(int tagId);
        Tag GetByValue(string value);
        List<Tag> GetAll();
    }
}
