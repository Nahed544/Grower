using Grower.Core.Entities;
using Grower.Web.Responses;
using MediatR;

namespace Grower.Web.Queries;

public class GetProductsByGrowerId :IRequest<List<ProductResponse>>
{
  public int GrowerId { get; }

  public GetProductsByGrowerId(int growerId)
  {
    GrowerId = growerId;
  }
}
