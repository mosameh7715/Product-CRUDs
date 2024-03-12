export class Product {
  constructor(
    public id: number,
    public name: string,
    public price: number,
    public description: string,
    public brandName: string,
    public imgUrl: string,
    public quantity: number
  ) {}
}
