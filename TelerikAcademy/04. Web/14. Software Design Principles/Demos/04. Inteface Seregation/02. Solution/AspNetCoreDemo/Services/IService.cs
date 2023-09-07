namespace AspNetCoreDemo.Services
{
	public interface IService<T> : IReadOnlyService<T>
	{
		void Create(T entity);
	}
}
