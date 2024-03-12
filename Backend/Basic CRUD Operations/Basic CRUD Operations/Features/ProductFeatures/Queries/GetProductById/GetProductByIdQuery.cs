using Basic_CRUD_Operations.Models;
using MediatR;

namespace Basic_CRUD_Operations.Features.ProductFeatures.Queries.GetProductById
{
    public class GetProductByIdQuery : IRequest<APIResponse>
    {
        public int Id { get; set; }
    }
}
