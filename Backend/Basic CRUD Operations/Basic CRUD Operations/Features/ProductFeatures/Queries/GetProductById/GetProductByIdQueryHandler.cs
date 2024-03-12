using Basic_CRUD_Operations.Features.ProductFeatures.Queries.GetProductById.DTOs;
using Basic_CRUD_Operations.Models;
using Basic_CRUD_Operations.Models.Product;
using Basic_CRUD_Operations.Repositories;
using MediatR;
using System.Net;

namespace Basic_CRUD_Operations.Features.ProductFeatures.Queries.GetProductById
{
    public class GetProductByIdQueryHandler : IRequestHandler<GetProductByIdQuery, APIResponse>
    {
        private readonly IRepository<Product> _productRepository;
        private APIResponse _response;

        public GetProductByIdQueryHandler(IRepository<Product> productRepository)
        {
            _productRepository = productRepository;
            _response = new APIResponse();
        }

        public async Task<APIResponse> Handle(GetProductByIdQuery request, CancellationToken cancellationToken)
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
                var productDTO = new GetProductByIdDTO()
                {
                    Id = product.Id,
                    Name = product.Name,
                    BrandName = product.BrandName,
                    Description = product.Description,
                    ImgUrl = product.ImgUrl,
                    Price = product.Price,
                    Quantity = product.Quantity
                };

                _response.Result = productDTO;
                _response.Message = "Product Retrieved Successfully";
                _response.StatusCode = HttpStatusCode.OK;
            }
            return _response;
        }
    }
}
