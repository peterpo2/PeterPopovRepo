using ForumManagementSystem.Exceptions;
using ForumManagementSystem.Models;
using ForumManagementSystem.services;
using Microsoft.AspNetCore.Mvc;

namespace ForumManagementSystem.CONTROLLERS
{
    [ApiController]
    [Route("api/tags")]
    public class Tagcontroller : ControllerBase
    {
        private readonly ITagService tagService;

        public Tagcontroller(ITagService tagService)
        {
            this.tagService = tagService;
        }

        [HttpGet]
        public List<Tag> GetAll()
        {
            return tagService.GetAll();
        }

        // TODO
        [HttpGet("{id}")]
        public Tag GetById(int id)
        {
            try
            {

                return tagService.GetById(id);

            }
            catch (EntityNotFoundException e)
            {
                throw new EntityNotFoundException("Tag", id);
            }
        }

        [HttpPost]
        public Tag CreateTag(Tag tag)
        {
            try
            {
                tagService.Create(tag);
            }
            catch (DuplicateEntityException e)
            {
                throw new DuplicateEntityException("Tag", "Name", tag.Name);
            }
            return tag;
        }

        [HttpPut("/{id}")]
        public Tag UpdateTag(int id, Tag tag)
        {
            tagService.Update(tag);
            return tag;
        }

        [HttpDelete("{id}")]
        public void DeleteUser(int id)
        {
            tagService.Delete(id);
        }
    }
}
