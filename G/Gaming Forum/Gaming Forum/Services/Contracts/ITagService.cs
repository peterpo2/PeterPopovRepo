using Gaming_Forum.Models;
using Gaming_Forum.Models.Dto;

namespace Gaming_Forum.Services.Contracts
{
    public interface ITagService
    {
        Tag CreateTag(TagDto tagDto);
        Tag GetTagById(int tagId);
        List<Tag> GetAllTags();
    }
}
