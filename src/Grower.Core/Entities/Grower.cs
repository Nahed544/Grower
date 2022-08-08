using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grower.Core.Entities;
public class Grower
{
  public int Id { get; set; }   
  public ICollection<Product> Products { get; set; }
  public int UserId { get; set; }
  public User User { get; set; }

}
