using Grower.Web.Responses; 
using MediatR;
using Grower.Core.Repository;
using Grower.Web.Mappers;
using Grower.Core.Entities;
using Grower.Web.Queries;

namespace Grower.Web.Handlers;

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
