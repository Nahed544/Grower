using AutoMapper;
using Grower.Core.Entities;
using Grower.Web.Responses;

namespace Grower.Web.Mappers;

public class ProductTypeMappingProfile : Profile
{
  public ProductTypeMappingProfile()
  {
    CreateMap<ProductType, ProductTypeResponse>()    
   .ReverseMap();

     
  }
}
