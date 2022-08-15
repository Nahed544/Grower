using Grower.Web.Responses;
using Grower.Web.Commands;
using MediatR;
using Grower.Core.Repository;
using Grower.Core.Entities;
using Grower.Web.Mappers;

namespace Grower.Web.Handlers;

public class CreateProductHandler : IRequestHandler<CreateProductCommand, ProductResponse>
{
  private readonly IProductRepository _productRepository;
  public CreateProductHandler(IProductRepository productRepository)
  {
   _productRepository=productRepository;
  }
  public async Task<ProductResponse> Handle(CreateProductCommand request, CancellationToken cancellationToken)
  {
    var productEntity = GrowerMapper.Mapper.Map<Product>(request);
    if (productEntity is null)
    {
      throw new ApplicationException("Issue with mapper");
    }
    var newProduct = await _productRepository.AddAsync(productEntity);
    var productResponse = GrowerMapper.Mapper.Map<ProductResponse>(newProduct);
    return productResponse;
  }
}
