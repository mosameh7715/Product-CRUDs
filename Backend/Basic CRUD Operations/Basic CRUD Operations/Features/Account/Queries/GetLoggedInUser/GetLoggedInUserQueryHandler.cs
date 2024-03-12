using Basic_CRUD_Operations.Models;
using MediatR;
using System.Net;
using System.Security.Claims;

namespace Basic_CRUD_Operations.Features.Account.Queries.GetLoggedInUser
{
    public class GetLoggedInUserQueryHandler : IRequestHandler<GetLoggedInUserQuery, APIResponse>
    {
        private readonly IHttpContextAccessor _contextAccessor;
        private APIResponse _response;
        public GetLoggedInUserQueryHandler(IHttpContextAccessor contextAccessor)
        {
            _contextAccessor = contextAccessor;
            _response = new APIResponse();

        }

        public async Task<APIResponse> Handle(GetLoggedInUserQuery request, CancellationToken cancellationToken)
        {
            var userIdClaim = _contextAccessor.HttpContext.User.Claims
                    .SingleOrDefault(c => c.Type == ClaimTypes.NameIdentifier);

            if (userIdClaim != null && Guid.TryParse(userIdClaim.Value, out Guid userId))
            {
                _response.Result = userId;
                _response.StatusCode = HttpStatusCode.OK;
                _response.Message = "User ID Retrieved Successfully";


                return _response;
            }

            throw new UnauthorizedAccessException("User ID claim not found or not valid.");
        }
    }
}
