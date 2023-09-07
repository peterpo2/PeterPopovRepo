using System.Collections.Generic;

namespace AspNetCoreDemo.Repositories
{
	public interface IReadOnlyRepository<T>
	{
		List<T> GetAll();
	}
}
