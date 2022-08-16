using Grower.Web.Responses;
using MediatR;

namespace Grower.Web.Commands;

public class CreateProductCommand : IRequest<ProductResponse>
{ 
  public string ProductName { get; set; }
  public string Description { get; set; }
  public int Quatity { get; set; }
  public string Image { get; set; }
  public bool Availability { get; set; }
  public int GrowerId { get; set; } 
  public int ProductTypeId { get; set; }
}
