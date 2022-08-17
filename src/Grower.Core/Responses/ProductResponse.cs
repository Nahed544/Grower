namespace Grower.Core.Responses;

public class ProductResponse
{
  public int Id { get; set; }
  public string ProductName { get; set; }
  public string Description { get; set; }
  public int Quatity { get; set; }
  public string Image { get; set; }
  public double Price { get; set; }
  public bool Availability { get; set; }
  public int GrowerId { get; set; } 
  public int ProductTypeId { get; set; } 
  public string ProductTypeName { get; set; }
 
   public ProductTypeResponse ProductTypeResponse { get; set; }
}
