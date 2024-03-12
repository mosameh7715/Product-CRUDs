using Basic_CRUD_Operations.Features.ProductFeatures.Commands.PutProduct.DTOs;
using Basic_CRUD_Operations.Models;
using MediatR;

namespace Basic_CRUD_Operations.Features.ProductFeatures.Commands.PutProduct
{
    public class PutProductCommand : IRequest<APIResponse>
    {
        public int Id { get; set; }
        public PutProductDTO PutProductDTO { get; set; }
    }
}
