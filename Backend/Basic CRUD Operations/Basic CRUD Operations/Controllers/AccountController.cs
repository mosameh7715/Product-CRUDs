using Basic_CRUD_Operations.Features.Account.Commands.Login;
using Basic_CRUD_Operations.Features.Account.Queries.GetLoggedInUser;
using Basic_CRUD_Operations.Models;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Basic_CRUD_Operations.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly IMediator _mediator;
        public AccountController(IMediator mediator)
        {
            _mediator = mediator;
        }
        #region POST
        [HttpPost]
        public async Task<APIResponse> Login(LoginCommand login)
        {
            return await _mediator.Send(login);
        }
        #endregion

        #region GET
        [HttpGet]
        [Authorize]
        public async Task<APIResponse> GetLoggedInUser()
        {
            return await _mediator.Send(new GetLoggedInUserQuery());
        }
        #endregion
    }
}
