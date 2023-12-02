using MediatR;

namespace BaseLoop.Core.Infrastructure.Commands;

public class CommandDispatcher : IDispatcher
{
    private readonly IMediator _mediator;

    public CommandDispatcher(IMediator mediator)
    {
        _mediator = mediator;
    }
    
    public async Task<TResult> DispatchAsync<TResult>(IRequest<TResult> request, CancellationToken cancellationToken = default)
    {
        return await _mediator.Send(request, cancellationToken);
    }

    public async Task DispatchAsync(IRequest request, CancellationToken cancellationToken = default)
    {
        await _mediator.Send(request, cancellationToken);
    }
}