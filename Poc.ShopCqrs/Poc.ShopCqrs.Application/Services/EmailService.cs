﻿using Poc.ShopCqrs.Domain.Interfaces.Service;

namespace Poc.ShopCqrs.Application.Services
{
    public class EmailService : IEmailService
    {
        public Task Send(string email) => Task.CompletedTask;
    }
}
