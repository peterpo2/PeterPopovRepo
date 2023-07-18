using Gaming_Forum.Models;
using Gaming_Forum.Models.Dto;
using Gaming_Forum.Repository.Contracts;
using Gaming_Forum.Services.Contracts;

namespace Gaming_Forum.Services
{
    public class TagService : ITagService
    {
        private readonly ITagRepository tagRepository;

        public TagService(ITagRepository tagRepository)
        {
            this.tagRepository = tagRepository;
        }

        public Tag CreateTag(TagDto tagDto)
        {
            var existingTag = tagRepository.GetByValue(tagDto.Value);

            if (existingTag != null)
            {
                return existingTag;
            }

            var newTag = new Tag
            {
                Value = tagDto.Value
            };

            return tagRepository.Create(newTag);
        }


        public Tag GetTagById(int tagId)
        {
            return tagRepository.GetById(tagId);
        }

        public List<Tag> GetAllTags()
        {
            return tagRepository.GetAll();
        }

    }
}
