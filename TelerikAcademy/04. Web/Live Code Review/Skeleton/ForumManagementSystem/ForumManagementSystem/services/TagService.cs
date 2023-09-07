using ForumManagementSystem.Exceptions;
using ForumManagementSystem.Models;
using ForumManagementSystem.Repositories;
using System;

namespace ForumManagementSystem.services
{
    public class TagService : ITagService
    {
        private readonly ITagRepository repository;

        public TagService(ITagRepository repository)
        {
            this.repository = repository;
        }

        public void Create(Tag tag)
        {
            bool duplicateExists = true;
            try
            {
                repository.GetByName(tag.Name);
            }
            catch (EntityNotFoundException e)
            {
                duplicateExists = false;
            }
            if (duplicateExists)
            {
                throw new DuplicateEntityException("Tag", "name", tag.Name);
            }
            repository.Create(tag);
        }

        public void Delete(int id)
        {
            Tag tag = repository.GetById(id);
            repository.Delete(tag);
        }

        public List<Tag> GetAll()
        {
            return repository.GetAll();
        }

        public Tag GetById(int id)
        {
            return repository.GetById(id);
        }

        public void Update(Tag tag)
        {
            bool duplicateExists = true;
            try
            {
                Tag existingTag = repository.GetByName(tag.Name);
                if (existingTag.Id == tag.Id)
                {
                    duplicateExists = false;
                }
            }
            catch (UserNotFoundException e)
            {
                duplicateExists = false;
            }
            if (duplicateExists)
            {
                throw new DuplicateEntityException("Tag", "name", tag.Name);
            }
            repository.Update(tag);
        }
    }
}
