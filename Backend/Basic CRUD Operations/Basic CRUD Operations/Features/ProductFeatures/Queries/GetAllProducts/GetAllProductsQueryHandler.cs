using Basic_CRUD_Operations.Features.ProductFeatures.Queries.GetAllProducts.DTOs;
using Basic_CRUD_Operations.Models;
using Basic_CRUD_Operations.Models.Product;
using Basic_CRUD_Operations.Repositories;
using MediatR;
using System.Net;

namespace Basic_CRUD_Operations.Features.ProductFeatures.Queries.GetAllProducts
{
    public class GetAllProductsQueryHandler : IRequestHandler<GetAllProductsQuery, APIResponse>
    {
        private readonly IRepository<Product> _productRepository;
        private APIResponse _response;

        public GetAllProductsQueryHandler(IRepository<Product> productRepository)
        {
            _productRepository = productRepository;
            _response = new APIResponse();
        }

        public async Task<APIResponse> Handle(GetAllProductsQuery request, CancellationToken cancellationToken)
        {
            List<GetAllProductsDTO> products = _productRepository
                .GetAll(x => x.Name.ToLower().Contains(request.Search ?? string.Empty), request.PageNumber, request.PageSize)
                .Select(x => new GetAllProductsDTO()
                {
                    Id = x.Id,
                    Name = x.Name,
                    BrandName = x.BrandName,
                    Description = x.Description,
                    ImgUrl = x.ImgUrl,
                    Price = x.Price,
                    Quantity = x.Quantity
                })
                .ToList();

            var resultSetResponse = new GetResultSetResponse()
            {
                Count = _productRepository.Count(x => x.Name.ToLower().Contains(request.Search ?? string.Empty)),
                ResultSet = products
            };

            _response.Result = resultSetResponse;
            _response.Message = "Products Retrieved Successfully";
            _response.StatusCode = HttpStatusCode.OK;
            return _response;
        }
    }
}
