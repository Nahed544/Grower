using Grower.Web.Responses;
using MediatR;

namespace Grower.Web.Queries;

public class GetAllProductTypesQuery : IRequest<List<ProductTypeResponse>>
{
}
