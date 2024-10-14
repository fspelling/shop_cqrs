using Poc.ShopCqrs.Service.Interfaces;

namespace Poc.ShopCqrs.Service.Services
{
    public class EmailService : IEmailService
    {
        public Task Send(string email) => Task.CompletedTask;
    }
}
