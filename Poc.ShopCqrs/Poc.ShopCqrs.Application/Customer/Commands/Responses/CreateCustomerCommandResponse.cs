﻿using EntityDb = Poc.ShopCqrs.Domain.Entity;

namespace Poc.ShopCqrs.Application.Customer.Commands.Responses
{
    public class CreateCustomerCommandResponse
    {
        public required EntityDb.Customer Customer { get; set; }
        public DateTime DateCriacao { get; set; }
    }
}