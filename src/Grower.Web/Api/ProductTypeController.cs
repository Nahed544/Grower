
using Grower.Core.Entities;
using Grower.Core.Repository.Base;
using Grower.Core.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;
namespace Grower.Web.Api;
public class ProductTypeController : BaseApiController
{
  private readonly IMediator _mediator;
  //private readonly IRepository<ProductType> _repository;
  public ProductTypeController(IMediator mediator, IRepository<ProductType> repository)
  {
    _mediator = mediator;
    //_repository = repository;
  }

  [HttpGet]
  public async Task<IActionResult> Get()
  {
    var products = await _mediator.Send(new GetAllProductTypesQuery());
    return Ok(products);
  }

}
