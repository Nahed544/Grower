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
    CreateMap<Product, ProductResponse>()
   .ForMember(d => d.ProductTypeName , opt => opt.MapFrom(src => src.ProductType.ProductTypeName))
   .ForMember(d => d.ProductTypeId, opt => opt.MapFrom(src => src.ProductType.Id))
   .ReverseMap()
   .ForPath(s => s.ProductType.ProductTypeName, opt => opt.MapFrom(src => src.ProductTypeName))
   .ForPath(s => s.ProductType.Id, opt => opt.MapFrom(src => src.ProductTypeId));
  ;

    CreateMap< Product, CreateProductCommand >().ReverseMap();
    CreateMap< Product, UpdateProductCommand >().ReverseMap();

  }
}
