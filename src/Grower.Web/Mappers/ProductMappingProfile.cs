using AutoMapper;
using Grower.Core.Entities;
using Grower.Web.Commands;
using Grower.Web.Queries;
using Grower.Web.Responses;

namespace Grower.Web.Mappers;

public class ProductMappingProfile : Profile
{
  public ProductMappingProfile()
  {
    CreateMap<Product, ProductResponse>().ReverseMap();
    CreateMap< Product, CreateProductCommand >().ReverseMap();

    ///
    CreateMap< ProductResponse, GetAllProductQuery>().ReverseMap();
  }
}
