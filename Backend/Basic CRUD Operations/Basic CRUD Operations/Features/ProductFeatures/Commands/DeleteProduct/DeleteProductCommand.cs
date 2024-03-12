using Basic_CRUD_Operations.Models;
using MediatR;

namespace Basic_CRUD_Operations.Features.ProductFeatures.Commands.DeleteProduct
{
    public class DeleteProductCommand : IRequest<APIResponse>
    {
        public int Id { get; set; }
    }
}
