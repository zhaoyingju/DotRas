﻿using System;
using System.Threading;
using DotRas.Internal.Abstractions.Factories;
using DotRas.Internal.Abstractions.Primitives;
using DotRas.Internal.Infrastructure.Primitives;

namespace DotRas.Internal.Infrastructure.Factories
{
    internal class TaskCancellationSourceFactory : ITaskCancellationSourceFactory
    {
        public ITaskCancellationSource Create()
        {
            CancellationTokenSource cancellationTokenSource = null;

            try
            {
                cancellationTokenSource = new CancellationTokenSource();

                return new TaskCancellationSource(
                    cancellationTokenSource);
            }
            catch (Exception)
            {
                cancellationTokenSource?.Dispose();
                throw;
            }
        }

        public ITaskCancellationSource Create(CancellationToken linkedCancellationToken)
        {
            CancellationTokenSource cancellationTokenSource = null;

            try
            {
                cancellationTokenSource = CancellationTokenSource.CreateLinkedTokenSource(linkedCancellationToken);

                return new TaskCancellationSource(
                    cancellationTokenSource);
            }
            catch (Exception)
            {
                cancellationTokenSource?.Dispose();
                throw;
            }
        }
    }
}