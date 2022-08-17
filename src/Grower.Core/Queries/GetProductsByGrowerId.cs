using Grower.Core.Entities;
using Grower.Core.Responses;
using MediatR;

namespace Grower.Core.Queries;

public class GetProductsByGrowerId :IRequest<List<ProductResponse>>
{
  public int GrowerId { get; }

  public GetProductsByGrowerId(int growerId)
  {
    GrowerId = growerId;
  }
}
