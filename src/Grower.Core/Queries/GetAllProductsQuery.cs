using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Grower.Core.Responses;
using MediatR;

namespace Grower.Core.Queries;
public class GetAllProductsQuery:IRequest<List<ProductResponse>>
{
}
