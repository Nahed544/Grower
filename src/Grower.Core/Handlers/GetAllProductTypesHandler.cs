using Grower.Core.Entities;
using Grower.Core.Repository;
using Grower.Core.Mappers;
using Grower.Core.Queries;
using Grower.Core.Responses;
using MediatR; 

namespace Grower.Core.Handlers;

public class GetAllProductTypesHandler : IRequestHandler<GetAllProductTypesQuery, List<ProductTypeResponse>>
{
  private readonly IProductTypeRepository _productTypeRepository;

  public GetAllProductTypesHandler(IProductTypeRepository productTypeRepository)
  {
    _productTypeRepository = productTypeRepository;
  }

  public async Task<List<ProductTypeResponse>> Handle(GetAllProductTypesQuery request, CancellationToken cancellationToken)
  {
    var productTypes = await _productTypeRepository.GetAllAsync();
    List<ProductTypeResponse> productTypesResponse =
    GrowerMapper.Mapper.Map<List<ProductTypeResponse>>(productTypes);
    return productTypesResponse;
  }
}
