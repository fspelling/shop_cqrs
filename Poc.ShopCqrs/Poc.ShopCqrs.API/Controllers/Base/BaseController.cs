﻿using Microsoft.AspNetCore.Mvc;
using Poc.ShopCqrs.Application.ViewModel.Base;
using System.Net;

namespace Poc.ShopCqrs.API.Controllers.Base
{
    public abstract class BaseController : ControllerBase
    {
        protected ActionResult<CustomResponseViewModel<T>> CustomResponse<T>(T result)
            => Ok(new CustomResponseViewModel<T>(result));

        protected ActionResult CustomResponseError(HttpStatusCode? statusCode = null, Exception? exception = null)
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
    }
}
