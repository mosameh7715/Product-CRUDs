using Basic_CRUD_Operations.Models;
using Basic_CRUD_Operations.Models.Product;
using Basic_CRUD_Operations.Repositories;
using MediatR;
using System.Net;

namespace Basic_CRUD_Operations.Features.ProductFeatures.Commands.DeleteProduct
{
    public class DeleteProductCommandHandler : IRequestHandler<DeleteProductCommand, APIResponse>
    {
        private readonly IRepository<Product> _productRepository;
        private APIResponse _response;

        public DeleteProductCommandHandler(IRepository<Product> productRepository)
        {
            _productRepository = productRepository;
            _response = new APIResponse();
        }

        public async Task<APIResponse> Handle(DeleteProductCommand request, CancellationToken cancellationToken)
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
                _productRepository.Delete(product);
                _productRepository.SaveChanges();
                _response.Result = request.Id;
                _response.Message = "Product Deleted Successfully";
                _response.StatusCode = HttpStatusCode.OK;
            }
            return _response;
        }
    }
}
