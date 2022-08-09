using Grower.Web.Responses; 
using MediatR;
using Grower.Core.Repository;
using Grower.Web.Mappers;
using Grower.Core.Entities;
using Grower.Web.Queries;

namespace Grower.Web.Handlers;

public class GetProductsHandler : IRequestHandler<GetAllProductQuery, List<ProductResponse>>
{
  private readonly IProductRepository _productRepository;
  public GetProductsHandler(IProductRepository productRepository)
  {
    _productRepository = productRepository;
  }

  public async Task<List<ProductResponse>> Handle(GetAllProductQuery request, CancellationToken cancellationToken)
  { 

    var productsResponse = new List<ProductResponse>();
    var products = await _productRepository.GetAllAsync();
    productsResponse =
      ProductMapper.Mapper.Map<List<ProductResponse>>(products);
    return productsResponse;
  }


   

}
