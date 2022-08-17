using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grower.Core.Repository.Base;
public interface IRepository<T> where T : class
{
  Task<IReadOnlyList<T>> GetAllAsync();
  Task<T> GetByIdAsync(int id);
  Task<T> AddAsync(T entity);
  Task<bool> UpdateAsync(T entity);
  Task DeleteAsync(T entity);
}
