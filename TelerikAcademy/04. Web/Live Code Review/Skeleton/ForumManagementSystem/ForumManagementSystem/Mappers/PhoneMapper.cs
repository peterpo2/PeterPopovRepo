using ForumManagementSystem.Models;
using ForumManagementSystem.services;

namespace ForumManagementSystem.Mappers
{
    public class PhoneMapper
    {
        private readonly IUsersService usersService;

        public PhoneMapper(IUsersService usersService)
        {
            this.usersService = usersService;
        }

        public Phone dtoToObject(PhoneDto phoneDto)
        {
            Phone phone = new Phone();
            phone.PhoneNumber = phoneDto.Number;
            phone.OwnerId = phoneDto.UserId;
            return phone;
        }
    }
}
