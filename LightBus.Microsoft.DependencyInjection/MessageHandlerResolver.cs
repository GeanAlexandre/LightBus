﻿using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;

namespace LightBus.Microsoft.DependencyInjection
{
    public class MessageHandlerResolver : IMessageHandlerResolver
    {
        private readonly IServiceProvider _services;

        public MessageHandlerResolver(IServiceProvider services)
        {
            _services = services;
        }

        public IEnumerable<IMessageHandler<TMessage>> GetMessageHandlers<TMessage>() where TMessage : IMessage
        {
            return _services.GetServices<IMessageHandler<TMessage>>();
        }

        public IMessageHandler<TMessage, TResponse> GetMessageHandler<TMessage, TResponse>()
            where TMessage : IMessage<TResponse>, new()
        {
            return _services.GetService<IMessageHandler<TMessage, TResponse>>();
        }
    }
}
