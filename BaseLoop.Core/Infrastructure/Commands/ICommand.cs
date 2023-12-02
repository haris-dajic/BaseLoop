using MediatR;

namespace BaseLoop.Core.Infrastructure.Commands;

public interface ICommand: IRequest
{
}

public interface ICommand<TResponse> : IRequest<TResponse>
{
}