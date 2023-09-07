using ForumManagementSystem.Models;

namespace ForumManagementSystem.Repositories
{
    public interface IPhoneRepository
    {
        List<Phone> GetAll();

        Phone Create(Phone phone);

        void Delete(Phone phone);

        string GenerateRandomPhone(string candidateChars, int length);
    }
}
