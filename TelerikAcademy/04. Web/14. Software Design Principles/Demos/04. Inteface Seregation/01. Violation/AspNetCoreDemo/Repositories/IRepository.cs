using System.Collections.Generic;

namespace AspNetCoreDemo.Repositories
{
	public interface IRepository<T>
	{
		void Create(T entity);
		List<T> GetAll();
	}
}
