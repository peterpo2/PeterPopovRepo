
using AspNetCoreDemo.Models;

namespace AspNetCoreDemo.Services
{
	public interface IUsersService
	{
		BaseUser GetById(int id);
		string GetDisplayInfo(BaseUser user);
	}
}
