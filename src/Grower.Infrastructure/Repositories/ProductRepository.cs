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
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Grower.Infrastructure.Repositories;
public class ProductRepository : Repository<Product>, IProductRepository

{
  readonly AppDbContext _dbContext;
  public ProductRepository(AppDbContext dbContext) : base(dbContext)
  {
    _dbContext = dbContext;
  }

  public async Task Delete(int productID)
  {
    var product = await _dbContext.Products.Where(a => a.Id == productID).FirstOrDefaultAsync();
    _dbContext.Products.Remove(product);
    await _dbContext.SaveChangesAsync();

  }

  public async Task<List<Product>> GetAllProductByGrowerId(int growerId)
  {
    List<Product> products = new List<Product>();
    products = _dbContext.Products.Include(pt => pt.ProductType).Where(p => p.GrowerId == growerId).ToList();
    return products;

  }

  public async Task<bool> UpdateAsync(Product productEntity)
  {
    var product = _dbContext.Products.Where(p => p.Id == productEntity.Id).FirstOrDefault();
    if (product != null)
    {
      product.ProductName = productEntity.ProductName;
      product.Price = productEntity.Price;
      product.ProductTypeId = productEntity.ProductTypeId;
      product.Availability = productEntity.Availability;
      product.Description = productEntity.Description;
      product.Image = productEntity.Image;
      _dbContext.Products.Update(product);
      var updated = await _dbContext.SaveChangesAsync();
      if (updated > 0)
      {
        return true;
      }
    }
    return false;
  }
}

