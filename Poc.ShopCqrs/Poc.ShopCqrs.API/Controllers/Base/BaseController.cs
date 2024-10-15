using MediatR;
using Microsoft.AspNetCore.Mvc;
using Poc.ShopCqrs.API.ViewModel;
using System.Net;

namespace Poc.ShopCqrs.API.Controllers.Base
{
    public abstract class BaseController(IMediator mediator) : ControllerBase
    {
        private readonly IMediator _mediator = mediator;

        protected async Task<ActionResult<CustomResponseViewModel<TResponse>>> SendMediator<TResponse, TException>(IRequest<TResponse> request)
            where TException : Exception
        {
            try
            {
                var response = await _mediator.Send(request);
                return CustomResponse(response);
            }
            catch(TException e)
            {
                return CustomResponseError(HttpStatusCode.BadRequest, e);
            }
            catch (Exception e)
            {
                return CustomResponseError(HttpStatusCode.InternalServerError, e);
            }
        }

        #region METODOS AUXILAIRES

        private ActionResult<CustomResponseViewModel<T>> CustomResponse<T>(T result)
            => Ok(new CustomResponseViewModel<T>(result));

        private ActionResult CustomResponseError(HttpStatusCode? statusCode = null, Exception? exception = null)
        {
            var responseError = new CustomResponseViewModel<string>(null!)
            {
                Error = true,
                Mensagem = exception!.Message,
                StatusCode = statusCode!.Value,
            };

            return statusCode switch
            {
                HttpStatusCode.BadRequest => BadRequest(responseError),
                _ => StatusCode((int)statusCode, responseError)
            };
        }

        #endregion
    }
}
