using Basic_CRUD_Operations.Models;
using MediatR;

namespace Basic_CRUD_Operations.Features.ProductFeatures.Queries.GetAllProducts
{
    public class GetAllProductsQuery : IRequest<APIResponse>
    {
        public string? Search { get; set; }
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
    }
}
