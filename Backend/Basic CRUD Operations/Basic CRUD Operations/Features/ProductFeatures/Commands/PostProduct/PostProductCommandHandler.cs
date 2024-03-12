using Basic_CRUD_Operations.Helpers.FileUploadService;
using Basic_CRUD_Operations.Models;
using Basic_CRUD_Operations.Models.Product;
using Basic_CRUD_Operations.Repositories;
using MediatR;
using System.Net;

namespace Basic_CRUD_Operations.Features.ProductFeatures.Commands.PostProduct
{
    public class PostProductCommandHandler : IRequestHandler<PostProductCommand, APIResponse>
    {
        private readonly IRepository<Product> _productRepository;
        private APIResponse _response;

        public PostProductCommandHandler(IRepository<Product> productRepository)
        {
            _productRepository = productRepository;
            _response = new APIResponse();
        }

        public async Task<APIResponse> Handle(PostProductCommand request, CancellationToken cancellationToken)
        {
            Product product = new Product()
            {
                Name = request.PostProductDTO.Name,
                Price = request.PostProductDTO.Price,
                Description = request.PostProductDTO.Description,
                BrandName = request.PostProductDTO.Brand,
                Quantity = request.PostProductDTO.Quantity
            };
            if (request.PostProductDTO.Image is not null)
            {
                product.ImgUrl = await FileUploadService.UploadImageAsync(request.PostProductDTO.Image);
            }
            _productRepository.Add(product);
            _productRepository.SaveChanges();


            _response.Result = product;
            _response.StatusCode = HttpStatusCode.OK;
            _response.Message = "Product Added Successfully";


            return _response;
        }
    }
}
