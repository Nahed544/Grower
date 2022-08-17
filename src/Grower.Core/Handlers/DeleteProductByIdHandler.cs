using Grower.Core.Repository;
using Grower.Core.Commands;
using MediatR;

namespace Grower.Core.Handlers;

public class DeleteProductByIdHandler : IRequestHandler<DeleteProductByIdCommand ,int>
{
  private readonly IProductRepository _productRepository;
  public DeleteProductByIdHandler(IProductRepository productRepository)
  {
    _productRepository = productRepository;
  }

   
  public  async Task<int>  Handle(DeleteProductByIdCommand request, CancellationToken cancellationToken)
   {
    await _productRepository.Delete(request.ProductId);

    return request.ProductId;
  }
}
