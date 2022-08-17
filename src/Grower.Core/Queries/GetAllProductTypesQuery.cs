using Grower.Core.Responses;
using MediatR;

namespace Grower.Core.Queries;

public class GetAllProductTypesQuery : IRequest<List<ProductTypeResponse>>
{
}
