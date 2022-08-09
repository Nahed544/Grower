

using System.Reflection;
using AutoMapper;
using Grower.Core.Repository;
using Grower.Core.Repository.Base;
using Grower.Infrastructure.Repositories;
using Grower.Infrastructure.Repositories.Base;
using Grower.Web.Handlers;
using Grower.Web.Mappers;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;

namespace Grower.Web.Extensions;

public static class AppServiceExtensions
{
  public static IServiceCollection AddApplicationService(this IServiceCollection Services,
      IConfiguration config)
  {
    // Add services to the container. //connection string 
    var _config = new MapperConfiguration(cfg =>
    { 
        cfg.AddProfile(new ProductMappingProfile()); 
    }); 
    var mapper = _config.CreateMapper(); 
    Services.AddSingleton(mapper); 
    Services.AddMediatR(Assembly.GetExecutingAssembly());

    Services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
    Services.AddTransient<IProductRepository, ProductRepository>();

    return Services;
  }
}
