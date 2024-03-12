using Basic_CRUD_Operations.Models;
using MediatR;

namespace Basic_CRUD_Operations.Features.Account.Queries.GetLoggedInUser
{
    public class GetLoggedInUserQuery : IRequest<APIResponse>
    {
    }
}
