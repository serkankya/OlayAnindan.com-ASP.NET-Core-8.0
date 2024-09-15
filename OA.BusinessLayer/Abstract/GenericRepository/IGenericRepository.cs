using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OA.BusinessLayer.Abstract.GenericRepository
{
	public interface IGenericRepository<T> where T : class, new()
	{
		Task<IEnumerable<T>> GetAllAsync();
		Task<IEnumerable<T>> GetActivesAsync();
		Task<bool> InsertAsync(T entity);
		Task<bool> UpdateAsync(T entity);
		Task<bool> DeleteAsync(int id);
		Task<bool> RemoveAsync(int id);
		Task<T> GetByIdAsync(int id);
	}
}
