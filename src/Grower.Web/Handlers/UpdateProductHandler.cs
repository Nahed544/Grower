using Grower.Core.Entities;
using Grower.Core.Repository;
using Grower.Web.Commands;
using Grower.Web.Mappers;
using Grower.Web.Responses;
using MediatR;

namespace Grower.Web.Handlers;

public class UpdateProductHandler : IRequestHandler<UpdateProductCommand ,bool>
{
  private readonly IProductRepository _productRepository;
  public UpdateProductHandler(IProductRepository productRepository)
  {
    _productRepository = productRepository;
  }

  public async Task<bool> Handle(UpdateProductCommand request, CancellationToken cancellationToken)
  {
    var product = GrowerMapper.Mapper.Map<Product>(request);
    var productUpdated = await _productRepository.UpdateAsync(product);
    return productUpdated;
  }

  
}
