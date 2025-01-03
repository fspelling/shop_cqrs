﻿namespace Poc.ShopCqrs.Domain.Core.Messaging
{
    public abstract class Message
    {
        public string? MessageType { get; protected set; } 
        public string AggregateId { get; protected set; }

        protected Message()
            => MessageType = GetType().Name;
    }
}
