using MediatR;
using Microsoft.AspNetCore.Mvc;
using Poc.ShopCqrs.API.Controllers.Base;
using Poc.ShopCqrs.Application.Commands.Requests;
using Poc.ShopCqrs.Application.Commands.Responses;
using Poc.ShopCqrs.Application.Queries.Requests;
using Poc.ShopCqrs.Application.Queries.Responses;
using Poc.ShopCqrs.Application.ViewModel;
using Poc.ShopCqrs.Domain.Exceptions;

namespace Poc.ShopCqrs.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController(IMediator mediator) : BaseController(mediator)
    {
        [HttpGet]
        public async Task<ActionResult<CustomResponseViewModel<FindCustomerByIdResponse>>> GetById([FromQuery] FindCustomerByIdRequest query)
            => await SendMediator<FindCustomerByIdResponse, CustomerException>(query);

        [HttpPost]
        public async Task<ActionResult<CustomResponseViewModel<CreateCustomerResponse>>> Create([FromBody]CreateCustomerRequest command)
            => await SendMediator<CreateCustomerResponse, CustomerException>(command);
    }
}
