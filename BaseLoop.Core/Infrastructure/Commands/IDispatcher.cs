using MediatR;

namespace BaseLoop.Core.Infrastructure.Commands;

public interface IDispatcher
{
    Task<TResult> DispatchAsync<TResult>(IRequest<TResult> request, CancellationToken cancellationToken = default);
    Task DispatchAsync(IRequest request, CancellationToken cancellationToken = default);
}