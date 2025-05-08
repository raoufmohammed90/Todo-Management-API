using MediatR;

namespace GTS.ToDoMgmt.Application.Abstractions.Messaging
{
    public interface ICommand : IRequest
    {
    }
    public interface ICommand<TResponse> : IRequest<TResponse>
    {
    }
}
