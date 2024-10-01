namespace Poc.ShopCqrs.Domain.Interfaces.Service
{
    public interface IEmailService
    {
        Task Send(string email);
    }
}
