using Microsoft.AspNetCore.Mvc;
using Poc.ShopCqrs.API.Controllers.Base;
using Poc.ShopCqrs.Application.EventStore.Model.Input;
using Poc.ShopCqrs.Application.EventStore.Model.View;
using Poc.ShopCqrs.Domain.Core.ViewModel;
using Poc.ShopCqrs.Domain.Entity;
using Poc.ShopCqrs.Domain.Exceptions;
using Poc.ShopCqrs.Domain.Interfaces.Service;
using StackExchange.Redis;
using System.Net;

namespace Poc.ShopCqrs.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EventStoreController(IEventStoreService eventStoreService) : BaseController
    {
        private readonly IEventStoreService _eventStoreService = eventStoreService;

        [HttpGet("{AggregateId}")]
        public async Task<ActionResult<CustomResponseViewModel<EventStoreViewModel>>> GetHistory(Guid AggregateId)
        {
            try
            {
                var response = await _eventStoreService.ObterHistoryPorAggregateId(AggregateId);
                return CustomResponse(new EventStoreViewModel() { EventsStore = response });
            }
            catch (EventStoreException e)
            {
                return CustomResponseError(HttpStatusCode.BadRequest, e);
            }
            catch (Exception e)
            {
                return CustomResponseError(HttpStatusCode.InternalServerError, e);
            }
        }

        [HttpPost("[action]")]
        public async Task<ActionResult<CustomResponseViewModel>> RestaureEntity([FromBody] EventStoreRestaureInputModel request)
        {
            try
            {
                await _eventStoreService.RestaureEntity<Customer>(request.EventStoreId, request.AggregateId);
                return CustomResponse();
            }
            catch (EventStoreException e)
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
