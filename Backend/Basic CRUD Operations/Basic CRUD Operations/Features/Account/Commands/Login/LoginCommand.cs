using Basic_CRUD_Operations.Models;
using MediatR;

namespace Basic_CRUD_Operations.Features.Account.Commands.Login
{
    public class LoginCommand : IRequest<APIResponse>
    {
        public string UserName { get; set; }
        public string Password { get; set; }
    }
}
