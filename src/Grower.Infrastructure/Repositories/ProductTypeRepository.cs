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
public class ProductTypeRepository : Repository<ProductType>, IProductTypeRepository
{
  readonly AppDbContext _dbContext;
  public ProductTypeRepository(AppDbContext dbContext) : base(dbContext)
  {
    _dbContext = dbContext;
  }
}
