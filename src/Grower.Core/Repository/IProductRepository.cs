﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using Grower.Core.Entities;
 using Grower.Core.Repository.Base;

namespace Grower.Core.Repository;
public interface IProductRepository : IRepository<Grower.Core.Entities.Product>
{  
  Task<List<Product>> GetAllProductByGrowerId(int growerId);
  Task Delete(int productID);
}

 
