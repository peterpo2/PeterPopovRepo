
using System.Collections.Generic;

namespace AspNetCoreDemo.Services
{
	public interface IReadOnlyService<T>
	{
		List<T> GetAll();
	}
}
