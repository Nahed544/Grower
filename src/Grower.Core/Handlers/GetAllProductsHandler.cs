using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Grower.Core.Mappers;
using Grower.Core.Queries;
using Grower.Core.Repository;
using Grower.Core.Responses;
using MediatR;

namespace Grower.Core.Handlers;
public class GetAllProductsHandler : IRequestHandler<GetAllProductsQuery, List<ProductResponse>>
{
  private readonly IProductRepository _productRepository;
  public GetAllProductsHandler(IProductRepository productRepository)
  {
    _productRepository = productRepository;
  }
  public async Task<List<ProductResponse>> Handle(GetAllProductsQuery request, CancellationToken cancellationToken)
  {

    var productsResponse = new List<ProductResponse>();
    var products = await _productRepository.GetAllProducts();
    productsResponse =
      GrowerMapper.Mapper.Map<List<ProductResponse>>(products);
    return productsResponse;
  }
}
