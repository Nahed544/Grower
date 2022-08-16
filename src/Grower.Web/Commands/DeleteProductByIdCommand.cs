using MediatR;

namespace Grower.Web.Commands;

public class DeleteProductByIdCommand : IRequest<int>
{
  public int ProductId { get; set; }
  public DeleteProductByIdCommand(int productId)
  {
    ProductId = productId;
  }
}
