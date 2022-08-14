using Grower.Core.Entities;
using Grower.Core.Repository.Base;
using Grower.Web.Commands;
using Grower.Web.Queries;
using Grower.Web.Responses;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Grower.Web.Api;

 
public class ProductController :BaseApiController
{
  private readonly IMediator _mediator;
  private readonly IRepository<Product> _repository;
  public ProductController(IMediator mediator , IRepository<Product> repository)
  {
    _mediator = mediator;
    _repository = repository;
  }

  [HttpGet]
  public async Task<IActionResult> Get(int growerId)
  {
    var products =  await _mediator.Send(new GetProductsByGrowerId(growerId));
    return Ok(products);
  }
  [HttpPost]
  public async Task<ActionResult<ProductResponse>> CreateProduct([FromBody] CreateProductCommand command)
  {
    var result = await _mediator.Send(command);
    return Ok(result);
  }

}
