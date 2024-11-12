using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Poc.ShopCqrs.API.Controllers.Base;
using Poc.ShopCqrs.Application.Customer.Commands;
using Poc.ShopCqrs.Application.Customer.Model.Inputs;
using Poc.ShopCqrs.Application.Customer.Model.Views;
using Poc.ShopCqrs.Application.Customer.Queries;
using Poc.ShopCqrs.Domain.Exceptions;
using Poc.ShopCqrs.Domain.Interfaces.EventBus;
using Poc.ShopCqrs.Domain.ViewModel;
using System.Net;

namespace Poc.ShopCqrs.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController(IMapper mapper, IEventBus eventBus) : BaseController
    {
        private readonly IMapper _mapper = mapper;
        private readonly IEventBus _eventBus = eventBus;

        [HttpGet]
        public async Task<ActionResult<CustomResponseViewModel<CustomerViewModel>>> GetById([FromQuery] CustomerByIdInputModel request)
        {
            try
            {
                var mapperRequest = _mapper.Map<FindCustomerByIdQuery>(request);
                var response = await _eventBus.SendQuery(mapperRequest);
                var mapperResponse = _mapper.Map<CustomerViewModel>(response);

                return CustomResponse(mapperResponse);
            }
            catch (CustomerException e)
            {
                return CustomResponseError(HttpStatusCode.BadRequest, e);
            }
            catch (Exception e)
            {
                return CustomResponseError(HttpStatusCode.InternalServerError, e);
            }
        }

        [HttpPost]
        public async Task<ActionResult<CustomResponseViewModel<object>>> Create([FromBody] CustomerInputModel request)
        {
            try
            {
                var mapperRequest = _mapper.Map<CreateCustomerCommand>(request);
                await _eventBus.SendCommand(mapperRequest);

                return CustomResponse<object>(null!);
            }
            catch (CustomerException e)
            {
                return CustomResponseError(HttpStatusCode.BadRequest, e);
            }
            catch (Exception e)
            {
                return CustomResponseError(HttpStatusCode.InternalServerError, e);
            }
        }
    }
}
