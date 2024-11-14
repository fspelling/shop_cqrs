namespace Poc.ShopCqrs.Domain.Exceptions
{
    public class EventStoreException(string message) : Exception(message)
    {
    }
}
