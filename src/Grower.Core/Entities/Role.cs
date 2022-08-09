using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grower.Core.Entities;
public class Role
{
  public int Id { get; set; }
  public int RoleTypeId { get; set; }
  public int UserId { get; set; }
  public RoleType RoleType { get; set; } 
  public User User { get; set; }
}
