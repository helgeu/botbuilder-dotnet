﻿// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading;
using System.Threading.Tasks;

namespace Microsoft.Bot.Builder
{
    /// <summary>
    /// Helper class for defining middleware by using a delegate or anonymous method.
    /// </summary>
    public class AnonymousReceiveMiddleware : IMiddleware
    {
        private readonly Func<ITurnContext, NextDelegate, CancellationToken, Task> _toCall;

        /// <summary>
        /// Creates a middleware object that uses the provided method as its
        /// process request handler.
        /// </summary>
        /// <param name="anonymousMethod">The method to use as the middleware's process 
        /// request handler.</param>
        public AnonymousReceiveMiddleware(Func<ITurnContext, NextDelegate, CancellationToken, Task> anonymousMethod)
        {
            _toCall = anonymousMethod ?? throw new ArgumentNullException(nameof(anonymousMethod));
        }

        /// <summary>
        /// Uses the method provided in the <see cref="AnonymousReceiveMiddleware"/> to
        /// process an incoming activity.
        /// </summary>
        /// <param name="context">The context object for this turn.</param>
        /// <param name="next">The delegate to call to continue the bot middleware pipeline.</param>
        /// <returns>A task that represents the work queued to execute.</returns>
        public Task OnTurn(ITurnContext context, NextDelegate next, CancellationToken cancellationToken)
        {
            return _toCall(context, next, cancellationToken);
        }
    }   
}
