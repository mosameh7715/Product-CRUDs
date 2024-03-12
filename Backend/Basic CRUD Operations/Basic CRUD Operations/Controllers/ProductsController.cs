using Basic_CRUD_Operations.Features.ProductFeatures.Commands.DeleteProduct;
using Basic_CRUD_Operations.Features.ProductFeatures.Commands.PostProduct;
using Basic_CRUD_Operations.Features.ProductFeatures.Commands.PostProduct.DTOs;
using Basic_CRUD_Operations.Features.ProductFeatures.Commands.PutProduct;
using Basic_CRUD_Operations.Features.ProductFeatures.Commands.PutProduct.DTOs;
using Basic_CRUD_Operations.Features.ProductFeatures.Queries.GetAllProducts;
using Basic_CRUD_Operations.Features.ProductFeatures.Queries.GetProductById;
using Basic_CRUD_Operations.Models;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Basic_CRUD_Operations.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class ProductsController : ControllerBase
    {
        private readonly IMediator _mediator;
        public ProductsController(IMediator mediator)
        {
            _mediator = mediator;
        }
        #region GET 
        [HttpGet]
        [AllowAnonymous]
        public async Task<APIResponse> GetAllProducts(string? search, int pageSize = 9, int pageNumber = 1)
        {
            return await _mediator.Send(new GetAllProductsQuery()
            {
                Search = search,
                PageSize = pageSize,
                PageNumber = pageNumber
            });
        }
        [HttpGet]
        [Route("{id}")]
        [AllowAnonymous]
        public async Task<APIResponse> GetProductById(int id)
        {
            return await _mediator.Send(new GetProductByIdQuery() { Id = id });
        }
        #endregion

        #region POST
        [HttpPost]
        public async Task<APIResponse> PostProduct([FromForm] PostProductDTO postProductDTO)
        {
            return await _mediator.Send(new PostProductCommand() { PostProductDTO = postProductDTO });
        }
        #endregion

        #region PUT
        [HttpPut]
        [Route("{id}")]
        public async Task<APIResponse> PutProduct(int id, [FromForm] PutProductDTO putProductDTO)
        {
            return await _mediator.Send(new PutProductCommand() { Id = id, PutProductDTO = putProductDTO });
        }
        #endregion

        #region DELETE
        [HttpDelete]
        [Route("{id}")]
        public async Task<APIResponse> DeleteProduct(int id)
        {
            return await _mediator.Send(new DeleteProductCommand() { Id = id });
        }
        #endregion
    }
}
