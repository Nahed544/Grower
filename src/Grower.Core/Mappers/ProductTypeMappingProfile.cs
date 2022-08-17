using AutoMapper;
using Grower.Core.Entities;
using Grower.Core.Responses;

namespace Grower.Core.Mappers;

public class ProductTypeMappingProfile : Profile
{
  public ProductTypeMappingProfile()
  {
    CreateMap<ProductType, ProductTypeResponse>()    
   .ReverseMap();

     
  }
}
