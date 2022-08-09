using Grower.Core.Entities;
using Grower.Web.Responses;
using MediatR;

namespace Grower.Web.Queries;

public class GetAllProductQuery :IRequest<List<ProductResponse>>
{

}
