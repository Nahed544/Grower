using Grower.Core.Entities;
using Grower.Core.Repository.Base;
using Grower.Web.Commands;
using Grower.Web.Queries;
using Grower.Web.Responses;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Grower.Web.Api;


public class ProductController : BaseApiController
{
  private readonly IMediator _mediator;
  private readonly IRepository<Product> _repository;
  public ProductController(IMediator mediator, IRepository<Product> repository)
  {
    _mediator = mediator;
    _repository = repository;
  }

  [HttpGet("{id}")]
  public async Task<IActionResult> Get(int id)
  {
    var products = await _mediator.Send(new GetProductsByGrowerId(id));
    return Ok(products);
  }
  [HttpPost]
  public async Task<ActionResult<ProductResponse>> CreateProduct([FromBody] CreateProductCommand command)
  {
    var result = await _mediator.Send(command);
    return Ok(result);
  }

  [HttpDelete("{id}")]
  public async Task<ActionResult> Delete(int id)
  {
    var result = await _mediator.Send(new DeleteProductByIdCommand(id));
    return Ok(result);

  }

  [HttpPut]
  public async Task<ActionResult<bool>> UpdateProduct([FromBody] UpdateProductCommand command)
  {
    if (command == null || !ModelState.IsValid)
    {
      return BadRequest();
    }
    var result = await _mediator.Send(command);
    if (result)
      return Ok(result);
    else
      return NoContent();
  }
}
