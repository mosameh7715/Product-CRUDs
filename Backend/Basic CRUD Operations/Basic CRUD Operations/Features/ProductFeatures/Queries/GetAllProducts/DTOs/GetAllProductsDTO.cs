namespace Basic_CRUD_Operations.Features.ProductFeatures.Queries.GetAllProducts.DTOs
{
    public class GetAllProductsDTO
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public float Price { get; set; }
        public string? Description { get; set; }
        public string? BrandName { get; set; }
        public string? ImgUrl { get; set; }
        public float Quantity { get; set; }
    }
}
