﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grower.Core.Entities;
public class ProductType
{
  public int Id { get; set; }
  public string ProductTypeName { get; set; }
  public ICollection<Product> Products { get; set; }
}
