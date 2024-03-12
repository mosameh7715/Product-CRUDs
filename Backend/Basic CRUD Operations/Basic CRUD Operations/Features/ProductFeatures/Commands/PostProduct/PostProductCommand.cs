using Basic_CRUD_Operations.Features.ProductFeatures.Commands.PostProduct.DTOs;
using Basic_CRUD_Operations.Models;
using MediatR;

namespace Basic_CRUD_Operations.Features.ProductFeatures.Commands.PostProduct
{
    public class PostProductCommand : IRequest<APIResponse>
    {
        public PostProductDTO PostProductDTO { get; set; }
    }
}
