using Basic_CRUD_Operations.Helpers.FileUploadService;
using Basic_CRUD_Operations.Models;
using Basic_CRUD_Operations.Models.Product;
using Basic_CRUD_Operations.Repositories;
using MediatR;
using System.Net;

namespace Basic_CRUD_Operations.Features.ProductFeatures.Commands.PutProduct
{
    public class PutProductCommandHandler : IRequestHandler<PutProductCommand, APIResponse>
    {
        private readonly IRepository<Product> _productRepository;
        private APIResponse _response;

        public PutProductCommandHandler(IRepository<Product> productRepository)
        {
            _productRepository = productRepository;
            _response = new APIResponse();
        }

        public async Task<APIResponse> Handle(PutProductCommand request, CancellationToken cancellationToken)
        {


            Product? product = _productRepository.GetById(request.Id);

            if (product is null)
            {
                _response.StatusCode = HttpStatusCode.NotFound;
                _response.IsSuccess = false;
                _response.Message = "Product Not Found";
            }
            else
            {
                product.Name = request.PutProductDTO.Name;
                product.Price = request.PutProductDTO.Price;
                product.Description = request.PutProductDTO.Description;
                product.BrandName = request.PutProductDTO.Brand;
                product.Quantity = request.PutProductDTO.Quantity;
                if (request.PutProductDTO.Image is not null)
                {
                    product.ImgUrl = await FileUploadService.UploadImageAsync(request.PutProductDTO.Image);
                }

                _productRepository.Update(product);
                _productRepository.SaveChanges();
                _response.Result = request.Id;
                _response.Message = "Product Updated Successfully";
                _response.StatusCode = HttpStatusCode.OK;

            }
            return _response;
        }
    }
}
