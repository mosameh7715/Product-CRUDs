namespace Basic_CRUD_Operations.Models.Product
{
    public class Product : BaseModel
    {
        public string Name { get; set; }
        public float Price { get; set; }
        public string? Description { get; set; }
        public string? BrandName { get; set; }
        public string? ImgUrl { get; set; }
        public float Quantity { get; set; }

    }
}
