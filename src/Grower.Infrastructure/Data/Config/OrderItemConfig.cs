using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Grower.Core.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Grower.Infrastructure.Data.Config;
internal class OrderItemConfiguration : IEntityTypeConfiguration<OrderItem>

{
public void Configure(EntityTypeBuilder<OrderItem> builder)
  { 

  }
}
