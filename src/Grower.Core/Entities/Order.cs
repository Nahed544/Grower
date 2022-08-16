using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grower.Core.Entities;
public class Order
{
  public int Id { get; set; }
  public DateTime CreatedOn { get; set; } = DateTime.Now;
  public DateTime? DeliveryDate { get; set; }
  public double TotalPrice { get; set; }
  public int ClientID { get; set; }
  public Client Client  { get; set; }
}
