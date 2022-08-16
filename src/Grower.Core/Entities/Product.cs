using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grower.Core.Entities;
public class Product
{
  public int Id { get; set; }
  public string ProductName { get; set; }
  public string Description { get; set; }
  public int Quatity { get; set; }
  public string Image { get; set; }
  public double Price { get; set; }
  public bool Availability { get; set; }
  public int GrowerId { get; set; }
  public Grower Grower { get; set; }
  public int ProductTypeId { get; set; }
  public ProductType ProductType { get; set; }


}
