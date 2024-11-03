﻿using System.Net;

namespace Poc.ShopCqrs.Domain.ViewModel
{
    public class CustomResponseViewModel<T>(T result)
    {
        public string Mensagem { get; set; } = "Operação realizada com sucesso.";
        public bool Error { get; set; } = false;
        public T Result { get; set; } = result;
        public HttpStatusCode StatusCode { get; set; } = HttpStatusCode.OK;
    }
}