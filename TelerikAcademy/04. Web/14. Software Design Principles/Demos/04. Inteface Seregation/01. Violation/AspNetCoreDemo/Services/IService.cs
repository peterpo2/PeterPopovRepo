
using System.Collections.Generic;

namespace AspNetCoreDemo.Services
{
	public interface IService<T>
	{
		void Create(T entity);
		List<T> GetAll();
	}
}
