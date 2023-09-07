using ForumManagementSystem.Models;

namespace ForumManagementSystem.services
{
    public interface IPhoneService
    {
        List<Phone> GetAll();

        Phone Create(Phone phone);

        String GenerateRandomPhone(String candidateChars, int length);

        void Delete(Phone phone);
    }
}
