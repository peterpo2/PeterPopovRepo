using ForumManagementSystem.data;
using ForumManagementSystem.Models;
using System.Text;

namespace ForumManagementSystem.Repositories
{
    public class PhoneRepository : IPhoneRepository
    {

        private readonly ApplicationContext context;

        public PhoneRepository(ApplicationContext context)
        {
            this.context = context;
        }

        public Phone Create(Phone phone)
        {
            context.Phones.Add(phone);
            context.SaveChanges();
            return phone;
        }

        public void Delete(Phone phone)
        {
            context.Remove(phone);
            context.SaveChanges();
        }

        public string GenerateRandomPhone(string candidateChars, int length)
        {
            StringBuilder sb = new StringBuilder();
            Random random = new Random();
            for (int i = 0; i < length; i++)
            {
                sb.Append(candidateChars[random.Next(0, candidateChars.Length)]);
            }
            return sb.ToString();
        }

        public List<Phone> GetAll()
        {
            return context.Phones.ToList();
        }
    }
}
