﻿using MediatR;

namespace Poc.ShopCqrs.Domain.Core.Messaging
{
    public abstract class Query<TResponse> : IRequest<TResponse>
    {
        public required TimeSpan TimeStamp { get; set; } = TimeSpan.Zero;
    }
}
