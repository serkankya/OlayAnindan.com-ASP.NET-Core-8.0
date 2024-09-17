using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OA.BusinessLayer.Abstract.GenericRepository
{
	public interface IGenericRepository<T, InsertTRequest, UpdateTRequest>
	   where T : class, new()
	   where InsertTRequest : class
	   where UpdateTRequest : class
	{
		Task<IEnumerable<T>> GetAllAsync();
		Task<IEnumerable<T>> GetActivesAsync();
		Task<bool> InsertAsync(InsertTRequest request);
		Task<bool> UpdateAsync(UpdateTRequest request);
		Task<bool> DeleteAsync(int id);
		Task<bool> RemoveAsync(int id);
		Task<T> GetByIdAsync(int id);
	}
}
