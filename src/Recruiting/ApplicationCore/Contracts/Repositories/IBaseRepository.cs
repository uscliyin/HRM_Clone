using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.Contracts.Repositories
{
    public interface IBaseRepository <T> where T:class
    {

        Task<IEnumerable<T>> GetAllAsync();
        // IEnumerable<T> GetAll();
        Task<T> GetByIdAsync(int id);
        Task<bool> GetExistsAsync(Expression<Func<T, bool>>? filter = null);
        Task<T> AddAsync(T entity);
        Task<T> UpdateAsync(T entity);
        Task<int> DeleteAsync(int id);

    }
}
