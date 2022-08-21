import { ProductType } from "./productType.model";
 
export class Product {
  public id: number;
  public productName: string;
  public description: string;
  public quatity: number;
  public availability: boolean;
  public growerId: number;
  public image: string;
  public price: number;
  public productTypeId: number ;

  public productTypeResponse: ProductType;

  constructor(id: number, productName: string, description: string, availability: boolean
    , growerId: number, productTypeResponse: ProductType, quatity: number, image: string,
    price: number) {

    this.availability = availability;
    this.description = description;
    this.growerId = growerId;
    this.productName = productName;
    this.id = id;
    this.productTypeResponse = productTypeResponse;
    this.quatity = quatity;
    this.image = image;
    this.price = price ;
    this.productTypeId = productTypeResponse.id ;

  }

}
