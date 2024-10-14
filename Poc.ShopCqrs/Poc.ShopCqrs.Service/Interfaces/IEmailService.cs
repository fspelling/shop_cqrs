namespace Poc.ShopCqrs.Service.Interfaces
{
    public interface IEmailService
    {
        Task Send(string email);
    }
}
