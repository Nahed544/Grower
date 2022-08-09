using System.Reflection;
using Grower.Core.Entities;
using Grower.Core.ProjectAggregate;
using Grower.SharedKernel;
using Grower.SharedKernel.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Grower.Infrastructure.Data;

public class AppDbContext : DbContext
{
  private readonly IDomainEventDispatcher _dispatcher;

  public AppDbContext(DbContextOptions<AppDbContext> options,
    IDomainEventDispatcher dispatcher)
      : base(options)
  {
    _dispatcher = dispatcher;
  }

   
  //public DbSet<ToDoItem> ToDoItems => Set<ToDoItem>();
  //public DbSet<Project> Projects => Set<Project>();
  public DbSet<ProductType> ProductTypes => Set<ProductType>();
  public DbSet<Product> Products => Set<Product>();
  public DbSet<Client> Clients => Set<Client>();
  public DbSet<Grower.Core.Entities.Grower> Growers => Set<Grower.Core.Entities.Grower>();
  public DbSet<Order> Orders => Set<Order>();
  public DbSet<OrderItem> OrderItems => Set<OrderItem>();
  public DbSet<Role> Roles => Set<Role>();
  public DbSet<RoleType> RoleTypes => Set<RoleType>();
  public DbSet<User> Users => Set<User>();
  public DbSet<UserCredentials> UserCredentials => Set<UserCredentials>();



  protected override void OnModelCreating(ModelBuilder modelBuilder)
  {
    

    base.OnModelCreating(modelBuilder);
    modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
  }

  public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken())
  {
    int result = await base.SaveChangesAsync(cancellationToken).ConfigureAwait(false);

    // ignore events if no dispatcher provided
    if (_dispatcher == null) return result;

    // dispatch events only if save was successful
    var entitiesWithEvents = ChangeTracker.Entries<EntityBase>()
        .Select(e => e.Entity)
        .Where(e => e.DomainEvents.Any())
        .ToArray();

    await _dispatcher.DispatchAndClearEvents(entitiesWithEvents);

    return result;
  }

  public override int SaveChanges()
  {
    return SaveChangesAsync().GetAwaiter().GetResult();
  }
}
