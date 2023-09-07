using System.Collections.Generic;

namespace AspNetCoreDemo.Repositories
{
	public interface IRepository<T> : IReadOnlyRepository<T>
	{
		void Create(T entity);
	}
}
