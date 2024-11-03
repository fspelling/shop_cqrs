using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Poc.ShopCqrs.API.Controllers.Base;
using Poc.ShopCqrs.Application.Customer.Commands.Requests;
using Poc.ShopCqrs.Application.Customer.Queries.Requests;
using Poc.ShopCqrs.Application.Customer.ViewModel;
using Poc.ShopCqrs.Domain.Exceptions;
using Poc.ShopCqrs.Domain.Messaging;
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
        public async Task<ActionResult<CustomResponseViewModel<CustomerResponseViewModel>>> GetById([FromQuery] CustomerByIdViewModel request)
        {
            try
            {
                var mapperRequest = _mapper.Map<FindCustomerByIdQueryRequest>(request);
                var response = await _eventBus.Send(mapperRequest);
                var mapperResponse = _mapper.Map<CustomerResponseViewModel>(response);

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
        public async Task<ActionResult<CustomResponseViewModel<CustomerResponseViewModel>>> Create([FromBody] CustomerViewModel request)
        {
            try
            {
                var mapperRequest = _mapper.Map<CreateCustomerCommandRequest>(request);
                var response = await _eventBus.Send(mapperRequest);
                var mapperResponse = _mapper.Map<CustomerResponseViewModel>(response);

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
    }
}
