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

namespace Grower.Infrastructure.Repositories;
public class ProductRepository : Repository<Product>, IProductRepository

{
  public ProductRepository(AppDbContext dbContext) : base(dbContext) { }

  public Task<IEnumerable<Product>> GetAllProductByName(string lastname)
  {
    throw new NotImplementedException();
  }
}

