using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ardalis.Specification.EntityFrameworkCore;
using Grower.Core.Repository.Base;
using Grower.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Grower.Infrastructure.Repositories.Base;
public class Repository<T> : IRepository<T> where T : class
{
  protected readonly AppDbContext _dbContext;
  public Repository(AppDbContext dbContext)
  {
    _dbContext = dbContext;
   }
  public async Task<T> AddAsync(T entity)
  {
    await _dbContext.Set<T>().AddAsync(entity);
    await _dbContext.SaveChangesAsync();
    return entity;
  }
  public async Task DeleteAsync(T entity)
  {
    _dbContext.Set<T>().Remove(entity);
    await _dbContext.SaveChangesAsync();
  }
  public async Task<IReadOnlyList<T>> GetAllAsync()
  {
    return await _dbContext.Set<T>().ToListAsync();
  }
  public async Task<T> GetByIdAsync(int id)
  {
    return await _dbContext.Set<T>().FindAsync(id);
  }
  public Task UpdateAsync(T entity)
  {
    throw new NotImplementedException();
  }
}
