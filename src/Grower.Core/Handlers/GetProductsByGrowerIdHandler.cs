using Grower.Core.Responses; 
using MediatR;
using Grower.Core.Repository;
using Grower.Core.Mappers;
using Grower.Core.Entities;
using Grower.Core.Queries;

namespace Grower.Core.Handlers;

public class GetProductsByGrowerIdHandler : IRequestHandler<GetProductsByGrowerId, List<ProductResponse>>
{
  private readonly IProductRepository _productRepository;
  public GetProductsByGrowerIdHandler(IProductRepository productRepository)
  {
    _productRepository = productRepository;
  }

  public async Task<List<ProductResponse>> Handle(GetProductsByGrowerId request, CancellationToken cancellationToken)
  { 

    var productsResponse = new List<ProductResponse>();
    var products = await _productRepository.GetAllProductByGrowerId(request.GrowerId);
    productsResponse =
      GrowerMapper.Mapper.Map<List<ProductResponse>>(products)  ;
    return productsResponse;
  }


   

}
