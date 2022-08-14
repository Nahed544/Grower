using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Grower.Core.Entities;
using Grower.Core.Repository;
using Grower.Core.Repository.Base;
using Grower.Infrastructure.Data;
using Grower.Infrastructure.Repositories.Base;
using Microsoft.EntityFrameworkCore;

namespace Grower.Infrastructure.Repositories;
public class ProductRepository : Repository<Product>, IProductRepository

{
  readonly AppDbContext _dbContext;
  public ProductRepository(AppDbContext dbContext) : base(dbContext) {
    _dbContext = dbContext;
  }

  public async Task<List<Product>> GetAllProductByGrowerId(int growerId)
  {
    List<Product> products = new List<Product>();
    products =  _dbContext.Products.Include(pt=>pt.ProductType).Where(p => p.GrowerId == growerId).ToList();
    return products;
 
  }

  public Task<IEnumerable<Product>> GetAllProductByName(string lastname)
  {
    throw new NotImplementedException();
  }
}

