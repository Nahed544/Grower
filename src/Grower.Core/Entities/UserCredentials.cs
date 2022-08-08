using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grower.Core.Entities;
public class UserCredentials
{
  public int Id  { get; set; }
  public string PasswordHash { get; set; }
  public string PasswordSalt { get; set; }

  public int UserId { get; set; }
  public User User { get; set; }

}
