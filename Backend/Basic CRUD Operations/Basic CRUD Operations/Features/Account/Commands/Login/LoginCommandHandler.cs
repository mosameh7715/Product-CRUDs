using Basic_CRUD_Operations.Models;
using Basic_CRUD_Operations.Models.Product;
using Basic_CRUD_Operations.Repositories;
using IdentityModel.Client;
using MediatR;
using System.Net;

namespace Basic_CRUD_Operations.Features.Account.Commands.Login
{
    public class LoginCommandHandler : IRequestHandler<LoginCommand, APIResponse>
    {
        private APIResponse _response;
        private readonly IConfiguration _configuration;

        public LoginCommandHandler(IRepository<Product> productRepository, IConfiguration configuration)
        {
            _response = new APIResponse();
            _configuration = configuration;
        }

        async Task<APIResponse> IRequestHandler<LoginCommand, APIResponse>.Handle(LoginCommand request, CancellationToken cancellationToken)
        {
            var client = new HttpClient();

            // send token req to identity server with client and user credintials 
            var token = await client.RequestPasswordTokenAsync(new PasswordTokenRequest
            {
                Address = $"{_configuration.GetValue<string>("IdentityUrl")}/connect/token",
                GrantType = "password",
                ClientId = "FullAccessClient",
                ClientSecret = "secret",
                Scope = "product.read product.write",
                UserName = request.UserName,
                Password = request.Password
            });

            if (token.AccessToken is null)
            {
                throw new Exception("Username or password is not correct");
            }


            _response.Result = token.AccessToken;
            _response.StatusCode = HttpStatusCode.OK;
            _response.Message = "Logged In Successfully";


            return _response;
        }
    }
}
