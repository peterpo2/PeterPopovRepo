using ForumManagementSystem.Models;
using ForumManagementSystem.Repositories;

namespace ForumManagementSystem.services
{
    public class PhoneService : IPhoneService
    {
        private readonly IPhoneRepository phoneRepository;

        public PhoneService(IPhoneRepository phoneRepository)
        {
            this.phoneRepository = phoneRepository;
        }

        public Phone Create(Phone phone)
        {
            return phoneRepository.Create(phone);
        }

        public void Delete(Phone phone)
        {
            phoneRepository.Delete(phone);
        }

        public string GenerateRandomPhone(string candidateChars, int length)
        {
            return phoneRepository.GenerateRandomPhone(candidateChars, length);
        }

        public List<Phone> GetAll()
        {
            return phoneRepository.GetAll();
        }
    }
}
